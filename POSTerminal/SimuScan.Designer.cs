namespace POSTerminal
{
    partial class SimuScan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimuScan));
            this.panel1 = new System.Windows.Forms.Panel();
            this.FIELD_SEARCH = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btAccept = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.btResetFilter = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btResetFilter);
            this.panel1.Controls.Add(this.FIELD_SEARCH);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(308, 34);
            this.panel1.TabIndex = 0;
            // 
            // FIELD_SEARCH
            // 
            this.FIELD_SEARCH.Location = new System.Drawing.Point(3, 8);
            this.FIELD_SEARCH.Name = "FIELD_SEARCH";
            this.FIELD_SEARCH.Size = new System.Drawing.Size(265, 20);
            this.FIELD_SEARCH.TabIndex = 0;
            this.FIELD_SEARCH.TextChanged += new System.EventHandler(this.FIELD_SEARCH_TextChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.listBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 34);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(308, 502);
            this.panel2.TabIndex = 1;
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(308, 502);
            this.listBox1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btCancel);
            this.panel3.Controls.Add(this.btAccept);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 485);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(308, 51);
            this.panel3.TabIndex = 2;
            // 
            // btAccept
            // 
            this.btAccept.Location = new System.Drawing.Point(134, 6);
            this.btAccept.Name = "btAccept";
            this.btAccept.Size = new System.Drawing.Size(78, 33);
            this.btAccept.TabIndex = 0;
            this.btAccept.Text = "Accept";
            this.btAccept.UseVisualStyleBackColor = true;
            this.btAccept.Click += new System.EventHandler(this.btAccept_Click);
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(218, 6);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(78, 33);
            this.btCancel.TabIndex = 1;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btResetFilter
            // 
            this.btResetFilter.BackgroundImage = global::POSTerminal.Properties.Resources.filter_remove;
            this.btResetFilter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btResetFilter.Dock = System.Windows.Forms.DockStyle.Right;
            this.btResetFilter.Location = new System.Drawing.Point(271, 0);
            this.btResetFilter.Name = "btResetFilter";
            this.btResetFilter.Size = new System.Drawing.Size(37, 34);
            this.btResetFilter.TabIndex = 1;
            this.btResetFilter.UseVisualStyleBackColor = true;
            this.btResetFilter.Click += new System.EventHandler(this.btResetFilter_Click);
            // 
            // SimuScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 536);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SimuScan";
            this.Text = "SimuScan";
            this.Load += new System.EventHandler(this.SimuScan_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox FIELD_SEARCH;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btAccept;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btResetFilter;
    }
}