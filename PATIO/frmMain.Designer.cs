namespace PATIO
{
    partial class frmMain
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.MenuPrincipal = new System.Windows.Forms.ToolStrip();
            this.btn_admin = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_reporting = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRecharger = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSite = new System.Windows.Forms.ToolStripSplitButton();
            this.MenuXWikiPRS = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuXWikiCAPA = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuXWikiTechnique = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.DP = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.panelMenu.SuspendLayout();
            this.MenuPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.MenuPrincipal);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(800, 72);
            this.panelMenu.TabIndex = 1;
            // 
            // MenuPrincipal
            // 
            this.MenuPrincipal.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.MenuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_admin,
            this.toolStripSeparator1,
            this.btn_reporting,
            this.toolStripSeparator2,
            this.btnRecharger,
            this.toolStripSeparator5,
            this.btnSite,
            this.toolStripSeparator6});
            this.MenuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.MenuPrincipal.Name = "MenuPrincipal";
            this.MenuPrincipal.Size = new System.Drawing.Size(800, 77);
            this.MenuPrincipal.TabIndex = 0;
            this.MenuPrincipal.Text = "Menu Principal";
            // 
            // btn_admin
            // 
            this.btn_admin.AutoSize = false;
            this.btn_admin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_admin.Image = ((System.Drawing.Image)(resources.GetObject("btn_admin.Image")));
            this.btn_admin.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btn_admin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_admin.Name = "btn_admin";
            this.btn_admin.Size = new System.Drawing.Size(70, 70);
            this.btn_admin.Text = "Administration";
            this.btn_admin.Click += new System.EventHandler(this.btn_admin_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 77);
            // 
            // btn_reporting
            // 
            this.btn_reporting.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_reporting.Image = ((System.Drawing.Image)(resources.GetObject("btn_reporting.Image")));
            this.btn_reporting.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btn_reporting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_reporting.Name = "btn_reporting";
            this.btn_reporting.Size = new System.Drawing.Size(64, 74);
            this.btn_reporting.Text = "Reporting";
            this.btn_reporting.Click += new System.EventHandler(this.btn_reporting_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 77);
            // 
            // btnRecharger
            // 
            this.btnRecharger.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnRecharger.AutoSize = false;
            this.btnRecharger.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRecharger.Image = global::PATIO.Properties.Resources.actualiser;
            this.btnRecharger.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnRecharger.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRecharger.Name = "btnRecharger";
            this.btnRecharger.Size = new System.Drawing.Size(70, 70);
            this.btnRecharger.Text = "Recharger";
            this.btnRecharger.Click += new System.EventHandler(this.btnRecharger_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 77);
            // 
            // btnSite
            // 
            this.btnSite.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSite.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSite.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuXWikiPRS,
            this.MenuXWikiCAPA,
            this.MenuXWikiTechnique});
            this.btnSite.Image = global::PATIO.Properties.Resources.page_web;
            this.btnSite.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSite.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSite.Name = "btnSite";
            this.btnSite.Size = new System.Drawing.Size(86, 74);
            this.btnSite.Text = "Sites";
            this.btnSite.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // MenuXWikiPRS
            // 
            this.MenuXWikiPRS.Name = "MenuXWikiPRS";
            this.MenuXWikiPRS.Size = new System.Drawing.Size(186, 22);
            this.MenuXWikiPRS.Text = "XWiki PRS";
            this.MenuXWikiPRS.Click += new System.EventHandler(this.MenuXWikiPRS_Click);
            // 
            // MenuXWikiCAPA
            // 
            this.MenuXWikiCAPA.Name = "MenuXWikiCAPA";
            this.MenuXWikiCAPA.Size = new System.Drawing.Size(186, 22);
            this.MenuXWikiCAPA.Text = "XWiki Plans d\'actions";
            this.MenuXWikiCAPA.Click += new System.EventHandler(this.MenuXWikiCAPA_Click);
            // 
            // MenuXWikiTechnique
            // 
            this.MenuXWikiTechnique.Name = "MenuXWikiTechnique";
            this.MenuXWikiTechnique.Size = new System.Drawing.Size(186, 22);
            this.MenuXWikiTechnique.Text = "XWiki Technique";
            this.MenuXWikiTechnique.Click += new System.EventHandler(this.MenuXWikiTechnique_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 77);
            // 
            // DP
            // 
            this.DP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DP.Location = new System.Drawing.Point(0, 72);
            this.DP.Name = "DP";
            this.DP.Size = new System.Drawing.Size(800, 378);
            this.DP.TabIndex = 4;
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 60000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DP);
            this.Controls.Add(this.panelMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.Text = "Application PATIO";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.MenuPrincipal.ResumeLayout(false);
            this.MenuPrincipal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private WeifenLuo.WinFormsUI.Docking.DockPanel DP;
        private System.Windows.Forms.ToolStrip MenuPrincipal;
        private System.Windows.Forms.ToolStripButton btn_admin;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btn_reporting;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnRecharger;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.ToolStripSplitButton btnSite;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem MenuXWikiPRS;
        private System.Windows.Forms.ToolStripMenuItem MenuXWikiCAPA;
        private System.Windows.Forms.ToolStripMenuItem MenuXWikiTechnique;
    }
}

