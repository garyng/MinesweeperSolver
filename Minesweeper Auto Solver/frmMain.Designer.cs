namespace Minesweeper_Auto_Solver
{
    partial class frmMain
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
            this.picBtnCon = new System.Windows.Forms.PictureBox();
            this.lblWH = new System.Windows.Forms.Label();
            this.btnGet = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picBtnCon)).BeginInit();
            this.SuspendLayout();
            // 
            // picBtnCon
            // 
            this.picBtnCon.Location = new System.Drawing.Point(12, 98);
            this.picBtnCon.Name = "picBtnCon";
            this.picBtnCon.Size = new System.Drawing.Size(161, 133);
            this.picBtnCon.TabIndex = 7;
            this.picBtnCon.TabStop = false;
            // 
            // lblWH
            // 
            this.lblWH.AutoSize = true;
            this.lblWH.Location = new System.Drawing.Point(12, 63);
            this.lblWH.Name = "lblWH";
            this.lblWH.Size = new System.Drawing.Size(77, 13);
            this.lblWH.TabIndex = 6;
            this.lblWH.Text = "Width Height";
            // 
            // btnGet
            // 
            this.btnGet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGet.Location = new System.Drawing.Point(12, 10);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(268, 50);
            this.btnGet.TabIndex = 5;
            this.btnGet.Text = "Solve";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.picBtnCon);
            this.Controls.Add(this.lblWH);
            this.Controls.Add(this.btnGet);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmMain";
            this.Text = "Minesweeper Auto Solver (For XP)";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBtnCon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBtnCon;
        private System.Windows.Forms.Label lblWH;
        private System.Windows.Forms.Button btnGet;
    }
}

