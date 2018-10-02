using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PATIO.Interfaces
{
    public partial class frmChoix : Form
    {
        public string choix = "";
        public frmChoix()
        {
            InitializeComponent();
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            if (lst.SelectedIndex < 0) { MessageBox.Show("Aucun choix !"); return; }

            choix = lst.Items[lst.SelectedIndex].ToString();

            this.DialogResult = DialogResult.OK;

        }
    }
}
