using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;
using PATIO.Classes;
using PATIO.Modules;

namespace PATIO.Classes
{
    public class Action : IComparable<Action>
    {
        public AccesNet Acces;

        public int ID { get; set; }

        //Informations principales
        public String Code { get; set; }
        public String Libelle { get; set; }
        public bool Actif { get; set; } = true;

        public TypeAction TypeAction { get; set; } = TypeAction.ACTION;

        public Utilisateur Pilote { get; set; }
        public int Statut { get; set; }
        public bool ActionPhare { get; set; } = false;
        public int OrdreActionPhare { get; set; }

        public List<int> DirectionPilote { get; set; }

        public int Validation { get; set; }

        public String Description { get; set; }

        public String _type { get; set; } = "";
        public String _codeplan { get; set; } = "";
        public String _axe { get; set; } = "";
        public String _os { get; set; } = "";
        public String _og { get; set; } = "";
        public String _op { get; set; } = "";
        public String _cpl { get; set; } = "";
        public String _ordreact { get; set; } = "";
        public String _annee { get; set; } = "";
        public String _direction { get; set; } = "";
        public String _reference { get; set; } = "";
        public String _ordreope { get; set; } = "";


        //Onglet Public, partenaires
        public List<int> PublicCible { get; set; }
        public String Territoire { get; set; }
        public List<int> Partenaire { get; set; }
        public List<int> Usager { get; set; }

        //Onglet Moyens
        public List<int> StructurePorteuse { get; set; }
        public List<int> Acteur { get; set; }
        public List<int> Levier { get; set; }
        public String CoutFinancier { get; set; }
        public Boolean FinancementFIR { get; set; } = false;
        public String Mt_2018 { get; set; }
        public String Mt_2019 { get; set; }
        public String Mt_2020 { get; set; }
        public String Mt_2021 { get; set; }
        public String Mt_2022 { get; set; }
        public String Mt_2023 { get; set; }
        public String Mt_Total { get; set; }

        //Onglet Suivi et évaluation
        public String ResultatLivrable { get; set; }
        public String NbPersImpact { get; set; }
        public String NbActeurMobilise { get; set; }
        public String IndicResultat { get; set; }
        public String IndicMoyen { get; set; }

        //Onglet Calendrier, responsabilités
        public List<int> AnneeMiseOeuvre { get; set; }
        public List<int> DirectionAssocie { get; set; }
        public List<int> Equipe { get; set; }

        //Onglet Liens
        public List<int> LienPlan { get; set; }
        public List<int> LienParcours { get; set; }
        public List<int> LienSecteur { get; set; }

        //Onglet Priorités CTS
        public List<int> TSante { get; set; }
        public List<int> Priorite_CTS { get; set; }

        //Onglet Informations en lien avec 6PO
        public DateTime DateDebut { get; set; } = DateTime.Now;
        public DateTime DateFin { get; set; } = DateTime.Now;
        public Meteo Meteo { get; set; }
        public TxAvancement TxAvancement { get; set; }
        public bool ActionInnovante { get; set; }
        public string AnalyseQualitative { get; set; }
        public string ReductionInegalite { get; set; }

        //Onglet Rôles 6PO
        public List<int> Role_6PO_CoPilote;
        public List<int> Role_6PO_Manager;
        public List<int> Role_6PO_Consultation;

        public Action()
        {
            PublicCible = new List<int>();
            Partenaire = new List<int>();
            Usager = new List<int>();
            StructurePorteuse = new List<int>();
            Acteur = new List<int>();
            Levier = new List<int>();
            AnneeMiseOeuvre = new List<int>();
            DirectionPilote = new List<int>();
            DirectionAssocie = new List<int>();
            Equipe = new List<int>();
            LienPlan = new List<int>();
            LienParcours = new List<int>();
            LienSecteur = new List<int>();
            TSante = new List<int>();
            Priorite_CTS = new List<int>();
            Role_6PO_CoPilote = new List<int>();
            Role_6PO_Manager = new List<int>();
            Role_6PO_Consultation = new List<int>();
        }

        //Construit l'action à partir des informations de l'élément
        public void Construire(Element e)
        {
            ID = e.ID;
            Code = e.Code;
            Libelle = e.Libelle.Replace("'''", "'");
            TypeAction = (TypeAction)e.Type_Element;
            Actif = e.Actif;

            foreach (dElement d in e.Liste)
            {
                if (d.Element_ID == ID)
                {
                    d.Valeur = d.Valeur.Replace("'''", "'");
                    //Onglet Informations géérales
                    if (d.Attribut_Code == "PILOTE") { Pilote = Acces.Trouver_Utilisateur(int.Parse(d.Valeur)); }
                    if (d.Attribut_Code == "STATUT") { Statut = int.Parse(d.Valeur); }

                    if (d.Attribut_Code == "ACTION_PHARE") { ActionPhare = (d.Valeur == "1"); }
                    if (d.Attribut_Code == "ORDRE_ACTION_PHARE") { OrdreActionPhare = int.Parse(d.Valeur); }
                    if (d.Attribut_Code == "VALIDATION_INTERNE") { Validation = int.Parse(d.Valeur); }

                    if (d.Attribut_Code == "DESCRIPTION") { Description = d.Valeur; }

                    if (d.Attribut_Code == "_TYPE") { _type = d.Valeur; }
                    if (d.Attribut_Code == "_CODEPLAN") { _codeplan = d.Valeur; }
                    if (d.Attribut_Code == "_AXE") { _axe = d.Valeur; }
                    if (d.Attribut_Code == "_OS") { _os = d.Valeur; }
                    if (d.Attribut_Code == "_OG") { _og = d.Valeur; }
                    if (d.Attribut_Code == "_OP") { _op = d.Valeur; }
                    if (d.Attribut_Code == "_CPL") { _cpl = d.Valeur; }
                    if (d.Attribut_Code == "_ORDREACT") { _ordreact = d.Valeur; }
                    if (d.Attribut_Code == "_ANNEE") { _annee = d.Valeur; }
                    if (d.Attribut_Code == "_DIRECTION") { _direction = d.Valeur; }
                    if (d.Attribut_Code == "_REFERENCE") { _reference = d.Valeur; }
                    if (d.Attribut_Code == "_ORDREOPE") { _ordreope = d.Valeur; }

                    //Onglet Public, partenaires
                    if (d.Attribut_Code == "PUBLIC_CIBLE") { PublicCible.Add(int.Parse(d.Valeur)); }
                    if (d.Attribut_Code == "TERRITOIRE") { Territoire = d.Valeur; }
                    if (d.Attribut_Code == "PARTENAIRE_INSTITU") { Partenaire.Add(int.Parse(d.Valeur)); }
                    if (d.Attribut_Code == "PARTENAIRE_USAGER") { Usager.Add(int.Parse(d.Valeur)); }

                    //Onglet Moyens
                    if (d.Attribut_Code == "STRUCTURE_PORTEUSE") { try { StructurePorteuse.Add(int.Parse(d.Valeur)); } catch { } }
                    if (d.Attribut_Code == "ACTEUR_SANTE") { Acteur.Add(int.Parse(d.Valeur)); }
                    if (d.Attribut_Code == "LEVIER") { Levier.Add(int.Parse(d.Valeur)); }
                    if (d.Attribut_Code == "COUT_FINANCIER") { CoutFinancier = d.Valeur; }
                    if (d.Attribut_Code == "FINANCEMENT_FIR") { FinancementFIR = (d.Valeur == "1"); }
                    if (d.Attribut_Code == "MT_2018") { Mt_2018 = d.Valeur; }
                    if (d.Attribut_Code == "MT_2019") { Mt_2019 = d.Valeur; }
                    if (d.Attribut_Code == "MT_2020") { Mt_2020 = d.Valeur; }
                    if (d.Attribut_Code == "MT_2021") { Mt_2021 = d.Valeur; }
                    if (d.Attribut_Code == "MT_2022") { Mt_2022 = d.Valeur; }
                    if (d.Attribut_Code == "MT_2023") { Mt_2023 = d.Valeur; }
                    if (d.Attribut_Code == "MT_TOTAL") { Mt_Total = d.Valeur; }

                    //Onglet 5 : Suivi et évaluation
                    if (d.Attribut_Code == "RESULTAT_LIVRABLE") { ResultatLivrable = d.Valeur; }
                    if (d.Attribut_Code == "NB_PERS_IMPACT") { NbPersImpact = d.Valeur; }
                    if (d.Attribut_Code == "NB_ACTEUR_MOBILISE") { NbActeurMobilise = d.Valeur; }
                    if (d.Attribut_Code == "INDIC_RESULTAT") { IndicResultat = d.Valeur; }
                    if (d.Attribut_Code == "INDIC_MOYEN") { IndicMoyen = d.Valeur; }

                    //Onglet 6 : Calendrier, responsabilités
                    if (d.Attribut_Code == "ANNEE_MO") { AnneeMiseOeuvre.Add(int.Parse(d.Valeur)); }
                    if (d.Attribut_Code == "DIRECTION_PILOTE") { DirectionPilote.Add(int.Parse(d.Valeur)); }
                    if (d.Attribut_Code == "DIRECTION_ASSOCIE") { DirectionAssocie.Add(int.Parse(d.Valeur)); }
                    if (d.Attribut_Code == "EQUIPE") { Equipe.Add(int.Parse(d.Valeur)); }

                    //Onglet 7 : Liens
                    if (d.Attribut_Code == "LIEN_PLAN") { LienPlan.Add(int.Parse(d.Valeur)); }
                    if (d.Attribut_Code == "LIEN_PARCOURS") { LienParcours.Add(int.Parse(d.Valeur)); }
                    if (d.Attribut_Code == "LIEN_SECTEUR") { LienSecteur.Add(int.Parse(d.Valeur)); }

                    //Onglet 8 : Priorité CTS
                    if (d.Attribut_Code == "TSANTE") { TSante.Add(int.Parse(d.Valeur)); }
                    if (d.Attribut_Code == "PRIORITE_CTS") { Priorite_CTS.Add(int.Parse(d.Valeur)); }

                    //Onglet 9
                    if (d.Attribut_Code == "DATE_DEBUT") { try { DateDebut = DateTime.Parse(d.Valeur); } catch { } }
                    if (d.Attribut_Code == "DATE_FIN") { try { DateFin = DateTime.Parse(d.Valeur); } catch { } }
                    if (d.Attribut_Code == "METEO") { Meteo = (Meteo)int.Parse(d.Valeur); }
                    if (d.Attribut_Code == "TX_AVANCEMENT") { TxAvancement = (TxAvancement)int.Parse(d.Valeur); }
                    if (d.Attribut_Code == "ACTION_INNOVANTE") { ActionInnovante = (d.Valeur == "1"); }
                    if (d.Attribut_Code == "ANALYSE_QUALITATIVE") { AnalyseQualitative = d.Valeur; }
                    if (d.Attribut_Code == "REDUCTION_INEGALITE") { ReductionInegalite = d.Valeur; }

                    //Onglet 10 : Rôle 6PO
                    if (d.Attribut_Code == "ROLE_6PO_COPILOTE") { Role_6PO_CoPilote.Add(int.Parse(d.Valeur)); }
                    if (d.Attribut_Code == "ROLE_6PO_MANAGER") { Role_6PO_Manager.Add(int.Parse(d.Valeur)); }
                    if (d.Attribut_Code == "ROLE_6PO_CONSULTATION") { Role_6PO_Consultation.Add(int.Parse(d.Valeur)); }

                }
            }
        }

        //Transforme une action sous la forme Element, dElement
        public Element Déconstruire()
        {
            Element e = new Element();

            e.ID = ID;
            e.Element_Type = Acces.type_ACTION.id;
            e.Code = Code;
            e.Libelle = Libelle;
            e.Type_Element = (int)TypeAction;
            e.Actif = Actif;

            DéconstruireP01(ref e);
            DéconstruireP02(ref e);
            DéconstruireP03(ref e);
            DéconstruireP04(ref e);
            DéconstruireP05(ref e);
            DéconstruireP06(ref e);
            DéconstruireP07(ref e);
            DéconstruireP08(ref e);
            DéconstruireP09(ref e);

            return e;
        }

        void DéconstruireP01(ref Element e)
        {
            dElement d;
            string CodeAttribut = "";

            //PILOTE
            if (!(Pilote is null))
            {
                CodeAttribut = "PILOTE";
                d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_ACTION.id, CodeAttribut), CodeAttribut, Pilote.ID.ToString());
                e.Liste.Add(d);
            }

            //ACTION_PHARE
            if (ActionPhare)
            {
                CodeAttribut = "ACTION_PHARE";
                d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_ACTION.id, CodeAttribut), CodeAttribut, (ActionPhare) ? "1" : "0");
                e.Liste.Add(d);
            }

            //ORDRE_ACTION_PHARE
            if (OrdreActionPhare > 0)
            {
                CodeAttribut = "ORDRE_ACTION_PHARE";
                d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_ACTION.id, CodeAttribut), CodeAttribut, OrdreActionPhare.ToString());
                e.Liste.Add(d);
            }

            //STATUT
            {
                CodeAttribut = "STATUT";
                d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_ACTION.id, CodeAttribut), CodeAttribut, Statut.ToString());
                e.Liste.Add(d);
            }

            //VALIDATION_INTERNE
            if (!(Validation < 0))
            {
                CodeAttribut = "VALIDATION_INTERNE";
                d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_ACTION.id, CodeAttribut), CodeAttribut, Validation.ToString());
                e.Liste.Add(d);
            }

            //DESCRIPTION
            if (!(Description is null))
            {
                CodeAttribut = "DESCRIPTION";
                d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_ACTION.id, CodeAttribut), CodeAttribut, Description);
                e.Liste.Add(d);
            }

            //TYPE
            if (!(_type is null))
            {
                CodeAttribut = "_TYPE";
                d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_ACTION.id, CodeAttribut), CodeAttribut, _type);
                e.Liste.Add(d);
            }

            //CODEPLAN
            if (!(_codeplan is null))
            {
                CodeAttribut = "_CODEPLAN";
                d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_ACTION.id, CodeAttribut), CodeAttribut, _codeplan);
                e.Liste.Add(d);
            }

            if (!(_axe is null))
            {
                CodeAttribut = "_AXE";
                d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_ACTION.id, CodeAttribut), CodeAttribut, _axe);
                e.Liste.Add(d);
            }

            if (!(_os is null))
            {
                CodeAttribut = "_OS";
                d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_ACTION.id, CodeAttribut), CodeAttribut, _os);
                e.Liste.Add(d);
            }

            if (!(_og is null))
            {
                CodeAttribut = "_OG";
                d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_ACTION.id, CodeAttribut), CodeAttribut, _og);
                e.Liste.Add(d);
            }

            if (!(_op is null))
            {
                CodeAttribut = "_OP";
                d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_ACTION.id, CodeAttribut), CodeAttribut, _op);
                e.Liste.Add(d);
            }

            if (!(_cpl is null))
            {
                CodeAttribut = "_CPL";
                d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_ACTION.id, CodeAttribut), CodeAttribut, _cpl);
                e.Liste.Add(d);
            }

            if (!(_ordreact is null))
            {
                CodeAttribut = "_ORDREACT";
                d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_ACTION.id, CodeAttribut), CodeAttribut, _ordreact);
                e.Liste.Add(d);
            }

            if (!(_annee is null))
            {
                CodeAttribut = "_ANNEE";
                d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_ACTION.id, CodeAttribut), CodeAttribut, _annee);
                e.Liste.Add(d);
            }

            if (!(_direction is null))
            {
                CodeAttribut = "_DIRECTION";
                d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_ACTION.id, CodeAttribut), CodeAttribut, _direction);
                e.Liste.Add(d);
            }

            if (!(_reference is null))
            {
                CodeAttribut = "_REFERENCE";
                d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_ACTION.id, CodeAttribut), CodeAttribut, _reference);
                e.Liste.Add(d);
            }

            if (!(_ordreope is null))
            {
                CodeAttribut = "_ORDREOPE";
                d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_ACTION.id, CodeAttribut), CodeAttribut, _ordreope);
                e.Liste.Add(d);
            }
        }

        void DéconstruireP02(ref Element e)
        {
            dElement d;
            string CodeAttribut = "";

            //PUBLIC_CIBLE
            if (!(PublicCible is null))
            {
                CodeAttribut = "PUBLIC_CIBLE";
                foreach (int k in PublicCible)
                {
                    d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_ACTION.id, CodeAttribut), CodeAttribut, k.ToString());
                    e.Liste.Add(d);
                }
            }

            //TERRITOIRE
            if (!(Territoire is null))
            {
                CodeAttribut = "TERRITOIRE";
                d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_ACTION.id, CodeAttribut), CodeAttribut, Territoire);
                e.Liste.Add(d);
            }

            // PARTENAIRE_INSTITU
            if (!(Partenaire is null))
            {
                CodeAttribut = "PARTENAIRE_INSTITU";
                foreach (int k in Partenaire)
                {
                    d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_ACTION.id, CodeAttribut), CodeAttribut, k.ToString());
                    e.Liste.Add(d);
                }
            }

            // PARTENAIRE_USAGER
            if (!(Usager is null))
            {
                CodeAttribut = "PARTENAIRE_USAGER";
                foreach (int k in Usager)
                {
                    d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_ACTION.id, CodeAttribut), CodeAttribut, k.ToString());
                    e.Liste.Add(d);
                }
            }
        }

        void DéconstruireP03(ref Element e)
        {
            dElement d;
            string CodeAttribut = "";

            //STRUCTURE PORTEUSE
            if (!(StructurePorteuse is null))
            {
                CodeAttribut = "STRUCTURE_PORTEUSE";
                foreach (int k in StructurePorteuse)
                {
                    d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_ACTION.id, CodeAttribut), CodeAttribut, k.ToString());
                    e.Liste.Add(d);
                }
            }

            //ACTEUR_SANTE
            if (!(Acteur is null))
            {
                CodeAttribut = "ACTEUR_SANTE";
                foreach (int k in Acteur)
                {
                    d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_ACTION.id, CodeAttribut), CodeAttribut, k.ToString());
                    e.Liste.Add(d);
                }
            }

            // LEVIER
            if (!(Levier is null))
            {
                CodeAttribut = "LEVIER";
                foreach (int k in Levier)
                {
                    d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_ACTION.id, CodeAttribut), CodeAttribut, k.ToString());
                    e.Liste.Add(d);
                }
            }

            //COUT_FINANCIER
            if (!(CoutFinancier is null))
            {
                CodeAttribut = "COUT_FINANCIER";
                d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_ACTION.id, CodeAttribut), CodeAttribut, CoutFinancier);
                e.Liste.Add(d);
            }

            //FINANCEMENT FIR
            if (FinancementFIR)
            {
                CodeAttribut = "FINANCEMENT_FIR";
                d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_ACTION.id, CodeAttribut), CodeAttribut, "1");
                e.Liste.Add(d);
            }

            //MT 2018
            if (!(Mt_2018 is null))
            {
                CodeAttribut = "MT_2018";
                d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_ACTION.id, CodeAttribut), CodeAttribut, Mt_2018);
                e.Liste.Add(d);
            }

            //MT 2019
            if (!(Mt_2019 is null))
            {
                CodeAttribut = "MT_2019";
                d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_ACTION.id, CodeAttribut), CodeAttribut, Mt_2019);
                e.Liste.Add(d);
            }

            //MT 2020
            if (!(Mt_2020 is null))
            {
                CodeAttribut = "MT_2020";
                d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_ACTION.id, CodeAttribut), CodeAttribut, Mt_2020);
                e.Liste.Add(d);
            }

            //MT 2021
            if (!(Mt_2021 is null))
            {
                CodeAttribut = "MT_2021";
                d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_ACTION.id, CodeAttribut), CodeAttribut, Mt_2021);
                e.Liste.Add(d);
            }

            //MT 2022
            if (!(Mt_2022 is null))
            {
                CodeAttribut = "MT_2022";
                d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_ACTION.id, CodeAttribut), CodeAttribut, Mt_2022);
                e.Liste.Add(d);
            }

            //MT 2023
            if (!(Mt_2023 is null))
            {
                CodeAttribut = "MT_2023";
                d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_ACTION.id, CodeAttribut), CodeAttribut, Mt_2023);
                e.Liste.Add(d);
            }

            //MT TOTAL
            if (!(Mt_Total is null))
            {
                CodeAttribut = "MT_TOTAL";
                d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_ACTION.id, CodeAttribut), CodeAttribut, Mt_Total);
                e.Liste.Add(d);
            }
        }

        void DéconstruireP04(ref Element e)
        {
            dElement d;
            string CodeAttribut = "";

            //RESULTAT_LIVRABLE
            if (!(ResultatLivrable is null))
            {
                CodeAttribut = "RESULTAT_LIVRABLE";
                d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_ACTION.id, CodeAttribut), CodeAttribut, ResultatLivrable);
                e.Liste.Add(d);
            }

            //NB_PERS_IMPACT
            if (!!(NbPersImpact is null))
            {
                CodeAttribut = "NB_PERS_IMPACT";
                d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_ACTION.id, CodeAttribut), CodeAttribut, NbPersImpact);
                e.Liste.Add(d);
            }

            //NB_ACTEUR_MOBILISE
            if (!(NbActeurMobilise is null))
            {
                CodeAttribut = "NB_ACTEUR_MOBILISE";
                d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_ACTION.id, CodeAttribut), CodeAttribut, NbActeurMobilise);
                e.Liste.Add(d);
            }

            //INDIC_RESULTAT
            if (!(IndicResultat is null))
            {
                CodeAttribut = "INDIC_RESULTAT";
                d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_ACTION.id, CodeAttribut), CodeAttribut, IndicResultat);
                e.Liste.Add(d);
            }

            //INDIC_MOYEN
            if (!(IndicMoyen is null))
            {
                CodeAttribut = "INDIC_MOYEN";
                d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_ACTION.id, CodeAttribut), CodeAttribut, IndicMoyen);
                e.Liste.Add(d);
            }
        }

        void DéconstruireP05(ref Element e)
        {
            dElement d;
            string CodeAttribut = "";

            //ANNEE_MO
            if (!(AnneeMiseOeuvre is null))
            {
                CodeAttribut = "ANNEE_MO";
                foreach (int k in AnneeMiseOeuvre)
                {
                    d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_ACTION.id, CodeAttribut), CodeAttribut, k.ToString());
                    e.Liste.Add(d);
                }
            }

            //DIRECTION_PILOTE
            if (!(DirectionPilote is null))
            {
                CodeAttribut = "DIRECTION_PILOTE";
                foreach (int k in DirectionPilote)
                {
                    d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_ACTION.id, CodeAttribut), CodeAttribut, k.ToString());
                    e.Liste.Add(d);
                }
            }

            // DIRECTION_ASSOCIE
            if (!(DirectionAssocie is null))
            {
                CodeAttribut = "DIRECTION_ASSOCIE";
                foreach (int k in DirectionAssocie)
                {
                    d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_ACTION.id, CodeAttribut), CodeAttribut, k.ToString());
                    e.Liste.Add(d);
                }
            }

            // EQUIPE
            if (!(Equipe is null))
            {
                CodeAttribut = "EQUIPE";
                foreach (int k in Equipe)
                {
                    d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_ACTION.id, CodeAttribut), CodeAttribut, k.ToString());
                    e.Liste.Add(d);
                }
            }
        }

        void DéconstruireP06(ref Element e)
        {
            dElement d;
            string CodeAttribut = "";

            //LIEN_PLAN
            if (!(LienPlan is null))
            {
                CodeAttribut = "LIEN_PLAN";
                foreach (int k in LienPlan)
                {
                    d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_ACTION.id, CodeAttribut), CodeAttribut, k.ToString());
                    e.Liste.Add(d);
                }
            }

            // LIEN_PARCOURS
            if (!(LienParcours is null))
            {
                CodeAttribut = "LIEN_PARCOURS";
                foreach (int k in LienParcours)
                {
                    d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_ACTION.id, CodeAttribut), CodeAttribut, k.ToString());
                    e.Liste.Add(d);
                }
            }

            // LIEN_SECTEUR
            if (!(LienSecteur is null))
            {
                CodeAttribut = "LIEN_SECTEUR";
                foreach (int k in LienSecteur)
                {
                    d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_ACTION.id, CodeAttribut), CodeAttribut, k.ToString());
                    e.Liste.Add(d);
                }
            }

        }

        void DéconstruireP07(ref Element e)
        {
            dElement d;
            string CodeAttribut = "";

            CodeAttribut = "TSANTE";
            foreach (int k in TSante)
            {
                d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_ACTION.id, CodeAttribut), CodeAttribut, k.ToString());
                e.Liste.Add(d);
            }

            CodeAttribut = "PRIORITE_CTS";
            foreach (int k in Priorite_CTS)
            {
                d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_ACTION.id, CodeAttribut), CodeAttribut, k.ToString());
                e.Liste.Add(d);
            }
        }

        void DéconstruireP08(ref Element e)
        {
            dElement d;
            string CodeAttribut = "";

            {
                CodeAttribut = "DATE_DEBUT";
                d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_ACTION.id, CodeAttribut), CodeAttribut, string.Format("{0:dd/MM/yyyy}", DateDebut));
                e.Liste.Add(d);
            }

            {
                CodeAttribut = "DATE_FIN";
                d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_ACTION.id, CodeAttribut), CodeAttribut, string.Format("{0:dd/MM/yyyy}", DateFin));
                e.Liste.Add(d);
            }

            {
                CodeAttribut = "METEO";
                d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_ACTION.id, CodeAttribut), CodeAttribut, ((int)Meteo).ToString());
                e.Liste.Add(d);
            }

            {
                CodeAttribut = "TX_AVANCEMENT";
                d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_ACTION.id, CodeAttribut), CodeAttribut, ((int)TxAvancement).ToString());
                e.Liste.Add(d);
            }

            if (ActionInnovante)
            {
                CodeAttribut = "ACTION_INNOVANTE";
                d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_ACTION.id, CodeAttribut), CodeAttribut, "1");
                e.Liste.Add(d);
            }

            if (!(AnalyseQualitative is null))
            {
                CodeAttribut = "ANALYSE_QUALITATIVE";
                d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_ACTION.id, CodeAttribut), CodeAttribut, AnalyseQualitative);
                e.Liste.Add(d);
            }

            if (!(ReductionInegalite is null))
            {
                CodeAttribut = "REDUCTION_INEGALITE";
                d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_ACTION.id, CodeAttribut), CodeAttribut, ReductionInegalite);
                e.Liste.Add(d);
            }
        }

        void DéconstruireP09(ref Element e)
        {
            dElement d;
            string CodeAttribut = "";

            CodeAttribut = "ROLE_6PO_COPILOTE";
            foreach (int k in Role_6PO_CoPilote )
            {
                d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_ACTION.id, CodeAttribut), CodeAttribut, k.ToString());
                e.Liste.Add(d);
            }

            CodeAttribut = "ROLE_6PO_MANAGER";
            foreach (int k in Role_6PO_Manager)
            {
                d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_ACTION.id, CodeAttribut), CodeAttribut, k.ToString());
                e.Liste.Add(d);
            }

            CodeAttribut = "ROLE_6PO_CONSULTATION";
            foreach (int k in Role_6PO_Consultation)
            {
                d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_ACTION.id, CodeAttribut), CodeAttribut, k.ToString());
                e.Liste.Add(d);
            }
        }

        //Comparateur par défaut
        public int CompareTo(Action p)
        {
            if (p is null) { return 1; }
            else { return (this.Libelle.CompareTo(p.Libelle)); }
        }
    }
}
