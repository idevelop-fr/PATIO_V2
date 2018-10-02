namespace PATIO.Interfaces
{
    partial class ctrlPlanCorrection
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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.choixCOPILOTE = new PATIO.Interfaces.ctrlChoixListe();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.lstAttribut = new System.Windows.Forms.ToolStripComboBox();
            this.lstPilote = new System.Windows.Forms.ListBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(362, 467);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lstPilote);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(354, 441);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "PILOTE";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.choixCOPILOTE);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(354, 441);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "ROLE_6PO_COPILOTE";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // choixCOPILOTE
            // 
            this.choixCOPILOTE.Dock = System.Windows.Forms.DockStyle.Top;
            this.choixCOPILOTE.Location = new System.Drawing.Point(3, 3);
            this.choixCOPILOTE.Name = "choixCOPILOTE";
            this.choixCOPILOTE.Size = new System.Drawing.Size(348, 150);
            this.choixCOPILOTE.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.lstAttribut});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(362, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(107, 22);
            this.toolStripLabel1.Text = "Choix de l\'attribut :";
            // 
            // lstAttribut
            // 
            this.lstAttribut.Name = "lstAttribut";
            this.lstAttribut.Size = new System.Drawing.Size(200, 25);
            this.lstAttribut.SelectedIndexChanged += new System.EventHandler(this.lstAttribut_SelectedIndexChanged);
            // 
            // lstPilote
            // 
            this.lstPilote.Dock = System.Windows.Forms.DockStyle.Top;
            this.lstPilote.FormattingEnabled = true;
            this.lstPilote.Location = new System.Drawing.Point(3, 3);
            this.lstPilote.Name = "lstPilote";
            this.lstPilote.Size = new System.Drawing.Size(348, 108);
            this.lstPilote.TabIndex = 0;
            // 
            // ctrlPlanCorrection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ctrlPlanCorrection";
            this.Size = new System.Drawing.Size(362, 492);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox lstAttribut;
        private ctrlChoixListe choixCOPILOTE;
        private System.Windows.Forms.ListBox lstPilote;
    }
}
