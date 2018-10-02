using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;
using PATIO.Interfaces;
using PATIO.Classes;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.Diagnostics;

namespace PATIO.Modules
{
    class EditionFiche
    {
        public AccesNet Acces;
        public ctrlConsole Console;
        public WeifenLuo.WinFormsUI.Docking.DockPanel DP;
        public string Chemin;

        public string type_element;
        public int id_element;
        public int id_parent;
        public int ordre=0;
        public Boolean OuvertureAuto = true;

        Microsoft.Office.Interop.Excel.Application app;

        /// <summary>
        /// Edition de la fiche de l'élément transmis
        /// </summary>
        public string Editer_Fiche()
        {
            if (type_element == Acces.type_PLAN.code) { return Editer_Fiche_Plan(); }
            if (type_element == Acces.type_OBJECTIF.code) { return Editer_Fiche_Objectif(); }
            if (type_element == Acces.type_ACTION.code) { return Editer_Fiche_Action(); }
            if (type_element == Acces.type_INDICATEUR.code) { return Editer_Fiche_Indicateur(); }

            return null;
        }

        /// <summary>
        /// Edition de la fiche pour un plan
        /// </summary>
        public string Editer_Fiche_Plan()
        {
            //Création de l'application Excel
            app = new Microsoft.Office.Interop.Excel.Application();
            app.DisplayAlerts = false;

            Plan plan = (Plan)Acces.Trouver_Element(Acces.type_PLAN.id, id_element);

            var modele = Chemin + "\\Modeles\\Fiche_PLAN.xltx";
            var fichier = Chemin + "\\Fichiers\\" + "FP-" + plan.Code + "-" + string.Format("{0:yyMMddHHmmss}", DateTime.Now);

            app.Workbooks.Open(modele);

            Workbooks wk = app.Workbooks;
            Workbook wb = app.ActiveWorkbook;
            Worksheet ws = wb.Sheets[1];
            Range r;

            r = ws.Cells[2, 4];
            r.Value = plan.Libelle;
            r = ws.Cells[3, 4];
            if (plan.Pilote != null) { r.Value = plan.Pilote.Nom + " " + plan.Pilote.Prenom; }
            r = ws.Cells[4, 4];
            r.Value = Acces.Donner_Chaine_Liste_Utilisateur(plan.Equipe); ; //Groupe interne
            r = ws.Cells[5, 4];
            r.Value = plan.GroupeExterne; //Groupe externe
            r = ws.Cells[6, 4];
            r.Value = string.Format("{0:dd/MM/yyyy}", DateTime.Now); //Groupe interne
            r = ws.Cells[6, 14];
            r.Value = plan.Code;

            //Affichage des éléments
            int n_ligne = 10;

            //Efface la zone
            ws.Range["A11:Z10000"].Clear();

            List<Lien> listeLien = Acces.Remplir_ListeLien(Acces.type_PLAN, plan.ID.ToString());
            listeLien.Sort();

            //Passe 1 : les objectifs
            foreach (Lien l in listeLien)
            {
                if(l.element2_type != Acces.type_OBJECTIF.id) { goto Suite1; }

                Objectif obj = (Objectif)Acces.Trouver_Element(Acces.type_OBJECTIF.id, l.element2_id);

                n_ligne++;
                r = ws.Cells[n_ligne, 1];
                r.Value = obj._op;
                r = ws.Cells[n_ligne, 2];
                r.Value = obj.Libelle;

                r = ws.Cells[n_ligne, 22];
                r.Value = obj.Code.Replace("OBJ-","");
                Suite1:;
            }

            //Passe 2 : les actions
            foreach (Lien l in listeLien)
            {
                if (l.element2_type != Acces.type_ACTION.id) { goto Suite2; }

                PATIO.Classes.Action action = (PATIO.Classes.Action)Acces.Trouver_Element(Acces.type_ACTION.id, l.element2_id);

                if(action.TypeAction != TypeAction.ACTION) { goto Suite2; }
                n_ligne++;
                r = ws.Cells[n_ligne, 3];
                r.Value = action.Libelle;

                r = ws.Cells[n_ligne, 4];
                string pilote = "";
                pilote = Acces.Donner_Chaine_Liste(action.DirectionPilote, "DIRECTION_METIER", "", true);
                pilote += (action.Pilote != null) ? "\n" + action.Pilote.Nom + " " + action.Pilote.Prenom : plan.Pilote.Nom + " " + plan.Pilote.Prenom;
                r.Value = pilote;

                r = ws.Cells[n_ligne, 7];
                r.Value = (action.ActionPhare ? "X" : "");
                if (action.OrdreActionPhare > 0) { r.Value = Acces.Trouver_TableValeur(action.OrdreActionPhare).Valeur; }

                r = ws.Cells[n_ligne, 8]; //Année 2018
                r.Interior.Color = Acces.Exister_Valeur(action.AnneeMiseOeuvre, "ANNEE_MO", "2018") ? XlRgbColor.rgbLightBlue : XlRgbColor.rgbWhite;
                r.Value = action.Mt_2018;
                r = ws.Cells[n_ligne, 9]; //Année 2019
                r.Interior.Color = Acces.Exister_Valeur(action.AnneeMiseOeuvre, "ANNEE_MO", "2019") ? XlRgbColor.rgbLightBlue : XlRgbColor.rgbWhite;
                r.Value = action.Mt_2019;
                r = ws.Cells[n_ligne, 10]; //Année 2020
                r.Interior.Color = Acces.Exister_Valeur(action.AnneeMiseOeuvre, "ANNEE_MO", "2020") ? XlRgbColor.rgbLightBlue : XlRgbColor.rgbWhite;
                r.Value = action.Mt_2020;
                r = ws.Cells[n_ligne, 11]; //Année 2021
                r.Interior.Color = Acces.Exister_Valeur(action.AnneeMiseOeuvre, "ANNEE_MO", "2021") ? XlRgbColor.rgbLightBlue : XlRgbColor.rgbWhite;
                r.Value = action.Mt_2021;
                r = ws.Cells[n_ligne, 12]; //Année 2022
                r.Interior.Color = Acces.Exister_Valeur(action.AnneeMiseOeuvre, "ANNEE_MO", "2022") ? XlRgbColor.rgbLightBlue : XlRgbColor.rgbWhite;
                r.Value = action.Mt_2022;
                r = ws.Cells[n_ligne, 13]; //Année 2023
                r.Interior.Color = Acces.Exister_Valeur(action.AnneeMiseOeuvre, "ANNEE_MO", "2023") ? XlRgbColor.rgbLightBlue : XlRgbColor.rgbWhite;
                r.Value = action.Mt_2023;
                r = ws.Cells[n_ligne, 14]; //Financement
                r.Value = action.CoutFinancier;
                if (action.Mt_Total != null)
                {
                    if (action.Mt_Total.Length > 0) { r.Value += "\n TOTAL : " + action.Mt_Total + " k€"; }
                }

                r = ws.Cells[n_ligne, 15]; //TDS MF
                r.Value = Acces.Exister_Valeur(action.TSante, "TSANTE", "TS591") ? "X" : "";
                r.Interior.Color = Acces.Exister_Valeur(action.Priorite_CTS, "PRIO_CTS_591", "", true) ? XlRgbColor.rgbLightBlue : XlRgbColor.rgbWhite;
                r = ws.Cells[n_ligne, 16]; //TDS Hainaut
                r.Value = Acces.Exister_Valeur(action.TSante, "TSANTE", "TS592") ? "X" : "";
                r.Interior.Color = Acces.Exister_Valeur(action.Priorite_CTS, "PRIO_CTS_592", "", true) ? XlRgbColor.rgbLightBlue : XlRgbColor.rgbWhite;
                r = ws.Cells[n_ligne, 17]; //TDS 62
                r.Value = Acces.Exister_Valeur(action.TSante, "TSANTE", "TS62") ? "X" : "";
                r.Interior.Color = Acces.Exister_Valeur(action.Priorite_CTS, "PRIO_CTS_62", "", true) ? XlRgbColor.rgbLightBlue : XlRgbColor.rgbWhite;
                r = ws.Cells[n_ligne, 18]; //TDS 80
                r.Value = Acces.Exister_Valeur(action.TSante, "TSANTE", "TS80") ? "X" : "";
                r.Interior.Color = Acces.Exister_Valeur(action.Priorite_CTS, "PRIO_CTS_80", "", true) ? XlRgbColor.rgbLightBlue : XlRgbColor.rgbWhite;
                r = ws.Cells[n_ligne, 19]; //TDS 60
                r.Value = Acces.Exister_Valeur(action.TSante, "TSANTE", "TS60") ? "X" : "";
                r.Interior.Color = Acces.Exister_Valeur(action.Priorite_CTS, "PRIO_CTS_60", "", true) ? XlRgbColor.rgbLightBlue : XlRgbColor.rgbWhite;
                r = ws.Cells[n_ligne, 20]; //TDS 02
                r.Value = Acces.Exister_Valeur(action.TSante, "TSANTE", "TS02") ? "X" : "";
                r.Interior.Color = Acces.Exister_Valeur(action.Priorite_CTS, "PRIO_CTS_02", "", true) ? XlRgbColor.rgbLightBlue : XlRgbColor.rgbWhite;
                r = ws.Cells[n_ligne, 21]; //REGION
                r.Value = Acces.Exister_Valeur(action.TSante, "TSANTE", "REGION") ? "X" : "";

                r = ws.Cells[n_ligne, 22];
                r.Value = action.Code.Replace("ACT-", "");
                Suite2:;
            }

            //Passe 3 : les opérations
            foreach (Lien l in listeLien)
            {
                if (l.element2_type != Acces.type_ACTION.id) { goto Suite3; }

                PATIO.Classes.Action action = (PATIO.Classes.Action)Acces.Trouver_Element(Acces.type_ACTION.id, l.element2_id);

                if (action.TypeAction != TypeAction.OPERATION) { goto Suite3; }
                n_ligne++;
                r = ws.Cells[n_ligne, 5];
                r.Value = action.Libelle;

                r = ws.Cells[n_ligne, 6];
                string pilote="";
                pilote = Acces.Donner_Chaine_Liste(action.DirectionPilote,"DIRECTION_METIER","",true);
                pilote += (action.Pilote != null)? "\n" + action.Pilote.Nom + " " + action.Pilote.Prenom : plan.Pilote.Nom + " " + plan.Pilote.Prenom;
                r.Value = pilote;

                r = ws.Cells[n_ligne, 7];
                r.Value = (action.ActionPhare ? "X" : "");
                if (action.OrdreActionPhare > 0) { r.Value = Acces.Trouver_TableValeur(action.OrdreActionPhare).Valeur; }

                r = ws.Cells[n_ligne, 8]; //Année 2018
                r.Interior.Color = Acces.Exister_Valeur(action.AnneeMiseOeuvre, "ANNEE_MO", "2018") ? XlRgbColor.rgbLightBlue : XlRgbColor.rgbWhite;
                r.Value = action.Mt_2018;
                r = ws.Cells[n_ligne, 9]; //Année 2019
                r.Interior.Color = Acces.Exister_Valeur(action.AnneeMiseOeuvre, "ANNEE_MO", "2019") ? XlRgbColor.rgbLightBlue : XlRgbColor.rgbWhite;
                r.Value = action.Mt_2019;
                r = ws.Cells[n_ligne, 10]; //Année 2020
                r.Interior.Color = Acces.Exister_Valeur(action.AnneeMiseOeuvre, "ANNEE_MO", "2020") ? XlRgbColor.rgbLightBlue : XlRgbColor.rgbWhite;
                r.Value = action.Mt_2020;
                r = ws.Cells[n_ligne, 11]; //Année 2021
                r.Interior.Color = Acces.Exister_Valeur(action.AnneeMiseOeuvre, "ANNEE_MO", "2021") ? XlRgbColor.rgbLightBlue : XlRgbColor.rgbWhite;
                r.Value = action.Mt_2021;
                r = ws.Cells[n_ligne, 12]; //Année 2022
                r.Interior.Color = Acces.Exister_Valeur(action.AnneeMiseOeuvre, "ANNEE_MO", "2022") ? XlRgbColor.rgbLightBlue : XlRgbColor.rgbWhite;
                r.Value = action.Mt_2022;
                r = ws.Cells[n_ligne, 13]; //Année 2023
                r.Interior.Color = Acces.Exister_Valeur(action.AnneeMiseOeuvre, "ANNEE_MO", "2023") ? XlRgbColor.rgbLightBlue : XlRgbColor.rgbWhite;
                r.Value = action.Mt_2023;
                r = ws.Cells[n_ligne, 14]; //Financement
                r.Value = action.CoutFinancier;
                if (action.Mt_Total != null)
                {
                    if (action.Mt_Total.Length > 0) { r.Value += "\n TOTAL : " + action.Mt_Total + " k€"; }
                }

                r = ws.Cells[n_ligne, 15]; //TDS MF
                r.Value = Acces.Exister_Valeur(action.TSante, "TSANTE", "TS591") ? "X" : "";
                r.Interior.Color = Acces.Exister_Valeur(action.Priorite_CTS, "PRIO_CTS_591", "", true) ? XlRgbColor.rgbLightBlue : XlRgbColor.rgbWhite;
                r = ws.Cells[n_ligne, 16]; //TDS Hainaut
                r.Value = Acces.Exister_Valeur(action.TSante, "TSANTE", "TS592") ? "X" : "";
                r.Interior.Color = Acces.Exister_Valeur(action.Priorite_CTS, "PRIO_CTS_592", "",true) ? XlRgbColor.rgbLightBlue : XlRgbColor.rgbWhite;
                r = ws.Cells[n_ligne, 17]; //TDS 62
                r.Value = Acces.Exister_Valeur(action.TSante, "TSANTE", "TS62") ? "X" : "";
                r.Interior.Color = Acces.Exister_Valeur(action.Priorite_CTS, "PRIO_CTS_62", "",true) ? XlRgbColor.rgbLightBlue : XlRgbColor.rgbWhite;
                r = ws.Cells[n_ligne, 18]; //TDS 80
                r.Value = Acces.Exister_Valeur(action.TSante, "TSANTE", "TS80") ? "X" : "";
                r.Interior.Color = Acces.Exister_Valeur(action.Priorite_CTS, "PRIO_CTS_80", "",true) ? XlRgbColor.rgbLightBlue : XlRgbColor.rgbWhite;
                r = ws.Cells[n_ligne, 19]; //TDS 60
                r.Value = Acces.Exister_Valeur(action.TSante, "TSANTE", "TS60") ? "X" : "";
                r.Interior.Color = Acces.Exister_Valeur(action.Priorite_CTS, "PRIO_CTS_60", "",true) ? XlRgbColor.rgbLightBlue : XlRgbColor.rgbWhite;
                r = ws.Cells[n_ligne, 20]; //TDS 02
                r.Value = Acces.Exister_Valeur(action.TSante, "TSANTE", "TS02") ? "X" : "";
                r.Interior.Color = Acces.Exister_Valeur(action.Priorite_CTS, "PRIO_CTS_02", "",true) ? XlRgbColor.rgbLightBlue : XlRgbColor.rgbWhite;
                r = ws.Cells[n_ligne, 21]; //REGION
                r.Value = Acces.Exister_Valeur(action.TSante, "TSANTE", "REGION") ? "X" : "";

                //Définition de l'ordre : différent d'action car la structure diffère avec les directions métier
                r = ws.Cells[n_ligne, 22]; 
                PATIO.Classes.Action parent = (PATIO.Classes.Action)Acces.Trouver_Element(Acces.type_ACTION.id, l.element1_id);
                string ordre = parent.Code.Replace("ACT-", "") + "-" + string.Format("{0:x3}", l.ordre);
                r.Value = ordre;
                //r.Value = action.Code.Replace("OPE-", "");
                Suite3:;
            }

            //Tri des lignes
            Range r_data = ws.Range["A11:W" + n_ligne];
            r_data.Sort(r_data.Columns[22, Type.Missing], Microsoft.Office.Interop.Excel.XlSortOrder.xlAscending);

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
                ws.Columns[1].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                ws.Columns[4].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                ws.Columns[6].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                ws.Columns[7].HorizontalAlignment = XlHAlign.xlHAlignCenter;

                ws.Columns[8].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                ws.Columns[9].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                ws.Columns[10].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                ws.Columns[11].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                ws.Columns[12].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                ws.Columns[13].HorizontalAlignment = XlHAlign.xlHAlignCenter;

                ws.Columns[15].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                ws.Columns[16].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                ws.Columns[17].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                ws.Columns[18].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                ws.Columns[19].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                ws.Columns[20].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                ws.Columns[21].HorizontalAlignment = XlHAlign.xlHAlignCenter;

                //Colonnes masquées
                ws.Columns["A"].Hidden = true;
                ws.Columns["V"].Hidden = true;
            }

            //Sauvegarde du fichier
            wb.SaveAs(fichier + ".xlsx");
            wb.ExportAsFixedFormat(Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF, fichier + ".pdf");

            wb.Close(false);
            wk.Close();

            //Fermeture de l'application Excel
            app.Quit();
            app = null;

            if (OuvertureAuto) { OuvertureFichier(fichier + ".pdf"); }

            return fichier;
        }

        /// <summary>
        /// Edition de la fiche pour un objectif
        /// </summary>
        public string Editer_Fiche_Objectif()
        {
            //Création de l'application Excel
            app = new Microsoft.Office.Interop.Excel.Application();
            app.DisplayAlerts = false;

            Objectif obj = (Objectif)Acces.Trouver_Element(Acces.type_OBJECTIF.id, id_element);

            var modele = Chemin + "\\Modeles\\Fiche_OBJECTIF.xltx";
            var fichier = Chemin + "\\Fichiers\\" + "FO-" + obj.Code;

            app.Workbooks.Open(modele);

            Workbooks wk = app.Workbooks;
            Workbook wb = app.ActiveWorkbook;
            Worksheet ws = wb.Sheets[1];
            Range r;

            r = ws.Cells[2, 2];
            r.Value = obj.Code;
            r = ws.Cells[3, 2];
            r.Value = obj.Libelle;
            r = ws.Cells[4, 2];
            if (obj.Pilote != null) { r.Value = obj.Pilote.Nom + " " + obj.Pilote.Prenom; }
            r = ws.Cells[6, 2];
            r.Value = Conversion(obj.Description);

            //Sauvegarde du fichier
            wb.SaveAs(fichier + ".xlsx");
            wb.ExportAsFixedFormat(Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF, fichier + ".pdf");

            wb.Close(false);
            wk.Close();

            //Fermeture de l'application Excel
            app.Quit();
            app = null;

            if (OuvertureAuto) { OuvertureFichier(fichier + ".pdf"); }

            return fichier;
        }

        /// <summary>
        /// Edition de la fiche pour une action
        /// </summary>
        public string Editer_Fiche_Action()
        {
            //Création de l'application Excel
            app = new Microsoft.Office.Interop.Excel.Application();
            app.DisplayAlerts = false;

            PATIO.Classes.Action action = (PATIO.Classes.Action)Acces.Trouver_Element(Acces.type_ACTION.id, id_element);

            PATIO.Classes.Action parent = (PATIO.Classes.Action)Acces.Trouver_Element(Acces.type_ACTION.id, id_parent);

            string Code = action.Code;

            //Correction du fichier en cas d'opération -> pour définir le bon ordre
            if (action.TypeAction == TypeAction.OPERATION) { Code = parent.Code + "-" + string.Format("{0:x3}", ordre); }

            var modele = Chemin + "\\Modeles\\Fiche_ACTION.xltx";
            var fichier = Chemin + "\\Fichiers\\" + "FA-" + Code;

            app.Workbooks.Open(modele);

            Workbooks wk = app.Workbooks;
            Workbook wb = app.ActiveWorkbook;
            Worksheet ws = wb.Sheets[1];
            Range r;

            r = ws.Cells[2, 2];
            r.Value = action.Code;
            r = ws.Cells[3, 2];
            r.Value = action.Libelle;
            r = ws.Cells[4, 2];
            if (action.Pilote != null) { r.Value = action.Pilote.Nom + " " + action.Pilote.Prenom; }
            r = ws.Cells[6, 2];
            r.Value = Conversion( action.Description);

            r = ws.Cells[7, 2]; //Public cible
            r.Value = Acces.Donner_Chaine_Liste(action.PublicCible, "PUBLIC_CIBLE");
            r = ws.Cells[8, 2]; //Territoires
            r.Value = action.Territoire;
            r = ws.Cells[9, 2]; //Partenaires institutionnels
            r.Value = Acces.Donner_Chaine_Liste(action.Partenaire, "PARTENAIRE_INSTITU");
            r = ws.Cells[10, 2]; //Partenaires institutionnels
            r.Value = Acces.Donner_Chaine_Liste(action.Usager, "PARTENAIRE_USAGER");

            r = ws.Cells[12, 2]; //Structures porteuses
            r.Value = Acces.Donner_Chaine_Liste(action.StructurePorteuse, "STRUCTURE_PORTEUSE");
            r = ws.Cells[13, 2]; //Acteurs de santé
            r.Value = Acces.Donner_Chaine_Liste(action.Acteur, "ACTEUR_SANTE");
            r = ws.Cells[14, 2]; //Leviers
            r.Value = Acces.Donner_Chaine_Liste(action.Partenaire, "LEVIER");
            r = ws.Cells[15, 2]; //Cout financier
            r.Value = action.CoutFinancier;
            r = ws.Cells[16, 2]; //Autrs financements

            r = ws.Cells[18, 2]; //Résultats
            r.Value = action.ResultatLivrable;
            r = ws.Cells[19, 2]; //Impact
            r.Value = action.NbPersImpact;
            r = ws.Cells[20, 2]; //Acteurs mobilisés
            r.Value = action.NbActeurMobilise;
            r = ws.Cells[21, 2]; //Indicateur de résultat
            r.Value = action.IndicResultat;
            r = ws.Cells[22, 2]; //Indicateur de moyens
            r.Value = action.IndicMoyen;

            r = ws.Cells[24, 2]; //Années de mise en oeuvre
            r.Value = Acces.Donner_Chaine_Liste(action.AnneeMiseOeuvre, "ANNEE_MO");

            r = ws.Cells[26, 2]; //Directions pilote
            r.Value = Acces.Donner_Chaine_Liste(action.DirectionPilote, "DIRECTION_METIER","",true);
            r = ws.Cells[27, 2]; //Directions associées
            r.Value = Acces.Donner_Chaine_Liste(action.DirectionAssocie, "DIRECTION_METIER","",true);

            r = ws.Cells[29, 2]; //Lien avec les autres plans
            r.Value = Acces.Donner_Chaine_Liste(action.LienPlan, "LIEN_PLAN");
            r = ws.Cells[30, 2]; //Lien avec les parcours
            r.Value = Acces.Donner_Chaine_Liste(action.LienParcours, "LIEN_PARCOURS");

            r = ws.Cells[32, 2]; //Lien avec les parcours
            r.Value = Acces.Donner_Chaine_Liste(action.TSante, "TSANTE");

            r = ws.Cells[34, 2]; //CTS 591
            r.Value = Acces.Donner_Chaine_Liste(action.Priorite_CTS, "PRIORITE_CTS", "PRIO_CTS_591");
            r = ws.Cells[35, 2]; //CTS 592
            r.Value = Acces.Donner_Chaine_Liste(action.Priorite_CTS, "PRIORITE_CTS", "PRIO_CTS_592");
            r = ws.Cells[36, 2]; //CTS 62
            r.Value = Acces.Donner_Chaine_Liste(action.Priorite_CTS, "PRIORITE_CTS", "PRIO_CTS_62");
            r = ws.Cells[37, 2]; //CTS 80
            r.Value = Acces.Donner_Chaine_Liste(action.Priorite_CTS, "PRIORITE_CTS", "PRIO_CTS_80");
            r = ws.Cells[38, 2]; //CTS 60
            r.Value = Acces.Donner_Chaine_Liste(action.Priorite_CTS, "PRIORITE_CTS", "PRIO_CTS_60");
            r = ws.Cells[39, 2]; //CTS 02
            r.Value = Acces.Donner_Chaine_Liste(action.Priorite_CTS, "PRIORITE_CTS", "PRIO_CTS_02");

            //Sauvegarde du fichier
            wb.SaveAs(fichier + ".xlsx");
            wb.ExportAsFixedFormat(Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF, fichier + ".pdf");

            wb.Close(false);
            wk.Close();

            //Fermeture de l'application Excel
            app.Quit();
            app = null;

            if (OuvertureAuto) { OuvertureFichier(fichier + ".pdf"); }


            return fichier;
        }

        /// <summary>
        /// Edition de la fiche pour un indicateur
        /// </summary>
        public string Editer_Fiche_Indicateur()
        {
            //Création de l'application Excel
            app = new Microsoft.Office.Interop.Excel.Application();
            app.DisplayAlerts = false;

            Indicateur indic = (Indicateur)Acces.Trouver_Element(Acces.type_INDICATEUR.id, id_element);

            var modele = Chemin + "\\Modeles\\Fiche_INDICATEUR.xltx";
            var fichier = Chemin + "\\Fichiers\\" + "FI-" + indic.Code;

            app.Workbooks.Open(modele);

            Workbooks wk = app.Workbooks;
            Workbook wb = app.ActiveWorkbook;
            Worksheet ws = wb.Sheets[1];
            Range r;

            r = ws.Cells[2, 2];
            r.Value = indic.Code;
            r = ws.Cells[3, 2];
            r.Value = indic.Libelle;
            r = ws.Cells[4, 2];
            //if (indic.Pilote != null) { r.Value = indic.Pilote.Nom + " " + indic.Pilote.Prenom; }
            r = ws.Cells[6, 2];
            //r.Value = Conversion(indic.Description);

            //Sauvegarde du fichier
            wb.SaveAs(fichier + ".xlsx");
            wb.ExportAsFixedFormat(Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF, fichier + ".pdf");

            wb.Close(false);
            wk.Close();

            //Fermeture de l'application Excel
            app.Quit();
            app = null;

            if (OuvertureAuto) { OuvertureFichier(fichier + ".pdf"); }

            return fichier;
        }

        public void OuvertureFichier(string fichier)
        {
            //Ouverture du fichier dans l'application
            Process.Start(fichier);
        }

        string Conversion(string texte)
        {
            string txt = "";
            Encoding ascii = Encoding.UTF7;
            Encoding utf8 = Encoding.UTF8;

            if(texte == null) { return ""; }

            byte[] utf8code = utf8.GetBytes(texte);
            byte[] asciicode = Encoding.Convert(utf8, ascii, utf8code);
            char[] asciichars = new char[ascii.GetCharCount(asciicode, 0, asciicode.Length)];
            ascii.GetChars(asciicode, 0, asciicode.Length, asciichars, 0);
            txt = new string(asciichars);

            return txt;
        }
    }
}
