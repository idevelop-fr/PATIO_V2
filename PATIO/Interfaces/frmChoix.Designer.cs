namespace PATIO.Interfaces
{
    partial class frmChoix
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
            this.lst = new System.Windows.Forms.ListBox();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.btnValider = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lst
            // 
            this.lst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lst.FormattingEnabled = true;
            this.lst.Location = new System.Drawing.Point(0, 25);
            this.lst.Name = "lst";
            this.lst.Size = new System.Drawing.Size(400, 266);
            this.lst.TabIndex = 0;
            // 
            // toolStrip3
            // 
            this.toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator6,
            this.toolStripSeparator10,
            this.btnValider,
            this.toolStripSeparator14});
            this.toolStrip3.Location = new System.Drawing.Point(0, 0);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(400, 25);
            this.toolStrip3.TabIndex = 14;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 25);
            // 
            // btnValider
            // 
            this.btnValider.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnValider.BackColor = System.Drawing.Color.Yellow;
            this.btnValider.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnValider.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnValider.Name = "btnValider";
            this.btnValider.Size = new System.Drawing.Size(90, 22);
            this.btnValider.Text = "Valider le choix";
            this.btnValider.Click += new System.EventHandler(this.btnValider_Click);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(6, 25);
            // 
            // frmChoix
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 291);
            this.Controls.Add(this.lst);
            this.Controls.Add(this.toolStrip3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChoix";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Choix d\'un item";
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripButton btnValider;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
        public System.Windows.Forms.ListBox lst;
    }
}