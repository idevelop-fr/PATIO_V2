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
    public partial class frmParametre : Form
    {
        public frmParametre()
        {
            InitializeComponent();
        }
        public AccesNet Acces;
        public WeifenLuo.WinFormsUI.Docking.DockPanel DP;
        public string Chemin;

        public int ID;
        public ctrlConsole Console;

        public Parametre param = new Parametre();

        public void Initialiser()
        {
            if (ID > 0)
            {
                param = Acces.Trouver_Parametre(ID);

                lblCode.Text = param.Code;
                lblCodeParam.Text = param.Code;
                lblValeurParam.Text = param.Valeur;
            }
        }

        void Valider()
        {
            string Code = lblCodeParam.Text.Trim();
            string Valeur = lblValeurParam.Text.Trim();

            if (Code.Length == 0) { MessageBox.Show("Code obligatoire", "Erreur"); return; }
            //if (Valeur.Length == 0) { MessageBox.Show("Valeur obligatoire", "Erreur"); return; }

            if (ID > 0)
            {
                param.Acces = Acces;

                if (param.Exister(Code)) { MessageBox.Show("Code existant"); return; }

                param.Code = Code;
                param.Valeur = Valeur;
                param.MettreAJour();
            }
            else
            {
                param = new Parametre();
                param.Acces = Acces;

                if (param.Exister(Code)) { MessageBox.Show("Code existant"); return; }

                param.Code = Code;
                param.Valeur = Valeur;
                param.Ajouter();
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
    }
}
