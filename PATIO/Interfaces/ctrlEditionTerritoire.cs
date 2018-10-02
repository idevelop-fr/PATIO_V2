using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using PATIO.Classes;
using Microsoft.Office.Interop.Excel;

namespace PATIO.Interfaces
{
    public partial class ctrlEditionTerritoire : UserControl
    {
        public AccesNet Acces;
        public WeifenLuo.WinFormsUI.Docking.DockPanel DP;
        public string Chemin;

        public ctrlConsole Console;

        public Utilisateur user_appli;

        List<table_valeur> ListeTerritoire = new List<table_valeur>();
        List<Lien> ListeLien = new List<Lien>();

        Microsoft.Office.Interop.Excel.Application app;

        public ctrlEditionTerritoire()
        {
            InitializeComponent();
        }

        public void Initialiser()
        {
            Afficher_ListeTerritoire();
        }

        void Afficher_ListeTerritoire()
        {
            lstTerritoire.Items.Clear();
            ListeTerritoire = new List<table_valeur>();

            ListeTerritoire = Acces.Remplir_ListeTableValeur("TSANTE");

            foreach (table_valeur tv in ListeTerritoire)
            {
                lstTerritoire.Items.Add(tv.Valeur);
            }
        }

        private void btnAfficherTerritoire_Click(object sender, EventArgs e)
        {
            AfficherTerritoire();
        }

        void AfficherTerritoire()
        {
            if (lstTerritoire.SelectedIndex < 0) { return; }

            int id_territoire = ListeTerritoire[lstTerritoire.SelectedIndex].ID;

            tree.Nodes.Clear();

            List<Lien> listeLien = new List<Lien>();

            if (optDéclinaison.Checked) { listeLien = Acces.Remplir_ListeLienTerritoire(id_territoire); }
            if (optRelation.Checked)
            {
                string prio = ListeTerritoire[lstTerritoire.SelectedIndex].Code;
                prio = "PRIO_CTS_" + prio.Replace("TS", "");
                listeLien = Acces.Remplir_ListeLienRelationPriorité(prio);
            }
            if(listeLien == null) { MessageBox.Show("Aucun lien trouvé"); return; }
            listeLien.Sort();

            //Acces.Exporter_Lien(listeLien);

            TreeNode NodG = Acces.Donner_ArbreGlobal();
            ListeLien = new List<Lien>();

            //Exlut les noeuds ne répondant pas à la requête
            Acces.Exclure_Arbre(NodG, listeLien, ref ListeLien);

            //Affiche la liste des noeuds
            foreach (TreeNode nd in NodG.Nodes)
            {
                nd.Checked = true;
                tree.Nodes.Add(nd);
            }

            tree.ShowNodeToolTips = true;
        }

        public void Editer_Fiche()
        {
            if (lstTerritoire.SelectedIndex < 0) { return; }

            //Extrait les informations de l'arborescence
            List<Element> Liste = new List<Element>();
            foreach (TreeNode nd in tree.Nodes)
            {
                if (nd.Checked) { Extrait_Info(nd, ref Liste); }
            }

            //Création de l'application Excel
            app = new Microsoft.Office.Interop.Excel.Application();
            app.DisplayAlerts = false;

            var modele = Chemin + "\\Modeles\\Fiche_PLAN_TERRITOIRE.xltx";
            var fichier = Chemin + "\\Fichiers\\" + "FD-" + (optDéclinaison.Checked?"DECL":"PRIO-") + ListeTerritoire[lstTerritoire.SelectedIndex].Code + "-" + string.Format("{0:yyMMddHHmmss}", DateTime.Now);

            app.Workbooks.Open(modele);

            Workbooks wk = app.Workbooks;
            Workbook wb = app.ActiveWorkbook;
            Worksheet ws = wb.Sheets[1];
            Range r;

            r = ws.Cells[2, 5];
            r.Value = lstTerritoire.Text;
            r = ws.Cells[3, 5];
            r.Value = string.Format("{0:dd/MM/yyyy}", DateTime.Now); //Groupe interne

            //Affichage des éléments
            int n_ligne = 7;

            //Efface la zone
            ws.Range["A8:Y10000"].Clear();

            //Traitement de la liste des éléments extraits
            foreach (Element e in Liste)
            {
                if (e.Element_Type == Acces.type_PLAN.id)
                {
                    Plan plan1 = (Plan)Acces.Trouver_Element(Acces.type_PLAN.id, e.ID);

                    n_ligne++;
                    r = ws.Cells[n_ligne, 1];
                    r.Value = plan1.Libelle + "/n" + (optDéclinaison.Checked?optDéclinaison.Text:optRelation.Text);
                    r = ws.Cells[n_ligne, 2];
                    string pilote = "";
                    pilote = (plan1.Pilote != null) ? "\n" + plan1.Pilote.Nom + " " + plan1.Pilote.Prenom : "";
                    r.Value = pilote;

                    r = ws.Cells[n_ligne, 24];
                    r.Value = plan1.Code.Replace("PAR-", "");
                }

                if (e.Element_Type == Acces.type_OBJECTIF.id)
                {
                    Objectif obj = (Objectif)Acces.Trouver_Element(Acces.type_OBJECTIF.id, e.ID);

                    n_ligne++;
                    r = ws.Cells[n_ligne, 3];
                    r.Value = obj.Libelle;

                    r = ws.Cells[n_ligne, 24];
                    r.Value = obj.Code.Replace("OBJ-", "");
                }

                if (e.Element_Type == Acces.type_ACTION.id)
                {
                    PATIO.Classes.Action action = (PATIO.Classes.Action)Acces.Trouver_Element(Acces.type_ACTION.id, e.ID);

                    if (action.TypeAction == TypeAction.ACTION)
                    {
                        n_ligne++;
                        r = ws.Cells[n_ligne, 4];
                        r.Value = action.Libelle;

                        r = ws.Cells[n_ligne, 5];
                        string pilote = "";
                        pilote = Acces.Donner_Chaine_Liste(action.DirectionPilote, "DIRECTION_METIER", "", true);
                        pilote += (action.Pilote != null) ? "\n" + action.Pilote.Nom + " " + action.Pilote.Prenom : "";
                        r.Value = pilote;

                        r = ws.Cells[n_ligne, 24];
                        r.Value = action.Code.Replace("ACT-", "");
                    }

                    if (action.TypeAction == TypeAction.OPERATION)
                    {
                        n_ligne++;
                        r = ws.Cells[n_ligne, 6];
                        r.Value = action.Libelle;

                        r = ws.Cells[n_ligne, 7];
                        string pilote = "";
                        pilote = Acces.Donner_Chaine_Liste(action.DirectionPilote, "DIRECTION_METIER", "", true);
                        pilote += (action.Pilote != null) ? "\n" + action.Pilote.Nom + " " + action.Pilote.Prenom : "";
                        r.Value = pilote;

                        r = ws.Cells[n_ligne, 24];
                        r.Value = action.Code.Replace("OPE-", "");
                    }

                    r = ws.Cells[n_ligne, 8];
                    r.Value = Acces.Donner_Chaine_Liste(action.DirectionAssocie, "DIRECTION_METIER", "", true);

                    r = ws.Cells[n_ligne, 9];
                    r.Value = (action.ActionPhare ? "X" : "");
                    if (action.OrdreActionPhare > 0) { r.Value = Acces.Trouver_TableValeur(action.OrdreActionPhare).Valeur; }

                    r = ws.Cells[n_ligne, 10]; //Année 2018
                    r.Interior.Color = Acces.Exister_Valeur(action.AnneeMiseOeuvre, "ANNEE_MO", "2018") ? XlRgbColor.rgbLightBlue : XlRgbColor.rgbWhite;
                    r.Value = action.Mt_2018;
                    r = ws.Cells[n_ligne, 11]; //Année 2019
                    r.Interior.Color = Acces.Exister_Valeur(action.AnneeMiseOeuvre, "ANNEE_MO", "2019") ? XlRgbColor.rgbLightBlue : XlRgbColor.rgbWhite;
                    r.Value = action.Mt_2019;
                    r = ws.Cells[n_ligne, 12]; //Année 2020
                    r.Interior.Color = Acces.Exister_Valeur(action.AnneeMiseOeuvre, "ANNEE_MO", "2020") ? XlRgbColor.rgbLightBlue : XlRgbColor.rgbWhite;
                    r.Value = action.Mt_2020;
                    r = ws.Cells[n_ligne, 13]; //Année 2021
                    r.Interior.Color = Acces.Exister_Valeur(action.AnneeMiseOeuvre, "ANNEE_MO", "2021") ? XlRgbColor.rgbLightBlue : XlRgbColor.rgbWhite;
                    r.Value = action.Mt_2021;
                    r = ws.Cells[n_ligne, 14]; //Année 2022
                    r.Interior.Color = Acces.Exister_Valeur(action.AnneeMiseOeuvre, "ANNEE_MO", "2022") ? XlRgbColor.rgbLightBlue : XlRgbColor.rgbWhite;
                    r.Value = action.Mt_2022;
                    r = ws.Cells[n_ligne, 15]; //Année 2023
                    r.Interior.Color = Acces.Exister_Valeur(action.AnneeMiseOeuvre, "ANNEE_MO", "2023") ? XlRgbColor.rgbLightBlue : XlRgbColor.rgbWhite;
                    r.Value = action.Mt_2023;
                    r = ws.Cells[n_ligne, 16]; //Financement
                    r.Value = action.CoutFinancier;
                    if (action.Mt_Total != null)
                    {
                        if (action.Mt_Total.Length > 0) { r.Value += "\n TOTAL : " + action.Mt_Total + " k€"; }
                    }

                    r = ws.Cells[n_ligne, 17]; //TDS MF
                    r.Value = Acces.Exister_Valeur(action.TSante, "TSANTE", "TS591") ? "X" : "";
                    r.Interior.Color = Acces.Exister_Valeur(action.Priorite_CTS, "PRIO_CTS_591", "", true) ? XlRgbColor.rgbLightBlue : XlRgbColor.rgbWhite;
                    r = ws.Cells[n_ligne, 18]; //TDS Hainaut
                    r.Value = Acces.Exister_Valeur(action.TSante, "TSANTE", "TS592") ? "X" : "";
                    r.Interior.Color = Acces.Exister_Valeur(action.Priorite_CTS, "PRIO_CTS_592", "", true) ? XlRgbColor.rgbLightBlue : XlRgbColor.rgbWhite;
                    r = ws.Cells[n_ligne, 19]; //TDS 62
                    r.Value = Acces.Exister_Valeur(action.TSante, "TSANTE", "TS62") ? "X" : "";
                    r.Interior.Color = Acces.Exister_Valeur(action.Priorite_CTS, "PRIO_CTS_62", "", true) ? XlRgbColor.rgbLightBlue : XlRgbColor.rgbWhite;
                    r = ws.Cells[n_ligne, 20]; //TDS 80
                    r.Value = Acces.Exister_Valeur(action.TSante, "TSANTE", "TS80") ? "X" : "";
                    r.Interior.Color = Acces.Exister_Valeur(action.Priorite_CTS, "PRIO_CTS_80", "", true) ? XlRgbColor.rgbLightBlue : XlRgbColor.rgbWhite;
                    r = ws.Cells[n_ligne, 21]; //TDS 60
                    r.Value = Acces.Exister_Valeur(action.TSante, "TSANTE", "TS60") ? "X" : "";
                    r.Interior.Color = Acces.Exister_Valeur(action.Priorite_CTS, "PRIO_CTS_60", "", true) ? XlRgbColor.rgbLightBlue : XlRgbColor.rgbWhite;
                    r = ws.Cells[n_ligne, 22]; //TDS 02
                    r.Value = Acces.Exister_Valeur(action.TSante, "TSANTE", "TS02") ? "X" : "";
                    r.Interior.Color = Acces.Exister_Valeur(action.Priorite_CTS, "PRIO_CTS_02", "", true) ? XlRgbColor.rgbLightBlue : XlRgbColor.rgbWhite;
                    r = ws.Cells[n_ligne, 23]; //REGION
                    r.Value = Acces.Exister_Valeur(action.TSante, "TSANTE", "REGION") ? "X" : "";
                }
            }

            //Tri des lignes
            Range r_data = ws.Range["A8:Y" + n_ligne];
            r_data.Sort(r_data.Columns[24, Type.Missing], Microsoft.Office.Interop.Excel.XlSortOrder.xlAscending);

            r_data.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

            //Mise en forme
            {
                r_data.WrapText = true; //Renvoie à la ligne
                //Bordures
                Borders border = r_data.Borders;

                border.LineStyle = XlLineStyle.xlContinuous;
                border.Weight = 2d;
                border[XlBordersIndex.xlEdgeLeft].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                border[XlBordersIndex.xlEdgeTop].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                border[XlBordersIndex.xlEdgeBottom].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                border[XlBordersIndex.xlEdgeRight].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                //Alignement
                ws.Columns[2].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                ws.Columns[5].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                ws.Columns[7].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                ws.Columns[8].HorizontalAlignment = XlHAlign.xlHAlignCenter;

                ws.Columns[9].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                ws.Columns[10].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                ws.Columns[11].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                ws.Columns[12].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                ws.Columns[13].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                ws.Columns[14].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                ws.Columns[15].HorizontalAlignment = XlHAlign.xlHAlignCenter;

                ws.Columns[17].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                ws.Columns[18].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                ws.Columns[19].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                ws.Columns[20].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                ws.Columns[21].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                ws.Columns[22].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                ws.Columns[23].HorizontalAlignment = XlHAlign.xlHAlignCenter;

                //Colonnes masquées
                ws.Columns["X"].Hidden = true; //Colonne Code
            }

            //Sauvegarde du fichier
            wb.SaveAs(fichier + ".xlsx");
            wb.ExportAsFixedFormat(Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF, fichier + ".pdf");

            wb.Close(false);
            wk.Close();

            //Fermeture de l'application Excel
            app.Quit();
            app = null;

            Process.Start(fichier + ".xlsx");

        }

        private void btnEditer_Click(object sender, EventArgs e)
        {
            Editer_Fiche();
        }

        void Extrait_Info(TreeNode Nod, ref List<Element> Liste)
        {
            if (Nod.Tag.ToString() == "1")
            {
                Element e = Acces.Trouver_Element(int.Parse(Nod.Name));
                Liste.Add(e);
            }

            foreach (TreeNode nd in Nod.Nodes)
            {
                Extrait_Info(nd, ref Liste);
            }

        }

    }
}
