using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PATIO.Classes;
using Microsoft.VisualBasic;
using PATIO.Interfaces;
using Microsoft.Office.Interop.Excel;
using WeifenLuo.WinFormsUI.Docking;

namespace PATIO.Interfaces
{
    public partial class ctrlListePlan : UserControl
    {
        public PATIO.Classes.AccesNet Acces;
        public WeifenLuo.WinFormsUI.Docking.DockPanel DP;

        public string Chemin;
        public ctrlConsole Console;

        public List<Plan> ListePlan;
        public List<Plan> lPlan;
        public Plan plan;

        /// <summary>
        /// Définition de l'événement déclenché par l'enregistrement d'une fiche action
        /// </summary>
        public class evt_Selection : EventArgs
        {
            private string id;

            public evt_Selection(string s)
            {
                id = s;
            }

            public string ID
            {
                get { return id; }
                set { id = value; }
            }
        }

        public event EventHandler<evt_Selection> EVT_Selection;

        public ctrlListePlan()
        {
            InitializeComponent();
            Initialise();
        }

        void Initialise()
        {
            imageList1.Images.Add(PATIO.Properties.Resources.suivant);
            imageList1.Images.Add(PATIO.Properties.Resources.dossier_plus);    //Dossier
            imageList1.Images.Add(PATIO.Properties.Resources.btn_carre_bleu);  //National
            imageList1.Images.Add(PATIO.Properties.Resources.btn_carre_vert);  //Régional
            imageList1.Images.Add(PATIO.Properties.Resources.btn_carre_jaune); //Territorial
            imageList1.Images.Add(PATIO.Properties.Resources.btn_carre_orange);//Local
            imageList1.Images.Add(PATIO.Properties.Resources.btn_carre_rouge); //Transverse
        }

        public void Afficher_ListePlan()
        {
            lstPlan.Nodes.Clear();
            List<int> liste = new List<int>();

            //Recherche de la liste des plans
            ListePlan = (List<Plan>) Acces.Remplir_ListeElement(Acces.type_PLAN.id, "", true);
            ListePlan.Sort();

            int n = 0;

            foreach (var p in ListePlan)
            {
                TreeNode T = new TreeNode(p.Libelle);
                T.Name = p.ID.ToString();
                T.ForeColor = (p.Actif) ? Color.Black : Color.Red;
                T.ImageIndex = Donner_IndexImage(p.TypePlan);
                T.Tag = Acces.type_PLAN.code;
                T.ToolTipText = p.Code;
                string txt = lblRecherche.Text.Trim().ToUpper();
                if (txt.Length > 0)
                {
                    if (p.Libelle.ToUpper().Contains(txt) || p.Code.ToUpper().Contains(txt))
                    {
                        lstPlan.Nodes.Add(T);
                        liste.Add(p.ID);
                        n++;
                    }
                }
                else
                {
                    lstPlan.Nodes.Add(T);
                    liste.Add(p.ID);
                    n++;
                }
            }
            lblNb.Text = "Nb : " + n.ToString();
        }

        int Donner_IndexImage(TypePlan t)
        {
            if (t == TypePlan.DOSSIER) { return 1; }
            if (t == TypePlan.NATIONAL) { return 2; }
            if (t == TypePlan.REGIONAL) { return 3; }
            if (t == TypePlan.TERRITORIAL) { return 4; }
            if (t == TypePlan.LOCAL) { return 5; }
            if (t == TypePlan.TRANSVERSE) { return 6; }
            return 0;
        }

        private void BtnNewPlan_Click(object sender, EventArgs e)
        {
            Ajouter_Plan();
        }

        void Ajouter_Plan()
        {
            var f = new frmPlan();
            f.Acces = Acces;
            f.Creation = true;

            f.plan = new Plan();
            f.plan.Actif = true;

            f.Initialiser();

            if (f.ShowDialog(this) == DialogResult.OK)
            {
                Afficher_ListePlan();

                TreeNode[] Nd = lstPlan.Nodes.Find(f.plan.ID.ToString(), true);
                if (Nd.Count() > 0) { lstPlan.SelectedNode = Nd[0]; Nd[0].EnsureVisible();  }
            }
        }

        private void BtnSupprimerPlan_Click(object sender, EventArgs e)
        {
            Supprimer_Plan();
        }

        void Supprimer_Plan()
        {
            if (lstPlan.SelectedNode != null)
            {
                var Id = Int32.Parse(lstPlan.SelectedNode.Name);
                Acces.Supprimer_Element(Acces.type_PLAN, Acces.Trouver_Element(Acces.type_PLAN.id, Id));

                lstPlan.Nodes.Remove(lstPlan.SelectedNode);
            }
        }

        private void BtnModifierPlan_Click(object sender, EventArgs e)
        {
            Modifier_Plan();
        }

        public void Modifier_Plan()
        {
            if (plan != null)
            {
                var f = new frmPlan();
                f.Acces = Acces;
                f.Creation = false;

                f.plan = plan;

                f.Initialiser();

                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    plan = f.plan;
                    try
                    {
                        lstPlan.SelectedNode.Text = plan.Libelle;
                        lstPlan.SelectedNode.ToolTipText = plan.Code;
                        lstPlan.SelectedNode.Tag = plan;
                        lstPlan.SelectedNode.ImageIndex = Donner_IndexImage(plan.TypePlan);
                    } catch { }
                }
            }
        }

        private void btnDesactiverPlan_Click(object sender, EventArgs e)
        {
            Desactiver_Plan();
        }

        void Desactiver_Plan()
        {
            if (lstPlan.SelectedNode != null)
            {
                var Id = Int32.Parse(lstPlan.SelectedNode.Name);
                Acces.Modifier_Element(Acces.type_PLAN, Id, false);
                Afficher_ListePlan();
            }
        }

        private void btnOuvrirPlan_Click(object sender, EventArgs e)
        {
            Ouvrir_Plan();
        }

        private void lstPlan_DoubleClick(object sender, EventArgs e)
        {
            Modifier_Plan();
            //Ouvrir_Plan();
        }

        private void Ouvrir_Plan()
        {
            if (lstPlan.SelectedNode is null) { return; }

            Plan plan = (Plan)Acces.Trouver_Element(Acces.type_PLAN.id, int.Parse(lstPlan.SelectedNode.Name));

            var D = new WeifenLuo.WinFormsUI.Docking.DockContent();
            D.TabText = "Plan " + plan.Code;
            //MessageBox.Show(int.Parse(lstPlan.SelectedNode.Name).ToString());

            var ctrl = new ctrlPlan();
            ctrl.Acces = Acces;
            ctrl.plan = plan;
            ctrl.DP = DP;
            ctrl.Console = Console;
            ctrl.Chemin = Chemin;
            ctrl.Afficher();

            ctrl.Dock = DockStyle.Fill;
            D.Controls.Add(ctrl);
            D.Tag = plan.Code;

            //Recherche si la fiche élément n'est pas ouverte
            foreach(DockContent d in DP.Documents)
            {
                if(d.Tag == D.Tag) { d.Show(); return; }
            }

            D.Show(DP, DockState.Document);
        }

        private void BtnActualiserPlan_Click(object sender, EventArgs e)
        {
            Afficher_ListePlan();
        }

        private void MenuImporter_Click(object sender, EventArgs e)
        {
            Importer();
        }

        void Importer()
        {
            //fenêtre de dialogue
            OpenFileDialog f = new OpenFileDialog();
            f.Title = "Importer un fichier de plans";
            f.Filter = "*.xlsx|*.xlsx";
            f.InitialDirectory = "C:\\temp\\PATIO\\Fichiers";

            if (f.ShowDialog() == DialogResult.OK)
            {
                var fichier = f.FileName;

                Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                Workbooks wk = app.Workbooks;
                Workbook wb = wk.Open(fichier);
                Worksheet ws = (Worksheet)wb.Sheets[1]; 

                string code;
                string Libelle;
                int n = 1;
                int k = 0; int existe = 0;  

                Range r = ws.Cells[1, 1];
                code = r.Value;

                //La première ligne contient les entêtes de colonnes
                while(code.Length>0)
                {
                    n++;
                    r = ws.Cells[n, 1];
                    code = r.Value;
                    if(code is null) { break; }

                    r = ws.Cells[n, 2];
                    Libelle  = r.Value;
                    if (Libelle is null) { Libelle = ""; }

                    Plan p = new Plan();
                    p.Code = code;
                    p.Libelle = Libelle;

                    if(Acces.Existe_Element(Acces.type_PLAN, "CODE", code))
                    { existe++; }
                    else
                    {
                        Acces.Ajouter_Element(Acces.type_PLAN, p);
                        k++;
                    }
                }

                wb.Close();
                wk.Close();

                MessageBox.Show(k + " plan(s) ajouté(s), " + existe + " existant(s)","Traitement terminé",MessageBoxButtons.OK);
                Afficher_ListePlan();
            }
        }

        private void MenuExporter_Click(object sender, EventArgs e)
        {
            Exporter();
        }

        void Exporter()
        {
            MessageBox.Show("Pas fait");
        }

        private void lblRecherche_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                Afficher_ListePlan();
            }
        }

        private void lstPlan_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int id = int.Parse(lstPlan.SelectedNode.Name);
            plan =(Plan) Acces.Trouver_Element(Acces.type_PLAN.id, id);

            OnRaise_Evt_Selection(new evt_Selection(id.ToString()));
        }

        private void lstPlan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(Char)Keys.Return) { Ouvrir_Plan(); }
        }

        /// <summary>
        /// Déclenchement de l'événement indiquant un enregistrement d'une fiche
        /// </summary>
        protected virtual void OnRaise_Evt_Selection(evt_Selection e)
        {
            EventHandler<evt_Selection> handler = EVT_Selection;

            if (handler != null)
            {
                //e.ID = this.Tag.ToString();
                handler(this, e);
            }
        }
    }
}
