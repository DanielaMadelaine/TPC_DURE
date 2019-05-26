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

        

      

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void CargarMedicos()

        {
            MedicoNegocio negocio = new MedicoNegocio();
            listaLocal = negocio.Cargar_medicos();

            dgvMedicos.DataSource = listaLocal;
            dgvMedicos.Columns[0].Visible = false;
            //dgv_medicos.Columns[1].Visible = false;
            //dgv_medicos.Columns[2].Visible = false;
            //dgv_medicos.Columns[3].Visible = false; 
            //dgv_medicos.Columns[4].Visible = false; 
            dgvMedicos.Columns[5].Visible = false;
            //dgv_medicos.Columns[6].Visible = false;  //DNI
            dgvMedicos.Columns[7].Visible = false; //DIRECCION
            dgvMedicos.Columns[8].Visible = false; //EMAIL
        }



 

        private void BuscarMedico_Load(object sender, EventArgs e)
        {

            CargarMedicos();

        }

        //private void tbxnombre_keyup(object sender, keyeventargs e)
        //{
        //    dataview mifiltro;

        //    string salida = "";
        //    string[] palabra_busqueda = this.tbxnombre.text.split(' ');

        //    foreach (string palabra in palabra_busqueda)
        //    {
        //        if (salida.length == 0)
        //        {
        //            salida = "(nombre like '% " + palabra + "%' or apellido like ' % " + palabra + "%')";
        //        }
        //        else
        //        {
        //            salida += "and (nombre like '% " + palabra + "%' or apellido like ' % " + palabra + "%')";
        //        }
        //    }

          

            






        
    }
}
