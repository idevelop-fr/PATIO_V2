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
    public partial class ctrlAdminParam : UserControl
    {
        public PATIO.Classes.AccesNet Acces;
        public WeifenLuo.WinFormsUI.Docking.DockPanel DP;
        public string Chemin;

        public ctrlConsole Console;

        List<table_valeur> listeTypeElement;

        public ctrlAdminParam()
        {
            InitializeComponent();
        }

        public void Initialiser()
        {
            Afficher_ListeAttribut();
            Afficher_ListeTV();
            Afficher_ListeParam();

            Afficher_ListeElement();
        }

        void Afficher_ListeElement()
        {
            lstElement.Items.Clear();

            listeTypeElement = Acces.Remplir_ListeTableValeur("TYPE_ELEMENT");

            foreach (var t in listeTypeElement)
            {
                lstElement.Items.Add(t.Code);
            }
        }

        void Afficher_ListeAttribut()
        {
            Acces.Charger_ListeAttribut();
            DG_Attribut.DataSource = Acces.ListeAttribut;
            DG_Attribut.Columns["ID"].Visible = false;

            //Filtre par raport à la zone de recherche
            string recherche = lblRechercheAttribut.Text.Trim().ToUpper();
            if (recherche.Length > 0)
            {
                try
                {
                    for (int k = 0; k < DG_Attribut.Rows.Count; k++)
                    {
                        DG_Attribut.Rows[k].Visible =
                            DG_Attribut.Rows[k].Cells["Libelle"].Value.ToString().ToUpper().Contains(recherche)
                            || DG_Attribut.Rows[k].Cells["Code"].Value.ToString().ToUpper().Contains(recherche);
                    }
                } catch { }
            }

            if (!(lstElement.SelectedIndex<0))
            {
                for (int k = 0; k < DG_Attribut.Rows.Count; k++)
                {
                    try
                    {
                        DG_Attribut.Rows[k].Visible =
                           (DG_Attribut.Rows[k].Cells["element_type"].Value.ToString() == listeTypeElement[lstElement.SelectedIndex].ID.ToString());
                    } catch { }
                }
            }

            for (int k=0;k < DG_Attribut.Columns.Count; k++)
            {
                DG_Attribut.Columns[k].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        void Afficher_ListeParam()
        {
            Acces.Charger_ListeParametre();
            DG_Param.DataSource = Acces.ListeParametre;
            DG_Param.Columns["ID"].Visible = false;

            //Filtre par raport à la zone de recherche
            string recherche = lblRechercheParam.Text.Trim().ToUpper();
            if (recherche.Length > 0)
            {
                for (int k = 0; k < DG_Param.Rows.Count; k++)
                {
                    DG_Param.Rows[k].Visible = DG_Param.Rows[k].Cells["nom"].Value.ToString().ToUpper().Contains(recherche)
                        || DG_Param.Rows[k].Cells["code"].Value.ToString().ToUpper().Contains(recherche);
                }
            }

            for (int k = 0; k < DG_Param.Columns.Count; k++)
            {
                DG_Param.Columns[k].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        void Afficher_ListeTV()
        {
            DG_TV.DataSource = null;
            Acces.Charger_ListeTableValeur();
            DG_TV.DataSource = Acces.ListeTableValeur;
            DG_TV.Columns["ID"].Visible = false;

            //Filtre par raport à la zone de recherche
            string recherche = lblRechercheTV.Text.Trim().ToUpper();
            if (recherche.Length>0)
            {
                for(int k=0;k < DG_TV.Rows.Count;k++)
                {
                    DG_TV.Rows[k].Visible = DG_TV.Rows[k].Cells["nom"].Value.ToString().ToUpper().Contains(recherche)
                        || DG_TV.Rows[k].Cells["code"].Value.ToString().ToUpper().Contains(recherche);
                }
            }

            for (int k = 0; k < DG_TV.Columns.Count; k++)
            {
                DG_TV.Columns[k].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            DG_TV.Columns["valeur"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        private void btnAjouterAttribut_Click(object sender, EventArgs e)
        {
            AjouterAttribut();
        }

        private void btnSupprimerAttribut_Click(object sender, EventArgs e)
        {
            SupprimerAttribut();
        }

        private void btnModifierAttribut_Click(object sender, EventArgs e)
        {
            ModifierAttribut();
        }

        void AjouterAttribut()
        {
            frmAttribut f = new frmAttribut();
            f.Acces = Acces;
            f.Initialiser();

            if (f.ShowDialog() == DialogResult.OK)
            {
                Afficher_ListeAttribut();
            }
        }

        void ModifierAttribut()
        {
            if (DG_Attribut.SelectedRows.Count == 0) { return; }

            frmAttribut f = new frmAttribut();
            f.Acces = Acces;
            f.ID = int.Parse(DG_Attribut.SelectedRows[0].Cells["ID"].Value.ToString());
            f.Initialiser();

            if (f.ShowDialog() == DialogResult.OK)
            {
                Afficher_ListeAttribut();
            }
        }

        void SupprimerAttribut()
        {
            if (DG_Attribut.SelectedRows.Count == 0) { return; }

            if (MessageBox.Show("Etes-vous sûr de vouloir supprimer cet attribut ?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.Yes) { return; }

            Attribut att = new Attribut();
            att.Acces = Acces;
            att.ID = int.Parse(DG_Attribut.SelectedRows[0].Cells["id"].Value.ToString());
            att.Supprimer();

            //Impact sur dElement !!!!!

            Afficher_ListeAttribut();
        }

        void AjouterTV()
        {
            frmTableValeur f = new frmTableValeur();
            f.Acces = Acces;
            f.Initialiser();

            if (f.ShowDialog() == DialogResult.OK)
            {
                Afficher_ListeTV();
            }
        }

        void ModifierTV()
        {
            if (DG_TV.SelectedRows.Count == 0) { return; }

            frmTableValeur f = new frmTableValeur();
            f.Acces = Acces;
            f.ID = int.Parse(DG_TV.SelectedRows[0].Cells["ID"].Value.ToString());
            f.Initialiser();

            if (f.ShowDialog() == DialogResult.OK)
            {
                Afficher_ListeTV();
            }
        }

        void SupprimerTV()
        {
            if (DG_TV.SelectedRows.Count == 0) { return; }

            if (MessageBox.Show("Etes-vous sûr de vouloir supprimer cet élément de table de valeur ?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.Yes) { return; }

            table_valeur tv = new table_valeur();
            tv.Acces = Acces;
            tv.ID = int.Parse(DG_TV.SelectedRows[0].Cells["id"].Value.ToString());
            tv.Supprimer();

            Afficher_ListeTV();
        }

        private void btnAjouterTV_Click(object sender, EventArgs e)
        {
            AjouterTV();
        }

        private void btnModifierTV_Click(object sender, EventArgs e)
        {
            ModifierTV();
        }

        private void btnSupprimerTV_Click(object sender, EventArgs e)
        {
            SupprimerTV();
        }

        private void btnActualiserTV_Click(object sender, EventArgs e)
        {
            Afficher_ListeTV();
        }

        private void btnActuaiserGroupe_Click(object sender, EventArgs e)
        {
            Afficher_ListeAttribut();
        }

        void AjouterParam()
        {
            frmParametre f = new frmParametre();
            f.Acces = Acces;
            f.Initialiser();

            if (f.ShowDialog() == DialogResult.OK)
            {
                Afficher_ListeParam();
            }
        }

        void ModifierParam()
        {
            if (DG_Param.SelectedRows.Count == 0) { return; }

            frmParametre f = new frmParametre();
            f.Acces = Acces;
            f.ID = int.Parse(DG_Param.SelectedRows[0].Cells["ID"].Value.ToString());
            f.Initialiser();

            if (f.ShowDialog() == DialogResult.OK)
            {
                Afficher_ListeParam();
            }
        }

        void SupprimerParam()
        {
            if (DG_Param.SelectedRows.Count == 0) { return; }

            if (MessageBox.Show("Etes-vous sûr de vouloir supprimer ce paramètre ?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.Yes) { return; }

            Parametre p = new Parametre();
            p.Acces = Acces;
            p.ID = int.Parse(DG_Param.SelectedRows[0].Cells["id"].Value.ToString());
            p.Supprimer();

            Afficher_ListeParam();
        }

        private void btnAjouterParam_Click(object sender, EventArgs e)
        {
            AjouterParam();
        }

        private void btnModifierParam_Click(object sender, EventArgs e)
        {
            ModifierParam();
        }

        private void btnsupprimerParam_Click(object sender, EventArgs e)
        {
            SupprimerParam();
        }

        private void btnActualiserParam_Click(object sender, EventArgs e)
        {
            Afficher_ListeParam();
        }

        private void lblRechercheTV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Return)
                { Afficher_ListeTV(); }
        }

        private void toolStrip2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            { Afficher_ListeParam(); }
        }

        private void toolStrip3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            { Afficher_ListeAttribut(); }
        }

        private void btnTV_CopierVers_Click(object sender, EventArgs e)
        {
            Copier_tv();
        }
        void Copier_tv()
        {
            if (DG_TV.SelectedRows.Count == 0) { return; }

            frmChoix f = new frmChoix();
            List<string> Liste = Acces.Remplir_ListeTableValeurNom();
            foreach(string l in Liste) { f.lst.Items.Add(l); }
            if (f.ShowDialog() == DialogResult.OK)
            {
                string nom = f.choix;
                nom = nom.ToUpper().Trim();
                if (nom.Length == 0) { return; }

                table_valeur tv_src = Acces.Trouver_TableValeur(int.Parse(DG_TV.SelectedRows[0].Cells["ID"].Value.ToString()));
                if (nom == tv_src.Nom) { MessageBox.Show("Table identique !"); return; }

                if(Acces.Trouver_TableValeur_Code(nom, tv_src.Code) != null)
                { MessageBox.Show("Cet élément existe déjà pour la table de destination."); return; }

                //Création du nouvel élément
                table_valeur tv_dest = new table_valeur() { Acces = Acces, };
                tv_dest.Nom = nom;
                tv_dest.Code = tv_src.Code;
                tv_dest.Valeur = tv_src.Valeur;
                tv_dest.Valeur6PO = tv_src.Valeur6PO;

                tv_dest.Ajouter();
                Afficher_ListeTV();
            }
        }

        private void lblRechercheAttribut_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (Char) Keys.Return) { Afficher_ListeAttribut(); }
        }

        private void lstElement_SelectedIndexChanged(object sender, EventArgs e)
        {
            Afficher_ListeAttribut();
        }
    }
}
