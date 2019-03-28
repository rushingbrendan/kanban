namespace workstationSimulator
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
            this.label20 = new System.Windows.Forms.Label();
            this.logOutput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.workstationInput = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.employeeSkillInput = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.timescaleLabel = new System.Windows.Forms.Label();
            this.assemblyTimeLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.startTimeLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.currentTimeLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.workstationInput)).BeginInit();
            this.SuspendLayout();
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(7, 239);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(39, 20);
            this.label20.TabIndex = 38;
            this.label20.Text = "Log";
            // 
            // logOutput
            // 
            this.logOutput.Location = new System.Drawing.Point(5, 267);
            this.logOutput.MaximumSize = new System.Drawing.Size(735, 178);
            this.logOutput.MinimumSize = new System.Drawing.Size(735, 178);
            this.logOutput.Multiline = true;
            this.logOutput.Name = "logOutput";
            this.logOutput.ReadOnly = true;
            this.logOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.logOutput.Size = new System.Drawing.Size(735, 178);
            this.logOutput.TabIndex = 37;
            this.logOutput.WordWrap = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 20);
            this.label2.TabIndex = 40;
            this.label2.Text = "Workstation";
            // 
            // workstationInput
            // 
            this.workstationInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.workstationInput.Location = new System.Drawing.Point(131, 8);
            this.workstationInput.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.workstationInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.workstationInput.Name = "workstationInput";
            this.workstationInput.Size = new System.Drawing.Size(74, 26);
            this.workstationInput.TabIndex = 39;
            this.workstationInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 20);
            this.label1.TabIndex = 41;
            this.label1.Text = "Employee Skill";
            // 
            // employeeSkillInput
            // 
            this.employeeSkillInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employeeSkillInput.FormattingEnabled = true;
            this.employeeSkillInput.Items.AddRange(new object[] {
            "Rookie",
            "Normal",
            "Experienced"});
            this.employeeSkillInput.Location = new System.Drawing.Point(127, 45);
            this.employeeSkillInput.Name = "employeeSkillInput";
            this.employeeSkillInput.Size = new System.Drawing.Size(121, 28);
            this.employeeSkillInput.TabIndex = 42;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(364, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 20);
            this.label3.TabIndex = 43;
            this.label3.Text = "Time scale:";
            // 
            // timescaleLabel
            // 
            this.timescaleLabel.AutoSize = true;
            this.timescaleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timescaleLabel.Location = new System.Drawing.Point(466, 16);
            this.timescaleLabel.Name = "timescaleLabel";
            this.timescaleLabel.Size = new System.Drawing.Size(0, 20);
            this.timescaleLabel.TabIndex = 44;
            // 
            // assemblyTimeLabel
            // 
            this.assemblyTimeLabel.AutoSize = true;
            this.assemblyTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.assemblyTimeLabel.Location = new System.Drawing.Point(466, 47);
            this.assemblyTimeLabel.Name = "assemblyTimeLabel";
            this.assemblyTimeLabel.Size = new System.Drawing.Size(0, 20);
            this.assemblyTimeLabel.TabIndex = 46;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(342, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 20);
            this.label5.TabIndex = 45;
            this.label5.Text = "Assembly Time:";
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.Chartreuse;
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.Location = new System.Drawing.Point(30, 94);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(119, 52);
            this.startButton.TabIndex = 47;
            this.startButton.Text = "Start Simulator";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.BackColor = System.Drawing.Color.Red;
            this.stopButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.stopButton.Location = new System.Drawing.Point(173, 94);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(119, 52);
            this.stopButton.TabIndex = 48;
            this.stopButton.Text = "Stop Simulator";
            this.stopButton.UseVisualStyleBackColor = false;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // startTimeLabel
            // 
            this.startTimeLabel.AutoSize = true;
            this.startTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startTimeLabel.Location = new System.Drawing.Point(466, 81);
            this.startTimeLabel.Name = "startTimeLabel";
            this.startTimeLabel.Size = new System.Drawing.Size(0, 20);
            this.startTimeLabel.TabIndex = 50;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(353, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 20);
            this.label6.TabIndex = 49;
            this.label6.Text = "Start Time:";
            // 
            // currentTimeLabel
            // 
            this.currentTimeLabel.AutoSize = true;
            this.currentTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentTimeLabel.Location = new System.Drawing.Point(466, 115);
            this.currentTimeLabel.Name = "currentTimeLabel";
            this.currentTimeLabel.Size = new System.Drawing.Size(0, 20);
            this.currentTimeLabel.TabIndex = 52;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(342, 113);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 20);
            this.label8.TabIndex = 51;
            this.label8.Text = "Current Time:";
            // 
            // progressBar
            // 
            this.progressBar.ForeColor = System.Drawing.Color.Lime;
            this.progressBar.Location = new System.Drawing.Point(16, 197);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(715, 28);
            this.progressBar.TabIndex = 53;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(20, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(277, 20);
            this.label4.TabIndex = 54;
            this.label4.Text = "Current Fog Lamp Assembly Progress";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.currentTimeLabel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.startTimeLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.assemblyTimeLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.timescaleLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.employeeSkillInput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.workstationInput);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.logOutput);
            this.Name = "Form1";
            this.Text = "Workstation Simulator";
            ((System.ComponentModel.ISupportInitialize)(this.workstationInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox logOutput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown workstationInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox employeeSkillInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label timescaleLabel;
        private System.Windows.Forms.Label assemblyTimeLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Label startTimeLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label currentTimeLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label label4;
    }
}

