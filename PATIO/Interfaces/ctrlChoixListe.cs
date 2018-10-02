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
    public partial class ctrlChoixListe : UserControl
    {
        public List<Parametre> ListeChoix = new List<Parametre>();
        public List<Parametre> ListeSelection = new List<Parametre>();
        public List<int> ListeSelectionId = new List<int>();

        public ctrlChoixListe()
        {
            InitializeComponent();
        }

        public void Initialiser()
        {
            lstChoix.Items.Clear();
            lstSelection.Items.Clear();
            ListeChoix = new List<Parametre>();
            ListeSelection = new List<Parametre>();
            ListeSelectionId = new List<int>();
        }

        public void Afficher_Liste()
        {
            Afficher_Liste_Choix();
            Affiche_Liste_Selection();
        }

        public void Afficher_Liste_Choix()
        {
            lstChoix.Items.Clear();
            foreach (Parametre p in ListeChoix)
            {
                if (lblRecherche.Text.Length > 0)
                {
                    if(p.Valeur.ToUpper().Contains(lblRecherche.Text.Trim().ToUpper()))
                    {
                        lstChoix.Items.Add(p.Valeur);
                    }
                }
                else
                {
                    lstChoix.Items.Add(p.Valeur);
                }
            }
        }

        void Affiche_Liste_Selection()
        {
            foreach (Parametre p in ListeSelection)
            {
                lstSelection.Items.Add(p.Valeur);
                ListeSelectionId.Add(p.ID);
                //Suppression de la liste des choix
                for (int i = 0; i < lstChoix.Items.Count; i++)
                {
                    if (lstChoix.Items[i].ToString() == p.Valeur)
                    { lstChoix.Items.Remove(lstChoix.Items[i]); break; }
                }
            }
        }

        private void ctrlChoixListe_Resize(object sender, EventArgs e)
        {
            int taille = 0;

            //Redimensionne les composantes en largeur
            taille = this.Size.Width-Barre.Size.Width;
            if (taille >= 100)
            {
                groupBox1.Width = taille / 2;
                groupBox2.Width = taille / 2;
            }

            //Redimensionne les composantes en hauteur
            //taille = this.Size.Height - btnAjouter.Size.Height - btnRetirer.Size.Height - Separ.Size.Height;
            if(taille>0)
            {
                //ecart.Height = taille / 2;
            }
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            Ajouter();
        }

        void Ajouter()
        {
            if(lstChoix.SelectedItem is null) { return; }

            foreach (Parametre p in ListeChoix)
            {
                if (p.Valeur == lstChoix.SelectedItem.ToString())
                {
                    ListeSelection.Add(p);
                    ListeSelectionId.Add(p.ID);
                    ListeChoix.Remove(p);
                    break;
                }
            }

            lstSelection.Items.Add(lstChoix.SelectedItem);
            lstChoix.Items.Remove(lstChoix.SelectedItem);
        }

        private void btnRetirer_Click(object sender, EventArgs e)
        {
            Retirer();
        }

        void Retirer()
        {
            if (lstSelection.SelectedItem is null) { return; }

            foreach (Parametre p in ListeSelection)
            {
                if (p.Valeur == lstSelection.SelectedItem.ToString())
                {
                    ListeChoix.Add(p);
                    ListeSelection.Remove(p);
                    ListeSelectionId.Remove(p.ID);
                    lstChoix.Items.Add(lstSelection.SelectedItem);
                    lstSelection.Items.Remove(lstSelection.SelectedItem);
                    break;
                }
            }
        }

        private void lstChoix_DoubleClick(object sender, EventArgs e)
        {
            Ajouter();
        }

        private void lstSelection_DoubleClick(object sender, EventArgs e)
        {
            Retirer();
        }

        private void btnTout_Click(object sender, EventArgs e)
        {
            Transfèrer_Tout();
        }

        void Transfèrer_Tout()
        {
            if(lstChoix.Items.Count>0)
            {
                for(int i = lstChoix.Items.Count-1; i>=0 ;i--)
                {
                    lstChoix.SelectedIndex = i;
                    Ajouter();
                }
            }
            else
            {
                for (int i = lstSelection.Items.Count - 1; i >= 0; i--)
                {
                    lstSelection.SelectedIndex = i;
                    Retirer();
                }
            }
        }

        private void lblRecherche_TextChanged(object sender, EventArgs e)
        {
            Afficher_Liste_Choix();
        }
    }
}
