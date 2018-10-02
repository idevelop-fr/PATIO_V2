using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PATIO.Interfaces
{
    public partial class ctrlConsole : UserControl
    {
        public PATIO.Classes.AccesNet Acces;
        public WeifenLuo.WinFormsUI.Docking.DockPanel DP;
        public int PropId;

        public string Chemin;

        public ctrlConsole Console;

        public ctrlConsole()
        {
            InitializeComponent();
        }

        public void Afficher()
        {
            lst.Items.Clear();
        }

        public void Ajouter(string texte)
        {
            lst.Items.Add(texte);
            lst.SelectedIndex = lst.Items.Count - 1;
            System.IO.File.AppendAllText(Chemin + "\\log.txt", "[->] " + texte + "\n");

        }

        private void btnEffacer_Click(object sender, EventArgs e)
        {
            lst.Items.Clear();
        }
    }
}
