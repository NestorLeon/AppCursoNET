using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Utilerias;

namespace Negocio
{
    public class clsNAsientoTipo
    {
        #region PROPIEDADES
        public int ID { get; set; }
        public string Tipo { get; set; }
        #endregion

        #region MÉTODOS
        public static bool CrearCuenta(string tipo)
        {
            bool valorRetorno = false;
            try
            {
                
                string strConnection = "Server=database-server-cine.c8hbnhjrqbcv.us-east-2.rds.amazonaws.com;Database=BD_CursoCSharpNet;User Id=admin;Password=s1I8lTCuyPxnXdkCGOV5;";
                dcCineDataContext dcDataContext = new dcCineDataContext(strConnection);
                dcDataContext.Connection.Open();
                               
                Asiento_Tipo objAsiento_Tipo = new Asiento_Tipo();
                objAsiento_Tipo.Tipo = tipo;
                
                dcDataContext.Asiento_Tipo.InsertOnSubmit(objAsiento_Tipo);
                              
                dcDataContext.SubmitChanges();
                dcDataContext.Connection.Close();

                valorRetorno = true;
            }
            catch (Exception ex)
            {
                clsULogExceptions.WriteException(ex.Message);
                throw new ApplicationException("Ocurrió un error al actualizar el tipo de asiento.");
            }
            return valorRetorno;
        }
        public static List<Asiento_Tipo> ObtenerLista()
        {
            string strConnection = "Server=database-server-cine.c8hbnhjrqbcv.us-east-2.rds.amazonaws.com;Database=BD_CursoCSharpNet;User Id=admin;Password=s1I8lTCuyPxnXdkCGOV5;";
            dcCineDataContext dcDataContext = new dcCineDataContext(strConnection);
            dcDataContext.Connection.Open();

           
            var sqlConsulta = from u in dcDataContext.Asiento_Tipo
                              select u;

            dcDataContext.SubmitChanges();
            dcDataContext.Connection.Close();

            return sqlConsulta.ToList();
        }
        public static bool Actualizar(Asiento_Tipo tipo)
        {
            bool valorRetorno = false;
            try
            {
                
                string strConnection = "Server=database-server-cine.c8hbnhjrqbcv.us-east-2.rds.amazonaws.com;Database=BD_CursoCSharpNet;User Id=admin;Password=s1I8lTCuyPxnXdkCGOV5;";
                dcCineDataContext dcDataContext = new dcCineDataContext(strConnection);
                dcDataContext.Connection.Open();
                               
                Asiento_Tipo objAsientoTipo = dcDataContext.Asiento_Tipo.First(u => u.ID == tipo.ID);
                objAsientoTipo.Tipo = tipo.Tipo;
                                
                dcDataContext.SubmitChanges();
                dcDataContext.Connection.Close();

                valorRetorno = true;
            }
            catch (Exception ex)
            {
                clsULogExceptions.WriteException(ex.Message);
                throw new ApplicationException("Ocurrió un error al actualizar el tipo de asiento.");
            }
            return valorRetorno;
        }
        public static bool Eliminar(int ID)
        {

            bool valorRetorno = false;
            try
            {
                
                string strConnection = "Server=database-server-cine.c8hbnhjrqbcv.us-east-2.rds.amazonaws.com;Database=BD_CursoCSharpNet;User Id=admin;Password=s1I8lTCuyPxnXdkCGOV5;";
                dcCineDataContext dcDataContext = new dcCineDataContext(strConnection);
                dcDataContext.Connection.Open();
                                
                Asiento_Tipo tipo = dcDataContext.Asiento_Tipo.First(u => u.ID == ID);

                dcDataContext.Asiento_Tipo.DeleteOnSubmit(tipo);
                                
                dcDataContext.SubmitChanges();
                dcDataContext.Connection.Close();

                valorRetorno = true;
            }
            catch (Exception ex)
            {
                clsULogExceptions.WriteException(ex.Message);
                throw new ApplicationException("Ocurrió un error al actualizar el tipo de asiento.");
            }
            return valorRetorno;
        }
        public static Asiento_Tipo GetOne(int ID)
        {
            Asiento_Tipo valorRetorno = null;
            try
            {
                
                string strConnection = "Server=database-server-cine.c8hbnhjrqbcv.us-east-2.rds.amazonaws.com;Database=BD_CursoCSharpNet;User Id=admin;Password=s1I8lTCuyPxnXdkCGOV5;";
                dcCineDataContext dcDataContext = new dcCineDataContext(strConnection);
                dcDataContext.Connection.Open();
                                
                valorRetorno = dcDataContext.Asiento_Tipo.First(u => u.ID == ID);
                                
                dcDataContext.SubmitChanges();
                dcDataContext.Connection.Close();
            }
            catch (Exception ex)
            {
                clsULogExceptions.WriteException(ex.Message);
                throw new ApplicationException("Ocurrió un error al obtener el tipo de asiento con ID igual a " + ID);
            }
            return valorRetorno;
        }

        public static void Login()
        {

        }
        #endregion
    }
}
