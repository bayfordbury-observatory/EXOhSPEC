namespace MotorTest
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
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
            this.aggXUpDown = new System.Windows.Forms.NumericUpDown();
            this.aggLbl = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.aggYUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.X = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.enableLbl = new System.Windows.Forms.CheckBox();
            this.timerEnabled = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.aggXUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aggYUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(21, 39);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(388, 96);
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
            this.button1.Location = new System.Drawing.Point(148, 172);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "X Forward";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // motorXlbl
            // 
            this.motorXlbl.AutoSize = true;
            this.motorXlbl.Location = new System.Drawing.Point(464, 45);
            this.motorXlbl.Name = "motorXlbl";
            this.motorXlbl.Size = new System.Drawing.Size(20, 13);
            this.motorXlbl.TabIndex = 2;
            this.motorXlbl.Text = "X: ";
            // 
            // motorYlbl
            // 
            this.motorYlbl.AutoSize = true;
            this.motorYlbl.Location = new System.Drawing.Point(464, 71);
            this.motorYlbl.Name = "motorYlbl";
            this.motorYlbl.Size = new System.Drawing.Size(17, 13);
            this.motorYlbl.TabIndex = 3;
            this.motorYlbl.Text = "Y:";
            // 
            // guiderYlbl
            // 
            this.guiderYlbl.AutoSize = true;
            this.guiderYlbl.Location = new System.Drawing.Point(464, 145);
            this.guiderYlbl.Name = "guiderYlbl";
            this.guiderYlbl.Size = new System.Drawing.Size(17, 13);
            this.guiderYlbl.TabIndex = 5;
            this.guiderYlbl.Text = "Y:";
            // 
            // guiderXlbl
            // 
            this.guiderXlbl.AutoSize = true;
            this.guiderXlbl.Location = new System.Drawing.Point(464, 119);
            this.guiderXlbl.Name = "guiderXlbl";
            this.guiderXlbl.Size = new System.Drawing.Size(20, 13);
            this.guiderXlbl.TabIndex = 4;
            this.guiderXlbl.Text = "X: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(461, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Guider Errors";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(461, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Motor position";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(57, 172);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "X Backwards";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // aggXUpDown
            // 
            this.aggXUpDown.DecimalPlaces = 1;
            this.aggXUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.aggXUpDown.Location = new System.Drawing.Point(303, 175);
            this.aggXUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.aggXUpDown.Name = "aggXUpDown";
            this.aggXUpDown.Size = new System.Drawing.Size(51, 20);
            this.aggXUpDown.TabIndex = 9;
            this.aggXUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // aggLbl
            // 
            this.aggLbl.AutoSize = true;
            this.aggLbl.Location = new System.Drawing.Point(284, 153);
            this.aggLbl.Name = "aggLbl";
            this.aggLbl.Size = new System.Drawing.Size(81, 13);
            this.aggLbl.TabIndex = 10;
            this.aggLbl.Text = "Aggressiveness";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(57, 201);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(85, 23);
            this.button3.TabIndex = 12;
            this.button3.Text = "Y Backwards";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(148, 201);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(85, 23);
            this.button4.TabIndex = 11;
            this.button4.Text = "Y Forward";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // aggYUpDown
            // 
            this.aggYUpDown.DecimalPlaces = 1;
            this.aggYUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.aggYUpDown.Location = new System.Drawing.Point(303, 201);
            this.aggYUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.aggYUpDown.Name = "aggYUpDown";
            this.aggYUpDown.Size = new System.Drawing.Size(51, 20);
            this.aggYUpDown.TabIndex = 13;
            this.aggYUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Jog";
            // 
            // X
            // 
            this.X.AutoSize = true;
            this.X.Location = new System.Drawing.Point(284, 177);
            this.X.Name = "X";
            this.X.Size = new System.Drawing.Size(14, 13);
            this.X.TabIndex = 15;
            this.X.Text = "X";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(284, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Y";
            // 
            // enableLbl
            // 
            this.enableLbl.AutoSize = true;
            this.enableLbl.Location = new System.Drawing.Point(448, 178);
            this.enableLbl.Name = "enableLbl";
            this.enableLbl.Size = new System.Drawing.Size(113, 17);
            this.enableLbl.TabIndex = 17;
            this.enableLbl.Text = "enable corrections";
            this.enableLbl.UseVisualStyleBackColor = true;
            // 
            // timerEnabled
            // 
            this.timerEnabled.Location = new System.Drawing.Point(448, 203);
            this.timerEnabled.Name = "timerEnabled";
            this.timerEnabled.Size = new System.Drawing.Size(85, 23);
            this.timerEnabled.TabIndex = 18;
            this.timerEnabled.Text = "Stop timer";
            this.timerEnabled.UseVisualStyleBackColor = true;
            this.timerEnabled.Click += new System.EventHandler(this.timerEnabled_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 262);
            this.Controls.Add(this.timerEnabled);
            this.Controls.Add(this.enableLbl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.X);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.aggYUpDown);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.aggLbl);
            this.Controls.Add(this.aggXUpDown);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.guiderYlbl);
            this.Controls.Add(this.guiderXlbl);
            this.Controls.Add(this.motorYlbl);
            this.Controls.Add(this.motorXlbl);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.aggXUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aggYUpDown)).EndInit();
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
        private System.Windows.Forms.NumericUpDown aggXUpDown;
        private System.Windows.Forms.Label aggLbl;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.NumericUpDown aggYUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label X;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox enableLbl;
        private System.Windows.Forms.Button timerEnabled;
    }
}

