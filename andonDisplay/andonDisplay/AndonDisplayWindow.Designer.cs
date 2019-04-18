namespace andonDisplay
{
    partial class AndonDisplayWindow
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
            this.cbWorkstation = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbHarnesCount = new System.Windows.Forms.Label();
            this.lbReflectCount = new System.Windows.Forms.Label();
            this.lbHousCount = new System.Windows.Forms.Label();
            this.lbLensCount = new System.Windows.Forms.Label();
            this.lbBulbCount = new System.Windows.Forms.Label();
            this.lbBezCount = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.workerLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbWorkstation
            // 
            this.cbWorkstation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWorkstation.FormattingEnabled = true;
            this.cbWorkstation.Location = new System.Drawing.Point(35, 52);
            this.cbWorkstation.Name = "cbWorkstation";
            this.cbWorkstation.Size = new System.Drawing.Size(272, 21);
            this.cbWorkstation.TabIndex = 0;
            this.cbWorkstation.TextChanged += new System.EventHandler(this.UpdateSelectedWorkstation);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Harnesses:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Reflectors:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(32, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Housings:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(32, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Lenses:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(32, 222);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "Bulbs:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(32, 253);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 17);
            this.label6.TabIndex = 6;
            this.label6.Text = "Bezels:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(31, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 22);
            this.label7.TabIndex = 7;
            this.label7.Text = "Workstation:";
            // 
            // lbHarnesCount
            // 
            this.lbHarnesCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHarnesCount.Location = new System.Drawing.Point(227, 101);
            this.lbHarnesCount.Name = "lbHarnesCount";
            this.lbHarnesCount.Size = new System.Drawing.Size(80, 17);
            this.lbHarnesCount.TabIndex = 8;
            this.lbHarnesCount.Text = "0";
            this.lbHarnesCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbReflectCount
            // 
            this.lbReflectCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbReflectCount.Location = new System.Drawing.Point(230, 130);
            this.lbReflectCount.Name = "lbReflectCount";
            this.lbReflectCount.Size = new System.Drawing.Size(77, 17);
            this.lbReflectCount.TabIndex = 9;
            this.lbReflectCount.Text = "0";
            this.lbReflectCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbHousCount
            // 
            this.lbHousCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHousCount.Location = new System.Drawing.Point(230, 162);
            this.lbHousCount.Name = "lbHousCount";
            this.lbHousCount.Size = new System.Drawing.Size(77, 17);
            this.lbHousCount.TabIndex = 10;
            this.lbHousCount.Text = "0";
            this.lbHousCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbLensCount
            // 
            this.lbLensCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLensCount.Location = new System.Drawing.Point(230, 192);
            this.lbLensCount.Name = "lbLensCount";
            this.lbLensCount.Size = new System.Drawing.Size(77, 17);
            this.lbLensCount.TabIndex = 11;
            this.lbLensCount.Text = "0";
            this.lbLensCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbBulbCount
            // 
            this.lbBulbCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBulbCount.Location = new System.Drawing.Point(233, 222);
            this.lbBulbCount.Name = "lbBulbCount";
            this.lbBulbCount.Size = new System.Drawing.Size(74, 17);
            this.lbBulbCount.TabIndex = 12;
            this.lbBulbCount.Text = "0";
            this.lbBulbCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbBezCount
            // 
            this.lbBezCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBezCount.Location = new System.Drawing.Point(236, 253);
            this.lbBezCount.Name = "lbBezCount";
            this.lbBezCount.Size = new System.Drawing.Size(71, 17);
            this.lbBezCount.TabIndex = 13;
            this.lbBezCount.Text = "0";
            this.lbBezCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(36, 319);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(124, 17);
            this.label8.TabIndex = 14;
            this.label8.Text = "Is worker needed?";
            // 
            // workerLabel
            // 
            this.workerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.workerLabel.Location = new System.Drawing.Point(239, 319);
            this.workerLabel.Name = "workerLabel";
            this.workerLabel.Size = new System.Drawing.Size(68, 17);
            this.workerLabel.TabIndex = 15;
            this.workerLabel.Text = "NO";
            this.workerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // AndonDisplayWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 384);
            this.Controls.Add(this.workerLabel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lbBezCount);
            this.Controls.Add(this.lbBulbCount);
            this.Controls.Add(this.lbLensCount);
            this.Controls.Add(this.lbHousCount);
            this.Controls.Add(this.lbReflectCount);
            this.Controls.Add(this.lbHarnesCount);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbWorkstation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AndonDisplayWindow";
            this.Text = "WorkStation Andon Display";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbWorkstation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbHarnesCount;
        private System.Windows.Forms.Label lbReflectCount;
        private System.Windows.Forms.Label lbHousCount;
        private System.Windows.Forms.Label lbLensCount;
        private System.Windows.Forms.Label lbBulbCount;
        private System.Windows.Forms.Label lbBezCount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label workerLabel;
    }
}

