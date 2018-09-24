using System;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace ControleDeRota.DAO
{
    public class Connection
    {
        private static string strConn = WebConfigurationManager.ConnectionStrings["ControleDeRotas"].ConnectionString;

        protected SqlConnection objConn;

        protected bool conectar()
        {
            objConn = new SqlConnection(strConn);

            try
            {
                objConn.Open();
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
                return false;
            }
            return true;
        }

        protected bool desconectar()
        {
            try
            {
                if(!(objConn == null)){
                    objConn.Close();
                    objConn.Dispose();
                }
            }catch (Exception e)
            {
                throw new Exception(e.ToString());
                return false;
            }
            return true;
        }
    }
}