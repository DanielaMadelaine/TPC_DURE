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

        public void cargarGrilla()
        {
            MedicoNegocio negocio = new MedicoNegocio();
            try
            {
                //// ACA MANEJAMOS LA LISTA DE LOS MEDICOS , TODOS LOS CAMPOS Y ESO. ECT
                ///// ME TIRA TODO DESPUES RESTRINGIR EN CADA CASO.
                listaLocal = negocio.listarMedicos();
                dgv_medicos.DataSource = listaLocal;
                //dgv_medicos.Columns[0].Visible =false;
                //dgv_medicos.Columns[1].Visible = false;
                //dgv_medicos.Columns[2].Visible = false;
                //dgv_medicos.Columns[3].Visible = false; 
                //dgv_medicos.Columns[4].Visible = false; 
                //dgv_medicos.Columns[5].Visible = false;
                //dgv_medicos.Columns[6].Visible = false;  //DNI
                //dgv_medicos.Columns[7].Visible = false; //DIRECCION
                //dgv_medicos.Columns[8].Visible = false; //EMAIL




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
