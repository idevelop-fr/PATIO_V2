namespace PATIO.Interfaces
{
    partial class ctrlListeUtilisateur
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
            this.lstUser = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnNewUser = new System.Windows.Forms.ToolStripButton();
            this.BtnModifierUser = new System.Windows.Forms.ToolStripButton();
            this.BtnDesactiverUser = new System.Windows.Forms.ToolStripButton();
            this.BtnSupprimerUser = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnActualiserUser = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
            this.lblRecherche = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatut = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblNb = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip3.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstUser
            // 
            this.lstUser.AllowDrop = true;
            this.lstUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstUser.FullRowSelect = true;
            this.lstUser.ImageIndex = 0;
            this.lstUser.ImageList = this.imageList1;
            this.lstUser.Location = new System.Drawing.Point(0, 25);
            this.lstUser.Name = "lstUser";
            this.lstUser.SelectedImageIndex = 0;
            this.lstUser.Size = new System.Drawing.Size(349, 400);
            this.lstUser.TabIndex = 12;
            this.lstUser.DragDrop += new System.Windows.Forms.DragEventHandler(this.lstUser_DragDrop);
            this.lstUser.DragOver += new System.Windows.Forms.DragEventHandler(this.lstUser_DragOver);
            this.lstUser.DoubleClick += new System.EventHandler(this.lstUser_DoubleClick);
            this.lstUser.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstUser_MouseDown);
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
            this.BtnNewUser,
            this.BtnModifierUser,
            this.BtnDesactiverUser,
            this.BtnSupprimerUser,
            this.toolStripSeparator7,
            this.toolStripSeparator10,
            this.BtnActualiserUser,
            this.toolStripSeparator19,
            this.lblRecherche,
            this.toolStripSeparator1});
            this.toolStrip3.Location = new System.Drawing.Point(0, 0);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(349, 25);
            this.toolStrip3.TabIndex = 11;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // BtnNewUser
            // 
            this.BtnNewUser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnNewUser.Image = global::PATIO.Properties.Resources.btn_ajouter;
            this.BtnNewUser.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnNewUser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnNewUser.Name = "BtnNewUser";
            this.BtnNewUser.Size = new System.Drawing.Size(23, 22);
            this.BtnNewUser.Text = "Créer";
            this.BtnNewUser.Click += new System.EventHandler(this.BtnNewUser_Click);
            // 
            // BtnModifierUser
            // 
            this.BtnModifierUser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnModifierUser.Image = global::PATIO.Properties.Resources.btn_modifier;
            this.BtnModifierUser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnModifierUser.Name = "BtnModifierUser";
            this.BtnModifierUser.Size = new System.Drawing.Size(23, 22);
            this.BtnModifierUser.Text = "Modifier";
            this.BtnModifierUser.Click += new System.EventHandler(this.BtnModifierUser_Click);
            // 
            // BtnDesactiverUser
            // 
            this.BtnDesactiverUser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnDesactiverUser.Image = global::PATIO.Properties.Resources.case_a_cocher;
            this.BtnDesactiverUser.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnDesactiverUser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnDesactiverUser.Name = "BtnDesactiverUser";
            this.BtnDesactiverUser.Size = new System.Drawing.Size(23, 22);
            this.BtnDesactiverUser.Text = "Activer/Désactiver";
            this.BtnDesactiverUser.Click += new System.EventHandler(this.BtnDesactiverUser_Click);
            // 
            // BtnSupprimerUser
            // 
            this.BtnSupprimerUser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnSupprimerUser.Image = global::PATIO.Properties.Resources.btn_supprimer;
            this.BtnSupprimerUser.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnSupprimerUser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnSupprimerUser.Name = "BtnSupprimerUser";
            this.BtnSupprimerUser.Size = new System.Drawing.Size(23, 22);
            this.BtnSupprimerUser.Text = "Supprimer";
            this.BtnSupprimerUser.Click += new System.EventHandler(this.BtnSupprimerUser_Click);
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
            // BtnActualiserUser
            // 
            this.BtnActualiserUser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnActualiserUser.Image = global::PATIO.Properties.Resources.btn_maj;
            this.BtnActualiserUser.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnActualiserUser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnActualiserUser.Name = "BtnActualiserUser";
            this.BtnActualiserUser.Size = new System.Drawing.Size(23, 22);
            this.BtnActualiserUser.Text = "Actualiser";
            this.BtnActualiserUser.Click += new System.EventHandler(this.BtnActualiserUser_Click);
            // 
            // toolStripSeparator19
            // 
            this.toolStripSeparator19.Name = "toolStripSeparator19";
            this.toolStripSeparator19.Size = new System.Drawing.Size(6, 25);
            // 
            // lblRecherche
            // 
            this.lblRecherche.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblRecherche.Name = "lblRecherche";
            this.lblRecherche.Size = new System.Drawing.Size(100, 25);
            this.lblRecherche.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lblRecherche_KeyPress);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatut,
            this.lblNb});
            this.statusStrip1.Location = new System.Drawing.Point(0, 425);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(349, 22);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatut
            // 
            this.lblStatut.Name = "lblStatut";
            this.lblStatut.Size = new System.Drawing.Size(305, 17);
            this.lblStatut.Spring = true;
            this.lblStatut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNb
            // 
            this.lblNb.Name = "lblNb";
            this.lblNb.Size = new System.Drawing.Size(29, 17);
            this.lblNb.Text = "Nb :";
            // 
            // ctrlListeUtilisateur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lstUser);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip3);
            this.Name = "ctrlListeUtilisateur";
            this.Size = new System.Drawing.Size(349, 447);
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TreeView lstUser;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton BtnNewUser;
        private System.Windows.Forms.ToolStripButton BtnModifierUser;
        private System.Windows.Forms.ToolStripButton BtnDesactiverUser;
        private System.Windows.Forms.ToolStripButton BtnSupprimerUser;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripButton BtnActualiserUser;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator19;
        public System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatut;
        private System.Windows.Forms.ToolStripStatusLabel lblNb;
        public System.Windows.Forms.ToolStripTextBox lblRecherche;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}
