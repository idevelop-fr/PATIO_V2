namespace PATIO.Interfaces
{
    partial class ctrlListeGroupe
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
            this.components = new System.ComponentModel.Container();
            this.lstGroupe = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnNewGroupe = new System.Windows.Forms.ToolStripButton();
            this.BtnModifierGroupe = new System.Windows.Forms.ToolStripButton();
            this.BtnDesactiverGroupe = new System.Windows.Forms.ToolStripButton();
            this.BtnSupprimerGroupe = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnOuvrirGroupe = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnActualiserGroupe = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatut = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblNb = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip3.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstGroupe
            // 
            this.lstGroupe.AllowDrop = true;
            this.lstGroupe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstGroupe.FullRowSelect = true;
            this.lstGroupe.ImageIndex = 0;
            this.lstGroupe.ImageList = this.imageList1;
            this.lstGroupe.Location = new System.Drawing.Point(0, 25);
            this.lstGroupe.Name = "lstGroupe";
            this.lstGroupe.SelectedImageIndex = 0;
            this.lstGroupe.Size = new System.Drawing.Size(291, 399);
            this.lstGroupe.TabIndex = 14;
            this.lstGroupe.DragDrop += new System.Windows.Forms.DragEventHandler(this.lstGroupe_DragDrop);
            this.lstGroupe.DragOver += new System.Windows.Forms.DragEventHandler(this.lstGroupe_DragOver);
            this.lstGroupe.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstGroupe_MouseDown);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // toolStrip3
            // 
            this.toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator6,
            this.BtnNewGroupe,
            this.BtnModifierGroupe,
            this.BtnDesactiverGroupe,
            this.BtnSupprimerGroupe,
            this.toolStripSeparator7,
            this.toolStripSeparator10,
            this.BtnOuvrirGroupe,
            this.toolStripSeparator14,
            this.BtnActualiserGroupe,
            this.toolStripSeparator19});
            this.toolStrip3.Location = new System.Drawing.Point(0, 0);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(291, 25);
            this.toolStrip3.TabIndex = 13;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // BtnNewGroupe
            // 
            this.BtnNewGroupe.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnNewGroupe.Image = global::PATIO.Properties.Resources.btn_ajouter;
            this.BtnNewGroupe.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnNewGroupe.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnNewGroupe.Name = "BtnNewGroupe";
            this.BtnNewGroupe.Size = new System.Drawing.Size(23, 22);
            this.BtnNewGroupe.Text = "Créer";
            this.BtnNewGroupe.Click += new System.EventHandler(this.BtnNewUser_Click);
            // 
            // BtnModifierGroupe
            // 
            this.BtnModifierGroupe.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnModifierGroupe.Image = global::PATIO.Properties.Resources.btn_modifier;
            this.BtnModifierGroupe.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnModifierGroupe.Name = "BtnModifierGroupe";
            this.BtnModifierGroupe.Size = new System.Drawing.Size(23, 22);
            this.BtnModifierGroupe.Text = "Modifier";
            this.BtnModifierGroupe.Click += new System.EventHandler(this.BtnModifierUser_Click);
            // 
            // BtnDesactiverGroupe
            // 
            this.BtnDesactiverGroupe.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnDesactiverGroupe.Image = global::PATIO.Properties.Resources.case_a_cocher;
            this.BtnDesactiverGroupe.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnDesactiverGroupe.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnDesactiverGroupe.Name = "BtnDesactiverGroupe";
            this.BtnDesactiverGroupe.Size = new System.Drawing.Size(23, 22);
            this.BtnDesactiverGroupe.Text = "Activer/Désactiver";
            this.BtnDesactiverGroupe.Click += new System.EventHandler(this.BtnDesactiverGroupe_Click);
            // 
            // BtnSupprimerGroupe
            // 
            this.BtnSupprimerGroupe.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnSupprimerGroupe.Image = global::PATIO.Properties.Resources.btn_supprimer;
            this.BtnSupprimerGroupe.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnSupprimerGroupe.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnSupprimerGroupe.Name = "BtnSupprimerGroupe";
            this.BtnSupprimerGroupe.Size = new System.Drawing.Size(23, 22);
            this.BtnSupprimerGroupe.Text = "Supprimer";
            this.BtnSupprimerGroupe.Click += new System.EventHandler(this.BtnSupprimerGroupe_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 25);
            // 
            // BtnOuvrirGroupe
            // 
            this.BtnOuvrirGroupe.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.BtnOuvrirGroupe.Image = global::PATIO.Properties.Resources.btn_voir;
            this.BtnOuvrirGroupe.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnOuvrirGroupe.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnOuvrirGroupe.Name = "BtnOuvrirGroupe";
            this.BtnOuvrirGroupe.Size = new System.Drawing.Size(55, 22);
            this.BtnOuvrirGroupe.Text = "Ouvrir";
            this.BtnOuvrirGroupe.Click += new System.EventHandler(this.BtnOuvrirGroupe_Click);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(6, 25);
            // 
            // BtnActualiserGroupe
            // 
            this.BtnActualiserGroupe.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnActualiserGroupe.Image = global::PATIO.Properties.Resources.btn_maj;
            this.BtnActualiserGroupe.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnActualiserGroupe.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnActualiserGroupe.Name = "BtnActualiserGroupe";
            this.BtnActualiserGroupe.Size = new System.Drawing.Size(23, 22);
            this.BtnActualiserGroupe.Text = "Actualiser";
            this.BtnActualiserGroupe.Click += new System.EventHandler(this.BtnActualiserGroupe_Click);
            // 
            // toolStripSeparator19
            // 
            this.toolStripSeparator19.Name = "toolStripSeparator19";
            this.toolStripSeparator19.Size = new System.Drawing.Size(6, 25);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatut,
            this.lblNb});
            this.statusStrip1.Location = new System.Drawing.Point(0, 424);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(291, 22);
            this.statusStrip1.TabIndex = 15;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatut
            // 
            this.lblStatut.Name = "lblStatut";
            this.lblStatut.Size = new System.Drawing.Size(247, 17);
            this.lblStatut.Spring = true;
            this.lblStatut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNb
            // 
            this.lblNb.Name = "lblNb";
            this.lblNb.Size = new System.Drawing.Size(29, 17);
            this.lblNb.Text = "Nb :";
            // 
            // ctrlListeGroupe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lstGroupe);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip3);
            this.Name = "ctrlListeGroupe";
            this.Size = new System.Drawing.Size(291, 446);
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TreeView lstGroupe;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton BtnNewGroupe;
        private System.Windows.Forms.ToolStripButton BtnModifierGroupe;
        private System.Windows.Forms.ToolStripButton BtnDesactiverGroupe;
        private System.Windows.Forms.ToolStripButton BtnSupprimerGroupe;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripButton BtnOuvrirGroupe;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
        private System.Windows.Forms.ToolStripButton BtnActualiserGroupe;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator19;
        public System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatut;
        private System.Windows.Forms.ToolStripStatusLabel lblNb;
    }
}
