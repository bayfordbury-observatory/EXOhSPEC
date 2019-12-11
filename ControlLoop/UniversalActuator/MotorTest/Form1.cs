using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

namespace MotorTest {
    public partial class Form1 : Form {

        MaxIm.CCDCamera ccd;
        TCubeDCServo[] device = new TCubeDCServo[2];

        double motorX, motorY, guiderX, guiderY;

        double stepSize = 0.1, move;

        double aggresivenessX = 0.5, aggresivenessY = 0.5;

        int i = 0;

        public Form1() {
            InitializeComponent();

            DeviceManagerCLI.BuildDeviceList();

            List<string> serialNumbers = DeviceManagerCLI.GetDeviceList(TCubeDCServo.DevicePrefix);

            richTextBox1.Text = serialNumbers.Count().ToString();

            for (int i = 0; i < serialNumbers.Count(); i++) {

                device[i] = TCubeDCServo.CreateTCubeDCServo(serialNumbers[i]);

                device[i].Connect(serialNumbers[i]);
                if (!device[i].IsSettingsInitialized()) {
                    device[i].WaitForSettingsInitialized(5000);
                }

                device[i].StartPolling(250);

                // call GetMotorConfiguration on the device to initialize the DeviceUnitConverter object required for real world unit parameters            
                MotorConfiguration motorSettings = device[i].GetMotorConfiguration(serialNumbers[i]);
                DCMotorSettings currentDeviceSettings = device[i].MotorDeviceSettings as DCMotorSettings;

                // display info about device            
                DeviceInfo deviceInfo = device[i].GetDeviceInfo();
                richTextBox1.AppendText(Environment.NewLine + "Device " + deviceInfo.SerialNumber + " " + deviceInfo.Name + " " + device[i].GetMoveAbsolutePosition().ToString("F4")+ Environment.NewLine);

                
            }
            
            ccd = new MaxIm.CCDCamera();

            ccd.LinkEnabled = true;

            ccd.MultiStarGuiding = true;

            ccd.GuiderExpose(1.0);

            while (ccd.GuiderRunning) {
                Thread.Sleep(1000);
            }

            ccd.GuiderTrack(0.1);

            // Thread.Sleep(1000);

            timer1.Enabled = true;
        }

        private void timerEnabled_Click(object sender, EventArgs e) {
            if (timer1.Enabled) {
                timer1.Enabled = false;
                timerEnabled.Text = "Start timer";
            } else {
                timer1.Enabled = true;
                timerEnabled.Text = "Stop timer";
            }
        }

        private void timer1_Tick(object sender, EventArgs e) {
            //richTextBox1.Text = ccd.GuiderXError.ToString("F5");

            aggresivenessX = (float)aggXUpDown.Value;
            aggresivenessY = (float)aggYUpDown.Value;

            motorX = (float)device[1].Position;
            motorY = (float)device[0].Position;

            guiderX = ccd.GuiderXError;
            guiderY = ccd.GuiderYError;

            //device[0].GetMoveAbsolutePosition().ToString("F4");

            motorXlbl.Text = motorX.ToString("F5");
            motorYlbl.Text = motorY.ToString("F5");

            guiderXlbl.Text = guiderX.ToString("F5");
            guiderYlbl.Text = guiderY.ToString("F5");

            if (i > 0) {

                if (Math.Abs(guiderX) > 0.05 && enableLbl.Checked) {

                    stepSize = Math.Abs(guiderX * 0.020 * aggresivenessX);

                    move = stepSize;

                    if (move > 0.05) { move = 0.05; }

                    if (guiderX < 0) {
                        device[1].MoveRelative(MotorDirection.Forward, (decimal)stepSize, 5000);
                        richTextBox1.AppendText("X " + guiderX.ToString("F3") + " " + stepSize.ToString("F4") + " " + move.ToString("F4") + " Forward" + Environment.NewLine);
                    } else {
                        device[1].MoveRelative(MotorDirection.Backward, (decimal)stepSize, 5000);
                        richTextBox1.AppendText("X " + guiderX.ToString("F3") + " " + stepSize.ToString("F4") + " " + move.ToString("F4") + " Backward" + Environment.NewLine);
                    }

                    richTextBox1.ScrollToCaret();

                }

                if (Math.Abs(guiderY) > 0.05 && enableLbl.Checked) {
                    stepSize = Math.Abs(guiderY * 0.020 * aggresivenessY);

                    move = stepSize;

                    if (move > 0.05) { move = 0.05; }

                    if (guiderY > 0) {
                        device[0].MoveRelative(MotorDirection.Forward, (decimal)stepSize, 5000);
                        richTextBox1.AppendText("Y " + guiderY.ToString("F3") + " " + stepSize.ToString("F4") + " " + move.ToString("F4") + " Forward" + Environment.NewLine);
                    } else {
                        device[0].MoveRelative(MotorDirection.Backward, (decimal)stepSize, 5000);
                        richTextBox1.AppendText("Y " + guiderY.ToString("F3") + " " + stepSize.ToString("F4") + " " + move.ToString("F4") + " Backward" + Environment.NewLine);
                    }

                    richTextBox1.ScrollToCaret();

                }

                i = 0;
            }
            i++;


        }

        private void button1_Click(object sender, EventArgs e) {
            stepSize = 0.05;
            device[1].MoveRelative(MotorDirection.Forward, (decimal)stepSize, 2000);
        }

        private void button2_Click(object sender, EventArgs e) {
            stepSize = 0.05;
            device[1].MoveRelative(MotorDirection.Backward, (decimal)stepSize, 2000);
        }

        private void button4_Click(object sender, EventArgs e) {
            stepSize = 0.05;
            device[0].MoveRelative(MotorDirection.Forward, (decimal)stepSize, 2000);
        }

        private void button3_Click(object sender, EventArgs e) {
            stepSize = 0.05;
            device[0].MoveRelative(MotorDirection.Backward, (decimal)stepSize, 2000);
        }
    }
    
}
