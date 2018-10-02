namespace PATIO
{
    partial class ctrlAccueil
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnActualiser = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.lblCodeUser = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lblNom = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.lstUtilisateur = new System.Windows.Forms.ToolStripComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.treeAsso = new System.Windows.Forms.TreeView();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.btnOuvrirAction = new System.Windows.Forms.ToolStripButton();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.treePilote = new System.Windows.Forms.TreeView();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnOuvrirElement = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator3,
            this.btnActualiser,
            this.toolStripSeparator4,
            this.lblCodeUser,
            this.toolStripSeparator1,
            this.lblNom,
            this.toolStripSeparator2,
            this.toolStripSeparator5,
            this.toolStripLabel1,
            this.lstUtilisateur});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(745, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnActualiser
            // 
            this.btnActualiser.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnActualiser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnActualiser.Image = PATIO.Properties.Resources.btn_maj;
            this.btnActualiser.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnActualiser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnActualiser.Name = "btnActualiser";
            this.btnActualiser.Size = new System.Drawing.Size(23, 22);
            this.btnActualiser.Text = "Actualiser";
            this.btnActualiser.Click += new System.EventHandler(this.btnActualiser_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // lblCodeUser
            // 
            this.lblCodeUser.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblCodeUser.Name = "lblCodeUser";
            this.lblCodeUser.Size = new System.Drawing.Size(58, 22);
            this.lblCodeUser.Text = "CodeUser";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // lblNom
            // 
            this.lblNom.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(89, 22);
            this.lblNom.Text = "Nom utilisateur";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(96, 22);
            this.toolStripLabel1.Text = "Profil utilisateur :";
            // 
            // lstUtilisateur
            // 
            this.lstUtilisateur.Name = "lstUtilisateur";
            this.lstUtilisateur.Size = new System.Drawing.Size(200, 25);
            this.lstUtilisateur.SelectedIndexChanged += new System.EventHandler(this.lstUtilisateur_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.splitter2);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(745, 593);
            this.panel1.TabIndex = 8;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.treeAsso);
            this.groupBox3.Controls.Add(this.toolStrip3);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 335);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(745, 258);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Objets dont vous êtes Membre de l\'équipe";
            // 
            // treeAsso
            // 
            this.treeAsso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeAsso.Location = new System.Drawing.Point(3, 16);
            this.treeAsso.Name = "treeAsso";
            this.treeAsso.Size = new System.Drawing.Size(715, 239);
            this.treeAsso.TabIndex = 0;
            // 
            // toolStrip3
            // 
            this.toolStrip3.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOuvrirAction});
            this.toolStrip3.Location = new System.Drawing.Point(718, 16);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(24, 239);
            this.toolStrip3.TabIndex = 2;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // btnOuvrirAction
            // 
            this.btnOuvrirAction.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOuvrirAction.Image = PATIO.Properties.Resources.btn_voir;
            this.btnOuvrirAction.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnOuvrirAction.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOuvrirAction.Name = "btnOuvrirAction";
            this.btnOuvrirAction.Size = new System.Drawing.Size(21, 14);
            this.btnOuvrirAction.Text = "Ouvrir l\'action";
            this.btnOuvrirAction.Click += new System.EventHandler(this.btnOuvrirAction_Click);
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(0, 332);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(745, 3);
            this.splitter2.TabIndex = 4;
            this.splitter2.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.treePilote);
            this.groupBox2.Controls.Add(this.toolStrip2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(745, 332);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Objets dont vous êtes Pilote";
            // 
            // treePilote
            // 
            this.treePilote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treePilote.Location = new System.Drawing.Point(3, 16);
            this.treePilote.Name = "treePilote";
            this.treePilote.Size = new System.Drawing.Size(715, 313);
            this.treePilote.TabIndex = 0;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOuvrirElement});
            this.toolStrip2.Location = new System.Drawing.Point(718, 16);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(24, 313);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btnOuvrirElement
            // 
            this.btnOuvrirElement.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOuvrirElement.Image = PATIO.Properties.Resources.btn_voir;
            this.btnOuvrirElement.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnOuvrirElement.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOuvrirElement.Name = "btnOuvrirElement";
            this.btnOuvrirElement.Size = new System.Drawing.Size(21, 14);
            this.btnOuvrirElement.Text = "Ouvrir l\'élément";
            this.btnOuvrirElement.Click += new System.EventHandler(this.btnOuvrirElement_Click);
            // 
            // ctrlAccueil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ctrlAccueil";
            this.Size = new System.Drawing.Size(745, 618);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnActualiser;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel lblCodeUser;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel lblNom;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TreeView treeAsso;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TreeView treePilote;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton btnOuvrirAction;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnOuvrirElement;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox lstUtilisateur;
    }
}
