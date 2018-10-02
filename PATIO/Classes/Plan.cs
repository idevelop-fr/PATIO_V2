using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;
using PATIO.Classes;

namespace PATIO.Classes
{
    public class Plan : IComparable<Plan>
    {
        public AccesNet Acces;

        public int ID { get; set; }
        public String Code { get; set; } = "";
        public String Libelle { get; set; } = "";
        public bool Actif { get; set; } = true;

        public Utilisateur Pilote { get; set; }
        public TypePlan TypePlan { get; set; } = TypePlan.REGIONAL;
        public string Abrege { get; set; }

        public NiveauPlan NiveauPlan { get; set; } = NiveauPlan.Niveau_2;
        public DateTime DateDebut { get; set; } = DateTime.Now;
        public DateTime DateFin { get; set; } = DateTime.Now;

        public List<int> Equipe { get; set; }
        public String GroupeExterne { get; set; } = "";

        public bool OptAnalyseGlobale { get; set; } = false;
        public bool OptCommentaires { get; set; } = false;
        public bool OptGouvernance { get; set; } = false;
        public bool OptPrioriteRegionale { get; set; } = false;

        public String _type { get; set; } = "";
        public String _ref1 { get; set; } = "";
        public String _ref2 { get; set; } = "";
        public String _os { get; set; } = "";
        public String _og { get; set; } = "";


        public Plan()
        {
            Equipe = new List<int>();
        }

        //Construit un plan à partir des informations de l'élément
        public void Construire(Element e)
        {
            Plan p = new Plan();

            ID = e.ID;
            Code = e.Code;
            Libelle = e.Libelle.Replace("'''", "'");
            TypePlan = (TypePlan)e.Type_Element;
            Actif = e.Actif;
            Abrege = "";
            foreach (dElement d in e.Liste)
            {
                if (d.Element_ID == ID)
                {
                    d.Valeur = d.Valeur.Replace("'''", "'");
                    if (d.Attribut_Code == "PILOTE") { Pilote = Acces.Trouver_Utilisateur(int.Parse(d.Valeur.ToString())); }
                    if (d.Attribut_Code == "ABREGE") { Abrege = d.Valeur.ToString(); }
                    if (d.Attribut_Code == "NIVEAU_6PO") { NiveauPlan = (NiveauPlan)(int.Parse(d.Valeur.ToString())); }
                    if (d.Attribut_Code == "DATE_DEBUT") { DateDebut = DateTime.Parse(d.Valeur.ToString()); }
                    if (d.Attribut_Code == "DATE_FIN") { DateFin = DateTime.Parse(d.Valeur.ToString()); }
                    if (d.Attribut_Code == "ANALYSE_GLOBALE") { OptAnalyseGlobale = (d.Valeur.ToString() == "1"); }
                    if (d.Attribut_Code == "COMMENTAIRES") { OptCommentaires = (d.Valeur.ToString() == "1"); }
                    if (d.Attribut_Code == "GOUVERNANCE") { OptGouvernance = (d.Valeur.ToString() == "1"); }
                    if (d.Attribut_Code == "PRIORITE_REGIONALE") { OptPrioriteRegionale = (d.Valeur.ToString() == "1"); }
                    if (d.Attribut_Code == "EQUIPE") { Equipe.Add(int.Parse(d.Valeur)); }
                    if (d.Attribut_Code == "GROUPE_EXTERNE") { GroupeExterne = d.Valeur.ToString(); }

                    if (d.Attribut_Code == "_TYPE") { _type = d.Valeur.ToString(); }
                    if (d.Attribut_Code == "_REF1") { _ref1 = d.Valeur.ToString(); }
                    if (d.Attribut_Code == "_REF2") { _ref2 = d.Valeur.ToString(); }
                    if (d.Attribut_Code == "_OS") { _os = d.Valeur.ToString(); }
                    if (d.Attribut_Code == "_OG") { _og = d.Valeur.ToString(); }
                }
            }
        }

        //Transforme un plan sous la forme Element, dElement
        public Element Déconstruire()
        {
            Element e = new Element();
            dElement d;

            e.ID = ID;
            e.Element_Type = Acces.type_PLAN.id;
            e.Code = Code;
            e.Libelle = Libelle;
            e.Type_Element = (int)TypePlan;
            e.Actif = Actif;

            string CodeAttribut = "";

            if (!(Pilote is null))
            {
                CodeAttribut = "PILOTE";
                d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_PLAN.id, CodeAttribut), CodeAttribut, Pilote.ID.ToString());
                e.Liste.Add(d);
            }

            if (Abrege.Length > 0)
            {
                CodeAttribut = "ABREGE";
                d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_PLAN.id, CodeAttribut), CodeAttribut, Abrege);
                e.Liste.Add(d);
            }

            CodeAttribut = "NIVEAU_6PO";
            d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_PLAN.id, CodeAttribut), CodeAttribut, ((int)NiveauPlan).ToString());
            e.Liste.Add(d);

            CodeAttribut = "DATE_DEBUT";
            d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_PLAN.id, CodeAttribut), CodeAttribut, DateDebut.ToString());
            e.Liste.Add(d);

            CodeAttribut = "DATE_FIN";
            d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_PLAN.id, CodeAttribut), CodeAttribut, DateFin.ToString());
            e.Liste.Add(d);

            if (OptAnalyseGlobale == true)
            {
                CodeAttribut = "ANALYSE_GLOBALE";
                d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_PLAN.id, CodeAttribut), CodeAttribut, "1");
                e.Liste.Add(d);
            }

            if (OptCommentaires == true)
            {
                CodeAttribut = "COMMENTAIRES";
                d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_PLAN.id, CodeAttribut), CodeAttribut, "1");
                e.Liste.Add(d);
            }

            if (OptGouvernance == true)
            {
                CodeAttribut = "GOUVERNANCE";
                d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_PLAN.id, CodeAttribut), CodeAttribut, "1");
                e.Liste.Add(d);
            }

            if (OptPrioriteRegionale == true)
            {
                CodeAttribut = "PRIORITE_REGIONALE";
                d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_PLAN.id, CodeAttribut), CodeAttribut, "1");
                e.Liste.Add(d);
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

            if (GroupeExterne.Length > 0)
            {
                CodeAttribut = "GROUPE_EXTERNE";
                d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_PLAN.id, CodeAttribut), CodeAttribut, GroupeExterne);
                e.Liste.Add(d);
            }
            CodeAttribut = "_TYPE";
            d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_PLAN.id, CodeAttribut), CodeAttribut, _type);
            e.Liste.Add(d);

            CodeAttribut = "_REF1";
            d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_PLAN.id, CodeAttribut), CodeAttribut, _ref1);
            e.Liste.Add(d);

            CodeAttribut = "_REF2";
            d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_PLAN.id, CodeAttribut), CodeAttribut, _ref2);
            e.Liste.Add(d);

            CodeAttribut = "_OS";
            d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_PLAN.id, CodeAttribut), CodeAttribut, _os);
            e.Liste.Add(d);

            CodeAttribut = "_OG";
            d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_PLAN.id, CodeAttribut), CodeAttribut, _og);
            e.Liste.Add(d);

            return e;
        }

        //Comparateur par défaut
        public int CompareTo(Plan p)
        {
            if (p is null) { return 1; }
            else { return (this.Libelle.CompareTo(p.Libelle)); }
        }

    }

}
