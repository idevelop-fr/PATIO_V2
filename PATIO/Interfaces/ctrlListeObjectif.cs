using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PATIO.Classes;
using WeifenLuo.WinFormsUI.Docking;

namespace PATIO.Interfaces
{
    public partial class ctrlListeObjectif : UserControl
    {
        public PATIO.Classes.AccesNet Acces;
        public WeifenLuo.WinFormsUI.Docking.DockPanel DP;
        public Boolean Actif = false;

        public string Chemin;
        public Boolean InterfaceGestion = false;
        public Boolean Checked = false;
        public string CodeRef = "";

        public List<Objectif> ListeObjectif;
        public List<Objectif> lObj;
        public Objectif obj;

        public ctrlConsole Console;

        /// <summary>
        /// Définition de l'événement déclenché par l'enregistrement d'une fiche action
        /// </summary>
        public class evt_Modifier : EventArgs
        {
            public evt_Modifier(string s)
            {
                id = s;
            }
            private string id;

            public string ID
            {
                get { return id; }
                set { id = value; }
            }
        }

        public event EventHandler<evt_Modifier> EVT_Modifier;

        int n_obj = 0;
        //****************************************
        public ctrlListeObjectif()
        {
            InitializeComponent();
            Initialiser();
        }

        void Initialiser()
        {
            imageList1.Images.Add(PATIO.Properties.Resources.suivant);
            imageList1.Images.Add(PATIO.Properties.Resources.dossier_plus);
            imageList1.Images.Add(PATIO.Properties.Resources.btn_losange_bleu);
            imageList1.Images.Add(PATIO.Properties.Resources.btn_losange_orange);
            imageList1.Images.Add(PATIO.Properties.Resources.btn_losange_rouge);
            imageList1.Images.Add(PATIO.Properties.Resources.btn_losange_vert);
        }

        public void Afficher_ListeObjectif()
        {
            List<int> liste = new List<int>();

            lstObjectif.Nodes.Clear();
            lstObjectif.CheckBoxes = Checked;

            //Recherche de la liste des Objectifs
            ListeObjectif = (List<Objectif>) Acces.Remplir_ListeElement(Acces.type_OBJECTIF.id, "");

            ListeObjectif.Sort();
            int n = 0;

            foreach (var p in ListeObjectif)
            {
                //Recherche de la présence de l'item dans l'arbre
                TreeNode T = new TreeNode(p.Libelle);
                T.Name = p.ID.ToString();
                T.ForeColor = (p.Actif) ? Color.Black : Color.Red;
                T.ImageIndex =Donner_IndexImage(p.TypeObjectif);
                T.ToolTipText = p.Code + " (" + p.ID + ")";
                //T.Tag = Acces.type_OBJECTIF.id;
                string txt = lblRecherche.Text.Trim().ToUpper();
                if (txt.Length > 0)
                {
                    if (p.Libelle.ToUpper().Contains(txt) || p.Code.ToUpper().Contains(txt))
                    {
                        lstObjectif.Nodes.Add(T);
                        liste.Add(p.ID);
                        n++;
                    }
                }
                else
                {
                    lstObjectif.Nodes.Add(T);
                    liste.Add(p.ID);
                    n++;
                }
            }

            lblNb.Text = "Nb : " + n.ToString();
            //Inversion de la liste des objectifs
            //liste.Reverse();
            //Repositionnement des éléments selon la hiérarchie
            Repositionner();
        }

        void Repositionner()
        { 
            //Placement des objectifs/sous-objectifs
            List<Lien> ListeLienSysteme = Acces.Remplir_ListeLienSYSTEME(Acces.type_OBJECTIF);

            //On balaye la liste des Objectifs
            //Si un lien existe,
            //on recherche la position des 2 objectifs
            //On déplace le fils sous le parent
            foreach (Lien p in ListeLienSysteme)
            {
                TreeNode[] Nod1 = lstObjectif.Nodes.Find(p.element1_id.ToString(), true);
                TreeNode[] Nod2 = lstObjectif.Nodes.Find(p.element2_id.ToString(), true);

                if (Nod1.Count() > 0 && Nod2.Count() > 0)
                {
                    TreeNode parent = Nod1[0];
                    TreeNode Element = Nod2[0];

                    Element.Tag = p;

                    //Element.Remove();
                    lstObjectif.Nodes.Remove(Element);
                    parent.Nodes.Add(Element);
                }
                else { Console.Ajouter("[Move Objectif] Erreur Lien" + p.ID); }
            }
        }

        int Donner_IndexImage(TypeObjectif t)
        {
            if (t == TypeObjectif.DOSSIER) { return 1; }
            if (t == TypeObjectif.AXE ) { return 2; }
            if (t == TypeObjectif.STRATEGIQUE) { return 3; }
            if (t == TypeObjectif.GENERAL) { return 4; }
            if (t == TypeObjectif.OPERATIONNEL) { return 5; }
            return 0;
        }

        private void BtnNewObjectif_Click(object sender, EventArgs e)
        {
            Ajouter_SousObjectif();
        }

        void Ajouter_Objectif()
        {
            ctrlFicheObjectif f = new ctrlFicheObjectif();
            f.Acces = Acces;
            f.Creation = true;
            f.Console = Console;

            f.objectif  = new Objectif();
            f.objectif.Code = "OBJ_PA" + ((lblRecherche.Text.Length > 0) ? lblRecherche.Text : "") ;
            f.objectif.Actif = true;
            f.objectifParent = null;
            n_obj++;
            f.Tag = Acces.type_OBJECTIF.id + n_obj;
            f.EVT_Enregistrer += Handler_evt_Modifier;

            f.Initialiser();

            var D = new WeifenLuo.WinFormsUI.Docking.DockContent();
            D.TabText = "Objectif (Nouveau)";

            f.Dock = DockStyle.Fill;
            D.Controls.Add(f);

            D.Show(DP, WeifenLuo.WinFormsUI.Docking.DockState.Document);
        }

        void Handler_evt_Modifier(object sender, ctrlFicheObjectif.evt_Enregistrer e)
        {
            Afficher_ListeObjectif();

            //Actualise le titre de l'onglet
            WeifenLuo.WinFormsUI.Docking.DockContent d = (WeifenLuo.WinFormsUI.Docking.DockContent) DP.ActiveDocument;
            ctrlFicheObjectif f;
            try { f = (ctrlFicheObjectif)d.Controls[0]; } catch { f = null; }
            if(f!= null)
            {
                if (f.Tag.ToString() == e.ID.ToString())
                {
                    d.TabText = f.objectif.Code;
                    this.Tag = e.ID.ToString();
                }
            }

            try
            {
                TreeNode[] nd = lstObjectif.Nodes.Find(f.objectif.ID.ToString(), true);
                if (nd.Length > 0) { nd[0].Parent.Expand(); lstObjectif.SelectedNode = nd[0].Parent ; }
            } catch { }
            //Active l'événement our une remontée avec des éléments de hiérarchie plus haute
            OnRaise_Evt_Modifier(new evt_Modifier(n_obj.ToString()));
        }

        void Ajouter_SousObjectif()
        {
            string code = CodeRef;

            if (lstObjectif.SelectedNode is null)
            {
                MessageBox.Show("Vous devez choisir un objectif parent");
                return;
            }

            int id = int.Parse(lstObjectif.SelectedNode.Name);
            Objectif obj =(Objectif) Acces.Trouver_Element(Acces.type_OBJECTIF.id, id);
            code = obj.Code;

            ctrlFicheObjectif f = new ctrlFicheObjectif();
            f.Acces = Acces;
            f.Creation = true;
            f.objectif = new Objectif();
            f.objectif.Code =  code;
            f.objectif.Actif = true;
            f.objectifParent = (Objectif)Acces.Trouver_Element(Acces.type_OBJECTIF.id, int.Parse(lstObjectif.SelectedNode.Name)); ;

            n_obj++;
            f.Tag = Acces.type_OBJECTIF.code + n_obj;
            f.EVT_Enregistrer += Handler_evt_Modifier;

            f.Initialiser();

            var D = new WeifenLuo.WinFormsUI.Docking.DockContent();
            D.TabText = "Objectif (Nouveau)";

            f.Dock = DockStyle.Fill;
            D.Controls.Add(f);

            D.Show(DP, WeifenLuo.WinFormsUI.Docking.DockState.Document);
        }

        private void BtnSupprimerObjectif_Click(object sender, EventArgs e)
        {
            Supprimer_Objectif();
        }

        void Supprimer_Objectif()
        {
            if (lstObjectif.SelectedNode != null)
            {
                var Id = Int32.Parse(lstObjectif.SelectedNode.Name);
                Acces.Supprimer_Element(Acces.type_OBJECTIF, Acces.Trouver_Element(Acces.type_OBJECTIF.id,Id));

                lstObjectif.Nodes.Remove(lstObjectif.SelectedNode);
                OnRaise_Evt_Modifier(new evt_Modifier(""));
            }
        }

        private void BtnModifierObjectif_Click(object sender, EventArgs e)
        {
            Modifier_Objectif();
        }

        public void Modifier_Objectif()
        {
            if (obj == null) { return; }

            ctrlFicheObjectif f = new ctrlFicheObjectif();
            f.Acces = Acces;
            f.Creation = false;
            f.Console = Console;

            var Id = obj.ID;

            Objectif P =(Objectif) Acces.Trouver_Element(Acces.type_OBJECTIF.id, Id);

            f.objectif = P;
            n_obj++;
            f.Tag = Acces.type_OBJECTIF.id + n_obj;
            f.EVT_Enregistrer += Handler_evt_Modifier;

            f.Initialiser();
            f.Dock = DockStyle.Fill;

            var D = new WeifenLuo.WinFormsUI.Docking.DockContent();
            D.TabText = "Objectif " + P.Code;

            f.Dock = DockStyle.Fill;
            D.Controls.Add(f);
            D.Tag = obj.Code;

            //Recherche si la fiche élément n'est pas ouverte
            foreach (DockContent d in DP.Documents)
            {
                if (d.Tag == D.Tag) { d.Show(); return; }
            }
            D.Show(DP, DockState.Document);
        }

        private void BtnDesactiverObjectif_Click(object sender, EventArgs e)
        {
            Desactiver_Objectif();
        }

        void Desactiver_Objectif()
        {
            if (lstObjectif.SelectedNode != null)
            {
                var Id = Int32.Parse(lstObjectif.SelectedNode.Name);
                Acces.Modifier_Element(Acces.type_OBJECTIF, Id, false);

                Objectif obj = (Objectif)Acces.Trouver_Element(Acces.type_OBJECTIF.id, Id);
                lstObjectif.SelectedNode.ForeColor = (obj.Actif) ? Color.Black : Color.Red;

                //AfficheListeObjectif();
            }
        }

        private void lstObjectif_DoubleClick(object sender, EventArgs e)
        {
            Modifier_Objectif();
        }

        private void BtnActualiserObjectif_Click(object sender, EventArgs e)
        {
            Afficher_ListeObjectif();
        }

        private void lblRecherche_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Return)
            {
                Afficher_ListeObjectif();
            }
        }

        private void lstObjectif_MouseDown(object sender, MouseEventArgs e)
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

        private void lstObjectif_DragOver(object sender, DragEventArgs e)
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

        private void lstObjectif_DragDrop(object sender, DragEventArgs e)
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

            if (NodDest == nodSrc) { return; }//Système anti-bouclage

            //Prise en compte du changement en base
            //Recherche d'un lien du NodSrc
            if (!(nodSrc.Tag is null))
            {
                Lien k = Acces.Donner_LienParent(((Lien)nodSrc.Tag).ID);
                Acces.Supprimer_Lien(k);
            }

            //Création du lien
            Lien p = new Lien() { Acces = Acces };
            p.element1_type = Acces.type_OBJECTIF.id;
            p.element1_id = int.Parse(NodDest.Name);
            p.element1_code = ((Objectif)Acces.Trouver_Element(Acces.type_OBJECTIF.id, p.element1_id)).Code;
            p.element2_type = Acces.type_OBJECTIF.id;
            p.element2_id = int.Parse(nodSrc.Name);
            p.element2_code = ((Objectif)Acces.Trouver_Element(Acces.type_OBJECTIF.id, p.element2_id)).Code;
            p.element0_type = Acces.type_PLAN.id; //SYSTEME
            p.element0_id = 1; //SYSTEME
            p.element0_code = "SYSTEME"; //SYSTEME
            p.ordre = p.Donner_Ordre() + 1;

            p.Ajouter();
            Acces.Ajouter_Lien(p);

            TreeNode nd = new TreeNode();
            nd = (TreeNode)nodSrc.Clone();
            NodDest.Nodes.Add(nd);
            lstObjectif.SelectedNode = nd;

            TreeNode[] Nods = lstObjectif.Nodes.Find(nodSrc.Name.ToString(), true);

            try { Nods[0].Remove(); } catch { }
        }
            void Importer()
        {
            /*
            //Objet de gestion des données
            lObjectif lobj = new lObjectif();
            lobj.Acces = Acces;
            lLien llien = new lLien();
            llien.Acces = Acces;

            //fenêtre de dialogue
            OpenFileDialog f = new OpenFileDialog();
            f.Title = "Importer un fichier d'objectifs";
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

                    Objectif a = new Objectif();
                    a.Code = code;
                    a.Libelle = Libelle;

                    if (lobj.ExisteCode(code))
                    { existe++; }
                    else
                    {
                        lobj.Ajouter(a);

                        if (Parent.Length > 0)
                        {
                            //Création du lien
                            lObjectif lrecherche = new lObjectif();
                            lrecherche.Acces = Acces;
                            lrecherche.ChargeCode(Parent);
                            if (lrecherche.Liste.Count > 0)
                            {
                                Lien l = new Lien() { Acces = Acces };
                                l.element1_type =Acces.type_OBJECTIF.id;
                                l.element1_id = lrecherche.Liste[0].ID;
                                l.element1_code = lrecherche.Liste[0].Code;
                                l.element2_type =Acces.type_OBJECTIF.id;
                                l.element2_id = a.ID;
                                l.element2_code = a.Code;
                                l.element0_type = Acces.type_PLAN.id; //SYSTEM
                                l.element0_id = 1; //SYSTEM
                                l.element0_code = "SYSTEME"; //SYSTEM
                                l.ordre =l.DonneOrdre() + 1; //SYSTEM
                                l.Enregistrer();
                            }
                            else { pb++; MessageBox.Show("Code " + Parent + " non trouvé", "Problème", MessageBoxButtons.OK); }
                        }
                        k++;
                    }
                }


                wb.Close();
                wk.Close();

                MessageBox.Show(k + " objectif(s) ajouté(s), " + existe + " existant(s)," + pb + " problème(s)", "Traitement terminé", MessageBoxButtons.OK);
                AfficheListeObjectif();
            }*/
        }

        private void MenuImporter_Click(object sender, EventArgs e)
        {
            Importer();
        }

        public void Trouver_Selection()
        {
            lObj = new List<Objectif>();
            foreach (TreeNode n in lstObjectif.Nodes)
            {
                if(n.Checked) { lObj.Add((Objectif) Acces.Trouver_Element(Acces.type_OBJECTIF.id,  int.Parse(n.Name))); }
                Explorer(n);
            }
        }

        void Explorer(TreeNode nod)
        {
            foreach(TreeNode n in nod.Nodes)
            {
                if (n.Checked) { lObj.Add((Objectif)Acces.Trouver_Element(Acces.type_OBJECTIF.id, int.Parse(n.Name))); }
                if (n.Nodes.Count > 0) { Explorer(n); }
            }
        }

        private void lstObjectif_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int id = int.Parse(lstObjectif.SelectedNode.Name);

            obj=(Objectif) Acces.Trouver_Element(Acces.type_OBJECTIF.id, id);
        }

        private void btnCreerObjectif_Click(object sender, EventArgs e)
        {
            Ajouter_Objectif();
        }

        /// <summary>
        /// Déclenchement de l'événement indiquant un enregistrement d'une fiche
        /// </summary>
        protected virtual void OnRaise_Evt_Modifier(evt_Modifier e)
        {
            EventHandler<evt_Modifier> handler = EVT_Modifier;

            if (handler != null)
            {
                e.ID = this.Tag.ToString();
                handler(this, e);
            }
        }
    }
}
