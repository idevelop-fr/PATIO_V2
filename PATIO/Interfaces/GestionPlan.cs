using System.Windows.Forms;
using PATIO.Classes;
using PATIO.Interfaces;

namespace Interfaces
{
    public partial class GestionPlan : UserControl
    {
        public AccesNet Acces;
        public WeifenLuo.WinFormsUI.Docking.DockPanel DP;
        public string Chemin;

        public ctrlConsole Console;

        public GestionPlan()
        {
            InitializeComponent();
        }

        public void Initialise()
        {
            //Charge l'ensemble des données
            AfficheListePlan();
            AfficheListeObjectif();
            AfficheListeAction();
            AfficheListeIndicateur();
            AfficheListeUser();
            AfficheListeGroupe();
        }

        private void AfficheListePlan()
        {
            tabPlan.Controls.Clear();

            var ctrllisteplan = new ctrlListePlan();

            ctrllisteplan.Acces=Acces;
            ctrllisteplan.DP = DP;
            ctrllisteplan.Console = Console;
            ctrllisteplan.Chemin = Chemin;

            ctrllisteplan.Afficher_ListePlan();

            ctrllisteplan.Dock = DockStyle.Fill;

            tabPlan.Controls.Add(ctrllisteplan);
        }

        private void AfficheListeObjectif()
        {
            tabObjectif.Controls.Clear();


            var ctrllisteobjectif = new ctrlListeObjectif();

            ctrllisteobjectif.Acces = Acces;
            ctrllisteobjectif.DP = DP;
            ctrllisteobjectif.Console = Console;
            ctrllisteobjectif.Chemin = Chemin;

            ctrllisteobjectif.Afficher_ListeObjectif();

            ctrllisteobjectif.Dock = DockStyle.Fill;

            tabObjectif.Controls.Add(ctrllisteobjectif);
        }

        private void AfficheListeAction()
        {
            tabAction.Controls.Clear();

            var ctrllisteaction = new ctrlListeAction();

            ctrllisteaction.Acces = Acces;
            ctrllisteaction.DP = DP;
            ctrllisteaction.Console = Console;
            ctrllisteaction.Chemin = Chemin;

            ctrllisteaction.Afficher_ListeAction();

            ctrllisteaction.Dock = DockStyle.Fill;

            tabAction.Controls.Add(ctrllisteaction);

        }

        private void AfficheListeIndicateur()
        {
            tabIndicateur .Controls.Clear();

            var ctrllisteindicateur = new ctrlListeIndicateur();

            ctrllisteindicateur.Acces = Acces;
            ctrllisteindicateur.DP = DP;
            ctrllisteindicateur.Console = Console;
            ctrllisteindicateur.Chemin=Chemin;

            ctrllisteindicateur.Afficher_ListeIndicateur();

            ctrllisteindicateur.Dock = DockStyle.Fill;

            tabIndicateur.Controls.Add(ctrllisteindicateur);
        }

        private void AfficheListeUser()
        {
            tabUser.Controls.Clear();

            var ctrllisteuser = new ctrlListeUtilisateur();

            ctrllisteuser.Acces = Acces;
            ctrllisteuser.DP = DP;
            ctrllisteuser.Console = Console;

            ctrllisteuser.Afficher_ListeUser();

            ctrllisteuser.Dock = DockStyle.Fill;

            tabUser.Controls.Add(ctrllisteuser);
        }

        private void AfficheListeGroupe()
        {
            tabGroupe.Controls.Clear();

            var ctrllisteGroupe = new ctrlListeGroupe();

            ctrllisteGroupe.Acces = Acces;
            ctrllisteGroupe.DP = DP;

            ctrllisteGroupe.Console = Console;

            ctrllisteGroupe.AfficheListeGroupe();

            ctrllisteGroupe.Dock = DockStyle.Fill;

            tabGroupe.Controls.Add(ctrllisteGroupe);

        }
    }
}
