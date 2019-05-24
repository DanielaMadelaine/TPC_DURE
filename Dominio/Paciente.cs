using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Paciente: Persona
    {
        public String IdPaciente { get; set; }
        public DateTime FechaIngreso { get; set; }
        public ObraSocial ObraSocial { get; set; }
    }
}