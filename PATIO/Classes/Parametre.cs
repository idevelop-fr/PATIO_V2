using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace PATIO.Classes
{
    public class Parametre
    {
        public AccesNet Acces;

        public int ID { get; set; }
        public string Code { get; set; }
        public string Valeur { get; set; }

        public Parametre() { }

        public Parametre(int _ID, string _Code, string _Valeur)
        {
            ID = _ID;
            Code = _Code;
            Valeur = _Valeur;
        }

        public void Ajouter()
        {
            string sql;

            sql = "INSERT INTO parametre (code, valeur) VALUES (";
            sql += "'" + Code + "',";
            sql += "'" + Valeur.Replace("'", "\'") + "')";
            Acces.cls.Execute(sql);

            //Recherche de l'iD attribué
            sql = "SELECT id from parametre";
            sql += " WHERE code='" + Code + "'";
            DataSet Sn = Acces.cls.ContenuRequete(sql);

            if (Acces.cls.NbLignes > 0) { ID = int.Parse(Sn.Tables["dataset"].Rows[0][0].ToString()); }
        }

        public void MettreAJour()
        {
            string sql;

            sql = "UPDATE parametre SET";
            sql += " code ='" + Code + "',";
            sql += " valeur ='" + Valeur.Replace("'", "\'") + "'";
            sql += " WHERE id='" + ID + "'";
            Acces.cls.Execute(sql);
        }

        public void Supprimer()
        {
            string sql;

            sql = "DELETE FROM parametre";
            sql += " WHERE id='" + ID + "'";
            Acces.cls.Execute(sql);

        }

        public Boolean Exister(string _Code)
        {
            string sql;

            sql = "SELECT * FROM parametre";
            sql += " WHERE Code='" + _Code + "'";
            DataSet Sn = Acces.cls.ContenuRequete(sql);

            if (Acces.cls.NbLignes == 0) { return false; }
            else
            {
                foreach (DataRow r in Sn.Tables["dataset"].Rows)
                {
                    if (r["id"].ToString() != ID.ToString())
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        //Comparateur par défaut
        public int CompareTo(Parametre p)
        {
            if (p is null) { return 1; }
            else
            {
                string A = Code;
                string B = p.Code;
                return (A.CompareTo(B));
            }
        }
    }
}
