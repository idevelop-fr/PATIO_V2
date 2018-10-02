namespace PATIO.Interfaces
{
    partial class ctrlListePlan
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
            this.lstPlan = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnNewPlan = new System.Windows.Forms.ToolStripButton();
            this.btnModifierPlan = new System.Windows.Forms.ToolStripButton();
            this.btnDesactiverPlan = new System.Windows.Forms.ToolStripButton();
            this.btnSupprimerPlan = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.btnOuvrirPlan = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnActualiserPlan = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuTransfert = new System.Windows.Forms.ToolStripDropDownButton();
            this.MenuImporter = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuExporter = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.lblRecherche = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatut = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblNb = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstPlan
            // 
            this.lstPlan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstPlan.FullRowSelect = true;
            this.lstPlan.ImageIndex = 0;
            this.lstPlan.ImageList = this.imageList1;
            this.lstPlan.Location = new System.Drawing.Point(0, 25);
            this.lstPlan.Name = "lstPlan";
            this.lstPlan.SelectedImageIndex = 0;
            this.lstPlan.ShowNodeToolTips = true;
            this.lstPlan.Size = new System.Drawing.Size(443, 418);
            this.lstPlan.TabIndex = 10;
            this.lstPlan.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.lstPlan_AfterSelect);
            this.lstPlan.DoubleClick += new System.EventHandler(this.lstPlan_DoubleClick);
            this.lstPlan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lstPlan_KeyPress);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.btnNewPlan,
            this.btnModifierPlan,
            this.btnDesactiverPlan,
            this.btnSupprimerPlan,
            this.toolStripSeparator2,
            this.toolStripSeparator16,
            this.btnOuvrirPlan,
            this.toolStripSeparator3,
            this.BtnActualiserPlan,
            this.toolStripSeparator17,
            this.MenuTransfert,
            this.toolStripSeparator4,
            this.lblRecherche,
            this.toolStripSeparator5});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(443, 25);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnNewPlan
            // 
            this.btnNewPlan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNewPlan.Image = global::PATIO.Properties.Resources.btn_ajouter;
            this.btnNewPlan.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnNewPlan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNewPlan.Name = "btnNewPlan";
            this.btnNewPlan.Size = new System.Drawing.Size(23, 22);
            this.btnNewPlan.Text = "Créer";
            this.btnNewPlan.Click += new System.EventHandler(this.BtnNewPlan_Click);
            // 
            // btnModifierPlan
            // 
            this.btnModifierPlan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnModifierPlan.Image = global::PATIO.Properties.Resources.btn_modifier;
            this.btnModifierPlan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnModifierPlan.Name = "btnModifierPlan";
            this.btnModifierPlan.Size = new System.Drawing.Size(23, 22);
            this.btnModifierPlan.Text = "Modifier";
            this.btnModifierPlan.Click += new System.EventHandler(this.BtnModifierPlan_Click);
            // 
            // btnDesactiverPlan
            // 
            this.btnDesactiverPlan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDesactiverPlan.Image = global::PATIO.Properties.Resources.case_a_cocher;
            this.btnDesactiverPlan.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDesactiverPlan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDesactiverPlan.Name = "btnDesactiverPlan";
            this.btnDesactiverPlan.Size = new System.Drawing.Size(23, 22);
            this.btnDesactiverPlan.Text = "Activer/Désactiver";
            this.btnDesactiverPlan.Click += new System.EventHandler(this.btnDesactiverPlan_Click);
            // 
            // btnSupprimerPlan
            // 
            this.btnSupprimerPlan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSupprimerPlan.Image = global::PATIO.Properties.Resources.btn_supprimer;
            this.btnSupprimerPlan.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSupprimerPlan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSupprimerPlan.Name = "btnSupprimerPlan";
            this.btnSupprimerPlan.Size = new System.Drawing.Size(23, 22);
            this.btnSupprimerPlan.Text = "Supprimer";
            this.btnSupprimerPlan.Click += new System.EventHandler(this.BtnSupprimerPlan_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            this.toolStripSeparator16.Size = new System.Drawing.Size(6, 25);
            // 
            // btnOuvrirPlan
            // 
            this.btnOuvrirPlan.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnOuvrirPlan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOuvrirPlan.Image = global::PATIO.Properties.Resources.btn_voir;
            this.btnOuvrirPlan.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnOuvrirPlan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOuvrirPlan.Name = "btnOuvrirPlan";
            this.btnOuvrirPlan.Size = new System.Drawing.Size(23, 22);
            this.btnOuvrirPlan.Text = "Ouvrir";
            this.btnOuvrirPlan.Click += new System.EventHandler(this.btnOuvrirPlan_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // BtnActualiserPlan
            // 
            this.BtnActualiserPlan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnActualiserPlan.Image = global::PATIO.Properties.Resources.btn_maj;
            this.BtnActualiserPlan.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnActualiserPlan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnActualiserPlan.Name = "BtnActualiserPlan";
            this.BtnActualiserPlan.Size = new System.Drawing.Size(23, 22);
            this.BtnActualiserPlan.Text = "Actualiser";
            this.BtnActualiserPlan.Click += new System.EventHandler(this.BtnActualiserPlan_Click);
            // 
            // toolStripSeparator17
            // 
            this.toolStripSeparator17.Name = "toolStripSeparator17";
            this.toolStripSeparator17.Size = new System.Drawing.Size(6, 25);
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
            this.MenuExporter.Click += new System.EventHandler(this.MenuExporter_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // lblRecherche
            // 
            this.lblRecherche.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblRecherche.Name = "lblRecherche";
            this.lblRecherche.Size = new System.Drawing.Size(150, 25);
            this.lblRecherche.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lblRecherche_KeyPress);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatut,
            this.lblNb});
            this.statusStrip1.Location = new System.Drawing.Point(0, 443);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(443, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatut
            // 
            this.lblStatut.Name = "lblStatut";
            this.lblStatut.Size = new System.Drawing.Size(399, 17);
            this.lblStatut.Spring = true;
            this.lblStatut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNb
            // 
            this.lblNb.Name = "lblNb";
            this.lblNb.Size = new System.Drawing.Size(29, 17);
            this.lblNb.Text = "Nb :";
            // 
            // ctrlListePlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lstPlan);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ctrlListePlan";
            this.Size = new System.Drawing.Size(443, 465);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView lstPlan;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnNewPlan;
        private System.Windows.Forms.ToolStripButton btnModifierPlan;
        private System.Windows.Forms.ToolStripButton btnDesactiverPlan;
        private System.Windows.Forms.ToolStripButton btnSupprimerPlan;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator16;
        private System.Windows.Forms.ToolStripButton btnOuvrirPlan;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton BtnActualiserPlan;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator17;
        public System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripDropDownButton MenuTransfert;
        private System.Windows.Forms.ToolStripMenuItem MenuImporter;
        private System.Windows.Forms.ToolStripMenuItem MenuExporter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        public System.Windows.Forms.ToolStripTextBox lblRecherche;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatut;
        private System.Windows.Forms.ToolStripStatusLabel lblNb;
    }
}
