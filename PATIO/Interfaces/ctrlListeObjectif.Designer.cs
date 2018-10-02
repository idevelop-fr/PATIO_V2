namespace PATIO.Interfaces
{
    partial class ctrlListeObjectif
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
            this.lstObjectif = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCreerObjectif = new System.Windows.Forms.ToolStripButton();
            this.btnCreerSousObjectif = new System.Windows.Forms.ToolStripButton();
            this.btnModifierObjectif = new System.Windows.Forms.ToolStripButton();
            this.btnDesactiverObjectif = new System.Windows.Forms.ToolStripButton();
            this.btnSupprimerObjectif = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnActualiserObjectif = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator18 = new System.Windows.Forms.ToolStripSeparator();
            this.lblRecherche = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuTransfert = new System.Windows.Forms.ToolStripDropDownButton();
            this.MenuImporter = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuExporter = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatut = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblNb = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstObjectif
            // 
            this.lstObjectif.AllowDrop = true;
            this.lstObjectif.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstObjectif.FullRowSelect = true;
            this.lstObjectif.HideSelection = false;
            this.lstObjectif.ImageIndex = 0;
            this.lstObjectif.ImageList = this.imageList1;
            this.lstObjectif.Location = new System.Drawing.Point(0, 25);
            this.lstObjectif.Name = "lstObjectif";
            this.lstObjectif.SelectedImageIndex = 0;
            this.lstObjectif.ShowNodeToolTips = true;
            this.lstObjectif.Size = new System.Drawing.Size(351, 394);
            this.lstObjectif.TabIndex = 9;
            this.lstObjectif.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.lstObjectif_AfterSelect);
            this.lstObjectif.DragDrop += new System.Windows.Forms.DragEventHandler(this.lstObjectif_DragDrop);
            this.lstObjectif.DragOver += new System.Windows.Forms.DragEventHandler(this.lstObjectif_DragOver);
            this.lstObjectif.DoubleClick += new System.EventHandler(this.lstObjectif_DoubleClick);
            this.lstObjectif.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstObjectif_MouseDown);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // toolStrip2
            // 
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator4,
            this.btnCreerObjectif,
            this.btnCreerSousObjectif,
            this.btnModifierObjectif,
            this.btnDesactiverObjectif,
            this.btnSupprimerObjectif,
            this.toolStripSeparator5,
            this.toolStripSeparator13,
            this.BtnActualiserObjectif,
            this.toolStripSeparator18,
            this.lblRecherche,
            this.toolStripSeparator1,
            this.MenuTransfert});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(351, 25);
            this.toolStrip2.TabIndex = 8;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
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
            this.btnCreerSousObjectif.Click += new System.EventHandler(this.BtnNewObjectif_Click);
            // 
            // btnModifierObjectif
            // 
            this.btnModifierObjectif.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnModifierObjectif.Image = global::PATIO.Properties.Resources.btn_modifier;
            this.btnModifierObjectif.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnModifierObjectif.Name = "btnModifierObjectif";
            this.btnModifierObjectif.Size = new System.Drawing.Size(23, 22);
            this.btnModifierObjectif.Text = "Modifier";
            this.btnModifierObjectif.Click += new System.EventHandler(this.BtnModifierObjectif_Click);
            // 
            // btnDesactiverObjectif
            // 
            this.btnDesactiverObjectif.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDesactiverObjectif.Image = global::PATIO.Properties.Resources.case_a_cocher;
            this.btnDesactiverObjectif.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDesactiverObjectif.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDesactiverObjectif.Name = "btnDesactiverObjectif";
            this.btnDesactiverObjectif.Size = new System.Drawing.Size(23, 22);
            this.btnDesactiverObjectif.Text = "Activer/Désactiver";
            this.btnDesactiverObjectif.Click += new System.EventHandler(this.BtnDesactiverObjectif_Click);
            // 
            // btnSupprimerObjectif
            // 
            this.btnSupprimerObjectif.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSupprimerObjectif.Image = global::PATIO.Properties.Resources.btn_supprimer;
            this.btnSupprimerObjectif.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSupprimerObjectif.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSupprimerObjectif.Name = "btnSupprimerObjectif";
            this.btnSupprimerObjectif.Size = new System.Drawing.Size(23, 22);
            this.btnSupprimerObjectif.Text = "Supprimer";
            this.btnSupprimerObjectif.Click += new System.EventHandler(this.BtnSupprimerObjectif_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(6, 25);
            // 
            // BtnActualiserObjectif
            // 
            this.BtnActualiserObjectif.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnActualiserObjectif.Image = global::PATIO.Properties.Resources.btn_maj;
            this.BtnActualiserObjectif.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnActualiserObjectif.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnActualiserObjectif.Name = "BtnActualiserObjectif";
            this.BtnActualiserObjectif.Size = new System.Drawing.Size(23, 22);
            this.BtnActualiserObjectif.Text = "Actualiser";
            this.BtnActualiserObjectif.Click += new System.EventHandler(this.BtnActualiserObjectif_Click);
            // 
            // toolStripSeparator18
            // 
            this.toolStripSeparator18.Name = "toolStripSeparator18";
            this.toolStripSeparator18.Size = new System.Drawing.Size(6, 25);
            // 
            // lblRecherche
            // 
            this.lblRecherche.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblRecherche.Name = "lblRecherche";
            this.lblRecherche.Size = new System.Drawing.Size(150, 25);
            this.lblRecherche.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lblRecherche_KeyPress);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
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
            this.MenuTransfert.Visible = false;
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
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatut,
            this.lblNb});
            this.statusStrip1.Location = new System.Drawing.Point(0, 419);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(351, 22);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatut
            // 
            this.lblStatut.Name = "lblStatut";
            this.lblStatut.Size = new System.Drawing.Size(307, 17);
            this.lblStatut.Spring = true;
            this.lblStatut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNb
            // 
            this.lblNb.Name = "lblNb";
            this.lblNb.Size = new System.Drawing.Size(29, 17);
            this.lblNb.Text = "Nb :";
            // 
            // ctrlListeObjectif
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lstObjectif);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip2);
            this.Name = "ctrlListeObjectif";
            this.Size = new System.Drawing.Size(351, 441);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnCreerSousObjectif;
        private System.Windows.Forms.ToolStripButton btnModifierObjectif;
        private System.Windows.Forms.ToolStripButton btnDesactiverObjectif;
        private System.Windows.Forms.ToolStripButton btnSupprimerObjectif;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripButton BtnActualiserObjectif;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ImageList imageList1;
        public System.Windows.Forms.TreeView lstObjectif;
        private System.Windows.Forms.ToolStripDropDownButton MenuTransfert;
        private System.Windows.Forms.ToolStripMenuItem MenuImporter;
        private System.Windows.Forms.ToolStripMenuItem MenuExporter;
        public System.Windows.Forms.ToolStripTextBox lblRecherche;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatut;
        private System.Windows.Forms.ToolStripStatusLabel lblNb;
        private System.Windows.Forms.ToolStripButton btnCreerObjectif;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator18;
    }
}
