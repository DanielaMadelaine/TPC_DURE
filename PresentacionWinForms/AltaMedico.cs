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
        Validaciones validamos = new Validaciones();



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

                
                        medicolocal.Nombre = txbNombre.Text.Trim();
                        medicolocal.Apellido = txbApellido.Text.Trim();
                        medicolocal.DNI = txtDNI.Text.Trim();
                        medicolocal.Especialidad = (Especialidades)cbxEspecialidad.SelectedItem;
                        medicolocal.FechaNacimiento = Nacimiento.Value;
                        medicolocal.Email = txbEmail.Text.Trim();
                        if (rbtMasculino.Checked == true) { medicolocal.Sexo = "M"; } else { medicolocal.Sexo = "F"; }
                        medicolocal.Telephone = txbTelefono.Text.Trim();
                        medicolocal.matricula = txbMatricula.Text.Trim();
                        medicolocal.TipoTel = (string)comboBoxTipoTel.SelectedItem;
                        medicolocal.Direcc.Localidad = txbLocalidad.Text.Trim();
                        medicolocal.Direcc.CodigoPostal = txbCP.Text.Trim();
                        medicolocal.Direcc.Calle = txbDomicilio.Text.Trim();
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
                    txtDNI.Text = medicolocal.DNI;
                    txbTelefono.Text = medicolocal.Telephone;
                    txbMatricula.Text = medicolocal.matricula;
                    txbEmail.Text = medicolocal.Email;
                    comboBoxTipoTel.SelectedIndex = comboBoxTipoTel.FindString(medicolocal.TipoTel);
                    //comboBoxPROV.SelectedIndex = comboBoxPROV.FindString(medicolocal.Direcc.Provincia);
                    //ckbCapa.Checked = medicolocal.UsaCapa;
                    //ckbVuela.Checked = medicolocal.Volador;
                    //cboUniverso.SelectedIndex = cboUniverso.FindString(heroeLocal.Universo.Nombre);
                    cbxEspecialidad.SelectedIndex = cbxEspecialidad.FindString(medicolocal.Especialidad.descripcion);
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

        private void txbNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            validamos.OnlyLetters(e);
        }

        private void txbApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            validamos.OnlyLetters(e);
        }

        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            validamos.OnlyNumbers(e);
        }

        private void txbMatricula_KeyPress(object sender, KeyPressEventArgs e)
        {
            validamos.OnlyNumbers(e);
        }

        private void txbLocalidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            validamos.OnlyLetters(e);
        }

        
        private void txbTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            validamos.OnlyNumbers(e);
        }

        private void txbCP_KeyPress(object sender, KeyPressEventArgs e)
        {
            validamos.OnlyNumbers(e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            txbNombre.Clear();
            txbApellido.Clear();
            txtDNI.Clear();
            txbMatricula.Clear();
            txbEmail.Clear();
            txbLocalidad.Clear();
            txbCP.Clear();
            txbTelefono.Clear();
            rbFemenino.Checked =false;
            rbtMasculino.Checked = false;
            txbDomicilio.Clear();
            cbxEspecialidad.SelectedIndex = -1;
            comboBoxPROV.SelectedIndex = -1;
            comboBoxTipoTel.SelectedIndex = -1;

        }
    }
}


        
    
    

