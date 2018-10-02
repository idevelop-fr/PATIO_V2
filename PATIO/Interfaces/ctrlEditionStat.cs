using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PATIO.Classes;

namespace PATIO.Interfaces
{
    public partial class ctrlEditionStat : UserControl
    {
        public AccesNet Acces;
        public WeifenLuo.WinFormsUI.Docking.DockPanel DP;
        public string Chemin;

        public ctrlConsole Console;

        public Utilisateur user_appli;

        public ctrlEditionStat()
        {
            InitializeComponent();
        }

        public void Initialiser()
        {
            Afficher_ListeStat();
        }

        void Afficher_ListeStat()
        {
            lstStat.Items.Clear();

            lstStat.Items.Add("S01 : Nombre d'éléments par plan");
        }

        void Afficher()
        {
            if (lstStat.SelectedIndex < 0) { return; }
            string codestat = lstStat.Text.Split(':')[0].Trim();

            MessageBox.Show("En cours de développement");
        }
    }
}
