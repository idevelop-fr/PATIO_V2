using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PATIO.Classes;

namespace PATIO.Interfaces
{
    public partial class frmAttribut : Form
    {
        public AccesNet Acces;
        public WeifenLuo.WinFormsUI.Docking.DockPanel DP;
        public string Chemin;

        public int ID;
        public ctrlConsole Console;

        public Attribut attribut = new Attribut();
        List<table_valeur> listeTypeElement;

        public frmAttribut()
        {
            InitializeComponent();
        }

        public void Initialiser()
        {
            Afficher_ListeTypeElement();

            if(ID>0)
            {
                attribut = Acces.Trouver_Attribut(ID);

                lblLibelle.Text = attribut.Libelle;
                lblCode.Text = attribut.Code;
                lblCodeAttribut.Text = attribut.Code;
                lbl6PO.Text = attribut.ATT_6PO;

                int k = 0;
                foreach (table_valeur tv in listeTypeElement)
                {
                   if (tv.ID == attribut.Element_Type) { lstTypeElement.SelectedIndex = k; break; }
                    k++;
                }
            }
        }

        void Afficher_ListeTypeElement()
        {
            lstTypeElement.Items.Clear();

            listeTypeElement = Acces.Remplir_ListeTableValeur("TYPE_ELEMENT");

            foreach (var t in listeTypeElement)
            {
                lstTypeElement.Items.Add(t.Code);
            }
        }

        private void BtnAnnuler_Click(object sender, EventArgs e)
        {
            this.DialogResult= DialogResult.Cancel;
        }

        void Valider()
        {
            string Code = lblCodeAttribut.Text.Trim();
            string Libelle = lblLibelle.Text.Trim();
            string Attribut_6PO = lbl6PO.Text.Trim();
            int element_type =listeTypeElement[lstTypeElement.SelectedIndex].ID;

            if (Libelle.Length == 0) { MessageBox.Show("Libellé obligatoire", "Erreur"); return; }
            if (Code.Length == 0) { MessageBox.Show("Code obligatoire", "Erreur"); return; }

            if (ID>0)
            {
                attribut.Acces = Acces;

                if (attribut.Exister(element_type, Code)) { MessageBox.Show("Code existant"); return; }

                attribut.Code = Code;
                attribut.Libelle = Libelle;
                attribut.Element_Type = element_type;
                attribut.ATT_6PO = Attribut_6PO;
                attribut.MettreAJour();

                if(Code != lblCode.Text)
                {
                    attribut.MettreAJour_dElement(lblCode.Text);
                    if(MessageBox.Show("Mettre à jour la table de valeurs pour le nouveau code ?","Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        attribut.MettreAJour_TV(lblCode.Text);
                    }
                }
            }
            else
            {
                attribut = new Attribut();
                attribut.Acces = Acces;

                if (attribut.Exister((int)element_type, Code)) { MessageBox.Show("Code existant"); return; }

                attribut.Code = Code;
                attribut.Libelle = Libelle;
                attribut.Element_Type = (int)element_type;
                attribut.ATT_6PO = Attribut_6PO;
                attribut.Ajouter();
            }
            //Attention si correction du code impact sur dElement
            this.DialogResult = DialogResult.OK;
        }

        private void BtnValider_Click(object sender, EventArgs e)
        {
            Valider();
        }

        private void lblCodeAttribut_TextChanged(object sender, EventArgs e)
        {
            lbl6PO.Text = lblCodeAttribut.Text;
        }
    }
}
