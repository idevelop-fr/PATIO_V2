using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PATIO.Modules;
using System.Data;

namespace PATIO.Classes
{
    public class table_valeur : IComparable<table_valeur>
    {
        public AccesNet Acces;

        public int ID { get; set; }
        public string Nom { get; set; }
        public string Code { get; set; }
        public string Valeur { get; set; }
        public string Valeur6PO { get; set; }

        public void Ajouter()
        {
            string sql;

            sql = "INSERT INTO table_valeur (nom, code, valeur, valeur_6po) VALUES (";
            sql += "'" + Nom.Replace("'","''") + "',";
            sql += "'" + Code + "',";
            sql += "'" + Valeur.Replace("'", "''") + "',";
            sql += "'" + Valeur6PO.Replace("'", "''") + "')";
            Acces.cls.Execute(sql);

            //Recherche de l'iD attribué
            sql = "SELECT id from table_valeur";
            sql += " WHERE nom='" + Nom.Replace("'","''") + "'";
            sql += " AND code='" + Code + "'";
            DataSet Sn = Acces.cls.ContenuRequete(sql);

            if (Acces.cls.NbLignes > 0) { ID = int.Parse(Sn.Tables["dataset"].Rows[0][0].ToString()); }
        }

        public void MettreAJour()
        {
            string sql;

            sql = "UPDATE table_valeur SET";
            sql += " nom ='" + Nom.Replace("'","''") + "',";
            sql += " code ='" + Code + "',";
            sql += " valeur ='" + Valeur.Replace("'", "''") + "',";
            sql += " valeur_6po ='" + Valeur6PO.Replace("'", "''") + "'";
            sql += " WHERE id='" + ID + "'";
            Acces.cls.Execute(sql);
        }

        public void Supprimer()
        {
            string sql;

            sql = "DELETE FROM table_valeur";
            sql += " WHERE id='" + ID + "'";
            Acces.cls.Execute(sql);
        }

        public Boolean Exister(string _Nom, string _Code)
        {
            string sql;

            sql = "SELECT * FROM table_valeur";
            sql += " WHERE nom='" + _Nom.Replace("'","''") + "'";
            sql += " AND Code='" + _Code + "'";
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
        public int CompareTo(table_valeur p)
        {
            if (p is null) { return 1; }
            else
            {
                string A = Nom + "-" + Valeur;
                string B = p.Nom + "-" + p.Valeur;
                return (A.CompareTo(B));
            }
        }
    }
}
