using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Medicos: Persona
    {
        public int IdMedico { get; set; } 
        public DateTime FechaIngreso { get; set; }
        public Especialidades Especialidad { get; set; }
        public string matricula { get; set; }
        //public Horarios Horariosmedico { get; set; }
    }





}