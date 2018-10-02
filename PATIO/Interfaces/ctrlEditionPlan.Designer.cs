namespace PATIO.Interfaces
{
    partial class ctrlEditionPlan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlEditionPlan));
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tree = new System.Windows.Forms.TreeView();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnOuvrirPDF = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
            this.lblNbIndicateur = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
            this.lblNbOpération = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.lblNbAction = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.lblNbObjectif = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.pb = new System.Windows.Forms.ToolStripProgressBar();
            this.btnOuvrirXLS = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.lstPlan = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCompresser = new System.Windows.Forms.Button();
            this.btnAgréger = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEditer = new System.Windows.Forms.Button();
            this.optIndicateur = new System.Windows.Forms.CheckBox();
            this.optOpération = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(225, 25);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 582);
            this.splitter1.TabIndex = 8;
            this.splitter1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tree);
            this.panel1.Controls.Add(this.toolStrip2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(228, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(843, 582);
            this.panel1.TabIndex = 9;
            // 
            // tree
            // 
            this.tree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tree.Location = new System.Drawing.Point(0, 25);
            this.tree.Name = "tree";
            this.tree.Size = new System.Drawing.Size(843, 557);
            this.tree.TabIndex = 1;
            // 
            // toolStrip2
            // 
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator3,
            this.btnOuvrirPDF,
            this.toolStripSeparator4,
            this.toolStripSeparator19,
            this.lblNbIndicateur,
            this.toolStripSeparator17,
            this.lblNbOpération,
            this.toolStripSeparator14,
            this.lblNbAction,
            this.toolStripSeparator15,
            this.lblNbObjectif,
            this.toolStripSeparator16,
            this.pb,
            this.btnOuvrirXLS,
            this.toolStripSeparator2});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(843, 25);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnOuvrirPDF
            // 
            this.btnOuvrirPDF.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnOuvrirPDF.Image = ((System.Drawing.Image)(resources.GetObject("btnOuvrirPDF.Image")));
            this.btnOuvrirPDF.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOuvrirPDF.Name = "btnOuvrirPDF";
            this.btnOuvrirPDF.Size = new System.Drawing.Size(84, 22);
            this.btnOuvrirPDF.Text = "Ouvrir en PDF";
            this.btnOuvrirPDF.Click += new System.EventHandler(this.btnOuvrir_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator19
            // 
            this.toolStripSeparator19.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator19.Name = "toolStripSeparator19";
            this.toolStripSeparator19.Size = new System.Drawing.Size(6, 25);
            // 
            // lblNbIndicateur
            // 
            this.lblNbIndicateur.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblNbIndicateur.Name = "lblNbIndicateur";
            this.lblNbIndicateur.Size = new System.Drawing.Size(71, 22);
            this.lblNbIndicateur.Text = "Indicateurs :";
            // 
            // toolStripSeparator17
            // 
            this.toolStripSeparator17.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator17.Name = "toolStripSeparator17";
            this.toolStripSeparator17.Size = new System.Drawing.Size(6, 25);
            // 
            // lblNbOpération
            // 
            this.lblNbOpération.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblNbOpération.Name = "lblNbOpération";
            this.lblNbOpération.Size = new System.Drawing.Size(71, 22);
            this.lblNbOpération.Text = "Opérations :";
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(6, 25);
            // 
            // lblNbAction
            // 
            this.lblNbAction.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblNbAction.Name = "lblNbAction";
            this.lblNbAction.Size = new System.Drawing.Size(53, 22);
            this.lblNbAction.Text = "Actions :";
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            this.toolStripSeparator15.Size = new System.Drawing.Size(6, 25);
            // 
            // lblNbObjectif
            // 
            this.lblNbObjectif.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblNbObjectif.Name = "lblNbObjectif";
            this.lblNbObjectif.Size = new System.Drawing.Size(60, 22);
            this.lblNbObjectif.Text = "Objectifs :";
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            this.toolStripSeparator16.Size = new System.Drawing.Size(6, 25);
            // 
            // pb
            // 
            this.pb.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(100, 22);
            this.pb.Visible = false;
            // 
            // btnOuvrirXLS
            // 
            this.btnOuvrirXLS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnOuvrirXLS.Image = ((System.Drawing.Image)(resources.GetObject("btnOuvrirXLS.Image")));
            this.btnOuvrirXLS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOuvrirXLS.Name = "btnOuvrirXLS";
            this.btnOuvrirXLS.Size = new System.Drawing.Size(89, 22);
            this.btnOuvrirXLS.Text = "Ouvrir en Excel";
            this.btnOuvrirXLS.Click += new System.EventHandler(this.btnOuvrirXLS_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.toolStripLabel2,
            this.lstPlan,
            this.toolStripSeparator5});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1071, 25);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(89, 22);
            this.toolStripLabel2.Text = "Liste des plans :";
            // 
            // lstPlan
            // 
            this.lstPlan.Name = "lstPlan";
            this.lstPlan.Size = new System.Drawing.Size(400, 25);
            this.lstPlan.SelectedIndexChanged += new System.EventHandler(this.lstPlan_SelectedIndexChanged);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 25);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3);
            this.panel2.Size = new System.Drawing.Size(225, 582);
            this.panel2.TabIndex = 11;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCompresser);
            this.groupBox2.Controls.Add(this.btnAgréger);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 123);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(219, 106);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Agrégation";
            // 
            // btnCompresser
            // 
            this.btnCompresser.Location = new System.Drawing.Point(84, 61);
            this.btnCompresser.Name = "btnCompresser";
            this.btnCompresser.Size = new System.Drawing.Size(129, 36);
            this.btnCompresser.TabIndex = 4;
            this.btnCompresser.Text = "Compresser les XLS";
            this.btnCompresser.UseVisualStyleBackColor = true;
            this.btnCompresser.Click += new System.EventHandler(this.btnCompresser_Click);
            // 
            // btnAgréger
            // 
            this.btnAgréger.Location = new System.Drawing.Point(84, 19);
            this.btnAgréger.Name = "btnAgréger";
            this.btnAgréger.Size = new System.Drawing.Size(129, 36);
            this.btnAgréger.TabIndex = 3;
            this.btnAgréger.Text = "Agréger et ouvrir";
            this.btnAgréger.UseVisualStyleBackColor = true;
            this.btnAgréger.Click += new System.EventHandler(this.btnAgréger_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnEditer);
            this.groupBox1.Controls.Add(this.optIndicateur);
            this.groupBox1.Controls.Add(this.optOpération);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(219, 120);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Eléments à afficher";
            // 
            // btnEditer
            // 
            this.btnEditer.Location = new System.Drawing.Point(138, 78);
            this.btnEditer.Name = "btnEditer";
            this.btnEditer.Size = new System.Drawing.Size(75, 36);
            this.btnEditer.TabIndex = 2;
            this.btnEditer.Text = "Editer";
            this.btnEditer.UseVisualStyleBackColor = true;
            this.btnEditer.Click += new System.EventHandler(this.btnEditer_Click);
            // 
            // optIndicateur
            // 
            this.optIndicateur.AutoSize = true;
            this.optIndicateur.Location = new System.Drawing.Point(25, 46);
            this.optIndicateur.Name = "optIndicateur";
            this.optIndicateur.Size = new System.Drawing.Size(78, 17);
            this.optIndicateur.TabIndex = 1;
            this.optIndicateur.Text = "Indicateurs";
            this.optIndicateur.UseVisualStyleBackColor = true;
            this.optIndicateur.CheckedChanged += new System.EventHandler(this.optIndicateur_CheckedChanged);
            // 
            // optOpération
            // 
            this.optOpération.AutoSize = true;
            this.optOpération.Location = new System.Drawing.Point(25, 22);
            this.optOpération.Name = "optOpération";
            this.optOpération.Size = new System.Drawing.Size(77, 17);
            this.optOpération.TabIndex = 0;
            this.optOpération.Text = "Opérations";
            this.optOpération.UseVisualStyleBackColor = true;
            this.optOpération.CheckedChanged += new System.EventHandler(this.optOpération_CheckedChanged);
            // 
            // ctrlEditionPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ctrlEditionPlan";
            this.Size = new System.Drawing.Size(1071, 607);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnOuvrirPDF;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripProgressBar pb;
        private System.Windows.Forms.TreeView tree;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator19;
        private System.Windows.Forms.ToolStripLabel lblNbIndicateur;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator17;
        private System.Windows.Forms.ToolStripLabel lblNbOpération;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
        private System.Windows.Forms.ToolStripLabel lblNbAction;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator15;
        private System.Windows.Forms.ToolStripLabel lblNbObjectif;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator16;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox lstPlan;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnEditer;
        private System.Windows.Forms.CheckBox optIndicateur;
        private System.Windows.Forms.CheckBox optOpération;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStripButton btnOuvrirXLS;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Button btnAgréger;
        private System.Windows.Forms.Button btnCompresser;
    }
}
