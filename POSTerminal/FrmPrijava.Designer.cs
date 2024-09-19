namespace POSTerminal
{
    partial class FrmPrijava
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrijava));
            this.txtScan = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btSimuScan = new System.Windows.Forms.Button();
            this.btPrijava = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtScan
            // 
            this.txtScan.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScan.Location = new System.Drawing.Point(95, 180);
            this.txtScan.Name = "txtScan";
            this.txtScan.Size = new System.Drawing.Size(590, 31);
            this.txtScan.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Coral;
            this.label1.Location = new System.Drawing.Point(221, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(367, 55);
            this.label1.TabIndex = 1;
            this.label1.Text = "POSTerm v1.0.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(308, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 37);
            this.label2.TabIndex = 2;
            this.label2.Text = "PRIJAVA";
            // 
            // btSimuScan
            // 
            this.btSimuScan.BackgroundImage = global::POSTerminal.Properties.Resources.barcode;
            this.btSimuScan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btSimuScan.Location = new System.Drawing.Point(692, 180);
            this.btSimuScan.Name = "btSimuScan";
            this.btSimuScan.Size = new System.Drawing.Size(42, 31);
            this.btSimuScan.TabIndex = 5;
            this.btSimuScan.UseVisualStyleBackColor = true;
            this.btSimuScan.Click += new System.EventHandler(this.btSimuScan_Click);
            // 
            // btPrijava
            // 
            this.btPrijava.BackgroundImage = global::POSTerminal.Properties.Resources._486;
            this.btPrijava.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btPrijava.Location = new System.Drawing.Point(297, 233);
            this.btPrijava.Name = "btPrijava";
            this.btPrijava.Size = new System.Drawing.Size(207, 164);
            this.btPrijava.TabIndex = 4;
            this.btPrijava.UseVisualStyleBackColor = true;
            this.btPrijava.Click += new System.EventHandler(this.btPrijava_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::POSTerminal.Properties.Resources.Logo;
            this.pictureBox1.Location = new System.Drawing.Point(594, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(140, 143);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // FrmPrijava
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btSimuScan);
            this.Controls.Add(this.btPrijava);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtScan);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmPrijava";
            this.Text = "POSTerm v1.0. - Prijava";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btPrijava;
        private System.Windows.Forms.Button btSimuScan;
        public System.Windows.Forms.TextBox txtScan;
    }
}