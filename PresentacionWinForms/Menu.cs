using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentacionWinForms
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void altaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AltaPaciente ventana = new AltaPaciente();
            ventana.ShowDialog();

        }

        private void altaMedicosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AltaMedico ventana = new AltaMedico();
            ventana.ShowDialog();
        }

        private void listaMedicosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListaMedicos ventana = new ListaMedicos();
            ventana.ShowDialog();
        }

       
    }
}
