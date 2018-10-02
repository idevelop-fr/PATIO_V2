using System;
using System.Windows.Forms;
using PATIO.Classes;
using WeifenLuo.WinFormsUI.Docking;

namespace PATIO.Interfaces
{
    public partial class ctrlReporting : UserControl
    {
        public AccesNet Acces;
        public WeifenLuo.WinFormsUI.Docking.DockPanel DP;
        public string Chemin;

        public ctrlConsole Console;

        public Utilisateur user_appli;

        public ctrlReporting()
        {
            InitializeComponent();
        }

        public void Initialiser()
        {
        }

        private void btnEditionPlan_Click(object sender, EventArgs e)
        {
            Afficher_EditionPlan();
        }

        void Afficher_EditionPlan()
        {
            DockContent D1 = new DockContent();

            ctrlEditionPlan ctrl = new ctrlEditionPlan();
            ctrl.Acces = Acces;
            ctrl.DP = DP;
            ctrl.Dock = DockStyle.Fill;
            ctrl.Console = Console;
            ctrl.Chemin = Chemin;
            ctrl.Initialiser();
            D1.Controls.Add(ctrl);

            D1.Show(DP, DockState.Document);
            D1.Text = "Edition par plan";
            D1.ShowInTaskbar = false;
            D1.CloseButton = true;
        }

        void Afficher_EditionDirection()
        {
            DockContent D1 = new DockContent();

            ctrlEditionDirection ctrl = new ctrlEditionDirection();
            ctrl.Acces = Acces;
            ctrl.DP = DP;
            ctrl.Dock = DockStyle.Fill;
            ctrl.Console = Console;
            ctrl.Chemin = Chemin;
            ctrl.Initialiser();
            D1.Controls.Add(ctrl);

            D1.Show(DP, DockState.Document);
            D1.Text = "Edition par direction";
            D1.ShowInTaskbar = false;
            D1.CloseButton = true;
        }

        void Afficher_EditionTerritoire()
        {
            DockContent D1 = new DockContent();

            ctrlEditionTerritoire ctrl = new ctrlEditionTerritoire();
            ctrl.Acces = Acces;
            ctrl.DP = DP;
            ctrl.Dock = DockStyle.Fill;
            ctrl.Console = Console;
            ctrl.Chemin = Chemin;
            ctrl.Initialiser();
            D1.Controls.Add(ctrl);

            D1.Show(DP, DockState.Document);
            D1.Text = "Edition par territoire";
            D1.ShowInTaskbar = false;
            D1.CloseButton = true;
        }

        void Afficher_EditionStat()
        {
            DockContent D1 = new DockContent();

            ctrlEditionStat ctrl = new ctrlEditionStat();
            ctrl.Acces = Acces;
            ctrl.DP = DP;
            ctrl.Dock = DockStyle.Fill;
            ctrl.Console = Console;
            ctrl.Chemin = Chemin;
            ctrl.Initialiser();
            D1.Controls.Add(ctrl);

            D1.Show(DP, DockState.Document);
            D1.Text = "Edition des statistiques";
            D1.ShowInTaskbar = false;
            D1.CloseButton = true;
        }

        private void btnEditionTerritoire_Click(object sender, EventArgs e)
        {
            Afficher_EditionTerritoire();
        }

        private void btnEditionStat_Click(object sender, EventArgs e)
        {
            Afficher_EditionStat();
        }

        private void btnEditionDirection_Click(object sender, EventArgs e)
        {
            Afficher_EditionDirection();
        }
    }
}
