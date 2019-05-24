using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Horarios
    {
        public  DateTime HoraEntrada { get; set; }
        public DateTime Horario { get; set; }
        public List<String> DiasDisponibles { get; set; }
    }
}