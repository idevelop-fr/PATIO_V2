namespace PATIO.Interfaces
{
    partial class ctrlExport
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lst = new System.Windows.Forms.ListBox();
            this.BtnExporter = new System.Windows.Forms.Button();
            this.btnExporterWeb = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lst);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(339, 413);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Liste des événements";
            // 
            // lst
            // 
            this.lst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lst.FormattingEnabled = true;
            this.lst.Location = new System.Drawing.Point(3, 16);
            this.lst.Name = "lst";
            this.lst.Size = new System.Drawing.Size(333, 394);
            this.lst.TabIndex = 0;
            // 
            // BtnExporter
            // 
            this.BtnExporter.Location = new System.Drawing.Point(354, 16);
            this.BtnExporter.Name = "BtnExporter";
            this.BtnExporter.Size = new System.Drawing.Size(155, 60);
            this.BtnExporter.TabIndex = 1;
            this.BtnExporter.Text = "Exporter vers des fichiers";
            this.BtnExporter.UseVisualStyleBackColor = true;
            this.BtnExporter.Click += new System.EventHandler(this.BtnExporter_Click);
            // 
            // btnExporterWeb
            // 
            this.btnExporterWeb.Location = new System.Drawing.Point(354, 108);
            this.btnExporterWeb.Name = "btnExporterWeb";
            this.btnExporterWeb.Size = new System.Drawing.Size(155, 60);
            this.btnExporterWeb.TabIndex = 2;
            this.btnExporterWeb.Text = "Exporter vers le web";
            this.btnExporterWeb.UseVisualStyleBackColor = true;
            this.btnExporterWeb.Click += new System.EventHandler(this.btnExporterWeb_Click);
            // 
            // ctrlExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnExporterWeb);
            this.Controls.Add(this.BtnExporter);
            this.Controls.Add(this.groupBox1);
            this.Name = "ctrlExport";
            this.Size = new System.Drawing.Size(642, 413);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lst;
        private System.Windows.Forms.Button BtnExporter;
        private System.Windows.Forms.Button btnExporterWeb;
    }
}
