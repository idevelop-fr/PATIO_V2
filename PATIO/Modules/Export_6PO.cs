using System.Collections.Generic;
using PATIO.Classes;
using Microsoft.Office.Interop.Excel;
using PATIO.Interfaces;
using System.Windows.Forms;

namespace PATIO.Modules
{
    public class Export_6PO
    {
        public AccesNet Acces;
        public ctrlConsole Console;

        public string Chemin;
        public Plan plan;
        public List<Lien> listeLien;

        List<Objectif> lObj = new List<Objectif>();
        Microsoft.Office.Interop.Excel.Application app;

        //Exportation de l'ensemble des éléments d'un plan
        public void Exporter6PO()
        {
            //Création de l'application Excel
            app = new Microsoft.Office.Interop.Excel.Application();
            app.DisplayAlerts = false;

            Console.Ajouter("Export du plan...");
            Console.Ajouter(plan.NiveauPlan.ToString());

            //Extraction des liens
            listeLien = Acces.Remplir_ListeLien(Acces.type_PLAN, plan.ID.ToString());

            //Exportation de la hiérarchie
            switch (plan.NiveauPlan)
            {
                case NiveauPlan.Niveau_2:
                    {
                        //Pas d'export de la hiérarchie de plan
                        //ExportPlan_N2();
                        break;
                    }
                case NiveauPlan.Niveau_3:
                    {
                        Console.Ajouter("->Plan niveau 3");
                        ExportPlan_N3();
                        break;
                    }
                case NiveauPlan.Niveau_4:
                    {
                        Console.Ajouter("->Plan niveau 4");
                        ExportPlan_N4();
                        break;
                    }
                case NiveauPlan.Niveau_5:
                    {
                        Console.Ajouter("->Plan niveau 5");
                        ExportPlan_N5();
                        break;
                    }
            }

            //Exportation des objectifs
            Console.Ajouter("->Export des objectifs...");
            ExportObjectif();

            //Exportation des actions
            Console.Ajouter("->Export des actions...");
            ExportAction();

            //Exportation des utilisateurs
            Console.Ajouter("->Export des utilisateurs...");
            ExportUtilisateur();

            //Exportation des tables de valeurs -> référentiels
            Console.Ajouter("->Export des tables de valeurs...");
            ExportTableValeur();

            Console.Ajouter("...Fin Export Plan");

            //Fermeture de l'application Excel
            app.Quit();
            app = null;
        }

        //Exportation de la hiérarchie de niveau 2 (inexistante avec l'évolution des sous-actions
        void ExportPlan_N2()
        {
            var fichier = Chemin + "\\Fichiers\\" + "PLAN-" + plan.Code;
            Console.Ajouter("->Cible : " + fichier);

            app.Workbooks.Add();

            Workbooks wk = app.Workbooks;
            Workbook wb = app.ActiveWorkbook;
            Worksheet ws = wb.Sheets[1];
            Range r;
            int n = 1;
            int niveau = 2;

            //Renommage de la feuille 1
            ws.Name = "Hiérarchies";

            //Entêtes
            for (int i = 0; i < niveau; i++)
            {
                r = ws.Cells[n, 3 * i + 1];
                r.Value = "Libelle_VN";
                r = ws.Cells[n, 3 * i + 2];
                r.Value = "Code_VN";
                r = ws.Cells[n, 3 * i + 3];
                r.Value = "Description_VN";
            }

            //Ligne explicative
            n++;
            for (int i = 1; i < niveau; i++)
            {
                r = ws.Cells[n, 3 * i + 1];
                r.Value = "Niveau " + i + "/" + niveau;
                r = ws.Cells[n, 3 * i + 2];
                r.Value = "HIER_PLAN_" + niveau + "NIV_" + i;
            }
            r = ws.Cells[n, 1];
            r.Value = "Plan/Programme";

            //Liste des objectifs de 1er niveau
            Console.Ajouter("->Nb lignes :" + listeLien.Count.ToString());
            foreach (var l in listeLien)
            {
                if (l.element2_type == Acces.type_OBJECTIF.id && l.element1_type == Acces.type_PLAN.id)
                {
                    Objectif Obj =(Objectif) Acces.Trouver_Element(Acces.type_OBJECTIF.id, l.element2_id);

                    n++;
                    r = ws.Cells[n, 1];
                    r.Value = Obj.Libelle;
                    r = ws.Cells[n, 2];
                    r.Value = Obj.Code;

                    lObj.Add(Obj);
                }
            }

            System.IO.File.Delete(fichier + ".xlsx");

            wb.SaveAs(fichier);

            wb.Close(false);
            wk.Close();
            app.Quit();
        }

        //Exportation de la hiérarchie de niveau 3
        //Il y a 2 niveaux d'objectifs : l'un est intégré à la hiérachie de plan
        void ExportPlan_N3()
        {
            var fichier = Chemin + "\\Fichiers\\" + "PLAN-" + plan.Code;
            Console.Ajouter("->Cible : " + fichier);

            app.Workbooks.Add();

            Workbooks wk = app.Workbooks;
            Workbook wb = app.ActiveWorkbook;
            Worksheet ws = wb.Sheets[1];
            Range r;
            int n = 1;
            int niveau = 3;

            //Renommage de la feuille 1
            ws.Name = "Hiérarchies";

            //Entêtes
            for (int i = 0; i < niveau; i++)
            {
                r = ws.Cells[n, 3 * i + 1];
                r.Value = "Libelle_VN";
                r = ws.Cells[n, 3 * i + 2];
                r.Value = "Code_VN";
                r = ws.Cells[n, 3 * i + 3];
                r.Value = "Description_VN";
            }

            //Ligne explicative
            n++;
            for (int i = 1; i < niveau; i++)
            {
                r = ws.Cells[n, 3 * i + 1];
                r.Value = "Niveau " + i + "/" + niveau;
                r = ws.Cells[n, 3 * i + 2];
                r.Value = "HIER_PLAN_" + niveau + "NIV_" + i;
            }
            r = ws.Cells[n, 1];
            r.Value = "Plan/Programme";

            //Liste des objectifs de 1er niveau
            Console.Ajouter("->Nb lignes :" + listeLien.Count.ToString());
            foreach (var l in listeLien)
            {
                //On cherche un objectif (element2_type) qui n'est pas un objectif opérationnel
                //et le parent de l'objectif est le plan
                if (l.element1_type == Acces.type_PLAN.id && l.element2_type == Acces.type_OBJECTIF.id)
                {
                    Objectif Obj = (Objectif)Acces.Trouver_Element(Acces.type_OBJECTIF.id, l.element2_id);

                    if (Obj.TypeObjectif != TypeObjectif.OPERATIONNEL)
                    {
                        n++;
                        r = ws.Cells[n, 1];
                        r.Value = Obj.Libelle;
                        r = ws.Cells[n, 2];
                        r.Value = Obj.Code;

                        /*r = ws.Cells[n, 1];
                        r.Value = plan.Libelle;
                        r = ws.Cells[n, 2];
                        r.Value = plan.Code;

                        r = ws.Cells[n, 4];
                        r.Value = Obj.Libelle;
                        r = ws.Cells[n, 5];
                        r.Value = Obj.Code;*/

                        lObj.Add(Obj);
                    }
                }
            }

            System.IO.File.Delete(fichier + ".xlsx");

            System.IO.File.Delete(fichier);

            wb.SaveAs(fichier);

            wb.Close();
            wk.Close();
        }

        //Exportation de la hiérarchie de niveau 4
        //Il y a 3 niveaux d'objectifs : les 2 premiers sont intégrés à la hiérachie de plan
        void ExportPlan_N4()
        {
            var fichier = Chemin + "\\Fichiers\\" + "PLAN-" + plan.Code;
            Console.Ajouter("->Cible : " + fichier);

            app.Workbooks.Add();

            Workbooks wk = app.Workbooks;
            Workbook wb = app.ActiveWorkbook;
            Worksheet ws = wb.Sheets[1];
            Range r;
            int n = 1;
            int niveau = 4;

            //Renommage de la feuille 1
            ws.Name = "Hiérarchies";

            //Entêtes
            for (int i = 0; i < niveau; i++)
            {
                r = ws.Cells[n, 3 * i + 1];
                r.Value = "Libelle_VN";
                r = ws.Cells[n, 3 * i + 2];
                r.Value = "Code_VN";
                r = ws.Cells[n, 3 * i + 3];
                r.Value = "Description_VN";
            }

            //Ligne explicative
            n++;
            for (int i = 1; i < niveau; i++)
            {
                r = ws.Cells[n, 3 * i + 1];
                r.Value = "Niveau " + i + "/" + niveau;
                r = ws.Cells[n, 3 * i + 2];
                r.Value = "HIER_PLAN_" + niveau + "NIV_" + i;
            }
            r = ws.Cells[n, 1];
            r.Value = "Plan/Programme";

            //Liste des objectifs de 1er niveau et 2ème niveau
            Console.Ajouter("->Nb lignes : " + listeLien.Count.ToString());

            foreach (var l in listeLien)
            {
                //l'élément principal est un objectif ainsi que son parent
                if (l.element1_type == Acces.type_OBJECTIF.id && l.element2_type == Acces.type_OBJECTIF.id)
                {
                    Objectif Obj2 = (Objectif)Acces.Trouver_Element(Acces.type_OBJECTIF.id, l.element2_id);

                    //On exclut les objectifs opérationnels sensés correspondre au niveau Objectif de 6PO
                    if (Obj2.TypeObjectif != TypeObjectif.OPERATIONNEL)
                    {
                        Objectif Obj1 = (Objectif)Acces.Trouver_Element(Acces.type_OBJECTIF.id, l.element1_id); //Parent
                        n++;
                        r = ws.Cells[n, 1];
                        r.Value = Obj1.Libelle;
                        r = ws.Cells[n, 2];
                        r.Value = Obj1.Code;

                        r = ws.Cells[n, 4];
                        r.Value = Obj2.Libelle;
                        r = ws.Cells[n, 5];
                        r.Value = Obj2.Code;
                        /*
                        r = ws.Cells[n, 1];
                        r.Value = plan.Libelle;
                        r = ws.Cells[n, 2];
                        r.Value = plan.Code;

                        r = ws.Cells[n, 4];
                        r.Value = Obj1.Libelle;
                        r = ws.Cells[n, 5];
                        r.Value = Obj1.Code;

                        r = ws.Cells[n, 7];
                        r.Value = Obj2.Libelle;
                        r = ws.Cells[n, 8];
                        r.Value = Obj2.Code;*/

                        lObj.Add(Obj2);
                    }
                }
            }

            System.IO.File.Delete(fichier + ".xlsx");
            wb.SaveAs(fichier);

            wb.Close();
            wk.Close();
        }

        //Exportation de la hiérarchie de niveau 5
        void ExportPlan_N5()
        {
            var fichier = Chemin + "\\Fichiers\\" + "PLAN-" + plan.Code;
            Console.Ajouter("->Cible : " + fichier);

            app.Workbooks.Add();

            Workbooks wk = app.Workbooks;
            Workbook wb = app.ActiveWorkbook;
            Worksheet ws = wb.Sheets[1];
            Range r;
            int n = 1;
            int niveau = 5;

            //Renommage de la feuille 1
            ws.Name = "Hiérarchies";

            //Entêtes
            for (int i = 0; i < niveau; i++)
            {
                r = ws.Cells[n, 3 * i + 1];
                r.Value = "Libelle_VN";
                r = ws.Cells[n, 3 * i + 2];
                r.Value = "Code_VN";
                r = ws.Cells[n, 3 * i + 3];
                r.Value = "Description_VN";
            }

            //Ligne explicative
            n++;
            for (int i = 1; i < niveau; i++)
            {
                r = ws.Cells[n, 3 * i + 1];
                r.Value = "Niveau " + i + "/" + niveau;
                r = ws.Cells[n, 3 * i + 2];
                r.Value = "HIER_PLAN_" + niveau + "NIV_" + i;
            }
            r = ws.Cells[n, 1];
            r.Value = "Plan/Programme";

            //Liste des objectifs de 1er niveau et 2ème niveau
            Console.Ajouter("->Nb lignes : " + listeLien.Count.ToString());
            foreach (var l1 in listeLien)
            {
                if (l1.element2_type == Acces.type_OBJECTIF.id 
                    && l1.element1_type == Acces.type_PLAN.id)
                {
                    Objectif Obj1 = (Objectif) Acces.Trouver_Element(Acces.type_OBJECTIF.id,l1.element2_id);
                    lObj.Add(Obj1);

                    foreach (var l2 in listeLien)
                    {
                        if (l2.element1_id == l1.element2_id 
                            && l2.element1_type == Acces.type_OBJECTIF.id 
                            && l2.element2_type == Acces.type_OBJECTIF.id)
                        {
                            Objectif Obj2 =(Objectif) Acces.Trouver_Element(Acces.type_OBJECTIF.id,l2.element2_id);

                            n++;
                            r = ws.Cells[n, 1];
                            r.Value = Obj1.Libelle;
                            r = ws.Cells[n, 2];
                            r.Value = Obj1.Code;
                            r = ws.Cells[n, 4];
                            r.Value = Obj2.Libelle;
                            r = ws.Cells[n, 5];
                            r.Value = Obj2.Code;

                            lObj.Add(Obj2);
                        }
                    }
                }
            }

            System.IO.File.Delete(fichier + ".xlsx");

            wb.SaveAs(fichier);

            wb.Close();
            wk.Close();
        }

        //Exportation de la liste des objectifs d'un plan -> Il s'agit de la liste des actions
        void ExportObjectif()
        {
            var fichier = Chemin + "\\Fichiers\\" + "OBJ-" + plan.Code;

            Workbooks wk = app.Workbooks;
            Workbook wb = app.Workbooks.Add();

            //Création des feuilles
            int nb_feuilles = wb.Sheets.Count;

            Worksheet ws1 = wb.Sheets.Add(); ws1.Name = "ACT-";
            Worksheet ws2 = wb.Sheets.Add(After: ws1); ws2.Name = "RAT-";
            Worksheet ws3 = wb.Sheets.Add(After: ws2); ws3.Name = "EQU-";
            Worksheet ws4 = wb.Sheets.Add(After: ws3); ws4.Name = "ATT-";
            Worksheet ws5 = wb.Sheets.Add(After: ws4); ws5.Name = "PLA-";
            Worksheet ws6 = wb.Sheets.Add(After: ws5); ws6.Name = "IND-";
            Worksheet ws7 = wb.Sheets.Add(After: ws6); ws7.Name = "IND-PLAN";

            //Suppression des feuilles déjà existantes
            for (var i = nb_feuilles + 7; i > 7; i--) 
            {
                Worksheet w = wb.Sheets[i];
                w.Delete();
            }

            Range r;
            int n1 = 1; int n2 = 1; int n3 = 1; int n4 = 1;
            //int n5 = 1;
            //int n6 = 1; int n7 = 1;
            List<Objectif> Liste = new List<Objectif>();

            //Création des entêtes
            Entete_Objectif(ws1);
            Entete_Objectif(ws2);
            Entete_Objectif(ws3);
            Entete_Objectif(ws4);
            Entete_Objectif(ws5);
            Entete_Objectif(ws6);
            Entete_Objectif(ws7);

            //Liste des objectifs n'ayant pas été intégrés dans la structure
            //Onglet ACT + RAT
            foreach (var l in listeLien)
            {
                if (l.element2_type == Acces.type_OBJECTIF.id)
                    //if (l.element1_type == Acces.type_OBJECTIF.id && l.element2_type == Acces.type_ACTION.id)
                {
                    //PATIO.Classes.Action action = (PATIO.Classes.Action)Acces.Trouver_Element(Acces.type_ACTION.id, l.element2_id);
                    Objectif Obj = (Objectif) Acces.Trouver_Element(Acces.type_OBJECTIF.id, l.element2_id);
                    Objectif Obj2 =(Objectif) Acces.Trouver_Element(Acces.type_OBJECTIF.id, l.element1_id);

                    //Onglet 1: ACT-
                    n1++;
                    r = ws1.Cells[n1, 1];
                    r.Value = Obj.Code;
                    r = ws1.Cells[n1, 2];
                    r.Value = Obj.Libelle.Substring(0, System.Math.Min(Obj.Libelle.Length, 250));
                    r = ws1.Cells[n1, 3];
                    try { r.Value = Obj.Pilote.Code; } catch { }
                    r = ws1.Cells[n1, 4];
                    r.Value = Acces.Trouver_TableValeur_6PO("STATUT", (int) Obj.Statut); //"A débuter";
                    r = ws1.Cells[n1, 5];
                    r.Value = string.Format("{0:dd/MM/yyyy}", Obj.DateDebut);
                    r = ws1.Cells[n1, 6];
                    r.Value = string.Format("{0:dd/MM/yyyy}", Obj.DateFin);
                    r = ws1.Cells[n1, 7];
                    r.Value = Obj.Description;
                    r = ws1.Cells[n1, 8];
                    r.Value = Obj2.Code;

                    Liste.Add(Obj); //Ajout de l'objectif pour la suite de l'export

                    //Onglet 2 : RAT- A priori cet onglet ne sert pas pour les objectifs
                    n2++;
                    /*r = ws2.Cells[n2, 1];
                    r.Value = action.Code;
                    r = ws2.Cells[n2, 2];
                    r.Value = "HIER_HDF";
                    r = ws2.Cells[n2, 3];
                    r.Value = "REGION";
                    r = ws2.Cells[n2, 4];
                    r.Value = "REGION";*/
                }
            }

            //Onglet RAT : complément avec les référentiels
            AjouteRattachementObjectif(Liste, ref n2, ref ws2);

            //Onglet EQU : Equipe
            AjouteEquipeObjectif(Liste, ref n3, ref ws3);

            //Onglet ATT : Attributs
            AjouteAttributObjectif(Liste, ref n4, ref ws4);

            if (System.IO.File.Exists(fichier + ".xls")) { System.IO.File.Delete(fichier + ".xls"); }

            wb.SaveAs(fichier + ".xls");
            wb.SaveAs(fichier + ".xls", XlFileFormat.xlExcel8);

            wb.Close();
            wk.Close();
        }

        //Ajoute les éléments relatifs aux attributs
        void AjouteAttributObjectif(List<Objectif> Liste, ref int n, ref Worksheet ws)
        {
            Range r;
            foreach (Objectif obj in Liste)
            {
                Element e = new Element() { Acces = Acces, };
                e = obj.Déconstruire();

                foreach (dElement d in e.Liste)
                {
                    string attribut = Acces.Trouver_Attribut_6PO(Acces.type_ACTION, d.Attribut_Code);
                    string valeur = Acces.Trouver_TableValeur_6PO(d.Attribut_Code, d.Valeur);

                    if (!(d.Valeur is null))
                    {
                        if (valeur.Length == 0)
                        {
                            if (d.Valeur.Length == 0)
                            { attribut = ""; } //Sans valeur on n'ajoute pas
                            else
                            {
                                switch (attribut)
                                {
                                    case "CHEF_DE_PROJET":
                                        {
                                            Utilisateur user = (Utilisateur)Acces.Trouver_Element(Acces.type_UTILISATEUR.id, int.Parse(d.Valeur));
                                            valeur = user.Code;
                                            if (valeur.Contains("[")) { valeur = ""; }
                                            break;
                                        }

                                    default:
                                        {
                                            valeur = d.Valeur;
                                            break;
                                        }
                                }
                            }
                        }

                        if (attribut.Length > 0 && valeur.Length > 0)
                        {
                            n++;
                            r = ws.Cells[n, 1];
                            r.Value = obj.Code;
                            r = ws.Cells[n, 2];
                            r.Value = attribut;
                            r = ws.Cells[n, 3];
                            r.Value = valeur; //Afficher la valeur de la table des valeurs correspondante
                        }
                    }
                }
            }
        }

        //Ajoute les informations relatives à l'équipe
        void AjouteEquipeObjectif(List<Objectif> Liste, ref int n, ref Worksheet ws)
        {
            Range r;
            List<Utilisateur> Liste_Membre = new List<Utilisateur>();
            foreach (Objectif obj in Liste)
            {
                //Co-pilote
                Liste_Membre = Acces.Donner_ListeEquipeMembre(obj.ID, "ROLE_6PO_COPILOTE");
                foreach (Utilisateur u in Liste_Membre)
                {
                    n++;
                    r = ws.Cells[n, 1];
                    r.Value = obj.Code;
                    r = ws.Cells[n, 2];
                    r.Value = "Co-Pilote";
                    r = ws.Cells[n, 3];
                    r.Value = u.Code;
                }

                //Manager
                Liste_Membre = Acces.Donner_ListeEquipeMembre(obj.ID, "ROLE_6PO_MANAGER");
                foreach (Utilisateur u in Liste_Membre)
                {
                    n++;
                    r = ws.Cells[n, 1];
                    r.Value = obj.Code;
                    r = ws.Cells[n, 2];
                    r.Value = "Manager";
                    r = ws.Cells[n, 3];
                    r.Value = u.Code;
                }

                //Consultation
                Liste_Membre = Acces.Donner_ListeEquipeMembre(obj.ID, "ROLE_6PO_CONSULTATION");
                foreach (Utilisateur u in Liste_Membre)
                {
                    n++;
                    r = ws.Cells[n, 1];
                    r.Value = obj.Code;
                    r = ws.Cells[n, 2];
                    r.Value = "Consultation";
                    r = ws.Cells[n, 3];
                    r.Value = u.Code;
                }
            }
        }

        //Ajoute les rattachements aux référentiels
        void AjouteRattachementObjectif(List<Objectif> Liste, ref int n, ref Worksheet ws)
        {/*
            foreach (Objectif obj in Liste)
            {
                Element e = new Element() { Acces = Acces, };
                e = obj.Déconstruire();

                Console.Ajouter("[OBJECTIF] " + obj.Code);
                foreach (dElement d in e.Liste)
                {
                    string hierarchie = "";
                    string Niveau = "";
                    string ValeurNiveau = "";
                    Console.Ajouter("[-->] " + d.Attribut_Code);

                    //Traitement de chaque référentiel
                    switch (d.Attribut_Code)
                    {
                        case "ANALYSE_QUALITATIVE":
                            {
                                n++;
                                hierarchie = "PUBLIC_CIBLE";
                                Niveau = hierarchie;
                                ValeurNiveau = Acces.Trouver_TableValeur_6PO(hierarchie, d.Valeur);
                                break;
                            }
                    }

                    //Ajout des informations dans le fichier
                    if (ValeurNiveau.Trim().Length > 0)
                    {
                        Range r;
                        r = ws.Cells[n, 1];
                        r.Value = obj.Code;
                        r = ws.Cells[n, 2];
                        r.Value = hierarchie; //Hiérarchie
                        r = ws.Cells[n, 3];
                        r.Value = Niveau; //Niveau
                        r = ws.Cells[n, 4];
                        r.Value = ValeurNiveau; //Valeur de niveau
                    }
                }
            }*/
        }

        //Export de la liste des actions d'un plan -> Il s'agit de la liste des opérations
        void ExportAction()
        {
            string fichier =Chemin + "\\Fichiers\\" + "ACT-" + plan.Code;

            Workbooks wk = app.Workbooks;
            Workbook wb = app.Workbooks.Add();

            //Création des feuilles
            int nb_feuilles = wb.Sheets.Count;

            Worksheet ws1 = wb.Sheets.Add(); ws1.Name = "PRJ-";
            Worksheet ws2 = wb.Sheets.Add(After: ws1); ws2.Name = "RAT-";
            Worksheet ws3 = wb.Sheets.Add(After: ws2); ws3.Name = "EQU-";
            Worksheet ws4 = wb.Sheets.Add(After: ws3); ws4.Name = "ATT-";
            Worksheet ws5 = wb.Sheets.Add(After: ws4); ws5.Name = "PLA-";
            Worksheet ws6 = wb.Sheets.Add(After: ws5); ws6.Name = "IND-";
            Worksheet ws7 = wb.Sheets.Add(After: ws6); ws7.Name = "IND-PLAN";

            //Suppression des feuilles déjà existantes
            for (var i = nb_feuilles + 7; i > 7; i--) 
            {
                Worksheet w = wb.Sheets[i];
                w.Delete();
            }

            Range r;
            int n1 = 1; int n2 = 1; int n3 = 1; int n4 = 1;
            //int n5 = 1;
            //int n6 = 1; int n7 = 1;

            List<PATIO.Classes.Action> Liste = new List<PATIO.Classes.Action>();

            //Création des entêtes
            {
                Entete_Action(ws1);
                Entete_Action(ws2);
                Entete_Action(ws3);
                Entete_Action(ws4);
                Entete_Action(ws5);
                Entete_Action(ws6);
                Entete_Action(ws7);
            }

            //Détermine les paramètres de rattachement
            string Niveau = ""; string ValeurNiveau = "";
            Donner_NiveauValeur6PO(plan, ref Niveau, ref ValeurNiveau);

            //Liste des objectifs n'ayant pas été intégrés dans la structure
            //Onglet PRJ + RAT
            foreach (var l in listeLien)
            {
                if (l.element2_type == Acces.type_ACTION.id)
                    //if (l.element1_type == Acces.type_ACTION.id && l.element2_type == Acces.type_ACTION.id)
                {
                    PATIO.Classes.Action action1 = (PATIO.Classes.Action)Acces.Trouver_Element(Acces.type_ACTION.id, l.element1_id);
                    PATIO.Classes.Action action2 =(PATIO.Classes.Action) Acces.Trouver_Element(Acces.type_ACTION.id, l.element2_id);

                    if(action2 is null) { MessageBox.Show("id lien : " + l.ID.ToString(), "Action 2 null"); }
                    //Onglet 1: ACT-
                    n1++;
                    r = ws1.Cells[n1, 1];
                    r.Value = action2.Code;
                    r = ws1.Cells[n1, 2];
                    r.Value = action2.Libelle.Substring(0, System.Math.Min(action2.Libelle.Length, 250));
                    r = ws1.Cells[n1, 3];
                    try { r.Value = action2.Pilote.Code; } catch { }
                    r = ws1.Cells[n1, 4];
                    r.Value = Acces.Trouver_TableValeur_6PO("STATUT",(int) action2.Statut);// "A débuter";// action.Statut.ToString().Replace("_", " ");
                    r = ws1.Cells[n1, 5];
                    r.Value = string.Format("{0:dd/MM/yyyy}", action2.DateDebut);
                    r = ws1.Cells[n1, 6];
                    r.Value = string.Format("{0:dd/MM/yyyy}", action2.DateFin);
                    r = ws1.Cells[n1, 7];
                    r.Value = action2.Description;
                    // Le code indiqué à cet endroit entraîne la créaton des liens Actions Parent-Enfant
                    r = ws1.Cells[n1, 8];
                    if (action2.TypeAction == TypeAction.OPERATION) { r.Value = action1.Code; }

                    Liste.Add(action2); //Liste utilisée pour la suite de l'export

                    //Onglet 2 : RAT- A priori cet onglet ne sert pas pour les objectif
                    //Cas d'une opération => rattachement à l'objectif et non à l'action
                    string rattache = "";
                    if(action2.TypeAction == TypeAction.OPERATION)
                    {
                        foreach(Lien lr in listeLien)
                        {
                            if(lr.element2_id == action1.ID)
                            {
                                rattache = lr.element1_code;
                                break;
                            }
                        }
                    }
                    else
                    {
                        rattache = action1.Code;
                    }

                    n2++;
                    r = ws2.Cells[n2, 1];
                    r.Value = action2.Code;
                    r = ws2.Cells[n2, 2];
                    r.Value = Niveau;
                    r = ws2.Cells[n2, 3];
                    r.Value = ValeurNiveau; 
                    r = ws2.Cells[n2, 4];
                    r.Value = rattache; 
                }
            }

            //Onglet RAT : complément avec les référentiels
            AjouteRattachementAction(Liste, ref n2, ref ws2);

            //Onglet EQU : Equipe
            AjouteEquipeAction(Liste, ref n3, ref ws3);

            //Onglet ATT : Attributs
            AjouteAttributAction(Liste, ref n4, ref ws4);

            if (System.IO.File.Exists(fichier + ".xls")) { System.IO.File.Delete(fichier + ".xls"); }

            wb.SaveAs(fichier + ".xls");
            wb.SaveAs(fichier + ".xls", XlFileFormat.xlExcel8);

            wb.Close();
            wk.Close();
        }

        //Ajoute les éléments relatifs aux attributs
        void AjouteAttributAction(List<PATIO.Classes.Action> Liste, ref int n, ref Worksheet ws)
        {
            Range r;
            foreach (PATIO.Classes.Action action in Liste)
            {
                Element e = new Element() { Acces = Acces, };
                e = action.Déconstruire();

                foreach (dElement d in e.Liste)
                {
                    string attribut = Acces.Trouver_Attribut_6PO(Acces.type_ACTION, d.Attribut_Code);
                    string valeur = Acces.Trouver_TableValeur_6PO(d.Attribut_Code, d.Valeur);

                    if (!(d.Valeur is null))
                    {
                        if (valeur.Length == 0)
                        {
                            if (d.Valeur.Length == 0)
                            { attribut = ""; } //Sans valeur on n'ajoute pas
                            else
                            {
                                switch(attribut)
                                {
                                    case "CHEF_DE_PROJET":
                                        {
                                            Utilisateur user = (Utilisateur)Acces.Trouver_Element(Acces.type_UTILISATEUR.id, int.Parse(d.Valeur));
                                            valeur = user.Code;
                                            if (valeur.Contains("[")) { valeur = ""; }
                                            break;
                                        }

                                    default:
                                        {
                                            valeur = d.Valeur;
                                            break;
                                        }
                                }
                            }
                        }

                        if (attribut.Length > 0 && valeur.Length>0 )
                        {
                            n++;
                            r = ws.Cells[n, 1];
                            r.Value = action.Code;
                            r = ws.Cells[n, 2];
                            r.Value = attribut;
                            r = ws.Cells[n, 3];
                            r.Value = valeur; //Afficher la valeur de la table des valeurs correspondante
                        }
                    }
                }
            }
        }

        //Ajoute les informations relatives à l'équipe
        void AjouteEquipeAction(List<PATIO.Classes.Action> Liste, ref int n, ref Worksheet ws)
        {
            Range r;
            List<Utilisateur> Liste_Membre = new List<Utilisateur>();
            foreach (PATIO.Classes.Action action in Liste)
            {
                //Co-pilote
                Liste_Membre = Acces.Donner_ListeEquipeMembre(action.ID, "ROLE_6PO_COPILOTE");
                foreach (Utilisateur u in Liste_Membre)
                {
                    n++;
                    r = ws.Cells[n, 1];
                    r.Value = action.Code;
                    r = ws.Cells[n, 2];
                    r.Value = "Co-Pilote";
                    r = ws.Cells[n, 3];
                    r.Value = u.Code;
                }

                //Manager
                Liste_Membre = Acces.Donner_ListeEquipeMembre(action.ID, "ROLE_6PO_MANAGER");
                foreach (Utilisateur u in Liste_Membre)
                {
                    n++;
                    r = ws.Cells[n, 1];
                    r.Value = action.Code;
                    r = ws.Cells[n, 2];
                    r.Value = "Manager";
                    r = ws.Cells[n, 3];
                    r.Value = u.Code;
                }

                //Consultation
                Liste_Membre = Acces.Donner_ListeEquipeMembre(action.ID, "ROLE_6PO_CONSULTATION");
                foreach (Utilisateur u in Liste_Membre)
                {
                    n++;
                    r = ws.Cells[n, 1];
                    r.Value = action.Code;
                    r = ws.Cells[n, 2];
                    r.Value = "Consultation";
                    r = ws.Cells[n, 3];
                    r.Value = u.Code;
                }
            }
        }

        //Ajoute les rattachements aux référentiels
        void AjouteRattachementAction(List<PATIO.Classes.Action> Liste, ref int n, ref Worksheet ws)
        {
            foreach (PATIO.Classes.Action action in Liste)
            {
                Element e = new Element() { Acces = Acces, };
                e = action.Déconstruire();

                Console.Ajouter("[ACTION] " + action.Code);
                foreach (dElement d in e.Liste)
                {
                    string hierarchie = "";
                    string Niveau = "";
                    string ValeurNiveau = "";
                    Console.Ajouter("[-->] " + d.Attribut_Code);

                    //Traitement de chaque référentiel
                    switch (d.Attribut_Code)
                    {
                        case "PUBLIC_CIBLE":
                            {
                                hierarchie = "PUBLIC_CIBLE";
                                Niveau = hierarchie;
                                ValeurNiveau = Acces.Trouver_TableValeur_6PO(hierarchie, d.Valeur);
                                break;
                            }

                        case "ACTEUR_SANTE":
                            {
                                hierarchie = "ACTEUR_SANTE";
                                Niveau = hierarchie;
                                ValeurNiveau = Acces.Trouver_TableValeur_6PO(hierarchie, d.Valeur);
                                break;
                            }

                        case "LEVIER":
                            {
                                hierarchie = "LEVIER";
                                Niveau = hierarchie;
                                ValeurNiveau = Acces.Trouver_TableValeur_6PO(hierarchie, d.Valeur);
                                break;
                            }

                        case "PARTENAIRE_INSTITU":
                            {
                                hierarchie = "PARTENAIRE_INSTITU";
                                Niveau = hierarchie;
                                ValeurNiveau = Acces.Trouver_TableValeur_6PO("PARTENAIRE_INSTITU", d.Valeur);
                                break;
                            }

                        case "PARTENAIRE_USAGER":
                            {
                                hierarchie = "PARTENAIRE_USAGER";
                                Niveau = hierarchie;
                                ValeurNiveau = Acces.Trouver_TableValeur_6PO("PARTENAIRE_USAGER", d.Valeur);
                                break;
                            }

                        case "ANNEE_MO":
                            {
                                hierarchie = "ANNEE_MO";
                                Niveau = hierarchie;
                                ValeurNiveau = Acces.Trouver_TableValeur_6PO(hierarchie, d.Valeur);
                                break;
                            }

                        case "LIEN_PLAN":
                            {
                                hierarchie = "LIEN_PLAN";
                                Niveau = hierarchie;
                                ValeurNiveau = Acces.Trouver_TableValeur_6PO(hierarchie, d.Valeur);
                                break;
                            }

                        case "LIEN_PARCOURS":
                            {
                                hierarchie = "PARCOURS";
                                Niveau = hierarchie;
                                ValeurNiveau = Acces.Trouver_TableValeur_6PO(hierarchie, d.Valeur);
                                break;
                            }

                        case "LIEN_SECTEUR":
                            {
                                hierarchie = "SECTEUR";
                                Niveau = hierarchie;
                                ValeurNiveau = Acces.Trouver_TableValeur_6PO(hierarchie, d.Valeur);
                                break;
                            }

                        case "TSANTE":
                            {
                                hierarchie = "TSANTE";
                                Niveau = hierarchie;
                                ValeurNiveau = Acces.Trouver_TableValeur_6PO(hierarchie, d.Valeur);
                                break;
                            }

                        case "PRIORITE_CTS":
                            {
                                hierarchie = "PRIO_CTS";
                                Acces.Donner_TableValeur_6PO(hierarchie, d.Valeur, ref hierarchie, ref Niveau, ref ValeurNiveau);
                                Niveau = hierarchie;
                                break;
                            }
                    }

                    //Ajout des informations dans le fichier
                    if (ValeurNiveau.Trim().Length > 0)
                    {
                        n++;
                        Range r;
                        r = ws.Cells[n, 1];
                        r.Value = action.Code;
                        r = ws.Cells[n, 2];
                        r.Value = hierarchie; //Hiérarchie
                        r = ws.Cells[n, 3];
                        r.Value = Niveau; //Niveau
                        r = ws.Cells[n, 4];
                        r.Value = ValeurNiveau; //Valeur de niveau
                    }
                }
            }
        }

        //Donne les informations techniques pour l'export des actions en fonction du niveau du plan
        void Donner_NiveauValeur6PO(Plan plan, ref string niveau, ref string valeur)
        {
            switch (plan.NiveauPlan)
            {
                case NiveauPlan.Niveau_2:
                    {
                        niveau = "HIER_PLAN_2NIV";
                        valeur = "HIER_PLAN_2NIV_1";

                        break;
                    }
                case NiveauPlan.Niveau_3:
                    {
                        niveau = "HIER_PLAN_3NIV";
                        valeur = "HIER_PLAN_3NIV_2";

                        break;
                    }
                case NiveauPlan.Niveau_4:
                    {
                        niveau = "HIER_PLAN_4NIV";
                        valeur = "HIER_PLAN_4NIV_3";

                        break;
                    }
                case NiveauPlan.Niveau_5:
                    {
                        niveau = "HIER_PLAN_5NIV";
                        valeur = "HIER_PLAN_5NIV_4";

                        break;
                    }
            }
        }

        //Création des entêtes pour l'export Objectif
        void Entete_Objectif(Worksheet ws)
        {
            Range r;
            int n1 = 1; int n = 1; int n3 = 1; int n4 = 1;
            /*int n5 = 1;*/
            int n6 = 1; int n7 = 1;

            //Entêtes Onglet 1 : ACT-
            switch (ws.Name)
            {
                case "ACT-":
                    {
                        r = ws.Cells[n1, 1];
                        r.Value = "Code objectif";
                        r = ws.Cells[n1, 2];
                        r.Value = "Libellé objectif";
                        r = ws.Cells[n1, 3];
                        r.Value = "Pilote";
                        r = ws.Cells[n1, 4];
                        r.Value = "Statut";
                        r = ws.Cells[n1, 5];
                        r.Value = "Date de début";
                        r = ws.Cells[n1, 6];
                        r.Value = "Date de fin";
                        r = ws.Cells[n1, 7];
                        r.Value = "Description";
                        r = ws.Cells[n1, 8];
                        r.Value = "Niveau de rattachement du Plan";
                        break;
                    }

                case "RAT-":
                    {
                        //Entêtes Onglet 2 : RAT-
                        r = ws.Cells[n, 1];
                        r.Value = "Code objectif";
                        r = ws.Cells[n, 2];
                        r.Value = "Hiérarchief";
                        r = ws.Cells[n, 3];
                        r.Value = "Niveau";
                        r = ws.Cells[n, 4];
                        r.Value = "Valeur Niveau";
                        break;
                    }

                case "EQU-":
                    {
                        //Entêtes Onglet 3 : EQU-
                        r = ws.Cells[n3, 1];
                        r.Value = "Code objectif";
                        r = ws.Cells[n3, 2];
                        r.Value = "Rôle";
                        r = ws.Cells[n3, 3];
                        r.Value = "Nom";
                        break;
                    }

                case "ATT-":
                    {
                        //Entêtes Onglet 4 : ATT-
                        r = ws.Cells[n4, 1];
                        r.Value = "Code objectif";
                        r = ws.Cells[n4, 2];
                        r.Value = "Attribut";
                        r = ws.Cells[n4, 3];
                        r.Value = "Valeur";
                        break;
                    }

                case "PLA-":
                    {
                        //Entêtes Onglet 5 : PLA-
                        break;
                    }

                case "IND-":
                    {
                        //Entêtes Onglet 6
                        r = ws.Cells[n6, 1];
                        r.Value = "Code objectif";
                        r = ws.Cells[n6, 2];
                        r.Value = "WP";
                        r = ws.Cells[n6, 3];
                        r.Value = "TYPE";
                        r = ws.Cells[n6, 4];
                        r.Value = "Code Résultat";
                        r = ws.Cells[n6, 5];
                        r.Value = "Libellé";
                        r = ws.Cells[n6, 6];
                        r.Value = "Genre";
                        r = ws.Cells[n6, 7];
                        r.Value = "Catégorie";
                        r = ws.Cells[n6, 8];
                        r.Value = "Répartition";
                        r = ws.Cells[n6, 9];
                        r.Value = "Référence";
                        r = ws.Cells[n6, 10];
                        r.Value = "Cible finale";
                        r = ws.Cells[n6, 11];
                        r.Value = "Période";
                        r = ws.Cells[n6, 12];
                        r.Value = "Réalisé";
                        break;
                    }

                case "IND-PLAN":
                    {
                        //Entêtes Onglet 7
                        r = ws.Cells[n7, 1];
                        r.Value = "Code objectif";
                        r = ws.Cells[n7, 2];
                        r.Value = "Code phase";
                        r = ws.Cells[n7, 3];
                        r.Value = "TYPE";
                        r = ws.Cells[n7, 4];
                        r.Value = "Code Résultat";
                        r = ws.Cells[n7, 5];
                        r.Value = "Libellé";
                        r = ws.Cells[n7, 6];
                        r.Value = "Genre";
                        r = ws.Cells[n7, 7];
                        r.Value = "Catégorie";
                        r = ws.Cells[n7, 8];
                        r.Value = "Répartition";
                        r = ws.Cells[n7, 9];
                        r.Value = "Référence";
                        r = ws.Cells[n7, 10];
                        r.Value = "Cible finale";
                        r = ws.Cells[n7, 11];
                        r.Value = "Période";
                        r = ws.Cells[n7, 12];
                        r.Value = "Cible";
                        break;
                    }
            }
        }

        //Création des entêtes pour l'export Action
        void Entete_Action(Worksheet ws)
        {
            Range r;
            int n1 = 1; int n = 1; int n3 = 1; int n4 = 1;
            /*int n5 = 1;*/ int n6 = 1; int n7 = 1;

            //Entêtes Onglet 1 : ACT-
            switch (ws.Name)
            {
                case "PRJ-":
                    {
                        r = ws.Cells[n1, 1];
                        r.Value = "Code";
                        r = ws.Cells[n1, 2];
                        r.Value = "Libellé";
                        r = ws.Cells[n1, 3];
                        r.Value = "Pilote";
                        r = ws.Cells[n1, 4];
                        r.Value = "Statut";
                        r = ws.Cells[n1, 5];
                        r.Value = "Date de début";
                        r = ws.Cells[n1, 6];
                        r.Value = "Date de fin";
                        r = ws.Cells[n1, 7];
                        r.Value = "Description";
                        r = ws.Cells[n1, 8];
                        r.Value = "Niveau de rattachement";
                        break;
                    }
                case "RAT-":
                    {
                        //Entêtes Onglet 2 : RAT-
                        r = ws.Cells[n, 1];
                        r.Value = "Code";
                        r = ws.Cells[n, 2];
                        r.Value = "Hiérarchie";
                        r = ws.Cells[n, 3];
                        r.Value = "Niveau";
                        r = ws.Cells[n, 4];
                        r.Value = "Valeur Niveau";
                        break;
                    }
                case "EQU-":
                    {
                        //Entêtes Onglet 3 : EQU-
                        r = ws.Cells[n3, 1];
                        r.Value = "Code";
                        r = ws.Cells[n3, 2];
                        r.Value = "Rôle";
                        r = ws.Cells[n3, 3];
                        r.Value = "Nom";
                        break;
                    }
                case "ATT-":
                    {
                        //Entêtes Onglet 4 : ATT-
                        r = ws.Cells[n4, 1];
                        r.Value = "Code";
                        r = ws.Cells[n4, 2];
                        r.Value = "Attribut";
                        r = ws.Cells[n4, 3];
                        r.Value = "Valeur";
                        break;
                    }

                case "PLA-":
                    {
                        //Entêtes Onglet 5 : PLA-
                        break;
                    }

                case "IND-":
                    {
                        //Entêtes Onglet 6 : IND-
                        r = ws.Cells[n6, 1];
                        r.Value = "Code";
                        r = ws.Cells[n6, 2];
                        r.Value = "Code phase";
                        r = ws.Cells[n6, 3];
                        r.Value = "TYPE";
                        r = ws.Cells[n6, 4];
                        r.Value = "Code indicateur";
                        r = ws.Cells[n6, 5];
                        r.Value = "Libellé indicateur";
                        r = ws.Cells[n6, 6];
                        r.Value = "Genre";
                        r = ws.Cells[n6, 7];
                        r.Value = "Catégorie";
                        r = ws.Cells[n6, 8];
                        r.Value = "Code Répartition";
                        r = ws.Cells[n6, 9];
                        r.Value = "Valeur Référence";
                        r = ws.Cells[n6, 10];
                        r.Value = "Valeur Cible finale";
                        r = ws.Cells[n6, 11];
                        r.Value = "Période";
                        r = ws.Cells[n6, 12];
                        r.Value = "Réalisé";
                        break;
                    }
                case "IND-PLAN":
                    {
                        //Entêtes Onglet 7 : IND-PLAN
                        r = ws.Cells[n7, 1];
                        r.Value = "Code";
                        r = ws.Cells[n7, 2];
                        r.Value = "Code phase";
                        r = ws.Cells[n7, 3];
                        r.Value = "TYPE";
                        r = ws.Cells[n7, 4];
                        r.Value = "Code indicateur";
                        r = ws.Cells[n7, 5];
                        r.Value = "Libellé indicateur";
                        r = ws.Cells[n7, 6];
                        r.Value = "Genre";
                        r = ws.Cells[n7, 7];
                        r.Value = "Catégorie";
                        r = ws.Cells[n7, 8];
                        r.Value = "Code Répartition";
                        r = ws.Cells[n7, 9];
                        r.Value = "Valeur Référence";
                        r = ws.Cells[n7, 10];
                        r.Value = "Valeur Cible finale";
                        r = ws.Cells[n7, 11];
                        r.Value = "Période";
                        r = ws.Cells[n7, 12];
                        r.Value = "Cible";
                        break;
                    }
            }
        }

        //Exprt de la liste des utilisateurs Pilote
        void ExportUtilisateur()
        {
            var fichier = Chemin + "\\Fichiers\\" + "USER";
            Console.Ajouter("->Cible : " + fichier);

            app.Workbooks.Add();

            Workbooks wk = app.Workbooks;
            Workbook wb = app.ActiveWorkbook;
            Worksheet ws = wb.Sheets[1];
            Range r;
            int n = 1;

            //Renommage de la feuille 1
            ws.Name = "utilisateurs";

            //Entêtes
            r = ws.Cells[n, 1];
            r.Value = "code";
            r = ws.Cells[n, 2];
            r.Value = "Prénom";
            r = ws.Cells[n, 3];
            r.Value = "Nom";
            r = ws.Cells[n, 4];
            r.Value = "email";
            r = ws.Cells[n, 5];
            r.Value = "Genre";

            //Liste des objectifs de 1er niveau
            Console.Ajouter("->Nb lignes :" + listeLien.Count.ToString());
            List<Utilisateur> ListeUtilisateur =(List<Utilisateur>) Acces.Remplir_ListeElement(Acces.type_UTILISATEUR.id, "");

            foreach (Utilisateur l in ListeUtilisateur)
            {
                if (l.Actif)
                {
                    n++;
                    r = ws.Cells[n, 1];
                    r.Value = l.Code ;
                    r = ws.Cells[n, 2];
                    r.Value = l.Prenom;
                    r = ws.Cells[n, 3];
                    r.Value = l.Nom;
                    r = ws.Cells[n, 4];
                    r.Value = l.Mail;
                }
            }

            if (System.IO.File.Exists(fichier + ".xls")) {
                try { System.IO.File.Delete(fichier + ".xls"); } catch { } }

            wb.SaveAs(fichier + ".xls");
            wb.SaveAs(fichier + ".xls", XlFileFormat.xlExcel8);

            wb.Close();
            wk.Close();
        }

        void ExportTableValeur()
        {
            foreach(string tv in Acces.Remplir_ListeTableValeurNom("DESC"))
            {
                //Recherche du libellé
                string libelle = Acces.Trouver_Attribut_Libelle(tv);

                //if(libelle.Length ==0) { MessageBox.Show("Libellé de l'attribut " + tv + " non trouvé"); }

                if(!(System.IO.Directory.Exists(Chemin + "\\Fichiers\\TV\\")))
                { System.IO.Directory.CreateDirectory(Chemin + "\\Fichiers\\TV\\"); }

                string fichier = Chemin + "\\Fichiers\\TV\\" + "TV-" + tv;

                Workbooks wk = app.Workbooks;
                Workbook wb = app.Workbooks.Add();

                //Création des feuilles
                int nb_feuilles = wb.Sheets.Count;

                Range r;
                int n = 0;
                Worksheet ws = wb.Sheets.Add(); ws.Name = tv;
                n = 0;
                //Entêtes
                {
                    n++;
                    r = ws.Cells[n, 1];
                    r.Value = "Libelle_VN";
                    r = ws.Cells[n, 2];
                    r.Value = "Code_VN";
                    r = ws.Cells[n, 3];
                    r.Value = "Description_VN";
                    n++;
                    r = ws.Cells[n, 1];
                    r.Value = libelle;
                    r = ws.Cells[n, 2];
                    r.Value = tv;
                }

                //Insertion des données
                foreach (table_valeur ltv in Acces.Remplir_ListeTableValeur(tv))
                {
                    n++;
                    r = ws.Cells[n, 1];
                    r.Value = ltv.Valeur;
                    r = ws.Cells[n, 2];
                    r.Value = ltv.Code;
                }

                //Suppression des feuilles déjà existantes
                n = wb.Sheets.Count;
                for (var i = 0; i < nb_feuilles; i++)
                {
                    Worksheet w = wb.Sheets[n-i];
                    w.Delete();
                }

                if (System.IO.File.Exists(fichier + ".xls")) { System.IO.File.Delete(fichier + ".xls"); }

                wb.SaveAs(fichier + ".xls");
                wb.SaveAs(fichier + ".xls", XlFileFormat.xlExcel8);

                wb.Close();
                wk.Close();
            }
        }
    }
}
