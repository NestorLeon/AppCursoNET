using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Utilerias;

namespace Negocio
{
    public class clsNCiudad
    {
        #region PROPIEDADES
        public int ID { get; set; }
        public string Ciudad { get; set; }

        #endregion

        #region MÉTODOS, ACCIONES, OPERACIONES
        public static bool CrearCiudad(string ciudad)
        {
            bool valorRetorno = false;
            try
            {
                // CREAR OBJETO DATA CONTEXT Y ABRIR CONEXIÓN
                string strConnection = "Server=database-server-cine.c8hbnhjrqbcv.us-east-2.rds.amazonaws.com;Database=BD_CursoCSharpNet;User Id=admin;Password=s1I8lTCuyPxnXdkCGOV5;";
                dcCineDataContext dcDataContext = new dcCineDataContext(strConnection);
                dcDataContext.Connection.Open();

                // INSTRUCCIONES DE MANIPULACIÓN DE LOS DATOS
                Ciudad objCiudad = new Ciudad();
                objCiudad.Ciudad1= ciudad;
              

                dcDataContext.Ciudad.InsertOnSubmit(objCiudad);

                // ENVIAR CAMBIOS Y CERRAR CONEXIÓN
                dcDataContext.SubmitChanges();
                dcDataContext.Connection.Close();

                valorRetorno = true;
            }
            catch (Exception ex)
            {
                clsULogExceptions.WriteException(ex.Message);
                throw new ApplicationException("Ocurrió un error al actualizar el usuario.");
            }
            return valorRetorno;
        }
        public static List<Ciudad> ObtenerLista()
        {
            string strConnection = "Server=database-server-cine.c8hbnhjrqbcv.us-east-2.rds.amazonaws.com;Database=BD_CursoCSharpNet;User Id=admin;Password=s1I8lTCuyPxnXdkCGOV5;";
            dcCineDataContext dcDataContext = new dcCineDataContext(strConnection);
            dcDataContext.Connection.Open();

            //  select * from Ciudad
            var sqlConsulta = from u in dcDataContext.Ciudad
                              select u;

            dcDataContext.SubmitChanges();
            dcDataContext.Connection.Close();

            return sqlConsulta.ToList();
        }
        public static bool Actualizar(Ciudad ciudad)
        {
            bool valorRetorno = false;
            try
            {
                // CREAR OBJETO DATA CONTEXT Y ABRIR CONEXIÓN
                string strConnection = "Server=database-server-cine.c8hbnhjrqbcv.us-east-2.rds.amazonaws.com;Database=BD_CursoCSharpNet;User Id=admin;Password=s1I8lTCuyPxnXdkCGOV5;";
                dcCineDataContext dcDataContext = new dcCineDataContext(strConnection);
                dcDataContext.Connection.Open();

                // INSTRUCCIONES DE MANIPULACIÓN DE LOS DATOS
                Ciudad objCiudad = dcDataContext.Ciudad.First(u => u.ID == ciudad.ID);
                objCiudad.Ciudad1= ciudad.Ciudad1;
               

                // ENVIAR CAMBIOS Y CERRAR CONEXIÓN
                dcDataContext.SubmitChanges();
                dcDataContext.Connection.Close();

                valorRetorno = true;
            }
            catch (Exception ex)
            {
                clsULogExceptions.WriteException(ex.Message);
                throw new ApplicationException("Ocurrió un error al actualizar la ciudad");
            }
            return valorRetorno;
        }
        public static bool Eliminar(int ID)
        {

            bool valorRetorno = false;
            try
            {
                // CREAR OBJETO DATA CONTEXT Y ABRIR CONEXIÓN
                string strConnection = "Server=database-server-cine.c8hbnhjrqbcv.us-east-2.rds.amazonaws.com;Database=BD_CursoCSharpNet;User Id=admin;Password=s1I8lTCuyPxnXdkCGOV5;";
                dcCineDataContext dcDataContext = new dcCineDataContext(strConnection);
                dcDataContext.Connection.Open();

                // INSTRUCCIONES DE MANIPULACIÓN DE LOS DATOS
                Ciudad ciudad = dcDataContext.Ciudad.First(u => u.ID == ID);

                dcDataContext.Ciudad.DeleteOnSubmit(ciudad);

                // ENVIAR CAMBIOS Y CERRAR CONEXIÓN
                dcDataContext.SubmitChanges();
                dcDataContext.Connection.Close();

                valorRetorno = true;
            }
            catch (Exception ex)
            {
                clsULogExceptions.WriteException(ex.Message);
                throw new ApplicationException("Ocurrió un error al actualizar la ciudad.");
            }
            return valorRetorno;
        }
        public static Ciudad GetOne(int ID)
        {
            Ciudad valorRetorno = null;
            try
            {
                // CREAR OBJETO DATA CONTEXT Y ABRIR CONEXIÓN
                string strConnection = "Server=database-server-cine.c8hbnhjrqbcv.us-east-2.rds.amazonaws.com;Database=BD_CursoCSharpNet;User Id=admin;Password=s1I8lTCuyPxnXdkCGOV5;";
                dcCineDataContext dcDataContext = new dcCineDataContext(strConnection);
                dcDataContext.Connection.Open();

                // INSTRUCCIONES DE MANIPULACIÓN DE LOS DATOS
                valorRetorno = dcDataContext.Ciudad.First(u => u.ID == ID);

                // ENVIAR CAMBIOS Y CERRAR CONEXIÓN
                dcDataContext.SubmitChanges();
                dcDataContext.Connection.Close();
            }
            catch (Exception ex)
            {
                clsULogExceptions.WriteException(ex.Message);
                throw new ApplicationException("Ocurrió un error al obtener la ciudad con ID igual a " + ID);
            }
            return valorRetorno;
        }

        public static void Login()
        {

        }
        #endregion
    }
}
    
