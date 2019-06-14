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

            try
            {
                AltaMedico ventana = new AltaMedico();
                ventana.ShowDialog();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            
        }

        private void listaMedicosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ListaMedicos ventana = new ListaMedicos();
                ventana.ShowDialog();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
           
        }

       

        private void eliminarMedicosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EliminarMedico ventana = new EliminarMedico();
            ventana.ShowDialog();
        }

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                BuscarMedico ventana = new BuscarMedico();
                ventana.ShowDialog();
            }
            catch (Exception ex)
            {


                MessageBox.Show(ex.ToString());
            }
           
        }

        
    }
}
