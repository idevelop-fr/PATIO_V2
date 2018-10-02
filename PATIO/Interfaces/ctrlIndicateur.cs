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
    public partial class ctrlIndicateur : UserControl
    {
        public PATIO.Classes.AccesNet Acces;
        public TreeNode NodG;
        public string IndicateurId;

        public ctrlConsole Console = new ctrlConsole();

        public ctrlIndicateur()
        {
            InitializeComponent();
        }

        public void Affiche()
        {

        }
    }
}
