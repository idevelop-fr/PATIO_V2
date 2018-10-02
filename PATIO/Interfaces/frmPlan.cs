using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PATIO.Classes;
using PATIO.Modules;

namespace PATIO.Interfaces
{
    public partial class frmPlan : Form
    {
        public Plan plan;
        public PATIO.Classes.AccesNet Acces;
        public Boolean Creation = false;
        public int PropId;

        string[] listeTypePlan;
        string[] listeNiveau;

        List<Utilisateur> ListePilote = new List<Utilisateur>();

        Fonctions fonc = new Fonctions();

        public frmPlan()
        {
            InitializeComponent();
        }

        public void Initialiser()
        {
            lblLibellePlan.Text = plan.Libelle;
            OptActivePlan.Checked = plan.Actif;

            AfficheTypePlan();
            lstTypePlan.SelectedIndex = lstTypePlan.Items.IndexOf(plan.TypePlan.ToString());

            AfficheCode(plan.Code);
            lblCodePlan.Tag = lblCodePlan.Text; //Pour le test de changement de code
            lblCode.Text = plan.Code;

            lblID.Text = plan.ID.ToString();

            GenereCode();

            AfficheListePilote();
            var n = 0;
            try
            {
                foreach(var p in ListePilote)
                {
                    if(p.ID == plan.Pilote.ID)
                    {
                        lstPilote.SelectedIndex = n;
                        break;
                    }
                    n++;
                }
            }
            catch { lstPilote.SelectedIndex = 0; }

            AfficheNiveau();
            lstNiveau.SelectedIndex = lstNiveau.Items.IndexOf(plan.NiveauPlan.ToString());

            ChoixEquipe.Initialiser();
            foreach (Utilisateur user in (List<Utilisateur>)Acces.Remplir_ListeElement(Acces.type_UTILISATEUR.id, ""))
            {
                Boolean ok = false;
                foreach (int k in plan.Equipe)
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

            lblGroupeExterne.Text = plan.GroupeExterne;

            if (Creation)
            {
                try
                {
                    plan.DateDebut = DateTime.Parse(Acces.Donner_ValeurParametre("DATE_DEBUT_PRS"));
                    plan.DateFin = DateTime.Parse(Acces.Donner_ValeurParametre("DATE_FIN_PRS"));
                }
                catch { }
            }
            try { lblDateDebut.Value = plan.DateDebut; } catch { }
            try { lblDateFin.Value = plan.DateFin; } catch { }

            OptGouvernance.Checked = plan.OptGouvernance;
            OptCommentaires.Checked = plan.OptCommentaires;
            OptAnalyseGlobale.Checked = plan.OptAnalyseGlobale;
            OptPrioriteRegionale.Checked = plan.OptPrioriteRegionale;

            Application.DoEvents();
            AfficheEntete();
        }

        void AfficheTypePlan()
        {
            lstTypePlan.Items.Clear();

            listeTypePlan = Enum.GetNames(typeof(TypePlan));

            foreach(var t in listeTypePlan)
            {
                lstTypePlan.Items.Add(t);
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

            if (lstPilote.Items.Count > 0) { lstPilote.SelectedIndex = 0; }
        }

        void AfficheNiveau()
        {
            lstNiveau.Items.Clear();

            listeNiveau = Enum.GetNames(typeof(NiveauPlan));

            foreach (var t in listeNiveau)
            {
                lstNiveau.Items.Add(t);
            }
        }

        private void BtnAnnuler_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BtnValider_Click(object sender, EventArgs e)
        {
            Valider();
        }

        void Valider()
        {
            var LibPlan = lblLibellePlan.Text.Trim();
            var EntetePlan = lblEntete.Text.Trim().ToUpper();
            var CodePlan = lblCodePlan.Text;
            var Abrege = lblCodeAbrégé.Text;
            var OptActive = OptActivePlan.Checked;
            var TypePlan = (TypePlan)lstTypePlan.SelectedIndex;
            var Niveau = (NiveauPlan)lstNiveau.SelectedIndex;
            var DDeb = lblDateDebut.Value;
            var DFin = lblDateFin.Value;
            var OptAG = OptAnalyseGlobale.Checked;
            var OptCom = OptCommentaires.Checked;
            var OptGouv = OptGouvernance.Checked;
            var OptPR = OptPrioriteRegionale.Checked;

            int Pilote = -1;
            try { Pilote = ListePilote[lstPilote.SelectedIndex].ID; } catch { }

            if (LibPlan.Length==0)
            {
                MessageBox.Show("Libellé du plan d'actions obligatoire","Erreur",MessageBoxButtons.OK);
                return;
            }

            if (CodePlan.Length == 0)
            {
                MessageBox.Show("Code du plan d'actions obligatoire", "Erreur", MessageBoxButtons.OK);
                return;
            }
 
            plan.Libelle = LibPlan;
            plan.Code = CodePlan;
            plan.TypePlan = TypePlan;
            plan.Abrege = Abrege;
            plan.Actif = OptActive;

            plan.Pilote =Acces.Trouver_Utilisateur(Pilote);
            plan.NiveauPlan = Niveau;
            plan.DateDebut = DDeb;
            plan.DateFin = DFin;
            plan.OptAnalyseGlobale = OptAG;
            plan.OptCommentaires = OptCom;
            plan.OptGouvernance = OptGouv;
            plan.OptPrioriteRegionale = OptPR;
            plan.Equipe = ChoixEquipe.ListeSelectionId;
            plan.GroupeExterne = lblGroupeExterne.Text.Trim();

            if (Creation)
            {
                if (!(Acces.Existe_Element(Acces.type_PLAN, "CODE", plan.Code)))
                {
                    plan.ID =   Acces.Ajouter_Element(Acces.type_PLAN, plan);
                } else { MessageBox.Show("Plan existant (Code)", "Erreur"); return; }
            }
            else
            {
                Acces.Enregistrer(Acces.type_PLAN, plan);
            }

            //Test du changement de code --> Impact sur les liens
            if(lblCodePlan.Text != lblCodePlan.Tag.ToString())
            {
                Lien l = new Lien() { Acces = Acces, };
                l.MettreAJourCode(Acces.type_PLAN, plan.ID, plan.Code);
            }

            this.DialogResult = DialogResult.OK;
        }

        void AfficheCode(string code)
        {
            if (code is null) { return; }

            AfficheEntete();
            string entete = (plan.Code.Length == 0)? "": plan.Code.ToString().Substring(0, 3);
            lblEntete.Text = entete;

            lblRef1.Text = plan._ref1;
            lblRef2.Text = plan._ref2;
            lblOS.Text = plan._os;
            lblOG.Text = plan._og;
        }

        void GenereCode()
        {
            string code = "";

            try
            {
                if (lblRef1.Text.Trim().ToUpper().Length > 0) { plan._ref1 = lblRef1.Text.Trim().ToUpper(); } //Référence principale
                if (lblRef2.Text.Trim().ToUpper().Length > 0) { plan._ref2 = lblRef2.Text.Trim().ToUpper(); } //Référence secondaire
                if (lblOS.Text.Trim().ToUpper().Length > 0) { plan._os = string.Format("{0:00}", int.Parse(lblOS.Text)); }
                if (lblOG.Text.Trim().ToUpper().Length > 0) { plan._og = string.Format("{0:00}", int.Parse(lblOG.Text)); }
            } catch { }
            code += (plan._ref1.Length > 0) ? "-" + plan._ref1 : "";
            code += (plan._ref2.Length > 0) ? "-" + plan._ref2 : "";
            code += (plan._os.Length > 0) ? "-OS" + plan._os : "";
            code += (plan._og.Length > 0) ? "-OG" + plan._og : "";

            lblCodePlan.Text = lblEntete.Text.ToUpper().Trim() + code;
            if (code.Length > 1) { lblCodeAbrégé.Text = code.Substring(1); }
        }

        private void lstEntete_SelectedIndexChanged(object sender, EventArgs e)
        {
            GenereCode();
        }

        private void lstTypePlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            AfficheEntete();
        }

        void AfficheEntete()
        { 
            if (fonc.DonneTypePlan(lstTypePlan.Text) == TypePlan.DOSSIER) { lblEntete.Text = "PXX"; }
            if (fonc.DonneTypePlan(lstTypePlan.Text) == TypePlan.NATIONAL) { lblEntete.Text = "PAN"; }
            if (fonc.DonneTypePlan(lstTypePlan.Text) == TypePlan.REGIONAL) { lblEntete.Text = "PAR"; }
            if (fonc.DonneTypePlan(lstTypePlan.Text) == TypePlan.TERRITORIAL) { lblEntete.Text = "PAT"; }
            if (fonc.DonneTypePlan(lstTypePlan.Text) == TypePlan.LOCAL) { lblEntete.Text = "PAL"; }
            if (fonc.DonneTypePlan(lstTypePlan.Text) == TypePlan.TRANSVERSE) { lblEntete.Text = "PTR"; }
        }

        private void lblEntete_TextChanged(object sender, EventArgs e)
        {
            GenereCode();
        }

        private void lblRef_TextChanged(object sender, EventArgs e)
        {
            GenereCode();
        }

        private void lblRef2_TextChanged(object sender, EventArgs e)
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
    }
}
