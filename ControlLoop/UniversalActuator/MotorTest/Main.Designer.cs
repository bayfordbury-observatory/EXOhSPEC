namespace SpecControl {
    partial class Main {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.motorXlbl = new System.Windows.Forms.Label();
            this.motorYlbl = new System.Windows.Forms.Label();
            this.guiderYlbl = new System.Windows.Forms.Label();
            this.guiderXlbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.enableLbl = new System.Windows.Forms.CheckBox();
            this.timerEnabled = new System.Windows.Forms.Button();
            this.reverseX = new System.Windows.Forms.CheckBox();
            this.reverseY = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.correctionUpDown = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.stepUpDown = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.KpyUD = new System.Windows.Forms.NumericUpDown();
            this.KixUD = new System.Windows.Forms.NumericUpDown();
            this.KiyUD = new System.Windows.Forms.NumericUpDown();
            this.KdxUD = new System.Windows.Forms.NumericUpDown();
            this.KdyUD = new System.Windows.Forms.NumericUpDown();
            this.KpxUD = new System.Windows.Forms.NumericUpDown();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.imaxyUD = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.imaxxUD = new System.Windows.Forms.NumericUpDown();
            this.kpxLbl = new System.Windows.Forms.Label();
            this.kpyLbl = new System.Windows.Forms.Label();
            this.kiyLbl = new System.Windows.Forms.Label();
            this.kixLbl = new System.Windows.Forms.Label();
            this.kdyLbl = new System.Windows.Forms.Label();
            this.kdxLbl = new System.Windows.Forms.Label();
            this.loopTimeLbl = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.minMoveXUD = new System.Windows.Forms.NumericUpDown();
            this.minMoveYUD = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.correctionUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stepUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KpyUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KixUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KiyUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KdxUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KdyUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KpxUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imaxyUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imaxxUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minMoveXUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minMoveYUD)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(21, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(388, 214);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(138, 301);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "X+";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // motorXlbl
            // 
            this.motorXlbl.AutoSize = true;
            this.motorXlbl.Location = new System.Drawing.Point(426, 38);
            this.motorXlbl.Name = "motorXlbl";
            this.motorXlbl.Size = new System.Drawing.Size(20, 13);
            this.motorXlbl.TabIndex = 2;
            this.motorXlbl.Text = "X: ";
            // 
            // motorYlbl
            // 
            this.motorYlbl.AutoSize = true;
            this.motorYlbl.Location = new System.Drawing.Point(426, 64);
            this.motorYlbl.Name = "motorYlbl";
            this.motorYlbl.Size = new System.Drawing.Size(17, 13);
            this.motorYlbl.TabIndex = 3;
            this.motorYlbl.Text = "Y:";
            // 
            // guiderYlbl
            // 
            this.guiderYlbl.AutoSize = true;
            this.guiderYlbl.Location = new System.Drawing.Point(426, 158);
            this.guiderYlbl.Name = "guiderYlbl";
            this.guiderYlbl.Size = new System.Drawing.Size(17, 13);
            this.guiderYlbl.TabIndex = 5;
            this.guiderYlbl.Text = "Y:";
            // 
            // guiderXlbl
            // 
            this.guiderXlbl.AutoSize = true;
            this.guiderXlbl.Location = new System.Drawing.Point(426, 132);
            this.guiderXlbl.Name = "guiderXlbl";
            this.guiderXlbl.Size = new System.Drawing.Size(20, 13);
            this.guiderXlbl.TabIndex = 4;
            this.guiderXlbl.Text = "X: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(423, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Guider Errors";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(423, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Motor position";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(35, 301);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(40, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "X-";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(87, 334);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(40, 23);
            this.button3.TabIndex = 12;
            this.button3.Text = "Y-";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(87, 270);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(40, 23);
            this.button4.TabIndex = 11;
            this.button4.Text = "Y+";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(87, 241);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "Jog";
            // 
            // enableLbl
            // 
            this.enableLbl.AutoSize = true;
            this.enableLbl.Location = new System.Drawing.Point(21, 401);
            this.enableLbl.Name = "enableLbl";
            this.enableLbl.Size = new System.Drawing.Size(113, 17);
            this.enableLbl.TabIndex = 17;
            this.enableLbl.Text = "enable corrections";
            this.enableLbl.UseVisualStyleBackColor = true;
            this.enableLbl.Click += new System.EventHandler(this.enableLbl_Click);
            // 
            // timerEnabled
            // 
            this.timerEnabled.Location = new System.Drawing.Point(21, 461);
            this.timerEnabled.Name = "timerEnabled";
            this.timerEnabled.Size = new System.Drawing.Size(85, 23);
            this.timerEnabled.TabIndex = 18;
            this.timerEnabled.Text = "Stop timer";
            this.timerEnabled.UseVisualStyleBackColor = true;
            this.timerEnabled.Click += new System.EventHandler(this.timerEnabled_Click);
            // 
            // reverseX
            // 
            this.reverseX.AutoSize = true;
            this.reverseX.Checked = true;
            this.reverseX.CheckState = System.Windows.Forms.CheckState.Checked;
            this.reverseX.Location = new System.Drawing.Point(287, 412);
            this.reverseX.Name = "reverseX";
            this.reverseX.Size = new System.Drawing.Size(61, 17);
            this.reverseX.TabIndex = 19;
            this.reverseX.Text = "reverse";
            this.reverseX.UseVisualStyleBackColor = true;
            // 
            // reverseY
            // 
            this.reverseY.AutoSize = true;
            this.reverseY.Checked = true;
            this.reverseY.CheckState = System.Windows.Forms.CheckState.Checked;
            this.reverseY.Location = new System.Drawing.Point(354, 412);
            this.reverseY.Name = "reverseY";
            this.reverseY.Size = new System.Drawing.Size(61, 17);
            this.reverseY.TabIndex = 20;
            this.reverseY.Text = "reverse";
            this.reverseY.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 433);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Minimum correction interval:";
            // 
            // correctionUpDown
            // 
            this.correctionUpDown.DecimalPlaces = 2;
            this.correctionUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.correctionUpDown.Location = new System.Drawing.Point(159, 431);
            this.correctionUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.correctionUpDown.Name = "correctionUpDown";
            this.correctionUpDown.Size = new System.Drawing.Size(51, 20);
            this.correctionUpDown.TabIndex = 21;
            this.correctionUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(216, 433);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "secs";
            // 
            // stepUpDown
            // 
            this.stepUpDown.Location = new System.Drawing.Point(81, 304);
            this.stepUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.stepUpDown.Name = "stepUpDown";
            this.stepUpDown.Size = new System.Drawing.Size(51, 20);
            this.stepUpDown.TabIndex = 24;
            this.stepUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(259, 237);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 16);
            this.label7.TabIndex = 26;
            this.label7.Text = "PID tuning";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(304, 260);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 13);
            this.label8.TabIndex = 27;
            this.label8.Text = "X";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(371, 260);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 13);
            this.label9.TabIndex = 28;
            this.label9.Text = "Y";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(259, 280);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(20, 13);
            this.label10.TabIndex = 29;
            this.label10.Text = "Kp";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(259, 307);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(16, 13);
            this.label11.TabIndex = 30;
            this.label11.Text = "Ki";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(259, 335);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(20, 13);
            this.label12.TabIndex = 31;
            this.label12.Text = "Kd";
            // 
            // KpyUD
            // 
            this.KpyUD.DecimalPlaces = 2;
            this.KpyUD.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.KpyUD.Location = new System.Drawing.Point(353, 276);
            this.KpyUD.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.KpyUD.Name = "KpyUD";
            this.KpyUD.Size = new System.Drawing.Size(51, 20);
            this.KpyUD.TabIndex = 32;
            this.KpyUD.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // KixUD
            // 
            this.KixUD.DecimalPlaces = 2;
            this.KixUD.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.KixUD.Location = new System.Drawing.Point(286, 303);
            this.KixUD.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.KixUD.Name = "KixUD";
            this.KixUD.Size = new System.Drawing.Size(51, 20);
            this.KixUD.TabIndex = 33;
            this.KixUD.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // KiyUD
            // 
            this.KiyUD.DecimalPlaces = 2;
            this.KiyUD.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.KiyUD.Location = new System.Drawing.Point(354, 303);
            this.KiyUD.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.KiyUD.Name = "KiyUD";
            this.KiyUD.Size = new System.Drawing.Size(51, 20);
            this.KiyUD.TabIndex = 34;
            this.KiyUD.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // KdxUD
            // 
            this.KdxUD.DecimalPlaces = 2;
            this.KdxUD.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.KdxUD.Location = new System.Drawing.Point(286, 331);
            this.KdxUD.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.KdxUD.Name = "KdxUD";
            this.KdxUD.Size = new System.Drawing.Size(51, 20);
            this.KdxUD.TabIndex = 35;
            this.KdxUD.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // KdyUD
            // 
            this.KdyUD.DecimalPlaces = 2;
            this.KdyUD.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.KdyUD.Location = new System.Drawing.Point(353, 331);
            this.KdyUD.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.KdyUD.Name = "KdyUD";
            this.KdyUD.Size = new System.Drawing.Size(51, 20);
            this.KdyUD.TabIndex = 36;
            this.KdyUD.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // KpxUD
            // 
            this.KpxUD.DecimalPlaces = 2;
            this.KpxUD.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.KpxUD.Location = new System.Drawing.Point(285, 276);
            this.KpxUD.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.KpxUD.Name = "KpxUD";
            this.KpxUD.Size = new System.Drawing.Size(51, 20);
            this.KpxUD.TabIndex = 37;
            this.KpxUD.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 495);
            this.splitter1.TabIndex = 38;
            this.splitter1.TabStop = false;
            // 
            // imaxyUD
            // 
            this.imaxyUD.Location = new System.Drawing.Point(353, 359);
            this.imaxyUD.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.imaxyUD.Name = "imaxyUD";
            this.imaxyUD.Size = new System.Drawing.Size(51, 20);
            this.imaxyUD.TabIndex = 41;
            this.imaxyUD.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(250, 361);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 39;
            this.label4.Text = "iMax";
            // 
            // imaxxUD
            // 
            this.imaxxUD.Location = new System.Drawing.Point(285, 359);
            this.imaxxUD.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.imaxxUD.Name = "imaxxUD";
            this.imaxxUD.Size = new System.Drawing.Size(51, 20);
            this.imaxxUD.TabIndex = 42;
            this.imaxxUD.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // kpxLbl
            // 
            this.kpxLbl.AutoSize = true;
            this.kpxLbl.Location = new System.Drawing.Point(423, 278);
            this.kpxLbl.Name = "kpxLbl";
            this.kpxLbl.Size = new System.Drawing.Size(30, 13);
            this.kpxLbl.TabIndex = 43;
            this.kpxLbl.Text = "Kp X";
            // 
            // kpyLbl
            // 
            this.kpyLbl.AutoSize = true;
            this.kpyLbl.Location = new System.Drawing.Point(470, 278);
            this.kpyLbl.Name = "kpyLbl";
            this.kpyLbl.Size = new System.Drawing.Size(30, 13);
            this.kpyLbl.TabIndex = 44;
            this.kpyLbl.Text = "Kp Y";
            // 
            // kiyLbl
            // 
            this.kiyLbl.AutoSize = true;
            this.kiyLbl.Location = new System.Drawing.Point(470, 306);
            this.kiyLbl.Name = "kiyLbl";
            this.kiyLbl.Size = new System.Drawing.Size(26, 13);
            this.kiyLbl.TabIndex = 46;
            this.kiyLbl.Text = "Ki Y";
            // 
            // kixLbl
            // 
            this.kixLbl.AutoSize = true;
            this.kixLbl.Location = new System.Drawing.Point(423, 306);
            this.kixLbl.Name = "kixLbl";
            this.kixLbl.Size = new System.Drawing.Size(26, 13);
            this.kixLbl.TabIndex = 45;
            this.kixLbl.Text = "Ki X";
            // 
            // kdyLbl
            // 
            this.kdyLbl.AutoSize = true;
            this.kdyLbl.Location = new System.Drawing.Point(470, 335);
            this.kdyLbl.Name = "kdyLbl";
            this.kdyLbl.Size = new System.Drawing.Size(30, 13);
            this.kdyLbl.TabIndex = 48;
            this.kdyLbl.Text = "Kd Y";
            // 
            // kdxLbl
            // 
            this.kdxLbl.AutoSize = true;
            this.kdxLbl.Location = new System.Drawing.Point(423, 335);
            this.kdxLbl.Name = "kdxLbl";
            this.kdxLbl.Size = new System.Drawing.Size(30, 13);
            this.kdxLbl.TabIndex = 47;
            this.kdxLbl.Text = "Kd X";
            // 
            // loopTimeLbl
            // 
            this.loopTimeLbl.AutoSize = true;
            this.loopTimeLbl.Location = new System.Drawing.Point(426, 361);
            this.loopTimeLbl.Name = "loopTimeLbl";
            this.loopTimeLbl.Size = new System.Drawing.Size(56, 13);
            this.loopTimeLbl.TabIndex = 49;
            this.loopTimeLbl.Text = "Loop time:";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(426, 383);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(85, 23);
            this.button5.TabIndex = 50;
            this.button5.Text = "Reset integral";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // minMoveXUD
            // 
            this.minMoveXUD.Location = new System.Drawing.Point(285, 386);
            this.minMoveXUD.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.minMoveXUD.Name = "minMoveXUD";
            this.minMoveXUD.Size = new System.Drawing.Size(51, 20);
            this.minMoveXUD.TabIndex = 53;
            this.minMoveXUD.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // minMoveYUD
            // 
            this.minMoveYUD.Location = new System.Drawing.Point(353, 386);
            this.minMoveYUD.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.minMoveYUD.Name = "minMoveYUD";
            this.minMoveYUD.Size = new System.Drawing.Size(51, 20);
            this.minMoveYUD.TabIndex = 52;
            this.minMoveYUD.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(229, 388);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(50, 13);
            this.label13.TabIndex = 51;
            this.label13.Text = "minMove";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 495);
            this.Controls.Add(this.minMoveXUD);
            this.Controls.Add(this.minMoveYUD);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.loopTimeLbl);
            this.Controls.Add(this.kdyLbl);
            this.Controls.Add(this.kdxLbl);
            this.Controls.Add(this.kiyLbl);
            this.Controls.Add(this.kixLbl);
            this.Controls.Add(this.kpyLbl);
            this.Controls.Add(this.kpxLbl);
            this.Controls.Add(this.imaxxUD);
            this.Controls.Add(this.imaxyUD);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.KpxUD);
            this.Controls.Add(this.KdyUD);
            this.Controls.Add(this.KdxUD);
            this.Controls.Add(this.KiyUD);
            this.Controls.Add(this.KixUD);
            this.Controls.Add(this.KpyUD);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.stepUpDown);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.correctionUpDown);
            this.Controls.Add(this.reverseY);
            this.Controls.Add(this.reverseX);
            this.Controls.Add(this.timerEnabled);
            this.Controls.Add(this.enableLbl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.guiderYlbl);
            this.Controls.Add(this.guiderXlbl);
            this.Controls.Add(this.motorYlbl);
            this.Controls.Add(this.motorXlbl);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Main";
            this.Text = "SpecControl";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.correctionUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stepUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KpyUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KixUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KiyUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KdxUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KdyUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KpxUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imaxyUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imaxxUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minMoveXUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minMoveYUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

       

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label motorXlbl;
        private System.Windows.Forms.Label motorYlbl;
        private System.Windows.Forms.Label guiderYlbl;
        private System.Windows.Forms.Label guiderXlbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox enableLbl;
        private System.Windows.Forms.Button timerEnabled;
        private System.Windows.Forms.CheckBox reverseX;
        private System.Windows.Forms.CheckBox reverseY;
        private System.Windows.Forms.NumericUpDown correctionUpDown;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown stepUpDown;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown KpyUD;
        private System.Windows.Forms.NumericUpDown KixUD;
        private System.Windows.Forms.NumericUpDown KiyUD;
        private System.Windows.Forms.NumericUpDown KdxUD;
        private System.Windows.Forms.NumericUpDown KdyUD;
        private System.Windows.Forms.NumericUpDown KpxUD;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.NumericUpDown imaxyUD;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown imaxxUD;
        private System.Windows.Forms.Label kpxLbl;
        private System.Windows.Forms.Label kpyLbl;
        private System.Windows.Forms.Label kiyLbl;
        private System.Windows.Forms.Label kixLbl;
        private System.Windows.Forms.Label kdyLbl;
        private System.Windows.Forms.Label kdxLbl;
        private System.Windows.Forms.Label loopTimeLbl;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.NumericUpDown minMoveXUD;
        private System.Windows.Forms.NumericUpDown minMoveYUD;
        private System.Windows.Forms.Label label13;
    }
}

