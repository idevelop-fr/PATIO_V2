using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PATIO.Classes;

namespace PATIO.Interfaces
{
    public partial class ctrlGroupe : UserControl
    {
        public PATIO.Classes.AccesNet Acces;
        public TreeNode NodG;
        public string GroupeId;
        public WeifenLuo.WinFormsUI.Docking.DockPanel DP;

        public Groupe groupe;

        public ctrlGroupe()
        {
            InitializeComponent();
        }

        public void Affiche()
        {

        }
    }
}
