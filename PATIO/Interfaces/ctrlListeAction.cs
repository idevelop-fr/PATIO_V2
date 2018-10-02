using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PATIO.Classes;
using WeifenLuo.WinFormsUI.Docking;

namespace PATIO.Interfaces
{
    public partial class ctrlListeAction : UserControl
    {
        /// <summary>
        /// Définition des paramètres publics
        /// </summary>
        public PATIO.Classes.AccesNet Acces;
        public WeifenLuo.WinFormsUI.Docking.DockPanel DP;
        public Plan plan;

        public string Chemin;
        public Boolean Checked = false;
        public string CodeRef = "";

        public List<PATIO.Classes.Action> ListeAction;
        public List<PATIO.Classes.Action> lAction;
        public PATIO.Classes.Action action;

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

        /// <summary>
        /// Définition des paramètres locaux
        /// </summary>
        TreeNode ndTemp = new TreeNode();
        int n_action = 0;

        /// <summary>
        /// Procédure d'initialisation standard du composant
        /// </summary>
        public ctrlListeAction()
        {
            InitializeComponent();
            Initialiser();
        }

        /// <summary>
        /// Procédure d'initialisation paramétrée du composant
        /// </summary>
        void Initialiser()
        {
            imageList1.Images.Add(PATIO.Properties.Resources.suivant);
            imageList1.Images.Add(PATIO.Properties.Resources.dossier_plus);
            imageList1.Images.Add(PATIO.Properties.Resources.btn_cercle_bleu);
            imageList1.Images.Add(PATIO.Properties.Resources.btn_cercle_vert);
        }

        /// <summary>
        /// Affichage de la liste des actions
        /// </summary>
        public void Afficher_ListeAction()
        {
            List<int> liste = new List<int>();
            lstAction.CheckBoxes = Checked;

            lstAction.Nodes.Clear();

            //Recherche de la liste des Actions
            ListeAction=(List<PATIO.Classes.Action>) Acces.Remplir_ListeElement(Acces.type_ACTION.id, "");
            ListeAction.Sort();

            string txt = lblRecherche.Text.Trim().ToUpper();
            int n = 0;
            foreach (var p in ListeAction)
            {
                TreeNode T = new TreeNode(p.Libelle);
                T.Name = p.ID.ToString();
                T.ForeColor = (p.Actif) ? Color.Black : Color.Red;
                T.ImageIndex = Donner_IndexImage(p.TypeAction);
                T.ToolTipText = p.Code + " (" + p.ID  + ")";
                if (txt.Length > 0)
                {
                    if (p.Libelle.ToUpper().Contains(txt) || p.Code.ToUpper().Contains(txt))
                    {
                        lstAction.Nodes.Add(T);
                        liste.Add(p.ID);
                        n++;
                    }
                }
                else
                {
                    lstAction.Nodes.Add(T);
                    liste.Add(p.ID);
                    n++;
                }
            }

            lblNb.Text = "Nb : " + n.ToString();

            //Repositionnement des éléments selon la hiérarchie
            Repositionner(liste);
        }

        /// <summary>
        /// Repositionnement des actions dans une hiérarchie
        /// </summary>
        void Repositionner(List<int> liste)
        {
            //Placement des objectifs/sous-objectifs
            List<Lien> ListeLienSysteme = Acces.Remplir_ListeLienSYSTEME(Acces.type_ACTION);

            //On balaye la liste des actions
            //Si un lien existe,
            //on recherche la position des 2 actions
            //On déplace le fils sous le parent
            foreach (Lien p in ListeLienSysteme)
            {
                TreeNode[] Nod1 = lstAction.Nodes.Find(p.element1_id.ToString(), true);
                TreeNode[] Nod2 = lstAction.Nodes.Find(p.element2_id.ToString(), true);

                if (Nod1.Count() > 0 && Nod2.Count() > 0)
                {
                    TreeNode parent = Nod1[0];
                    TreeNode Element = Nod2[0];

                    if(parent.Name == Element.Name) { break; }
                    Element.Tag = p;

                    //Element.Remove();
                    lstAction.Nodes.Remove(Element);
                    parent.Nodes.Add(Element);
                }
                else {
                    if (p.element0_id > 0)
                    { /*Console.Ajouter("[Move Action] Erreur Lien" + p.ID);*/ }
                    else { if (p.element0_code.Length > 0) { Console.Ajouter("[Erreur Lien Action] Id : " + p.ID); } }
                }
            }
        }

        /// <summary>
        /// Renvoie l'image associée au type d'action
        /// </summary>
        int Donner_IndexImage(TypeAction t)
        {
            if (t == TypeAction.DOSSIER) { return 1; }
            if (t == TypeAction.ACTION) { return 2; }
            if (t == TypeAction.OPERATION) { return 3; }
            return 0;
        }

        /// <summary>
        /// Procédure déclenchée lors de la création d'une action
        /// </summary>
        private void btnCréerAction_Click(object sender, EventArgs e)
        {
            Ajouter_Action();
        }

        /// <summary>
        /// Création d'une action par l'intermédiaire de la fiche action
        /// </summary>
        void Ajouter_Action()
        {
            string code = CodeRef;
            var D = new WeifenLuo.WinFormsUI.Docking.DockContent();
            D.TabText = "Action (nouvelle)";

            Console.Ajouter("[AJOUT ACTION]");
            ctrlFicheAction f = new ctrlFicheAction();
            f.Acces = Acces;
            f.Creation = true;

            f.action = new PATIO.Classes.Action();
            f.action.Code = "ACT-";
            f.action._type = "ACT";
            if (plan._ref1 != null) { f.action._codeplan = plan._ref1; }
            if (plan._os != null) { f.action._os = plan._os; }
            if (plan._og != null) { f.action._og = plan._og; }
            f.action.Actif = true;
            f.actionParent = null;
            Console.Ajouter("Code plan : " + f.action._codeplan);

            n_action++;
            f.Tag = Acces.type_ACTION.id + n_action;
            f.EVT_Enregistrer += Handler_evt_Modifier;

            f.Initialiser();

            f.Dock = DockStyle.Fill;
            D.Controls.Add(f);

            D.Show(DP, WeifenLuo.WinFormsUI.Docking.DockState.Document);
        }

        /// <summary>
        /// Procédure de création d'une sous-action
        /// Un lien est créé
        /// </summary>
        private void BtnNewAction_Click(object sender, EventArgs e)
        {
            Ajouter_SousAction();
        }

        /// <summary>
        /// Création d'une sous-action par l'intermédiaire de la fiche action
        /// </summary>
        void Ajouter_SousAction()
        {
            string code = CodeRef;
            Console.Ajouter("[AJOUT SOUS-ACTION");
            //Recherche du code du parent pour optimiser le codage des actions
            if (lstAction.SelectedNode is null)
            {
                MessageBox.Show("Vous devez sélectionner une action.", "Erreur");
                return;
            }

            ctrlFicheAction f = new ctrlFicheAction();
            f.Acces = Acces;
            f.Creation = true;
            n_action++;
            f.Tag = Acces.type_ACTION.code + n_action;
            f.EVT_Enregistrer += Handler_evt_Modifier;

            f.action = new PATIO.Classes.Action();
            //f.action.Code = "ACT-" + code;
            f.action.Actif = true;

            f.actionParent = (PATIO.Classes.Action) Acces.Trouver_Element(Acces.type_ACTION.id, int.Parse(lstAction.SelectedNode.Name));
            Console.Ajouter("Action parent : " + f.actionParent.Code);

            f.Initialiser();

            var D = new WeifenLuo.WinFormsUI.Docking.DockContent();
            D.TabText = "Action (nouvelle)";

            f.Dock = DockStyle.Fill;
            D.Controls.Add(f);

            D.Show(DP, WeifenLuo.WinFormsUI.Docking.DockState.Document);
        }

        /// <summary>
        /// Procédure de suppression d'une action ou sous-action
        /// </summary>
        private void BtnSupprimerAction_Click(object sender, EventArgs e)
        {
            SupprimerAction();
        }

        /// <summary>
        /// Suppression d'une action ou sous-action
        /// </summary>
        void SupprimerAction()
        {
            if (lstAction.SelectedNode != null)
            {
                var Id = Int32.Parse(lstAction.SelectedNode.Name);
                Acces.Supprimer_Element(Acces.type_ACTION, Acces.Trouver_Element(Acces.type_ACTION.id, Id));

                lstAction.Nodes.Remove(lstAction.SelectedNode);
            }
        }

        /// <summary>
        /// Procédure de modification d'une action ou sous-action
        /// </summary>
        private void BtnModifierAction_Click(object sender, EventArgs e)
        {
            Modifier_Action();
        }

        /// <summary>
        /// Modiication d'une action ou sous-action par l'intermédiaire de la fiche action
        /// </summary>
        public void Modifier_Action()
        {
            if (action == null) { return; }

            Console.Ajouter("[MODIFICATION ACTION]");

            var D = new WeifenLuo.WinFormsUI.Docking.DockContent();
            D.TabText = "Action " + action.Code;

            ctrlFicheAction f = new ctrlFicheAction();
            f.Acces = Acces;
            f.Creation = false;
            f.plan = plan;

            n_action++;
            f.Tag = Acces.type_ACTION.id + n_action;
            f.EVT_Enregistrer += Handler_evt_Modifier;

            f.action = action;
            f.Initialiser();

            f.Dock = DockStyle.Fill;
            D.Controls.Add(f);
            D.Tag = action.Code;

            //Recherche si la fiche élément n'est pas ouverte
            foreach (DockContent d in DP.Documents)
            {
                if (d.Tag == D.Tag) { d.Show(); return; }
            }
            D.Show(DP, DockState.Document);
        }

        /// <summary>
        /// Procédure déclenchée par double clic pour la modification d'une action ou sous-action
        /// </summary>
        private void lstAction_DoubleClick(object sender, EventArgs e)
        {
            Modifier_Action();
        }

        /// <summary>
        /// Procédure déclenchée pour l'ctualisation de la liste des actions
        /// </summary>
        private void BtnActualiserAction_Click(object sender, EventArgs e)
        {
            Afficher_ListeAction();
        }

        /// <summary>
        /// Recharge les informations et affiche la liste ds actions sous forme d'une hiérarchie
        /// </summary>
        void Actualiser()
        {
            Afficher_ListeAction();

            TreeNode[] Nod = lstAction.Nodes.Find(action.ID.ToString(), true);
            if (Nod.Length > 0) { lstAction.SelectedNode = Nod[0]; Nod[0].EnsureVisible(); }
        }

        /// <summary>
        /// Procédure déclenchée au début d'un drag and drop
        /// </summary>
        private void lstAction_MouseDown(object sender, MouseEventArgs e)
        {
            // Get the tree.
            TreeView tree = (TreeView)sender;

            // Get the node underneath the mouse.
            TreeNode node = tree.GetNodeAt(e.X, e.Y);
            tree.SelectedNode = node;

            // Start the drag-and-drop operation with a cloned copy of the node.
            if (node != null && e.Button == MouseButtons.Right)
            {
                tree.DoDragDrop(node.Clone(), DragDropEffects.Copy);
            }
        }

        /// <summary>
        /// Procédure déclenchée en cours d'un drag and drop
        /// </summary>
        private void lstAction_DragOver(object sender, DragEventArgs e)
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

        /// <summary>
        /// Procédure déclenchée en fin d'un drag and drop
        /// </summary>
        private void lstAction_DragDrop(object sender, DragEventArgs e)
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

            if(NodDest == nodSrc) { return; }//Système anti-bouclage

            //Prise en compte du changement en base
            //Recherche d'un lien du NodSrc
            if (!(nodSrc.Tag is null))
            { Acces.Supprimer_Lien((Lien)nodSrc.Tag); Console.Ajouter("Suppression du lien"); }
            else { Console.Ajouter("Pas de lien à supprimer"); }

            //Création du lien
            Lien p = new Lien() { Acces = Acces };
            p.element0_type = Acces.type_PLAN.id; //SYSTEME
            p.element0_id = 1; //SYSTEME
            p.element0_code = "SYSTEME"; //SYSTEME
            p.element1_type =Acces.type_ACTION.id;
            p.element1_id = int.Parse(NodDest.Name);
            p.element1_code = ((PATIO.Classes.Action) Acces.Trouver_Element(Acces.type_ACTION.id,p.element1_id)).Code;
            p.element2_type =Acces.type_ACTION.id;
            p.element2_id = int.Parse(nodSrc.Name);
            p.element2_code = ((PATIO.Classes.Action) Acces.Trouver_Element(Acces.type_ACTION.id,p.element2_id)).Code;
            p.ordre = p.Donner_Ordre() + 1;

            p.Ajouter();
            Acces.Ajouter_Lien(p);
            Console.Ajouter("Création du lien : " + p.ID);

            //Afficher_ListeAction();
            TreeNode nd = new TreeNode();
            nd = (TreeNode)nodSrc.Clone();
            NodDest.Nodes.Add(nd);
            lstAction.SelectedNode = nd;
            
            TreeNode[] Nods = lstAction.Nodes.Find(nodSrc.Name.ToString(), true);

            try { Nods[0].Remove(); } catch { }
        }
 
        /// <summary>
        /// Procédure déclenchée lors de la validation d'une recherche
        /// </summary>
        private void lblRecherche_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            { Afficher_ListeAction(); }
        }

        /// <summary>
        /// Procédure permettant de déterminer la liste des éléments cochés
        /// </summary>
        public void Trouver_Selection()
        {
            lAction = new List<PATIO.Classes.Action>();
            foreach (TreeNode n in lstAction.Nodes)
            {
                if (n.Checked) { lAction.Add((PATIO.Classes.Action) Acces.Trouver_Element(Acces.type_ACTION.id,int.Parse(n.Name))); }
                Explorer(n);
            }
        }

        /// <summary>
        /// Sous-procédure de recherche des éléments cochés
        /// </summary>
        void Explorer(TreeNode nod)
        {
            foreach (TreeNode n in nod.Nodes)
            {
                if (n.Checked) { lAction.Add((PATIO.Classes.Action) Acces.Trouver_Element(Acces.type_ACTION.id,int.Parse(n.Name))); }
                if (n.Nodes.Count > 0) { Explorer(n); }
            }
        }

        /// <summary>
        /// Procédure déclenchée pour la suppression d'un lien
        /// Ceci permet de ramener au niveau de base un élément mis dans une hiérarchie
        /// </summary>
        private void MenuSupprimer_Lien_Click(object sender, EventArgs e)
        {
            Supprimer_Lien();
        }

        /// <summary>
        /// Suppression du lien hiérarchique
        /// </summary>
        void Supprimer_Lien()
        {
            if(lstAction.SelectedNode is null) { return; }

            if(lstAction.SelectedNode.Parent is null) { return; }

            List<Lien> ListeLienSysteme = Acces.Remplir_ListeLienSYSTEME(Acces.type_ACTION, lstAction.SelectedNode.Parent.Name, lstAction.SelectedNode.Name);

            foreach(Lien ln in ListeLienSysteme)
            {
                ln.Acces = Acces;
                ln.Supprimer();
                Acces.Supprimer_Lien(ln);
            }

            Afficher_ListeAction();
        }

        /// <summary>
        /// Procédure déclenchée lors d'un clic sur un élément de la liste
        /// Permet de déterminer l'action sélectionnée
        /// </summary>
        private void lstAction_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int id = int.Parse(lstAction.SelectedNode.Name);

            action = (PATIO.Classes.Action) Acces.Trouver_Element(Acces.type_ACTION.id, id);
            CodeRef = action.Code;
            Console.Ajouter("[LISTE_ACTION] CodeRef =" + CodeRef);
            Console.Ajouter("[LISTE_ACTION] OS =" + action._os);
        }

        /// <summary>
        /// Réponse donnée lors d'un enregistrement dans une fiche action
        /// </summary>
        void Handler_evt_Modifier(object sender, ctrlFicheAction.evt_Enregistrer e)
        {
            Afficher_ListeAction();

            //Actualise le titre de l'onglet
            WeifenLuo.WinFormsUI.Docking.DockContent d = (WeifenLuo.WinFormsUI.Docking.DockContent)DP.ActiveDocument;
            ctrlFicheAction f;
            try { f = (ctrlFicheAction) d.Controls[0]; } catch { f = null; }
            if (f != null)
            {
                if (f.Tag.ToString() == e.ID.ToString())
                {
                    d.TabText =  f.action.Code;
                    this.Tag = e.ID.ToString();
                }
            }

            try
            {
                TreeNode[] nd = lstAction.Nodes.Find(f.action.ID.ToString(), true);
                if (nd.Length > 0) { nd[0].Parent.Expand(); lstAction.SelectedNode = nd[0].Parent; }
            } catch { }
            //Active l'événement our une remontée avec des éléments de hiérarchie plus haute
            OnRaise_Evt_Modifier(new evt_Modifier(n_action.ToString()));
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
