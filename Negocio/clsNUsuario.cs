using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Utilerias;

namespace Negocio
{
    public class clsNUsuario
    {
        #region PROPIEDADES
        public int ID { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string CorreoElectronico { get; set; }
        #endregion

        #region MÉTODOS, ACCIONES, OPERACIONES
        public static List<Usuario> Search(string usuario, string correo)
        {
            string strConnection = "Server=database-server-cine.c8hbnhjrqbcv.us-east-2.rds.amazonaws.com;Database=BD_CursoCSharpNet;User Id=admin;Password=s1I8lTCuyPxnXdkCGOV5;";
            dcCineDataContext dcDataContext = new dcCineDataContext(strConnection);
            dcDataContext.Connection.Open();

            //  select * from Usuario
            //  where usuario like '%texto%' and correo like '%texto%'
            var sqlConsulta = from u in dcDataContext.Usuario
                              where u.Usuario1.Contains(usuario) &
                                    u.CorreoElectronico.Contains(correo)
                              select u;

            dcDataContext.SubmitChanges();
            dcDataContext.Connection.Close();

            return sqlConsulta.ToList();
        }

        public static bool CrearCuenta(string usuario, string password, string correo_electronico)
        {
            bool valorRetorno = false;
            try
            {
                // CREAR OBJETO DATA CONTEXT Y ABRIR CONEXIÓN
                string strConnection = "Server=database-server-cine.c8hbnhjrqbcv.us-east-2.rds.amazonaws.com;Database=BD_CursoCSharpNet;User Id=admin;Password=s1I8lTCuyPxnXdkCGOV5;";
                dcCineDataContext dcDataContext = new dcCineDataContext(strConnection);
                dcDataContext.Connection.Open();

                // INSTRUCCIONES DE MANIPULACIÓN DE LOS DATOS
                Usuario objUsuario = new Usuario();
                objUsuario.Usuario1 = usuario;
                objUsuario.Password = password;
                objUsuario.CorreoElectronico = correo_electronico;

                dcDataContext.Usuario.InsertOnSubmit(objUsuario);

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
        public static List<Usuario> ObtenerLista()
        {
            string strConnection = "Server=database-server-cine.c8hbnhjrqbcv.us-east-2.rds.amazonaws.com;Database=BD_CursoCSharpNet;User Id=admin;Password=s1I8lTCuyPxnXdkCGOV5;";
            dcCineDataContext dcDataContext = new dcCineDataContext(strConnection);
            dcDataContext.Connection.Open();

            //  select * from Usuario
            var sqlConsulta = from u in dcDataContext.Usuario
                              select u;

            dcDataContext.SubmitChanges();
            dcDataContext.Connection.Close();

            return sqlConsulta.ToList();
        }
        public static bool Actualizar(Usuario usuario)
        {
            bool valorRetorno = false;
            try
            {
                // CREAR OBJETO DATA CONTEXT Y ABRIR CONEXIÓN
                string strConnection = "Server=database-server-cine.c8hbnhjrqbcv.us-east-2.rds.amazonaws.com;Database=BD_CursoCSharpNet;User Id=admin;Password=s1I8lTCuyPxnXdkCGOV5;";
                dcCineDataContext dcDataContext = new dcCineDataContext(strConnection);
                dcDataContext.Connection.Open();

                // INSTRUCCIONES DE MANIPULACIÓN DE LOS DATOS
                Usuario objUsuario = dcDataContext.Usuario.First(u => u.ID == usuario.ID);
                objUsuario.Usuario1 = usuario.Usuario1;
                objUsuario.Password = usuario.Password;
                objUsuario.CorreoElectronico = usuario.CorreoElectronico;

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
                Usuario usuario = dcDataContext.Usuario.First(u => u.ID == ID);

                dcDataContext.Usuario.DeleteOnSubmit(usuario);

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
        public static Usuario GetOne(int ID)
        {
            Usuario valorRetorno = null;
            try
            {
                // CREAR OBJETO DATA CONTEXT Y ABRIR CONEXIÓN
                string strConnection = "Server=database-server-cine.c8hbnhjrqbcv.us-east-2.rds.amazonaws.com;Database=BD_CursoCSharpNet;User Id=admin;Password=s1I8lTCuyPxnXdkCGOV5;";
                dcCineDataContext dcDataContext = new dcCineDataContext(strConnection);
                dcDataContext.Connection.Open();

                // INSTRUCCIONES DE MANIPULACIÓN DE LOS DATOS
                valorRetorno = dcDataContext.Usuario.First(u => u.ID == ID);

                // ENVIAR CAMBIOS Y CERRAR CONEXIÓN
                dcDataContext.SubmitChanges();
                dcDataContext.Connection.Close();
            }
            catch (Exception ex)
            {
                clsULogExceptions.WriteException(ex.Message);
                throw new ApplicationException("Ocurrió un error al obtener el usuario con ID igual a " + ID);
            }
            return valorRetorno;
        }

        public static void Login()
        {

        }
        #endregion
    }
}
