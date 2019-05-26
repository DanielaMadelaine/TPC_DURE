using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;


namespace PresentacionWinForms
{
    public partial class BuscarMedico : Form
    {

        private List<Medicos> listaLocal;

        public BuscarMedico()
        {
            InitializeComponent();
        }

        private void tbxNombre_TextChanged(object sender, EventArgs e)
        {
            MedicoNegocio negocio = new MedicoNegocio();
            listaLocal = negocio.listarMedicos();

            if (tbxNombre.Text == "")
            {
                List<Medicos> lista;
                lista = listaLocal.FindAll(X => X.Apellido.Contains(tbxNombre.Text));
                dgvMedicos.DataSource = lista;
                dgvMedicos.DataSource = listaLocal;
            }
            else
            {
                dgvMedicos.DataSource = listaLocal;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
