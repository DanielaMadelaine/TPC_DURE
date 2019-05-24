using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Especialidades
    {
        public String descripcion { get; set; }
        public int idespecialidad { get; set; }


        public override string ToString()
        {
            return descripcion;
        }



    }
}