using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using PATIO.Classes;
using PATIO.Modules;

namespace PATIO.Interfaces
{
    public partial class ctrlExport : UserControl
    {
        public PATIO.Classes.AccesNet Acces;
        public WeifenLuo.WinFormsUI.Docking.DockPanel DP;
        public int PropId;

        public string Chemin;

        Fonctions fonc = new Fonctions();

        public ctrlExport()
        {
            InitializeComponent();
        }

        public void Initialise()
        {
            lst.Items.Clear();
        }

        private void BtnExporter_Click(object sender, EventArgs e)
        {
            Exporter();
        }

        void Exporter()
        {
            lst.Items.Add("Initialisation de l'export");

            //Définit et crée si besoin le répertoire de destination
            var chemin_export = Chemin + "\\Export";
            if (!(Directory.Exists(chemin_export))) { Directory.CreateDirectory(chemin_export); }

            //Export de la table Plan
            lst.Items.Add("Export de la table Plan...");
            ExportePlan(chemin_export);

            //Export de la table Objectif
            lst.Items.Add("Export de la table Objectif...");
            ExporteObjectif(chemin_export);

            //Export de la table Action
            lst.Items.Add("Export de la table Action...");
            ExporteAction(chemin_export);

            //Export de la table Lien
            lst.Items.Add("Export de la table Lien...");
            ExporteLien(chemin_export);

            //Export de la table Indicateur
            lst.Items.Add("Export de la table Indicateur...");
            ExporteIndicateur(chemin_export);

            //Export de la table Propriétaires
            lst.Items.Add("Export de la table Propriétaire...");
            ExporteProprietaire(chemin_export);

            //Export de la table Utilisateurs
            lst.Items.Add("Export de la table Utilisateur...");
            ExporteUtilisateur(chemin_export);

            lst.Items.Add("Export terminé");
        }

        void ExportePlan(string chemin)
        {
            /*var plan = (from p in Acces.Plan
                        select new { p.ID, p.Libelle, p.Code, p.ProprietaireId, p.Actif,
                            p.TypePlan, p.NiveauPlan, p.Abrege, p.Pilote, p.DateDebut, p.DateFin,
                            p.OptAnalyseGlobale, p.OptCommentaires, p.OptGouvernance, p.OptPrioriteRegionale })
               .ToList()
               .Select(p =>
                       new XElement("Plan",
                       new XElement("ID", p.ID),
                       new XElement("Libelle", p.Libelle),
                       new XElement("Code", p.Code),
                       new XElement("ProprietaireID", p.ProprietaireId),
                       new XElement("Actif", p.Actif),
                       new XElement("TypePlan", p.TypePlan.GetHashCode()),
                       new XElement("NiveauPlan", p.NiveauPlan.GetHashCode()),
                       new XElement("Abrege", p.Abrege),
                       new XElement("Pilote", p.Pilote.ID),
                       new XElement("DateDebut", p.DateDebut),
                       new XElement("DateFin", p.DateFin),
                       new XElement("OptAnalyseGlobale", p.OptAnalyseGlobale),
                       new XElement("OptCommentaires", p.OptCommentaires),
                       new XElement("OptGouvernance", p.OptGouvernance),
                       new XElement("OptPrioriteRegionale", p.OptPrioriteRegionale)
                    ));

            XElement pl = new XElement("Plans");

            foreach (XElement el in plan)
            {
                pl.Add(el);
            }

            pl.Save(chemin + "\\1-plan.xml");*/
        }

        void ExporteObjectif(string chemin)
        {
            /*var objectif = (from p in Acces.Objectif
                        select new
                        {
                            p.ID,
                            p.Libelle,
                            p.Code,
                            p.ProprietaireId,
                            p.Description,
                            p.Actif,
                            p.TypeObjectif,
                            p.Pilote,
                            p.Statut,
                            p.DateDebut,
                            p.DateFin,
                            p.Meteo,
                            p.TxAvancement,
                            p.AnalyseQualitative
                        })
               .ToList()
               .Select(p =>
                       new XElement("Objectif",
                       new XElement("ID", p.ID),
                       new XElement("Libelle", p.Libelle),
                       new XElement("Code", p.Code),
                       new XElement("ProprietaireID", p.ProprietaireId),
                       new XElement("Description", p.Description),
                       new XElement("Actif", p.Actif),
                       new XElement("TypeObjectif", p.TypeObjectif.GetHashCode()),
                       new XElement("Pilote", p.Pilote.ID),
                       new XElement("Statut", p.Statut.GetHashCode()),
                       new XElement("DateDebut", p.DateDebut),
                       new XElement("DateFin", p.DateFin),
                       new XElement("Meteo", p.Meteo.GetHashCode()),
                       new XElement("TxAvancement", p.TxAvancement.GetHashCode()),
                       new XElement("AnalyseQualitative", p.AnalyseQualitative)
                       ));

            XElement pl = new XElement("Objectifs");

            foreach (XElement el in objectif)
            {
                pl.Add(el);
            }

            pl.Save(chemin + "\\1-objectif.xml");*/
        }

        void ExporteAction(string chemin)
        {
            /*var action = (from p in Acces.Action
                            select new
                            {
                                p.ID,
                                p.Libelle,
                                p.Code,
                                p.ProprietaireId,
                                p.Description,
                                p.Actif,
                                p.TypeAction,
                                p.Pilote,
                                p.Statut,
                                p.DateDebut,
                                p.DateFin,
                                p.Meteo,
                                p.TxAvancement,
                                p.ActionInnovante,
                                p.AnalyseQualitative,
                                p.ReductionInegalite
                            })
               .ToList()
               .Select(p =>
                       new XElement("Action",
                       new XElement("ID", p.ID),
                       new XElement("Libelle", p.Libelle),
                       new XElement("Code", p.Code),
                       new XElement("ProprietaireID", p.ProprietaireId),
                       new XElement("Description", p.Description),
                       new XElement("Actif", p.Actif),
                       new XElement("TypeAction", p.TypeAction.GetHashCode()),
                       new XElement("Pilote", p.Pilote.ID),
                       new XElement("Statut", p.Statut.GetHashCode()),
                       new XElement("DateDebut", p.DateDebut),
                       new XElement("DateFin", p.DateFin),
                       new XElement("Meteo", p.Meteo.GetHashCode()),
                       new XElement("TxAvancement", p.TxAvancement.GetHashCode()),
                       new XElement("ActionInnovante", p.ActionInnovante),
                       new XElement("AnalyseQualitative", p.AnalyseQualitative),
                       new XElement("ReductionInegalite", p.ReductionInegalite)
                       ));

            XElement pl = new XElement("Actions");

            foreach (XElement el in action)
            {
                pl.Add(el);
            }

            pl.Save(chemin + "\\1-action.xml");*/
        }

        void ExporteLien(string chemin)
        {
            /*var lien = (from p in Acces.Lien
                        select new
                        {
                            p.ID,
                            p.PlanId,
                            p.element1_type,
                            p.element1_id,
                            p.element1_code,
                            p.element2_type,
                            p.element2_id,
                            p.element2_code,
                            p.ProprietaireId,
                            p.Ordre,
                            p.Actif,
                        })
               .ToList()
               .Select(p =>
                       new XElement("Lien",
                       new XElement("ID", p.ID),
                       new XElement("PlanID", p.PlanId),
                       new XElement("element1_type", p.element1_type.GetHashCode()),
                       new XElement("element1_id", p.element1_id),
                       new XElement("element1_code", p.element1_code),
                       new XElement("element2_type", p.element2_type.GetHashCode()),
                       new XElement("element2_id", p.element2_id),
                       new XElement("element2_code", p.element2_code),
                       new XElement("Ordre", p.Ordre),
                       new XElement("Actif", p.Actif)
                       ));

            XElement pl = new XElement("Liens");

            foreach (XElement el in lien)
            {
                pl.Add(el);
            }

            pl.Save(chemin + "\\2-lien.xml");*/
        }

        void ExporteIndicateur(string chemin)
        {
            /*var indic = (from p in Acces.Indicateur
                        select new
                        {
                            p.ID,
                            p.Libelle,
                            p.Code,
                            p.ProprietaireId,
                            p.Actif,
                            p.TypeIndicateur
                        })
               .ToList()
               .Select(p =>
                       new XElement("Indicateur",
                       new XElement("ID", p.ID),
                       new XElement("Libelle", p.Libelle),
                       new XElement("Code", p.Code),
                       new XElement("ProprietaireID", p.ProprietaireId),
                       new XElement("Actif", p.Actif),
                       new XElement("TypeIndicateur", p.TypeIndicateur.GetHashCode())
                       ));

            XElement pl = new XElement("Indicateurs");

            foreach (XElement el in indic)
            {
                pl.Add(el);
            }

            pl.Save(chemin + "\\1-indicateur.xml");*/
        }

        void ExporteProprietaire(string chemin)
        {
            /*var prop = (from p in Acces.Proprietaire
                         select new
                         {
                             p.ID,
                             p.Libelle,
                             p.Code,
                             p.Actif,
                         })
               .ToList()
               .Select(p =>
                       new XElement("Proprietaire",
                       new XElement("ID", p.ID),
                       new XElement("Libelle", p.Libelle),
                       new XElement("Code", p.Code),
                       new XElement("Actif", p.Actif)
                       ));

            XElement pl = new XElement("Proprietaires");

            foreach (XElement el in prop)
            {
                pl.Add(el);
            }

            pl.Save(chemin + "\\0-proprietaire.xml");*/
        }

        void ExporteUtilisateur(string chemin)
        {
            /*var prop = (from p in Acces.Utilisateur
                        select new
                        {
                            p.ID,
                            p.Code,
                            p.Nom,
                            p.Prenom,
                            p.Mail,
                            p.ProprietaireId,
                            p.TypeUtilisateur,
                            p.TypeLicence,
                            p.Actif,
                        })
               .ToList()
               .Select(p =>
                       new XElement("Utilisateur",
                       new XElement("ID", p.ID),
                       new XElement("Code", p.Code),
                       new XElement("Nom", p.Nom),
                       new XElement("Prenom", p.Prenom),
                       new XElement("Mail", p.Mail),
                       new XElement("ProprietaireID", p.ProprietaireId),
                       new XElement("TypeUtilisateur", p.TypeUtilisateur.GetHashCode()),
                       new XElement("TypeLicence", p.TypeLicence.GetHashCode()),
                       new XElement("Actif", p.Actif)
                       ));

            XElement pl = new XElement("Utilisateurs");

            foreach (XElement el in prop)
            {
                pl.Add(el);
            }

            pl.Save(chemin + "\\0-utilisateur.xml");*/
        }

        private void btnExporterWeb_Click(object sender, EventArgs e)
        {
            ExporterWeb();
        }

        List<table_valeur> tablevaleur;
        List<Attribut> listeattribut;

        void ExporterWeb()
        {
            lst.Items.Clear();

            //Suppression des informations
            SuppressionElement();

            //Chargement de la table de valeur
            ChargementTableValeur();

            //Chargement de la table des attributs
            ChargementTableAttribut();

            //Export des plans
            InsertionPlan();

            //Export des objectifs
            InsertionObjectif();

            //Export des actions
            InsertionAction();

            //Export des indicateurs
            InsertionIndicateur();

            //Export des utilisateurs
            InsertionUtilisateur();

            //Export des groupes
            InsertionGroupe();

            //Export des liens
            InsertionLien();

            lst.Items.Add("Export terminé");
        }

        void SuppressionElement()
        {
            Modules.ClassePHP cls = new Modules.ClassePHP();
            string sql = "";

            lst.Items.Add("Suppression des éléments...");
            Application.DoEvents();

            //Suppression Table Element
            sql = "DELETE FROM element";
            cls.Execute(sql);
            if (cls.erreur.Length > 0) { lst.Items.Add("Erreur : " + cls.erreur); }

            //Suppression Table dElement
            sql = "DELETE FROM delement";
            cls.Execute(sql);
            if (cls.erreur.Length > 0) { lst.Items.Add("Erreur : " + cls.erreur); }

            //Suppression Table dElement
            sql = "DELETE FROM lien";
            cls.Execute(sql);
            if (cls.erreur.Length > 0) { lst.Items.Add("Erreur : " + cls.erreur); }
        }

        void ChargementTableValeur()
        {
            Modules.ClassePHP cls = new Modules.ClassePHP();
            tablevaleur = new List<table_valeur>();

            lst.Items.Add("Chargement de la table de valeurs...");
            Application.DoEvents();

            DataSet Sn = cls.ContenuTable("table_valeur");

            foreach(DataRow r in Sn.Tables["table_valeur"].Rows)
            {
                table_valeur t = new table_valeur();
                t.ID = int.Parse(r[0].ToString());
                t.Nom  = r[1].ToString();
                t.Code  = r[2].ToString();
                t.Valeur = r[3].ToString();
                tablevaleur.Add(t);
            }
        }

        void ChargementTableAttribut()
        {
            Modules.ClassePHP cls = new Modules.ClassePHP();
            listeattribut = new List<Attribut>();

            lst.Items.Add("Chargement de la table des attributs...");
            Application.DoEvents();

            DataSet Sn = cls.ContenuTable("attribut");

            foreach (DataRow r in Sn.Tables["attribut"].Rows)
            {
                Attribut t = new Attribut();
                t.ID = int.Parse(r[0].ToString());
                t.Code = r[1].ToString();
                t.Libelle = r[2].ToString();
                t.Element_Type = int.Parse(r[3].ToString());
                listeattribut.Add(t);
            }
        }

        void InsertionPlan()
        {
            Modules.ClassePHP cls = new Modules.ClassePHP();
            string sql = "";
            int n = 0;

            List<Plan> ListePlan =(List<Plan>) Acces.Remplir_ListeElement(Acces.type_PLAN.id, "");
            lst.Items.Add("Insertion Table Plan..." + ListePlan.Count().ToString());
            Application.DoEvents();

            //Insertion des données
            //Recherche du code correspondant au type donné
            int elementid=0;
            string typeelement = DonneValeur("TYPE_ELEMENT",Acces.type_PLAN.code, ref elementid);

            foreach (Plan p in ListePlan)
            {
                //lst.Items.Add("Plan : " + p.Libelle);
                Application.DoEvents();
                sql = "INSERT INTO element (element_type, code, libelle, actif) VALUES (";
                sql += "'" + typeelement + "',";
                sql += "'" + p.Code + "',";
                sql += "'" + p.Libelle.Replace("'","\'") + "',";
                sql += "'" + (p.Actif ? 1:0) + "')";

                cls = new Modules.ClassePHP();
                cls.Execute(sql);
                if (cls.erreur.Length > 0) { lst.Items.Add("Erreur : " + p.Libelle); }
                else { n++; }

                //Détail
                if (!(p.Pilote is null)) { Insertion_delement(elementid, typeelement, p.Code, "PILOTE", p.Pilote.ID.ToString()); }
                int id_typeplan=0;
                Insertion_delement(elementid, typeelement, p.Code, "TYPE", DonneValeur("TYPE_PLAN", p.TypePlan.ToString(),ref id_typeplan));
                Insertion_delement(elementid, typeelement, p.Code, "ABREGE", p.Abrege);
                int id_typeniveau = 0;
                Insertion_delement(elementid, typeelement, p.Code, "NIVEAU_6PO", DonneValeur("NIVEAU_6PO", p.NiveauPlan.ToString(),ref id_typeniveau));
                Insertion_delement(elementid, typeelement, p.Code, "DATE_DEBUT", p.DateDebut.ToString());
                Insertion_delement(elementid, typeelement, p.Code, "DATE_FIN", p.DateFin.ToString());
                if (p.OptAnalyseGlobale) { Insertion_delement(elementid, typeelement, p.Code, "ANALYSE_GLOBALE", (p.OptAnalyseGlobale ? 1 : 0).ToString()); }
                if (p.OptCommentaires) { Insertion_delement(elementid, typeelement, p.Code, "COMMENTAIRES", (p.OptCommentaires ? 1 : 0).ToString()); }
                if (p.OptGouvernance) { Insertion_delement(elementid, typeelement, p.Code, "GOUVERNANCE", (p.OptGouvernance ? 1 : 0).ToString()); }
                if (p.OptPrioriteRegionale) { Insertion_delement(elementid, typeelement, p.Code, "PRIORITE_REGIONALE", (p.OptPrioriteRegionale ? 1 : 0).ToString()); }
            }

            lst.Items.Add(n + " lignes Table Plan...");
        }

        void InsertionObjectif()
        {
            Modules.ClassePHP cls = new Modules.ClassePHP();
            string sql = "";
            int n = 0;

            List<Objectif> ListeObjectif=(List<Objectif>) Acces.Remplir_ListeElement(Acces.type_OBJECTIF.id, "");
            lst.Items.Add("Insertion Table Objectif..." + ListeObjectif.Count().ToString());
            Application.DoEvents();

            //Insertion des données
            //Recherche du code correspondant au type donné
            int elementid = 0;
            string typeelement = DonneValeur("TYPE_ELEMENT", Acces.type_OBJECTIF.code, ref elementid);

            foreach (Objectif p in ListeObjectif)
            {
                //lst.Items.Add("Objectif : " + p.Libelle);
                Application.DoEvents();
                sql = "INSERT INTO element (element_type, code, libelle, actif) VALUES (";
                sql += "'" + typeelement + "',";
                sql += "'" + p.Code + "',";
                sql += "'" + p.Libelle.Replace("'", "\'") + "',";
                sql += "'" + (p.Actif ? 1 : 0) + "')";

                cls = new Modules.ClassePHP();
                cls.Execute(sql);
                if (cls.erreur.Length > 0) { lst.Items.Add("Erreur : " + p.Libelle); }
                else { n++; }

                //Détail
                if (!(p.Pilote is null)) { Insertion_delement(elementid, typeelement, p.Code, "PILOTE", p.Pilote.ID.ToString()); }
                int id_typeobjectif = 0;
                Insertion_delement(elementid, typeelement, p.Code, "TYPE", DonneValeur("TYPE_OBJECTIF", p.TypeObjectif.ToString(), ref id_typeobjectif));
                int id_typestatut = 0;
                Insertion_delement(elementid, typeelement, p.Code, "STATUT", DonneValeur("STATUT", p.Statut.ToString(), ref id_typestatut));
                Insertion_delement(elementid, typeelement, p.Code, "DATE_DEBUT", p.DateDebut.ToString());
                Insertion_delement(elementid, typeelement, p.Code, "DATE_FIN", p.DateFin.ToString());
                int id_meteo = 0;
                Insertion_delement(elementid, typeelement, p.Code, "METEO", DonneValeur("METEO", p.Meteo.ToString(), ref id_meteo));
                int id_tx_avancement = 0;
                Insertion_delement(elementid, typeelement, p.Code, "TX_AVANCEMENT", DonneValeur("TX_AVANCEMENT", p.TxAvancement.ToString(), ref id_tx_avancement));

                if (p.AnalyseQualitative.Length>0) { Insertion_delement(elementid, typeelement, p.Code, "ANALYSE_QUALITATIVE", p.AnalyseQualitative); }
            }

            lst.Items.Add(n + " lignes Table Objectif...");

        }

        void InsertionAction()
        {
            Modules.ClassePHP cls = new Modules.ClassePHP();
            string sql = "";
            int n = 0;

            List<PATIO.Classes.Action> ListeAction = (List<PATIO.Classes.Action>) Acces.Remplir_ListeElement(Acces.type_ACTION.id, "");
            lst.Items.Add("Insertion Table Action..." + ListeAction.Count().ToString());
            Application.DoEvents();

            //Insertion des données
            //Recherche du code correspondant au type donné
            int elementid = 0;
            string typeelement = DonneValeur("TYPE_ELEMENT", Acces.type_ACTION.code, ref elementid);

            foreach (PATIO.Classes.Action p in ListeAction)
            {
                //lst.Items.Add("Action : " + p.Libelle);
                Application.DoEvents();
                sql = "INSERT INTO element (element_type, code, libelle, actif) VALUES (";
                sql += "'" + typeelement + "',";
                sql += "'" + p.Code + "',";
                sql += "'" + p.Libelle.Replace("'", "\'") + "',";
                sql += "'" + (p.Actif ? 1 : 0) + "')";

                cls = new Modules.ClassePHP();
                cls.Execute(sql);
                if (cls.erreur.Length > 0) { lst.Items.Add("Erreur : " + p.Libelle); }
                else { n++; }

                //Détail
                if (!(p.Pilote is null)) { Insertion_delement(elementid, typeelement, p.Code, "PILOTE", p.Pilote.ID.ToString()); }
                int id_typeaction = 0;
                Insertion_delement(elementid, typeelement, p.Code, "TYPE", DonneValeur("TYPE_ACTION", p.TypeAction.ToString(), ref id_typeaction));
                int id_typestatut = 0;
                Insertion_delement(elementid, typeelement, p.Code, "STATUT", DonneValeur("STATUT", p.Statut.ToString(), ref id_typestatut));
                Insertion_delement(elementid, typeelement, p.Code, "DATE_DEBUT", p.DateDebut.ToString());
                Insertion_delement(elementid, typeelement, p.Code, "DATE_FIN", p.DateFin.ToString());
                int id_meteo = 0;
                Insertion_delement(elementid, typeelement, p.Code, "METEO", DonneValeur("METEO", p.Meteo.ToString(), ref id_meteo));
                int id_tx_avancement = 0;
                Insertion_delement(elementid, typeelement, p.Code, "TX_AVANCEMENT", DonneValeur("TX_AVANCEMENT", p.TxAvancement.ToString(), ref id_tx_avancement));

                if (p.AnalyseQualitative.Length > 0) { Insertion_delement(elementid, typeelement, p.Code, "ANALYSE_QUALITATIVE", p.AnalyseQualitative); }
                if (p.ActionInnovante) { Insertion_delement(elementid, typeelement, p.Code, "ACTION_INNOVANTE", (p.ActionInnovante ? 1 : 0).ToString()); }
                if (p.ReductionInegalite.Length>0) { Insertion_delement(elementid, typeelement, p.Code, "REDUCTION_INEGALITE", p.ReductionInegalite); }
            }

            lst.Items.Add(n + " lignes Table Action...");

        }

        void InsertionIndicateur()
        {
            Modules.ClassePHP cls = new Modules.ClassePHP();
            string sql = "";
            int n = 0;

            List<Indicateur> ListeIndicateur = (List<Indicateur>) Acces.Remplir_ListeElement(Acces.type_INDICATEUR.id, "");
            lst.Items.Add("Insertion Table Indicateur..." + ListeIndicateur.Count().ToString());
            Application.DoEvents();

            //Insertion des données
            //Recherche du code correspondant au type donné
            int elementid = 0;
            string typeelement = DonneValeur("TYPE_ELEMENT", Acces.type_INDICATEUR.code, ref elementid);

            foreach (Indicateur p in ListeIndicateur)
            {
                //lst.Items.Add("Indicateur : " + p.Libelle);
                Application.DoEvents();
                sql = "INSERT INTO element (element_type, code, libelle, actif) VALUES (";
                sql += "'" + typeelement + "',";
                sql += "'" + p.Code + "',";
                sql += "'" + p.Libelle.Replace("'", "\'") + "',";
                sql += "'" + (p.Actif ? 1 : 0) + "')";

                cls = new Modules.ClassePHP();
                cls.Execute(sql);
                if (cls.erreur.Length > 0) { lst.Items.Add("Erreur : " + p.Libelle); }
                else { n++; }

                //Détail
                int id_typeindic = 0;
                Insertion_delement(elementid, typeelement, p.Code, "TYPE", DonneValeur("TYPE_INDICATEUR", p.TypeIndicateur.ToString(), ref id_typeindic));

            }

            lst.Items.Add(n + " lignes Table Indicateur...");

        }

        void InsertionUtilisateur()
        {
            Modules.ClassePHP cls = new Modules.ClassePHP();
            string sql = "";
            int n = 0;

            List<Utilisateur> ListeUtilisateur = (List<Utilisateur>) Acces.Remplir_ListeElement(Acces.type_UTILISATEUR.id, "");
            lst.Items.Add("Insertion Table Utilisateur..." + ListeUtilisateur.Count().ToString());
            Application.DoEvents();

            //Insertion des données
            //Recherche du code correspondant au type donné
            int elementid = 0;
            string typeelement = DonneValeur("TYPE_ELEMENT", Acces.type_INDICATEUR.code, ref elementid);

            foreach (Utilisateur p in ListeUtilisateur)
            {
                //lst.Items.Add("Indicateur : " + p.Nom);
                Application.DoEvents();
                sql = "INSERT INTO element (element_type, code, libelle, actif) VALUES (";
                sql += "'" + typeelement + "',";
                sql += "'" + p.Code + "',";
                sql += "'" + p.Nom.Replace("'", "\'") + "',";
                sql += "'" + (p.Actif ? 1 : 0) + "')";

                cls = new Modules.ClassePHP();
                cls.Execute(sql);
                if (cls.erreur.Length > 0) { lst.Items.Add("Erreur : " + p.Nom); }
                else { n++; }

                //Détail
                if (!(p.Prenom.Length>0)) { Insertion_delement(elementid, typeelement, p.Code, "PRENOM", p.Prenom.ToString()); }

                int id_typeuser = 0;
                Insertion_delement(elementid, typeelement, p.Code, "TYPE_UTILISATEUR", DonneValeur("TYPE_UTILISATEUR", p.TypeUtilisateur.ToString(), ref id_typeuser));

                int id_typelicence = 0;
                Insertion_delement(elementid, typeelement, p.Code, "TYPE_LICENCE", DonneValeur("TYPE_LICENCE", p.TypeLicence.ToString(), ref id_typelicence));

            }

            lst.Items.Add(n + " lignes Table Utilisateur...");

        }

        void InsertionGroupe()
        {
            Modules.ClassePHP cls = new Modules.ClassePHP();
            string sql = "";
            int n = 0;

            List<Groupe>  ListeGroupe = (List<Groupe>) Acces.Remplir_ListeElement(Acces.type_GROUPE.id, "");
            lst.Items.Add("Insertion Table Groupe..." + ListeGroupe.Count().ToString());
            Application.DoEvents();

            //Insertion des données
            //Recherche du code correspondant au type donné
            int elementid = 0;
            string typeelement = DonneValeur("TYPE_ELEMENT", Acces.type_INDICATEUR.code, ref elementid);

            foreach (Groupe p in ListeGroupe)
            {
                //lst.Items.Add("Indicateur : " + p.Libelle);
                Application.DoEvents();
                sql = "INSERT INTO element (element_type, code, libelle, actif) VALUES (";
                sql += "'" + typeelement + "',";
                sql += "'" + p.Code + "',";
                sql += "'" + p.Libelle.Replace("'", "\'") + "',";
                sql += "'" + (p.Actif ? 1 : 0) + "')";

                cls = new Modules.ClassePHP();
                cls.Execute(sql);
                if (cls.erreur.Length > 0) { lst.Items.Add("Erreur : " + p.Libelle); }
                else { n++; }

                //Détail
                int id_typegroupe = 0;
                Insertion_delement(elementid, typeelement, p.Code, "TYPE_GROUPE", DonneValeur("TYPE_GROUPE", p.TypeGroupe.ToString(), ref id_typegroupe));
            }

            lst.Items.Add(n + " lignes Table Groupe...");

        }

        void InsertionLien()
        {
            Modules.ClassePHP cls = new Modules.ClassePHP();
            string sql = "";
            int n = 0;

            List<Lien> ListeLien = Acces.Remplir_ListeLien(Acces.type_PLAN,"");
            lst.Items.Add("Insertion Table Lien..." + ListeLien.Count().ToString());
            Application.DoEvents();

            Acces.Remplir_ListeElement(Acces.type_PLAN.id,"");
            List<Plan> listeplan =(List<Plan>) Acces.Remplir_ListeElement(Acces.type_PLAN.id,"");

            //Insertion des données

            foreach (Lien p in ListeLien)
            {
                //lst.Items.Add("Lien : " + p.element1_code + "-" + p.element2_code);
                Application.DoEvents();

                int elementid0 = 0; int elementid1 = 0; int elementid2 = 0;
                string typeelement0 = DonneValeur("TYPE_ELEMENT", Acces.type_PLAN.code, ref elementid0);
                string element1_type = DonneValeur("TYPE_ELEMENT", Acces.Trouver_TableValeur(p.element1_type).Code, ref elementid1);
                string element2_type = DonneValeur("TYPE_ELEMENT", Acces.Trouver_TableValeur(p.element2_type).Code, ref elementid2);

                sql = "INSERT INTO lien (element0_type, element0_code, element0_id, element1_type, element1_id, element1_code,";
                sql += " element2_type, element2_id, element2_code, ordre, complement) VALUES (";
                sql += "'" +typeelement0 + "',";
                sql += "'" + DonneCodePlan(p.element0_id, listeplan) + "',";
                sql += "'" + p.element0_id + "',";
                sql += "'" + element1_type + "',";
                sql += "'" + p.element1_id + "',";
                sql += "'" + p.element1_code + "',";
                sql += "'" + element2_type + "',";
                sql += "'" + p.element2_id + "',";
                sql += "'" + p.element2_code + "',";
                sql += "'" + p.ordre + "',";
                sql += "'" + p.complement + "')";

                cls = new Modules.ClassePHP();
                cls.Execute(sql);
                if (cls.erreur.Length > 0) { lst.Items.Add("Erreur : " + p.element1_code + "-" + p.element2_code); }
                else { n++; }
            }

            lst.Items.Add(n + " lignes Table Lien...");

        }

        void Insertion_delement(int elementid, string typeelement, string code, string attribut, string valeur)
        {
            //Recherche de l'id de l'attribut
            string attribut_id="";

            foreach(Attribut att in listeattribut)
            {
                if(att.Code==attribut && att.Element_Type==int.Parse(typeelement)) { attribut_id = att.ID.ToString(); break; }
            }

            string sql;
            sql = "INSERT INTO delement (element_id, element_code, attribut_id, attribut_code, valeur) VALUES (";
            sql += "'" + elementid + "',";
            sql += "'" + code + "',";
            sql += "'" + attribut_id + "',";
            sql += "'" + attribut + "',";
            sql += "'" + valeur + "')";

            Modules.ClassePHP cls = new Modules.ClassePHP();
            cls.Execute(sql);
            if (cls.erreur.Length > 0) { lst.Items.Add("Erreur : " + sql); }
        }

        string DonneValeur(string type, string code, ref  int id)
        {
            string valeur = "";

            foreach(table_valeur t in tablevaleur)
            {
                if (t.Nom == type && t.Code == code)
                {
                    valeur = t.Valeur;
                    id = t.ID;
                    break;
                }
            }
            return valeur;
        }

        string DonneCodePlan(int id, List<Plan> liste)
        {
            string code = "";

            foreach(Plan p in liste)
            {
                if(p.ID == id) { code = p.Code; break; }
            }

            return code;
        }
    }
}
