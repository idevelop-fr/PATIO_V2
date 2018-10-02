using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PATIO.Classes;
using PATIO.Modules;

namespace PATIO.Interfaces
{
    public partial class frmGroupe : Form
    {
        public frmGroupe()
        {
            InitializeComponent();
        }

        public PATIO.Classes.Groupe groupe;
        public PATIO.Classes.AccesNet Acces;
        public Boolean Creation = false;
        public int PropId;

        string[] listeTypeGroupe;

        Fonctions fonc = new Fonctions();

        public void Initialise()
        {
            lblLibelleGroupe.Text = groupe.Libelle;
            lblCodeGroupe.Text = groupe.Code;
            OptActiveGroupe.Checked = groupe.Actif;

            AfficheTypeGroupe();
            lstTypeGroupe.SelectedIndex = lstTypeGroupe.Items.IndexOf(groupe.TypeGroupe.ToString());
        }

        void AfficheTypeGroupe()
        {
            lstTypeGroupe.Items.Clear();

            listeTypeGroupe = Enum.GetNames(typeof(TypeGroupe));

            foreach (var t in listeTypeGroupe)
            {
                lstTypeGroupe.Items.Add(t);
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
            var LibGroupe = lblLibelleGroupe.Text.Trim();
            var CodeGroupe = lblCodeGroupe.Text.Trim().ToUpper();
            var OptActive = OptActiveGroupe.Checked;
            var TypeGroupe = (TypeGroupe)lstTypeGroupe.SelectedIndex;


            if (LibGroupe.Length == 0)
            {
                MessageBox.Show("Libellé du groupe obligatoire", "Erreur", MessageBoxButtons.OK);
                return;
            }

            if (CodeGroupe.Length == 0)
            {
                MessageBox.Show("Code du groupe obligatoire", "Erreur", MessageBoxButtons.OK);
                return;
            }

            bool ok = false;
            if (Creation) { ok = Acces.Existe_Element(Acces.type_GROUPE, "CODE", CodeGroupe); }
            else {
                //ok = fonc.ExisteCode(Acces.type_INDICATEUR.id, CodeGroupe, groupe.ID);
            }

            if (ok) { MessageBox.Show("Pb avec le code", "Erreur", MessageBoxButtons.OK); return; }

            groupe.Libelle = LibGroupe;
            groupe.Code = CodeGroupe;
            groupe.Actif = OptActive;
            groupe.TypeGroupe = TypeGroupe;

            if (Creation)
            {
                if (!(Acces.Existe_Element(Acces.type_GROUPE, "CODE", CodeGroupe))) { Acces.Enregistrer(Acces.type_GROUPE, groupe); }
            }
            else
            {
                Acces.Enregistrer(Acces.type_GROUPE, groupe);
            }

            this.DialogResult = DialogResult.OK;
        }
    }
}
