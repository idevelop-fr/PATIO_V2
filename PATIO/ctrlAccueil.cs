using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PATIO.Classes;
using PATIO.Interfaces;

namespace PATIO
{
    public partial class ctrlAccueil : UserControl
    {
        public AccesNet Acces;
        public WeifenLuo.WinFormsUI.Docking.DockPanel DP;
        public string Chemin;

        public ctrlConsole Console;

        public Utilisateur user_appli;

        List<Utilisateur> Liste;

        bool Chargé = false;

        public ctrlAccueil()
        {
            InitializeComponent();
        }

        public void Initialise()
        {
            lblNom.Text = "?";
            lblCodeUser.Text = "?";
            Afficher_ListeUtilisateur();
        }

        public void Afficher_ObjetPilote(Utilisateur user)
        {
            if (!Chargé) { return; }

            List<Plan> Liste1 = (List<Plan>)Acces.Remplir_ListeElement(Acces.type_PLAN.id, "");
            TreeNode Nd1 = new TreeNode("Plans");

            foreach (Plan p in Liste1)
            {
                if (!(p.Pilote is null))
                {
                    if (p.Pilote.ID == user.ID)
                    {
                        TreeNode nd = new TreeNode(p.Libelle);
                        nd.Name = "PLA-" + p.ID;
                        nd.Tag = p;
                        Nd1.Nodes.Add(nd);
                    }
                }
            }
            Nd1.Expand();

            List<Objectif> Liste2 = (List<Objectif>)Acces.Remplir_ListeElement(Acces.type_OBJECTIF.id, "");
            TreeNode Nd2 = new TreeNode("Objectifs");

            foreach (Objectif p in Liste2)
            {
                if (!(p.Pilote is null))
                {
                    if (p.Pilote.ID == user.ID)
                    {
                        TreeNode nd = new TreeNode(p.Libelle);
                        nd.Name = "OBJ-" + p.ID;
                        nd.Tag = p;
                        Nd2.Nodes.Add(nd);
                    }
                }
            }
            Nd2.Expand();

            List<PATIO.Classes.Action> Liste3 = (List<PATIO.Classes.Action>)Acces.Remplir_ListeElement(Acces.type_ACTION.id, "");
            TreeNode Nd3 = new TreeNode("Actions");

            foreach (PATIO.Classes.Action p in Liste3)
            {
                if (!(p.Pilote is null))
                {
                    if (p.Pilote.ID == user.ID)
                    {
                        TreeNode nd = new TreeNode(p.Libelle);
                        nd.Name = "ACT-" + p.ID;
                        nd.Tag = p;
                        Nd3.Nodes.Add(nd);
                    }
                }
            }
            Nd3.Expand();

            treePilote.Nodes.Add(Nd1);
            treePilote.Nodes.Add(Nd2);
            treePilote.Nodes.Add(Nd3);
        }

        public void Afficher_ObjetMembre(Utilisateur user)
        {
            List<PATIO.Classes.Action> Liste= (List<PATIO.Classes.Action>)Acces.Donner_ListeActionMembre(user.ID);
            TreeNode Nd = new TreeNode("Actions");

            foreach (PATIO.Classes.Action p in Liste)
            {
                TreeNode nd = new TreeNode(p.Libelle);
                nd.Name = "ACT-" + p.ID;
                nd.Tag = p;
                Nd.Nodes.Add(nd);
            }
            Nd.Expand();

            treeAsso.Nodes.Add(Nd);
        }

        private void btnActualiser_Click(object sender, EventArgs e)
        {
            Initialise();
        }

        void Ouvrir()
        {
            if(treePilote.SelectedNode is null ) { return; }
            string Code = treePilote.SelectedNode.Name;
            
            if(Code.Split('-')[0] == Acces.type_PLAN.code)
            {
                int ID = int.Parse(Code.Split('-')[1]);
                Ouvrir_Plan(ID);
            }
            if (Code.Split('-')[0] == Acces.type_OBJECTIF.code)
            {
                int ID = int.Parse(Code.Split('-')[1]);
                Ouvrir_Objectif(ID);
            }
            if (Code.Split('-')[0] == Acces.type_ACTION.code)
            {
                int ID = int.Parse(Code.Split('-')[1]);
                Ouvrir_Action(ID);
            }
        }

        void Ouvrir_Plan(int ID)
        {
            Plan plan = (Plan)Acces.Trouver_Element(Acces.type_PLAN.id, ID);

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

            D.Show(DP, WeifenLuo.WinFormsUI.Docking.DockState.Document);
        }

        void Ouvrir_Objectif(int ID)
        {
            Objectif objectif = (Objectif)Acces.Trouver_Element(Acces.type_OBJECTIF.id, ID);

            var D = new WeifenLuo.WinFormsUI.Docking.DockContent();
            D.TabText = "Objectif " + objectif.Code;

            var ctrl = new ctrlFicheObjectif();
            ctrl.Acces = Acces;
            ctrl.objectif = objectif;
            ctrl.Initialiser();

            ctrl.Dock = DockStyle.Fill;
            D.Controls.Add(ctrl);

            D.Show(DP, WeifenLuo.WinFormsUI.Docking.DockState.Document);
        }

        void Ouvrir_Action(int ID)
        {
            PATIO.Classes.Action action = (PATIO.Classes.Action)Acces.Trouver_Element(Acces.type_ACTION.id, ID);

            var D = new WeifenLuo.WinFormsUI.Docking.DockContent();
            D.TabText = "Action " + action.Code;

            ctrlFicheAction ctrl = new ctrlFicheAction();
            ctrl.Acces = Acces;
            ctrl.action = action;
            ctrl.Initialiser();

            ctrl.Dock = DockStyle.Fill;
            D.Controls.Add(ctrl);

            D.Show(DP, WeifenLuo.WinFormsUI.Docking.DockState.Document);
        }

        private void btnOuvrirElement_Click(object sender, EventArgs e)
        {
            Ouvrir();
        }

        private void btnOuvrirAction_Click(object sender, EventArgs e)
        {
            if(treeAsso.SelectedNode is null) { return; }
            Ouvrir_Action(int.Parse(treeAsso.SelectedNode.Name.Split('-')[1]));
        }

        void Afficher_ListeUtilisateur()
        {
            lstUtilisateur.Items.Clear();
            Chargé = false;
            Liste = (List<Utilisateur>)Acces.Remplir_ListeElement(Acces.type_UTILISATEUR.id, "");
            int n = -1;

            foreach(Utilisateur user in Liste)
            {
                lstUtilisateur.Items.Add(user.Nom + " " + user.Prenom);
                if(user.ID == user_appli.ID) { n = lstUtilisateur.Items.Count-1; }
            }
            Chargé = true;
            if (!(n < 0)) { lstUtilisateur.SelectedIndex = n; }
        }

        private void lstUtilisateur_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Chargé) { return; }

            lblCodeUser.Text = user_appli.Code;
            lblNom.Text = user_appli.Nom + " " + user_appli.Prenom;

            treePilote.Nodes.Clear();
            treeAsso.Nodes.Clear();

            if (lstUtilisateur.SelectedIndex < 0) { return; }

            Utilisateur user = Liste[lstUtilisateur.SelectedIndex];

            Afficher_ObjetPilote(user);
            Afficher_ObjetMembre(user);
        }
    }
}
