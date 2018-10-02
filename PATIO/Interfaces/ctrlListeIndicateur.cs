using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PATIO.Classes;
using WeifenLuo.WinFormsUI.Docking;

namespace PATIO.Interfaces
{
    public partial class ctrlListeIndicateur : UserControl
    {
        public PATIO.Classes.AccesNet Acces;
        public WeifenLuo.WinFormsUI.Docking.DockPanel DP;

        public string Chemin;

        public List<Indicateur> ListeIndicateur;
        public List<Indicateur> lIndicateur;
        public Indicateur indicateur;

        public Boolean Checked = false;
        public string CodeRef;

        public ctrlConsole Console;

        public ctrlListeIndicateur()
        {
            InitializeComponent();
            Initialiser();
        }

        void Initialiser()
        {
            imageList1.Images.Add(PATIO.Properties.Resources.suivant);
            imageList1.Images.Add(PATIO.Properties.Resources.dossier_plus);
            imageList1.Images.Add(PATIO.Properties.Resources.btn_triangle_bleu);
            imageList1.Images.Add(PATIO.Properties.Resources.btn_triangle_rouge);
            imageList1.Images.Add(PATIO.Properties.Resources.btn_triangle_vert);
        }

        public void Afficher_ListeIndicateur()
        {
            List<int> liste = new List<int>();

            lstIndicateur.Nodes.Clear();
            lstIndicateur.CheckBoxes = Checked;

            //Recherche de la liste des Indicateurs
            ListeIndicateur = (List<Indicateur>) Acces.Remplir_ListeElement(Acces.type_INDICATEUR.id, "");

            int n = 0;
            foreach (var p in ListeIndicateur)
            {
                TreeNode T = new TreeNode(p.Libelle);
                T.Name = p.ID.ToString();
                T.ForeColor = (p.Actif) ? Color.Black : Color.Red;
                T.ImageIndex = Donner_IndexImage(p.TypeIndicateur);
                T.Tag = Acces.type_INDICATEUR.id;
                T.ToolTipText = p.Code;
                string txt = lblRecherche.Text.Trim().ToUpper();
                if (txt.Length > 0)
                {
                    if (p.Libelle.ToUpper().Contains(txt) || p.Code.ToUpper().Contains(txt))
                    {
                        lstIndicateur.Nodes.Add(T);
                        liste.Add(p.ID);
                        n++;
                    }
                }
                else
                {
                    lstIndicateur.Nodes.Add(T);
                    liste.Add(p.ID);
                    n++;
                }
            }

            lblNb.Text = "Nb : " + n.ToString();
            //Inversion de la liste des indicateurs
            //liste.Reverse();
            //Repositionnement des éléments selon la hiérarchie
            Repositionner(liste);
        }

        void Repositionner(List<int> liste)
        {
            //Placement des objectifs/sous-objectifs
            List<Lien> ListeLienSysteme = Acces.Remplir_ListeLienSYSTEME(Acces.type_INDICATEUR);

            //On balaye la liste des Objectifs
            //Si un lien existe,
            //on recherche la position des 2 objectifs
            //On déplace le fils sous le parent
            foreach (Lien p in ListeLienSysteme)
            {
                TreeNode[] Nod1 = lstIndicateur.Nodes.Find(p.element1_id.ToString(), true);
                TreeNode[] Nod2 = lstIndicateur.Nodes.Find(p.element2_id.ToString(), true);

                if (Nod1.Count() > 0 && Nod2.Count() > 0)
                {
                    TreeNode parent = Nod1[0];
                    TreeNode Element = Nod2[0];

                    Element.Tag = p;

                    //Element.Remove();
                    lstIndicateur.Nodes.Remove(Element);
                    parent.Nodes.Add(Element);
                    //Console.Ajouter("[Move Indicateur] " + parent.Name + "-" + Element.Name);
                }
                else { Console.Ajouter("[Move Indicateur] Erreur Lien" + p.ID); }
            }
        }

        int Donner_IndexImage(TypeIndicateur t)
        {
            if (t == TypeIndicateur.DOSSIER) { return 1; }
            if (t == TypeIndicateur.MOYEN ) { return 2; }
            if (t == TypeIndicateur.IMPACT) { return 3; }
            if (t == TypeIndicateur.RESULTAT ) { return 4; }
            return 0;
        }

        private void BtnNewIndicateur_Click(object sender, EventArgs e)
        {
            Ajouter_Indicateur();
        }

        void Ajouter_Indicateur()
        {
            var f = new frmIndicateur();
            f.Acces = Acces;
            f.Creation = true;

            f.indicateur = new PATIO.Classes.Indicateur ();
            f.indicateur.Actif = true;

            f.Initialise();

            if (f.ShowDialog(this) == DialogResult.OK)
            {
                Afficher_ListeIndicateur();

                TreeNode[] Nod = lstIndicateur.Nodes.Find(f.indicateur.ID.ToString(), true);
                if (Nod.Length > 0)
                {
                    lstIndicateur.SelectedNode = Nod[0];
                    Nod[0].EnsureVisible();
                }
            }
        }

        private void BtnSupprimerIndicateur_Click(object sender, EventArgs e)
        {
            Supprimer_Indicateur();
        }

        void Supprimer_Indicateur()
        {
            if (lstIndicateur.SelectedNode != null)
            {
                var Id = Int32.Parse(lstIndicateur.SelectedNode.Name);
                Acces.Supprimer_Element(Acces.type_INDICATEUR, Acces.Trouver_Element(Acces.type_INDICATEUR.id, Id));

                lstIndicateur.Nodes.Remove(lstIndicateur.SelectedNode);
                //AfficheListeIndicateur();
            }
        }

        private void BtnModifierIndicateur_Click(object sender, EventArgs e)
        {
            Modifier_Indicateur();
        }

        public void Modifier_Indicateur()
        {
            if (indicateur == null) { return; }

            var f = new frmIndicateur();
            f.Acces = Acces;
            f.Creation = false;

            f.indicateur = indicateur;
            f.Initialise();

            if (f.ShowDialog(this) == DialogResult.OK)
            {
                lstIndicateur.SelectedNode.Text = indicateur.Libelle;
                lstIndicateur.SelectedNode.ToolTipText = indicateur.Code;
                lstIndicateur.SelectedNode.Tag = indicateur;
                //AfficheListeIndicateur();
            }
        }

        private void btnDesactiverIndicateur_Click(object sender, EventArgs e)
        {
            Desactiver_Indicateur();
        }

        void Desactiver_Indicateur()
        {
            if (lstIndicateur.SelectedNode != null)
            {
                var Id = Int32.Parse(lstIndicateur.SelectedNode.Name);
                Acces.Modifier_Element(Acces.type_INDICATEUR, Id, false);

                Afficher_ListeIndicateur();
            }
        }

        private void BtnOuvrirIndicateur_Click(object sender, EventArgs e)
        {
            Ouvrir_Indicateur();
        }

        private void lstIndicateur_DoubleClick(object sender, EventArgs e)
        {
            Modifier_Indicateur();
            //Ouvrir_Indicateur();
        }

        private void Ouvrir_Indicateur()
        {
            var D = new WeifenLuo.WinFormsUI.Docking.DockContent();
            D.TabText = "Indicateur " + lstIndicateur.SelectedNode.Name;

            var ctrl = new ctrlIndicateur();
            ctrl.Acces = Acces;
            ctrl.IndicateurId = lstIndicateur.SelectedNode.Name;
            ctrl.Affiche();

            ctrl.Dock = DockStyle.Fill;
            D.Controls.Add(ctrl);

            D.Show(DP, WeifenLuo.WinFormsUI.Docking.DockState.Document);
        }

        private void BtnActualiserIndicateur_Click(object sender, EventArgs e)
        {
            Afficher_ListeIndicateur();
        }

        private void lstIndicateur_MouseDown(object sender, MouseEventArgs e)
        {
            // Get the tree.
            TreeView tree = (TreeView)sender;

            // Get the node underneath the mouse.
            TreeNode node = tree.GetNodeAt(e.X, e.Y);
            tree.SelectedNode = node;

            // Start the drag-and-drop operation with a cloned copy of the node.
            if (node != null && e.Button==MouseButtons.Right)
            {
                  tree.DoDragDrop(node.Clone(), DragDropEffects.Copy);
            }
        }

        private void lstIndicateur_DragOver(object sender, DragEventArgs e)
        {
            // Get the tree.
            TreeView tree = (TreeView)sender;

            // Drag and drop denied by default.
            e.Effect = DragDropEffects.None;

            // Is it a valid format?
            if (e.Data.GetData(typeof(TreeNode)) != null)
            {
                // Get the screen point.
                System.Drawing.Point pt = new System.Drawing.Point(e.X, e.Y);

                // Convert to a point in the TreeView's coordinate system.
                pt = tree.PointToClient(pt);

                // Is the mouse over a valid node?
                TreeNode node = tree.GetNodeAt(pt);

                if (node != null)
                {
                    e.Effect = DragDropEffects.Copy;
                    tree.SelectedNode = node;
                }
            }
        }

        private void lstIndicateur_DragDrop(object sender, DragEventArgs e)
        {
            // Get the tree.
            TreeView tree = (TreeView)sender;

            // Get the screen point.
            System.Drawing.Point pt = new System.Drawing.Point(e.X, e.Y);

            // Convert to a point in the TreeView's coordinate system.
            pt = tree.PointToClient(pt);

            // Get the node underneath the mouse.
            TreeNode NodDest = tree.GetNodeAt(pt);

            TreeNode nodSrc = (TreeNode)e.Data.GetData(typeof(TreeNode));

            if(NodDest == nodSrc) { return; }

            //Vérification du type de destination
            if(!(((Indicateur) Acces.Trouver_Element(Acces.type_INDICATEUR.id, int.Parse(NodDest.Name.ToString()))).TypeIndicateur == TypeIndicateur.DOSSIER))
                {
                    MessageBox.Show("Un indicateur (hors type DOSSIER) ne peut contenir d'autres indicateurs","Erreur",MessageBoxButtons.OK);
                    return;
                }
            //Prise en compte du changement en base
            //Recherche d'un lien du NodSrc
            Lien k = Acces.Donner_LienParent( int.Parse(nodSrc.Tag.ToString()));

            if (!(k is null))
            { 
                k.Acces = Acces;
                k.Supprimer();
            }

            //Création du lien
            Lien p = new Lien() { Acces = Acces, };
            p.element1_type = Acces.type_INDICATEUR.id;
            p.element1_id = int.Parse(NodDest.Name);
            p.element1_code = ((Indicateur) Acces.Trouver_Element(Acces.type_INDICATEUR.id, p.element1_id)).Code;
            p.element2_type = Acces.type_INDICATEUR.id;
            p.element2_id = int.Parse(nodSrc.Name);
            p.element2_code = ((Indicateur)Acces.Trouver_Element(Acces.type_INDICATEUR.id, p.element2_id)).Code;
            p.element0_type = Acces.type_PLAN.id; //SYSTEME
            p.element0_id = 1; //SYSTEME
            p.element0_code = "SYSTEME"; //SYSTEME
            p.ordre = p.Donner_Ordre() + 1;

            p.Ajouter();

            Acces.Ajouter_Lien(p);

            TreeNode nd = new TreeNode();
            nd = (TreeNode)nodSrc.Clone();
            NodDest.Nodes.Add(nd);
            lstIndicateur.SelectedNode = nd;

            TreeNode[] Nods = lstIndicateur.Nodes.Find(nodSrc.Name.ToString(), true);

            try { Nods[0].Remove(); } catch { }
        }

        void Importer()
        {/*
            //Objet de gestion des données
            lIndicateur lindic = new lIndicateur();
            lindic.Acces = Acces;
            lLien llien = new lLien();
            llien.Acces = Acces;

            //fenêtre de dialogue
            OpenFileDialog f = new OpenFileDialog();
            f.Title = "Importer un fichier d'indicateurs";
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
                string Parent;
                int n = 1;
                int k = 0; int existe = 0; int pb = 0;

                Range r = ws.Cells[1, 1];
                code = r.Value;

                //La première ligne contient les entêtes de colonnes
                while (code.Length > 0)
                {
                    code = ""; Libelle = ""; Parent = "";
                    n++;
                    r = ws.Cells[n, 1];
                    code = r.Value;
                    if (code is null) { break; }

                    r = ws.Cells[n, 2];
                    Libelle = r.Value;
                    if (Libelle is null) { Libelle = ""; }

                    r = ws.Cells[n, 3];
                    Parent = r.Value;
                    if (Parent is null) { Parent = ""; } else { Parent = Parent.Trim(); }

                    Indicateur a = new Indicateur();
                    a.Code = code;
                    a.Libelle = Libelle;

                    if (lindic.ExisteCode(code))
                    { existe++; }
                    else
                    {
                        lindic.Ajouter(a);

                        if (Parent.Length > 0)
                        {
                            //Création du lien
                            lIndicateur lrecherche = new lIndicateur();
                            lrecherche.Acces = Acces;
                            lrecherche.ChargeCode(Parent);
                            if (lrecherche.Liste.Count > 0)
                            {
                                Lien l = new Lien() { Acces = Acces };
                                l.element1_type =Acces.type_INDICATEUR.id;
                                l.element1_id = lrecherche.Liste[0].ID;
                                l.element1_code = lrecherche.Liste[0].Code;
                                l.element2_type =Acces.type_INDICATEUR.id;
                                l.element2_id = a.ID;
                                l.element2_code = a.Code;
                                l.element0_type = Acces.type_PLAN.id; //SYSTEM
                                l.element0_id = 1; //SYSTEM
                                l.element0_code = "SYSTEME"; //SYSTEM
                                l.Enregistrer();
                            }
                            else { pb++; MessageBox.Show("Code " + Parent + " non trouvé", "Problème", MessageBoxButtons.OK); }
                        }
                        k++;
                    }
                }

                wb.Close();
                wk.Close();

                MessageBox.Show(k + " indicateur(s) ajouté(s), " + existe + " existant(s)," + pb + " problème(s)", "Traitement terminé", MessageBoxButtons.OK);
                AfficheListeIndicateur();
            }*/
        }

        private void MenuImporter_Click(object sender, EventArgs e)
        {
            Importer();
        }

        public void Trouver_Selection()
        {
            lIndicateur = new List<Indicateur>();
            foreach (TreeNode n in lstIndicateur.Nodes)
            {
                if (n.Checked)
                { lIndicateur.Add((Indicateur) Acces.Trouver_Element(Acces.type_INDICATEUR.id, int.Parse(n.Name))); }
                Explorer(n);
            }
        }

        void Explorer(TreeNode nod)
        {
            foreach (TreeNode n in nod.Nodes)
            {
                if (n.Checked)
                { lIndicateur.Add((Indicateur)Acces.Trouver_Element(Acces.type_INDICATEUR.id, int.Parse(n.Name))); }
                if (n.Nodes.Count > 0) { Explorer(n); }
            }
        }

        private void lstIndicateur_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int id = int.Parse(lstIndicateur.SelectedNode.Name);
            indicateur = (Indicateur) Acces.Trouver_Element(Acces.type_INDICATEUR.id, id);
        }

        private void lblRecherche_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (Char) Keys.Return) { Afficher_ListeIndicateur(); }
        }

        private void btnCreerSousObjectif_Click(object sender, EventArgs e)
        {
            AjouterSousIndicateur();
        }

        void AjouterSousIndicateur()
        {
            if (lstIndicateur.SelectedNode is null) { MessageBox.Show("Choix d'un indicateur"); return; }

            Indicateur indParent = (Indicateur)Acces.Trouver_Element(Acces.type_INDICATEUR.id, int.Parse(lstIndicateur.SelectedNode.Name.ToString()));
            if (!(indParent.TypeIndicateur == TypeIndicateur.DOSSIER))
            {
                MessageBox.Show("Impossible de créer un indicateur sous un indicateur autre qu'un type DOSSIER", "Erreur", MessageBoxButtons.OK);
                return;
            }

            var f = new frmIndicateur();
            f.Acces = Acces;
            f.Creation = true;

            f.indicateur = new PATIO.Classes.Indicateur();
            f.indicateur.Actif = true;
            f.indicateur.Code = indParent.Code;
            f.Initialise();

            if (f.ShowDialog(this) == DialogResult.OK)
            {
                if (!(lstIndicateur.SelectedNode is null))
                {
                    //Création du lien avec le parent
                    Lien l = new Lien()
                    {
                        element0_type = Acces.type_PLAN.id,
                        element0_id = 1,
                        element0_code = "SYSTEME",
                        element1_type = Acces.type_INDICATEUR.id,
                        element2_type = Acces.type_INDICATEUR.id,
                        element1_id = int.Parse(lstIndicateur.SelectedNode.Name),
                        element1_code = ((Indicateur)Acces.Trouver_Element(Acces.type_INDICATEUR.id, int.Parse(lstIndicateur.SelectedNode.Name))).Code,
                        element2_id = f.indicateur.ID,
                        element2_code = ((Indicateur)Acces.Trouver_Element(Acces.type_INDICATEUR.id, f.indicateur.ID)).Code,
                        ordre = 1,
                        Acces = Acces,
                    };
                    l.Ajouter();
                    Acces.Ajouter_Lien(l);
                }
                Afficher_ListeIndicateur();

                TreeNode[] Nod = lstIndicateur.Nodes.Find(f.indicateur.ID.ToString(), true);
                if(Nod.Length>0) { lstIndicateur.SelectedNode = Nod[0].Parent; Nod[0].EnsureVisible(); }
            }
        }

        private void btnCreerObjectif_Click(object sender, EventArgs e)
        {
            Ajouter_Indicateur();
        }
    }
}
