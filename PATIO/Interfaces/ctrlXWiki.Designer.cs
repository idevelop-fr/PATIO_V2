namespace PATIO.Interfaces
{
    partial class ctrlXWiki
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
            this.btnExtraire = new System.Windows.Forms.Button();
            this.optPlan = new System.Windows.Forms.CheckBox();
            this.optAction = new System.Windows.Forms.CheckBox();
            this.optObjectif = new System.Windows.Forms.CheckBox();
            this.optOperation = new System.Windows.Forms.CheckBox();
            this.optIndicateur = new System.Windows.Forms.CheckBox();
            this.optSave = new System.Windows.Forms.CheckBox();
            this.btnCorriger = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.optObjectifCorrection = new System.Windows.Forms.CheckBox();
            this.optPlanCorrection = new System.Windows.Forms.CheckBox();
            this.optActionCorrection = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnExporter = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.optIndicExport = new System.Windows.Forms.CheckBox();
            this.optPlanExport = new System.Windows.Forms.CheckBox();
            this.optActionExport = new System.Windows.Forms.CheckBox();
            this.optObjectifExport = new System.Windows.Forms.CheckBox();
            this.optOperExport = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl = new System.Windows.Forms.Label();
            this.lst = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExtraire
            // 
            this.btnExtraire.Location = new System.Drawing.Point(6, 137);
            this.btnExtraire.Name = "btnExtraire";
            this.btnExtraire.Size = new System.Drawing.Size(138, 44);
            this.btnExtraire.TabIndex = 1;
            this.btnExtraire.Text = "Extraire";
            this.btnExtraire.UseVisualStyleBackColor = true;
            this.btnExtraire.Click += new System.EventHandler(this.btnExtraire_Click);
            // 
            // optPlan
            // 
            this.optPlan.AutoSize = true;
            this.optPlan.Checked = true;
            this.optPlan.CheckState = System.Windows.Forms.CheckState.Checked;
            this.optPlan.Location = new System.Drawing.Point(17, 23);
            this.optPlan.Name = "optPlan";
            this.optPlan.Size = new System.Drawing.Size(47, 17);
            this.optPlan.TabIndex = 2;
            this.optPlan.Text = "Plan";
            this.optPlan.UseVisualStyleBackColor = true;
            // 
            // optAction
            // 
            this.optAction.AutoSize = true;
            this.optAction.Checked = true;
            this.optAction.CheckState = System.Windows.Forms.CheckState.Checked;
            this.optAction.Location = new System.Drawing.Point(123, 23);
            this.optAction.Name = "optAction";
            this.optAction.Size = new System.Drawing.Size(56, 17);
            this.optAction.TabIndex = 3;
            this.optAction.Text = "Action";
            this.optAction.UseVisualStyleBackColor = true;
            // 
            // optObjectif
            // 
            this.optObjectif.AutoSize = true;
            this.optObjectif.Checked = true;
            this.optObjectif.CheckState = System.Windows.Forms.CheckState.Checked;
            this.optObjectif.Location = new System.Drawing.Point(17, 46);
            this.optObjectif.Name = "optObjectif";
            this.optObjectif.Size = new System.Drawing.Size(62, 17);
            this.optObjectif.TabIndex = 4;
            this.optObjectif.Text = "Objectif";
            this.optObjectif.UseVisualStyleBackColor = true;
            // 
            // optOperation
            // 
            this.optOperation.AutoSize = true;
            this.optOperation.Checked = true;
            this.optOperation.CheckState = System.Windows.Forms.CheckState.Checked;
            this.optOperation.Location = new System.Drawing.Point(123, 46);
            this.optOperation.Name = "optOperation";
            this.optOperation.Size = new System.Drawing.Size(72, 17);
            this.optOperation.TabIndex = 5;
            this.optOperation.Text = "Opération";
            this.optOperation.UseVisualStyleBackColor = true;
            // 
            // optIndicateur
            // 
            this.optIndicateur.AutoSize = true;
            this.optIndicateur.Checked = true;
            this.optIndicateur.CheckState = System.Windows.Forms.CheckState.Checked;
            this.optIndicateur.Location = new System.Drawing.Point(123, 88);
            this.optIndicateur.Name = "optIndicateur";
            this.optIndicateur.Size = new System.Drawing.Size(73, 17);
            this.optIndicateur.TabIndex = 6;
            this.optIndicateur.Text = "Indicateur";
            this.optIndicateur.UseVisualStyleBackColor = true;
            // 
            // optSave
            // 
            this.optSave.AutoSize = true;
            this.optSave.Checked = true;
            this.optSave.CheckState = System.Windows.Forms.CheckState.Checked;
            this.optSave.Location = new System.Drawing.Point(153, 137);
            this.optSave.Name = "optSave";
            this.optSave.Size = new System.Drawing.Size(192, 17);
            this.optSave.TabIndex = 7;
            this.optSave.Text = "Extraction à partir des sauvegardes";
            this.optSave.UseVisualStyleBackColor = true;
            // 
            // btnCorriger
            // 
            this.btnCorriger.Location = new System.Drawing.Point(6, 367);
            this.btnCorriger.Name = "btnCorriger";
            this.btnCorriger.Size = new System.Drawing.Size(138, 47);
            this.btnCorriger.TabIndex = 8;
            this.btnCorriger.Text = "Corriger";
            this.btnCorriger.UseVisualStyleBackColor = true;
            this.btnCorriger.Click += new System.EventHandler(this.btnCorriger_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.optObjectifCorrection);
            this.groupBox1.Controls.Add(this.optPlanCorrection);
            this.groupBox1.Controls.Add(this.optActionCorrection);
            this.groupBox1.Location = new System.Drawing.Point(6, 220);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 141);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Corrections";
            // 
            // optObjectifCorrection
            // 
            this.optObjectifCorrection.AutoSize = true;
            this.optObjectifCorrection.Enabled = false;
            this.optObjectifCorrection.Location = new System.Drawing.Point(23, 57);
            this.optObjectifCorrection.Name = "optObjectifCorrection";
            this.optObjectifCorrection.Size = new System.Drawing.Size(62, 17);
            this.optObjectifCorrection.TabIndex = 12;
            this.optObjectifCorrection.Text = "Objectif";
            this.optObjectifCorrection.UseVisualStyleBackColor = true;
            // 
            // optPlanCorrection
            // 
            this.optPlanCorrection.AutoSize = true;
            this.optPlanCorrection.Location = new System.Drawing.Point(23, 34);
            this.optPlanCorrection.Name = "optPlanCorrection";
            this.optPlanCorrection.Size = new System.Drawing.Size(47, 17);
            this.optPlanCorrection.TabIndex = 11;
            this.optPlanCorrection.Text = "Plan";
            this.optPlanCorrection.UseVisualStyleBackColor = true;
            // 
            // optActionCorrection
            // 
            this.optActionCorrection.AutoSize = true;
            this.optActionCorrection.Location = new System.Drawing.Point(23, 80);
            this.optActionCorrection.Name = "optActionCorrection";
            this.optActionCorrection.Size = new System.Drawing.Size(56, 17);
            this.optActionCorrection.TabIndex = 10;
            this.optActionCorrection.Text = "Action";
            this.optActionCorrection.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(340, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(490, 555);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.btnCorriger);
            this.tabPage1.Controls.Add(this.optSave);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.btnExtraire);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(482, 529);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Importer";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.optIndicateur);
            this.groupBox2.Controls.Add(this.optPlan);
            this.groupBox2.Controls.Add(this.optAction);
            this.groupBox2.Controls.Add(this.optObjectif);
            this.groupBox2.Controls.Add(this.optOperation);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(272, 122);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Types d\'objets";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnExporter);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(482, 529);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Exporter";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnExporter
            // 
            this.btnExporter.Location = new System.Drawing.Point(6, 134);
            this.btnExporter.Name = "btnExporter";
            this.btnExporter.Size = new System.Drawing.Size(138, 44);
            this.btnExporter.TabIndex = 4;
            this.btnExporter.Text = "Exporter";
            this.btnExporter.UseVisualStyleBackColor = true;
            this.btnExporter.Click += new System.EventHandler(this.btnExporter_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.optIndicExport);
            this.groupBox3.Controls.Add(this.optPlanExport);
            this.groupBox3.Controls.Add(this.optActionExport);
            this.groupBox3.Controls.Add(this.optObjectifExport);
            this.groupBox3.Controls.Add(this.optOperExport);
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(272, 122);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Types d\'objets";
            // 
            // optIndicExport
            // 
            this.optIndicExport.AutoSize = true;
            this.optIndicExport.Location = new System.Drawing.Point(123, 88);
            this.optIndicExport.Name = "optIndicExport";
            this.optIndicExport.Size = new System.Drawing.Size(73, 17);
            this.optIndicExport.TabIndex = 6;
            this.optIndicExport.Text = "Indicateur";
            this.optIndicExport.UseVisualStyleBackColor = true;
            // 
            // optPlanExport
            // 
            this.optPlanExport.AutoSize = true;
            this.optPlanExport.Checked = true;
            this.optPlanExport.CheckState = System.Windows.Forms.CheckState.Checked;
            this.optPlanExport.Location = new System.Drawing.Point(17, 23);
            this.optPlanExport.Name = "optPlanExport";
            this.optPlanExport.Size = new System.Drawing.Size(47, 17);
            this.optPlanExport.TabIndex = 2;
            this.optPlanExport.Text = "Plan";
            this.optPlanExport.UseVisualStyleBackColor = true;
            // 
            // optActionExport
            // 
            this.optActionExport.AutoSize = true;
            this.optActionExport.Location = new System.Drawing.Point(123, 23);
            this.optActionExport.Name = "optActionExport";
            this.optActionExport.Size = new System.Drawing.Size(56, 17);
            this.optActionExport.TabIndex = 3;
            this.optActionExport.Text = "Action";
            this.optActionExport.UseVisualStyleBackColor = true;
            // 
            // optObjectifExport
            // 
            this.optObjectifExport.AutoSize = true;
            this.optObjectifExport.Location = new System.Drawing.Point(17, 46);
            this.optObjectifExport.Name = "optObjectifExport";
            this.optObjectifExport.Size = new System.Drawing.Size(62, 17);
            this.optObjectifExport.TabIndex = 4;
            this.optObjectifExport.Text = "Objectif";
            this.optObjectifExport.UseVisualStyleBackColor = true;
            // 
            // optOperExport
            // 
            this.optOperExport.AutoSize = true;
            this.optOperExport.Location = new System.Drawing.Point(123, 46);
            this.optOperExport.Name = "optOperExport";
            this.optOperExport.Size = new System.Drawing.Size(72, 17);
            this.optOperExport.TabIndex = 5;
            this.optOperExport.Text = "Opération";
            this.optOperExport.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl);
            this.panel1.Controls.Add(this.lst);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(340, 555);
            this.panel1.TabIndex = 12;
            // 
            // lbl
            // 
            this.lbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl.Location = new System.Drawing.Point(0, 316);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(340, 239);
            this.lbl.TabIndex = 13;
            // 
            // lst
            // 
            this.lst.Dock = System.Windows.Forms.DockStyle.Top;
            this.lst.FormattingEnabled = true;
            this.lst.Location = new System.Drawing.Point(0, 0);
            this.lst.Name = "lst";
            this.lst.Size = new System.Drawing.Size(340, 316);
            this.lst.TabIndex = 12;
            // 
            // ctrlXWiki
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "ctrlXWiki";
            this.Size = new System.Drawing.Size(830, 555);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnExtraire;
        private System.Windows.Forms.CheckBox optPlan;
        private System.Windows.Forms.CheckBox optAction;
        private System.Windows.Forms.CheckBox optObjectif;
        private System.Windows.Forms.CheckBox optOperation;
        private System.Windows.Forms.CheckBox optIndicateur;
        private System.Windows.Forms.CheckBox optSave;
        private System.Windows.Forms.Button btnCorriger;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox optActionCorrection;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnExporter;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox optIndicExport;
        private System.Windows.Forms.CheckBox optPlanExport;
        private System.Windows.Forms.CheckBox optActionExport;
        private System.Windows.Forms.CheckBox optObjectifExport;
        private System.Windows.Forms.CheckBox optOperExport;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.ListBox lst;
        private System.Windows.Forms.CheckBox optObjectifCorrection;
        private System.Windows.Forms.CheckBox optPlanCorrection;
    }
}
