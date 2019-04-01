namespace OrderCreator
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
            this.orderQuantityInput = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.placeOrderButton = new System.Windows.Forms.Button();
            this.logOutput = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.orderQuantityInput)).BeginInit();
            this.SuspendLayout();
            // 
            // orderQuantityInput
            // 
            this.orderQuantityInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orderQuantityInput.Location = new System.Drawing.Point(50, 86);
            this.orderQuantityInput.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.orderQuantityInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.orderQuantityInput.Name = "orderQuantityInput";
            this.orderQuantityInput.Size = new System.Drawing.Size(120, 29);
            this.orderQuantityInput.TabIndex = 0;
            this.orderQuantityInput.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(45, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Order Quantity";
            // 
            // placeOrderButton
            // 
            this.placeOrderButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.placeOrderButton.Location = new System.Drawing.Point(198, 82);
            this.placeOrderButton.Name = "placeOrderButton";
            this.placeOrderButton.Size = new System.Drawing.Size(143, 37);
            this.placeOrderButton.TabIndex = 2;
            this.placeOrderButton.Text = "Place Order";
            this.placeOrderButton.UseVisualStyleBackColor = true;
            this.placeOrderButton.Click += new System.EventHandler(this.placeOrderButton_Click);
            // 
            // logOutput
            // 
            this.logOutput.Location = new System.Drawing.Point(2, 270);
            this.logOutput.MaximumSize = new System.Drawing.Size(735, 178);
            this.logOutput.MinimumSize = new System.Drawing.Size(735, 178);
            this.logOutput.Multiline = true;
            this.logOutput.Name = "logOutput";
            this.logOutput.ReadOnly = true;
            this.logOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.logOutput.Size = new System.Drawing.Size(735, 178);
            this.logOutput.TabIndex = 38;
            this.logOutput.WordWrap = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(10, 241);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(39, 20);
            this.label20.TabIndex = 39;
            this.label20.Text = "Log";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 450);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.logOutput);
            this.Controls.Add(this.placeOrderButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.orderQuantityInput);
            this.MaximumSize = new System.Drawing.Size(756, 489);
            this.MinimumSize = new System.Drawing.Size(756, 489);
            this.Name = "Form1";
            this.Text = "Order Creator Application For Kanban";
            ((System.ComponentModel.ISupportInitialize)(this.orderQuantityInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown orderQuantityInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button placeOrderButton;
        private System.Windows.Forms.TextBox logOutput;
        private System.Windows.Forms.Label label20;
    }
}

