﻿using System;
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




        public List<Medicos> Cargar_medicos()
        {

            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            ///////////////////////////////////////////////////////////
           
            Medicos auxm;
            Especialidades auxe;
            List<Medicos> listado = new List<Medicos>();
            try
            {


                conexion.ConnectionString = AccesoDatosManager.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;

                comando.CommandText = "select M.IDMEDICO,M.NOMBRE,M.APELLIDO,E.IDESPECIALIDAD,E.DESCRIPCION,M.DNI, M.FECHAINGRESO From MEDICOS M, ESPECIALIDADES E Where M.IDESPECIALIDAD=E.IDESPECIALIDAD";
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    auxm = new Medicos();
                    auxe = new Especialidades();

                    auxm.IdMedico = lector.GetInt32(0);
                    auxm.Nombre = lector.GetString(1);
                    auxm.Apellido = lector.GetString(2);
                    auxm.Especialidad = auxe;
                    auxe.idespecialidad = lector.GetInt32(3);
                    auxe.descripcion = lector.GetString(4);
                    auxm.DNI = lector.GetString(5);
                    auxm.FechaIngreso = lector.GetDateTime(6);

                    listado.Add(auxm);

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

    



        public List<Medicos> listarMedicos()
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            ///////////////////////////////////////////////////////////
            List<Medicos> listado = new List<Medicos>();
            Medicos nuevo;
            Especialidades aux;


            try
            {
                
                conexion.ConnectionString = AccesoDatosManager.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
     
                comando.CommandText = "select M.IDMEDICO,M.NOMBRE,M.APELLIDO,E.IDESPECIALIDAD,E.DESCRIPCION,M.DNI, M.FECHAINGRESO From MEDICOS M, ESPECIALIDADES E Where M.IDESPECIALIDAD=E.IDESPECIALIDAD";
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    nuevo = new Medicos();
                    aux = new Especialidades();


                    nuevo.IdMedico = lector.GetInt32(0);
                    nuevo.Nombre = lector.GetString(1);
                    nuevo.Apellido= lector.GetString(2);
                    nuevo.Especialidad = aux;
                    aux.idespecialidad = lector.GetInt32(3);
                    aux.descripcion = lector.GetString(4);
                    nuevo.DNI = lector.GetString(5);
                    nuevo.FechaIngreso = lector.GetDateTime(6);


                    //MSF-20190420: acá manejamos un posible nulo desde la DB. Recuerdan que la otra vez nos falló?
                    //Era porque en la DB estaba nulo y acá lo queríamos tomar y no le gustaba.
                    //Ojo... en la tabla no todas las columnas van a ser nuleables... en nuestro caso porque no le dimos
                    //importancia casi al diseño de la misma. Pero si está bien armada la tabla, serán pocas las columnas
                    //que sean nulleables. Solo a esa deberían agregarles ésta validación. Que de hecho pueden meter en un método
                    //para no tener que escribirla completa cada vez, por ejemplo.
                    //  if(!Convert.IsDBNull(lector["Debilidad"]))
                    //     nuevo.Apellido = lector.GetString(2);

                    /* if (!Convert.IsDBNull(lector["UsaCapa"]))
                         nuevo.Email = (bool)lector["UsaCapa"];

                     if (!Convert.IsDBNull(lector["Volador"]))
                         nuevo.Volador = (bool)lector["Volador"];

                    */

                 

                    listado.Add(nuevo);
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
                comando.CommandText = "insert into MEDICOS (Idmedico,Nombre,Apellido,DNI, FechaIngreso, IdEspecialidad) values";
                comando.CommandText += "('" + adoctor.Nombre + "', '" + adoctor.Apellido+ "', '" + adoctor.DNI + "', '" + adoctor.FechaIngreso.ToString() + "'," + adoctor.Especialidad.ToString() + ")";
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









    }
}
