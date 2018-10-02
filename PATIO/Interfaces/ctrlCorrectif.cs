using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PATIO.Classes;

namespace PATIO.Interfaces
{
    public partial class ctrlCorrectif : UserControl
    {
        public PATIO.Classes.AccesNet Acces;
        public WeifenLuo.WinFormsUI.Docking.DockPanel DP;
        public string Chemin;

        public ctrlConsole Console;

        public ctrlCorrectif()
        {
            InitializeComponent();
        }

        public void Initialiser()
        {
            AfficheListe();
        }

        void AfficheListe()
        {
            lst.Items.Clear();

            lst.Items.Add("TXT01: Corrections des codes spéciaux dans le libellé (V180917)");
            lst.Items.Add("CODE01: Corrections des codes Plans (V180917) (!Pas de marche arrière)");
            lst.Items.Add("CODE02: Corrections des codes Objectifs (V180917)(!Pas de marche arrière)");
            lst.Items.Add("CODE03: Corrections des codes Actions (V180917) (!Pas de marche arrière)");
            lst.Items.Add("MAJ01: Mise à jour de la table Liens après changement de codes (V180917)");
            lst.Items.Add("MAJ02: Mise à jour de la table Attributs (V180920)");
        }

        private void btnExecuter_Click(object sender, EventArgs e)
        {
            Executer();
        }

        void Executer()
        {
            if (lst.SelectedIndex < 0) { return; }

            string code = lst.Items[lst.SelectedIndex].ToString().Split(':')[0];

            switch (code)
            {
                case "TXT01": { CorrigeLibelle(); break; }
                case "CODE01": { CorrigeCode_Plan(); break; }
                case "CODE02": { CorrigeCode_Objectif(); break; }
                case "CODE03": { CorrigeCode_Action(); break; }
                case "MAJ01": { MiseAJour_Lien(); break; }
                case "MAJ02": { MiseAJour_Attribut(); break; }
            }
        }

        void CorrigeLibelle()
        {
            lstCommentaire.Items.Clear();
            lstCommentaire.Items.Add("Corrections des codes Plans");

            List<Plan> ListePlan = (List<Plan>)Acces.Remplir_ListeElement(Acces.type_PLAN.id, "");

            lstCommentaire.Items.Add("Plan -> " + ListePlan.Count);
            lstCommentaire.SelectedIndex = lstCommentaire.Items.Count - 1;

            foreach(Plan p in ListePlan)
            {
                Console.Ajouter(p.Libelle);
                p.Libelle = CorrigeTexte(p.Libelle);
                Acces.Enregistrer(Acces.type_PLAN, p);
            }

            List<Objectif> ListeObjectif = (List<Objectif>)Acces.Remplir_ListeElement(Acces.type_OBJECTIF.id, "");

            lstCommentaire.Items.Add("Objectif -> " + ListeObjectif.Count);
            lstCommentaire.SelectedIndex = lstCommentaire.Items.Count - 1;

            foreach (Objectif p in ListeObjectif)
            {
                Console.Ajouter(p.Libelle);
                p.Libelle = CorrigeTexte(p.Libelle);
                Acces.Enregistrer(Acces.type_OBJECTIF, p);
            }

            List<PATIO.Classes.Action> ListeAction = (List<PATIO.Classes.Action>)Acces.Remplir_ListeElement(Acces.type_ACTION.id, "");

            lstCommentaire.Items.Add("Action -> " + ListeAction.Count);
            lstCommentaire.SelectedIndex = lstCommentaire.Items.Count - 1;

            foreach (PATIO.Classes.Action p in ListeAction)
            {
                p.Libelle = CorrigeTexte(p.Libelle);
                Acces.Enregistrer(Acces.type_ACTION, p);
                Console.Ajouter(p.Libelle);
            }

            lstCommentaire.Items.Add("Traitement terminé");
            lstCommentaire.SelectedIndex = lstCommentaire.Items.Count - 1;
        }

        string CorrigeTexte(string txt)
        {
            string texte = "";
            for (int i = 0; i < txt.Length; i++)
            {
                char c = txt[i];
                int ichar = (int)c;

                switch (ichar)
                {
                    case 145: { c = '\''; break; }
                    case 146: { c = '\''; break; }
                    case 150: { c = ' '; break; }
                    case 160: { c = ' '; break; }
                    default: { break; }
                }

                texte += c;
            }

            return texte;
        }

        void CorrigeCode_Plan()
        {
            lstCommentaire.Items.Clear();
            lstCommentaire.Items.Add("Corrections des codes Plans");
            lstCommentaire.Items.Add("Chargement des données");

            List<Plan> Liste = (List<Plan>) Acces.Remplir_ListeElement(Acces.type_PLAN.id,"");

            lstCommentaire.Items.Add("Traitement...");

            progressBar1.Minimum = 1;
            progressBar1.Maximum = Liste.Count;
            progressBar1.Step = 1;
            progressBar1.Value = progressBar1.Minimum;

            foreach (Plan p in Liste)
            {
                progressBar1.PerformStep();
                string code = p.Code;

                string type = ""; string ref1 = ""; string ref2 = ""; string os = ""; string og = "";
                lstCommentaire.Items.Add(code);
                lstCommentaire.SelectedIndex = lstCommentaire.Items.Count - 1;

                int n = 0;

                foreach(string txt in code.Split('-'))
                {
                    n++;

                    switch (n)
                    {
                        case 1:
                            { type= txt; break; }
                        case 2:
                            { ref1 =txt; break; }
                        default:
                            {
                                if (txt.Substring(0, 2) == "OS") { os = txt.Substring(3); break; }
                                if (txt.Substring(0, 2) == "OG") { og = txt.Substring(3); break; }
                                ref2 = txt; break;
                            }
                    }
                }

                p._type = type;
                p._ref1 = ref1;
                p._ref2 = ref2;

                code = type + "-" + ref1;
                if (ref2.Length > 0) { code += "-" + ref2; }
                if (os.Length > 0) { p._os = string.Format("{0:00}", int.Parse(os)); code += "-OS" + p._os; }
                if (og.Length > 0) { p._og = string.Format("{0:00}", int.Parse(og)); code += "-OG" + p._og; }
                p.Code = code;
                lstCommentaire.Items.Add("--->" + code) ;

                Acces.Enregistrer(Acces.type_PLAN, p);
            }

            lstCommentaire.Items.Add("Traitement terminé : " + Liste.Count);
            lstCommentaire.SelectedIndex = lstCommentaire.Items.Count - 1;
        }

        void CorrigeCode_Objectif()
        {
            lstCommentaire.Items.Clear();
            lstCommentaire.Items.Add("Corrections des codes Objectifs");
            lstCommentaire.Items.Add("Chargement des données");

            List<Objectif> Liste = (List<Objectif>)Acces.Remplir_ListeElement(Acces.type_OBJECTIF.id, "");

            lstCommentaire.Items.Add("Traitement...");

            progressBar1.Minimum = 1;
            progressBar1.Maximum = Liste.Count;
            progressBar1.Step = 1;
            progressBar1.Value = progressBar1.Minimum;

            foreach (Objectif p in Liste)
            {
                progressBar1.PerformStep();

                string code = p.Code.Replace("_","-");
                string type = ""; string codeplan = ""; string axe = ""; string os = ""; string og = "";
                string op = ""; string cpl = "";
                lstCommentaire.Items.Add(code);
                lstCommentaire.SelectedIndex = lstCommentaire.Items.Count - 1;

                int n = 0;

                foreach (string txt in code.Split('-'))
                {
                    n++;

                    switch (n)
                    {
                        case 1:
                            { type = txt; break; }
                        case 2:
                            { codeplan = txt; break; }
                        default:
                            {
                                if (txt.Substring(0, 1) == "A") { axe = txt.Substring(2); break; }
                                if (txt.Substring(0, 2) == "OS") { os = txt.Substring(3); break; }
                                if (txt.Substring(0, 2) == "OG") { og = txt.Substring(3); break; }
                                if (txt.Substring(0, 2) == "OP") { op = txt.Substring(3); break; }
                                cpl = txt; break;
                            }
                    }
                }

                p._type = type;
                p._codeplan = codeplan;

                string codefin = type + "-" + codeplan;
                if (axe.Length > 0) { p._axe = string.Format("{0:00}", int.Parse(axe)); codefin += "-AX" + p._axe; }
                if (os.Length > 0) { p._os = string.Format("{0:00}", int.Parse(os)); codefin += "-OS" + p._os; }
                if (og.Length > 0) { p._og = string.Format("{0:00}", int.Parse(og)); codefin += "-OG" + p._og; }
                if (op.Length > 0) { p._op = string.Format("{0:00}", int.Parse(op)); codefin += "-OP" + p._op; }
                if (cpl.Length > 0) { p._cpl = cpl; codefin += "-AU" + p._cpl; }
                p.Code = codefin;
                lstCommentaire.Items.Add("--->" + codefin);

                Acces.Enregistrer(Acces.type_OBJECTIF, p);
            }

            lstCommentaire.Items.Add("Traitement terminé : " + Liste.Count);
            lstCommentaire.SelectedIndex = lstCommentaire.Items.Count - 1;
        }

        void CorrigeCode_Action()
        {
            lstCommentaire.Items.Clear();
            lstCommentaire.Items.Add("Corrections des codes Actions");
            lstCommentaire.Items.Add("Chargement des données");

            List<PATIO.Classes.Action> Liste = (List<PATIO.Classes.Action>)Acces.Remplir_ListeElement(Acces.type_ACTION.id, "");

            lstCommentaire.Items.Add("Traitement...");

            progressBar1.Minimum = 1;
            progressBar1.Maximum = Liste.Count;
            progressBar1.Step = 1;
            progressBar1.Value = progressBar1.Minimum;

            foreach (PATIO.Classes.Action p in Liste)
            {
                progressBar1.PerformStep();

                string code = p.Code;

                string type = ""; string codeplan = ""; string axe = ""; string os = ""; string og = ""; string op = "";
                string cpl = ""; string annee = ""; string direction = ""; string reference = "";
                string ordreact = ""; string ordreope = "";

                lstCommentaire.Items.Add(code + "[" + p.ID + "]");
                lstCommentaire.SelectedIndex = lstCommentaire.Items.Count - 1;

                //Action ou opération
                string code1 = ""; string code2 = "";

                type = code.Substring(0, 3);
                code = code.Substring(4);

                if (type == "AXX") { code1 = code.Split('.')[0].Replace("_", "-OR"); }
                if (type == "ACT") { code1 = code.Split('.')[0].Replace("_", "-OR"); }

                if (type == "OPE")
                {
                    if (code.Split('.').Length > 1)
                    {
                        code1 = code.Split('.')[0].Replace("_", "-OR");
                        code2 = code.Split('.')[1];
                    }
                    else
                    { code1 = ""; code2 = code.Split('.')[0]; }
                }


                int n = 0;

                //Structure d'une action
                if (code1.Length > 0)
                {
                    foreach (string txt in code1.Split('-'))
                    {
                        n++;

                        switch (n)
                        {
                            case 1:
                                { codeplan = txt; break; }
                            default:
                                {
                                    if (txt.Substring(0, 1) == "A") { axe = txt.Substring(2); break; }
                                    if (txt.Substring(0, 2) == "OS") { os = txt.Substring(3); break; }
                                    if (txt.Substring(0, 2) == "OG") { og = txt.Substring(3); break; }
                                    if (txt.Substring(0, 2) == "OP") { op = txt.Substring(3); break; }
                                    if (txt.Substring(0, 2) == "OR") { ordreact = txt.Substring(3); break; }
                                    MessageBox.Show("NON TROUVE" + "->" + txt);
                                    Console.Ajouter("************ NON TROUVE ->" + txt);
                                    break;
                                }
                        }
                    }
                }

                //Structure d'une opération
                if (code2.Length > 0)
                {
                    foreach (string txt in code2.Split('-'))
                    {
                        try
                        {
                            if (txt.Substring(0, 1) == "A") { annee = txt.Substring(1); }
                            if (txt.Substring(0, 1) == "D") { direction = txt.Substring(1); }
                            if (txt.Substring(0, 1) == "R") { reference = txt.Substring(1); }
                            if (txt.Substring(0, 1) == "O") { ordreope = txt.Substring(1); }
                            if (txt.Substring(0, 1) == "|") { ordreope = txt.Substring(1); }
                        } catch { }
                    }
                }

                p._type = type;
                p._codeplan = codeplan;

                string codefin1 =  codeplan;
                if (axe.Length > 0) { codefin1 += "-" + axe; }
                if (os.Length > 0) { p._os = string.Format("{0:00}", int.Parse(os)); codefin1 += "-OS" + p._os; }
                if (og.Length > 0) { p._og = string.Format("{0:00}", int.Parse(og)); codefin1 += "-OG" + p._og; }
                if (op.Length > 0) { p._op = string.Format("{0:00}", int.Parse(op)); codefin1 += "-OP" + p._op; }
                if (cpl.Length > 0) { p._cpl = cpl; codefin1 += "-" + p._cpl; }
                if (ordreact.Length > 0) { p._ordreact = string.Format("{0:000}", int.Parse(ordreact)); codefin1 += "-" + p._ordreact; }

                string codefin2 = "";
                if (code2.Length > 0)
                {
                    try
                    {
                        if (annee.Length > 0) { p._annee = annee; codefin2 += "-" + axe; }
                        if (direction.Length > 0) { p._direction = string.Format("{0:00}", direction); codefin2 += "-" + p._direction; }
                        if (reference.Length > 0) { p._reference = string.Format("{0:00}", reference); codefin2 += "-" + p._reference; }
                        if (ordreope.Length > 0) { p._ordreope = string.Format("{0:000}", int.Parse(ordreope)); codefin2 += "-" + p._ordreope; }
                    } catch { }
                }

                p.Code = type;
                if (codefin1.Length > 0) { p.Code += "-" + codefin1; }
                if (codefin2.Length > 0) { p.Code += codefin2; }
                //MessageBox.Show(p.Code);
                lstCommentaire.Items.Add("--->" + p.Code);

                Console.Ajouter(code + " -> " + p.Code);
                
                Acces.Enregistrer(Acces.type_ACTION, p);
            }

            lstCommentaire.Items.Add("Traitement terminé : " + Liste.Count);
            lstCommentaire.SelectedIndex = lstCommentaire.Items.Count - 1;
        }

        void MiseAJour_Lien()
        {
            lstCommentaire.Items.Clear();
            lstCommentaire.Items.Add("Mise à jour de la table des liens");

            string sql;

            lstCommentaire.Items.Add("Niveau 0");
            sql = "UPDATE lien SET element0_code= (SELECT element.code FROM element";
            sql += " WHERE lien.element0_id = element.id)";
            Acces.cls.Execute(sql);
            if (Acces.cls.erreur.Length > 0) { MessageBox.Show(Acces.cls.erreur); }

            lstCommentaire.Items.Add("Niveau 1");
            sql = "UPDATE lien SET element1_code= (SELECT element.code FROM element";
            sql += " WHERE lien.element1_id = element.id)";
            Acces.cls.Execute(sql);
            if (Acces.cls.erreur.Length > 0) { MessageBox.Show(Acces.cls.erreur); }

            lstCommentaire.Items.Add("Niveau 2");
            sql = "UPDATE lien SET element2_code= (SELECT element.code FROM element";
            sql += " WHERE lien.element2_id = element.id)";
            Acces.cls.Execute(sql);
            if (Acces.cls.erreur.Length > 0) { MessageBox.Show(Acces.cls.erreur); }

            lstCommentaire.Items.Add("Traitement terminé");
            lstCommentaire.SelectedIndex = lstCommentaire.Items.Count - 1;
        }

        void MiseAJour_Attribut()
        {
            lstCommentaire.Items.Clear();
            lstCommentaire.Items.Add("Mise à jour de la table Attribut");

            string sql;
            string id_element = "";
            string attribut = "";

            lstCommentaire.Items.Add("MT_2019 : changement de type d'élement");
            sql = "UPDATE delement SET attribut_id= (SELECT id FROM attribut";
            sql += " WHERE attribut.code= delement.attribut_code)";
            sql += " WHERE delement.attribut_code = 'MT_2019'";
            Acces.cls.Execute(sql);
            if (Acces.cls.erreur.Length > 0) { MessageBox.Show(Acces.cls.erreur); }

            id_element = "3"; //ACTION
            lstCommentaire.Items.Add("[ACTION] _TYPEPLAN-->_TYPE");
            sql = "UPDATE delement, element SET attribut_code= '_TYPE'";
            sql += " WHERE attribut_code= '_TYPEPLAN'";
            sql += " AND delement.element_id = element.id";
            sql += " AND element.element_type=" + id_element;
            Acces.cls.Execute(sql);
            if (Acces.cls.erreur.Length > 0) { MessageBox.Show(Acces.cls.erreur); }
            //////////////////////////////////////////////////////////////

            id_element = "1"; attribut = "_TYPE";
            lstCommentaire.Items.Add("[OBJECTIF] " + attribut + "--> Actualise les id");
            sql = "UPDATE delement, element SET attribut_id= (SELECT DISTINCT id FROM attribut";
            sql += " WHERE attribut.code = delement.attribut_code ";
            sql += " AND attribut.element_type='" + id_element + "')";
            sql += " WHERE delement.element_id = element.id";
            sql += " AND element.element_type='" + id_element + "'";
            sql += " AND delement.attribut_code='" + attribut + "'";
            Acces.cls.Execute(sql);
            if (Acces.cls.erreur.Length > 0) { MessageBox.Show(Acces.cls.erreur); }

            id_element = "1"; attribut = "_AXE";
            lstCommentaire.Items.Add("[OBJECTIF] " + attribut + "--> Actualise les id");
            sql = "UPDATE delement, element SET attribut_id= (SELECT DISTINCT id FROM attribut";
            sql += " WHERE attribut.code = delement.attribut_code ";
            sql += " AND attribut.element_type='" + id_element + "')";
            sql += " WHERE delement.element_id = element.id";
            sql += " AND element.element_type='" + id_element + "'";
            sql += " AND delement.attribut_code='" + attribut + "'";
            Acces.cls.Execute(sql);
            if (Acces.cls.erreur.Length > 0) { MessageBox.Show(Acces.cls.erreur); }

            id_element = "1"; attribut = "_CODEPLAN";
            lstCommentaire.Items.Add("[OBJECTIF] " + attribut + "--> Actualise les id");
            sql = "UPDATE delement, element SET attribut_id= (SELECT DISTINCT id FROM attribut";
            sql += " WHERE attribut.code = delement.attribut_code ";
            sql += " AND attribut.element_type='" + id_element + "')";
            sql += " WHERE delement.element_id = element.id";
            sql += " AND element.element_type='" + id_element + "'";
            sql += " AND delement.attribut_code='" + attribut + "'";
            Acces.cls.Execute(sql);
            if (Acces.cls.erreur.Length > 0) { MessageBox.Show(Acces.cls.erreur); }

            id_element = "1"; attribut = "_REF1";
            lstCommentaire.Items.Add("[OBJECTIF] " + attribut + "--> Actualise les id");
            sql = "UPDATE delement, element SET attribut_id= (SELECT DISTINCT id FROM attribut";
            sql += " WHERE attribut.code = delement.attribut_code ";
            sql += " AND attribut.element_type='" + id_element + "')";
            sql += " WHERE delement.element_id = element.id";
            sql += " AND element.element_type='" + id_element + "'";
            sql += " AND delement.attribut_code='" + attribut + "'";
            Acces.cls.Execute(sql);
            if (Acces.cls.erreur.Length > 0) { MessageBox.Show(Acces.cls.erreur); }

            id_element = "1"; attribut = "_REF2";
            lstCommentaire.Items.Add("[OBJECTIF] " + attribut + "--> Actualise les id");
            sql = "UPDATE delement, element SET attribut_id= (SELECT DISTINCT id FROM attribut";
            sql += " WHERE attribut.code = delement.attribut_code ";
            sql += " AND attribut.element_type='" + id_element + "')";
            sql += " WHERE delement.element_id = element.id";
            sql += " AND element.element_type='" + id_element + "'";
            sql += " AND delement.attribut_code='" + attribut + "'";
            Acces.cls.Execute(sql);
            if (Acces.cls.erreur.Length > 0) { MessageBox.Show(Acces.cls.erreur); }

            id_element = "1"; attribut = "_OS";
            lstCommentaire.Items.Add("[OBJECTIF] " + attribut + "--> Actualise les id");
            sql = "UPDATE delement, element SET attribut_id= (SELECT DISTINCT id FROM attribut";
            sql += " WHERE attribut.code = delement.attribut_code ";
            sql += " AND attribut.element_type='" + id_element + "')";
            sql += " WHERE delement.element_id = element.id";
            sql += " AND element.element_type='" + id_element + "'";
            sql += " AND delement.attribut_code='" + attribut + "'";
            Acces.cls.Execute(sql);
            if (Acces.cls.erreur.Length > 0) { MessageBox.Show(Acces.cls.erreur); }

            id_element = "1"; attribut = "_OG";
            lstCommentaire.Items.Add("[OBJECTIF] " + attribut + "--> Actualise les id");
            sql = "UPDATE delement, element SET attribut_id= (SELECT DISTINCT id FROM attribut";
            sql += " WHERE attribut.code = delement.attribut_code ";
            sql += " AND attribut.element_type='" + id_element + "')";
            sql += " WHERE delement.element_id = element.id";
            sql += " AND element.element_type='" + id_element + "'";
            sql += " AND delement.attribut_code='" + attribut + "'";
            Acces.cls.Execute(sql);
            if (Acces.cls.erreur.Length > 0) { MessageBox.Show(Acces.cls.erreur); }

            //////////////////////////////////////////////////////////////
            ///            
            id_element = "2"; attribut = "TYPE";
            lstCommentaire.Items.Add("[OBJECTIF] " + attribut + "--> Actualise les id");
            sql = "UPDATE delement, element SET attribut_id= (SELECT DISTINCT id FROM attribut";
            sql += " WHERE attribut.code = delement.attribut_code ";
            sql += " AND attribut.element_type='" + id_element + "')";
            sql += " WHERE delement.element_id = element.id";
            sql += " AND element.element_type='" + id_element + "'";
            sql += " AND delement.attribut_code='" + attribut + "'";
            Acces.cls.Execute(sql);
            if (Acces.cls.erreur.Length > 0) { MessageBox.Show(Acces.cls.erreur); }

            id_element = "2"; attribut = "_TYPE";
            lstCommentaire.Items.Add("[OBJECTIF] " + attribut + "--> Actualise les id");
            sql = "UPDATE delement, element SET attribut_id= (SELECT DISTINCT id FROM attribut";
            sql += " WHERE attribut.code = delement.attribut_code ";
            sql += " AND attribut.element_type='" + id_element + "')";
            sql += " WHERE delement.element_id = element.id";
            sql += " AND element.element_type='" + id_element + "'";
            sql += " AND delement.attribut_code='" + attribut + "'";
            Acces.cls.Execute(sql);
            if (Acces.cls.erreur.Length > 0) { MessageBox.Show(Acces.cls.erreur); }

            id_element = "2"; attribut = "_AXE";
            lstCommentaire.Items.Add("[OBJECTIF] " + attribut + "--> Actualise les id");
            sql = "UPDATE delement, element SET attribut_id= (SELECT DISTINCT id FROM attribut";
            sql += " WHERE attribut.code = delement.attribut_code ";
            sql += " AND attribut.element_type='" + id_element + "')";
            sql += " WHERE delement.element_id = element.id";
            sql += " AND element.element_type='" + id_element + "'";
            sql += " AND delement.attribut_code='" + attribut + "'";
            Acces.cls.Execute(sql);
            if (Acces.cls.erreur.Length > 0) { MessageBox.Show(Acces.cls.erreur); }

            id_element = "2"; attribut = "_CODEPLAN";
            lstCommentaire.Items.Add("[OBJECTIF] " + attribut + "--> Actualise les id");
            sql = "UPDATE delement, element SET attribut_id= (SELECT DISTINCT id FROM attribut";
            sql += " WHERE attribut.code = delement.attribut_code ";
            sql += " AND attribut.element_type='" + id_element + "')";
            sql += " WHERE delement.element_id = element.id";
            sql += " AND element.element_type='" + id_element + "'";
            sql += " AND delement.attribut_code='" + attribut + "'";
            Acces.cls.Execute(sql);
            if (Acces.cls.erreur.Length > 0) { MessageBox.Show(Acces.cls.erreur); }

            id_element = "2"; attribut = "_OS";
            lstCommentaire.Items.Add("[OBJECTIF] " + attribut + "--> Actualise les id");
            sql = "UPDATE delement, element SET attribut_id= (SELECT DISTINCT id FROM attribut";
            sql += " WHERE attribut.code = delement.attribut_code ";
            sql += " AND attribut.element_type='" + id_element + "')";
            sql += " WHERE delement.element_id = element.id";
            sql += " AND element.element_type='" + id_element + "'";
            sql += " AND delement.attribut_code='" + attribut + "'";
            Acces.cls.Execute(sql);
            if (Acces.cls.erreur.Length > 0) { MessageBox.Show(Acces.cls.erreur); }

            id_element = "2"; attribut = "_OG";
            lstCommentaire.Items.Add("[OBJECTIF] " + attribut + "--> Actualise les id");
            sql = "UPDATE delement, element SET attribut_id= (SELECT DISTINCT id FROM attribut";
            sql += " WHERE attribut.code = delement.attribut_code ";
            sql += " AND attribut.element_type='" + id_element + "')";
            sql += " WHERE delement.element_id = element.id";
            sql += " AND element.element_type='" + id_element + "'";
            sql += " AND delement.attribut_code='" + attribut + "'";
            Acces.cls.Execute(sql);
            if (Acces.cls.erreur.Length > 0) { MessageBox.Show(Acces.cls.erreur); }

            id_element = "2"; attribut = "_OP";
            lstCommentaire.Items.Add("[OBJECTIF] " + attribut + "--> Actualise les id");
            sql = "UPDATE delement, element SET attribut_id= (SELECT DISTINCT id FROM attribut";
            sql += " WHERE attribut.code = delement.attribut_code ";
            sql += " AND attribut.element_type='" + id_element + "')";
            sql += " WHERE delement.element_id = element.id";
            sql += " AND element.element_type='" + id_element + "'";
            sql += " AND delement.attribut_code='" + attribut + "'";
            Acces.cls.Execute(sql);
            if (Acces.cls.erreur.Length > 0) { MessageBox.Show(Acces.cls.erreur); }

            id_element = "2"; attribut = "_DIRECTION";
            lstCommentaire.Items.Add("[OBJECTIF] " + attribut + "--> Actualise les id");
            sql = "UPDATE delement, element SET attribut_id= (SELECT DISTINCT id FROM attribut";
            sql += " WHERE attribut.code = delement.attribut_code ";
            sql += " AND attribut.element_type='" + id_element + "')";
            sql += " WHERE delement.element_id = element.id";
            sql += " AND element.element_type='" + id_element + "'";
            sql += " AND delement.attribut_code='" + attribut + "'";
            Acces.cls.Execute(sql);
            if (Acces.cls.erreur.Length > 0) { MessageBox.Show(Acces.cls.erreur); }

            id_element = "2"; attribut = "_CPL";
            lstCommentaire.Items.Add("[ACTION] " + attribut + "--> Actualise les id");
            sql = "UPDATE delement, element SET attribut_id= (SELECT DISTINCT id FROM attribut";
            sql += " WHERE attribut.code = delement.attribut_code ";
            sql += " AND attribut.element_type='" + id_element + "')";
            sql += " WHERE delement.element_id = element.id";
            sql += " AND element.element_type='" + id_element + "'";
            sql += " AND delement.attribut_code='" + attribut + "'";
            Acces.cls.Execute(sql);
            if (Acces.cls.erreur.Length > 0) { MessageBox.Show(Acces.cls.erreur); }

            id_element = "2"; attribut = "ROLE_6PO_COPILOTE";
            lstCommentaire.Items.Add("[ACTION] " + attribut + "--> Actualise les id");
            sql = "UPDATE delement, element SET attribut_id= (SELECT DISTINCT id FROM attribut";
            sql += " WHERE attribut.code = delement.attribut_code ";
            sql += " AND attribut.element_type='" + id_element + "')";
            sql += " WHERE delement.element_id = element.id";
            sql += " AND element.element_type='" + id_element + "'";
            sql += " AND delement.attribut_code='" + attribut + "'";
            Acces.cls.Execute(sql);
            if (Acces.cls.erreur.Length > 0) { MessageBox.Show(Acces.cls.erreur); }

            id_element = "2"; attribut = "ROLE_6PO_MANAGER";
            lstCommentaire.Items.Add("[ACTION] " + attribut + "--> Actualise les id");
            sql = "UPDATE delement, element SET attribut_id= (SELECT DISTINCT id FROM attribut";
            sql += " WHERE attribut.code = delement.attribut_code ";
            sql += " AND attribut.element_type='" + id_element + "')";
            sql += " WHERE delement.element_id = element.id";
            sql += " AND element.element_type='" + id_element + "'";
            sql += " AND delement.attribut_code='" + attribut + "'";
            Acces.cls.Execute(sql);
            if (Acces.cls.erreur.Length > 0) { MessageBox.Show(Acces.cls.erreur); }

            id_element = "2"; attribut = "ROLE_6PO_CONSULTATION";
            lstCommentaire.Items.Add("[ACTION] " + attribut + "--> Actualise les id");
            sql = "UPDATE delement, element SET attribut_id= (SELECT DISTINCT id FROM attribut";
            sql += " WHERE attribut.code = delement.attribut_code ";
            sql += " AND attribut.element_type='" + id_element + "')";
            sql += " WHERE delement.element_id = element.id";
            sql += " AND element.element_type='" + id_element + "'";
            sql += " AND delement.attribut_code='" + attribut + "'";
            Acces.cls.Execute(sql);
            if (Acces.cls.erreur.Length > 0) { MessageBox.Show(Acces.cls.erreur); }

            //////////////////////////////////////////////////////////////
            id_element = "3"; attribut = "_TYPE";
            lstCommentaire.Items.Add("[ACTION] " + attribut + "--> Actualise les id");
            sql = "UPDATE delement, element SET attribut_id= (SELECT DISTINCT id FROM attribut";
            sql += " WHERE attribut.code = delement.attribut_code ";
            sql += " AND attribut.element_type='" + id_element + "')";
            sql += " WHERE delement.element_id = element.id";
            sql += " AND element.element_type='" + id_element + "'";
            sql += " AND delement.attribut_code='" + attribut + "'";

            id_element = "3"; attribut = "_CODEPLAN";
            lstCommentaire.Items.Add("[ACTION] " + attribut + "--> Actualise les id");
            sql = "UPDATE delement, element SET attribut_id= (SELECT DISTINCT id FROM attribut";
            sql += " WHERE attribut.code = delement.attribut_code ";
            sql += " AND attribut.element_type='" + id_element + "')";
            sql += " WHERE delement.element_id = element.id";
            sql += " AND element.element_type='" + id_element + "'";
            sql += " AND delement.attribut_code='" + attribut + "'";

            id_element = "3"; attribut = "_DIRECTION";
            lstCommentaire.Items.Add("[ACTION] " + attribut + "--> Actualise les id");
            sql = "UPDATE delement, element SET attribut_id= (SELECT DISTINCT id FROM attribut";
            sql += " WHERE attribut.code = delement.attribut_code ";
            sql += " AND attribut.element_type='" + id_element + "')";
            sql += " WHERE delement.element_id = element.id";
            sql += " AND element.element_type='" + id_element + "'";
            sql += " AND delement.attribut_code='" + attribut + "'";

            id_element = "3"; attribut = "_REFERENCE";
            lstCommentaire.Items.Add("[ACTION] " + attribut + "--> Actualise les id");
            sql = "UPDATE delement, element SET attribut_id= (SELECT DISTINCT id FROM attribut";
            sql += " WHERE attribut.code = delement.attribut_code ";
            sql += " AND attribut.element_type='" + id_element + "')";
            sql += " WHERE delement.element_id = element.id";
            sql += " AND element.element_type='" + id_element + "'";
            sql += " AND delement.attribut_code='" + attribut + "'";
            Acces.cls.Execute(sql);
            if (Acces.cls.erreur.Length > 0) { MessageBox.Show(Acces.cls.erreur); }

            id_element = "3"; attribut = "_AXE";
            lstCommentaire.Items.Add("[OBJECTIF] " + attribut + "--> Actualise les id");
            sql = "UPDATE delement, element SET attribut_id= (SELECT DISTINCT id FROM attribut";
            sql += " WHERE attribut.code = delement.attribut_code ";
            sql += " AND attribut.element_type='" + id_element + "')";
            sql += " WHERE delement.element_id = element.id";
            sql += " AND element.element_type='" + id_element + "'";
            sql += " AND delement.attribut_code='" + attribut + "'";
            Acces.cls.Execute(sql);
            if (Acces.cls.erreur.Length > 0) { MessageBox.Show(Acces.cls.erreur); }

            id_element = "3"; attribut = "_OS";
            lstCommentaire.Items.Add("[ACTION] " + attribut + "--> Actualise les id");
            sql = "UPDATE delement, element SET attribut_id= (SELECT DISTINCT id FROM attribut";
            sql += " WHERE attribut.code = delement.attribut_code ";
            sql += " AND attribut.element_type='" + id_element + "')";
            sql += " WHERE delement.element_id = element.id";
            sql += " AND element.element_type='" + id_element + "'";
            sql += " AND delement.attribut_code='" + attribut + "'";
            Acces.cls.Execute(sql);
            if (Acces.cls.erreur.Length > 0) { MessageBox.Show(Acces.cls.erreur); }

            id_element = "3"; attribut = "_OG";
            lstCommentaire.Items.Add("[ACTION] " + attribut + "--> Actualise les id");
            sql = "UPDATE delement, element SET attribut_id= (SELECT DISTINCT id FROM attribut";
            sql += " WHERE attribut.code = delement.attribut_code ";
            sql += " AND attribut.element_type='" + id_element + "')";
            sql += " WHERE delement.element_id = element.id";
            sql += " AND element.element_type='" + id_element + "'";
            sql += " AND delement.attribut_code='" + attribut + "'";
            Acces.cls.Execute(sql);
            if (Acces.cls.erreur.Length > 0) { MessageBox.Show(Acces.cls.erreur); }

            id_element = "3"; attribut = "_OP";
            lstCommentaire.Items.Add("[ACTION] " + attribut + "--> Actualise les id");
            sql = "UPDATE delement, element SET attribut_id= (SELECT DISTINCT id FROM attribut";
            sql += " WHERE attribut.code = delement.attribut_code ";
            sql += " AND attribut.element_type='" + id_element + "')";
            sql += " WHERE delement.element_id = element.id";
            sql += " AND element.element_type='" + id_element + "'";
            sql += " AND delement.attribut_code='" + attribut + "'";
            Acces.cls.Execute(sql);
            if (Acces.cls.erreur.Length > 0) { MessageBox.Show(Acces.cls.erreur); }

            id_element = "3"; attribut = "_ORDREACT";
            lstCommentaire.Items.Add("[ACTION] " + attribut + "--> Actualise les id");
            sql = "UPDATE delement, element SET attribut_id= (SELECT DISTINCT id FROM attribut";
            sql += " WHERE attribut.code = delement.attribut_code ";
            sql += " AND attribut.element_type='" + id_element + "')";
            sql += " WHERE delement.element_id = element.id";
            sql += " AND element.element_type='" + id_element + "'";
            sql += " AND delement.attribut_code='" + attribut + "'";
            Acces.cls.Execute(sql);
            if (Acces.cls.erreur.Length > 0) { MessageBox.Show(Acces.cls.erreur); }

            id_element = "3"; attribut = "_ORDREOPE";
            lstCommentaire.Items.Add("[ACTION] " + attribut + "--> Actualise les id");
            sql = "UPDATE delement, element SET attribut_id= (SELECT DISTINCT id FROM attribut";
            sql += " WHERE attribut.code = delement.attribut_code ";
            sql += " AND attribut.element_type='" + id_element + "')";
            sql += " WHERE delement.element_id = element.id";
            sql += " AND element.element_type='" + id_element + "'";
            sql += " AND delement.attribut_code='" + attribut + "'";
            Acces.cls.Execute(sql);
            if (Acces.cls.erreur.Length > 0) { MessageBox.Show(Acces.cls.erreur); }

            id_element = "3"; attribut = "_CPL";
            lstCommentaire.Items.Add("[ACTION] " + attribut + "--> Actualise les id");
            sql = "UPDATE delement, element SET attribut_id= (SELECT DISTINCT id FROM attribut";
            sql += " WHERE attribut.code = delement.attribut_code ";
            sql += " AND attribut.element_type='" + id_element + "')";
            sql += " WHERE delement.element_id = element.id";
            sql += " AND element.element_type='" + id_element + "'";
            sql += " AND delement.attribut_code='" + attribut + "'";
            Acces.cls.Execute(sql);
            if (Acces.cls.erreur.Length > 0) { MessageBox.Show(Acces.cls.erreur); }

            id_element = "3"; attribut = "DESCRIPTION";
            lstCommentaire.Items.Add("[ACTION] " + attribut + "--> Actualise les id");
            sql = "UPDATE delement, element SET attribut_id= (SELECT DISTINCT id FROM attribut";
            sql += " WHERE attribut.code = delement.attribut_code ";
            sql += " AND attribut.element_type='" + id_element + "')";
            sql += " WHERE delement.element_id = element.id";
            sql += " AND element.element_type='" + id_element + "'";
            sql += " AND delement.attribut_code='" + attribut + "'";
            Acces.cls.Execute(sql);
            if (Acces.cls.erreur.Length > 0) { MessageBox.Show(Acces.cls.erreur); }

            id_element = "3"; attribut = "FINANCEMENT_FIR";
            lstCommentaire.Items.Add("[ACTION] " + attribut + "--> Actualise les id");
            sql = "UPDATE delement, element SET attribut_id= (SELECT DISTINCT id FROM attribut";
            sql += " WHERE attribut.code = delement.attribut_code ";
            sql += " AND attribut.element_type='" + id_element + "')";
            sql += " WHERE delement.element_id = element.id";
            sql += " AND element.element_type='" + id_element + "'";
            sql += " AND delement.attribut_code='" + attribut + "'";
            Acces.cls.Execute(sql);
            if (Acces.cls.erreur.Length > 0) { MessageBox.Show(Acces.cls.erreur); }

            id_element = "3"; attribut = "ROLE_6PO_COPILOTE";
            lstCommentaire.Items.Add("[ACTION] " + attribut + "--> Actualise les id");
            sql = "UPDATE delement, element SET attribut_id= (SELECT DISTINCT id FROM attribut";
            sql += " WHERE attribut.code = delement.attribut_code ";
            sql += " AND attribut.element_type='" + id_element + "')";
            sql += " WHERE delement.element_id = element.id";
            sql += " AND element.element_type='" + id_element + "'";
            sql += " AND delement.attribut_code='" + attribut + "'";
            Acces.cls.Execute(sql);
            if (Acces.cls.erreur.Length > 0) { MessageBox.Show(Acces.cls.erreur); }

            id_element = "3"; attribut = "ROLE_6PO_MANAGER";
            lstCommentaire.Items.Add("[ACTION] " + attribut + "--> Actualise les id");
            sql = "UPDATE delement, element SET attribut_id= (SELECT DISTINCT id FROM attribut";
            sql += " WHERE attribut.code = delement.attribut_code ";
            sql += " AND attribut.element_type='" + id_element + "')";
            sql += " WHERE delement.element_id = element.id";
            sql += " AND element.element_type='" + id_element + "'";
            sql += " AND delement.attribut_code='" + attribut + "'";
            Acces.cls.Execute(sql);
            if (Acces.cls.erreur.Length > 0) { MessageBox.Show(Acces.cls.erreur); }

            id_element = "3"; attribut = "ROLE_6PO_CONSULTATION";
            lstCommentaire.Items.Add("[ACTION] " + attribut + "--> Actualise les id");
            sql = "UPDATE delement, element SET attribut_id= (SELECT DISTINCT id FROM attribut";
            sql += " WHERE attribut.code = delement.attribut_code ";
            sql += " AND attribut.element_type='" + id_element + "')";
            sql += " WHERE delement.element_id = element.id";
            sql += " AND element.element_type='" + id_element + "'";
            sql += " AND delement.attribut_code='" + attribut + "'";
            Acces.cls.Execute(sql);
            if (Acces.cls.erreur.Length > 0) { MessageBox.Show(Acces.cls.erreur); }

            id_element = "3"; attribut = "TYPE";
            lstCommentaire.Items.Add("[ACTION] " + attribut + "--> Actualise les id");
            sql = "UPDATE delement, element SET attribut_id= (SELECT DISTINCT id FROM attribut";
            sql += " WHERE attribut.code = delement.attribut_code ";
            sql += " AND attribut.element_type='" + id_element + "')";
            sql += " WHERE delement.element_id = element.id";
            sql += " AND element.element_type='" + id_element + "'";
            sql += " AND delement.attribut_code='" + attribut + "'";
            Acces.cls.Execute(sql);
            if (Acces.cls.erreur.Length > 0) { MessageBox.Show(Acces.cls.erreur); }

            id_element = "3"; attribut = "_ANNEE";
            lstCommentaire.Items.Add("[ACTION] " + attribut + "--> Actualise les id");
            sql = "UPDATE delement, element SET attribut_id= (SELECT DISTINCT id FROM attribut";
            sql += " WHERE attribut.code = delement.attribut_code ";
            sql += " AND attribut.element_type='" + id_element + "')";
            sql += " WHERE delement.element_id = element.id";
            sql += " AND element.element_type='" + id_element + "'";
            sql += " AND delement.attribut_code='" + attribut + "'";
            Acces.cls.Execute(sql);
            if (Acces.cls.erreur.Length > 0) { MessageBox.Show(Acces.cls.erreur); }

            /////////////////////////////////////////////////////////////

            id_element = "52"; attribut = "PRENOM";
            lstCommentaire.Items.Add("[ACTION] " + attribut + "--> Actualise les id");
            sql = "UPDATE delement, element SET attribut_id= (SELECT DISTINCT id FROM attribut";
            sql += " WHERE attribut.code = delement.attribut_code ";
            sql += " AND attribut.element_type='" + id_element + "')";
            sql += " WHERE delement.element_id = element.id";
            sql += " AND element.element_type='" + id_element + "'";
            sql += " AND delement.attribut_code='" + attribut + "'";
            Acces.cls.Execute(sql);
            if (Acces.cls.erreur.Length > 0) { MessageBox.Show(Acces.cls.erreur); }

            id_element = "52"; attribut = "MAIL";
            lstCommentaire.Items.Add("[ACTION] " + attribut + "--> Actualise les id");
            sql = "UPDATE delement, element SET attribut_id= (SELECT DISTINCT id FROM attribut";
            sql += " WHERE attribut.code = delement.attribut_code ";
            sql += " AND attribut.element_type='" + id_element + "')";
            sql += " WHERE delement.element_id = element.id";
            sql += " AND element.element_type='" + id_element + "'";
            sql += " AND delement.attribut_code='" + attribut + "'";
            Acces.cls.Execute(sql);
            if (Acces.cls.erreur.Length > 0) { MessageBox.Show(Acces.cls.erreur); }

            id_element = "52"; attribut = "TYPE_LICENCE";
            lstCommentaire.Items.Add("[ACTION] " + attribut + "--> Actualise les id");
            sql = "UPDATE delement, element SET attribut_id= (SELECT DISTINCT id FROM attribut";
            sql += " WHERE attribut.code = delement.attribut_code ";
            sql += " AND attribut.element_type='" + id_element + "')";
            sql += " WHERE delement.element_id = element.id";
            sql += " AND element.element_type='" + id_element + "'";
            sql += " AND delement.attribut_code='" + attribut + "'";
            Acces.cls.Execute(sql);
            if (Acces.cls.erreur.Length > 0) { MessageBox.Show(Acces.cls.erreur); }

            lstCommentaire.Items.Add("Traitement terminé");
            lstCommentaire.SelectedIndex = lstCommentaire.Items.Count - 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n =int.Parse( Microsoft.VisualBasic.Interaction.InputBox("Saisir l'ID", "ID"));

            PATIO.Classes.Action action = (PATIO.Classes.Action) Acces.Trouver_Element(Acces.type_ACTION.id, n);

            lstCommentaire.Items.Clear();
            lstCommentaire.Items.Add(action.Libelle);

            string texte ="";
            for (int i=0;i<action.Libelle.Length; i++)
            {
                char c = action.Libelle[i];
                int ichar = (int) c;

                switch (ichar)
                {
                    case 145: { c = '\''; break; }
                    case 146: { c = '\''; break; }
                    case 150: { c = ' '; break; }
                    case 160: { c = ' '; break; }
                    case 233: { c = 'é'; break; }
                    case 224: { c = 'à'; break; }
                    default: { break; }
                }
                lstCommentaire.Items.Add( c + " ->  " + ichar + (Char) Keys.Tab + ((ichar <32) ? " X" : "") + ((ichar > 140) ? " XX" : ""));

                texte += c;
            }

            action.Libelle = texte;
            Acces.Enregistrer(Acces.type_ACTION, action);
            lstCommentaire.Items.Add("->" + texte);

        }
    }
}
