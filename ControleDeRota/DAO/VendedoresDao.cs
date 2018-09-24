using System;
using System.Data.SqlClient;
using ControleDeRota.Modelos;
using System.Collections.Generic;

namespace ControleDeRota.DAO
{
    public class VendedoresDao : Connection
    {
        private string query;
        public bool insert(VendedoresMod _Vendedor)
        {
            try
            {
                conectar();
                query = "Insert Into tblVendedores(sNome,sCpf,sEndereco,sNumero,sCidade,sUF,sCEP) Values (@sNome,@sCpf,@sEndereco,@sNumero,@sCidade,@sUF,@sCEP)";
                SqlCommand cmd = new SqlCommand(query, objConn);
                atribuirValores(cmd, _Vendedor);
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

        public bool update(VendedoresMod _Vendedor)
        {
            try
            {
                conectar();
                query = "Update tblVendedores Set sNome = @sNome,sCpf = @sCpf,sEndereco = @sEndereco,sNumero = @sNumero,sCidade = @sCidade,sUF = @sUF,sCEP = @sCEP Where iCodigoVendedor = @iCodigoVendedor";
                SqlCommand cmd = new SqlCommand(query, objConn);
                atribuirValores(cmd, _Vendedor);
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

        public bool delete(VendedoresMod _VendedorMod)
        {
            try
            {
                conectar();
                query = "Delete from tblVendedores where iCodigoVendedor = @iCodigoVendedor";
                SqlCommand cmd = new SqlCommand(query, objConn);
                atribuirValores(cmd, _VendedorMod);
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

        public List<VendedoresMod> listaVendedores()
        {
            VendedoresMod _VendedorMod = new VendedoresMod();
            return listaVendedores(_VendedorMod);
        }

        public List<VendedoresMod> listaVendedores(VendedoresMod _VendedorMod)
        {
            SqlDataReader dr = null;
            List<VendedoresMod> lista = new List<VendedoresMod>();
            string query = "Select * from tblVendedores where 1 = 1 ";
            if(_VendedorMod.iCodigoVendedor != 0)
            {
                query += "And iCodigoVendedor = " + _VendedorMod.iCodigoVendedor;
            }

            try
            {
                conectar();
                SqlCommand cmd = new SqlCommand(query, objConn);
                dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                while (dr.Read())
                {
                    VendedoresMod v = new VendedoresMod();
                    v.iCodigoVendedor = Convert.ToInt32(dr["iCodigoVendedor"]);
                    v.sNome = dr["sNome"].ToString();
                    v.sCpf = dr["sCpf"].ToString();
                    v.sEndereco = dr["sEndereco"].ToString();
                    v.sNumero = dr["sNumero"].ToString();
                    v.sCidade = dr["sCidade"].ToString();
                    v.sUF = dr["sUF"].ToString();
                    v.sCEP = dr["sCEP"].ToString();

                    lista.Add(v);
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

        public void atribuirValores(SqlCommand cmd, VendedoresMod _Vendedor)
        {
            cmd.Parameters.AddWithValue("@iCodigoVendedor", _Vendedor.iCodigoVendedor);
            cmd.Parameters.AddWithValue("@sNome", _Vendedor.sNome);
            cmd.Parameters.AddWithValue("@sCpf", _Vendedor.sCpf);
            cmd.Parameters.AddWithValue("@sEndereco", _Vendedor.sEndereco);
            cmd.Parameters.AddWithValue("@sNumero", _Vendedor.sNumero);
            cmd.Parameters.AddWithValue("@sCidade", _Vendedor.sCidade);
            cmd.Parameters.AddWithValue("@sUF", _Vendedor.sUF);
            cmd.Parameters.AddWithValue("@sCEP", _Vendedor.sCEP);
        }
    }
}