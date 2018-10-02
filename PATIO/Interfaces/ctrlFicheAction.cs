using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PATIO.Classes;
using PATIO.Modules;

namespace PATIO.Interfaces
{
    public partial class ctrlFicheAction : UserControl
    {
        /// <summary>
        /// Définition des paramètres publics
        /// </summary>
        public PATIO.Classes.Action action;
        public PATIO.Classes.Action actionParent;
        public PATIO.Classes.AccesNet Acces;
        public Boolean Creation = false;
        public int PropId;
        public Plan plan;

        /// <summary>
        /// Définition des paramètres locaux
        /// </summary>
        string[] listeTypeAction;
        string[] listeMeteo;
        string[] listeTxAvancement;
        List<Utilisateur> ListePilote = new List<Utilisateur>();
        List<table_valeur> listeStatut;

        int Hauteur =250;

        /// <summary>
        /// Evénement survenant lorsque l'enregistrement est déclenché
        /// </summary>
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

        /// <summary>
        /// Procédure d'initialisation standard du composant
        /// </summary>
        public ctrlFicheAction()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Procédure d'initialisation paramétrée du composant
        /// </summary>
        public void Initialiser()
        {
            //Détermine la hauteur des composants
            string h= Acces.Donner_ValeurParametre("HAUTEUR");
            if (h != null) { if (int.Parse(h) > 0) { Hauteur = int.Parse(h); } }

            lblID.Text = action.ID.ToString();
            //Onglet 1
            lblLibelleAction.Text = action.Libelle;
            lblCodeAction.Text = action.Code;
            OptActiveAction.Checked = action.Actif;

            //Code et type d'action
            AfficheTypeAction();
            lstTypeAction.SelectedIndex = lstTypeAction.Items.IndexOf(action.TypeAction.ToString());
            lblCode.Text = action.Code;

            if (Creation && actionParent != null)
            { AfficheCode(actionParent); }
            else
            { AfficheCode(action); }
            GenereCode();

            lblCodeAction.Tag = lblCodeAction.Text;
            if(!(actionParent is null) && Creation)
                {
                optCodeAction.Checked = true;
                if (actionParent != null) {
                    if (actionParent.TypeAction == TypeAction.ACTION)
                    { lstTypeAction.SelectedIndex = 2; }
                    else
                    { lstTypeAction.SelectedIndex = 1; }
                }
                if (action.Pilote is null) { action.Pilote = actionParent.Pilote; }
            }

            //Pilote
            AfficheListePilote();
            if (actionParent != null)
            { if ((action.Pilote is null) && (actionParent.Pilote != null)) { action.Pilote = actionParent.Pilote; } }
            if (!(plan is null) && (action.Pilote is null)) { action.Pilote = plan.Pilote; }
            var n = 0;
            try
            {
                foreach (var p in ListePilote)
                {
                    if (p.ID == action.Pilote.ID)
                    {
                        lstPilote.SelectedIndex = n;
                        break;
                    }
                    n++;
                }
            }
            catch { lstPilote.SelectedIndex = 0; }

            //Action phare
            optActionPhare.Checked = action.ActionPhare;
            lstOrdrePriorite.Items.Clear();
            foreach (table_valeur tv in Acces.Remplir_ListeTableValeur("ORDRE_ACTION_PHARE"))
            {
                lstOrdrePriorite.Items.Add(tv.Valeur);
                if (action.ActionPhare && tv.ID == action.OrdreActionPhare)
                { lstOrdrePriorite.SelectedIndex = lstOrdrePriorite.Items.Count - 1; }
            }

            //Validation interne
            lstNiveauValidation.Items.Clear();
            foreach (table_valeur tv in Acces.Remplir_ListeTableValeur("VALIDATION_INTERNE"))
            {
                lstNiveauValidation.Items.Add(tv.Valeur);
                if (tv.ID == action.Validation)
                { lstNiveauValidation.SelectedIndex = lstNiveauValidation.Items.Count - 1; }
            }

            //statut de l'action
            AfficheListeStatut();
            if (lstStatut.Items.Count > 0) { lstStatut.SelectedIndex = 0; }
            n = 0;
            foreach(table_valeur tv in listeStatut)
            {
                if (action.Statut == tv.ID)
                {
                    lstStatut.SelectedIndex = n;
                    n++;
                    break;
                }
            }

            lblDescription.Text = action.Description;
            grpDescription.Height = Hauteur;

            //Onglet Public
            ChoixPublicCible.Initialiser();
            foreach (table_valeur tv in Acces.Remplir_ListeTableValeur("PUBLIC_CIBLE"))
            {
                Boolean ok = false;
                foreach (int k in action.PublicCible)
                {
                    if (tv.ID == k) { ok = true; break; }
                }
                if (ok)
                {
                    ChoixPublicCible.ListeSelection.Add(new Parametre(tv.ID, tv.Code, tv.Valeur));
                }
                ChoixPublicCible.ListeChoix.Add(new Parametre(tv.ID, tv.Code, tv.Valeur));
            }
            ChoixPublicCible.Afficher_Liste();
            grpPublic.Height = Hauteur;

            lblTerritoire.Text = action.Territoire;

            ChoixPartenaireInstitutionnel.Initialiser();
            foreach (table_valeur tv in Acces.Remplir_ListeTableValeur("PARTENAIRE_INSTITU"))
            {
                Boolean ok = false;
                foreach (int k in action.Partenaire)
                {
                    if (tv.ID == k) { ok = true; break; }
                }
                if (ok)
                {
                    ChoixPartenaireInstitutionnel.ListeSelection.Add(new Parametre(tv.ID, tv.Code, tv.Valeur));
                }
                ChoixPartenaireInstitutionnel.ListeChoix.Add(new Parametre(tv.ID, tv.Code, tv.Valeur));
            }
            ChoixPartenaireInstitutionnel.Afficher_Liste();
            grpPartenaire.Height = Hauteur;

            ChoixUsager.Initialiser();
            foreach (table_valeur tv in Acces.Remplir_ListeTableValeur("PARTENAIRE_USAGER"))
            {
                Boolean ok = false;
                foreach (int k in action.Usager)
                {
                    if (tv.ID == k) { ok = true; break; }
                }
                if (ok)
                {
                    ChoixUsager.ListeSelection.Add(new Parametre(tv.ID, tv.Code, tv.Valeur));
                }
                ChoixUsager.ListeChoix.Add(new Parametre(tv.ID, tv.Code, tv.Valeur));
            }
            ChoixUsager.Afficher_Liste();
            grpUsager.Height = Hauteur;

            //Onglet Moyens
            ChoixStructurePorteuse.Initialiser();
            foreach (table_valeur tv in Acces.Remplir_ListeTableValeur("STRUCTURE_PORTEUSE"))
            {
                Boolean ok = false;
                foreach (int k in action.StructurePorteuse)
                {
                    if (tv.ID == k) { ok = true; break; }
                }
                if (ok)
                {
                    ChoixStructurePorteuse.ListeSelection.Add(new Parametre(tv.ID, tv.Code, tv.Valeur));
                }
                ChoixStructurePorteuse.ListeChoix.Add(new Parametre(tv.ID, tv.Code, tv.Valeur));
            }
            ChoixStructurePorteuse.Afficher_Liste();
            grpStructure.Height = Hauteur;

            ChoixActeur.Initialiser();
            foreach (table_valeur tv in Acces.Remplir_ListeTableValeur("ACTEUR_SANTE"))
            {
                Boolean ok = false;
                foreach (int k in action.Acteur)
                {
                    if (tv.ID == k) { ok = true; break; }
                }
                if (ok)
                {
                    ChoixActeur.ListeSelection.Add(new Parametre(tv.ID, tv.Code, tv.Valeur));
                }
                ChoixActeur.ListeChoix.Add(new Parametre(tv.ID, tv.Code, tv.Valeur));
            }
            ChoixActeur.Afficher_Liste();
            grpActeur.Height = Hauteur;

            ChoixLevier.Initialiser();
            foreach (table_valeur tv in Acces.Remplir_ListeTableValeur("LEVIER"))
            {
                Boolean ok = false;
                foreach (int k in action.Levier)
                {
                    if (tv.ID == k) { ok = true; break; }
                }
                if (ok)
                {
                    ChoixLevier.ListeSelection.Add(new Parametre(tv.ID, tv.Code, tv.Valeur));
                }
                ChoixLevier.ListeChoix.Add(new Parametre(tv.ID, tv.Code, tv.Valeur));
            }
            ChoixLevier.Afficher_Liste();
            grpLevier.Height = Hauteur;

            lblCoutFinancier.Text = action.CoutFinancier;
            optFIR.Checked = action.FinancementFIR;

            lblMontant_2018.Text = action.Mt_2018;
            lblMontant_2019.Text = action.Mt_2019;
            lblMontant_2020.Text = action.Mt_2020;
            lblMontant_2021.Text = action.Mt_2021;
            lblMontant_2022.Text = action.Mt_2022;
            lblMontant_2023.Text = action.Mt_2023;
            lblMontant_Total.Text = action.Mt_Total;

            //Onglet Suivi évaluation
            lblResultatLivrable.Text = action.ResultatLivrable;
            lblNbPersImpact.Text = action.NbPersImpact;
            lblNbActeur.Text = action.NbActeurMobilise;
            lblIndicResultat.Text = action.IndicResultat;
            lblIndicMoyen.Text = action.IndicMoyen;

            //Onglet Calendrier, gouvernance
            ChoixAnnee.Initialiser();
            foreach (table_valeur tv in Acces.Remplir_ListeTableValeur("ANNEE_MO"))
            {
                Boolean ok = false;
                foreach (int k in action.AnneeMiseOeuvre)
                {
                    if (tv.ID == k) { ok = true; break; }
                }
                if (ok)
                {
                    ChoixAnnee.ListeSelection.Add(new Parametre(tv.ID, tv.Code, tv.Valeur));
                }
                ChoixAnnee.ListeChoix.Add(new Parametre(tv.ID, tv.Code, tv.Valeur));
            }
            ChoixAnnee.Afficher_Liste();

            //Direction Pilote
            ChoixDirectionPilote.Initialiser();
            foreach (table_valeur tv in Acces.Remplir_ListeTableValeur("DIRECTION_METIER"))
            {
                Boolean ok = false;
                foreach (int k in action.DirectionPilote)
                {
                    if (tv.ID == k) { ok = true; break; }
                }
                if (ok)
                {
                    ChoixDirectionPilote.ListeSelection.Add(new Parametre(tv.ID, tv.Code, tv.Valeur));
                }
                ChoixDirectionPilote.ListeChoix.Add(new Parametre(tv.ID, tv.Code, tv.Valeur));
            }
            ChoixDirectionPilote.Afficher_Liste();
            grpDirectionPilote.Height = Hauteur;

            ChoixDirectionAssocie.Initialiser();
            foreach (table_valeur tv in Acces.Remplir_ListeTableValeur("DIRECTION_METIER"))
            {
                Boolean ok = false;
                foreach (int k in action.DirectionAssocie)
                {
                    if (tv.ID == k) { ok = true; break; }
                }
                if (ok)
                {
                    ChoixDirectionAssocie.ListeSelection.Add(new Parametre(tv.ID, tv.Code, tv.Valeur));
                }
                ChoixDirectionAssocie.ListeChoix.Add(new Parametre(tv.ID, tv.Code, tv.Valeur));
            }
            ChoixDirectionAssocie.Afficher_Liste();
            grpDirAsso.Height = Hauteur;

            ChoixEquipe.Initialiser();
            foreach (Utilisateur user in (List<Utilisateur>)Acces.Remplir_ListeElement(Acces.type_UTILISATEUR.id, ""))
            {
                Boolean ok = false;
                foreach (int k in action.Equipe)
                {
                    if (user.ID == k) { ok = true; break; }
                }
                if (ok)
                {
                    ChoixEquipe.ListeSelection.Add(new Parametre(user.ID, user.Code, user.Nom + " " + user.Prenom));
                }
                ChoixEquipe.ListeChoix.Add(new Parametre(user.ID, user.Code, user.Nom + " " + user.Prenom));
            }
            ChoixEquipe.Afficher_Liste();
            grpEquipe.Height = Hauteur;

            //Onglet Liens
            ChoixLienPlan.Initialiser();
            foreach (table_valeur tv in Acces.Remplir_ListeTableValeur("LIEN_PLAN"))
            {
                Boolean ok = false;
                foreach (int k in action.LienPlan)
                {
                    if (tv.ID == k) { ok = true; break; }
                }
                if (ok)
                {
                    ChoixLienPlan.ListeSelection.Add(new Parametre(tv.ID, tv.Code, tv.Valeur));
                }
                ChoixLienPlan.ListeChoix.Add(new Parametre(tv.ID, tv.Code, tv.Valeur));
            }
            ChoixLienPlan.Afficher_Liste();
            grpLienPlan.Height = Hauteur;

            ChoixLienParcours.Initialiser();
            foreach (table_valeur tv in Acces.Remplir_ListeTableValeur("PARCOURS"))
            {
                Boolean ok = false;
                foreach (int k in action.LienParcours)
                {
                    if (tv.ID == k) { ok = true; break; }
                }
                if (ok)
                {
                    ChoixLienParcours.ListeSelection.Add(new Parametre(tv.ID, tv.Code, tv.Valeur));
                }
                ChoixLienParcours.ListeChoix.Add(new Parametre(tv.ID, tv.Code, tv.Valeur));
            }
            ChoixLienParcours.Afficher_Liste();
            grpLienParcours.Height = Hauteur;

            ChoixLienSecteur.Initialiser();
            foreach (table_valeur tv in Acces.Remplir_ListeTableValeur("SECTEUR"))
            {
                Boolean ok = false;
                foreach (int k in action.LienSecteur)
                {
                    if (tv.ID == k) { ok = true; break; }
                }
                if (ok)
                {
                    ChoixLienSecteur.ListeSelection.Add(new Parametre(tv.ID, tv.Code, tv.Valeur));
                }
                ChoixLienSecteur.ListeChoix.Add(new Parametre(tv.ID, tv.Code, tv.Valeur));
            }
            ChoixLienSecteur.Afficher_Liste();
            grpLienSecteur.Height = Hauteur;

            //Onglet Territoires
            ChoixTSANTE.Initialiser();
            foreach (table_valeur tv in Acces.Remplir_ListeTableValeur("TSANTE"))
            {
                Boolean ok = false;
                foreach (int k in action.TSante)
                {
                    if (tv.ID == k) { ok = true; break; }
                }
                if (ok)
                {
                    ChoixTSANTE.ListeSelection.Add(new Parametre(tv.ID, tv.Code, tv.Valeur));
                }
                ChoixTSANTE.ListeChoix.Add(new Parametre(tv.ID, tv.Code, tv.Valeur));
            }
            ChoixTSANTE.Afficher_Liste();

            ChoixCTS591.Initialiser();
            foreach (table_valeur tv in Acces.Remplir_ListeTableValeur("PRIO_CTS_591"))
            {
                Boolean ok = false;
                foreach (int k in action.Priorite_CTS)
                {
                    if (tv.ID == k) { ok = true; break; }
                }
                if (ok)
                {
                    ChoixCTS591.ListeSelection.Add(new Parametre(tv.ID, tv.Code, tv.Valeur));
                }
                ChoixCTS591.ListeChoix.Add(new Parametre(tv.ID, tv.Code, tv.Valeur));
            }
            ChoixCTS591.Afficher_Liste();

            ChoixCTS592.Initialiser();
            foreach (table_valeur tv in Acces.Remplir_ListeTableValeur("PRIO_CTS_592"))
            {
                Boolean ok = false;
                foreach (int k in action.Priorite_CTS)
                {
                    if (tv.ID == k) { ok = true; break; }
                }
                if (ok)
                {
                    ChoixCTS592.ListeSelection.Add(new Parametre(tv.ID, tv.Code, tv.Valeur));
                }
                ChoixCTS592.ListeChoix.Add(new Parametre(tv.ID, tv.Code, tv.Valeur));
            }
            ChoixCTS592.Afficher_Liste();

            ChoixCTS62.Initialiser();
            foreach (table_valeur tv in Acces.Remplir_ListeTableValeur("PRIO_CTS_62"))
            {
                Boolean ok = false;
                foreach (int k in action.Priorite_CTS)
                {
                    if (tv.ID == k) { ok = true; break; }
                }
                if (ok)
                {
                    ChoixCTS62.ListeSelection.Add(new Parametre(tv.ID, tv.Code, tv.Valeur));
                }
                ChoixCTS62.ListeChoix.Add(new Parametre(tv.ID, tv.Code, tv.Valeur));
            }
            ChoixCTS62.Afficher_Liste();

            ChoixCTS80.Initialiser();
            foreach (table_valeur tv in Acces.Remplir_ListeTableValeur("PRIO_CTS_80"))
            {
                Boolean ok = false;
                foreach (int k in action.Priorite_CTS)
                {
                    if (tv.ID == k) { ok = true; break; }
                }
                if (ok)
                {
                    ChoixCTS80.ListeSelection.Add(new Parametre(tv.ID, tv.Code, tv.Valeur));
                }
                ChoixCTS80.ListeChoix.Add(new Parametre(tv.ID, tv.Code, tv.Valeur));
            }
            ChoixCTS80.Afficher_Liste();

            ChoixCTS02.Initialiser();
            foreach (table_valeur tv in Acces.Remplir_ListeTableValeur("PRIO_CTS_02"))
            {
                Boolean ok = false;
                foreach (int k in action.Priorite_CTS)
                {
                    if (tv.ID == k) { ok = true; break; }
                }
                if (ok)
                {
                    ChoixCTS02.ListeSelection.Add(new Parametre(tv.ID, tv.Code, tv.Valeur));
                }
                ChoixCTS02.ListeChoix.Add(new Parametre(tv.ID, tv.Code, tv.Valeur));
            }
            ChoixCTS02.Afficher_Liste();

            ChoixCTS60.Initialiser();
            foreach (table_valeur tv in Acces.Remplir_ListeTableValeur("PRIO_CTS_60"))
            {
                Boolean ok = false;
                foreach (int k in action.Priorite_CTS)
                {
                    if (tv.ID == k) { ok = true; break; }
                }
                if (ok)
                {
                    ChoixCTS60.ListeSelection.Add(new Parametre(tv.ID, tv.Code, tv.Valeur));
                }
                ChoixCTS60.ListeChoix.Add(new Parametre(tv.ID, tv.Code, tv.Valeur));
            }
            ChoixCTS60.Afficher_Liste();

            //Onglet 6PO
            AfficheListeMeteo();
            lstMeteo.SelectedIndex = lstMeteo.Items.IndexOf(action.Meteo.ToString());

            AfficheListeTxAvancement();
            lstTx.SelectedIndex = lstTx.Items.IndexOf(action.TxAvancement.ToString());

            //Onglet Rôles 6PO
            List<Utilisateur> ListeUtilisateur = (List<Utilisateur>)Acces.Remplir_ListeElement(Acces.type_UTILISATEUR.id, "");
            foreach (Utilisateur user in ListeUtilisateur) //Supprime l'utilisateur [AUCUN]
            {
                if (user.Nom.Contains("[")) { ListeUtilisateur.Remove(user); break; }
            }

            ChoixRole6PO_Copilote.Initialiser();
            foreach (Utilisateur tv in ListeUtilisateur)
            {
                Boolean ok = false;
                foreach (int k in action.Role_6PO_CoPilote)
                {
                    if (tv.ID == k) { ok = true; break; }
                }
                if (ok)
                {
                    ChoixRole6PO_Copilote.ListeSelection.Add(new Parametre(tv.ID, tv.Code, tv.Nom + " " + tv.Prenom));
                }
                ChoixRole6PO_Copilote.ListeChoix.Add(new Parametre(tv.ID, tv.Code, tv.Nom + " " + tv.Prenom));
            }
            ChoixRole6PO_Copilote.Afficher_Liste();

            ChoixRole6PO_Manager.Initialiser();
            foreach (Utilisateur tv in ListeUtilisateur)
            {
                Boolean ok = false;
                foreach (int k in action.Role_6PO_Manager)
                {
                    if (tv.ID == k) { ok = true; break; }
                }
                if (ok)
                {
                    ChoixRole6PO_Manager.ListeSelection.Add(new Parametre(tv.ID, tv.Code, tv.Nom + " " + tv.Prenom));
                }
                ChoixRole6PO_Manager.ListeChoix.Add(new Parametre(tv.ID, tv.Code, tv.Nom + " " + tv.Prenom));
            }
            ChoixRole6PO_Manager.Afficher_Liste();

            ChoixRole6PO_Consultation.Initialiser();
            foreach (Utilisateur tv in ListeUtilisateur)
            {
                Boolean ok = false;
                foreach (int k in action.Role_6PO_Consultation)
                {
                    if (tv.ID == k) { ok = true; break; }
                }
                if (ok)
                {
                    ChoixRole6PO_Consultation.ListeSelection.Add(new Parametre(tv.ID, tv.Code, tv.Nom + " " + tv.Prenom));
                }
                ChoixRole6PO_Consultation.ListeChoix.Add(new Parametre(tv.ID, tv.Code, tv.Nom + " " + tv.Prenom));
            }
            ChoixRole6PO_Consultation.Afficher_Liste();

            if (Creation)
            {
                try
                {
                    action.DateDebut = DateTime.Parse(Acces.Donner_ValeurParametre("DATE_DEBUT_PRS"));
                    action.DateFin = DateTime.Parse(Acces.Donner_ValeurParametre("DATE_FIN_PRS"));
                }
                catch { }
            }

            try { lblDateDebut.Value = action.DateDebut; } catch { }
            try { lblDateFin.Value = action.DateFin; } catch { }

            lblDescription.Text = action.Description;
            lblAnalyseQualitative.Text = action.AnalyseQualitative;
            lblReductionInegalite.Text = action.ReductionInegalite;
            OptActionInnovante.Checked = action.ActionInnovante;
            lblEnregistrer.Text = "Chargé " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now);
        }

        /// <summary>
        /// Affichage de la liste des types d'action
        /// </summary>
        void AfficheTypeAction()
        {
            lstTypeAction.Items.Clear();

            listeTypeAction = Enum.GetNames(typeof(TypeAction));

            foreach (var t in listeTypeAction)
            {
                lstTypeAction.Items.Add(t);
            }
        }

        /// <summary>
        /// Affichage de la liste des pilotes d'action
        /// </summary>
        void AfficheListePilote()
        {
            lstPilote.Items.Clear();

            ListePilote = Acces.Remplir_ListeUtilisateurPilote();
            foreach (var t in ListePilote)
            {
                lstPilote.Items.Add(t.Nom + " " + t.Prenom);
            }
        }

        /// <summary>
        /// Affichage de la liste des statuts pour l'action
        /// </summary>
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

        /// <summary>
        /// Affichage de la liste des météos
        /// </summary>
        void AfficheListeMeteo()
        {
            lstMeteo.Items.Clear();

            listeMeteo = Enum.GetNames(typeof(Meteo));

            foreach (var t in listeMeteo)
            {
                lstMeteo.Items.Add(t);
            }
        }

        /// <summary>
        /// Affichage de la liste des taux d'avancement
        /// </summary>
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

        /// <summary>
        /// Procédure lancée à l'enregistrement de la fiche
        /// </summary>
        void Valider()
        {
            //Onglet Informations générales
            var LibAction = lblLibelleAction.Text.Trim();
            var CodeAction = lblCodeAction.Text.Trim().ToUpper();
            var OptActive = OptActiveAction.Checked;
            var TypeAction = (TypeAction)lstTypeAction.SelectedIndex;

            if (LibAction.Length == 0)
            {
                MessageBox.Show("Libellé de l'action obligatoire", "Erreur", MessageBoxButtons.OK);
                return;
            }

            if (CodeAction.Length < 5)
            {
                MessageBox.Show("Code de l'action obligatoire", "Erreur", MessageBoxButtons.OK);
                return;
            }

            string Statut = lstStatut.Text;
            int Statut_ID = Acces.Trouver_TableValeur_ID("STATUT", Statut);
            int Pilote = -1;
            try { Pilote = ListePilote[lstPilote.SelectedIndex].ID; } catch { }

            action.Libelle = LibAction;
            action.Code = CodeAction;
            action.TypeAction = TypeAction;
            action.Actif = OptActive;
            action.Pilote = Acces.Trouver_Utilisateur(Pilote);
            action.Statut = Statut_ID;
            action.ActionPhare = optActionPhare.Checked;
            action.OrdreActionPhare = Acces.Trouver_TableValeur_ID("ORDRE_ACTION_PHARE", lstOrdrePriorite.Text.ToString());
            action.Validation = Acces.Trouver_TableValeur_ID("VALIDATION_INTERNE", lstNiveauValidation.Text);

            action.Description = lblDescription.Text.Trim();

            action._type = ""; action._codeplan = "";
            action._axe = ""; action._os = ""; action._og = ""; action._op = "";
            action._cpl = ""; action._ordreact = "";
            action._annee = ""; action._direction = ""; action._reference = "";
            action._ordreope = "";

            if ((TypeAction)lstTypeAction.SelectedIndex == TypeAction.DOSSIER) { action._type = "AXX"; }
            if ((TypeAction)lstTypeAction.SelectedIndex == TypeAction.ACTION) { action._type = "ACT"; }
            if ((TypeAction)lstTypeAction.SelectedIndex == TypeAction.OPERATION) { action._type = "OPE"; }

            try
            {
                action._codeplan = lblPlanACT.Text.ToUpper().Trim();
                if (lblAxeACT.Text.Trim().Length > 0) { action._axe = string.Format("{0:00}", int.Parse(lblAxeACT.Text)); }
                if (lblOSACT.Text.Trim().Length > 0) { action._os = string.Format("{0:00}", int.Parse(lblOSACT.Text)); }
                if (lblOGACT.Text.Trim().Length > 0) { action._og = string.Format("{0:00}", int.Parse(lblOGACT.Text)); }
                if (lblOPACT.Text.Trim().Length > 0) { action._op = string.Format("{0:00}", int.Parse(lblOPACT.Text)); }
                if (lblAutreACT.Text.Trim().Length > 0) { action._cpl = lblAutreACT.Text; }
                if (lblOrdreACT.Text.Trim().Length > 0) { action._ordreact = string.Format("{0:000}", int.Parse(lblOrdreACT.Text)); }

                if (action._type == "OPE")
                {
                    if (lblAnnéeOPE.Text.Trim().Length > 0) { action._annee = lblAnnéeOPE.Text; }
                    if (lblDirectionOPE.Text.Trim().Length > 0) { action._direction = lblDirectionOPE.Text; }
                    if (lblRefOPE.Text.Trim().Length > 0) { action._reference = lblRefOPE.Text; }
                    if (lblOrdreOPE.Text.Trim().Length > 0) { action._ordreope = string.Format("{0:000}", int.Parse(lblOrdreOPE.Text)); }
                }
            }
            catch { }

            //Onglet Public, partenaires
            action.PublicCible = ChoixPublicCible.ListeSelectionId;
            action.Territoire = lblTerritoire.Text.Trim();
            action.Partenaire = ChoixPartenaireInstitutionnel.ListeSelectionId;
            action.Usager = ChoixUsager.ListeSelectionId;

            //Onglet Moyens
            action.StructurePorteuse = ChoixStructurePorteuse.ListeSelectionId;
            action.Acteur = ChoixActeur.ListeSelectionId;
            action.Levier = ChoixLevier.ListeSelectionId;
            action.CoutFinancier = lblCoutFinancier.Text.Trim();
            action.FinancementFIR = optFIR.Checked;
            action.Mt_2018 = lblMontant_2018.Text.Trim();
            action.Mt_2019 = lblMontant_2019.Text.Trim();
            action.Mt_2020 = lblMontant_2020.Text.Trim();
            action.Mt_2021 = lblMontant_2021.Text.Trim();
            action.Mt_2022 = lblMontant_2022.Text.Trim();
            action.Mt_2023 = lblMontant_2023.Text.Trim();
            action.Mt_Total = lblMontant_Total.Text.Trim();

            //Onglet Suivi et évaluation
            action.ResultatLivrable = lblResultatLivrable.Text.Trim();
            action.NbPersImpact = lblNbPersImpact.Text.Trim();
            action.NbActeurMobilise = lblNbActeur.Text.Trim();
            action.IndicResultat = lblIndicResultat.Text.Trim();
            action.IndicMoyen = lblIndicMoyen.Text.Trim();

            //Onglet Calendrier, responsabilités
            action.AnneeMiseOeuvre = ChoixAnnee.ListeSelectionId;
            action.DirectionPilote = ChoixDirectionPilote.ListeSelectionId;
            action.DirectionAssocie = ChoixDirectionAssocie.ListeSelectionId;
            action.Equipe = ChoixEquipe.ListeSelectionId;

            //Onglet Liens
            action.LienPlan = ChoixLienPlan.ListeSelectionId;
            action.LienParcours = ChoixLienParcours.ListeSelectionId;
            action.LienSecteur = ChoixLienSecteur.ListeSelectionId;

            //Onglet Priorités CTS
            action.TSante = ChoixTSANTE.ListeSelectionId;
            List<int> listePrio = new List<int>();
            foreach (int k in ChoixCTS591.ListeSelectionId) { listePrio.Add(k); }
            foreach (int k in ChoixCTS592.ListeSelectionId) { listePrio.Add(k); }
            foreach (int k in ChoixCTS62.ListeSelectionId) { listePrio.Add(k); }
            foreach (int k in ChoixCTS80.ListeSelectionId) { listePrio.Add(k); }
            foreach (int k in ChoixCTS02.ListeSelectionId) { listePrio.Add(k); }
            foreach (int k in ChoixCTS60.ListeSelectionId) { listePrio.Add(k); }
            action.Priorite_CTS = listePrio;

            //Onglet 6PO
            action.DateDebut = lblDateDebut.Value;
            action.DateFin = lblDateFin.Value;
            action.Meteo = (Meteo)lstMeteo.SelectedIndex;
            action.TxAvancement = (TxAvancement)lstTx.SelectedIndex;
            action.ActionInnovante = OptActionInnovante.Checked;
            action.AnalyseQualitative = lblAnalyseQualitative.Text.Trim();
            action.ReductionInegalite = lblReductionInegalite.Text.Trim();

            //Onglet Rôle 6PO
            action.Role_6PO_CoPilote = ChoixRole6PO_Copilote.ListeSelectionId;
            action.Role_6PO_Manager = ChoixRole6PO_Manager.ListeSelectionId;
            action.Role_6PO_Consultation = ChoixRole6PO_Consultation.ListeSelectionId;

            if (Creation)
            {
                if (!(Acces.Existe_Element(Acces.type_ACTION, "CODE", CodeAction)))
                {
                    action.ID = Acces.Ajouter_Element(Acces.type_ACTION, action);

                    if (actionParent != null)
                    {
                        //Création du lien avec le parent
                        Lien l = new Lien() { Acces = Acces, };
                        l.element0_type = Acces.type_PLAN.id;
                        l.element0_id = 1;
                        l.element0_code = "SYSTEME";
                        l.element1_type = Acces.type_ACTION.id;
                        l.element1_id = actionParent.ID;
                        l.element1_code = actionParent.Code;
                        l.element2_type = Acces.type_ACTION.id;
                        l.element2_id = action.ID;
                        l.element2_code = action.Code;
                        l.Ajouter();
                        Acces.Ajouter_Lien(l);
                        Creation = false;
                    }

                    Acces.Enregistrer(Acces.type_ACTION, action);
                }
            }
            else
            {
                Acces.Enregistrer(Acces.type_ACTION, action);
            }

            //Test du changement de code --> Impact sur les liens
            if (lblCodeAction.Text != lblCodeAction.Tag.ToString())
            {
                Lien l = new Lien() { Acces = Acces };
                l.MettreAJourCode(Acces.type_ACTION, action.ID, action.Code);
            }

            OnRaise_Evt_Enregistrer(new evt_Enregistrer(this.Tag.ToString())); //Déclenche l'événement de modification
            Creation = false;
            lblEnregistrer.Text = "Enregistré " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now);
        }

        /// <summary>
        /// Adaptation de l'affichage selon le type de l'action
        /// </summary>
        private void lstTypeAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblEnteteACT.Text = Acces.type_ACTION.code;
            action.TypeAction = TypeAction.ACTION;

            if (lstTypeAction.SelectedIndex == 2)
            {
                action.TypeAction = TypeAction.OPERATION;
                optCodeAction.Checked = true;
                GenereCode();
            }
            if (lstTypeAction.SelectedIndex == 1)
            {
                optCodeAction.Checked = false;
                GenereCode();
            }

            if (lstTypeAction.SelectedIndex == 0) { lblEnteteACT.Text = "AXX"; action.TypeAction = TypeAction.DOSSIER; }
        }

        /// <summary>
        /// Mise à zéro des différentes zones de saisie pour le code
        /// </summary>
        void EffaceCode()
        {
            lblPlanACT.Text = "";
            lblAxeACT.Text = "";
            lblOSACT.Text = "";
            lblOGACT.Text = "";
            lblOPACT.Text = "";
            lblAutreACT.Text = "";
            lblOrdreACT.Text = "";
            lblAnnéeOPE.Text = "";
            lblDirectionOPE.Text = "";
            lblRefOPE.Text = "";
            lblOrdreOPE.Text = "";
        }

        /// <summary>
        /// Affichage du code de l'action et des zones de saisie selon les informations stockées
        /// </summary>
        void AfficheCode(PATIO.Classes.Action action)
        {
            EffaceCode();
            if (action.Code is null) { return; }

            lblPlanACT.Text = action._codeplan;
            lblAxeACT.Text = action._axe;
            lblOSACT.Text = action._os;
            lblOGACT.Text = action._og;
            lblOPACT.Text = action._op;
            lblAutreACT.Text = action._cpl;
            lblOrdreACT.Text = action._ordreact;
            lblAnnéeOPE.Text = action._annee;
            lblDirectionOPE.Text = action._direction;
            lblRefOPE.Text = action._reference;
            lblOrdreOPE.Text = action._ordreope;
        }

        /// <summary>
        /// Génération du code de l'action selon les informations saisies
        /// </summary>
        void GenereCode()
        {
            string code = "";

            string type = ""; string codeplan = ""; string axe = ""; string os = ""; string og = ""; string op = "";
            string cpl = ""; string annee = ""; string direction = ""; string reference = "";
            string ordreact = ""; string ordreope = "";


            if ((TypeAction)lstTypeAction.SelectedIndex == TypeAction.DOSSIER) { type = "AXX"; }
            if ((TypeAction)lstTypeAction.SelectedIndex == TypeAction.ACTION) { type = "ACT"; }
            if ((TypeAction)lstTypeAction.SelectedIndex == TypeAction.OPERATION) { type = "OPE"; }

            try
            {
                codeplan = lblPlanACT.Text.ToUpper().Trim();
                if (lblAxeACT.Text.Trim().Length > 0) { axe = string.Format("{0:00}", int.Parse(lblAxeACT.Text)); }
                if (lblOSACT.Text.Trim().Length > 0) { os = string.Format("{0:00}", int.Parse(lblOSACT.Text)); }
                if (lblOGACT.Text.Trim().Length > 0) { og = string.Format("{0:00}", int.Parse(lblOGACT.Text)); }
                if (lblOPACT.Text.Trim().Length > 0) { op = string.Format("{0:00}", int.Parse(lblOPACT.Text)); }
                if (lblAutreACT.Text.Trim().Length > 0) { cpl = lblAutreACT.Text; }
                if (lblOrdreACT.Text.Trim().Length > 0) { ordreact = string.Format("{0:000}", int.Parse(lblOrdreACT.Text)); }

                if (type =="OPE")
                {
                    if (lblAnnéeOPE.Text.Trim().Length > 0) { annee = lblAnnéeOPE.Text; }
                    if (lblDirectionOPE.Text.Trim().Length > 0) { direction = lblDirectionOPE.Text; }
                    if (lblRefOPE.Text.Trim().Length > 0) { reference = lblRefOPE.Text; }
                    if (lblOrdreOPE.Text.Trim().Length > 0) { ordreope = string.Format("{0:000}", int.Parse(lblOrdreOPE.Text)); }
                }
            }
            catch { }

            code += type + "-" + codeplan;
            if (axe.Length > 0) { code += "-AX" + axe; }
            if (os.Length > 0) { code += "-OS" + os; }
            if (og.Length > 0) { code += "-OG" + og; }
            if (op.Length > 0) { code += "-OP" + op; }
            if (cpl.Length > 0) { code += "-AU" + cpl; }
            if (ordreact.Length > 0) { code += "-" + ordreact; }
            if (annee.Length > 0) { code += "-" + annee; }
            if (direction.Length > 0) { code += "-" + direction; }
            if (reference.Length > 0) { code += "-" + reference; }
            if (ordreope.Length > 0) { code += "-" + ordreope; }

            lblCodeAction.Text = code;
        }

        /// <summary>
        /// Procédure de génération lancée lors du changement de valeur d'une zone de saisie
        /// </summary>
        private void lblPlanACT_TextChanged(object sender, EventArgs e)
        {
            GenereCode();
        }

        /// <summary>
        /// Procédure de génération lancée lors du changement de valeur d'une zone de saisie
        /// </summary>
        private void lblAxeACT_TextChanged(object sender, EventArgs e)
        {
            GenereCode();
        }

        /// <summary>
        /// Procédure de génération lancée lors du changement de valeur d'une zone de saisie
        /// </summary>
        private void lblOSACT_TextChanged(object sender, EventArgs e)
        {
            GenereCode();
        }

        /// <summary>
        /// Procédure de génération lancée lors du changement de valeur d'une zone de saisie
        /// </summary>
        private void lblOGACT_TextChanged(object sender, EventArgs e)
        {
            GenereCode();
        }

        /// <summary>
        /// Procédure de génération lancée lors du changement de valeur d'une zone de saisie
        /// </summary>
        private void lblOPACT_TextChanged(object sender, EventArgs e)
        {
            GenereCode();
        }

        /// <summary>
        /// Procédure de génération lancée lors du changement de valeur d'une zone de saisie
        /// </summary>
        private void lblAutreACT_TextChanged(object sender, EventArgs e)
        {
            GenereCode();
        }

        /// <summary>
        /// Procédure de génération lancée lors du changement de valeur d'une zone de saisie
        /// </summary>
        private void lblAnnéeOPE_TextChanged(object sender, EventArgs e)
        {
            GenereCode();
        }

        /// <summary>
        /// Procédure de génération lancée lors du changement de valeur d'une zone de saisie
        /// </summary>
        private void lblDirectionOPE_TextChanged(object sender, EventArgs e)
        {
            GenereCode();
        }

        /// <summary>
        /// Procédure de génération lancée lors du changement de valeur d'une zone de saisie
        /// </summary>
        private void lblRefOPE_TextChanged(object sender, EventArgs e)
        {
            GenereCode();
        }

        /// <summary>
        /// Procédure de génération lancée lors du changement de valeur d'une zone de saisie
        /// </summary>
        private void lblOrdreOPE_TextChanged(object sender, EventArgs e)
        {
            GenereCode();
        }

        /// <summary>
        /// Procédure de génération lancée lors du changement de valeur d'une zone de saisie
        /// </summary>
        private void optCodeAction_CheckedChanged(object sender, EventArgs e)
        {
            GenereCode();
        }

        /// <summary>
        /// Procédure d'enregistrement lancée lors de la validation (touche entrée)
        /// </summary>
        private void lblAutreACT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                Valider();
            }
        }

        /// <summary>
        /// Procédure d'enregistrement lancée lors de la validation (touche entrée)
        /// </summary>
        private void lblOrdreOPE_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                Valider();
            }
        }

        /// <summary>
        /// Adaptation de l'affichage selon le statut d'action phare de l'action
        /// </summary>
        private void optActionPhare_CheckedChanged(object sender, EventArgs e)
        {
            lstOrdrePriorite.Enabled = optActionPhare.Checked;
            if (!optActionPhare.Checked) { lstOrdrePriorite.Text = ""; }
        }

        /// <summary>
        /// Procédure d'enregistrement lancée lors du clic sur le bouton d'enregistrement
        /// </summary>
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            btnEnregistrer.Enabled = false;
            Valider();
            btnEnregistrer.Enabled = true;
        }

        /// <summary>
        /// Procédure d'actualisation des listes proposées pour la saisie
        /// Le rechargement des données est alors opéré pour tenir compte des modifications faites par ailleurs
        /// </summary>
        private void btnActualiser_Click(object sender, EventArgs e)
        {
            Acces.Charger_ListeAttribut();
            Acces.Charger_ListeParametre();
            Acces.Charger_ListeTableValeur();
            Initialiser();
        }

        /// <summary>
        /// Déclenchement de l'événement d'enregistrement
        /// Utiliser par un autre contrôle écoutant ce composant
        /// </summary>
        protected virtual void OnRaise_Evt_Enregistrer(evt_Enregistrer e)
        {
            EventHandler<evt_Enregistrer> handler = EVT_Enregistrer;

            if (handler != null)
            {
                e.ID = this.Tag.ToString();
                handler(this, e);
            }
        }

        /// <summary>
        /// Procédure de mise à jour des dates de début et de fin de l'action
        /// selon les informations de l'action parent si elle est indiquée
        /// selon l valeur par défaut définie dans les paramètres globaux
        /// </summary>
        private void btnDateDefaut_Click(object sender, EventArgs e)
        {
            if (!(actionParent is null))
            {
                try
                {
                    lblDateDebut.Value = actionParent.DateDebut;
                    lblDateFin.Value = actionParent.DateFin;
                    return;
                }
                catch { }
            }
            Acces.Charger_ListeParametre();

            foreach (Parametre p in Acces.ListeParametre)
            {
                switch (p.Code)
                {
                    case "DATE_DEBUT_PRS":
                        lblDateDebut.Value = DateTime.Parse(p.Valeur);
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
