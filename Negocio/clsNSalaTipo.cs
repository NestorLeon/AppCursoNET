using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilerias;

namespace Negocio
{
    public class clsNSalaTipo
    {
        #region PROPIEDADES
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Capacidad { get; set; }
        public string Formato_Pantalla { get; set; }
        public string Sonido { get; set; }
        #endregion

        #region MÉTODOS, ACCIONES, OPERACIONES
        public static bool AgregarSala(string Nombre, string Descripcion, int Capacidad, string Formato_Pantalla, string Sonido)
        {
            bool valorRetorno = false;
            try
            {
                // CREAR OBJETO DATA CONTEXT Y ABRIR CONEXIÓN
                string strConnection = "Server=database-server-cine.c8hbnhjrqbcv.us-east-2.rds.amazonaws.com;Database=BD_CursoCSharpNet;User Id=admin;Password=s1I8lTCuyPxnXdkCGOV5;";
                dcCineDataContext dcDataContext = new dcCineDataContext(strConnection);
                dcDataContext.Connection.Open();

                // INSTRUCCIONES DE MANIPULACIÓN DE LOS DATOS
                Sala_Tipo objSalaTipo = new Sala_Tipo();
                objSalaTipo.Nombre = Nombre;
                objSalaTipo.Descripcion = Descripcion;
                objSalaTipo.Capacidad = Capacidad;
                objSalaTipo.Formato_Pantalla = Formato_Pantalla;
                objSalaTipo.Sonido = Sonido;

                dcDataContext.Sala_Tipo.InsertOnSubmit(objSalaTipo);

                // ENVIAR CAMBIOS Y CERRAR CONEXIÓN
                dcDataContext.SubmitChanges();
                dcDataContext.Connection.Close();

                valorRetorno = true;
            }
            catch (Exception ex)
            {
                clsULogExceptions.WriteException(ex.Message);
                throw new ApplicationException("Ocurrió un error al actualizar el tipo de Sala.");
            }
            return valorRetorno;
        }
        public static List<Sala_Tipo> ObtenerLista()
        {
            string strConnection = "Server=database-server-cine.c8hbnhjrqbcv.us-east-2.rds.amazonaws.com;Database=BD_CursoCSharpNet;User Id=admin;Password=s1I8lTCuyPxnXdkCGOV5;";
            dcCineDataContext dcDataContext = new dcCineDataContext(strConnection);
            dcDataContext.Connection.Open();

            //  select * from Usuario
            var sqlConsulta = from u in dcDataContext.Sala_Tipo
                              select u;

            dcDataContext.SubmitChanges();
            dcDataContext.Connection.Close();

            return sqlConsulta.ToList();
        }
        public static bool Actualizar(Sala_Tipo sala_Tipo)
        {
            bool valorRetorno = false;
            try
            {
                // CREAR OBJETO DATA CONTEXT Y ABRIR CONEXIÓN
                string strConnection = "Server=database-server-cine.c8hbnhjrqbcv.us-east-2.rds.amazonaws.com;Database=BD_CursoCSharpNet;User Id=admin;Password=s1I8lTCuyPxnXdkCGOV5;";
                dcCineDataContext dcDataContext = new dcCineDataContext(strConnection);
                dcDataContext.Connection.Open();

                // INSTRUCCIONES DE MANIPULACIÓN DE LOS DATOS
                Sala_Tipo objSalaTipo = dcDataContext.Sala_Tipo.First(u => u.ID == sala_Tipo.ID);
                objSalaTipo.Nombre = sala_Tipo.Nombre;
                objSalaTipo.Descripcion = sala_Tipo.Descripcion;
                objSalaTipo.Capacidad = sala_Tipo.Capacidad;
                objSalaTipo.Formato_Pantalla = sala_Tipo.Formato_Pantalla;
                objSalaTipo.Sonido = sala_Tipo.Sonido;

                // ENVIAR CAMBIOS Y CERRAR CONEXIÓN
                dcDataContext.SubmitChanges();
                dcDataContext.Connection.Close();

                valorRetorno = true;
            }
            catch (Exception ex)
            {
                clsULogExceptions.WriteException(ex.Message);
                throw new ApplicationException("Ocurrió un error al actualizar el tipo de Sala.");
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
                Sala_Tipo sala_Tipo = dcDataContext.Sala_Tipo.First(u => u.ID == ID);

                dcDataContext.Sala_Tipo.DeleteOnSubmit(sala_Tipo);

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
        public static Sala_Tipo GetOne(int ID)
        {
            Sala_Tipo valorRetorno = null;
            try
            {
                // CREAR OBJETO DATA CONTEXT Y ABRIR CONEXIÓN
                string strConnection = "Server=database-server-cine.c8hbnhjrqbcv.us-east-2.rds.amazonaws.com;Database=BD_CursoCSharpNet;User Id=admin;Password=s1I8lTCuyPxnXdkCGOV5;";
                dcCineDataContext dcDataContext = new dcCineDataContext(strConnection);
                dcDataContext.Connection.Open();

                // INSTRUCCIONES DE MANIPULACIÓN DE LOS DATOS
                valorRetorno = dcDataContext.Sala_Tipo.First(u => u.ID == ID);

                // ENVIAR CAMBIOS Y CERRAR CONEXIÓN
                dcDataContext.SubmitChanges();
                dcDataContext.Connection.Close();
            }
            catch (Exception ex)
            {
                clsULogExceptions.WriteException(ex.Message);
                throw new ApplicationException("Ocurrió un error al obtener el tipo de Sala con ID igual a " + ID);
            }
            return valorRetorno;
        }
        #endregion
    }
}
