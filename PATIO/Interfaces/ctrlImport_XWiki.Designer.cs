namespace CAPA.Interfaces
{
    partial class ctrlImport_XWiki
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
            this.lst = new System.Windows.Forms.ListBox();
            this.btnExtraire = new System.Windows.Forms.Button();
            this.optPlan = new System.Windows.Forms.CheckBox();
            this.optAction = new System.Windows.Forms.CheckBox();
            this.optObjectif = new System.Windows.Forms.CheckBox();
            this.optOperation = new System.Windows.Forms.CheckBox();
            this.optIndicateur = new System.Windows.Forms.CheckBox();
            this.optSave = new System.Windows.Forms.CheckBox();
            this.btnCorriger = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.optActionCorrection = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lst
            // 
            this.lst.Dock = System.Windows.Forms.DockStyle.Left;
            this.lst.FormattingEnabled = true;
            this.lst.Location = new System.Drawing.Point(0, 0);
            this.lst.Name = "lst";
            this.lst.Size = new System.Drawing.Size(458, 555);
            this.lst.TabIndex = 0;
            // 
            // btnExtraire
            // 
            this.btnExtraire.Location = new System.Drawing.Point(477, 145);
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
            this.optPlan.Location = new System.Drawing.Point(477, 17);
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
            this.optAction.Location = new System.Drawing.Point(583, 17);
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
            this.optObjectif.Location = new System.Drawing.Point(477, 40);
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
            this.optOperation.Location = new System.Drawing.Point(583, 40);
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
            this.optIndicateur.Location = new System.Drawing.Point(583, 82);
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
            this.optSave.Location = new System.Drawing.Point(634, 160);
            this.optSave.Name = "optSave";
            this.optSave.Size = new System.Drawing.Size(192, 17);
            this.optSave.TabIndex = 7;
            this.optSave.Text = "Extraction à partir des sauvegardes";
            this.optSave.UseVisualStyleBackColor = true;
            // 
            // btnCorriger
            // 
            this.btnCorriger.Location = new System.Drawing.Point(168, 25);
            this.btnCorriger.Name = "btnCorriger";
            this.btnCorriger.Size = new System.Drawing.Size(79, 26);
            this.btnCorriger.TabIndex = 8;
            this.btnCorriger.Text = "Corriger";
            this.btnCorriger.UseVisualStyleBackColor = true;
            this.btnCorriger.Click += new System.EventHandler(this.btnCorriger_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.optActionCorrection);
            this.groupBox1.Controls.Add(this.btnCorriger);
            this.groupBox1.Location = new System.Drawing.Point(495, 234);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(253, 141);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Corrections";
            // 
            // optActionCorrection
            // 
            this.optActionCorrection.AutoSize = true;
            this.optActionCorrection.Checked = true;
            this.optActionCorrection.CheckState = System.Windows.Forms.CheckState.Checked;
            this.optActionCorrection.Location = new System.Drawing.Point(26, 31);
            this.optActionCorrection.Name = "optActionCorrection";
            this.optActionCorrection.Size = new System.Drawing.Size(56, 17);
            this.optActionCorrection.TabIndex = 10;
            this.optActionCorrection.Text = "Action";
            this.optActionCorrection.UseVisualStyleBackColor = true;
            // 
            // ctrlImport_XWiki
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.optSave);
            this.Controls.Add(this.optIndicateur);
            this.Controls.Add(this.optOperation);
            this.Controls.Add(this.optObjectif);
            this.Controls.Add(this.optAction);
            this.Controls.Add(this.optPlan);
            this.Controls.Add(this.btnExtraire);
            this.Controls.Add(this.lst);
            this.Name = "ctrlImport_XWiki";
            this.Size = new System.Drawing.Size(830, 555);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lst;
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
    }
}
