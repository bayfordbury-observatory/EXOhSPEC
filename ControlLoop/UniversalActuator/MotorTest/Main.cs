using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using Thorlabs.MotionControl.DeviceManagerCLI;
using Thorlabs.MotionControl.GenericMotorCLI;
using Thorlabs.MotionControl.GenericMotorCLI.ControlParameters;
using Thorlabs.MotionControl.GenericMotorCLI.AdvancedMotor;
using Thorlabs.MotionControl.GenericMotorCLI.Settings;
using Thorlabs.MotionControl.TCube.DCServoCLI;
using Thorlabs.MotionControl.TCube.InertialMotorCLI;

namespace SpecControl {
    public partial class Main : Form {

        MaxIm.CCDCamera ccd;

        bool TIM = false;

        TCubeInertialMotor[] devicesTIM = new TCubeInertialMotor[2];
        TCubeInertialMotor deviceTIM;

        TCubeDCServo[] devicesTDC = new TCubeDCServo[2];
        List<string> serialNumbersTDC;
        //TCubeDCServo deviceTDC;

        Int32 motorX, motorY, targetX, targetY;
        decimal motorXd, motorYd;
        double errX, errY;

        double stepSizeX, stepSizeY; //stepSizeX= 2,

        Stopwatch stopWatch = new Stopwatch();

        int jog = 10;
        decimal jogd = 10;

        int stepsToMoveX, stepsToMoveY; //stepsToMove
        decimal stepsToMoveXd, stepsToMoveYd;

        //PID variables
        double Kpx, Kix, Kdx, Kpy, Kiy, Kdy, intX = 0, intY = 0, derrXav, derrYav, dt, imaxX, imaxY, lastErrX = 0, lastErrY = 0;
        double KpxO, KixO, KdxO, KpyO, KiyO, KdyO;

        private void enableLbl_Click(object sender, EventArgs e) {
            intX = 0;
            intY = 0;
        }

        int minMoveX, minMoveY;

        double[] derrX = new double[3];
        double[] derrY = new double[3];

        private void button5_Click(object sender, EventArgs e) {
            intX = 0;
            intY = 0;
        }

        InertialMotorStatus.MotorChannels ch1, ch2;

        //float ltime;

        bool first = true;

        public volatile bool eventFlag;
        public volatile bool ready;
        public volatile string p_eventCode;

        public Main() {
            InitializeComponent();
            
               if (Properties.Settings.Default.UpgradeRequired) {
                    Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.UpgradeRequired = false;
                Properties.Settings.Default.Save();
            }

            derrX[0] = 0; derrX[1] = 0; derrX[2] = 0; derrY[0] = 0; derrY[1] = 0; derrY[2] = 0;



            stopWatch.Start();

            //Get the list of IM devices
            DeviceManagerCLI.BuildDeviceList();

            List<string> serialNumbersTIM = DeviceManagerCLI.GetDeviceList(TCubeInertialMotor.DevicePrefix);
            serialNumbersTDC = DeviceManagerCLI.GetDeviceList(TCubeDCServo.DevicePrefix);

            richTextBox1.AppendText("TIM devices: " + serialNumbersTIM.Count() + " | TDC devices: " + serialNumbersTDC.Count() + Environment.NewLine);

            //Put the devices into an array


            for (int i = 0; i < serialNumbersTDC.Count(); i++) {

                devicesTDC[i] = TCubeDCServo.CreateTCubeDCServo(serialNumbersTDC[i]);
                TIM = false;
            }

            for (int i = 0; i < serialNumbersTIM.Count(); i++) {
                //TIM takes preference
                devicesTIM[i] = TCubeInertialMotor.CreateTCubeInertialMotor(serialNumbersTIM[i]);
                TIM = true;
            }




            if (TIM) {



                KpxUD.Value = (decimal)Properties.Settings.Default.Kpx;
                KixUD.Value = (decimal)Properties.Settings.Default.Kix;
                KdxUD.Value = (decimal)Properties.Settings.Default.Kdx;
                KpyUD.Value = (decimal)Properties.Settings.Default.Kpy;
                KiyUD.Value = (decimal)Properties.Settings.Default.Kiy;
                KdyUD.Value = (decimal)Properties.Settings.Default.Kdy;
                minMoveXUD.Value = (decimal)Properties.Settings.Default.minMoveX;
                minMoveYUD.Value = (decimal)Properties.Settings.Default.minMoveY;

                imaxxUD.Value = (decimal)Properties.Settings.Default.imaxX;
                imaxyUD.Value = (decimal)Properties.Settings.Default.imaxY;

                reverseX.Checked = Properties.Settings.Default.revx;
                reverseY.Checked = Properties.Settings.Default.revy;

                deviceTIM = devicesTIM[0];

                //Connect and initialise

                deviceTIM.Connect(serialNumbersTIM[0]);

                if (!deviceTIM.IsSettingsInitialized()) {
                    deviceTIM.WaitForSettingsInitialized(5000);
                }

                deviceTIM.StartPolling(100);

                // call GetMotorConfiguration on the device to initialize the DeviceUnitConverter object required for real world unit parameters            
                //MotorConfiguration motorSettings = device[i].GetMotorConfiguration(serialNumbers[i]);

                InertialMotorConfiguration motorSettings = deviceTIM.GetInertialMotorConfiguration(serialNumbersTIM[0]);
                ThorlabsInertialMotorSettings currentDeviceSettings = deviceTIM.InertialMotorDeviceSettings as ThorlabsInertialMotorSettings;

                // display info about device            
                DeviceInfo deviceInfo = deviceTIM.GetDeviceInfo();
                richTextBox1.AppendText("Selected device " + deviceInfo.Name + " serial: " + deviceInfo.SerialNumber + Environment.NewLine);// device[i].GetPosition(ch1).ToString("F4")

                ch1 = InertialMotorStatus.MotorChannels.Channel1;
                ch2 = InertialMotorStatus.MotorChannels.Channel2;

                //Set step rate and acceleration

                currentDeviceSettings.Drive.Channel(ch1).StepRate = 1000;
                currentDeviceSettings.Drive.Channel(ch1).StepAcceleration = 100000;
                currentDeviceSettings.Drive.Channel(ch2).StepRate = 1000;
                currentDeviceSettings.Drive.Channel(ch2).StepAcceleration = 100000;


                //apply setting

                deviceTIM.SetSettings(currentDeviceSettings, true, true);

                //get motor positions and print

                motorX = deviceTIM.GetPosition(ch1);//GetPosition(ch1);
                motorY = deviceTIM.GetPosition(ch2);

            } else {

                //TDC



                KpxUD.Value = (decimal)Properties.Settings.Default.Kpx2;
                KixUD.Value = (decimal)Properties.Settings.Default.Kix2;
                KdxUD.Value = (decimal)Properties.Settings.Default.Kdx2;
                KpyUD.Value = (decimal)Properties.Settings.Default.Kpy2;
                KiyUD.Value = (decimal)Properties.Settings.Default.Kiy2;
                KdyUD.Value = (decimal)Properties.Settings.Default.Kdy2;
                minMoveXUD.Value = (decimal)Properties.Settings.Default.minMoveX2;
                minMoveYUD.Value = (decimal)Properties.Settings.Default.minMoveY2;

                imaxxUD.Value = (decimal)Properties.Settings.Default.imaxX2;
                imaxyUD.Value = (decimal)Properties.Settings.Default.imaxY2;

                reverseX.Checked = Properties.Settings.Default.revx2;
                reverseY.Checked = Properties.Settings.Default.revy2;

                stepUpDown.DecimalPlaces = 2;
                stepUpDown.Increment = (decimal)0.05;

                for (int i = 0; i < serialNumbersTDC.Count(); i++) {

                    devicesTDC[i] = TCubeDCServo.CreateTCubeDCServo(serialNumbersTDC[i]);

                    richTextBox1.AppendText(i + " Serial: " + serialNumbersTDC[i]);

                    try {

                        devicesTDC[i].Connect(serialNumbersTDC[i]);

                        if (!devicesTDC[i].IsSettingsInitialized()) {
                            devicesTDC[i].WaitForSettingsInitialized(5000);
                        }

                        devicesTDC[i].StartPolling(100);

                        MotorConfiguration motorSettings = devicesTDC[i].GetMotorConfiguration(serialNumbersTDC[i], DeviceConfiguration.DeviceSettingsUseOptionType.UseDeviceSettings); //serialNumbersTDC[i]

                        DCMotorSettings currentDeviceSettings = devicesTDC[i].MotorDeviceSettings as DCMotorSettings;

                        // display info about device            
                        DeviceInfo deviceInfo = devicesTDC[i].GetDeviceInfo();
                        richTextBox1.AppendText(i + " Device  " + deviceInfo.Name + " " + deviceInfo.SerialNumber + " " + devicesTDC[i].GetMoveAbsolutePosition().ToString("F4") + Environment.NewLine);

                    } catch (Exception ex) {
                        richTextBox1.AppendText(" " + ex.Message + Environment.NewLine);

                    }

                }




            }




            motorXlbl.Text = "X: " + motorX.ToString();
            motorYlbl.Text = "Y: " + motorY.ToString();





            if (TIM) {
                //get status of ch1

                //InertialMotorStatus status = deviceTIM.ChannelStatus(ch1);
                // richTextBox1.AppendText(status.Status + " " + status.Position + " " + status.IsError + " " + status.IsMoving + Environment.NewLine);// device[i].GetPosition(ch1).ToString("F4")

            } else {

            }


            //Create MaxIm DL object

            ccd = new MaxIm.CCDCamera();

            // ccd.Notify += notify();

            //Connect CCD

            ccd.LinkEnabled = true;

            /*
            ccd.MultiStarGuiding = true;

            ccd.GuiderExpose(1.0);

            while (ccd.GuiderRunning) {
                Thread.Sleep(100);
            }

            ccd.GuiderTrack(1.0);
            */

            //Thread.Sleep(2000);

            //Notify on new guider image(?)

            ccd.EventMask = 256;

            ccd.Notify += new MaxIm._CameraEvents_NotifyEventHandler(notify);

            //Sets minimum correction interval

            timer1.Interval = Convert.ToInt16(correctionUpDown.Value * 1000);
            timer1.Enabled = true;

            ready = true;
        }

        //start stop correction loop
        private void timerEnabled_Click(object sender, EventArgs e) {
            if (timer1.Enabled) {
                timer1.Enabled = false;
                timerEnabled.Text = "Start timer";
            } else {
                intX = 0;
                intY = 0;
                timer1.Enabled = true;
                timerEnabled.Text = "Stop timer";
            }
        }

        private void timer1_Tick(object sender, EventArgs e) {

            //Get motor positions
            if (TIM) {
                position_Update2(deviceTIM, ch1);
                position_Update2(deviceTIM, ch2);
            } else {

                position_Update1(0);
                position_Update1(1);

            }

            if (eventFlag && ready) {
                eventFlag = false;
                timer1.Enabled = false;

                //while (!ccd.GuiderNewMeasurement) { }

                //get the error values from MaxIm
                errX = ccd.GuiderXError;
                errY = ccd.GuiderYError;

                guiderXlbl.Text = "X: " + errX.ToString("F5");
                guiderYlbl.Text = "Y: " + errY.ToString("F5");

               
                

                //perform correction
                correction();

                //reset timer
                timer1.Interval = Convert.ToInt16(correctionUpDown.Value * 1000);
                timer1.Enabled = true;

            }

        }

        //receive update from MaxIm and set flag
        void notify(short EventCode) {
            eventFlag = true;

        }

        //calculate how far to move and perform the move
        void correction() {

            //Get PID coefficients
            Kpx = (double)KpxUD.Value;
            Kix = (double)KixUD.Value;
            Kdx = (double)KdxUD.Value;
            Kpy = (double)KpyUD.Value;
            Kiy = (double)KiyUD.Value;
            Kdy = (double)KdyUD.Value;

            //maximum integral value to prevent windup
            imaxX = (double)imaxxUD.Value;
            imaxY = (double)imaxyUD.Value;

            //don't move if error less than this
            minMoveX = (int)minMoveXUD.Value;
            minMoveY = (int)minMoveYUD.Value;

            //when error is small enough, add to integral
            if (errX < 20 && enableLbl.Checked) {
                intX += errX;
            }

            if (errY < 20 && enableLbl.Checked) {
                intY += errY;
            }

            //prevent integral windup
            if (intX > imaxX) {
                intX = imaxX;
            }
            if (intX < -imaxX) {
                intX = -imaxX;
            }
            if (intY > imaxY) {
                intY = imaxY;
            }
            if (intY < -imaxY) {
                intY = -imaxY;
            }

            //calculate derivite
            derrX[2] = derrX[1];
            derrX[1] = derrX[0];
            derrY[2] = derrY[1];
            derrY[1] = derrY[0];

            derrX[0] = errX - lastErrX;
            derrY[0] = errY - lastErrY;

            lastErrX = errX;
            lastErrY = errY;

            derrXav = (derrX[0] + derrX[1] + derrX[2]) / 3;
            derrYav = (derrY[0] + derrY[1] + derrY[2]) / 3;

            //time since last
            dt = Convert.ToDouble(stopWatch.ElapsedMilliseconds) / 1000;
            stopWatch.Restart();

            loopTimeLbl.Text = dt.ToString("F3") + "s";

            //calculate correction value

            KpxO = (Kpx * errX);
            KixO = (Kix * intX * dt);
            KdxO = (Kdx * derrXav / dt);

            KpyO = (Kpy * errY);
            KiyO = (Kiy * intY * dt);
            KdyO = (Kdy * derrYav / dt);

            //write errors to string
            kpxLbl.Text = errX.ToString("F2");
            kixLbl.Text = intX.ToString("F2");
            kdxLbl.Text = derrXav.ToString("F2");

            kpyLbl.Text = errY.ToString("F2");
            kiyLbl.Text = intY.ToString("F2");
            kdyLbl.Text = derrYav.ToString("F2");

            //steps to move = P +I -D
            stepSizeX = KpxO + KixO - KdxO;
            stepSizeY = KpyO + KiyO - KdyO;



            //add to current motor position to get 

            if (TIM) {

                //convert to numbers of steps and reverse if necessary
                if (reverseX.Checked) {
                    stepsToMoveX = Convert.ToInt32(Math.Round(0 - stepSizeX));
                } else {
                    stepsToMoveX = Convert.ToInt32(Math.Round(stepSizeX));
                }
                if (reverseY.Checked) {
                    stepsToMoveY = Convert.ToInt32(Math.Round(0 - stepSizeY));
                } else {
                    stepsToMoveY = Convert.ToInt32(Math.Round(stepSizeY));
                }

                motorX = deviceTIM.GetPosition(ch1);
                motorY = deviceTIM.GetPosition(ch2);


                targetX = motorX + stepsToMoveX;
                targetY = motorY + stepsToMoveY;


            } else {
                //convert to numbers of steps and reverse if necessary
                if (reverseX.Checked) {
                    stepsToMoveXd = (decimal)(0 - stepSizeX);
                } else {
                    stepsToMoveXd = (decimal)stepSizeX;
                }
                if (reverseY.Checked) {
                    stepsToMoveYd = (decimal)(0 - stepSizeY);
                } else {
                    stepsToMoveYd = (decimal)stepSizeY;
                }

            }



            if (enableLbl.Checked && !first) {

                if (TIM) {

                    //only move if it's big enough
                    if (Math.Abs(stepsToMoveX) >= minMoveX) {

                        //do the move in X
                        Move_Method2(deviceTIM, ch1, targetX);

                        richTextBox1.AppendText("X err " + errX.ToString("F3") + " px  (=" + stepSizeX.ToString("F1") + " steps) Moving " + stepsToMoveX + " steps" + Environment.NewLine);

                    } else {

                        //no move, just print info
                        richTextBox1.AppendText("X err " + errX.ToString("F3") + " px  (=" + stepSizeX.ToString("F1") + " steps)" + Environment.NewLine);

                    }


                    if (Math.Abs(stepsToMoveY) >= minMoveY) {

                        //do the move in Y
                        Move_Method2(deviceTIM, ch2, targetY);

                        richTextBox1.AppendText("Y err " + errY.ToString("F3") + " px  (=" + stepSizeY.ToString("F1") + " steps) Moving " + stepsToMoveY + " steps" + Environment.NewLine);

                    } else {

                        richTextBox1.AppendText("Y err " + errY.ToString("F3") + " px  (=" + stepSizeY.ToString("F1") + " steps)" + Environment.NewLine);

                    }
                } else {
                    //TDC

                    if (Math.Abs(stepsToMoveXd) >= (decimal)minMoveX) {

                        //do the move in X
                        Move_Method1(1, stepsToMoveXd);

                        richTextBox1.AppendText("X err " + errX.ToString("F3") + " px  (=" + stepSizeX.ToString("F5") + " steps) Moving " + stepsToMoveXd.ToString("F5") + " steps" + Environment.NewLine);

                    } else {

                        //no move, just print info
                        richTextBox1.AppendText("X err " + errX.ToString("F3") + " px  (=" + stepSizeX.ToString("F5") + " steps)" + Environment.NewLine);

                    }


                    if (Math.Abs(stepsToMoveYd) >= (decimal)minMoveY) {

                        //do the move in Y
                        Move_Method1(0, stepsToMoveYd);

                        richTextBox1.AppendText("Y err " + errY.ToString("F3") + " px  (=" + stepSizeY.ToString("F5") + " steps) Moving " + stepsToMoveYd.ToString("F5") + " steps" + Environment.NewLine);

                    } else {

                        richTextBox1.AppendText("Y err " + errY.ToString("F3") + " px  (=" + stepSizeY.ToString("F5") + " steps)" + Environment.NewLine);

                    }
                }

            } 

            richTextBox1.ScrollToCaret();
            first = false;

        }

        private void button1_Click(object sender, EventArgs e) {
            //X forward
            if (TIM) {

                jog = Convert.ToInt32(stepUpDown.Value);
                motorX = deviceTIM.GetPosition(ch1);
                Move_Method2(deviceTIM, ch1, motorX + jog);
                // motorXlbl.Text = "X: " + motorX.ToString();//+ " moving " + jog + " steps";
            } else {

                jogd = stepUpDown.Value;
                Move_Method1(1, jogd);
            }



        }

        private void button2_Click(object sender, EventArgs e) {
            //X backward
            if (TIM) {

                jog = Convert.ToInt32(stepUpDown.Value);
                motorX = deviceTIM.GetPosition(ch1);
                Move_Method2(deviceTIM, ch1, motorX - jog);
                // motorXlbl.Text = "X: " + motorX.ToString();//+ " moving -" + jog + " steps";
            } else {
                jogd = 0-stepUpDown.Value;
                Move_Method1(1, jogd);
            }

        }

        private void button4_Click(object sender, EventArgs e) {
            //Y forward
            if (TIM) {

                jog = Convert.ToInt32(stepUpDown.Value);
                motorY = deviceTIM.GetPosition(ch2);
                Move_Method2(deviceTIM, ch2, motorY + jog);
                // motorYlbl.Text = "Y: " + motorY.ToString();//+ " moving " + jog + " steps"; ;
            } else {

                jogd = stepUpDown.Value;
                Move_Method1(0, jogd);
            }

        }

        private void button3_Click(object sender, EventArgs e) {
            //Y backward

            if (TIM) {
                jog = Convert.ToInt32(stepUpDown.Value);
                motorY = deviceTIM.GetPosition(ch2);
                Move_Method2(deviceTIM, ch2, motorY - jog);
                //  motorYlbl.Text = "Y: " + motorY.ToString();
            } else {
                jogd = 0-stepUpDown.Value;
                Move_Method1(0, jogd);
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            if (TIM) {
                deviceTIM.StopPolling();
                deviceTIM.Disconnect(true);

                Properties.Settings.Default.Kpx = (double)KpxUD.Value;
                Properties.Settings.Default.Kix = (double)KixUD.Value;
                Properties.Settings.Default.Kdx = (double)KdxUD.Value;
                Properties.Settings.Default.Kpy = (double)KpyUD.Value;
                Properties.Settings.Default.Kiy = (double)KiyUD.Value;
                Properties.Settings.Default.Kdy = (double)KdyUD.Value;

                Properties.Settings.Default.imaxX = (double)imaxxUD.Value;
                Properties.Settings.Default.imaxY = (double)imaxyUD.Value;

                Properties.Settings.Default.minMoveX = (double)minMoveXUD.Value;
                Properties.Settings.Default.minMoveY = (double)minMoveYUD.Value;

                Properties.Settings.Default.revx = reverseX.Checked;
                Properties.Settings.Default.revy = reverseY.Checked;

            } else {
                for (int i = 0; i < serialNumbersTDC.Count(); i++) {
                    devicesTDC[i].StopPolling();
                    devicesTDC[i].Disconnect(true);
                }


                Properties.Settings.Default.Kpx2 = (double)KpxUD.Value;
                Properties.Settings.Default.Kix2 = (double)KixUD.Value;
                Properties.Settings.Default.Kdx2 = (double)KdxUD.Value;
                Properties.Settings.Default.Kpy2 = (double)KpyUD.Value;
                Properties.Settings.Default.Kiy2 = (double)KiyUD.Value;
                Properties.Settings.Default.Kdy2 = (double)KdyUD.Value;

                Properties.Settings.Default.imaxX2 = (double)imaxxUD.Value;
                Properties.Settings.Default.imaxY2 = (double)imaxyUD.Value;

                Properties.Settings.Default.minMoveX2 = (double)minMoveXUD.Value;
                Properties.Settings.Default.minMoveY2 = (double)minMoveYUD.Value;

                Properties.Settings.Default.revx2 = reverseX.Checked;
                Properties.Settings.Default.revy2 = reverseY.Checked;
            }


            Properties.Settings.Default.Save();


        }

        private static bool _taskComplete;

        private static ulong _taskID;

        public static void CommandCompleteFunction(ulong taskID) {
            if ((_taskID > 0) && (_taskID == taskID)) {
                _taskComplete = true;
            }
        }

        public void Move_Method2(TCubeInertialMotor device, InertialMotorStatus.MotorChannels channel, int position) {
            //TIM

            ready = false;
            _taskComplete = false;

            richTextBox1.ScrollToCaret();

            _taskID = device.MoveTo(channel, position, CommandCompleteFunction);
            int i = 0;
            while (!_taskComplete) {
                Thread.Sleep(250);
                if (channel == ch1) {
                    motorX = device.GetPosition(channel);
                    motorXlbl.Text = "X: " + motorX.ToString() + " - moving";
                } else {
                    motorY = device.GetPosition(channel);
                    motorYlbl.Text = "Y: " + motorY.ToString() + " - moving";

                }

                if (i > 10) {
                    device.Stop(channel);
                    break;
                }

                i++;
                Application.DoEvents();
                // will need some timeout functionality;         
            }


      
            Application.DoEvents();
            ready = true;

            position_Update2(device, channel);
        }

        public void position_Update2(TCubeInertialMotor device, InertialMotorStatus.MotorChannels channel) {

            if (channel == ch1) {
                motorX = device.GetPosition(channel);
                motorXlbl.Text = "X: " + motorX.ToString();
            } else {
                motorY = device.GetPosition(channel);
                motorYlbl.Text = "Y: " + motorY.ToString();

            }
        }

        public void Move_Method1(int channel,  decimal size) {
            //TDC

            if (size < 0) {
                devicesTDC[channel].MoveRelative(MotorDirection.Backward, Math.Abs(size), 2000);
            } else {
                devicesTDC[channel].MoveRelative(MotorDirection.Forward, size, 2000);               
            }

            position_Update1(channel);
        }

        public void position_Update1(int channel) {
            try {
                if (channel == 1) {//x=1
                    motorXd = devicesTDC[channel].Position; ;
                    motorXlbl.Text = "X: " + motorXd.ToString("F1");
                } else { //y=0
                    motorYd = devicesTDC[channel].Position; ;
                    motorYlbl.Text = "Y: " + motorYd.ToString("F1");

                }
            } catch (Exception ex){

            }
        }

    }

}