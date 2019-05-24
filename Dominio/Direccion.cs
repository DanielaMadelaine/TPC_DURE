using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Direccion
    {
        public String Calle { get; set; }
        public string Numero { get; set; }
        public String Piso { get; set; }
        public String Departamento { get; set; }
        public String Localidad { get; set; }
        public int CP { get; set; }
        public String Provincia { get; set; }
    }
}