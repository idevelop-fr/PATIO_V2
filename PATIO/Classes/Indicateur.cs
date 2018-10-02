using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;
using PATIO.Classes;

namespace PATIO.Classes
{
    public class Indicateur : IComparable<Indicateur>
    {
        public AccesNet Acces;

        public int ID { get; set; }
        public String Code { get; set; }

        public String Libelle { get; set; }
        public bool Actif { get; set; } = true;

        public TypeIndicateur TypeIndicateur { get; set; }

        public Indicateur()
        {
        }

        //Construction de l'indicateur à partir des informations de l'élément
        public void Construire(Element e)
        {
            ID = e.ID;
            Code = e.Code;
            Libelle = e.Libelle.Replace("'''", "'");
            TypeIndicateur = (TypeIndicateur)e.Type_Element;
            Actif = e.Actif;

            /*
            foreach (dElement d in e.Liste)
            {
                if (d.Element_ID == ID)
                {
                    if (d.Attribut_Code == "TYPE") { TypeIndicateur = (TypeIndicateur)(int.Parse(d.Valeur)); }
                }
            }
            */
        }

        //Transforme un indicateur sous la forme Element, dElement
        public Element Déconstruire()
        {
            Element e = new Element();
            //dElement d;

            e.ID = ID;
            e.Element_Type =Acces.type_INDICATEUR.id;
            e.Code = Code;
            e.Libelle = Libelle;
            e.Type_Element=(int) TypeIndicateur;
            e.Actif = Actif;

            //string CodeAttribut = "";
            {
                /*CodeAttribut = "TYPE";
                d = new dElement(ID, Acces.Trouver_Attribut_ID(Acces.type_INDICATEUR.id, CodeAttribut), CodeAttribut, ((int)TypeIndicateur).ToString());
                e.Liste.Add(d);*/
            }

            return e;
        }

        //Comparateur par défaut
        public int CompareTo(Indicateur p)
        {
            if (p is null) { return 1; }
            else { return (this.Libelle.CompareTo(p.Libelle)); }
        }
    }
}
