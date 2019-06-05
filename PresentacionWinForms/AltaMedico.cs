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
    public partial class AltaMedico : Form
    {


        Medicos medicolocal = null;

        public AltaMedico()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MedicoNegocio negocio = new MedicoNegocio();
            try
            {
                //MSF-20190420: ahora pasamos a usar siempre la variable heroeLocal, si vino algo de afuera, lo usamos
                //pero sino, tenemos que crear un heroe nuevo.
                if (medicolocal == null)
                    medicolocal = new Medicos();

                medicolocal.Nombre = txbNombre.Text;
                medicolocal.Apellido = txbApellido.Text;
                medicolocal.DNI = txtDNI.Text;
                //medicolocal.Volador = ckbVuela.Checked;
                medicolocal.Especialidad = (Especialidades)cbxEspecialidad.SelectedItem;

                //MSF-20190420: si el heroe tienen ID es porque vino uno existente de afuera, entonces lo modifico.
                //Sino, es porque lo acabo de crear, entonces lo mando a agregar.
                // if (medicolocal.Id != 0)
                //{
                //  negocio.modificarHeroe(heroeLocal);
                //}
                //else
                //{
                //negocio.agregarHeroe(heroeLocal);
                // }
                negocio.AgregarMedicos(medicolocal);
                Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
    
}
