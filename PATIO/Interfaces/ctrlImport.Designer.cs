namespace PATIO.Interfaces
{
    partial class ctrlImport
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
            this.BtnImporter = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lstFichier = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblRepertoire = new System.Windows.Forms.Label();
            this.BtnChoisir = new System.Windows.Forms.Button();
            this.lst = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnImporter
            // 
            this.BtnImporter.Location = new System.Drawing.Point(350, 3);
            this.BtnImporter.Name = "BtnImporter";
            this.BtnImporter.Size = new System.Drawing.Size(155, 60);
            this.BtnImporter.TabIndex = 3;
            this.BtnImporter.Text = "Importer";
            this.BtnImporter.UseVisualStyleBackColor = true;
            this.BtnImporter.Click += new System.EventHandler(this.BtnImporter_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(344, 406);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lstFichier);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 126);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(338, 277);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            // 
            // lstFichier
            // 
            this.lstFichier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstFichier.FormattingEnabled = true;
            this.lstFichier.Location = new System.Drawing.Point(3, 16);
            this.lstFichier.Name = "lstFichier";
            this.lstFichier.Size = new System.Drawing.Size(332, 258);
            this.lstFichier.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblRepertoire);
            this.groupBox1.Controls.Add(this.BtnChoisir);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(338, 110);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Choix du répertoire contenant les fichiers à importer";
            // 
            // lblRepertoire
            // 
            this.lblRepertoire.Location = new System.Drawing.Point(6, 24);
            this.lblRepertoire.Name = "lblRepertoire";
            this.lblRepertoire.Size = new System.Drawing.Size(245, 74);
            this.lblRepertoire.TabIndex = 1;
            // 
            // BtnChoisir
            // 
            this.BtnChoisir.Location = new System.Drawing.Point(257, 19);
            this.BtnChoisir.Name = "BtnChoisir";
            this.BtnChoisir.Size = new System.Drawing.Size(75, 23);
            this.BtnChoisir.TabIndex = 0;
            this.BtnChoisir.Text = "Choisir";
            this.BtnChoisir.UseVisualStyleBackColor = true;
            this.BtnChoisir.Click += new System.EventHandler(this.BtnChoisir_Click);
            // 
            // lst
            // 
            this.lst.FormattingEnabled = true;
            this.lst.Location = new System.Drawing.Point(533, 3);
            this.lst.Name = "lst";
            this.lst.Size = new System.Drawing.Size(338, 212);
            this.lst.TabIndex = 4;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listView1);
            this.groupBox3.Location = new System.Drawing.Point(350, 221);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(572, 182);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Contenu du fichier";
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Location = new System.Drawing.Point(3, 16);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(566, 163);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // ctrlImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lst);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.BtnImporter);
            this.Name = "ctrlImport";
            this.Size = new System.Drawing.Size(925, 406);
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnImporter;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblRepertoire;
        private System.Windows.Forms.Button BtnChoisir;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ListBox lst;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckedListBox lstFichier;
    }
}
