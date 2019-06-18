using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Direccion
    {
        public String Calle { get; set; }
        public String Localidad { get; set; }
        public String CodigoPostal { get; set; }
        public String Provincia { get; set; }


        public override string ToString()
        {
            return Localidad;
        }

    }
}
