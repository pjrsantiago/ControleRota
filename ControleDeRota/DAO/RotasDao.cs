using System;
using System.Data.SqlClient;
using ControleDeRota.Modelos;
using System.Collections.Generic;

namespace ControleDeRota.DAO
{
    public class RotasDao : Connection
    {
        private string query;
        public bool insert(RotasMod _Rota)
        {
            try
            {
                conectar();
                query = "Insert Into tblRotas(sDescricao,iCodVendedor) Values (@sDescricao,@iCodVendedor)";
                SqlCommand cmd = new SqlCommand(query, objConn);
                atribuirValores(cmd, _Rota);
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

        public bool update(RotasMod _Rota)
        {
            try
            {
                conectar();
                query = "Update tblRotas Set sDescricao = @sDescricao,iCodVendedor = @iCodVendedor Where iCodigoRota = @iCodigoRota";
                SqlCommand cmd = new SqlCommand(query, objConn);
                atribuirValores(cmd, _Rota);
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

        public bool delete(RotasMod _RotaMod)
        {
            try
            {
                conectar();
                query = "Delete from tblRotas where iCodigoRota = @iCodigoRota";
                SqlCommand cmd = new SqlCommand(query, objConn);
                atribuirValores(cmd, _RotaMod);
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

        public List<RotasMod> listaRotas()
        {
            RotasMod _RotaMod = new RotasMod();
            return listaRotas(_RotaMod);
        }

        public List<RotasMod> listaRotas(RotasMod _RotaMod)
        {
            SqlDataReader dr = null;
            List<RotasMod> lista = new List<RotasMod>();
            string query = "Select r.iCodigoRota, r.sDescricao, r.iCodVendedor, v.sNome As sVendedor From tblRotas r inner join tblVendedores v on r.iCodVendedor = v.iCodigoVendedor where 1 = 1 ";
            if(_RotaMod.iCodigoRota != 0)
            {
                query += "And r.iCodigoRota = " + _RotaMod.iCodigoRota;
            }

            try
            {
                conectar();
                SqlCommand cmd = new SqlCommand(query, objConn);
                dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                while (dr.Read())
                {
                    RotasMod r = new RotasMod();
                    r.iCodigoRota = Convert.ToInt32(dr["iCodigoRota"]);
                    r.sDescricao = dr["sDescricao"].ToString();
                    r.iCodVendedor = Convert.ToInt32(dr["iCodVendedor"]);
                    r.sVendedor = dr["sVendedor"].ToString();
                    
                    lista.Add(r);
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

        public void atribuirValores(SqlCommand cmd, RotasMod _Rota)
        {
            cmd.Parameters.AddWithValue("@iCodigoRota", _Rota.iCodigoRota);
            cmd.Parameters.AddWithValue("@sDescricao", _Rota.sDescricao);
            cmd.Parameters.AddWithValue("@iCodVendedor", _Rota.iCodVendedor);
            cmd.Parameters.AddWithValue("@sVendedor", _Rota.sVendedor);
        }
    }
}