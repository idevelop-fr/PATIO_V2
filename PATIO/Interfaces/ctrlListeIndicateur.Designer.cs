namespace PATIO.Interfaces
{
    partial class ctrlListeIndicateur
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
            this.lstIndicateur = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCreerObjectif = new System.Windows.Forms.ToolStripButton();
            this.btnCreerSousObjectif = new System.Windows.Forms.ToolStripButton();
            this.BtnModifierIndicateur = new System.Windows.Forms.ToolStripButton();
            this.BtnDesactiverIndicateur = new System.Windows.Forms.ToolStripButton();
            this.BtnSupprimerIndicateur = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnOuvrirIndicateur = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnActualiserIndicateur = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator20 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuTransfert = new System.Windows.Forms.ToolStripDropDownButton();
            this.MenuImporter = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuExporter = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lblRecherche = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatut = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblNb = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip4.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstIndicateur
            // 
            this.lstIndicateur.AllowDrop = true;
            this.lstIndicateur.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstIndicateur.FullRowSelect = true;
            this.lstIndicateur.ImageIndex = 0;
            this.lstIndicateur.ImageList = this.imageList1;
            this.lstIndicateur.Location = new System.Drawing.Point(0, 25);
            this.lstIndicateur.Name = "lstIndicateur";
            this.lstIndicateur.SelectedImageIndex = 0;
            this.lstIndicateur.ShowNodeToolTips = true;
            this.lstIndicateur.Size = new System.Drawing.Size(366, 378);
            this.lstIndicateur.TabIndex = 11;
            this.lstIndicateur.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.lstIndicateur_AfterSelect);
            this.lstIndicateur.DragDrop += new System.Windows.Forms.DragEventHandler(this.lstIndicateur_DragDrop);
            this.lstIndicateur.DragOver += new System.Windows.Forms.DragEventHandler(this.lstIndicateur_DragOver);
            this.lstIndicateur.DoubleClick += new System.EventHandler(this.lstIndicateur_DoubleClick);
            this.lstIndicateur.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstIndicateur_MouseDown);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // toolStrip4
            // 
            this.toolStrip4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator8,
            this.btnCreerObjectif,
            this.btnCreerSousObjectif,
            this.BtnModifierIndicateur,
            this.BtnDesactiverIndicateur,
            this.BtnSupprimerIndicateur,
            this.toolStripSeparator9,
            this.toolStripSeparator11,
            this.BtnOuvrirIndicateur,
            this.toolStripSeparator15,
            this.BtnActualiserIndicateur,
            this.toolStripSeparator20,
            this.MenuTransfert,
            this.toolStripSeparator1,
            this.lblRecherche,
            this.toolStripSeparator2});
            this.toolStrip4.Location = new System.Drawing.Point(0, 0);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.Size = new System.Drawing.Size(366, 25);
            this.toolStrip4.TabIndex = 10;
            this.toolStrip4.Text = "toolStrip4";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // btnCreerObjectif
            // 
            this.btnCreerObjectif.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCreerObjectif.Image = global::PATIO.Properties.Resources.plus;
            this.btnCreerObjectif.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnCreerObjectif.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCreerObjectif.Name = "btnCreerObjectif";
            this.btnCreerObjectif.Size = new System.Drawing.Size(23, 22);
            this.btnCreerObjectif.Text = "Créer un objectif";
            this.btnCreerObjectif.Click += new System.EventHandler(this.btnCreerObjectif_Click);
            // 
            // btnCreerSousObjectif
            // 
            this.btnCreerSousObjectif.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCreerSousObjectif.Image = global::PATIO.Properties.Resources.plus_o;
            this.btnCreerSousObjectif.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnCreerSousObjectif.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCreerSousObjectif.Name = "btnCreerSousObjectif";
            this.btnCreerSousObjectif.Size = new System.Drawing.Size(23, 22);
            this.btnCreerSousObjectif.Text = "Créer un sous-objectif";
            this.btnCreerSousObjectif.Click += new System.EventHandler(this.btnCreerSousObjectif_Click);
            // 
            // BtnModifierIndicateur
            // 
            this.BtnModifierIndicateur.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnModifierIndicateur.Image = global::PATIO.Properties.Resources.btn_modifier;
            this.BtnModifierIndicateur.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnModifierIndicateur.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnModifierIndicateur.Name = "BtnModifierIndicateur";
            this.BtnModifierIndicateur.Size = new System.Drawing.Size(23, 22);
            this.BtnModifierIndicateur.Text = "Modifier";
            this.BtnModifierIndicateur.Click += new System.EventHandler(this.BtnModifierIndicateur_Click);
            // 
            // BtnDesactiverIndicateur
            // 
            this.BtnDesactiverIndicateur.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnDesactiverIndicateur.Image = global::PATIO.Properties.Resources.case_a_cocher;
            this.BtnDesactiverIndicateur.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnDesactiverIndicateur.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnDesactiverIndicateur.Name = "BtnDesactiverIndicateur";
            this.BtnDesactiverIndicateur.Size = new System.Drawing.Size(23, 22);
            this.BtnDesactiverIndicateur.Text = "Activer/Désactiver";
            this.BtnDesactiverIndicateur.Click += new System.EventHandler(this.btnDesactiverIndicateur_Click);
            // 
            // BtnSupprimerIndicateur
            // 
            this.BtnSupprimerIndicateur.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnSupprimerIndicateur.Image = global::PATIO.Properties.Resources.btn_supprimer;
            this.BtnSupprimerIndicateur.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnSupprimerIndicateur.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnSupprimerIndicateur.Name = "BtnSupprimerIndicateur";
            this.BtnSupprimerIndicateur.Size = new System.Drawing.Size(23, 22);
            this.BtnSupprimerIndicateur.Text = "Supprimer";
            this.BtnSupprimerIndicateur.Click += new System.EventHandler(this.BtnSupprimerIndicateur_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 25);
            // 
            // BtnOuvrirIndicateur
            // 
            this.BtnOuvrirIndicateur.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.BtnOuvrirIndicateur.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnOuvrirIndicateur.Image = global::PATIO.Properties.Resources.btn_voir;
            this.BtnOuvrirIndicateur.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnOuvrirIndicateur.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnOuvrirIndicateur.Name = "BtnOuvrirIndicateur";
            this.BtnOuvrirIndicateur.Size = new System.Drawing.Size(23, 22);
            this.BtnOuvrirIndicateur.Text = "Ouvrir";
            this.BtnOuvrirIndicateur.Click += new System.EventHandler(this.BtnOuvrirIndicateur_Click);
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            this.toolStripSeparator15.Size = new System.Drawing.Size(6, 25);
            // 
            // BtnActualiserIndicateur
            // 
            this.BtnActualiserIndicateur.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnActualiserIndicateur.Image = global::PATIO.Properties.Resources.btn_maj;
            this.BtnActualiserIndicateur.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnActualiserIndicateur.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnActualiserIndicateur.Name = "BtnActualiserIndicateur";
            this.BtnActualiserIndicateur.Size = new System.Drawing.Size(23, 22);
            this.BtnActualiserIndicateur.Text = "Actualiser";
            this.BtnActualiserIndicateur.Click += new System.EventHandler(this.BtnActualiserIndicateur_Click);
            // 
            // toolStripSeparator20
            // 
            this.toolStripSeparator20.Name = "toolStripSeparator20";
            this.toolStripSeparator20.Size = new System.Drawing.Size(6, 25);
            // 
            // MenuTransfert
            // 
            this.MenuTransfert.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuTransfert.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuImporter,
            this.MenuExporter});
            this.MenuTransfert.Image = global::PATIO.Properties.Resources.squares_2;
            this.MenuTransfert.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuTransfert.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuTransfert.Name = "MenuTransfert";
            this.MenuTransfert.Size = new System.Drawing.Size(24, 22);
            this.MenuTransfert.Text = "toolStripDropDownButton1";
            // 
            // MenuImporter
            // 
            this.MenuImporter.Name = "MenuImporter";
            this.MenuImporter.Size = new System.Drawing.Size(120, 22);
            this.MenuImporter.Text = "Importer";
            this.MenuImporter.Click += new System.EventHandler(this.MenuImporter_Click);
            // 
            // MenuExporter
            // 
            this.MenuExporter.Name = "MenuExporter";
            this.MenuExporter.Size = new System.Drawing.Size(120, 22);
            this.MenuExporter.Text = "Exporter";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // lblRecherche
            // 
            this.lblRecherche.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblRecherche.Name = "lblRecherche";
            this.lblRecherche.Size = new System.Drawing.Size(100, 25);
            this.lblRecherche.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lblRecherche_KeyPress);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatut,
            this.lblNb});
            this.statusStrip1.Location = new System.Drawing.Point(0, 403);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(366, 22);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatut
            // 
            this.lblStatut.Name = "lblStatut";
            this.lblStatut.Size = new System.Drawing.Size(322, 17);
            this.lblStatut.Spring = true;
            this.lblStatut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNb
            // 
            this.lblNb.Name = "lblNb";
            this.lblNb.Size = new System.Drawing.Size(29, 17);
            this.lblNb.Text = "Nb :";
            // 
            // ctrlListeIndicateur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lstIndicateur);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip4);
            this.Name = "ctrlListeIndicateur";
            this.Size = new System.Drawing.Size(366, 425);
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton BtnModifierIndicateur;
        private System.Windows.Forms.ToolStripButton BtnDesactiverIndicateur;
        private System.Windows.Forms.ToolStripButton BtnSupprimerIndicateur;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripButton BtnOuvrirIndicateur;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator15;
        private System.Windows.Forms.ToolStripButton BtnActualiserIndicateur;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator20;
        public System.Windows.Forms.ImageList imageList1;
        public System.Windows.Forms.TreeView lstIndicateur;
        private System.Windows.Forms.ToolStripDropDownButton MenuTransfert;
        private System.Windows.Forms.ToolStripMenuItem MenuImporter;
        private System.Windows.Forms.ToolStripMenuItem MenuExporter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatut;
        private System.Windows.Forms.ToolStripStatusLabel lblNb;
        public System.Windows.Forms.ToolStripTextBox lblRecherche;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnCreerSousObjectif;
        private System.Windows.Forms.ToolStripButton btnCreerObjectif;
    }
}
