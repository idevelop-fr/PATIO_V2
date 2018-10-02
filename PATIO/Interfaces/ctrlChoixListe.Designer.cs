namespace PATIO.Interfaces
{
    partial class ctrlChoixListe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlChoixListe));
            this.Barre = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAjouter = new System.Windows.Forms.ToolStripButton();
            this.btnRetirer = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnTout = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstChoix = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblRecherche = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstSelection = new System.Windows.Forms.ListBox();
            this.Barre.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Barre
            // 
            this.Barre.AutoSize = false;
            this.Barre.Dock = System.Windows.Forms.DockStyle.Left;
            this.Barre.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Barre.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.btnAjouter,
            this.btnRetirer,
            this.toolStripSeparator2,
            this.btnTout,
            this.toolStripSeparator3});
            this.Barre.Location = new System.Drawing.Point(259, 0);
            this.Barre.Name = "Barre";
            this.Barre.Size = new System.Drawing.Size(41, 150);
            this.Barre.TabIndex = 1;
            this.Barre.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(39, 6);
            // 
            // btnAjouter
            // 
            this.btnAjouter.AutoSize = false;
            this.btnAjouter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAjouter.Image = global::PATIO.Properties.Resources.vers_droite;
            this.btnAjouter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(29, 25);
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // btnRetirer
            // 
            this.btnRetirer.AutoSize = false;
            this.btnRetirer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRetirer.Image = global::PATIO.Properties.Resources.vers_gauche;
            this.btnRetirer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRetirer.Name = "btnRetirer";
            this.btnRetirer.Size = new System.Drawing.Size(29, 25);
            this.btnRetirer.Text = "Retirer";
            this.btnRetirer.Click += new System.EventHandler(this.btnRetirer_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(39, 6);
            // 
            // btnTout
            // 
            this.btnTout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnTout.Image = ((System.Drawing.Image)(resources.GetObject("btnTout.Image")));
            this.btnTout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTout.Name = "btnTout";
            this.btnTout.Size = new System.Drawing.Size(39, 19);
            this.btnTout.Text = "Tout";
            this.btnTout.Click += new System.EventHandler(this.btnTout_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(39, 6);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstChoix);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 150);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Choix";
            // 
            // lstChoix
            // 
            this.lstChoix.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstChoix.FormattingEnabled = true;
            this.lstChoix.Location = new System.Drawing.Point(3, 38);
            this.lstChoix.Name = "lstChoix";
            this.lstChoix.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstChoix.Size = new System.Drawing.Size(253, 109);
            this.lstChoix.TabIndex = 0;
            this.lstChoix.DoubleClick += new System.EventHandler(this.lstChoix_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblRecherche);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(253, 22);
            this.panel1.TabIndex = 1;
            // 
            // lblRecherche
            // 
            this.lblRecherche.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRecherche.Location = new System.Drawing.Point(86, 0);
            this.lblRecherche.Name = "lblRecherche";
            this.lblRecherche.Size = new System.Drawing.Size(167, 20);
            this.lblRecherche.TabIndex = 1;
            this.lblRecherche.TextChanged += new System.EventHandler(this.lblRecherche_TextChanged);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Recherche :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstSelection);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(300, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(259, 150);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sélection";
            // 
            // lstSelection
            // 
            this.lstSelection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstSelection.FormattingEnabled = true;
            this.lstSelection.Location = new System.Drawing.Point(3, 16);
            this.lstSelection.Name = "lstSelection";
            this.lstSelection.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstSelection.Size = new System.Drawing.Size(253, 131);
            this.lstSelection.TabIndex = 1;
            this.lstSelection.DoubleClick += new System.EventHandler(this.lstSelection_DoubleClick);
            // 
            // ctrlChoixListe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.Barre);
            this.Controls.Add(this.groupBox1);
            this.Name = "ctrlChoixListe";
            this.Size = new System.Drawing.Size(587, 150);
            this.Resize += new System.EventHandler(this.ctrlChoixListe_Resize);
            this.Barre.ResumeLayout(false);
            this.Barre.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStrip Barre;
        private System.Windows.Forms.ToolStripButton btnAjouter;
        private System.Windows.Forms.ToolStripButton btnRetirer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lstChoix;
        private System.Windows.Forms.ListBox lstSelection;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnTout;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox lblRecherche;
        private System.Windows.Forms.Label label1;
    }
}
