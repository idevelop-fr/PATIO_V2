using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace PATIO.Modules
{
    /// <summary>
    /// 
    /// </summary>
    public class ClassePHP
    {

        public string Site;
        public string SitePhP;

        public string erreur = "";
        public Boolean Trace = false;

        public PATIO.Interfaces.ctrlConsole Console;

        public int NbLignes=0;
        public string Chemin;

        public DataSet ContenuTable(string nom_table)
        {
            DataSet Sn = new DataSet();
            string url = SitePhP + "contenu_table.php?table=" + nom_table;

            DateTime d1 = DateTime.Now;

            Sn.ReadXml(url, XmlReadMode.Auto);

            DateTime d2 = DateTime.Now;

            if (Trace) { System.IO.File.AppendAllText(Chemin + "\\log.txt", "[Requête] Table " + nom_table + " -> " + (d2 - d1).Milliseconds + " ms" + "\n"); }

            NbLignes = int.Parse(Sn.Tables["stat"].Rows[0][0].ToString());
            System.IO.File.AppendAllText(Chemin + "\\log.txt", "[Nb lignes] " + NbLignes + "\n");

            return Sn;
        }

        public Boolean Initialiser()
        {
            string fichier = Chemin + "\\config.txt";

            if (!System.IO.File.Exists(fichier))
            {
                MessageBox.Show("Absence du fichier de configuration. Contactez l'administrateur", "Erreur");
                return false;
            }
            string Texte = System.IO.File.ReadAllText(fichier);

            Site = Texte;
            SitePhP = Site + "//php//";
            return true;
        }

        public DataSet ContenuRequete(string sql)
        {
            DataSet Sn = new DataSet();
            string msql = sql.Replace("'", "@@@");
            string url = SitePhP + "contenu_req.php?requete=" + msql;

            erreur = "";
            try
            {
            DateTime d1 = DateTime.Now;
            Sn.ReadXml(url, XmlReadMode.Auto);
            NbLignes = int.Parse(Sn.Tables["stat"].Rows[0]["nb"].ToString());
            try { erreur = Sn.Tables["stat"].Rows[0]["error"].ToString(); }
                catch (Exception ex) { Console.Ajouter("[ERREUR] " + ex.Message); }

            DateTime d2 = DateTime.Now;
            if (Trace)
            {
                System.IO.File.AppendAllText(Chemin + "\\log.txt", "[Requête] " + sql + " -> " + (d2 - d1).Milliseconds + " ms" + "\n");
                System.IO.File.AppendAllText(Chemin + "\\log.txt", "[Nb lignes] " + NbLignes + "\n");
                if (erreur.Length > 0)
                    { System.IO.File.AppendAllText(Chemin + "\\log.txt", "[***Erreur***] " + erreur + "\n"); }
            }

            }
            catch(Exception ex)
            {
                System.IO.File.AppendAllText(Chemin + "\\log.txt", url + "\n" + ex.Message + "\n");
            }

            return Sn;
        }

        public Boolean Execute(string sql)
        {
            System.Net.WebClient web = new System.Net.WebClient();
            string url = "";

            Boolean ok = false;

            if(!(sql.Contains(";")))  { sql += ";"; }
            url = SitePhP + "execute_req.php?requete=" + sql;
            Uri uri = new Uri(url);

            DateTime d1 = DateTime.Now;

            string result = web.DownloadString(url);

            Application.DoEvents();

            DateTime d2 = DateTime.Now;

            if (Trace) { System.IO.File.AppendAllText(Chemin + "\\log.txt", "[Requête]\n" + sql + " -> " + (d2 - d1).Milliseconds + " ms" + "\n"); }

            if (result == "1")
                { ok = true; erreur = ""; }
            else
            {
                erreur = result;
                if (Trace) { System.IO.File.AppendAllText(Chemin + "\\log.txt", "[##ERREUR##]\n" + erreur + "\n"); }
            }

            return ok;
        }

        public string GetFile(string fichier)
            {
            string texte = "";

            System.Net.WebClient web = new System.Net.WebClient();
            texte = web.DownloadString(fichier);
            return texte;
        }

        public Boolean Verifie()
        {
            System.Net.WebClient web = new System.Net.WebClient();
            string url = SitePhP + "verif_connexion.php";
            Uri uri = new Uri(url);

            string result = web.DownloadString(url);

            return (result.Length>0);
        }
    }
}
