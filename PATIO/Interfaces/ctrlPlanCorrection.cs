using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PATIO.Classes;

namespace PATIO.Interfaces
{
    public partial class ctrlPlanCorrection : UserControl
    {
        public PATIO.Classes.AccesNet Acces;
        public WeifenLuo.WinFormsUI.Docking.DockPanel DP;

        public ctrlConsole Console;
        public string Chemin;

        public List<Element> Liste;

        public ctrlPlanCorrection()
        {
            InitializeComponent();
        }

        public void Initialiser()
        {
            Afficher_ListeAttribut();
        }

        void Afficher_ListeAttribut()
        {
            lstAttribut.Items.Clear();
            Acces.Charger_ListeAttribut();

            foreach (Attribut a in Acces.ListeAttribut)
            {
                if (a.Element_Type == Acces.type_ACTION.id && a.Libelle.Substring(0, 1) != "_")
                { lstAttribut.Items.Add(a.Code + " : " + a.Libelle); }
            }
        }

        private void lstAttribut_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstAttribut.SelectedIndex < 0) { return; }

            string code = lstAttribut.Text.Split(':')[0].Trim();
            foreach(TabPage t in tabControl1.TabPages)
            {
                if(t.Text == code) { tabControl1.SelectedTab = t; break; }
            }
        }

        void Execute(string attribut_code, List<string>  Listevaleur)
        {
            foreach (Element e in Liste)
            {
                int element_type = e.Element_Type;

                int attribut_id = 0;

                attribut_id = Acces.Trouver_Attribut_ID(element_type, attribut_code);
                if(attribut_id == 0) { goto Suite; }

                //Suppression de l'ensemble ds valeurs associées à l'attribut
                Acces.Supprimer_dElement(e.ID, attribut_id);

                //Ajoute des nouvelles valeurs
                foreach (string valeur in Listevaleur)
                {
                    dElement d = new dElement() { Acces = Acces, };

                    d.Element_ID = e.ID;
                    d.Attribut_ID = attribut_id;
                    d.Attribut_Code = attribut_code;
                    d.Valeur = valeur;
                    d.Ajouter();
                }

                Suite:;
            }
        }
    }
}
