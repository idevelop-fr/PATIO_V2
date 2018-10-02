using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PATIO.Modules;
using PATIO.Classes;
using System.Data;

namespace PATIO.Classes
{
    public class Attribut : IComparable<Attribut>
    {
        public AccesNet Acces;

        public int ID { get; set; }
        public string Code { get; set; }
        public string Libelle { get; set; }
        public int Element_Type { get; set; }
        public string ATT_6PO { get; set; }

        public Attribut() { }

        public Attribut(string code, string libelle, int typeelement, string Att_6po)
        {
            Code = code;
            Libelle = libelle.Replace("'''", "'");
            Element_Type = typeelement;
            ATT_6PO = Att_6po;
        }

        public void Ajouter()
        {
            string sql;

            sql = "INSERT INTO attribut (code, libelle, element_type, att_6po) VALUES (";
            sql += "'" + Code + "',";
            sql += "'" + Libelle.Replace("'","\'") + "',";
            sql += "'" + Element_Type + "',";
            sql += "'" + ATT_6PO + "')";
            Acces.cls.Execute(sql);

            //Recherche de l'iD attribué
            sql = "SELECT id from attribut";
            sql += " WHERE Code='" + Code + "'";
            sql += " AND element_type='" + Element_Type + "'";
            DataSet Sn = Acces.cls.ContenuRequete(sql);

            if(Acces.cls.NbLignes>0) { ID = int.Parse(Sn.Tables["dataset"].Rows[0][0].ToString()); }
        }

        public void MettreAJour()
        {
            string sql;

            sql = "UPDATE attribut SET";
            sql += " code ='" + Code + "',";
            sql += " libelle ='" + Libelle.Replace("'", "''") + "',";
            sql += " element_type ='" + Element_Type + "',";
            sql += " att_6po ='" + ATT_6PO + "'";
            sql += " WHERE id='" + ID + "'";
            Acces.cls.Execute(sql);
        }

        public void Supprimer()
        {
            string sql;

            sql = "DELETE FROM attribut";
            sql += " WHERE id='" + ID + "'";
            Acces.cls.Execute(sql);

        }

        public void MettreAJour_dElement(string ancien_code)
        {
            string sql;

            sql = "UPDATE delement SET";
            sql += " attribut_code ='" + Code + "',";
            sql += " WHERE element_type='" + Element_Type + "'";
            sql += " AND attribut_code='" + ancien_code + "'";
            Acces.cls.Execute(sql);
        }

        public void MettreAJour_TV(string ancien_code)
        {
            string sql;

            sql = "UPDATE table_valeur SET";
            sql += " nom ='" + Code + "',";
            sql += " WHERE nom ='" + ancien_code + "'";
            Acces.cls.Execute(sql);
        }

        public Boolean Exister(int _Element_type, string _Code)
        {
            string sql;

            sql = "SELECT * FROM attribut";
            sql += " WHERE element_type='" + _Element_type + "'";
            sql += " AND Code='" + _Code + "'";
            DataSet Sn = Acces.cls.ContenuRequete(sql);

            if(Acces.cls.NbLignes == 0) { return false; }
            else
            {
                foreach(DataRow r in Sn.Tables["dataset"].Rows)
                {
                    if(r["id"].ToString() != ID.ToString())
                    {
                        return true;
                    }
                }

                return false;
            }

        }

        //Comparateur par défaut
        public int CompareTo(Attribut p)
        {
            if (p is null) { return 1; }
            else
            {
                string A = Libelle;
                string B = p.Libelle;
                return (A.CompareTo(B));
            }
        }
    }
}
