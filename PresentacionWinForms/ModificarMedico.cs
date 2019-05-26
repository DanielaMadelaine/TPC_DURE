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

namespace PresentacionWinForms
{
    public partial class ModificarMedico : Form
    {
        private Medicos MedicoLocal = null;


        public ModificarMedico()
        {
            InitializeComponent();
        }

        //MSF-20190420: nuevo constructor para recibir por parametro un heroe a modificar. El mismo será seleccionado desde la ventana de listado de heroes.
        public ModificarMedico(Medicos medico)
        {
            InitializeComponent();
            MedicoLocal = medico;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
