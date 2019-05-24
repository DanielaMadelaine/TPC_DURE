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
    public partial class ListaMedicos : Form
    {


        private List<Medicos> listaLocal;

        public ListaMedicos()
        {
            InitializeComponent();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cargarGrilla()
        {
            MedicoNegocio negocio = new MedicoNegocio();
            try
            {
                listaLocal = negocio.listarMedicos();
                dgv_medicos.DataSource = listaLocal;
                dgv_medicos.Columns[0].Visible =false;
                dgv_medicos.Columns[1].Visible = false;
                //dgv_medicos.Columns[2].Visible = false;
                //dgv_medicos.Columns[3].Visible = false; NOMBRE
                //dgv_medicos.Columns[4].Visible = false; //APELLIDO
                //dgv_medicos.Columns[5].Visible = false;
                //dgv_medicos.Columns[6].Visible = false;
                dgv_medicos.Columns[7].Visible = false;
                dgv_medicos.Columns[8].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ListaMedicos_Load(object sender, EventArgs e)
        {
            cargarGrilla();
        }
    }
}
