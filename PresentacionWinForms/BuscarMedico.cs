﻿using System;
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
            listaLocal = negocio.listarMedicos();

            dgvMedicos.DataSource = listaLocal;
            dgvMedicos.Columns[0].Visible = false;
            dgvMedicos.Columns[1].Visible = false;
           // dgvMedicos.Columns[2].Visible = false;
            //dgv_medicos.Columns[3].Visible = false; 
            //dgv_medicos.Columns[4].Visible = false; 
           // dgvMedicos.Columns[5].Visible = false;
            //dgv_medicos.Columns[6].Visible = false;  //DNI
            //dgvMedicos.Columns[7].Visible = false; //DIRECCION
            //dgvMedicos.Columns[8].Visible = false; //EMAIL
        }



 

        private void BuscarMedico_Load(object sender, EventArgs e)
        {

            CargarMedicos();

        }



        

        private void tbxNombre_TextChanged(object sender, EventArgs e)
        {
            if (tbxNombre.Text == "")
            {
                dgvMedicos.DataSource = listaLocal;
            }
            else
            {
                List<Medicos> lista;
                lista = listaLocal.FindAll(X => X.Nombre.Contains(tbxNombre.Text));
                dgvMedicos.DataSource = lista;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                AltaMedico form = new AltaMedico((Medicos)dgvMedicos.CurrentRow.DataBoundItem);
                form.ShowDialog();
                CargarMedicos();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
               
            } 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MedicoNegocio negocio = new MedicoNegocio();
            try
            {
                
                if (dgvMedicos.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("Está seguro de que desea eliminar el registro?", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //unGestorClientes.eliminarLogico((int)dgwClientes.CurrentRow.Cells[0].Value);
                        negocio.eliminarLogico((int)dgvMedicos.CurrentRow.Cells[0].Value);
                        MessageBox.Show("Cliente eliminado");

                        CargarMedicos();

                       
                        
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un registro");
                }




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }
    }
}
