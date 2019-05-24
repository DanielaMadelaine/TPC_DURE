using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using AccesoDatos;


namespace Negocio
{
    public class EspecialidadNegocio
    {
        public List<Especialidades> listarEspecialidades()
        {
            List<Especialidades> listado = new List<Especialidades>();
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            Especialidades uni = new Especialidades();
            try
            {
                accesoDatos.setearConsulta("Select Idespecialidad, Descripcion from ESPECIALIDADES");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    uni = new Especialidades();
                    uni.idespecialidad= (int)accesoDatos.Lector["IdEspecialidad"];
                    uni.descripcion = accesoDatos.Lector["Descripcion"].ToString();
                    listado.Add(uni);
                }

                return listado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }
    }
}
