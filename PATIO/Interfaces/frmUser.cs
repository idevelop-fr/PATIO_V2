using System;
using System.Windows.Forms;
using PATIO.Classes;
using PATIO.Modules;


namespace PATIO.Interfaces
{
    public partial class frmUser : Form
    {
        public Utilisateur User;
        public AccesNet Acces;
        public Boolean Creation = false;

        string[] listeTypeUser;
        string[] listeTypeLicence;

        public frmUser()
        {
            InitializeComponent();
        }

        public void Initialise()
        {
            lblNomUser.Text = User.Nom;
            lblPrenomUser.Text = User.Prenom;
            lblCodeUser.Text = User.Code;
            lblMailUser.Text = User.Mail;
            OptActiveUser.Checked = User.Actif;

            AfficheTypeUser();
            lstTypeUser.SelectedIndex = lstTypeUser.Items.IndexOf(User.TypeUtilisateur.ToString());

            AfficheTypeLicence();
            lstLicenceUser.SelectedIndex = lstLicenceUser.Items.IndexOf(User.TypeLicence.ToString());

            AfficheListeDirection();
        }

        void AfficheTypeUser()
        {
            lstTypeUser.Items.Clear();

            listeTypeUser = Enum.GetNames(typeof(TypeUtilisateur));

            foreach (var t in listeTypeUser)
            {
                lstTypeUser.Items.Add(t);
            }
        }

        void AfficheTypeLicence()
        {
            lstLicenceUser.Items.Clear();

            listeTypeLicence = Enum.GetNames(typeof(TypeLicence));

            foreach (var t in listeTypeLicence)
            {
                lstLicenceUser.Items.Add(t);
            }
        }

        void AfficheListeDirection()
        {
            lstDirection.Items.Clear();
            foreach (table_valeur tv in Acces.Remplir_ListeTableValeur("DIRECTION_METIER"))
            {
                lstDirection.Items.Add(tv.Valeur);
                if (tv.ID == User.Direction)
                { lstDirection.SelectedIndex = lstDirection.Items.Count - 1; }
            }
        }

        private void BtnAnnuler_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BtnValider_Click(object sender, EventArgs e)
        {
            Valider();
        }

        void Valider()
        {
            var CodeUser = lblCodeUser.Text.Trim();
            var NomUser = lblNomUser.Text.Trim().ToUpper();
            var PrenomUser = lblPrenomUser.Text.Trim().ToUpper();
            var Mail = lblMailUser.Text.Trim();
            var OptActive = OptActiveUser.Checked;
            var TypeLicence = (TypeLicence)lstLicenceUser.SelectedIndex;
            var TypeUser = (TypeUtilisateur)lstTypeUser.SelectedIndex;

            if (CodeUser.Length == 0)
            {
                MessageBox.Show("Code d'utilisateur obligatoire", "Erreur", MessageBoxButtons.OK);
                return;
            }

            if (NomUser.Length == 0 || PrenomUser.Length==0 )
            {
                MessageBox.Show("Nom et prénom obligatoire", "Erreur", MessageBoxButtons.OK);
                return;
            }

            User.Code = CodeUser;
            User.Nom = NomUser;
            User.Prenom = PrenomUser;
            User.Mail = Mail;
            User.TypeUtilisateur = TypeUser;
            User.TypeLicence = TypeLicence;
            User.Actif = OptActive;
            User.Direction = Acces.Trouver_TableValeur_ID("DIRECTION_METIER", lstDirection.Text);

            if (Creation)
            {
                if (!(Acces.Existe_Element(Acces.type_UTILISATEUR, "CODE", CodeUser)))
                { Acces.Ajouter_Element(Acces.type_UTILISATEUR, User); }
            }
            else
            {
                Acces.Enregistrer(Acces.type_UTILISATEUR, User);
            }

            this.DialogResult = DialogResult.OK;
        }

        private void lblNomUser_TextChanged(object sender, EventArgs e)
        {
            GénéreInfo();
        }

        void GénéreInfo()
        {
            string url = lblPrenomUser.Text.ToLower().Trim() + "." + lblNomUser.Text.ToLower().Trim();
            url = url.Replace(" ","")  + "@ars.sante.fr";
            lblMailUser.Text = url;

            string id = "";
            if (lblPrenomUser.Text.Trim().Length > 0) { id = lblPrenomUser.Text.ToLower().Trim().Substring(0, 1); }
            string nom = lblNomUser.Text.ToLower().Replace(" ", "").Replace("-", "").Trim();
            id += nom;

            lblCodeUser.Text = id;
        }

        private void lblPrenomUser_TextChanged(object sender, EventArgs e)
        {
            GénéreInfo();
        }
    }
}
