using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PATIO.Classes;

namespace PATIO.Interfaces
{
    public partial class ctrlListeGroupe : UserControl
    {
        public PATIO.Classes.AccesNet Acces;
        public WeifenLuo.WinFormsUI.Docking.DockPanel DP;

        public ctrlConsole Console;

        public List<Groupe> ListeGroupe;

        public int GroupeId;
        public string GroupeCode;

        public ctrlListeGroupe()
        {
            InitializeComponent();
            Initialise();
        }

        public void Initialise()
        {
            imageList1.Images.Add(PATIO.Properties.Resources.suivant);
            imageList1.Images.Add(PATIO.Properties.Resources.dossier_plus);
            imageList1.Images.Add(PATIO.Properties.Resources.Pilote);
        }

        public void AfficheListeGroupe()
        {
            lstGroupe.Nodes.Clear();

            //Recherche de la liste des groupes
            ListeGroupe =(List<Groupe>) Acces.Remplir_ListeElement(Acces.type_GROUPE.id, "");

            int n = 0;
            foreach (var p in ListeGroupe)
            {
                TreeNode T = new TreeNode(p.Libelle);
                T.Name = p.ID.ToString();
                T.ForeColor = (p.Actif) ? Color.Black : Color.Red;
                T.ImageIndex = DonneIndexImage(p.TypeGroupe);
                T.Tag = Acces.type_GROUPE.id;
                lstGroupe.Nodes.Add(T);
                n++;
            }
            lblNb.Text = "Nb : " + n.ToString();
        }

        int DonneIndexImage(TypeGroupe t)
        {
            if (t == TypeGroupe.DOSSIER) { return 1; }
            if (t == TypeGroupe.GROUPE) { return 2; }
            return 0;
        }

        private void BtnNewUser_Click(object sender, EventArgs e)
        {
            AjouterGroupe();
        }

        void AjouterGroupe()
        {
            var f = new frmGroupe();
            f.Acces = Acces;
            f.Creation = true;

            f.groupe = new Groupe();
            f.groupe.Actif = true;

            f.Initialise();

            if (f.ShowDialog(this) == DialogResult.OK)
            {
                AfficheListeGroupe();
            }
        }

        private void BtnModifierUser_Click(object sender, EventArgs e)
        {
            ModifierGroupe();
        }

        void ModifierGroupe()
        {
            if (lstGroupe.SelectedNode != null)
            {
                var f = new frmGroupe();
                f.Acces = Acces;
                f.Creation = false;

                f.groupe = ListeGroupe.ElementAt(lstGroupe.SelectedNode.Index);

                f.Initialise();

                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    AfficheListeGroupe();
                }
            }
        }

        private void BtnDesactiverGroupe_Click(object sender, EventArgs e)
        {
            DesactiverGroupe();
        }

        void DesactiverGroupe()
        {
            if (lstGroupe.SelectedNode != null)
            {
                var Id = Int32.Parse(lstGroupe.SelectedNode.Name);
                Acces.Modifier_Element(Acces.type_GROUPE, Id, false);

                AfficheListeGroupe();
            }
        }

        private void BtnSupprimerGroupe_Click(object sender, EventArgs e)
        {
            SupprimerGroupe();
        }

        void SupprimerGroupe()
        {
            if (lstGroupe.SelectedNode != null)
            {
                var Id = Int32.Parse(lstGroupe.SelectedNode.Name);
                Acces.Supprimer_Element(Acces.type_GROUPE, Acces.Trouver_Element(Acces.type_GROUPE.id, Id));
                AfficheListeGroupe();
            }
        }

        private void BtnActualiserGroupe_Click(object sender, EventArgs e)
        {
            AfficheListeGroupe();
        }

        private void BtnOuvrirGroupe_Click(object sender, EventArgs e)
        {
            OuvrirGroupe();
        }

        private void OuvrirGroupe()
        {
            if (lstGroupe.SelectedNode is null) { return; }

            Groupe groupe =(Groupe) Acces.Trouver_Element(Acces.type_GROUPE.id, int.Parse(lstGroupe.SelectedNode.Name));
            var D = new WeifenLuo.WinFormsUI.Docking.DockContent();
            D.TabText = "Groupe " + groupe.Code;

            var ctrl = new ctrlGroupe();
            ctrl.Acces = Acces;
            ctrl.groupe = groupe;
            ctrl.DP = DP;
            ctrl.Affiche();

            ctrl.Dock = DockStyle.Fill;
            D.Controls.Add(ctrl);

            D.Show(DP, WeifenLuo.WinFormsUI.Docking.DockState.Document);
        }

        private void lstGroupe_MouseDown(object sender, MouseEventArgs e)
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

        private void lstGroupe_DragOver(object sender, DragEventArgs e)
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

        private void lstGroupe_DragDrop(object sender, DragEventArgs e)
        {
            // Get the tree.
            TreeView tree = (TreeView)sender;

            // Get the screen point.
            System.Drawing.Point pt = new System.Drawing.Point(e.X, e.Y);

            // Convert to a point in the TreeView's coordinate system.
            pt = tree.PointToClient(pt);

            // Get the node underneath the mouse.
            TreeNode NodDest = tree.GetNodeAt(pt);

            // Add a child node.
            //node.Nodes.Add((TreeNode)e.Data.GetData(typeof(TreeNode)));

            // Show the newly added node if it is not already visible.
            //node.Expand();

            TreeNode nodSrc = (TreeNode)e.Data.GetData(typeof(TreeNode));

            if (NodDest.Name == nodSrc.Name) { return; }

            //Prise en compte du changement en base
            //Recherche d'un lien du NodSrc
            Lien k = Acces.Donner_LienParent(((Lien) nodSrc.Tag).ID);

            if (!(k is null)) //Suppression des liens existants pour le Prop 0 (SYSTEME)
            {
                k.Acces = Acces;
                k.Supprimer();
            }

            //Création du lien
            Lien p = new Lien() { Acces = Acces };
            p.element1_type =Acces.type_GROUPE.id;
            p.element1_id = int.Parse(NodDest.Name);
            p.element1_code =((Indicateur) Acces.Trouver_Element(Acces.type_INDICATEUR.id,p.element1_id)).Code;
            p.element2_type =Acces.type_GROUPE.id;
            p.element2_id = int.Parse(nodSrc.Name);
            p.element2_code =((Indicateur) Acces.Trouver_Element(Acces.type_INDICATEUR.id,p.element2_id)).Code;
            p.element0_type = Acces.type_PLAN.id; //SYSTEME
            p.element0_id = 1; //SYSTEME
            p.element0_code = "SYSTEME"; //SYSTEME
            p.ordre = p.Donner_Ordre() + 1;

            if (p.element1_id == p.element2_id) { return; } //Système anti-bouclage

            p.Ajouter();
            Acces.Ajouter_Lien(p);

            AfficheListeGroupe();

            TreeNode[] Nods = lstGroupe.Nodes.Find(nodSrc.Name.ToString(), true);

            lstGroupe.SelectedNode = Nods[0];
            Nods[0].EnsureVisible();
        }
    }
}