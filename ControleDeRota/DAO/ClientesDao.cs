using System;
using System.Data.SqlClient;
using ControleDeRota.Modelos;
using System.Collections.Generic;

namespace ControleDeRota.DAO
{
    public class ClientesDao : Connection
    {
        private string query;
        public bool insert(ClientesMod _Cliente)
        {
            try
            {
                conectar();
                query = "Insert Into tblClientes(sDescricao,sCpfCnpj,sEndereco,sNumero,sCidade,sUF,sCEP) Values (@sDescricao,@sCpfCnpj,@sEndereco,@sNumero,@sCidade,@sUF,@sCEP)";
                SqlCommand cmd = new SqlCommand(query, objConn);
                atribuirValores(cmd, _Cliente);
                cmd.ExecuteNonQuery();
            }catch (Exception e)
            {
                return false;
                throw new Exception(e.ToString());
            }
            finally
            {
                desconectar();
            }
            return true;
        }

        public bool update(ClientesMod _Cliente)
        {
            try
            {
                conectar();
                query = "Update tblClientes Set sDescricao = @sDescricao,sCpfCnpj = @sCpfCnpj,sEndereco = @sEndereco,sNumero = @sNumero,sCidade = @sCidade,sUF = @sUF,sCEP = @sCEP Where iCodigoCliente = @iCodigoCliente";
                SqlCommand cmd = new SqlCommand(query, objConn);
                atribuirValores(cmd, _Cliente);
                cmd.ExecuteNonQuery();
            }catch (Exception e)
            {
                return false;
                throw new Exception(e.ToString());
            }
            finally
            {
                if(!(objConn == null))
                {
                    desconectar();
                }
            }
            return true;
        }

        public bool delete(ClientesMod _ClienteMod)
        {
            try
            {
                conectar();
                query = "Delete from tblClientes where iCodigoCliente = @iCodigoCliente";
                SqlCommand cmd = new SqlCommand(query, objConn);
                atribuirValores(cmd, _ClienteMod);
                cmd.ExecuteNonQuery();
            }catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
            finally
            {
                desconectar();
            }
            return true;
        }

        public List<ClientesMod> listaClientes()
        {
            ClientesMod _ClienteMod = new ClientesMod();
            return listaClientes(_ClienteMod);
        }

        public List<ClientesMod> listaClientes(ClientesMod _ClienteMod)
        {
            SqlDataReader dr = null;
            List<ClientesMod> lista = new List<ClientesMod>();
            string query = "Select * from tblClientes where 1 = 1 ";
            if(_ClienteMod.iCodigoCliente != 0)
            {
                query += "And iCodigoCliente = " + _ClienteMod.iCodigoCliente;
            }

            try
            {
                conectar();
                SqlCommand cmd = new SqlCommand(query, objConn);
                dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                while (dr.Read())
                {
                    ClientesMod c = new ClientesMod();
                    c.iCodigoCliente = Convert.ToInt32(dr["iCodigoCliente"]);
                    c.sDescricao = dr["sDescricao"].ToString();
                    c.sCpfCnpj = dr["sCpfCnpj"].ToString();
                    c.sEndereco = dr["sEndereco"].ToString();
                    c.sNumero = dr["sNumero"].ToString();
                    c.sCidade = dr["sCidade"].ToString();
                    c.sUF = dr["sUF"].ToString();
                    c.sCEP = dr["sCEP"].ToString();

                    lista.Add(c);
                }
            }catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
            finally
            {
                if(!(dr == null))
                {
                    dr.Close();
                }
            }
            return lista;
        }

        public void atribuirValores(SqlCommand cmd, ClientesMod _Cliente)
        {
            cmd.Parameters.AddWithValue("@iCodigoCliente", _Cliente.iCodigoCliente);
            cmd.Parameters.AddWithValue("@sDescricao", _Cliente.sDescricao);
            cmd.Parameters.AddWithValue("@sCpfCnpj", _Cliente.sCpfCnpj);
            cmd.Parameters.AddWithValue("@sEndereco", _Cliente.sEndereco);
            cmd.Parameters.AddWithValue("@sNumero", _Cliente.sNumero);
            cmd.Parameters.AddWithValue("@sCidade", _Cliente.sCidade);
            cmd.Parameters.AddWithValue("@sUF", _Cliente.sUF);
            cmd.Parameters.AddWithValue("@sCEP", _Cliente.sCEP);
        }
    }
}