using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PATIO.Classes;

namespace PATIO.Interfaces
{
    public partial class ctrlAdmin : UserControl
    {
        public PATIO.Classes.AccesNet Acces;
        public WeifenLuo.WinFormsUI.Docking.DockPanel DP;
        public string Chemin;

        public ctrlConsole Console;

        public ctrlAdmin()
        {
            InitializeComponent();
        }

        public void Initialiser()
        {
            Afficher_OngletUtilisateurs();
            Afficher_OngletExport();
            Afficher_OngletImport();
            Afficher_OngletImportXWiki();
            Afficher_OngletParametre();
            Afficher_FichierLog();
            Afficher_OngletCorrectifs();
        }

        void Afficher_OngletUtilisateurs()
        {
            tabUser.Controls.Clear();
            Interfaces.ctrlListeUtilisateur ctrl = new Interfaces.ctrlListeUtilisateur();
            ctrl.Acces = Acces;
            ctrl.DP = DP;
            ctrl.Dock = DockStyle.Fill;
            ctrl.Afficher_ListeUser();
            tabUser.Controls.Add(ctrl);
        }

        void Afficher_OngletExport()
        {
            tabExport.Controls.Clear();
            Interfaces.ctrlExport  ctrl = new Interfaces.ctrlExport();
            ctrl.Acces = Acces;
            ctrl.DP = DP;
            ctrl.Dock = DockStyle.Fill;
            ctrl.Initialise();
            tabExport.Controls.Add(ctrl);
        }

        void Afficher_OngletImport()
        {
            tabImport.Controls.Clear();
            Interfaces.ctrlImport  ctrl = new Interfaces.ctrlImport();
            ctrl.Acces = Acces;
            ctrl.DP = DP;
            ctrl.Chemin = Chemin;
            ctrl.Dock = DockStyle.Fill;
            ctrl.Initialise();
            tabImport.Controls.Add(ctrl);
        }

        void Afficher_OngletImportXWiki()
        {
            tabXWiki.Controls.Clear();
            Interfaces.ctrlXWiki ctrl = new Interfaces.ctrlXWiki();
            ctrl.Acces = Acces;
            ctrl.DP = DP;
            ctrl.Dock = DockStyle.Fill;
            ctrl.Console = Console;
            ctrl.Chemin = Chemin;
            ctrl.Initialise();
            tabXWiki.Controls.Add(ctrl);
        }

        void Afficher_OngletParametre()
        {
            tabParametre.Controls.Clear();
            Interfaces.ctrlAdminParam ctrl = new Interfaces.ctrlAdminParam();
            ctrl.Acces = Acces;
            ctrl.DP = DP;
            ctrl.Chemin = Chemin;
            ctrl.Dock = DockStyle.Fill;
            ctrl.Initialiser();
            tabParametre.Controls.Add(ctrl);
        }

        private void btnActualiserFichierLog_Click(object sender, EventArgs e)
        {
            Afficher_FichierLog();
        }

        void Afficher_FichierLog()
        {
            try
            { string txt = System.IO.File.ReadAllText(Chemin + "\\log.txt");
                lblFichierLog.Text = txt; }
            catch { }
        }

        void Afficher_OngletCorrectifs()
        {
            tabCorrectif.Controls.Clear();
            Interfaces.ctrlCorrectif ctrl = new Interfaces.ctrlCorrectif();
            ctrl.Acces = Acces;
            ctrl.DP = DP;
            ctrl.Dock = DockStyle.Fill;
            ctrl.Console = Console;
            ctrl.Initialiser();
            tabCorrectif.Controls.Add(ctrl);
        }
    }
}
