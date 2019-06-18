using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data.SqlClient;
using AccesoDatos;

namespace Negocio
{
    public class MedicoNegocio
    {


       

        public List<Medicos> listarMedicos()
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            ///////////////////////////////////////////////////////////
            List<Medicos> listado = new List<Medicos>();
            Medicos nuevo;
            Especialidades aux;
            Direccion aux1;


            try
            {
                
                conexion.ConnectionString = AccesoDatosManager.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
     
                comando.CommandText = "SELECT M.IDMEDICO,M.NOMBRE,M.APELLIDO,M.NMATRICULA,E.DESCRIPCION,M.ESTADO,M.DNI,M.TELEFONO,M.FECHANAC,M.TIPOTEL,M.SEXO,M.EMAIL,M.localidad FROM MEDICOS M LEFT JOIN ESPECIALIDADES E ON M.IDESPECIALIDAD = E.IDESPECIALIDAD";
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    nuevo = new Medicos();
                    aux = new Especialidades();
                    aux1 = new Direccion();
                    


                    nuevo.IdMedico = (int)lector["IdMedico"];
                    nuevo.Nombre = lector.GetString(1);
                    nuevo.Apellido= lector.GetString(2);
                    nuevo.matricula = lector.GetString(3);
                    nuevo.Especialidad = aux;
                    aux.descripcion = lector.GetString(4);
                    nuevo.Estado = lector.GetBoolean(5);
                    nuevo.DNI = lector.GetString(6);
                    nuevo.Telephone = lector.GetString(7);
                    nuevo.FechaNacimiento = lector.GetDateTime(8);
                    nuevo.TipoTel = lector.GetString(9);
                    nuevo.Sexo = lector.GetString(10);
                    nuevo.Email = lector.GetString(11);
                   // nuevo.Direcc.Localidad = lector.GetString(12);
            
                    nuevo.Direcc = aux1;
                    aux1.Localidad=lector.GetString(12);



                    if (nuevo.Estado)
                    {
                        listado.Add(nuevo);
                    }
                   
                }                    

                return listado;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }



        public void AgregarMedicos( Medicos adoctor)
        {

            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            try
            {
                conexion.ConnectionString = AccesoDatosManager.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                //MSF-20190420: le agregué todas las columnas. Teniendo en cuenta inclusive lo que elegimos en el combo de selección..
                comando.CommandText = "insert into MEDICOS (Nombre,Apellido,DNI, IdEspecialidad, FechaNac,Email,Sexo,Telefono,NMatricula,tipotel,cp,localidad,provincia,direccion) values";
                comando.CommandText += "( '" + adoctor.Nombre + "', '" + adoctor.Apellido+ "', " + adoctor.DNI + "," + adoctor.Especialidad.idespecialidad.ToString() + ", '" +
                adoctor.FechaNacimiento.ToShortDateString() +"', '"+adoctor.Email+"','"+ adoctor.Sexo +"','"+ adoctor.Telephone +"', '"+adoctor.matricula+"','"+adoctor.TipoTel+"'," +
                ""+adoctor.Direcc.CodigoPostal.ToString()+",'"+adoctor.Direcc.Localidad+"','"+adoctor.Direcc.Provincia+"' , '"+adoctor.Direcc.Calle+"'      )";
                comando.Connection = conexion;
                conexion.Open();

                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }




        }

        public void modificarMedico (Medicos modificar)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {

               // accesoDatos.setearConsulta("Exec Modificarmedico set Nombre = @Nombre, Apellido = @Apellido Where Idmedico = @id");
                accesoDatos.setearSP("modificarmedico");
                //accesoDatos.setearConsulta("update MEDICOS Set Nombre= '"+modificar.Nombre+"', Apellido='"+modificar.Apellido+"',  Idespecialidad="+modificar.Especialidad.idespecialidad.ToString()+" Where Id=" + modificar.IdMedico.ToString());
                accesoDatos.Comando.Parameters.Clear();
                 accesoDatos.Comando.Parameters.AddWithValue("@Nombre", modificar.Nombre);
                 accesoDatos.Comando.Parameters.AddWithValue("@Apellido", modificar.Apellido);
                accesoDatos.Comando.Parameters.AddWithValue("@DNI", modificar.DNI);
                accesoDatos.Comando.Parameters.AddWithValue("@Email", modificar.Email);
                accesoDatos.Comando.Parameters.AddWithValue("@telefono", modificar.Telephone);
                accesoDatos.Comando.Parameters.AddWithValue("@TipoTel", modificar.TipoTel);
                accesoDatos.Comando.Parameters.AddWithValue("@id", modificar.IdMedico);
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarAccion();

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



        public void eliminarLogico(int id)
        {
            AccesoDatosManager conexion;
            try
            {
                conexion = new AccesoDatosManager();
                conexion.setearConsulta("Update MEDICOS Set estado = 0 Where Idmedico=@id");
                conexion.Comando.Parameters.Clear();
                conexion.Comando.Parameters.AddWithValue("@id", id);
                conexion.abrirConexion();
                conexion.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }













    }
}
