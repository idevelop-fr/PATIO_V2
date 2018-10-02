using System;
using System.Collections.Generic;
using System.Data;
using PATIO.Modules;
using System.Windows.Forms;

namespace PATIO.Classes
{
    public class AccesNet
    {
        public ClassePHP cls;
        public string Chemin;

        public List<Attribut> ListeAttribut = new List<Attribut>();
        public List<table_valeur> ListeTableValeur = new List<table_valeur>();
        public List<Parametre> ListeParametre = new List<Parametre>();

        public PATIO.Interfaces.ctrlConsole Console;

        public Fonctions fonc = new Fonctions();

        List<Element> Liste_Element = new List<Element>();
        List<dElement> Liste_dElement = new List<dElement>();
        public List<Lien> ListeLien = new List<Lien>();

        public TypeElement type_PLAN = new TypeElement("PLA", 0);
        public TypeElement type_OBJECTIF = new TypeElement("OBJ", 1);
        public TypeElement type_ACTION = new TypeElement("ACT", 2);
        public TypeElement type_INDICATEUR = new TypeElement("IND", 3);
        public TypeElement type_UTILISATEUR = new TypeElement("USR", 4);
        public TypeElement type_GROUPE = new TypeElement("GRP", 5);

        public AccesNet()
        {
        }

        public Boolean Initialiser()
        {
            cls = new ClassePHP();
            cls.Trace = true; //Active le traçage des requêtes pour le débuggage
            cls.Chemin = Chemin;
            if (!cls.Initialiser()) { return false; }

            cls.Console = Console;

            Nettoyer(); //Corrige automatiquement les bugs possibles

            //Corriger_tv();
            Charger_ListeTableValeur();
            Déterminer_CodeType();

            Charger_Element();
            Charger_Lien();
            Charger_ListeParametre();
            Charger_ListeAttribut();

            Remplir_ListeElement(type_UTILISATEUR.id, "");
            return true;
        }

        void Corriger_tv()
        {
            string sql;

            sql = "UPDATE table_valeur SET code='PLA' where code='P' and nom='TYPE_ELEMENT'";
            cls.Execute(sql);
            sql = "UPDATE table_valeur SET code='OBJ' where code='O' and nom='TYPE_ELEMENT'";
            cls.Execute(sql);
            sql = "UPDATE table_valeur SET code='ACT' where code='A' and nom='TYPE_ELEMENT'";
            cls.Execute(sql);
            sql = "UPDATE table_valeur SET code='IND' where code='I' and nom='TYPE_ELEMENT'";
            cls.Execute(sql);
            sql = "UPDATE table_valeur SET code='USR' where code='U' and nom='TYPE_ELEMENT'";
            cls.Execute(sql);
            sql = "UPDATE table_valeur SET code='GRP' where code='G' and nom='TYPE_ELEMENT'";
            cls.Execute(sql);
        }

        //Déterminer les codes des éléments
        void Déterminer_CodeType()
        {
            type_PLAN.id = Trouver_TableValeur_Code("TYPE_ELEMENT", type_PLAN.code).ID;
            type_OBJECTIF.id = Trouver_TableValeur_Code("TYPE_ELEMENT", type_OBJECTIF.code).ID;
            type_ACTION.id = Trouver_TableValeur_Code("TYPE_ELEMENT", type_ACTION.code).ID;
            type_INDICATEUR.id = Trouver_TableValeur_Code("TYPE_ELEMENT", type_INDICATEUR.code).ID;
            type_UTILISATEUR.id = Trouver_TableValeur_Code("TYPE_ELEMENT", type_UTILISATEUR.code).ID;
            type_GROUPE.id = Trouver_TableValeur_Code("TYPE_ELEMENT", type_GROUPE.code).ID;
        }

        //Intègre l'ensemble des éléments en mémoire
        //Evite de faire un appel récurrent
        public void Charger_Element()
        {
            string sql = "";

            Liste_Element = new List<Element>();
            Liste_dElement = new List<dElement>();
            ListeLien = new List<Lien>();

            //ELEMENT
            sql = "SELECT * FROM element";
            DataSet Sn = cls.ContenuRequete(sql);

            if (cls.NbLignes == 0) { return; }

            foreach (DataRow r in Sn.Tables["dataset"].Rows)
            {
                Element e = new Element();
                e.ID = int.Parse(r["id"].ToString());
                e.Element_Type = int.Parse(r["element_type"].ToString());
                e.Code = r["code"].ToString();
                e.Libelle = r["libelle"].ToString();
                e.Type_Element = int.Parse(r["type_element"].ToString());
                e.Actif = (r["actif"].ToString() == "1");

                Liste_Element.Add(e);
            }

            //Recherche des détails des éléments DELEMENT
            sql = "SELECT * FROM delement";

            //DataSet DSn = cls.ContenuTable("delement");
            DataSet DSn = cls.ContenuRequete(sql);
            foreach (DataRow r in DSn.Tables["dataset"].Rows)
            {
                dElement de = new dElement();
                de.ID = int.Parse(r["id"].ToString());
                de.Element_ID = int.Parse(r["element_id"].ToString());
                de.Attribut_ID = int.Parse(r["attribut_id"].ToString());
                de.Attribut_Code = r["attribut_code"].ToString();
                de.Valeur = r["Valeur"].ToString();
                Liste_dElement.Add(de);
            }

            //Rattachement des détails aux éléments principaux
            foreach (Element e in Liste_Element)
            {
                foreach (dElement d in Liste_dElement)
                {
                    if (e.ID == d.Element_ID) { e.Liste.Add(d); }
                }
            }
        }

        /// <summary>
        /// Procédure de chargement de la liste des liens
        /// </summary>
        public void Charger_Lien(Boolean InclusSysteme=true)
        {
            //LIEN
            string sql = "SELECT * FROM lien";
            if(!InclusSysteme) { sql += " WHERE element0_code <>'SYSTEME'"; }
            /*sql += " ORDER BY element0_type, element1_type, element2_type,";
            sql += " element0_code, element1_code, ordre";*/

            DataSet SnLien = cls.ContenuRequete(sql);

            if (cls.NbLignes == 0) { return; }

            foreach (DataRow r in SnLien.Tables["dataset"].Rows)
            {
                Lien l = new Lien();
                l.ID = int.Parse(r["id"].ToString());
                l.element0_type = int.Parse(r["element0_type"].ToString());
                l.element0_code = r["element0_code"].ToString();
                l.element0_id = int.Parse(r["element0_id"].ToString());
                l.element1_type = int.Parse(r["element1_type"].ToString());
                l.element1_code = r["element1_code"].ToString();
                l.element1_id = int.Parse(r["element1_id"].ToString());
                l.element2_type = int.Parse(r["element2_type"].ToString());
                l.element2_code = r["element2_code"].ToString();
                l.element2_id = int.Parse(r["element2_id"].ToString());
                l.ordre = int.Parse(r["ordre"].ToString());
                l.complement = r["complement"].ToString();
                ListeLien.Add(l);
            }
        }

        /// <summary>
        /// Procédure d'ajout d'un élément dans la base de données
        /// </summary>
        /// <param name="typeelement"></param>
        /// <param name="objet"></param>
        /// <returns></returns>
        //Ajoute l'ensemble des informations d'un objet
        public int Ajouter_Element(TypeElement typeelement, object objet)
        {
            int id = 0;
            Element e = new Element(); //Création de l'ossature de l'élément représentant l'objet
            e.Acces = this;
            e.Element_Type = typeelement.id;

            //Ajout des informations principales et complémentaires
            if (typeelement.code == type_PLAN.code)
            {
                Plan plan = (Plan)objet;
                plan.Acces = this;
                e = plan.Déconstruire();
                e.Acces = this;
                id = e.Enregistrer();
            }

            if (typeelement.code == type_OBJECTIF.code)
            {
                Objectif objectif = (Objectif)objet;
                objectif.Acces = this;
                e = objectif.Déconstruire();
                e.Acces = this;
                id = e.Enregistrer();
            }

            if (typeelement.code == type_ACTION.code)
            {
                PATIO.Classes.Action action = (PATIO.Classes.Action)objet;
                action.Acces = this;
                e = action.Déconstruire();
                e.Acces = this;
                id = e.Enregistrer();
            }

            if (typeelement.code == type_INDICATEUR.code)
            {
                Indicateur indic = (Indicateur)objet;
                indic.Acces = this;
                e = indic.Déconstruire();
                e.Acces = this;
                id = e.Enregistrer();
            }

            if (typeelement.code == type_UTILISATEUR.code)
            {
                Utilisateur user = (Utilisateur)objet;
                user.Acces = this;
                e = user.Déconstruire();
                e.Acces = this;
                id = e.Enregistrer();
            }

            if (typeelement.code == type_GROUPE.code)
            {
                Groupe grp = (Groupe)objet;
                grp.Acces = this;
                e = grp.Déconstruire();
                e.Acces = this;
                id = e.Enregistrer();
            }

            Liste_Element.Add(e);
            return id;
        }

        //Ajout d'un détail d'élément
        public void Ajouter_dElement(dElement d)
        {
            Liste_dElement.Add(d);

            //Application à l'élément associé
            foreach (Element e in Liste_Element)
            {
                if (e.ID == d.Element_ID)
                {
                    e.Liste.Add(d);
                    return;
                }
            }
        }

        //Ajout d'un lien
        public void Ajouter_Lien(Lien l)
        {
            ListeLien.Add(l);
        }

        //Suppression d'un élément, de ses détails et de ses liens
        public void Supprimer_Element(TypeElement typeelement, Object obj)
        {
            Element e = new Element();
            e.Acces = this;

            //Suppression de la base de données
            if (typeelement.code == type_PLAN.code)
            {
                Plan p = (Plan)obj;
                e.Element_Type = typeelement.id;
                e.ID = p.ID;
                e.Supprimer();
            }

            if (typeelement.code == type_OBJECTIF.code)
            {
                Objectif objectif = (Objectif)obj;
                e.Element_Type = typeelement.id;
                e.ID = objectif.ID;
                e.Supprimer();
            }

            if (typeelement.code == type_ACTION.code)
            {
                PATIO.Classes.Action action = (PATIO.Classes.Action)obj;
                e.Element_Type = typeelement.id;
                e.ID = action.ID;
                e.Supprimer();
            }

            if (typeelement.code == type_INDICATEUR.code)
            {
                Indicateur indic = (Indicateur)obj;
                e.Element_Type = typeelement.id;
                e.ID = indic.ID;
                e.Supprimer();
            }

            if (typeelement.code == type_UTILISATEUR.code)
            {
                Utilisateur user = (Utilisateur)obj;
                e.Element_Type = typeelement.id;
                e.ID = user.ID;
                e.Supprimer();
            }

            if (typeelement.code == type_GROUPE.code)
            {
                Groupe grp = (Groupe)obj;
                e.Element_Type = typeelement.id;
                e.ID = grp.ID;
                e.Supprimer();
            }


            //Suppression des listes de référence
            List<dElement> Liste = new List<dElement>();
            foreach (dElement d in Liste_dElement) { if (d.Element_ID != e.ID) { Liste.Add(d); } }
            Liste_dElement = Liste;

            foreach (Element el in Liste_Element)
            {
                if (el.ID == e.ID) { Liste_Element.Remove(el); break; }
            }

            //Supprime les liens faisant référence à cet objet
            List<Lien> lLien = new List<Lien>();
            foreach (Lien l in ListeLien)
            {
                if ((l.element0_id != e.ID)
                    && (l.element1_id != e.ID)
                    && (l.element2_id != e.ID)) { lLien.Add(l); }
            }
            ListeLien = lLien;
        }

        //Suppression d'un détail d'élément
        public void Supprimer_dElement(dElement d)
        {
            Liste_dElement.Remove(d);

            //Application à l'élément associé
            foreach(Element e in Liste_Element)
            {
                if(e.ID == d.Element_ID)
                { foreach(dElement dl in e.Liste)
                    {
                        if(dl.ID == d.ID) { e.Liste.Remove(dl); return; }
                    }
                }
            }
        }

        //Suppression d'un lien
        public void Supprimer_Lien(Lien l)
        {
            l.Acces = this;
            l.Supprimer();

            ListeLien.Remove(l);
        }

        //Vérifie l'existence d'un objet de type défini en fonction de son code
        public Boolean Existe_Element(TypeElement typeelement, string attribut_recherche, string code)
        {
            int typeelement_id = Trouver_TableValeur_Code("TYPE_ELEMENT", typeelement.code).ID;

            foreach (Element e in Liste_Element)
            {
                if (e.Element_Type == typeelement_id)
                {
                    switch (attribut_recherche)
                    {
                        case "CODE":
                            {
                                if (e.Code == code) { return true; }
                                break;
                            }
                        case "ID":
                            {
                                if (e.ID == int.Parse(code)) { return true; }
                                break;
                            }
                    }
                }
            }

            return false;
        }

        //Trouve l'élément selon le type et le Code recherchés et renvoie l'élément
        public Boolean Existe_Lien(TypeElement typeelement0, int element0_id, int element1_id, int element2_id)
        {
            List<Lien> Liste = Remplir_ListeLien(typeelement0, element0_id.ToString());

            foreach (Lien l in Liste)
            {
                if (l.element0_id == element0_id && l.element1_id == element1_id && l.element2_id == element2_id) { return true; }
            }
            return false;
        }

        //Trouve l'élément selon le type et l'id recherchés et renvoie l'élément
        public Object Trouver_Element(int typeelement, int id)
        {
            List<Element> Liste = new List<Element>();

            foreach (Element e in Liste_Element)
            {
                if (e.ID == id)
                {
                    Liste.Add(e);
                    //foreach (dElement d in e.Liste) { Console.Ajouter(d.Attribut_Code + "->" + d.Valeur); }

                    if (typeelement == type_PLAN.id) { return ((List<Plan>)Construire_Element(typeelement, Liste))[0]; }
                    if (typeelement == type_OBJECTIF.id) { return ((List<Objectif>)Construire_Element(typeelement, Liste))[0]; }
                    if (typeelement == type_ACTION.id) { return ((List<PATIO.Classes.Action>)Construire_Element(typeelement, Liste))[0]; }
                    if (typeelement == type_INDICATEUR.id) { return ((List<Indicateur>)Construire_Element(typeelement, Liste))[0]; }
                    if (typeelement == type_UTILISATEUR.id) { return ((List<Utilisateur>)Construire_Element(typeelement, Liste))[0]; }
                    if (typeelement == type_GROUPE.id) { return ((List<Groupe>)Construire_Element(typeelement, Liste))[0]; }
                }
            }
            Console.Ajouter("[ERREUR] Elément non trouvé : " + typeelement + ", id=" + id.ToString());
            return null;
        }

        //Trouve l'élément selon le type et le Code recherchés et renvoie l'élément
        public Object Trouver_Element(string typeelement, string Code)
        {
            foreach (Element e in Liste_Element)
            {
                if (e.Code == Code) { return e; }
            }
            return null;
        }

        //Trouve l'élément selon l'id recherché et renvoie l'élément
        public Element Trouver_Element(int id)
        {
            foreach (Element e in Liste_Element)
            {
                if (e.ID == id)
                {
                    return e;
                }
            }

            return null;
        }

        //Charge la liste des attributs dans une liste
        public void Charger_ListeAttribut()
        {
            ListeAttribut = new List<Attribut>();

            string sql;
            sql = "SELECT * FROM attribut";
            sql += " ORDER BY libelle";
            DataSet Sn = cls.ContenuRequete(sql);

            if (cls.NbLignes == 0) { return; }

            foreach (DataRow r in Sn.Tables["dataset"].Rows)
            {
                Attribut att = new Attribut();
                att.ID = int.Parse(r["id"].ToString());
                att.Code = r["Code"].ToString();
                att.Libelle = r["Libelle"].ToString();
                att.Element_Type = int.Parse(r["Element_Type"].ToString());
                att.ATT_6PO = r["att_6po"].ToString();

                ListeAttribut.Add(att);
            }
        }

        //Charche la liste des tables de valeurs dans une liste
        public void Charger_ListeTableValeur()
        {
            ListeTableValeur = new List<table_valeur>();

            string sql;
            sql = "SELECT * FROM table_valeur";
            sql += " ORDER BY nom, code";
            DataSet Sn = cls.ContenuRequete(sql);

            if (cls.NbLignes == 0) { return; }

            foreach (DataRow r in Sn.Tables["dataset"].Rows)
            {
                table_valeur tv = new table_valeur();
                tv.ID = int.Parse(r["id"].ToString());
                tv.Nom = r["nom"].ToString();
                tv.Code = r["code"].ToString();
                tv.Valeur = r["valeur"].ToString();
                tv.Valeur6PO = r["valeur_6po"].ToString();

                ListeTableValeur.Add(tv);
            }
        }

        //Charge la liste des attributs dans une liste
        public void Charger_ListeParametre()
        {
            ListeParametre = new List<Parametre>();

            string sql;
            sql = "SELECT * FROM parametre";
            sql += " ORDER BY code";

            DataSet Sn = cls.ContenuRequete(sql);

            if (cls.NbLignes == 0) { return; }

            foreach (DataRow r in Sn.Tables["dataset"].Rows)
            {
                Parametre p = new Parametre();
                p.ID = int.Parse(r["id"].ToString());
                p.Code = r["code"].ToString();
                p.Valeur = r["valeur"].ToString();

                ListeParametre.Add(p);
            }
        }

        //Charge la liste des utilisateurs PILOTE dans une liste
        public List<Utilisateur> Remplir_ListeUtilisateurPilote()
        {
            List<Utilisateur> Liste = new List<Utilisateur>();

            List<Utilisateur> ListeUtilisateur = (List<Utilisateur>)Remplir_ListeElement(type_UTILISATEUR.id, "");

            foreach (Utilisateur user in ListeUtilisateur)
            {
                if (user.TypeLicence == TypeLicence.PILOTE) { Liste.Add(user); }
            }
            Liste.Sort();

            return Liste;
        }

        //Trouve un utilisateur selon identifiant et renvoie l'objet
        public Utilisateur Trouver_Utilisateur(int id)
        {
            Utilisateur utilisateur = null;

            List<Utilisateur> ListeUtilisateur = (List<Utilisateur>)Remplir_ListeElement(type_UTILISATEUR.id, "");

            foreach (Utilisateur user in ListeUtilisateur)
            {
                if (user.ID == id)
                {
                    utilisateur = user;
                    break;
                }
            }

            return utilisateur;
        }

        //Trouve un utilisateurselon identifiant et renvoie l'objet
        public Utilisateur Trouver_Utilisateur(string Code)
        {
            Utilisateur utilisateur = null;

            List<Utilisateur> ListeUtilisateur = (List<Utilisateur>)Remplir_ListeElement(type_UTILISATEUR.id, "");

            foreach (Utilisateur user in ListeUtilisateur)
            {
                if (user.Code == Code)
                {
                    utilisateur = user;
                    break;
                }
            }

            return utilisateur;
        }

        //Charge l'ensemble des informations relatives à l'élément
        public Object Remplir_ListeElement(int typeelement, int ID, Boolean Actif = false)
        {
            List<Element> Liste = new List<Element>();

            foreach (Element e in Liste_Element)
            {
                if (e.Element_Type == typeelement && e.ID == ID)
                {
                    Boolean ok1 = (e.ID == ID);
                    bool ok2 = (Actif) ? e.Actif : true;
                    if (ok1 && ok2) { Liste.Add(e); }
                }
            }

            //Construction des objets de gestion à partir des éléments*/
            return Construire_Element(typeelement, Liste);
        }

        //Charge l'ensemble des informations relatives à l'élément
        public Object Remplir_ListeElement(int typeelement, string code, Boolean Actif = false)
        {
            List<Element> Liste = new List<Element>();

            foreach (Element e in Liste_Element)
            {
                if (e.Element_Type == typeelement)
                {
                    Boolean ok1 = (code.Length > 0) ? (e.Code == code) : true;
                    bool ok2 = (Actif) ? e.Actif : true;
                    if (ok1 && ok2) { Liste.Add(e); }
                }
            }
            return Construire_Element(typeelement, Liste);
        }

        //Construction les éléments à partir des données extraites et stockées dans Liste_Element et Liste_dElement
        //La liste correspondant au type d'objet est alors chargée
        public Object Construire_Element(int typeelement, List<Element> Liste)
        {
            List<Plan> ListePlan = new List<Plan>();
            List<Objectif> ListeObjectif = new List<Objectif>();
            List<PATIO.Classes.Action> ListeAction = new List<PATIO.Classes.Action>();
            List<Indicateur> ListeIndicateur = new List<Indicateur>();
            List<Utilisateur> ListeUtilisateur = new List<Utilisateur>();
            List<Groupe> ListeGroupe = new List<Groupe>();

            foreach (Element e in Liste)
            {
                if (typeelement == type_PLAN.id)
                {
                    Plan plan = new Plan() { Acces = this, };
                    plan.Construire(e);
                    ListePlan.Add(plan);
                }
                if (typeelement == type_OBJECTIF.id)
                {
                    Objectif obj = new Objectif() { Acces = this, };
                    obj.Construire(e);
                    ListeObjectif.Add(obj); ;
                }
                if (typeelement == type_ACTION.id)
                {
                    PATIO.Classes.Action action = new PATIO.Classes.Action() { Acces = this, };
                    action.Construire(e);
                    ListeAction.Add(action);
                }
                if (typeelement == type_INDICATEUR.id)
                {
                    Indicateur indic = new Indicateur() { Acces = this, };
                    indic.Construire(e);
                    ListeIndicateur.Add(indic);
                }
                if (typeelement == type_UTILISATEUR.id)
                {
                    Utilisateur user = new Utilisateur() { Acces = this, };
                    user.Construire(e);
                    ListeUtilisateur.Add(user);
                }
                if (typeelement == type_GROUPE.id)
                {
                    Groupe grp = new Groupe() { Acces = this };
                    grp.Construire(e);
                    ListeGroupe.Add(grp);
                }
            }

            //Tri de la liste et renvoi de l'objet de type LIST
            if (typeelement == type_PLAN.id) { ListePlan.Sort(); return ListePlan; }
            if (typeelement == type_OBJECTIF.id) { ListeObjectif.Sort(); return ListeObjectif; }
            if (typeelement == type_ACTION.id) { ListeAction.Sort(); return ListeAction; }
            if (typeelement == type_INDICATEUR.id) { ListeIndicateur.Sort(); return ListeIndicateur; }
            if (typeelement == type_UTILISATEUR.id) { ListeUtilisateur.Sort(); return ListeUtilisateur; }
            if (typeelement == type_GROUPE.id) { ListeGroupe.Sort(); return ListeGroupe; }

            return null;
        }

        //Permet de modifier la valeur d'activation des éléments
        public void Modifier_Element(TypeElement typeelement, int ID, Boolean Actif)
        {
            //Mise à jour de la base
            string sql;
            sql = "UPDATE element SET actif='" + (Actif ? "1" : "0") + "'";
            sql += " WHERE element_type ='" + typeelement.id + "'";
            sql += " AND id='" + ID + "'";

            cls.Execute(sql);

            //Application aux éléments chargés

            foreach (Element e in Liste_Element)
            {
                if (e.ID == ID && e.Element_Type == typeelement.id) { e.Actif = Actif; break; }
            }
        }

        //Remplit la liste avec les détail des éléments
        public List<dElement> Remplir_ListedElement()
        {
            return Liste_dElement;
        }

        //Charge la liste des liens pour un ensemble défini (ex  plan)
        public List<Lien> Remplir_ListeLien(TypeElement element_type, string element_id = "")
        {
            List<Lien> Liste = new List<Lien>();

            foreach (Lien l in ListeLien)
            {
                if (l.element0_type == element_type.id)
                {
                    if (element_type.id > 0)
                    {
                        if (l.element0_id == int.Parse(element_id)) { Liste.Add(l); }
                    }
                    else { Liste.Add(l); }
                }
            }

            return Liste;
        }

        //Charge la liste des liens pour un ensemble défini (ex  plan) dont le type niveau 1 et 2 sont identiques
        public List<Lien> Remplir_ListeLienSYSTEME(TypeElement element_type, string element1_id = "", string element2_id = "")
        {
            List<Lien> Liste = new List<Lien>();

            foreach (Lien l in ListeLien)
            {
                if (l.element0_type == Trouver_TableValeur_Code("TYPE_ELEMENT", type_PLAN.code).ID && l.element0_id == 1)
                {
                    if (l.element1_type == element_type.id && l.element2_type == element_type.id)
                    {
                        Boolean ok1 = (element1_id.Length > 0) ? l.element1_id == int.Parse(element1_id) : true;
                        Boolean ok2 = (element2_id.Length > 0) ? l.element2_id == int.Parse(element2_id) : true;

                        if (ok1 && ok2) { Liste.Add(l); }
                    }
                    //else { Liste.Add(l); }
                }
            }

            return Liste;
        }

        //Charge la liste des liens ayant comme parent l'id de l'élément passé
        public Lien Donner_LienParent(int id)
        {
            foreach (Lien l in ListeLien)
            {
                if (l.ID == id) { return l; }
            }

            return null;
        }

        //Enregistre un élement
        public void Enregistrer(TypeElement typeelement, object obj)
        {
            Element e = new Element() { Acces = this, };
            e.Element_Type = typeelement.id;

            //Le principe de la déconstruction est de mettre sous la forme 
            // Element - dElement les informations contenues dans chaque objet
            // La mise à jour va modifier les informations principales et
            // mettre à jour les informations secondaires si elles sont différentes.
            if (typeelement.code == type_PLAN.code)
            {
                Plan plan = (Plan)obj;
                e = plan.Déconstruire();
                e.Acces = this;
                e.MettreAJour();
            }

            if (typeelement.code == type_OBJECTIF.code)
            {
                Objectif objectif = (Objectif)obj;
                e = objectif.Déconstruire();
                e.Acces = this;
                e.MettreAJour();
            }

            if (typeelement.code == type_ACTION.code)
            {
                PATIO.Classes.Action action = (PATIO.Classes.Action)obj;
                e = action.Déconstruire();
                e.Acces = this;
                e.MettreAJour();
            }

            if (typeelement.code == type_INDICATEUR.code)
            {
                Indicateur indic = (Indicateur)obj;
                e = indic.Déconstruire();
                e.Acces = this;
                e.MettreAJour();
            }

            if (typeelement.code == type_UTILISATEUR.code)
            {
                Utilisateur user = (Utilisateur)obj;
                e = user.Déconstruire();
                e.Acces = this;
                e.MettreAJour();
            }

            if (typeelement.code == type_GROUPE.code)
            {
                Groupe grp = (Groupe)obj;
                e = grp.Déconstruire();
                e.Acces = this;
                e.MettreAJour();
            }

            //Actualise la liste de référence principale
            foreach (Element el in Liste_Element)
            {
                if (el.ID == e.ID)
                {
                    //Mise à jour des informations principales
                    Liste_Element.Remove(el);
                    Liste_Element.Add(e);

                    //Mise à jour des détails de l'élement dans la liste de référence
                    foreach (dElement del in el.Liste)
                    {
                        if (del.Element_ID == e.ID) { Liste_dElement.Remove(del); }
                    }

                    foreach (dElement d in e.Liste) { Liste_dElement.Add(d); }
                    break;
                }
            }
        }

        //Trouve l'ID d'un attribut dans la liste selon son code
        public int Trouver_Attribut_ID(int typeelement, string code = "", string valeur = "")
        {
            int ID = 0;

            foreach (Attribut att in ListeAttribut)
            {
                if (att.Element_Type == typeelement && att.Code == code)
                {
                    ID = att.ID;
                    break;
                }
            }

            //if(ID==0) { Console.Ajouter("L'attribut [" + code + "] de type " + typeelement + " non trouvé");  }
            return ID;
        }

        //Trouve le libellé d'un attribut dans la liste selon son code
        public string Trouver_Attribut_Libelle(string code = "")
        {
            string libelle = "";

            foreach (Attribut att in ListeAttribut)
            {
                if (att.Code == code)
                {
                    libelle = att.Libelle;
                    break;
                }
            }

            //if(ID==0) { Console.Ajouter("L'attribut [" + code + "] de type " + typeelement + " non trouvé");  }
            return libelle;
        }

        //Trouve un attribut par son ID
        public Attribut Trouver_Attribut(int ID)
        {
            foreach (Attribut att in ListeAttribut)
            {
                if (att.ID == ID)
                {
                    return att;
                }
            }

            return null;
        }

        //Trouve un attribut par son ID
        public Parametre Trouver_Parametre(int ID)
        {
            foreach (Parametre p in ListeParametre)
            {
                if (p.ID == ID)
                {
                    return p;
                }
            }

            return null;
        }

        //Trouve l'attribut 6PO d'un attribut dans la liste selon son code
        public string Trouver_Attribut_6PO(TypeElement typeelement, string code = "")
        {
            string att6po = "";

            foreach (Attribut att in ListeAttribut)
            {
                if (att.Element_Type == typeelement.id && att.Code == code)
                {
                    att6po = att.ATT_6PO;
                    break;
                }
            }

            return att6po;
        }

        //Trouve l'ID dans une table de valeur correspondant au nom et à la valeur indiqués
        public int Trouver_TableValeur_ID(string nom, string valeur)
        {
            int ID = 0;

            foreach (table_valeur tv in ListeTableValeur)
            {
                if (tv.Nom == nom && tv.Valeur == valeur)
                {
                    ID = tv.ID;
                    break;
                }
            }

            return ID;
        }

        //Trouve une table de valeur par son ID
        public table_valeur Trouver_TableValeur(int id)
        {
            foreach (table_valeur tv in ListeTableValeur)
            {
                if (tv.ID == id)
                {
                    return tv;
                }
            }

            return null;
        }

        //Trouve l'ID dans une table de valeur correspondant au nom et à la valeur indiqués
        public table_valeur Trouver_TableValeur_Code(string nom, string Code)
        {
            foreach (table_valeur tv in ListeTableValeur)
            {
                if (tv.Nom == nom && tv.Code == Code)
                {
                    return tv;
                }
            }

            return null;
        }

        //Trouve l'élément tv dans une table de valeur correspondant au nom et à la valeur indiqués
        public string Trouver_TableValeur_Valeur(string nom, string Valeur, string attribut="CODE")
        {
            foreach (table_valeur tv in ListeTableValeur)
            {
                if (tv.Nom == nom && tv.Valeur == Valeur)
                {
                    switch(attribut)
                    {
                        case "CODE": return tv.Code;
                        case "ID": return tv.ID.ToString(); 
                        case "6PO": return tv.Valeur6PO;
                    }
                }
            }

            return "";
        }

        //Trouve la valeur associée dans 6PO
        public string Trouver_TableValeur_6PO(string nom, int ID)
        {
            foreach (table_valeur tv in ListeTableValeur)
            {
                if (tv.Nom == nom && tv.ID == ID)
                {
                    return tv.Valeur6PO;
                }
            }

            return "";
        }

        public string Trouver_TableValeur_6PO(string nom, string valeur)
        {
            foreach (table_valeur tv in ListeTableValeur)
            {
                if (tv.Nom == nom && tv.Valeur == valeur)
                {
                    return tv.Valeur6PO;
                }
            }

            return "";
        }

        //Donne le niveau et la valeur associée dans 6PO
        public void Donner_TableValeur_6PO(string nom_debut, string valeur, ref string nom_fin, ref string niveau, ref string valeurNiveau)
        {
            foreach (table_valeur tv in ListeTableValeur)
            {
                if (tv.Nom.Contains(nom_debut) && tv.ID == int.Parse(valeur))
                {
                    nom_fin = tv.Nom;
                    niveau = tv.Code;
                    valeurNiveau = tv.Valeur6PO;
                    break;
                }
            }
        }

        //Mise à jour de la liste des détails (récupération des id des détails
        public void Actualiser_dElement(int ID)
        {
            string sql = "";

            List<dElement> Liste = new List<dElement>();

            foreach (dElement d in Liste_dElement)
            {
                if (d.Element_ID != ID) { Liste.Add(d); }
            }

            //Recherche des éléments en base pour avoir l'ID
            sql = "SELECT * FROM delement";
            sql += " WHERE element_id='" + ID + "'";
            DataSet Sn = cls.ContenuRequete(sql);

            if (cls.NbLignes > 0)
            {
                foreach (DataRow r in Sn.Tables["dataset"].Rows)
                {
                    dElement d = new dElement();
                    d.ID = int.Parse(r["id"].ToString());
                    d.Element_ID = int.Parse(r["element_id"].ToString());
                    d.Attribut_ID = int.Parse(r["attribut_id"].ToString());
                    d.Attribut_Code = r["attribut_code"].ToString();
                    d.Valeur = r["valeur"].ToString();
                    Liste.Add(d);
                }
            }
            Liste_dElement = Liste;
        }

        //Renvoie la valeur d'un paramètre
        public string Donner_ValeurParametre(string Code)
        {
            foreach (Parametre p in ListeParametre)
            {
                if (p.Code == Code) { return p.Valeur; }
            }

            return null;
        }

        //retourne la liste des valeurs pour une table de valeurs précise
        public List<table_valeur> Remplir_ListeTableValeur(string nom)
        {
            List<table_valeur> Liste = new List<table_valeur>();

            foreach (table_valeur a in ListeTableValeur)
            {
                if (a.Nom == nom)
                {
                    Liste.Add(a);
                }
            }
            Liste.Sort();
            return Liste;
        }

        //Retourne la liste des différentes tables de valeurs
        public List<string> Remplir_ListeTableValeurNom(string ordre = "ASC")
        {
            List<string> Liste = new List<string>();

            string sql;

            sql = "SELECT DISTINCT nom FROM table_valeur";
            sql += (ordre == "ASC") ? " ORDER BY 1" : " ORDER BY 1 DESC";
            DataSet Sn = cls.ContenuRequete(sql);
            foreach (DataRow r in Sn.Tables["dataset"].Rows)
            {
                Liste.Add(r[0].ToString());
            }
            return Liste;
        }

        //Renvoie la la liste des actions dont un utilisateur est membre
        public List<PATIO.Classes.Action> Donner_ListeActionMembre(int id_user)
        {
            List<PATIO.Classes.Action> Liste = new List<PATIO.Classes.Action>();
            int attribut_id = Trouver_Attribut_ID(type_ACTION.id, "EQUIPE");

            foreach (dElement d in Liste_dElement)
            {
                if (d.Valeur == id_user.ToString() && d.Attribut_ID == attribut_id)
                {
                    PATIO.Classes.Action a1 = (PATIO.Classes.Action)Trouver_Element(type_ACTION.id, d.Element_ID);
                    Boolean ok = false;
                    foreach (PATIO.Classes.Action a0 in Liste)
                    { if (a1.ID == a0.ID) { ok = true; break; } }
                    if (!ok) { Liste.Add(a1); }
                }
            }

            return Liste;
        }

        //Renvoie la liste des utilisateurs ayant un rôle (aus ens 6PO) pour un objet de gestion
        //Co-pilote, manager, consultation
        public List<Utilisateur> Donner_ListeEquipeMembre(int element_id, string Role)
        {
            List<Utilisateur> Liste = new List<Utilisateur>();

            foreach (dElement d in Liste_dElement)
            {
                if (d.Element_ID == (int)element_id && d.Attribut_Code == Role)
                {
                    Utilisateur u1 = (Utilisateur)Trouver_Element(type_UTILISATEUR.id, int.Parse(d.Valeur));
                    Liste.Add(u1);
                }
            }
            return Liste;
        }

        public void Sauvegarder_local()
        {
            string fichier;
            DataSet Sn;

            //Répertoire
            if (!System.IO.Directory.Exists(Chemin + "\\Save")) { System.IO.Directory.CreateDirectory(Chemin + "\\Save"); }

            //Fichier Element
            fichier = Chemin + "\\Save\\element.xml";
            if (System.IO.File.Exists(fichier)) { System.IO.File.Delete(fichier); }
            Sn = cls.ContenuRequete("SELECT * FROM element");
            Sn.WriteXml(fichier);

            //Fichier dElement
            fichier = Chemin + "\\Save\\delement.xml";
            if (System.IO.File.Exists(fichier)) { System.IO.File.Delete(fichier); }
            Sn = cls.ContenuRequete("SELECT * FROM delement");
            Sn.WriteXml(fichier);

            //Fichier Lien
            fichier = Chemin + "\\Save\\lien.xml";
            if (System.IO.File.Exists(fichier)) { System.IO.File.Delete(fichier); }
            Sn = cls.ContenuRequete("SELECT * FROM lien");
            Sn.WriteXml(fichier);

            //Fichier Attriut
            fichier = Chemin + "\\Save\\attribut.xml";
            if (System.IO.File.Exists(fichier)) { System.IO.File.Delete(fichier); }
            Sn = cls.ContenuRequete("SELECT * FROM attribut");
            Sn.WriteXml(fichier);

            //Fichier Table de Valeur
            fichier = Chemin + "\\Save\\table_valeur.xml";
            if (System.IO.File.Exists(fichier)) { System.IO.File.Delete(fichier); }
            Sn = cls.ContenuRequete("SELECT * FROM table_valeur");
            Sn.WriteXml(fichier);

            //Fichier Parametre
            fichier = Chemin + "\\Save\\parametre.xml";
            if (System.IO.File.Exists(fichier)) { System.IO.File.Delete(fichier); }
            Sn = cls.ContenuRequete("SELECT * FROM parametre");
            Sn.WriteXml(fichier);
        }

        public void MettreAJour_dElement(int element_id, string valeur_prec, string valeur_suiv, string attribut_code, int attribut_id)
        {
            string sql;

            //Suppression de l'ancienne valeur
            if (valeur_prec.Length > 0)
            {
                sql = "DELETE FROM delement";
                sql += " WHERE element_id='" + element_id + "'";
                sql += " AND attribut_code='" + attribut_code + "'";
                sql += " AND valeur='" + valeur_prec + "'";
                cls.Execute(sql);
            }

            //Insertion de la nouvelle valeur
            sql = "INSERT INTO delement(element_id, attribut_id, attribut_code, valeur) VALUES (";
            sql += "'" + element_id + "',";
            sql += "'" + attribut_id + "',";
            sql += "'" + attribut_code + "',";
            sql += "'" + valeur_suiv + "')";
            cls.Execute(sql);

            int id = 0;
            sql = "SELECT id FROM delement";
            sql += " WHERE element_id='" + element_id + "'";
            sql += " AND attribut_code='" + attribut_code + "'";
            sql += " AND valeur='" + valeur_suiv + "'";
            DataSet sn = cls.ContenuRequete(sql);
            if (cls.NbLignes > 0) { id = int.Parse(sn.Tables["dataset"].Rows[0][0].ToString()); }
            else { MessageBox.Show("Problème avec l'id"); }

            //Construction du nouveau dElement
            dElement d_new = new dElement();
            d_new.ID = id;
            d_new.Element_ID = element_id;
            d_new.Attribut_ID = attribut_id;
            d_new.Attribut_Code = attribut_code;
            d_new.Valeur = valeur_suiv;

            //Application sur Element
            foreach (Element e in Liste_Element)
            {
                if (e.ID == element_id)
                {
                    foreach (dElement d in e.Liste)
                    {
                        if (d.Attribut_Code == attribut_code && d.Valeur == valeur_prec)
                        { e.Liste.Remove(d); break; }
                    }
                    e.Liste.Add(d_new);
                    break;
                }
            }

            //Application sur la liste dElement
            foreach (dElement d in Liste_dElement)
            {
                if (d.Element_ID == element_id && d.Attribut_Code == attribut_code && d.Valeur == valeur_prec)
                { Liste_dElement.Remove(d); break; }
            }
            Liste_dElement.Add(d_new);
        }

        //Modifie les dates pour l'ensemble des éléments d'un plan
        public void Modifier_Dates_Plan(Plan plan)
        {
            List<Lien> Liste = Remplir_ListeLien(type_PLAN, plan.ID.ToString());

            //Objectif
            List<Objectif> ListeObj =(List<Objectif>) Remplir_ListeElement(type_OBJECTIF.id, "");

            foreach (Lien l in Liste)
            {
                foreach (Objectif obj in ListeObj)
                {
                    if(l.element2_id == obj.ID && obj.Code.Contains(plan.Abrege))
                    {
                        obj.DateDebut = plan.DateDebut;
                        obj.DateFin = plan.DateFin;
                        Enregistrer(type_OBJECTIF, obj);
                        break;
                    }
                }
            }

            //Action
            List<PATIO.Classes.Action> ListeAction = (List<PATIO.Classes.Action>)Remplir_ListeElement(type_ACTION.id, "");

            foreach (Lien l in Liste)
            {
                foreach (PATIO.Classes.Action action in ListeAction)
                {
                    if (l.element2_id == action.ID && action.Code.Contains(plan.Abrege))
                    {
                        action.DateDebut = plan.DateDebut;
                        action.DateFin = plan.DateFin;
                        Enregistrer(type_ACTION, action);
                        break;
                    }
                }
            }
        }

        public Boolean Supprimer_dElement(int element_id, int attribut_id)
        {
            string sql;

            sql = "DELETE FROM delement";
            sql += " WHERE element_id='" + element_id + "'";
            sql += " AND attribut_id='" + attribut_id + "'";

            this.cls.Execute(sql);
            if (this.cls.erreur.Length > 0) { return false; }

            return true;
        }

        /// <summary>
        /// Renvoie une chaîne de caractère contenant les valeurs des indices de table de valeurs
        /// </summary>
        /// <param name="Liste"></param> Liste des indices de table de valeurs
        /// <param name="nom_tv"></param> nom de la table de valeurs
        /// <param name="valeur"></param> permet de retourner la valeur correspondante (cas des tables multiples)
        /// <param name="raccourci"></param> permet d'iniquer de couper les valeurs retournées au séparateur :
        /// <returns></returns>
        public string Donner_Chaine_Liste(List<int> Liste, string nom_tv, string valeur="", Boolean raccourci=false)
        {
            string Texte = "";

            foreach (table_valeur tv in this.Remplir_ListeTableValeur(nom_tv))
            {
                Boolean ok = false;
                foreach (int k in Liste)
                {
                    if (tv.ID == k)
                    {
                        if(valeur.Length>0)
                        { if(tv.Nom == valeur) { ok = true; break; }}
                        else { ok = true; break; }
                    }
                }
                if (ok)
                {
                    string val_final = tv.Valeur;
                    if(raccourci) { val_final = val_final.Split(':')[0].Trim(); }
                    Texte += ((Texte.Length > 0) ? ", " : "") + val_final;
                }
            }
            return Texte;
        }

        /// </summary>
        /// <param name="Liste"></param> Liste des indices de table de valeurs
        /// <param name="nom_tv"></param> nom de la table de valeurs
        /// <param name="valeur"></param> permet de retourner la valeur correspondante (cas des tables multiples)
        /// <param name="raccourci"></param> permet d'iniquer de couper les valeurs retournées au séparateur :
        /// <returns></returns>
        public string Donner_Chaine_Liste_Utilisateur(List<int> Liste)
        {
            string Texte = "";

            foreach (Utilisateur user in (List<Utilisateur>) this.Remplir_ListeElement(type_UTILISATEUR.id,""))
            {
                foreach (int k in Liste)
                {
                    if (user.ID == k)
                    {
                        Texte += ((Texte.Length > 0) ? ", " : "") + user.Nom + " " + user.Prenom;
                    }
                }
            }
            return Texte;
        }

        public Boolean Exister_Valeur(List<int> Liste, string nom_tv, string valeur, Boolean ToutesValeurs=false)
        {
            foreach (table_valeur tv in this.Remplir_ListeTableValeur(nom_tv))
            {
                foreach (int k in Liste)
                {
                    if (tv.ID == k)
                    {
                        if (ToutesValeurs) { return true; }
                        if (tv.Valeur == valeur) { return true; }
                    }
                }
            }
            return false;
        }

        public void Nettoyer()
        {
            string sql;

            sql = "DELETE FROM Lien WHERE element1_id = element2_id";
            this.cls.Execute(sql);
        }

        /// <summary>
        /// Retourne la liste des liens affectant un élément
        /// </summary>
        /// <param name="id_element"></param> Identifiant de l'élément
        /// <returns></returns>
        public List<Lien> Remplir_ListeLienDirection(int id_direction, Boolean pilote, Boolean associe)
        {
            List<int> ListeElement = new List<int>();

            //Recherche des éléments concernés
            foreach (dElement d in Liste_dElement)
            {
                if (d.Attribut_Code == "DIRECTION_PILOTE" && d.Valeur == id_direction.ToString() && pilote)
                {
                    if (ListeElement.IndexOf(d.Element_ID) < 0) { ListeElement.Add(d.Element_ID); }
                }

                if (d.Attribut_Code == "DIRECTION_ASSOCIE" && d.Valeur == id_direction.ToString() && associe)
                {
                    if (ListeElement.IndexOf(d.Element_ID) < 0) { ListeElement.Add(d.Element_ID); }
                }
            }

            List<Lien> lLiens = new List<Lien>();
            lLiens = this.Remplir_ListeLienElement(ListeElement);

            return lLiens;
        }

        /// <summary>
        /// Retourne la liste des liens affectant un élément
        /// </summary>
        /// <param name="id_territoire"></param> Identifiant du territoire
        /// <returns></returns>
        public List<Lien> Remplir_ListeLienTerritoire(int id_territoire)
        {
            List<int> ListeElement = new List<int>();

            //Recherche des éléments concernés
            foreach (dElement d in Liste_dElement)
            {
                if (d.Attribut_Code == "TSANTE" && d.Valeur == id_territoire.ToString())
                {
                    if (ListeElement.IndexOf(d.Element_ID) < 0) { ListeElement.Add(d.Element_ID); }
                }
            }

            List<Lien> lLiens = new List<Lien>();
            lLiens = this.Remplir_ListeLienElement(ListeElement);

            return lLiens;
        }

        /// <summary>
        /// Retourne la liste des liens affectant un élément
        /// </summary>
        /// <param name="id_territoire"></param> Identifiant du territoire
        /// <returns></returns>
        public List<Lien> Remplir_ListeLienRelationPriorité(string id_territoire)
        {
            List<int> ListeElement = new List<int>();

            List<table_valeur> tv = this.Remplir_ListeTableValeur(id_territoire);

            //Recherche des éléments concernés
            foreach (dElement d in Liste_dElement)
            {
                foreach (table_valeur tvv in tv)
                {
                    if (d.Attribut_Code == "PRIORITE_CTS" && d.Valeur == tvv.ID.ToString())
                    {
                        if (ListeElement.IndexOf(d.Element_ID) < 0) { ListeElement.Add(d.Element_ID); }
                    }
                }
            }

            List<Lien> lLiens = new List<Lien>();
            lLiens = this.Remplir_ListeLienElement(ListeElement);

            return lLiens;
        }

        /// <summary>
        /// Retourne les liens affectant le
        /// </summary>
        /// <param name="id_element"></param>
        /// <returns></returns>
        public List<Lien> Remplir_ListeLienElement(List<int> Liste)
        {
            string chaine = "";

            foreach(int e in Liste)
            {
                chaine += ((chaine.Length > 0) ? "," : "") + e.ToString();
            }
            if(chaine.Length == 0) { return null; }

            List<Lien> lLien = new List<Lien>();
            string sql;

            sql = "SELECT * FROM lien";
            sql += " WHERE (element0_id in (" + chaine + ")";
            sql += " OR element1_id in (" + chaine + ")";
            sql += " OR element2_id in (" + chaine + "))";
            sql += " AND element0_code <> 'SYSTEME'"; // hormis les liens système
            DataSet Sn = cls.ContenuRequete(sql);
            if (cls.NbLignes == 0) { return lLien; }

            foreach (DataRow r in Sn.Tables["dataset"].Rows)
            {
                Lien l = new Lien();
                l.ID = int.Parse(r["id"].ToString());
                l.element0_id = int.Parse(r["element0_id"].ToString());
                l.element0_type = int.Parse(r["element0_type"].ToString());
                l.element0_code = r["element0_code"].ToString();
                l.element1_id = int.Parse(r["element1_id"].ToString());
                l.element1_type = int.Parse(r["element1_type"].ToString());
                l.element1_code = r["element1_code"].ToString();
                l.element2_id = int.Parse(r["element2_id"].ToString());
                l.element2_type = int.Parse(r["element2_type"].ToString());
                l.element2_code = r["element2_code"].ToString();
                l.ordre = int.Parse(r["ordre"].ToString());
                l.complement = r["complement"].ToString();

                if (lLien.IndexOf(l) < 0) { lLien.Add(l); }
            }

            return lLien;
        }

        /// <summary>
        /// Procédure d'export du contenu d'une liste de liens vers un fichier texte
        /// </summary>
        /// <param name="Liste"></param>
        public void Exporter_Lien(List<Lien> Liste)
        {
            string fichier = Chemin + "\\Fichiers\\liens.txt";
            string Texte = "";

            foreach(Lien l in Liste)
            {
                Texte += l.ID.ToString() + "\t";
                Texte += l.element0_type.ToString() + "\t";
                Texte += l.element0_id.ToString() + "\t";
                Texte += l.element0_code.ToString() + "\t";
                Texte += l.element1_type.ToString() + "\t";
                Texte += l.element1_id.ToString() + "\t";
                Texte += l.element1_code.ToString() + "\t";
                Texte += l.element2_type.ToString() + "\t";
                Texte += l.element2_id.ToString() + "\t";
                Texte += l.element2_code.ToString() + "\t";
                Texte += l.ordre.ToString() + "\t";
                Texte += l.complement.ToString() + "\t";

                string ordrelien = l.element0_type.ToString()
                           + l.element1_type.ToString()
                           + l.element2_type.ToString()
                           + l.element0_code + l.element1_code
                           + string.Format("{0,5:X5}", l.ordre);
                Texte += ordrelien + "\n";
            }

            System.IO.File.WriteAllText(fichier, Texte);

        }

        /// <summary>
        /// Permet de créer l'arborescence globale
        /// puis de supprimr les noeuds non inclus
        /// </summary>
        public TreeNode Donner_ArbreGlobal()
        {
            TreeNode NodG = new TreeNode();

            //On charge la liste globale des liens, correspond à l'ensemble des éléments utilisés
            Charger_Lien(false); //On ne prend pas les liens organisant les liens du système (intra-élément)
            ListeLien.Sort();

            //Phase 1 : Plan (element0)
            foreach(Lien l in ListeLien)
            {
                if(l.element0_type == type_PLAN.id && l.element0_code != "SYSTEME")
                {
                    if (NodG.Nodes.Find(l.element0_id.ToString(), true).Length == 0)
                    {
                        Plan plan = (Plan)Trouver_Element(type_PLAN.id, l.element0_id);

                        if (plan != null)
                        {
                            TreeNode nd = new TreeNode();
                            nd.Text = plan.Libelle;
                            nd.Name = plan.ID.ToString();
                            nd.Tag = "0";
                            nd.ToolTipText = nd.Name;
                            nd.ToolTipText = "0";
                            nd.Tag = l;
                            NodG.Nodes.Add(nd);
                        }
                    }
                }
            }

            //Phase 2 : Objectifs (element2 de type Objectif)
            foreach (Lien l in ListeLien)
            {
                if (l.element2_type == type_OBJECTIF.id && l.element0_code != "SYSTEME")
                {
                    if (NodG.Nodes.Find(l.element2_id.ToString(), true).Length == 0)
                    {
                        Objectif obj = (Objectif)Trouver_Element(type_OBJECTIF.id, l.element2_id);

                        TreeNode nd = new TreeNode();
                        nd.Text = obj.Libelle;
                        nd.Name = obj.ID.ToString();
                        nd.Tag = "0";
                        nd.ToolTipText = nd.Name;
                        nd.ToolTipText = "0";
                        nd.Tag = l;

                        //Recherche du parent
                        TreeNode[] nod = NodG.Nodes.Find(l.element1_id.ToString(), true);
                        if (nod.Length > 0) { nod[0].Nodes.Add(nd); }
                        //else { MessageBox.Show("Non trouvé " + l.element1_id); }
                    }
                }
            }

            //Phase 3 : Actions (element2 de type Action)
            foreach (Lien l in ListeLien)
            {
                if (l.element2_type == type_ACTION.id && l.element0_code != "SYSTEME")
                {
                    if (NodG.Nodes.Find(l.element2_id.ToString(), true).Length == 0)
                    {
                        PATIO.Classes.Action action = (PATIO.Classes.Action)Trouver_Element(type_ACTION.id, l.element2_id);

                        if (action != null)
                        {
                            TreeNode nd = new TreeNode();
                            nd.Text = action.Libelle;
                            nd.Name = action.ID.ToString();
                            nd.Tag = "0";
                            nd.ToolTipText = nd.Name;
                            nd.ToolTipText = "0";
                            nd.Tag = l;

                            //Recherche du parent
                            TreeNode[] nod = NodG.Nodes.Find(l.element1_id.ToString(), true);
                            if (nod.Length > 0) { nod[0].Nodes.Add(nd); }
                        }
                    }
                }
            }

            return NodG; //Retourne l'arbre avec en premiers noeuds la liste des plans construits
        }

        /// <summary>
        /// Procédure permettant d'avoir la liste des noeus finaux (sans enfant) d'un arbre
        /// </summary>
        /// <param name="Nod"></param> Noeud à traiter
        /// <param name="Liste"></param> Liste des noeuds finaux
        public void Donner_ListeNoeudFinaux(TreeNode Nod,ref List<TreeNode> Liste)
        {
            //Le noeud n'a pas d'enfant (=final) -> on l'ajoute à la liste
            if (Nod.Nodes.Count == 0) { Liste.Add(Nod); }
            else
            {
                //Le noeud a des enfants -> on les parcoure (récursivité)
                foreach (TreeNode nd in Nod.Nodes) { Donner_ListeNoeudFinaux(nd, ref Liste); }
            }
        }

        /// <summary>
        /// Procédure d'exclusion d'un arbre des noeuds à inclure
        /// </summary>
        /// <param name="NodG"></param>
        /// <param name="Liste"></param>
        /// <returns></returns>
        public TreeNode Exclure_Arbre(TreeNode NodG, List<Lien> Liste, ref List<Lien> ListeLien)
        {
            TreeNode Nd = new TreeNode();
            List<TreeNode> ListeInclus = new List<TreeNode>();

            //Inclusion des noeuds correspondant aux éléments utilisés par les liens
            foreach(Lien l in Liste)
            {
                TreeNode[] nod = NodG.Nodes.Find(l.element2_id.ToString(),true);

                foreach(TreeNode nod1 in nod)
                {
                    nod1.Tag = "1";
                    nod1.ToolTipText = "1";
                    EtendreInclusion(nod1);
                    ListeInclus.Add(nod1);
                    ListeLien.Add(l);
                }

                if(nod.Length == 0) { Console.Ajouter("[X] Lien non inclus : " + l.element2_id.ToString()); }
            }

            //Recherche des noeuds finaux (noeuds sans enfant)
            List<TreeNode> ListeNoeud = new List<TreeNode>();
            Donner_ListeNoeudFinaux(NodG,ref ListeNoeud);

            //Exclusion des noeuds non identifiés comme inclus
            ExclureNoeud(ref NodG, ListeInclus, ListeNoeud);

            return Nd;
        }

        /// <summary>
        /// Etend la sélectiondu noeud à ses parents successifs
        /// </summary>
        /// <param name="Nod"></param>
        void EtendreInclusion(TreeNode Nod)
        {
            if (Nod == null) { return; }
            if (Nod.Parent == null) { return; }
            if (Nod.Parent.Tag != null)
            {
                if (Nod.Parent.Tag.ToString() == "1") { return; }
            }
            else { Nod.Parent.Tag = "0"; }

            try
            {
                Lien l = (Lien)Nod.Parent.Tag;
                Boolean ok = false;
                foreach (Lien l1 in ListeLien) { if (l == l1) { ok = true; break; } }
                if (!ok) { ListeLien.Add(l); }
            }
            catch { }
            Nod.Parent.Tag = "1";
            Nod.Parent.ToolTipText = "1";
            EtendreInclusion(Nod.Parent);
        }

        /// <summary>
        /// Supprime les noeuds de l'arbre
        /// </summary>
        /// <param name="Nod"></param> Arbre à traiter
        /// <param name="ListeInclus"></param> Liste des noeuds à inclure
        /// <param name="ListeNoeud"></param> Liste globale des noeufs finaux (sans enfant)
        void ExclureNoeud(ref TreeNode Nod, List<TreeNode> ListeInclus, List<TreeNode> ListeNoeud)
        {
            foreach(TreeNode nd1 in ListeNoeud)
            {
                //Recherche si le noeud fait partie des noeuds inclus
                Boolean ok = false;
                foreach(TreeNode nd2 in ListeInclus)
                {
                    if(nd1 == nd2) { ok = true; break; }
                }

                //Le noeud ne fait pas partie des inclus donc on le supprime et on remonte ses parents pour les enlever aussi si Tag=0
                if (!ok)
                {
                    nd1.ToolTipText = "X";
                    if (nd1.Parent != null)
                    {
                        if (nd1.Parent.Tag.ToString() == "0") { EtendreExclusion(ref Nod, nd1.Parent); }
                    }
                    Nod.Nodes.Remove(nd1);
                }
            }

            int n = 0;
            do
            {
                n = 0;
                foreach (TreeNode nd in Nod.Nodes)
                {
                    SupprimeNoeud(ref Nod, nd, ref n);
                }
                Console.Ajouter("[N] " + n);
                //if (n == 0) { break; }
            } while (n > 0);
        }

        void SupprimeNoeud(ref TreeNode NodG, TreeNode Nod, ref int n)
        {
            if(Nod == null) { return; }

            if (Nod.Tag.ToString() != "1")
            {
                n++;
                NodG.Nodes.Remove(Nod);
            }

            foreach (TreeNode nd in Nod.Nodes) { SupprimeNoeud(ref NodG, nd, ref n); }
        }

        /// <summary>
        /// Exclut le noeud et poursuit avec son noeud parent
        /// </summary>
        /// <param name="Nod"></param>
        void EtendreExclusion(ref TreeNode NodG, TreeNode Nod)
        {
            if (Nod != null)
            {
                if (Nod.Tag.ToString() == "0")
                {
                    Nod.ToolTipText = "X";
                    if (Nod.Parent != null)
                    {
                        if (Nod.Parent.Tag.ToString() == "0") { EtendreExclusion(ref NodG, Nod.Parent); }
                    }
                    NodG.Nodes.Remove(Nod);
                }
            }
        }
    }
}
