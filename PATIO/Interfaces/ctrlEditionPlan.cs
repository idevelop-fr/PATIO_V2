using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using PATIO.Classes;
using PATIO.Modules;
using Ionic;
using Ionic.Zip;

namespace PATIO.Interfaces
{
    public partial class ctrlEditionPlan : UserControl
    {
        public AccesNet Acces;
        public WeifenLuo.WinFormsUI.Docking.DockPanel DP;
        public string Chemin;

        public ctrlConsole Console;

        public Utilisateur user_appli;

        Plan plan = new Plan();
        EditionFiche edition = new EditionFiche();
        int n = 0;
        List<Plan> ListePlan = new List<Plan>();
        List<FileInfo> Liste = new List<FileInfo>();

        /// <summary>
        /// Procédure d'initialisation standard
        /// </summary>
        public ctrlEditionPlan()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Procédure d'initialisation paramétrée
        /// </summary>
        public void Initialiser()
        {
            Afficher_ListePlan();
        }

        void Editer()
        {
            //Actualise la structure
            CreeStructure();

            //Crée la liste des fichiers produits
            Liste = new List<FileInfo>();
            if (lstPlan.SelectedIndex<0) { return; }

            //Appel le module d'édition des fiches
            edition = new EditionFiche();
            edition.Acces = Acces;
            edition.Chemin = Chemin;
            edition.Console = Console;
            edition.OuvertureAuto = false;

            pb.Visible = true;
            pb.Maximum = n;
            pb.Minimum = 1;
            pb.Step = 1;
            pb.Value = pb.Minimum;
            Application.DoEvents();

            //Pour chaque noeud, la production des fichiers est exécutée
            foreach(TreeNode nd in tree.Nodes)
            {
                Editer_Noeud(nd);
            }

            pb.Visible = false;
        }

        void Editer_Noeud(TreeNode nd)
        {
            tree.SelectedNode = nd;
            nd.EnsureVisible();
            nd.ForeColor = Color.Blue;
            Application.DoEvents();

            pb.PerformStep();
            edition.type_element = nd.Name.Split('-')[0];
            edition.id_element =int.Parse(nd.Name.Split('-')[1]);
            edition.id_parent = 0;
            edition.ordre = 0;

            if(edition.type_element == Acces.type_ACTION.code)
            {
                TreeNode parent = nd.Parent;
                string type_parent = parent.Name.Split('-')[0];
                int id_parent = int.Parse( parent.Name.Split('-')[1]);
                if(type_parent == Acces.type_ACTION.code)
                {
                    edition.id_parent = id_parent;
                    edition.ordre = parent.Nodes[nd.Name].Index+1;
                    //MessageBox.Show(edition.ordre.ToString());
                }
            }

            nd.Tag=edition.Editer_Fiche();

            FileInfo f = new FileInfo(nd.Tag.ToString() + ".pdf");
            Liste.Add(f);

            Console.Ajouter(nd.Tag.ToString());
            foreach(TreeNode nds in nd.Nodes) { Editer_Noeud(nds); }
        }

        /// <summary>
        /// Repositionne les éléments selon la hiérarchie définie
        /// </summary>
        void CreeStructure()
        {
            int nbObjectif = 0; int nbAction = 0; int nbOpération = 0; int nbIndicateur = 0;

            //Affichage de la structure actuelle du plan d'actions
            tree.Nodes.Clear();
            TreeNode NodG = new TreeNode()
            {
                Text = "Plan d'actions de " + plan.NiveauPlan,
                Name = Acces.type_PLAN.code + "-" + plan.ID,
                ImageIndex = 1,
                Tag = Acces.type_PLAN.id,
            };

            NodG.Expand();
            n = 1;

            //Placement des objectifs/sous-objectifs
            List<Lien> listeLien = Acces.Remplir_ListeLien(Acces.type_PLAN, plan.ID.ToString());
            listeLien.Sort();

            //On balaye la liste des éléments
            //On crée l'élément sous le parent
            foreach (var p in listeLien)
            {
                //Recherche du parent
                string Parent = Acces.Trouver_TableValeur(p.element1_type).Code + "-" + p.element1_id.ToString();
                TreeNode NodParent = NodG;

                if (!(Parent == NodG.Name))
                {
                    TreeNode[] NodP = NodG.Nodes.Find(Parent, true);
                    if (NodP.Length > 0) { NodParent = NodP[0]; }
                }

                string Enfant = Acces.Trouver_TableValeur(p.element2_type).Code + "-" + p.element2_id.ToString();
                if (!(Enfant is null))
                {
                    Boolean Ajoute = true;
                    //Création de l'élément enfant
                    TreeNode NodEnfant = new TreeNode()
                    {
                        Name = Enfant,
                        Tag = p,
                    };

                    if (p.element2_type == Acces.type_OBJECTIF.id)
                    //if (p.element2_type == Acces.Trouver_TableValeur_ID("TYPE_ELEMENT", p.element1_type.ToString()))
                    {
                        Objectif q = (Objectif)Acces.Trouver_Element(Acces.type_OBJECTIF.id, p.element2_id);
                        if (!(q is null))
                        {
                            NodEnfant.Text = q.Libelle;
                            NodEnfant.Name = Acces.type_OBJECTIF.code + "-" + q.ID;
                            //NodEnfant.ImageIndex = Donner_ImageIndex(Acces.type_OBJECTIF.id, p.element2_id);
                            NodEnfant.ToolTipText = q.Code;
                            nbObjectif++;
                        }
                        else { Console.Ajouter("[Objectif non trouvé] ID:" + p.element2_id + " Code :" + p.element2_code); }
                    }

                    if (p.element2_type == Acces.type_ACTION.id)
                    {
                        PATIO.Classes.Action q = (PATIO.Classes.Action)Acces.Trouver_Element(Acces.type_ACTION.id, p.element2_id);
                        if (!optOpération.Checked) { Ajoute = (q.TypeAction == TypeAction.ACTION); }
                        if (!(q is null))
                        {
                            NodEnfant.Text = q.Libelle;
                            NodEnfant.Name = Acces.type_ACTION.code + "-" + q.ID;
                            //NodEnfant.ImageIndex = Donner_ImageIndex(Acces.type_ACTION.id, p.element2_id);
                            //if (q.ActionPhare) { NodEnfant.ImageIndex = imgs[PosImageActionPhare].Id; }
                            NodEnfant.ToolTipText = q.Code + " [" + p.ordre + "]";
                            if (q.TypeAction == TypeAction.ACTION) { nbAction++; }
                            if (q.TypeAction == TypeAction.OPERATION) { nbOpération++; }
                        }
                        else { Console.Ajouter("[Action non trouvée] ID:" + p.element2_id + " CODE:" + p.element2_code); }
                    }

                    if (p.element2_type == Acces.type_INDICATEUR.id)
                    {
                        Ajoute = optIndicateur.Checked;
                        Indicateur q = (Indicateur)Acces.Trouver_Element(Acces.type_INDICATEUR.id, p.element2_id);
                        if (!(q is null))
                        {
                            NodEnfant.Text = q.Libelle;
                            NodEnfant.Name = Acces.type_INDICATEUR.code + "-" + q.ID;
                            //NodEnfant.ImageIndex = Donner_ImageIndex(Acces.type_INDICATEUR.id, p.element2_id);
                            NodEnfant.ToolTipText = q.Code;
                            nbIndicateur++;
                        }
                        else { Console.Ajouter("[Indicateur non trouvée] ID:" + p.element2_id + " CODE:" + p.element2_code); }
                    }

                    if (Ajoute)
                    {
                        NodParent.Nodes.Add(NodEnfant);
                        n++;
                    }
                }
            }

            lblNbObjectif.Text = "Objectif : " + nbObjectif.ToString();
            lblNbAction.Text = "Actions : " + nbAction.ToString();
            lblNbOpération.Text = "Opérations : " + nbOpération.ToString();
            lblNbIndicateur.Text = "Indicateurs : " + nbIndicateur.ToString();

            NodG.ExpandAll();
            tree.Nodes.Add(NodG);
        }

        /// <summary>
        /// Réponse donnée lors d'un enregistrement dans une fiche action
        /// </summary>
        void Handler_evt_Selection(object sender, ctrlListePlan.evt_Selection e)
        {
            //plan = ctrllisteplan.plan;
            CreeStructure();
        }

        private void btnEditer_Click(object sender, EventArgs e)
        {
            Editer();
        }

        private void btnOuvrir_Click(object sender, EventArgs e)
        {
            Ouvrir_Fichier("PDF");
        }

        void Ouvrir_Fichier(string type)
        {
            if (tree.SelectedNode == null) { return; }

            string fichier = tree.SelectedNode.Tag.ToString();

            if (fichier.Length > 0)
            {
                if (type == "PDF") { edition.OuvertureFichier(fichier + ".pdf"); }
                if (type == "XLS") { edition.OuvertureFichier(fichier + ".xlsx"); }
            }

        }

        public void Afficher_ListePlan()
        {
            lstPlan.Items.Clear();

            //Recherche de la liste des plans
            ListePlan = (List<Plan>)Acces.Remplir_ListeElement(Acces.type_PLAN.id, "", true);
            ListePlan.Sort();

            foreach (var p in ListePlan)
            {
                lstPlan.Items.Add(p.Libelle);
            }
        }

        private void lstPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach(Plan p in ListePlan)
            {
                if(p.Libelle == lstPlan.SelectedItem.ToString())
                {
                    plan = p;
                    CreeStructure();
                    return;
                }
            }
        }

        private void btnOuvrirXLS_Click(object sender, EventArgs e)
        {
            Ouvrir_Fichier("XLS");
        }

        private void btnAgréger_Click(object sender, EventArgs e)
        {
            Agréger();
        }

        void Agréger()
        {

            PDF pdf = new PDF();
            pdf.MergePDF(Liste, Chemin + "\\Fichiers\\FX-" + plan.Code + ".pdf");
        }

        private void btnCompresser_Click(object sender, EventArgs e)
        {
            CompresserXLS();
        }

        void CompresserXLS()
        {
            ZipFile zip = new ZipFile();
            foreach(FileInfo f in Liste)
            {
                string fichier = f.FullName.Replace(".pdf", ".xlsx");
                zip.AddFile(fichier, plan.Code);
            }

            string dest = Chemin + "\\Fichiers\\FX-" + plan.Code + ".zip";
            zip.Save(dest);
            MessageBox.Show("le fichier compressé est : " + dest,"Terminé");
        }

        private void optOpération_CheckedChanged(object sender, EventArgs e)
        {
            CreeStructure();
        }

        private void optIndicateur_CheckedChanged(object sender, EventArgs e)
        {
            CreeStructure();
        }
    }
}
