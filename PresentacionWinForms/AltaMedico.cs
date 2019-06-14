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


        private Medicos medicolocal = null;
        


        public AltaMedico()
        {
            InitializeComponent();
           
        }


        public AltaMedico(Medicos doctor)
        {
            InitializeComponent();
            medicolocal = doctor;

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
              
                if (medicolocal == null)

                medicolocal = new Medicos();
                medicolocal.Direcc = new Direccion();

               // medicolocal.IdMedico = int.Parse(textBox3.Text);
                medicolocal.Nombre = txbNombre.Text;
                medicolocal.Apellido = txbApellido.Text;
                medicolocal.DNI = txtDNI.Text;
                medicolocal.Especialidad = (Especialidades)cbxEspecialidad.SelectedItem;
                medicolocal.FechaNacimiento = Nacimiento.Value;
                medicolocal.Email = txbEmail.Text;
                if (rbtMasculino.Checked == true) { medicolocal.Sexo = "M"; } else { medicolocal.Sexo = "F"; }
                medicolocal.Telephone = txbTelefono.Text;
                medicolocal.matricula = txbMatricula.Text;
                medicolocal.TipoTel = (string)comboBoxTipoTel.SelectedItem;
                medicolocal.Direcc.Localidad = txbLocalidad.Text;
                medicolocal.Direcc.CodigoPostal = txbCP.Text;
                medicolocal.Direcc.Calle = txbDomicilio.Text;
                medicolocal.Direcc.Provincia = (string)comboBoxPROV.SelectedItem;
                
                 if (medicolocal.IdMedico != 0)
                {
                      negocio.modificarMedico(medicolocal);
                    MessageBox.Show("Modificado Correctamente  :)");
                }
                else
                {
                    negocio.AgregarMedicos(medicolocal);
                    MessageBox.Show("Agregado Correctamente");
                }
                
                Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void AltaMedico_Load(object sender, EventArgs e)
        {
          
                EspecialidadNegocio SpecialidadNegocio = new EspecialidadNegocio();
            try
            {
                cbxEspecialidad.DataSource = SpecialidadNegocio.listarEspecialidades();

                if (medicolocal != null)
                {

                    txbNombre.Text = medicolocal.Nombre;
                    txbApellido.Text = medicolocal.Apellido;
                    //ckbCapa.Checked = medicolocal.UsaCapa;
                    //ckbVuela.Checked = medicolocal.Volador;
                    //cboUniverso.SelectedIndex = cboUniverso.FindString(heroeLocal.Universo.Nombre);

                    //alternativa al retomar una modificacion. Si tenes configurado Display y Value Member
                    //cboUniverso.SelectedValue = heroeLocal.Universo.Id;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
                
        }

        private void button4_Click(object sender, EventArgs e)
        {

            try
            {
                HorariosMedicos form = new HorariosMedicos();
                form.ShowDialog();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

           
        }









    }
}


        
    
    

