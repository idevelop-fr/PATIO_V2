using System;
using System.Data;

namespace PATIO.Classes
{
    public class Lien : IComparable<Lien>
    {
        public AccesNet Acces;

        public int ID { get; set; }
        //Element0 : clé de Regroupement ex : Plan
        public int element0_type { get; set; }
        public string element0_code { get; set; }
        public int element0_id { get; set; }
        //Element1: clé représentant un parent dans la structure
        public int element1_type { get; set; }
        public string element1_code { get; set; }
        public int element1_id { get; set; }
        //Element1: clé représentant un fils dans la structure
        public int element2_type { get; set; }
        public string element2_code { get; set; }
        public int element2_id { get; set; }

        public int ordre=0;
        public string complement;

        //Met à jour les champs de la table Lien
        public void MettreAJour()
        {
            string sql;

            sql = "UPDATE lien SET ";
            sql += " element0_type='" + element0_type + "',";
            sql += " element0_code='" + element0_code + "',";
            sql += " element0_id='" + element0_id + "',";
            sql += " element1_type='" + element1_type + "',";
            sql += " element1_code='" + element1_code + "',";
            sql += " element1_id='" + element1_id + "',";
            sql += " element2_type='" + element2_type + "',";
            sql += " element2_code='" + element2_code + "',";
            sql += " element2_id='" + element2_id + "',";
            sql += " ordre='" + ordre + "',";
            sql += " complement='" + complement + "'";
            sql += " WHERE id='" + ID + "'";
            Acces.cls.Execute(sql);
        }

        //Ajouter un nouveau lien
        public void Ajouter()
        {
            string sql;

            //Ajoute des informations
            sql = "INSERT INTO lien (element0_type, element0_code, element0_id,";
            sql += " element1_type, element1_code, element1_id,";
            sql += " element2_type, element2_code, element2_id,";
            sql += " ordre, complement) VALUES (";
            sql += "'" + element0_type + "',";
            sql += "'" + element0_code + "',";
            sql += "'" + element0_id + "',";
            sql += "'" + element1_type + "',";
            sql += "'" + element1_code + "',";
            sql += "'" + element1_id + "',";
            sql += "'" + element2_type + "',";
            sql += "'" + element2_code + "',";
            sql += "'" + element2_id + "',";
            sql += "'" + ordre + "',";
            sql += "'" + complement + "')";

            Acces.cls.Execute(sql);

            //Recherche de l'ID
            sql = "SELECT id FROM lien";
            sql += " WHERE element0_id='" + element0_id + "'";
            sql += " AND element1_id='" + element1_id + "'";
            sql += " AND element2_id='" + element2_id + "'";
            DataSet Sn = Acces.cls.ContenuRequete(sql);

            if(Acces.cls.NbLignes ==0) { return; }
            ID = int.Parse(Sn.Tables["dataset"].Rows[0][0].ToString());
        }

        //Supprimer un lien
        public void Supprimer()
        {
            string sql;

            sql = "DELETE FROM lien";
            sql += " WHERE ID='" + ID + "'";
            Acces.cls.Execute(sql);
        }

        //Donne l'ordre max des enfants du lien
        public int Donner_Ordre()
        {
            string sql;
            sql = "SELECT max(ordre) as maxordre FROM lien";
            sql += " WHERE element0_id = '" + element0_id + "'";
            sql += " AND element1_id = '" + element1_id + "'";

            DataSet Sn = Acces.cls.ContenuRequete(sql);

            if(Acces.cls.NbLignes == 0) { return 0; }

            try
            {
                if (Sn.Tables["dataset"].Rows[0][0].ToString().Length > 0)
                { return int.Parse(Sn.Tables["dataset"].Rows[0][0].ToString()); }
                else
                { return 0; }
            }
            catch { return 0; }
        }

        public Boolean Exister_Lien(string element0_type, string element0_code, string element1_type, string element1_code, string element2_type, string element2_code)
        {
            string sql;

            sql = "SELECT * FROM lien";
            sql += " WHERE element0_type='" + element0_type + "'";
            sql += " AND element0_code='" + element0_code + "'";
            sql += " AND element1_type='" + element1_type + "'";
            sql += " AND element1_code='" + element1_code + "'";
            sql += " AND element2_type='" + element2_type + "'";
            sql += " AND element2_code='" + element2_code + "'";
            DataSet Sn = Acces.cls.ContenuRequete(sql);

            if(Acces.cls.NbLignes==0) { return false; }

            return true;
        }

        //Met à jour les codes lors d'une modification du code sur l'objet
        public void MettreAJourCode(TypeElement typeelement,int id, string code)
        {
            string sql;

            sql = "UPDATE lien SET element0_code='" + code + "'";
            sql += " WHERE element0_type='" + typeelement.id + "'";
            sql += " AND element0_id='" + id + "'";
            Acces.cls.Execute(sql);

            sql = "UPDATE lien SET element1_code='" + code + "'";
            sql += " WHERE element1_type='" + typeelement.id + "'";
            sql += " AND element1_id='" + id + "'";
            Acces.cls.Execute(sql);

            sql = "UPDATE lien SET element2_code='" + code + "'";
            sql += " WHERE element2_type='" + typeelement.id + "'";
            sql += " AND element2_id='" + id + "'";
            Acces.cls.Execute(sql);
        }

        //Comparateur par défaut
        public int CompareTo(Lien p)
        {
            if (p is null) { return 1; }
            else
            {
                string A = element0_type.ToString()
                           + element1_type.ToString()
                           + element2_type.ToString()
                           + element0_code + element1_code
                           + string.Format("{0,5:X5}", ordre);
                string B = p.element0_type.ToString()
                           + p.element1_type.ToString()
                           + p.element2_type.ToString()
                           + p.element0_code + p.element1_code
                           + string.Format("{0,5:X5}", p.ordre);

                return (A.CompareTo(B));
            }
        }

        public int ComparePlan(Lien p)
        {
            if (p is null) { return 1; }
            else
            {
                string A = element0_code;
                string B = p.element0_code;

                return (A.CompareTo(B));
            }
        }
    }
}
