using System;
using System.Data.SqlClient;
using ControleDeRota.Modelos;
using System.Collections.Generic;

namespace ControleDeRota.DAO
{
    public class ClientesRotasDao : Connection
    {
        private string query;
        public bool insert(ClientesRotasMod _ClienteRota)
        {
            try
            {
                conectar();
                query = "Insert Into tblClientesRotas(iCodRota,iCodCliente,iSequencialRota) Values (@iCodRota,@iCodCliente,@iSequencialRota)";
                SqlCommand cmd = new SqlCommand(query, objConn);
                atribuirValores(cmd, _ClienteRota);
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

        public bool update(ClientesRotasMod _ClienteRota)
        {
            try
            {
                conectar();
                query = "Update tblClientesRotas Set iSequencialRota = @iSequencialRota Where iCodigoClientesRotas = @iCodigoClientesRotas";
                SqlCommand cmd = new SqlCommand(query, objConn);
                atribuirValores(cmd, _ClienteRota);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                return false;
                throw new Exception(e.ToString());
            }
            finally
            {
                if (!(objConn == null))
                {
                    desconectar();
                }
            }
            return true;
        }

        public bool delete(ClientesRotasMod _ClienteRotaMod)
        {
            try
            {
                conectar();
                query = "Delete from tblClientesRotas where iCodigoClientesRotas = @iCodigoClientesRotas";
                SqlCommand cmd = new SqlCommand(query, objConn);
                atribuirValores(cmd, _ClienteRotaMod);
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

        public List<ClientesRotasMod> listaClientesRotas()
        {
            ClientesRotasMod _ClienteRotaMod = new ClientesRotasMod();
            return listaClientesRotas(_ClienteRotaMod);
        }

        public List<ClientesRotasMod> listaClientesRotas(ClientesRotasMod _ClienteRotaMod)
        {
            SqlDataReader dr = null;
            List<ClientesRotasMod> lista = new List<ClientesRotasMod>();
            string query = "Select cr.iCodigoClientesRotas, cr.iCodRota, r.sDescricao As sRota, r.iCodVendedor, v.sNome As sVendedor, cr.iCodCliente, c.sDescricao As sCliente, c.sEndereco, c.sNumero, c.sCidade, c.sUF, c.sCEP, cr.iSequencialRota From tblClientesRotas cr inner join tblRotas r on r.iCodigoRota = cr.iCodRota inner join tblVendedores v on v.iCodigoVendedor = r.iCodVendedor inner join tblClientes c on c.iCodigoCliente = cr.iCodCliente where 1 = 1 ";
            if(_ClienteRotaMod.iCodRota != 0)
            {
                query += "And cr.iCodRota = " + _ClienteRotaMod.iCodRota + " Order by cr.iSequencialRota";
            }

            try
            {
                conectar();
                SqlCommand cmd = new SqlCommand(query, objConn);
                dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                while (dr.Read())
                {
                    ClientesRotasMod c = new ClientesRotasMod();
                    c.iCodigoClientesRotas = Convert.ToInt32(dr["iCodigoClientesRotas"]);
                    c.iCodRota = Convert.ToInt32(dr["iCodRota"]);
                    c.sRota = dr["sRota"].ToString();
                    c.iCodVendedor = Convert.ToInt32(dr["iCodVendedor"]);
                    c.sVendedor = dr["sVendedor"].ToString();
                    c.iCodCliente = Convert.ToInt32(dr["iCodCliente"]);
                    c.sCliente = dr["sCliente"].ToString();
                    c.sEndereco = dr["sEndereco"].ToString();
                    c.sNumero = dr["sNumero"].ToString();
                    c.sCidade = dr["sCidade"].ToString();
                    c.sUF = dr["sUF"].ToString();
                    c.sCEP = dr["sCEP"].ToString();
                    c.iSequencialRota = Convert.ToInt32(dr["iSequencialRota"]);

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

        public void atribuirValores(SqlCommand cmd, ClientesRotasMod _ClienteRota)
        {
            cmd.Parameters.AddWithValue("@iCodigoClientesRotas", _ClienteRota.iCodigoClientesRotas);
            cmd.Parameters.AddWithValue("@iCodRota", _ClienteRota.iCodRota);
            cmd.Parameters.AddWithValue("@sRota", _ClienteRota.sRota);
            cmd.Parameters.AddWithValue("@iCodVendedor", _ClienteRota.iCodVendedor);
            cmd.Parameters.AddWithValue("@sVendedor", _ClienteRota.sVendedor);
            cmd.Parameters.AddWithValue("@iCodCliente", _ClienteRota.iCodCliente);
            cmd.Parameters.AddWithValue("@sCliente", _ClienteRota.sCliente);
            cmd.Parameters.AddWithValue("@sEndereco", _ClienteRota.sEndereco);
            cmd.Parameters.AddWithValue("@sNumero", _ClienteRota.sNumero);
            cmd.Parameters.AddWithValue("@sCidade", _ClienteRota.sCidade);
            cmd.Parameters.AddWithValue("@sUF", _ClienteRota.sUF);
            cmd.Parameters.AddWithValue("@sCEP", _ClienteRota.sCEP);
            cmd.Parameters.AddWithValue("@iSequencialRota", _ClienteRota.iSequencialRota);
        }
    }
}