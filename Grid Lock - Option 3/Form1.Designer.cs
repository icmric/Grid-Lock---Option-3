namespace Grid_Lock___Option_3
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
            this.BtnRightArrow = new System.Windows.Forms.Button();
            this.LblBoo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnRightArrow
            // 
            this.BtnRightArrow.Location = new System.Drawing.Point(314, 255);
            this.BtnRightArrow.Name = "BtnRightArrow";
            this.BtnRightArrow.Size = new System.Drawing.Size(268, 183);
            this.BtnRightArrow.TabIndex = 0;
            this.BtnRightArrow.Text = ">";
            this.BtnRightArrow.UseVisualStyleBackColor = true;
            this.BtnRightArrow.Click += new System.EventHandler(this.button1_Click);
            // 
            // LblBoo
            // 
            this.LblBoo.AutoSize = true;
            this.LblBoo.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblBoo.Location = new System.Drawing.Point(302, 147);
            this.LblBoo.Name = "LblBoo";
            this.LblBoo.Size = new System.Drawing.Size(147, 73);
            this.LblBoo.TabIndex = 1;
            this.LblBoo.Text = "Boo";
            this.LblBoo.Click += new System.EventHandler(this.LblBoo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LblBoo);
            this.Controls.Add(this.BtnRightArrow);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnRightArrow;
        private System.Windows.Forms.Label LblBoo;
    }
}

