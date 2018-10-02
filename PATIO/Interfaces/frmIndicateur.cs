using System;
using System.Windows.Forms;
using PATIO.Classes;
using PATIO.Modules;

namespace PATIO.Interfaces
{
    public partial class frmIndicateur : Form
    {
        public frmIndicateur()
        {
            InitializeComponent();
        }

        public PATIO.Classes.Indicateur indicateur;
        public PATIO.Classes.AccesNet Acces;
        public Boolean Creation = false;

        Fonctions fonc = new Fonctions();

        string[] listeTypeIndicateur;

        public void Initialise()
        {
            lblLibelleIndicateur.Text = indicateur.Libelle;

            lblCodeIndicateur.Text = indicateur.Code;
            if(lblCodeIndicateur.Text.Length == 0) { lblCodeIndicateur.Text = "IND-"; }

            lblCodeIndicateur.Tag = lblCodeIndicateur.Text;

            OptActiveIndicateur.Checked = indicateur.Actif;

            AfficheTypeIndicateur();
            lstTypeIndicateur.SelectedIndex = lstTypeIndicateur.Items.IndexOf(indicateur.TypeIndicateur.ToString());
        }

        void AfficheTypeIndicateur()
        {
            lstTypeIndicateur.Items.Clear();

            listeTypeIndicateur = Enum.GetNames(typeof(TypeIndicateur));

            foreach (var t in listeTypeIndicateur)
            {
                lstTypeIndicateur.Items.Add(t);
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
            var LibIndicateur = lblLibelleIndicateur.Text.Trim();
            var CodeIndicateur = lblCodeIndicateur.Text.Trim().ToUpper();
            var OptActive = OptActiveIndicateur.Checked;
            var TypeIndicateur = (TypeIndicateur)lstTypeIndicateur.SelectedIndex;

            if (LibIndicateur.Length == 0)
            {
                MessageBox.Show("Libellé de l'indicateur obligatoire", "Erreur", MessageBoxButtons.OK);
                return;
            }

            if (CodeIndicateur.Length == 0)
            {
                MessageBox.Show("Code de l'indicateur obligatoire", "Erreur", MessageBoxButtons.OK);
                return;
            }

            indicateur.Libelle = LibIndicateur;
            indicateur.Code = CodeIndicateur;
            indicateur.TypeIndicateur = TypeIndicateur;
            indicateur.Actif = OptActive;

            if (Creation)
            {
                if (!(Acces.Existe_Element(Acces.type_INDICATEUR,"CODE", CodeIndicateur)))
                {indicateur.ID = Acces.Ajouter_Element(Acces.type_INDICATEUR, indicateur); }
            }
            else
            {
                Acces.Enregistrer(Acces.type_INDICATEUR, indicateur);

                //Test du changement de code --> Impact sur les liens
                if (lblCodeIndicateur.Text != lblCodeIndicateur.Tag.ToString())
                {
                    Lien l = new Lien() { Acces = Acces, };
                    l.MettreAJourCode(Acces.type_INDICATEUR, indicateur.ID, indicateur.Code);
                }
            }

            this.DialogResult = DialogResult.OK;
        }
    }
}
