namespace PATIO.Interfaces
{
    partial class ctrlListeAction
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
            this.lstAction = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCréerAction = new System.Windows.Forms.ToolStripButton();
            this.BtnCréerSousAction = new System.Windows.Forms.ToolStripButton();
            this.BtnModifierAction = new System.Windows.Forms.ToolStripButton();
            this.BtnSupprimerAction = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnActualiserAction = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuTransfert = new System.Windows.Forms.ToolStripDropDownButton();
            this.MenuExporter = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuSupprimer_Lien = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lblRecherche = new System.Windows.Forms.ToolStripTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatut = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblNb = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip3.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstAction
            // 
            this.lstAction.AllowDrop = true;
            this.lstAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstAction.FullRowSelect = true;
            this.lstAction.HideSelection = false;
            this.lstAction.ImageIndex = 0;
            this.lstAction.ImageList = this.imageList1;
            this.lstAction.Location = new System.Drawing.Point(0, 25);
            this.lstAction.Name = "lstAction";
            this.lstAction.SelectedImageIndex = 0;
            this.lstAction.ShowNodeToolTips = true;
            this.lstAction.Size = new System.Drawing.Size(398, 382);
            this.lstAction.TabIndex = 10;
            this.lstAction.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.lstAction_AfterSelect);
            this.lstAction.DragDrop += new System.Windows.Forms.DragEventHandler(this.lstAction_DragDrop);
            this.lstAction.DragOver += new System.Windows.Forms.DragEventHandler(this.lstAction_DragOver);
            this.lstAction.DoubleClick += new System.EventHandler(this.lstAction_DoubleClick);
            this.lstAction.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstAction_MouseDown);
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
            this.btnCréerAction,
            this.BtnCréerSousAction,
            this.BtnModifierAction,
            this.BtnSupprimerAction,
            this.toolStripSeparator7,
            this.toolStripSeparator10,
            this.BtnActualiserAction,
            this.toolStripSeparator19,
            this.MenuTransfert,
            this.toolStripSeparator1,
            this.lblRecherche});
            this.toolStrip3.Location = new System.Drawing.Point(0, 0);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(398, 25);
            this.toolStrip3.TabIndex = 9;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // btnCréerAction
            // 
            this.btnCréerAction.BackColor = System.Drawing.SystemColors.Control;
            this.btnCréerAction.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCréerAction.Image = global::PATIO.Properties.Resources.plus;
            this.btnCréerAction.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnCréerAction.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCréerAction.Name = "btnCréerAction";
            this.btnCréerAction.Size = new System.Drawing.Size(23, 22);
            this.btnCréerAction.Text = "Créer une action";
            this.btnCréerAction.Click += new System.EventHandler(this.btnCréerAction_Click);
            // 
            // BtnCréerSousAction
            // 
            this.BtnCréerSousAction.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnCréerSousAction.Image = global::PATIO.Properties.Resources.plus_o;
            this.BtnCréerSousAction.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnCréerSousAction.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnCréerSousAction.Name = "BtnCréerSousAction";
            this.BtnCréerSousAction.Size = new System.Drawing.Size(23, 22);
            this.BtnCréerSousAction.Text = "Créer une sous-action";
            this.BtnCréerSousAction.Click += new System.EventHandler(this.BtnNewAction_Click);
            // 
            // BtnModifierAction
            // 
            this.BtnModifierAction.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnModifierAction.Image = global::PATIO.Properties.Resources.btn_modifier;
            this.BtnModifierAction.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnModifierAction.Name = "BtnModifierAction";
            this.BtnModifierAction.Size = new System.Drawing.Size(23, 22);
            this.BtnModifierAction.Text = "Modifier";
            this.BtnModifierAction.Click += new System.EventHandler(this.BtnModifierAction_Click);
            // 
            // BtnSupprimerAction
            // 
            this.BtnSupprimerAction.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnSupprimerAction.Image = global::PATIO.Properties.Resources.btn_supprimer;
            this.BtnSupprimerAction.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnSupprimerAction.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnSupprimerAction.Name = "BtnSupprimerAction";
            this.BtnSupprimerAction.Size = new System.Drawing.Size(23, 22);
            this.BtnSupprimerAction.Text = "Supprimer";
            this.BtnSupprimerAction.Click += new System.EventHandler(this.BtnSupprimerAction_Click);
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
            // BtnActualiserAction
            // 
            this.BtnActualiserAction.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnActualiserAction.Image = global::PATIO.Properties.Resources.btn_maj;
            this.BtnActualiserAction.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnActualiserAction.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnActualiserAction.Name = "BtnActualiserAction";
            this.BtnActualiserAction.Size = new System.Drawing.Size(23, 22);
            this.BtnActualiserAction.Text = "Actualiser";
            this.BtnActualiserAction.Click += new System.EventHandler(this.BtnActualiserAction_Click);
            // 
            // toolStripSeparator19
            // 
            this.toolStripSeparator19.Name = "toolStripSeparator19";
            this.toolStripSeparator19.Size = new System.Drawing.Size(6, 25);
            // 
            // MenuTransfert
            // 
            this.MenuTransfert.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuTransfert.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuExporter,
            this.toolStripSeparator2,
            this.MenuSupprimer_Lien});
            this.MenuTransfert.Image = global::PATIO.Properties.Resources.squares_2;
            this.MenuTransfert.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuTransfert.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuTransfert.Name = "MenuTransfert";
            this.MenuTransfert.Size = new System.Drawing.Size(24, 22);
            this.MenuTransfert.Text = "toolStripDropDownButton1";
            // 
            // MenuExporter
            // 
            this.MenuExporter.Name = "MenuExporter";
            this.MenuExporter.Size = new System.Drawing.Size(180, 22);
            this.MenuExporter.Text = "Exporter";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // MenuSupprimer_Lien
            // 
            this.MenuSupprimer_Lien.Name = "MenuSupprimer_Lien";
            this.MenuSupprimer_Lien.Size = new System.Drawing.Size(180, 22);
            this.MenuSupprimer_Lien.Text = "Supprimer le lien";
            this.MenuSupprimer_Lien.Click += new System.EventHandler(this.MenuSupprimer_Lien_Click);
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
            this.lblRecherche.Size = new System.Drawing.Size(150, 25);
            this.lblRecherche.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lblRecherche_KeyPress);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatut,
            this.lblNb});
            this.statusStrip1.Location = new System.Drawing.Point(0, 407);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(398, 22);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatut
            // 
            this.lblStatut.Name = "lblStatut";
            this.lblStatut.Size = new System.Drawing.Size(354, 17);
            this.lblStatut.Spring = true;
            this.lblStatut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNb
            // 
            this.lblNb.Name = "lblNb";
            this.lblNb.Size = new System.Drawing.Size(29, 17);
            this.lblNb.Text = "Nb :";
            // 
            // ctrlListeAction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lstAction);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip3);
            this.Name = "ctrlListeAction";
            this.Size = new System.Drawing.Size(398, 429);
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton BtnCréerSousAction;
        private System.Windows.Forms.ToolStripButton BtnModifierAction;
        private System.Windows.Forms.ToolStripButton BtnSupprimerAction;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripButton BtnActualiserAction;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator19;
        public System.Windows.Forms.ImageList imageList1;
        public System.Windows.Forms.TreeView lstAction;
        private System.Windows.Forms.ToolStripDropDownButton MenuTransfert;
        private System.Windows.Forms.ToolStripMenuItem MenuExporter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem MenuSupprimer_Lien;
        private System.Windows.Forms.ToolStripButton btnCréerAction;
        public System.Windows.Forms.ToolStripTextBox lblRecherche;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatut;
        private System.Windows.Forms.ToolStripStatusLabel lblNb;
    }
}
