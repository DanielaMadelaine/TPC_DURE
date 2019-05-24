using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Turnos
    {
        public int IdTurno { get; set; }
        public DateTime FechaTurno { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public Estado Estado { get; set; }
        public Paciente Paciente { get; set; }
        public List<Medicos> Medicos { get; set; }
        public List<Especialidades> Especialidades { get; set; }
        public Direccion Consultorio { get; set; }
        public Horarios HoraTurno { get; set; }
        public Usuarios usuario { get; set; }
    }
}