using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PATIO.Classes;

namespace PATIO.Interfaces
{
    public partial class frmTableValeur : Form
    {
        public frmTableValeur()
        {
            InitializeComponent();
        }
        public AccesNet Acces;
        public WeifenLuo.WinFormsUI.Docking.DockPanel DP;
        public string Chemin;

        public int ID=0;
        public ctrlConsole Console;

        public table_valeur tv = new table_valeur();

        public void Initialiser()
        {
            Afficher_ListeNom();
            if (ID > 0)
            {
                tv = Acces.Trouver_TableValeur(ID);

                lstNom.Text = tv.Nom;
                lblCode.Text = tv.Code;
                lblCodeTV.Text = tv.Code;
                lblValeur.Text = tv.Valeur;
                lblValeur6PO.Text = tv.Valeur6PO;
            }
        }

        void Afficher_ListeNom()
        {
            lstNom.Items.Clear();

            List<string> Liste = Acces.Remplir_ListeTableValeurNom();
            foreach(string s in Liste)
            {
                lstNom.Items.Add(s);
            }
        }

        void Valider()
        {
            string Code = lblCodeTV.Text.Trim();
            string Nom = lstNom.Text.Trim();
            string Valeur = lblValeur.Text.Trim();
            string Valeur6PO = lblValeur6PO.Text.Trim();

            if (Nom.Length == 0) { MessageBox.Show("Nom obligatoire", "Erreur"); return; }
            if (Code.Length == 0) { MessageBox.Show("Code obligatoire", "Erreur"); return; }

            if (ID > 0)
            {
                tv.Acces = Acces;

                if (tv.Exister(Nom, Code)) { MessageBox.Show("Code existant"); return; }

                tv.Code = Code;
                tv.Nom = Nom;
                tv.Valeur = Valeur;
                tv.Valeur6PO = Valeur6PO;
                tv.MettreAJour();
            }
            else
            {
                tv = new table_valeur();
                tv.Acces = Acces;

                if (tv.Exister(Nom, Code)) { MessageBox.Show("Code existant"); return; }

                tv.Code = Code;
                tv.Nom = Nom;
                tv.Valeur = Valeur ;
                tv.Valeur6PO = Valeur6PO;
                tv.Ajouter();
            }
            //Attention si correction du code impact sur dElement
            this.DialogResult = DialogResult.OK;
        }

        private void BtnValider_Click(object sender, EventArgs e)
        {
            Valider();
        }

        private void BtnAnnuler_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void lblCodeTV_TextChanged(object sender, EventArgs e)
        {
            if(ID == 0) { lblValeur6PO.Text = lblCodeTV.Text; }
        }
    }
}
