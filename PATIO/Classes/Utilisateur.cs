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
    public class Utilisateur : IComparable<Utilisateur>
    {
        public AccesNet Acces;

        public int ID { get; set; }
        public String Code { get; set; }

        public String Nom { get; set; }
        public String Prenom { get; set; }
        public String Mail { get; set; }
        public TypeUtilisateur TypeUtilisateur { get; set; } = TypeUtilisateur.UTILISATEUR;
        public TypeLicence TypeLicence { get; set; } = TypeLicence.PILOTE;
        public bool Actif { get; set; } = true;
        public int Direction { get; set; }

        public Utilisateur()
        {
        }

        //Construit l'utilisateur à partir des informations de l'élément
        public void Construire(Element e)
        {
            ID = e.ID;
            Code = e.Code;
            Nom = e.Libelle.Replace("'''", "'");
            TypeUtilisateur = (TypeUtilisateur)e.Type_Element;
            Actif = e.Actif;

            foreach (dElement d in e.Liste)
            {
                d.Valeur = d.Valeur.Replace("'''", "'");
                if (d.Attribut_Code == "PRENOM") { Prenom = d.Valeur; }
                if (d.Attribut_Code == "MAIL") { Mail = d.Valeur; }
                if (d.Attribut_Code == "TYPE_LICENCE") { TypeLicence = (TypeLicence)(int.Parse(d.Valeur)); }
                if (d.Attribut_Code == "DIRECTION") { Direction = int.Parse( d.Valeur); }
            }
        }

        //Transforme un utilisateur sous la forme Element, dElement
        public Element Déconstruire()
        {
            Element e = new Element();
            dElement d;

            e.ID = ID;
            e.Element_Type =Acces.type_UTILISATEUR.id;
            e.Code = Code;
            e.Libelle = Nom;
            e.Type_Element=(int) TypeUtilisateur;
            e.Actif = Actif;

            string CodeAttribut = "";
            if (Prenom.Length > 0)
            {
                CodeAttribut = "PRENOM";
                d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_UTILISATEUR.id, CodeAttribut), CodeAttribut, Prenom);
                e.Liste.Add(d);
            }

            if (Mail.Length > 0)
            {
                CodeAttribut = "MAIL";
                d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_UTILISATEUR.id, CodeAttribut), CodeAttribut, Mail);
                e.Liste.Add(d);
            }

            {
                CodeAttribut = "TYPE_LICENCE";
                d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_UTILISATEUR.id, CodeAttribut), CodeAttribut, ((int)TypeLicence).ToString());
                e.Liste.Add(d);
            }

            if (Direction > 0)
            {
                CodeAttribut = "DIRECTION";
                d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_UTILISATEUR.id, CodeAttribut), CodeAttribut, Direction.ToString());
                e.Liste.Add(d);
            }

            return e;
        }

        //Comparateur par défaut
        public int CompareTo(Utilisateur p)
        {
            if (p is null) { return 1; }
            else { return (this.Nom.CompareTo(p.Nom)); }
        }
    }
}
