using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using PATIO.Classes;
using PATIO.Modules;
using System.IO;

namespace PATIO.Interfaces
{
    public partial class ctrlImport : UserControl
    {
        public PATIO.Classes.AccesNet Acces;
        public WeifenLuo.WinFormsUI.Docking.DockPanel DP;
        public int PropId;
        public string Chemin;

        Fonctions fonc = new Fonctions();

        List<Plan> listeplan;
        List<Objectif> listeobjectif;
        List<PATIO.Classes.Action> listeaction;
        List<Indicateur> listeindicateur;
        List<Utilisateur> listeutilisateur;

        public ctrlImport()
        {
            InitializeComponent();
        }

        public void Initialise()
        {
            lblRepertoire.Text=Chemin + "\\Export";
            AfficherFichier(lblRepertoire.Text);
        }

        void Importer()
        {
            foreach(var item in lstFichier.CheckedItems)
            {
                LireFichier(item.ToString());
            }
            lst.Items.Add("---FIN---");
        }

        private void BtnChoisir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.SelectedPath = Chemin + "\\Export";

            if(f.ShowDialog()== DialogResult.OK )
            {
                lblRepertoire.Text = f.SelectedPath;
                AfficherFichier(f.SelectedPath);
            }
        }

        void AfficherFichier(string Repertoire)
        {
            lstFichier.Items.Clear();
            foreach(var f in Directory.GetFiles(Repertoire,"*.xml"))
            {
                lstFichier.Items.Add(f,true);
            }
        }

        void LireFichier(string fichier)
        {
            StringBuilder result = new StringBuilder();

            XElement xdoc = XElement.Load(fichier);

            //Détermine la nature du fichier
            string TypeFichier = xdoc.Name.ToString();

            //Explore le fichier
            switch(TypeFichier)
            {
                case "Plans":
                    {
                        lst.Items.Add("Fichier de type PLAN");
                        lst.SelectedIndex = lst.Items.Count - 1;
                        Application.DoEvents();
                        ExtraitPlan(xdoc);
                        break;
                    }
                case "Objectifs":
                    {
                        lst.Items.Add("Fichier de type OBJECTIF");
                        lst.SelectedIndex = lst.Items.Count - 1;
                        ExtraitObjectif(xdoc);
                        break;
                    }

                case "Actions":
                    {
                        lst.Items.Add("Fichier de type ACTION");
                        lst.SelectedIndex = lst.Items.Count - 1;
                        Application.DoEvents();
                        ExtraitAction(xdoc);
                        break;
                    }

                case "Liens":
                    {
                        lst.Items.Add("Fichier de type LIEN");
                        lst.SelectedIndex = lst.Items.Count - 1;
                        Application.DoEvents();
                        ExtraitLien(xdoc);
                        break;
                    }

                case "Indicateurs":
                    {
                        lst.Items.Add("Fichier de type INDICATEUR");
                        lst.SelectedIndex = lst.Items.Count - 1;
                        Application.DoEvents();
                        ExtraitIndicateur(xdoc);
                        break;
                    }

                case "Utilisateurs":
                    {
                        lst.Items.Add("Fichier de type UTILISATEUR");
                        lst.SelectedIndex = lst.Items.Count - 1;
                        Application.DoEvents();
                        ExtraitUtilisateur(xdoc);
                        break;
                    }
            }
        }

        void ExtraitPlan(XElement element)
        {
            foreach (XElement childElement in element.Elements())
            {
                if(childElement.Name=="Plan")
                {
                    Plan p = new Plan();

                    foreach (XElement xl in childElement.Elements())
                    {
                        switch(xl.Name.ToString())
                        {
                            case "ID":
                                {p.ID = int.Parse(xl.Value.ToString()); break; }
                            case "Libelle":
                                { p.Libelle = xl.Value.ToString(); break; }
                            case "Code":
                                { p.Code  = xl.Value.ToString(); break; }
                            case "Actif":
                                { p.Actif = bool.Parse(xl.Value.ToString()); break; }
                            case "TypePlan":
                                { p.TypePlan = (TypePlan)int.Parse(xl.Value.ToString()); break; }
                            case "Pilote":
                                { p.Pilote = Acces.Trouver_Utilisateur(int.Parse(xl.Value.ToString())); break; }
                            case "NiveauPlan":
                                { p.NiveauPlan = (NiveauPlan)int.Parse(xl.Value.ToString()); break; }
                            case "Abrege":
                                { p.Abrege = xl.Value.ToString(); break; }
                            case "DateDebut":
                                { p.DateDebut = DateTime.Parse(xl.Value.ToString()); break; }
                            case "DateFin":
                                { p.DateFin = DateTime.Parse(xl.Value.ToString()); break; }
                            case "OptAnalyseGlobale":
                                { p.OptAnalyseGlobale = bool.Parse(xl.Value.ToString()); break; }
                            case "OptCommentaires":
                                { p.OptCommentaires = bool.Parse(xl.Value.ToString()); break; }
                            case "OptGouvernance":
                                { p.OptGouvernance = bool.Parse(xl.Value.ToString()); break; }
                            case "OptPrioriteRegionale":
                                { p.OptPrioriteRegionale = bool.Parse(xl.Value.ToString()); break; }
                        }
                    }
                    if (!Acces.Existe_Element(Acces.type_PLAN, "CODE", p.Code))
                    {
                        Acces.Ajouter_Element(Acces.type_PLAN, p);
                        if (Acces.cls.erreur.Length > 0) { lst.Items.Add(Acces.cls.erreur); }
                    }
                }
            }
        }

        void ExtraitObjectif(XElement element)
        {
            foreach (XElement childElement in element.Elements())
            {
                if (childElement.Name == "Objectif")
                {
                    Objectif p = new Objectif ();

                    foreach (XElement xl in childElement.Elements())
                    {
                        switch (xl.Name.ToString())
                        {
                            case "ID":
                                { p.ID = int.Parse(xl.Value.ToString()); break; }
                            case "Libelle":
                                { p.Libelle = xl.Value.ToString(); break; }
                            case "Code":
                                { p.Code = xl.Value.ToString(); break; }
                            case "Description":
                                { p.Description = xl.Value.ToString(); break; }
                            case "Actif":
                                { p.Actif = bool.Parse(xl.Value.ToString()); break; }
                            case "TypeObjectif":
                                { p.TypeObjectif = (TypeObjectif) int.Parse(xl.Value.ToString()); break; }
                            case "Pilote":
                                { p.Pilote = Acces.Trouver_Utilisateur(int.Parse(xl.Value.ToString())); break; }
                            case "DateDebut":
                                { p.DateDebut = DateTime.Parse(xl.Value.ToString()); break; }
                            case "DateFin":
                                { p.DateFin = DateTime.Parse(xl.Value.ToString()); break; }
                            case "Meteo":
                                { p.Meteo = (Meteo)int.Parse(xl.Value.ToString()); break; }
                            case "TxAvancement":
                                { p.TxAvancement = (TxAvancement)int.Parse(xl.Value.ToString()); break; }
                            case "AnalyseQualitative":
                                { p.AnalyseQualitative = xl.Value.ToString(); break; }
                        }
                    }
                    if (!Acces.Existe_Element(Acces.type_OBJECTIF , "CODE", p.Code)) { Acces.Ajouter_Element(Acces.type_OBJECTIF, p); }
                }
            }
        }

        void ExtraitAction(XElement element)
        {
            listeutilisateur = (List<Utilisateur>)Acces.Remplir_ListeElement(Acces.type_UTILISATEUR.id, "");

            foreach (XElement childElement in element.Elements())
            {
                if (childElement.Name == "Action")
                {
                    PATIO.Classes.Action p = new PATIO.Classes.Action();

                    foreach (XElement xl in childElement.Elements())
                    {
                        switch (xl.Name.ToString())
                        {
                            case "ID":
                                { p.ID = int.Parse(xl.Value.ToString()); break; }
                            case "Libelle":
                                { p.Libelle = xl.Value.ToString(); break; }
                            case "Code":
                                { p.Code = xl.Value.ToString().Replace("+", "_").Replace("|", "."); ; break; }
                            case "Description":
                                { p.Description = xl.Value.ToString(); break; }
                            case "Actif":
                                { p.Actif = bool.Parse(xl.Value.ToString()); break; }
                            case "TypeAction":
                                { p.TypeAction= (TypeAction)int.Parse(xl.Value.ToString()); break; }
                            case "Pilote":
                                { p.Pilote = Acces.Trouver_Utilisateur(int.Parse(xl.Value.ToString())); break; }
                            case "DateDebut":
                                { p.DateDebut = DateTime.Parse(xl.Value.ToString()); break; }
                            case "DateFin":
                                { p.DateFin = DateTime.Parse(xl.Value.ToString()); break; }
                            case "Meteo":
                                { p.Meteo = (Meteo)int.Parse(xl.Value.ToString()); break; }
                            case "TxAvancement":
                                { p.TxAvancement = (TxAvancement)int.Parse(xl.Value.ToString()); break; }
                            case "ActionInnovante":
                                { p.ActionInnovante = bool.Parse(xl.Value.ToString()); break; }
                            case "AnalyseQualitative":
                                { p.AnalyseQualitative = xl.Value.ToString(); break; }
                            case "ReductionInegalite":
                                { p.ReductionInegalite = xl.Value.ToString(); break; }
                        }
                    }

                    if (!Acces.Existe_Element(Acces.type_ACTION, "CODE", p.Code)) { Acces.Ajouter_Element(Acces.type_ACTION, p); }
                }
            }
        }

        void ExtraitLien(XElement element)
        {
            listeplan = (List<Plan>)Acces.Remplir_ListeElement(Acces.type_PLAN.id, "");
            listeobjectif = (List<Objectif>)Acces.Remplir_ListeElement(Acces.type_OBJECTIF.id, "");
            listeaction = (List<PATIO.Classes.Action>)Acces.Remplir_ListeElement(Acces.type_ACTION.id, "");
            listeindicateur = (List<Indicateur>)Acces.Remplir_ListeElement(Acces.type_INDICATEUR.id, "");

            foreach (XElement childElement in element.Elements())
            {
                if (childElement.Name == "Lien")
                {
                    Lien p = new Lien() { Acces = Acces, } ;

                    foreach (XElement xl in childElement.Elements())
                    {
                        switch (xl.Name.ToString())
                        {
                            case "ID":
                                { p.ID = int.Parse(xl.Value.ToString()); break; }
                            case "element0_type":
                                { p.element0_type = int.Parse(xl.Value.ToString()); break; }
                            case "element0_id":
                                { p.element0_id = int.Parse(xl.Value.ToString()); break; }
                            case "element0_code":
                                { p.element0_code = xl.Value.ToString(); break; }
                            case "element1_type":
                                { p.element1_type =int.Parse(xl.Value.ToString()); break; }
                            case "element1_Id":
                                { p.element1_id = int.Parse(xl.Value.ToString()); break; }
                            case "element1_code":
                                { p.element1_code = xl.Value.ToString(); break; }
                            case "element2_type":
                                { p.element2_type = int.Parse(xl.Value.ToString()); break; }
                            case "element2_Id":
                                { p.element2_id = int.Parse(xl.Value.ToString()); break; }
                            case "element2_code":
                                { p.element2_code= xl.Value.ToString(); break; }
                            case "Ordre":
                                { p.ordre = int.Parse(xl.Value.ToString()); break; }
                            case "complement":
                                { p.complement = xl.Value.ToString(); break; }
                        }
                    }
                    //Recherche des identifiants par rapport aux codes
            int typeelement_id = Acces.type_OBJECTIF.id;
                    if (p.element1_type == Acces.type_OBJECTIF.id)
                        { p.element1_code = p.element1_code.Replace("+", "_"); }
                    if (p.element2_type == Acces.type_OBJECTIF.id)
                        { p.element2_code = p.element2_code.Replace("+", "_"); }
                    if (p.element1_type == Acces.type_ACTION.id)
                        { p.element1_code = p.element1_code.Replace("+", "_").Replace("|", "."); }
                    if (p.element2_type == Acces.type_ACTION.id)
                        { p.element2_code = p.element2_code.Replace("+", "_").Replace("|", "."); }

                    p.element1_id = (int) DonneIDElement( p.element1_type.ToString(), p.element1_code);
                    p.element2_id = (int) DonneIDElement( p.element2_type.ToString(), p.element2_code);

                    if (!(p.Exister_Lien(p.element0_type.ToString(), p.element0_code, p.element1_type.ToString(), p.element1_code, p.element2_type.ToString(), p.element2_code)))
                    { p.Ajouter(); Acces.Ajouter_Lien(p); }
                }
            }
        }

        int DonneIDElement(string typeelement, string Code)
        {
            int id = 0;

            if(typeelement == Acces.type_PLAN.code)
            {
                foreach(Plan p in listeplan)
                { if(p.Code==Code) { id = p.ID; break; } }
                if (id == 0) { lst.Items.Add("Pb Plan : " + Code); }
            }

            if (typeelement == Acces.type_OBJECTIF.code)
            {
                foreach (Objectif p in listeobjectif)
                { if (p.Code == Code) { id = p.ID; break; } }
                if (id == 0) { lst.Items.Add("Pb Objectif : " + Code); }
            }

            if (typeelement == Acces.type_ACTION.code)
            {
                foreach (PATIO.Classes.Action p in listeaction)
                { if (p.Code == Code) { id = p.ID; break; } }
                if (id == 0) { lst.Items.Add("Pb Action : " + Code); }
            }

            if (typeelement == Acces.type_INDICATEUR.code)
            {
                foreach (Indicateur p in listeindicateur)
                { if (p.Code == Code) { id = p.ID; break; } }
                if (id == 0) { lst.Items.Add("Pb Indicateur : " + Code); }
            }

            return id;
        }

        void ExtraitIndicateur(XElement element)
        {
            foreach (XElement childElement in element.Elements())
            {
                if (childElement.Name == "Indicateur")
                {
                    Indicateur  p = new Indicateur();

                    foreach (XElement xl in childElement.Elements())
                    {
                        switch (xl.Name.ToString())
                        {
                            case "ID":
                                { p.ID = int.Parse(xl.Value.ToString()); break; }
                            case "Libelle":
                                { p.Libelle = xl.Value.ToString(); break; }
                            case "Code":
                                { p.Code = xl.Value.ToString(); break; }
                            case "Actif":
                                { p.Actif = bool.Parse(xl.Value.ToString()); break; }
                            case "TypeIndicateur":
                                { p.TypeIndicateur =(TypeIndicateur) int.Parse(xl.Value.ToString()); break; }
                        }
                    }
                    if (!Acces.Existe_Element(Acces.type_INDICATEUR,"CODE", p.Code)) { Acces.Ajouter_Element(Acces.type_INDICATEUR, p); }
                }
            }
        }

         void ExtraitUtilisateur(XElement element)
        {
            foreach (XElement childElement in element.Elements())
            {
                if (childElement.Name == "Utilisateur")
                {
                    Utilisateur p = new Utilisateur();

                    foreach (XElement xl in childElement.Elements())
                    {
                        switch (xl.Name.ToString())
                        {
                            case "ID":
                                { p.ID = int.Parse(xl.Value.ToString()); break; }
                            case "Code":
                                { p.Code = xl.Value.ToString(); break; }
                            case "Nom":
                                { p.Nom  = xl.Value.ToString(); break; }
                            case "Prenom":
                                { p.Prenom = xl.Value.ToString(); break; }
                            case "Mail":
                                { p.Mail = xl.Value.ToString(); break; }
                            case "TypeLicence":
                                { p.TypeLicence = fonc.DonneTypeLicence(xl.Value.ToString()); break; }
                            case "Actif":
                                { p.Actif = bool.Parse(xl.Value.ToString()); break; }
                        }
                    }
                    if (!Acces.Existe_Element(Acces.type_UTILISATEUR,"CODE",p.Code)) { Acces.Ajouter_Element(Acces.type_UTILISATEUR, p); }
                }
            }
        }

        private void BtnImporter_Click(object sender, EventArgs e)
        {
            Importer();
        }

    }
}
