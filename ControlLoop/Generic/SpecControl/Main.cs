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

namespace SpecControl {
    public partial class Main : Form {

        MaxIm.CCDCamera ccd;



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
                                

            motorXlbl.Text = "X: " + motorX.ToString();
            motorYlbl.Text = "Y: " + motorY.ToString();


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

			//Read error from MaxIm

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

				
				/*
				
				
				stepsToMoveXd and stepsToMoveYd are the output of the PID loop, to use however you wish
				
				
				*/
            
        }

        private void button1_Click(object sender, EventArgs e) {
            //X forward

      
        }

        private void button2_Click(object sender, EventArgs e) {
            //X backward


        }

        private void button4_Click(object sender, EventArgs e) {
            //Y forward


        }

        private void button3_Click(object sender, EventArgs e) {
            //Y backward


        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
  
			//Save the settings when closing

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
            
            Properties.Settings.Default.Save();


        }

        

    }

}