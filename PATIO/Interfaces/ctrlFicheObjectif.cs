using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PATIO.Classes;
using PATIO.Modules;

namespace PATIO.Interfaces
{
    public partial class ctrlFicheObjectif : UserControl
    {
        public ctrlFicheObjectif()
        {
            InitializeComponent();
        }

        public Objectif objectif;
        public Objectif objectifParent;
        public AccesNet Acces;
        public Boolean Creation = false;

        public Interfaces.ctrlConsole Console;


        Fonctions fonc = new Fonctions();

        string[] listeTypeObjectif;
        List<table_valeur> listeStatut;
        //string[] listeStatut;
        string[] listeMeteo;
        string[] listeTxAvancement;
        List<Utilisateur> ListePilote = new List<Utilisateur>();
        List<Utilisateur> ListeCopilote = new List<Utilisateur>();
        List<Utilisateur> ListeManager = new List<Utilisateur>();
        List<Utilisateur> ListeConsultation = new List<Utilisateur>();

        public class evt_Enregistrer : EventArgs
        {
            public evt_Enregistrer(string s)
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

        public event EventHandler<evt_Enregistrer> EVT_Enregistrer;

        public void Initialiser()
        {
            lblLibelleObjectif.Text = objectif.Libelle;

            lblCodeObjectif.Text = objectif.Code;
            lblCode.Text = objectif.Code;
            AfficheCode(objectif.Code);
            lblCodeObjectif.Tag = lblCodeObjectif.Text;

            OptActiveObjectif.Checked = objectif.Actif;

            AfficheTypeObjectif();
            lstTypeObjectif.SelectedIndex = lstTypeObjectif.Items.IndexOf(objectif.TypeObjectif.ToString());

            try
            { if (objectif.Pilote is null && objectifParent.Pilote != null) { objectif.Pilote = objectifParent.Pilote; }
            } catch { }

            AfficheListePilote();
            var n = 0;
            try
            {
                foreach (var p in ListePilote)
                {
                    if (p.ID == objectif.Pilote.ID)
                    {
                        lstPilote.SelectedIndex = n;
                        break;
                    }
                    n++;
                }
            }
            catch { lstPilote.SelectedIndex = 0; }

            //Statut
            AfficheListeStatut();
            if (lstStatut.Items.Count > 0) { lstStatut.SelectedIndex = 0; }
            n = 0;
            foreach (table_valeur tv in listeStatut)
            {
                if (objectif.Statut == tv.ID)
                {
                    lstStatut.SelectedIndex = n;
                    n++;
                    break;
                }
            }

            AfficheListeMeteo();
            lstMeteo.SelectedIndex = lstMeteo.Items.IndexOf(objectif.Meteo.ToString());

            AfficheListeTxAvancement();
            lstTx.SelectedIndex = lstTx.Items.IndexOf(objectif.TxAvancement.ToString());

            List<Utilisateur> ListeUtilisateur = (List<Utilisateur>)Acces.Remplir_ListeElement(Acces.type_UTILISATEUR.id, "");
            foreach(Utilisateur user in ListeUtilisateur) //Supprime l'utilisateur [AUCUN]
            {
                if (user.Nom.Contains("[")){ ListeUtilisateur.Remove(user); break; }
            }

            ChoixRole6PO_Copilote.Initialiser();
            foreach (Utilisateur tv in ListeUtilisateur)
            {
                Boolean ok = false;
                foreach (int k in objectif.Role_6PO_CoPilote)
                {
                    if (tv.ID == k) { ok = true; break; }
                }
                if (ok)
                {
                    ChoixRole6PO_Copilote.ListeSelection.Add(new Parametre(tv.ID, tv.Code, tv.Nom + " " + tv.Prenom));
                    //ChoixRole6PO_Copilote.ListeSelectionId.Add(tv.ID);
                }
                ChoixRole6PO_Copilote.ListeChoix.Add(new Parametre(tv.ID, tv.Code, tv.Nom + " " + tv.Prenom));
            }
            ChoixRole6PO_Copilote.Afficher_Liste();

            ChoixRole6PO_Manager.Initialiser();
            foreach (Utilisateur tv in ListeUtilisateur)
            {
                Boolean ok = false;
                foreach (int k in objectif.Role_6PO_Manager)
                {
                    if (tv.ID == k) { ok = true; break; }
                }
                if (ok)
                {
                    ChoixRole6PO_Manager.ListeSelection.Add(new Parametre(tv.ID, tv.Code, tv.Nom + " " + tv.Prenom));
                    //ChoixRole6PO_Manager.ListeSelectionId.Add(tv.ID);
                }
                ChoixRole6PO_Manager.ListeChoix.Add(new Parametre(tv.ID, tv.Code, tv.Nom + " " + tv.Prenom));
            }
            ChoixRole6PO_Manager.Afficher_Liste();

            ChoixRole6PO_Consultation.Initialiser();
            foreach (Utilisateur tv in ListeUtilisateur)
            {
                Boolean ok = false;
                foreach (int k in objectif.Role_6PO_Consultation)
                {
                    if (tv.ID == k) { ok = true; break; }
                }
                if (ok)
                {
                    ChoixRole6PO_Consultation.ListeSelection.Add(new Parametre(tv.ID, tv.Code, tv.Nom + " " + tv.Prenom));
                    //ChoixRole6PO_Consultation.ListeSelectionId.Add(tv.ID);
                }
                ChoixRole6PO_Consultation.ListeChoix.Add(new Parametre(tv.ID, tv.Code, tv.Nom + " " + tv.Prenom));
            }
            ChoixRole6PO_Consultation.Afficher_Liste();

            if (Creation)
            {
                try
                {
                    objectif.DateDebut = DateTime.Parse(Acces.Donner_ValeurParametre("DATE_DEBUT_PRS"));
                    objectif.DateFin = DateTime.Parse(Acces.Donner_ValeurParametre("DATE_FIN_PRS"));
                }
                catch { }
            }

            try { lblDateDebut.Value = objectif.DateDebut; } catch { }
            try { lblDateFin.Value = objectif.DateFin; } catch { }

            lblDescription.Text = objectif.Description;
            lblAnalyseQualitative.Text = objectif.AnalyseQualitative;

            lblEnregistrer.Text = "Chargé " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now);

        }

        void AfficheCode(string code)
        {
            string c = code.Substring(4);

            lblEntete.Text = objectif._type;
            lblPlan.Text = objectif._codeplan;
            lblAxe.Text = objectif._axe;
            lblOS.Text = objectif._os;
            lblOG.Text = objectif._og;
            lblOP.Text = objectif._op;
            lblAutre.Text = objectif._cpl;
        }

        void GenereCode()
        {
            string code = "";
            try {
                objectif._codeplan = lblPlan.Text;
                if (lblEntete.Text.Trim().Length > 0) { objectif._type = lblEntete.Text ; }
                if (lblAxe.Text.Trim().Length > 0) { objectif._axe = string.Format("{0:00}", int.Parse(lblAxe.Text)); }
                if (lblOS.Text.Trim().Length > 0) { objectif._os = string.Format("{0:00}", int.Parse(lblOS.Text)); }
                if (lblOG.Text.Trim().Length > 0) { objectif._og = string.Format("{0:00}", int.Parse(lblOG.Text)); }
                if (lblOP.Text.Trim().Length > 0) { objectif._op = string.Format("{0:00}", int.Parse(lblOP.Text)); }
                if (lblAutre.Text.Trim().Length > 0) { objectif._cpl = lblAutre.Text; }
            } catch { }

            code = objectif._type + "-" + objectif._codeplan;
            if (objectif._axe.Length > 0) { code += "-AX" + objectif._axe; }
            if (objectif._os.Length > 0) { code += "-OS" + objectif._os; }
            if (objectif._og.Length > 0) { code += "-OG" + objectif._og; }
            if (objectif._op.Length > 0) { code += "-OP" + objectif._op; }
            if (objectif._cpl.Length > 0) { code += "-AU" + objectif._cpl; }

            lblCodeObjectif.Text = code;
        }

        void AfficheTypeObjectif()
        {
            lstTypeObjectif.Items.Clear();

            listeTypeObjectif = Enum.GetNames(typeof(TypeObjectif));

            foreach (var t in listeTypeObjectif)
            {
                lstTypeObjectif.Items.Add(t);
            }
        }

        void AfficheListePilote()
        {
            lstPilote.Items.Clear();

            ListePilote = Acces.Remplir_ListeUtilisateurPilote();
            foreach (var t in ListePilote)
            {
                lstPilote.Items.Add(t.Nom + " " + t.Prenom);
            }
        }

        void AfficheListeStatut()
        {
            lstStatut.Items.Clear();

            listeStatut = Acces.Remplir_ListeTableValeur("STATUT");// Enum.GetNames(typeof(Statut));
            listeStatut.Sort();

            foreach (var t in listeStatut)
            {
                lstStatut.Items.Add(t.Valeur);
            }
        }

        void AfficheListeMeteo()
        {
            lstMeteo.Items.Clear();

            listeMeteo = Enum.GetNames(typeof(Meteo));

            foreach (var t in listeMeteo)
            {
                lstMeteo.Items.Add(t);
            }
        }

        void AfficheListeTxAvancement()
        {
            lstTx.Items.Clear();

            listeTxAvancement = Enum.GetNames(typeof(TxAvancement));

            foreach (var t in listeTxAvancement)
            {
                lstTx.Items.Add(t);
            }
        }

        private void BtnValider_Click(object sender, EventArgs e)
        {
            Valider();
        }

        void Valider()
        {
            var LibObjectif = lblLibelleObjectif.Text.Trim();
            var CodeObjectif = lblCodeObjectif.Text.Trim().ToUpper();
            var OptActive = OptActiveObjectif.Checked;
            var TypeObjectif = (TypeObjectif)lstTypeObjectif.SelectedIndex;

            string Statut = lstStatut.Text;
            int Statut_ID = Acces.Trouver_TableValeur_ID("STATUT", Statut);

            var Meteo = (Meteo)lstMeteo.SelectedIndex;
            var Tx = (TxAvancement)lstTx.SelectedIndex;

            int Pilote = -1;
            try { Pilote = ListePilote[lstPilote.SelectedIndex].ID; } catch { }
            var DDeb = lblDateDebut.Value;
            var DFin = lblDateFin.Value;

            var Description = lblDescription.Text;
            var Analyse = lblAnalyseQualitative.Text;

            if (LibObjectif.Length == 0)
            {
                MessageBox.Show("Libellé de l'objectif obligatoire", "Erreur", MessageBoxButtons.OK);
                return;
            }

            if (CodeObjectif.Length == 0)
            {
                MessageBox.Show("Code du plan d'actions obligatoire", "Erreur", MessageBoxButtons.OK);
                return;
            }

            //Vérifie si un utiilisateur n'a pas plusieurs profils
            List<int> ListeChoix = new List<int>();
            foreach (int i in ChoixRole6PO_Copilote.ListeSelectionId) { ListeChoix.Add(i); }
            foreach (int i in ChoixRole6PO_Manager.ListeSelectionId) { ListeChoix.Add(i); }
            foreach (int i in ChoixRole6PO_Consultation.ListeSelectionId) { ListeChoix.Add(i); }

            List<int> distinct = ListeChoix.Distinct().ToList();
            if (ListeChoix.Count() != distinct.Count())
            {
                MessageBox.Show("Un utilisateur ne peut pas posséder 2 rôles dans 6PO pour cet objectif.", "Erreur");
                return;
            }

            objectif.Libelle = LibObjectif;
            objectif.Code = CodeObjectif;
            objectif.TypeObjectif = TypeObjectif;
            objectif.Actif = OptActive;

            objectif.Pilote = Acces.Trouver_Utilisateur(Pilote);
            objectif.Statut = Statut_ID;
            objectif.Meteo = Meteo;
            objectif.TxAvancement = Tx;
            objectif.DateDebut = DDeb;
            objectif.DateFin = DFin;

            objectif.Description = Description;
            objectif.AnalyseQualitative = Analyse;

            objectif.Role_6PO_CoPilote = ChoixRole6PO_Copilote.ListeSelectionId;
            objectif.Role_6PO_Manager = ChoixRole6PO_Manager.ListeSelectionId;
            objectif.Role_6PO_Consultation = ChoixRole6PO_Consultation.ListeSelectionId;

            objectif._codeplan = lblPlan.Text;
            if (lblAxe.Text.Length > 0) { objectif._axe = string.Format("{0:00}", int.Parse(lblAxe.Text)); }
            if (lblOS.Text.Length > 0) { objectif._os = string.Format("{0:00}", int.Parse(lblOS.Text)); }
            if (lblOG.Text.Length > 0) { objectif._og = string.Format("{0:00}", int.Parse(lblOG.Text)); }
            if (lblOP.Text.Length > 0) { objectif._op = string.Format("{0:00}", int.Parse(lblOP.Text)); }
            objectif._cpl = lblAutre.Text;

            if (Creation)
            {
                if (!(Acces.Existe_Element(Acces.type_OBJECTIF, "CODE", CodeObjectif)))
                {
                    objectif.ID= Acces.Ajouter_Element(Acces.type_OBJECTIF, objectif);

                    //Création du lien avec le parent
                    if (!(objectifParent is null))
                    {
                        Lien l = new Lien() { Acces = Acces, };

                        l.element0_type = Acces.type_PLAN.id;
                        l.element0_id = 1;
                        l.element0_code = "SYSTEME";
                        l.element1_type = Acces.type_OBJECTIF.id;
                        l.element1_id = objectifParent.ID;
                        l.element1_code = objectifParent.Code;
                        l.element2_type = Acces.type_OBJECTIF.id;
                        l.element2_id = objectif.ID;
                        l.element2_code = objectif.Code;
                        l.Ajouter();
                        Acces.Ajouter_Lien(l);
                        Creation = false;
                    }
                }
                else { MessageBox.Show("L'objectif existe déjà (code identique).", "Erreur"); return; }
            }
            else
            {
                Acces.Enregistrer(Acces.type_OBJECTIF, objectif);
            }

            //Test du changement de code --> Impact sur les liens
            if (lblCodeObjectif.Text != lblCodeObjectif.Tag.ToString())
            {
                Lien l = new Lien();
                l.Acces = Acces;
                l.MettreAJourCode(Acces.type_OBJECTIF, objectif.ID, objectif.Code);
            }

            OnRaise_Evt_Enregistrer(new evt_Enregistrer(this.Tag.ToString()));
            Creation = false;
            lblEnregistrer.Text = "Enregistré " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now);

        }

        protected virtual void OnRaise_Evt_Enregistrer(evt_Enregistrer e)
        {
            EventHandler<evt_Enregistrer> handler = EVT_Enregistrer;

            if(handler != null)
            {
                e.ID = this.Tag.ToString();
                handler(this,e);
            }
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

        private void lstUserGroupe_DragOver(object sender, DragEventArgs e)
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

        private void lblPlan_TextChanged(object sender, EventArgs e)
        {
            GenereCode();
        }

        private void lblAxe_TextChanged(object sender, EventArgs e)
        {
            GenereCode();
        }

        private void lblOS_TextChanged(object sender, EventArgs e)
        {
            GenereCode();
        }

        private void lblOG_TextChanged(object sender, EventArgs e)
        {
            GenereCode();
        }

        private void lblOP_TextChanged(object sender, EventArgs e)
        {
            GenereCode();
        }

        private void lblAutre_TextChanged(object sender, EventArgs e)
        {
            GenereCode();
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            Valider();
        }

        private void btnActualiser_Click(object sender, EventArgs e)
        {
            Acces.Charger_ListeAttribut();
            Acces.Charger_ListeParametre();
            Acces.Charger_ListeTableValeur();
            Initialiser();
        }

        private void lblAutre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if( e.KeyChar == (Char) Keys.Return) { Valider(); }
        }

        private void btnDateDefaut_Click(object sender, EventArgs e)
        {
            if(!(objectifParent is null))
            {
                try
                {
                    lblDateDebut.Value = objectifParent.DateDebut;
                    lblDateFin.Value = objectifParent.DateFin;
                    return;
                }
                catch { }
            }

            //Application des paramètres par défaut
            Acces.Charger_ListeParametre();

            foreach (Parametre p in Acces.ListeParametre)
            {
                switch(p.Code)
                {
                    case "DATE_DEBUT_PRS":
                        lblDateDebut.Value = DateTime.Parse( p.Valeur);
                        break;
                    case "DATE_FIN_PRS":
                        lblDateFin.Value = DateTime.Parse(p.Valeur);
                        break;
                }
            }

            MessageBox.Show("Les dates par défaut ont été appliquées");
        }
    }
}
