namespace PATIO.Interfaces
{
    partial class ctrlReporting
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
            this.FLP = new System.Windows.Forms.FlowLayoutPanel();
            this.btnEditionPlan = new System.Windows.Forms.Button();
            this.btnEditionTerritoire = new System.Windows.Forms.Button();
            this.btnEditionStat = new System.Windows.Forms.Button();
            this.btnEditionDirection = new System.Windows.Forms.Button();
            this.FLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // FLP
            // 
            this.FLP.Controls.Add(this.btnEditionPlan);
            this.FLP.Controls.Add(this.btnEditionDirection);
            this.FLP.Controls.Add(this.btnEditionTerritoire);
            this.FLP.Controls.Add(this.btnEditionStat);
            this.FLP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FLP.Location = new System.Drawing.Point(3, 3);
            this.FLP.Name = "FLP";
            this.FLP.Padding = new System.Windows.Forms.Padding(5);
            this.FLP.Size = new System.Drawing.Size(738, 403);
            this.FLP.TabIndex = 2;
            // 
            // btnEditionPlan
            // 
            this.btnEditionPlan.AutoSize = true;
            this.btnEditionPlan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditionPlan.Image = global::PATIO.Properties.Resources.menu_parametre;
            this.btnEditionPlan.Location = new System.Drawing.Point(8, 8);
            this.btnEditionPlan.Name = "btnEditionPlan";
            this.btnEditionPlan.Size = new System.Drawing.Size(192, 151);
            this.btnEditionPlan.TabIndex = 3;
            this.btnEditionPlan.Text = "Edition par plan";
            this.btnEditionPlan.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditionPlan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEditionPlan.UseVisualStyleBackColor = true;
            this.btnEditionPlan.Click += new System.EventHandler(this.btnEditionPlan_Click);
            // 
            // btnEditionTerritoire
            // 
            this.btnEditionTerritoire.AutoSize = true;
            this.btnEditionTerritoire.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditionTerritoire.Image = global::PATIO.Properties.Resources.Globe;
            this.btnEditionTerritoire.Location = new System.Drawing.Point(404, 8);
            this.btnEditionTerritoire.Name = "btnEditionTerritoire";
            this.btnEditionTerritoire.Size = new System.Drawing.Size(192, 151);
            this.btnEditionTerritoire.TabIndex = 1;
            this.btnEditionTerritoire.Text = "Edition par territoire";
            this.btnEditionTerritoire.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditionTerritoire.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEditionTerritoire.UseVisualStyleBackColor = true;
            this.btnEditionTerritoire.Click += new System.EventHandler(this.btnEditionTerritoire_Click);
            // 
            // btnEditionStat
            // 
            this.btnEditionStat.AutoSize = true;
            this.btnEditionStat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditionStat.Image = global::PATIO.Properties.Resources.Performance;
            this.btnEditionStat.Location = new System.Drawing.Point(8, 165);
            this.btnEditionStat.Name = "btnEditionStat";
            this.btnEditionStat.Size = new System.Drawing.Size(192, 151);
            this.btnEditionStat.TabIndex = 0;
            this.btnEditionStat.Text = "Statistiques";
            this.btnEditionStat.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditionStat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEditionStat.UseVisualStyleBackColor = true;
            this.btnEditionStat.Click += new System.EventHandler(this.btnEditionStat_Click);
            // 
            // btnEditionDirection
            // 
            this.btnEditionDirection.AutoSize = true;
            this.btnEditionDirection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditionDirection.Image = global::PATIO.Properties.Resources.direction;
            this.btnEditionDirection.Location = new System.Drawing.Point(206, 8);
            this.btnEditionDirection.Name = "btnEditionDirection";
            this.btnEditionDirection.Size = new System.Drawing.Size(192, 151);
            this.btnEditionDirection.TabIndex = 2;
            this.btnEditionDirection.Text = "Edition par direction";
            this.btnEditionDirection.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditionDirection.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEditionDirection.UseVisualStyleBackColor = true;
            this.btnEditionDirection.Click += new System.EventHandler(this.btnEditionDirection_Click);
            // 
            // ctrlReporting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.FLP);
            this.Name = "ctrlReporting";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(744, 409);
            this.FLP.ResumeLayout(false);
            this.FLP.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel FLP;
        private System.Windows.Forms.Button btnEditionStat;
        private System.Windows.Forms.Button btnEditionTerritoire;
        private System.Windows.Forms.Button btnEditionDirection;
        private System.Windows.Forms.Button btnEditionPlan;
    }
}
