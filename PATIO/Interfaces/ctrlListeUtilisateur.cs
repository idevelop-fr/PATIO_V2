using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using PATIO.Classes;

namespace PATIO.Interfaces
{
    public partial class ctrlListeUtilisateur : UserControl
    {
        public AccesNet Acces;
        public WeifenLuo.WinFormsUI.Docking.DockPanel DP;

        public List<Utilisateur> ListeUtilisateur;
        public ctrlConsole Console;

        public int UserId;
        public string UserCode;

        public ctrlListeUtilisateur()
        {
            InitializeComponent();

            imageList1.Images.Add(PATIO.Properties.Resources.suivant);
            imageList1.Images.Add(PATIO.Properties.Resources.dossier_plus);
            imageList1.Images.Add(PATIO.Properties.Resources.Visiteur);
            imageList1.Images.Add(PATIO.Properties.Resources.Pilote);
            imageList1.Images.Add(PATIO.Properties.Resources.Administrateur);
        }

        public void Afficher_ListeUser()
        {
            lstUser.Nodes.Clear();

            //Recherche de la liste des utilisateurs
            ListeUtilisateur=(List<Utilisateur>) Acces.Remplir_ListeElement(Acces.type_UTILISATEUR.id, "");

            int n = 0;
            foreach (var p in ListeUtilisateur)
            {
                TreeNode T = new TreeNode(p.Nom + " " + p.Prenom);
                T.Name = p.ID.ToString();
                T.ForeColor = (p.Actif) ? Color.Black : Color.Red;
                T.ImageIndex = Donner_IndexImage(p.TypeUtilisateur);
                T.Tag = Acces.type_UTILISATEUR.id;
                lstUser.Nodes.Add(T);
                n++;
            }
            lblNb.Text = "Nb : " + n.ToString();
        }

        int Donner_IndexImage(TypeUtilisateur t)
        {
            if (t == TypeUtilisateur.DOSSIER) { return 1; }
            if (t == TypeUtilisateur.UTILISATEUR) { return 2; }
            if (t == TypeUtilisateur.PILOTE) { return 3; }
            if (t == TypeUtilisateur.ADMINISTRATEUR) { return 4; }
            return 0;
        }

        private void BtnNewUser_Click(object sender, EventArgs e)
        {
            Ajouter_User();
        }

        void Ajouter_User()
        {
            var f = new frmUser();
            f.Acces = Acces;
            f.Creation = true;

            f.User = new Utilisateur();
            f.User.Actif = true;

            f.Initialise();

            if (f.ShowDialog(this) == DialogResult.OK)
            {
                Afficher_ListeUser();
            }
        }

        private void BtnModifierUser_Click(object sender, EventArgs e)
        {
            Modifier_User();
        }

        void Modifier_User()
        {
            if (lstUser.SelectedNode != null)
            {
                var f = new frmUser();
                f.Acces = Acces;
                f.Creation = false;

                f.User =(Utilisateur) Acces.Trouver_Element(Acces.type_UTILISATEUR.id, int.Parse(lstUser.SelectedNode.Name));

                f.Initialise();

                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    Afficher_ListeUser();
                }
            }
        }

        private void BtnDesactiverUser_Click(object sender, EventArgs e)
        {
            Desactiver_User();
        }

        void Desactiver_User()
        {
            if (lstUser.SelectedNode != null)
            {
                var Id = Int32.Parse(lstUser.SelectedNode.Name);
                Acces.Modifier_Element(Acces.type_UTILISATEUR, Id, false);

                Afficher_ListeUser();
            }
        }

        private void BtnSupprimerUser_Click(object sender, EventArgs e)
        {
            Supprimer_User();
        }

        void Supprimer_User()
        {
            if (lstUser.SelectedNode != null)
            {
                var Id = Int32.Parse(lstUser.SelectedNode.Name);
                Utilisateur user = Acces.Trouver_Utilisateur(Id);
                Acces.Supprimer_Element(Acces.type_UTILISATEUR, user);

                Afficher_ListeUser();
            }
        }

        private void BtnActualiserUser_Click(object sender, EventArgs e)
        {
            Acces.Charger_Element();
            Acces.Charger_Lien();
            Afficher_ListeUser();
        }

        private void lstUser_MouseDown(object sender, MouseEventArgs e)
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

        private void lstUser_DragOver(object sender, DragEventArgs e)
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

        private void lstUser_DragDrop(object sender, DragEventArgs e)
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

            //Vérification du type de destination
            if (!(Acces.Trouver_Utilisateur(int.Parse(NodDest.Name.ToString())).TypeUtilisateur == TypeUtilisateur.DOSSIER))
            {
                MessageBox.Show("Un utilisateur (hors type DOSSIER) ne peut contenir d'autres utilisateurs", "Erreur", MessageBoxButtons.OK);
                return;
            }
            //Prise en compte du changement en base
            //Recherche d'un lien du NodSrc
            Lien k = Acces.Donner_LienParent(((Lien) nodSrc.Tag).ID);

            if (!(k is null)) //Suppression des liens existants pour le Prop 0 (SYSTEME)
            {
                k.Acces = Acces;
                k.Supprimer();
            }

            //Création du lien
            Lien p = new Lien();
            p.element1_type = Acces.type_UTILISATEUR.id;
            p.element1_id = int.Parse(NodDest.Name);
            p.element1_code = Acces.Trouver_Utilisateur(p.element1_id).Code;
            p.element2_type = Acces.type_UTILISATEUR.id;
            p.element1_id = int.Parse(nodSrc.Name);
            p.element2_code = Acces.Trouver_Utilisateur(p.element2_id).Code;
            p.element0_type = Acces.type_PLAN.id;
            p.element0_id = 1; //SYSTEME
            p.ordre = p.Donner_Ordre() + 1;

            if (p.element1_id == p.element2_id) { return; } //Système anti-bouclage

            p.Ajouter();

            Acces.Ajouter_Lien(p);
            Afficher_ListeUser();

            TreeNode[] Nods = lstUser.Nodes.Find(nodSrc.Name.ToString(), true);

            lstUser.SelectedNode = Nods[0];
            Nods[0].EnsureVisible();
        }

        private void lstUser_DoubleClick(object sender, EventArgs e)
        {
            Modifier_User();
        }

        private void lblRecherche_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                Afficher_ListeUser();
            }
        }
    }
}
