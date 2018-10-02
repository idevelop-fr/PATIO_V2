namespace PATIO.Interfaces
{
    partial class ctrlEditionTerritoire
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlEditionTerritoire));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnAfficherTerritoire = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.optRelation = new System.Windows.Forms.RadioButton();
            this.optDéclinaison = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstTerritoire = new System.Windows.Forms.ListBox();
            this.tree = new System.Windows.Forms.TreeView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEditer = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tree);
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip1);
            this.splitContainer1.Size = new System.Drawing.Size(912, 553);
            this.splitContainer1.SplitterDistance = 232;
            this.splitContainer1.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnAfficherTerritoire);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 228);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox3.Size = new System.Drawing.Size(226, 60);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // btnAfficherTerritoire
            // 
            this.btnAfficherTerritoire.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAfficherTerritoire.Location = new System.Drawing.Point(140, 18);
            this.btnAfficherTerritoire.Name = "btnAfficherTerritoire";
            this.btnAfficherTerritoire.Size = new System.Drawing.Size(81, 37);
            this.btnAfficherTerritoire.TabIndex = 0;
            this.btnAfficherTerritoire.Text = "Afficher";
            this.btnAfficherTerritoire.UseVisualStyleBackColor = true;
            this.btnAfficherTerritoire.Click += new System.EventHandler(this.btnAfficherTerritoire_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.optRelation);
            this.groupBox2.Controls.Add(this.optDéclinaison);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 154);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(226, 74);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // optRelation
            // 
            this.optRelation.AutoSize = true;
            this.optRelation.Location = new System.Drawing.Point(11, 42);
            this.optRelation.Name = "optRelation";
            this.optRelation.Size = new System.Drawing.Size(212, 17);
            this.optRelation.TabIndex = 1;
            this.optRelation.Text = "En relation avec une priorité du territoire";
            this.optRelation.UseVisualStyleBackColor = true;
            // 
            // optDéclinaison
            // 
            this.optDéclinaison.AutoSize = true;
            this.optDéclinaison.Checked = true;
            this.optDéclinaison.Location = new System.Drawing.Point(11, 19);
            this.optDéclinaison.Name = "optDéclinaison";
            this.optDéclinaison.Size = new System.Drawing.Size(148, 17);
            this.optDéclinaison.TabIndex = 0;
            this.optDéclinaison.TabStop = true;
            this.optDéclinaison.Text = "Déclinaison sur le territoire";
            this.optDéclinaison.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstTerritoire);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(226, 151);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Territoires";
            // 
            // lstTerritoire
            // 
            this.lstTerritoire.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstTerritoire.FormattingEnabled = true;
            this.lstTerritoire.Location = new System.Drawing.Point(3, 16);
            this.lstTerritoire.Name = "lstTerritoire";
            this.lstTerritoire.Size = new System.Drawing.Size(220, 132);
            this.lstTerritoire.TabIndex = 0;
            // 
            // tree
            // 
            this.tree.CheckBoxes = true;
            this.tree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tree.Location = new System.Drawing.Point(0, 25);
            this.tree.Name = "tree";
            this.tree.Size = new System.Drawing.Size(676, 528);
            this.tree.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.btnEditer,
            this.toolStripSeparator2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(676, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnEditer
            // 
            this.btnEditer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnEditer.Image = ((System.Drawing.Image)(resources.GetObject("btnEditer.Image")));
            this.btnEditer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditer.Name = "btnEditer";
            this.btnEditer.Size = new System.Drawing.Size(41, 22);
            this.btnEditer.Text = "Editer";
            this.btnEditer.Click += new System.EventHandler(this.btnEditer_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // ctrlEditionTerritoire
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ctrlEditionTerritoire";
            this.Size = new System.Drawing.Size(912, 553);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnAfficherTerritoire;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lstTerritoire;
        private System.Windows.Forms.TreeView tree;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnEditer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton optRelation;
        private System.Windows.Forms.RadioButton optDéclinaison;
    }
}
