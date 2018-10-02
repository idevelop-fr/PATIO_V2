namespace Interfaces
{
    partial class GestionPlan
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
            this.tabPlan = new System.Windows.Forms.TabPage();
            this.tabObjectif = new System.Windows.Forms.TabPage();
            this.tabAction = new System.Windows.Forms.TabPage();
            this.tabIndicateur = new System.Windows.Forms.TabPage();
            this.tabUser = new System.Windows.Forms.TabPage();
            this.tabGroupe = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl1.Controls.Add(this.tabPlan);
            this.tabControl1.Controls.Add(this.tabObjectif);
            this.tabControl1.Controls.Add(this.tabAction);
            this.tabControl1.Controls.Add(this.tabIndicateur);
            this.tabControl1.Controls.Add(this.tabUser);
            this.tabControl1.Controls.Add(this.tabGroupe);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(53, 30);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(459, 424);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPlan
            // 
            this.tabPlan.Location = new System.Drawing.Point(4, 34);
            this.tabPlan.Name = "tabPlan";
            this.tabPlan.Padding = new System.Windows.Forms.Padding(3);
            this.tabPlan.Size = new System.Drawing.Size(451, 386);
            this.tabPlan.TabIndex = 3;
            this.tabPlan.Text = "Plans";
            this.tabPlan.UseVisualStyleBackColor = true;
            // 
            // tabObjectif
            // 
            this.tabObjectif.Location = new System.Drawing.Point(4, 34);
            this.tabObjectif.Name = "tabObjectif";
            this.tabObjectif.Padding = new System.Windows.Forms.Padding(3);
            this.tabObjectif.Size = new System.Drawing.Size(451, 386);
            this.tabObjectif.TabIndex = 0;
            this.tabObjectif.Text = "Objectifs";
            this.tabObjectif.UseVisualStyleBackColor = true;
            // 
            // tabAction
            // 
            this.tabAction.Location = new System.Drawing.Point(4, 34);
            this.tabAction.Name = "tabAction";
            this.tabAction.Padding = new System.Windows.Forms.Padding(3);
            this.tabAction.Size = new System.Drawing.Size(451, 386);
            this.tabAction.TabIndex = 1;
            this.tabAction.Text = "Actions";
            this.tabAction.UseVisualStyleBackColor = true;
            // 
            // tabIndicateur
            // 
            this.tabIndicateur.Location = new System.Drawing.Point(4, 34);
            this.tabIndicateur.Name = "tabIndicateur";
            this.tabIndicateur.Padding = new System.Windows.Forms.Padding(3);
            this.tabIndicateur.Size = new System.Drawing.Size(451, 386);
            this.tabIndicateur.TabIndex = 2;
            this.tabIndicateur.Text = "Indicateurs";
            this.tabIndicateur.UseVisualStyleBackColor = true;
            // 
            // tabUser
            // 
            this.tabUser.Location = new System.Drawing.Point(4, 34);
            this.tabUser.Name = "tabUser";
            this.tabUser.Padding = new System.Windows.Forms.Padding(3);
            this.tabUser.Size = new System.Drawing.Size(451, 386);
            this.tabUser.TabIndex = 4;
            this.tabUser.Text = "Utilisateurs";
            this.tabUser.UseVisualStyleBackColor = true;
            // 
            // tabGroupe
            // 
            this.tabGroupe.Location = new System.Drawing.Point(4, 34);
            this.tabGroupe.Name = "tabGroupe";
            this.tabGroupe.Padding = new System.Windows.Forms.Padding(3);
            this.tabGroupe.Size = new System.Drawing.Size(451, 386);
            this.tabGroupe.TabIndex = 5;
            this.tabGroupe.Text = "Groupes";
            this.tabGroupe.UseVisualStyleBackColor = true;
            // 
            // GestionPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "GestionPlan";
            this.Size = new System.Drawing.Size(459, 424);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabObjectif;
        private System.Windows.Forms.TabPage tabAction;
        private System.Windows.Forms.TabPage tabIndicateur;
        public System.Windows.Forms.TabPage tabPlan;
        private System.Windows.Forms.TabPage tabUser;
        private System.Windows.Forms.TabPage tabGroupe;
    }
}
