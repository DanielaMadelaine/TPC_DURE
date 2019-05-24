using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Persona
    {


        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public String DNI { get; set; }
        public List<Telefonos> Telefono { get; set; }
        public Direccion Direcc { get; set; }
        public String Email { get; set; }


    }
}
