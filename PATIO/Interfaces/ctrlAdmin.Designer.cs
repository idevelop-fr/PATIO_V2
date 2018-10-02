namespace PATIO.Interfaces
{
    partial class ctrlAdmin
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabUser = new System.Windows.Forms.TabPage();
            this.tabImport = new System.Windows.Forms.TabPage();
            this.tabExport = new System.Windows.Forms.TabPage();
            this.tabXWiki = new System.Windows.Forms.TabPage();
            this.tabParametre = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblFichierLog = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnActualiserFichierLog = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tabCorrectif = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabUser);
            this.tabControl1.Controls.Add(this.tabImport);
            this.tabControl1.Controls.Add(this.tabExport);
            this.tabControl1.Controls.Add(this.tabXWiki);
            this.tabControl1.Controls.Add(this.tabParametre);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabCorrectif);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(63, 30);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(781, 478);
            this.tabControl1.TabIndex = 0;
            // 
            // tabUser
            // 
            this.tabUser.Location = new System.Drawing.Point(4, 34);
            this.tabUser.Name = "tabUser";
            this.tabUser.Padding = new System.Windows.Forms.Padding(3);
            this.tabUser.Size = new System.Drawing.Size(773, 440);
            this.tabUser.TabIndex = 0;
            this.tabUser.Text = "Utilisateurs";
            this.tabUser.UseVisualStyleBackColor = true;
            // 
            // tabImport
            // 
            this.tabImport.Location = new System.Drawing.Point(4, 34);
            this.tabImport.Name = "tabImport";
            this.tabImport.Padding = new System.Windows.Forms.Padding(3);
            this.tabImport.Size = new System.Drawing.Size(773, 440);
            this.tabImport.TabIndex = 1;
            this.tabImport.Text = "Importation";
            this.tabImport.UseVisualStyleBackColor = true;
            // 
            // tabExport
            // 
            this.tabExport.Location = new System.Drawing.Point(4, 34);
            this.tabExport.Name = "tabExport";
            this.tabExport.Size = new System.Drawing.Size(773, 440);
            this.tabExport.TabIndex = 2;
            this.tabExport.Text = "Exportation";
            this.tabExport.UseVisualStyleBackColor = true;
            // 
            // tabXWiki
            // 
            this.tabXWiki.Location = new System.Drawing.Point(4, 34);
            this.tabXWiki.Name = "tabXWiki";
            this.tabXWiki.Size = new System.Drawing.Size(773, 440);
            this.tabXWiki.TabIndex = 3;
            this.tabXWiki.Text = "Import XWiki";
            this.tabXWiki.UseVisualStyleBackColor = true;
            // 
            // tabParametre
            // 
            this.tabParametre.Location = new System.Drawing.Point(4, 34);
            this.tabParametre.Name = "tabParametre";
            this.tabParametre.Size = new System.Drawing.Size(773, 440);
            this.tabParametre.TabIndex = 4;
            this.tabParametre.Text = "Paramétrage";
            this.tabParametre.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblFichierLog);
            this.tabPage1.Controls.Add(this.toolStrip1);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(773, 440);
            this.tabPage1.TabIndex = 5;
            this.tabPage1.Text = "Fichier Log";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblFichierLog
            // 
            this.lblFichierLog.AcceptsReturn = true;
            this.lblFichierLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFichierLog.Location = new System.Drawing.Point(0, 25);
            this.lblFichierLog.Multiline = true;
            this.lblFichierLog.Name = "lblFichierLog";
            this.lblFichierLog.ReadOnly = true;
            this.lblFichierLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.lblFichierLog.Size = new System.Drawing.Size(773, 415);
            this.lblFichierLog.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.btnActualiserFichierLog,
            this.toolStripSeparator2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(773, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnActualiserFichierLog
            // 
            this.btnActualiserFichierLog.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnActualiserFichierLog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnActualiserFichierLog.Image = global::PATIO.Properties.Resources.btn_maj;
            this.btnActualiserFichierLog.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnActualiserFichierLog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnActualiserFichierLog.Name = "btnActualiserFichierLog";
            this.btnActualiserFichierLog.Size = new System.Drawing.Size(23, 22);
            this.btnActualiserFichierLog.Text = "Actualiser";
            this.btnActualiserFichierLog.Click += new System.EventHandler(this.btnActualiserFichierLog_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tabCorrectif
            // 
            this.tabCorrectif.Location = new System.Drawing.Point(4, 34);
            this.tabCorrectif.Name = "tabCorrectif";
            this.tabCorrectif.Size = new System.Drawing.Size(773, 440);
            this.tabCorrectif.TabIndex = 6;
            this.tabCorrectif.Text = "Correctifs";
            this.tabCorrectif.UseVisualStyleBackColor = true;
            // 
            // ctrlAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "ctrlAdmin";
            this.Size = new System.Drawing.Size(781, 478);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabUser;
        private System.Windows.Forms.TabPage tabImport;
        private System.Windows.Forms.TabPage tabExport;
        private System.Windows.Forms.TabPage tabXWiki;
        private System.Windows.Forms.TabPage tabParametre;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnActualiserFichierLog;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.TextBox lblFichierLog;
        private System.Windows.Forms.TabPage tabCorrectif;
    }
}
