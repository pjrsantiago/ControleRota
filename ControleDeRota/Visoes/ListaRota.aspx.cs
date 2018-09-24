using System;
using ControleDeRota.Modelos;
using ControleDeRota.Negocios;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace ControleDeRota.Visoes
{
    public partial class ListaRota : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dropRotas();
            }
        }

        public void dropRotas()
        {
            RotasNeg _RotaNeg = new RotasNeg();

            List<RotasMod> lista = new List<RotasMod>();
            lista = _RotaNeg.listaRotas();
            RotasMod rota = new RotasMod();
            rota.iCodigoRota = 0;
            rota.sDescricao = "Selecione uma rota";
            lista.Add(rota);

            lista.Sort(new OrderRotas(OrderRotas.SortType.iCodigoRota, "Ascending"));

            ddlRota.DataSource = lista;
            ddlRota.DataTextField = "sDescricao";
            ddlRota.DataValueField = "iCodigoRota";
            ddlRota.DataBind();
        }

        protected void ddlRota_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClientesRotasMod _ClienteRotaMod = new ClientesRotasMod();
            ClientesRotasNeg _ClienteRotaNeg = new ClientesRotasNeg();

            _ClienteRotaMod.iCodRota = Convert.ToInt32(ddlRota.SelectedValue);

            if(_ClienteRotaMod.iCodRota != 0)
            {
                try
                {
                    foreach (ClientesRotasMod lista in _ClienteRotaNeg.listaClientesRotas(_ClienteRotaMod))
                    {
                        lblDescricaoValor.Text = lista.sRota.Trim();
                        lblVendedorValor.Text = lista.sVendedor.Trim();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }

                CarregaGrid(_ClienteRotaMod);
            }
        }

        protected void CarregaGrid(ClientesRotasMod _ClienteRotaMod)
        {
            ClientesRotasNeg _ClienteRotaNeg = new ClientesRotasNeg();

            List<ClientesRotasMod> listaGrid = new List<ClientesRotasMod>();
            listaGrid = _ClienteRotaNeg.listaClientesRotas(_ClienteRotaMod);
            Session.Add("ListaGrid", listaGrid);
            gdvRotas.DataSource = listaGrid;
            gdvRotas.DataBind();
        }
    }
}