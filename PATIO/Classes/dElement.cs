using System;
using System.Collections.Generic;

namespace PATIO.Classes
{
    public class dElement : IComparable<dElement>
    {
        public AccesNet Acces;

        public int ID { get; set; }
        public int Element_ID { get; set; }
        public int Attribut_ID { get; set; }
        public string Attribut_Code { get; set; }
        public String Valeur { get; set; }

        public int typeelement;

        public List<PATIO.Classes.Attribut> ListeAttribut;

        //Constructeur sans paramètre
        public dElement() { }

        //Constructeur avec l'ensemble des paramètres
        public dElement (int elementid, int attributid, string attributcode, string valeur)
        {
            Element_ID = elementid;
            Attribut_ID = attributid;
            Attribut_Code = attributcode;
            Valeur = valeur;
        }

        public Boolean Ajouter()
        {
            string sql;

            sql = "INSERT INTO delement(element_id, attribut_id, attribut_code, valeur) VALUES (";
            sql += "'" + Element_ID + "',";
            sql += "'" + Attribut_ID + "',";
            sql += "'" + Attribut_Code + "',";
            sql += "'" + Valeur.Replace("'","\'") + "')";

            Acces.cls.Execute(sql);
            if (Acces.cls.erreur.Length > 0) { return false; }

            return true;
        }

        public Boolean Supprimer()
        {
            string sql;

            sql = "DELETE FROM delement WHERE id='" + ID + "'";

            Acces.cls.Execute(sql);
            if (Acces.cls.erreur.Length > 0) { return false; }

            return true;
        }

        public Boolean MettreAJour()
        {
            string sql;

            sql = "UPDATE delement SET ";
            sql += " element_id='" + Element_ID + "',";
            sql += " element_id='" + Attribut_ID + "',";
            sql += " element_code='" + Attribut_Code + "',";
            sql += " valeur='" + Valeur.Replace("'", "\'") + "',";
            sql += " WHERE id='" + ID + "'";

            Acces.cls.Execute(sql);
            if (Acces.cls.erreur.Length > 0) { return false; }

            return true;
        }

        //Comparateur par défaut
        public int CompareTo(dElement p)
        {
            try
            {
                if (p is null) { return 1; }
                else { return (this.Valeur.CompareTo(p.Valeur)); }
            }
            catch { return 1; }
        }
    }
}
