using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

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
        public static void CrearCuenta(string usuario, string password, string correo_electronico)
        {
            string strConnection = "Server=database-server-cine.c8hbnhjrqbcv.us-east-2.rds.amazonaws.com;Database=BD_CursoCSharpNet;User Id=admin;Password=s1I8lTCuyPxnXdkCGOV5;";
            dcCineDataContext dcDataContext = new dcCineDataContext(strConnection);
            dcDataContext.Connection.Open();

            Usuario objUsuario = new Usuario();
            objUsuario.Usuario1 = usuario;
            objUsuario.Password = password;
            objUsuario.CorreoElectronico = correo_electronico;

            dcDataContext.Usuario.InsertOnSubmit(objUsuario);

            dcDataContext.SubmitChanges();
            dcDataContext.Connection.Close();

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

        public static void Login()
        {

        }
        public static void ActualizarCuenta()
        {

        }
        public static void EliminarCuenta(int ID)
        {
            string strConnection = "Server=database-server-cine.c8hbnhjrqbcv.us-east-2.rds.amazonaws.com;Database=BD_CursoCSharpNet;User Id=admin;Password=s1I8lTCuyPxnXdkCGOV5;";
            dcCineDataContext dcDataContext = new dcCineDataContext(strConnection);
            dcDataContext.Connection.Open();

            Usuario usuario = dcDataContext.Usuario.First(u => u.ID == ID);

            dcDataContext.Usuario.DeleteOnSubmit(usuario);

            dcDataContext.SubmitChanges();
            dcDataContext.Connection.Close();
        }
        #endregion
    }
}
