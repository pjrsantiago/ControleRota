using System;
using ControleDeRota.Modelos;
using ControleDeRota.Negocios;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace ControleDeRota.Visoes
{
    public partial class CadRotas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregaGrid();
                dropVendedores();
                dropClientes();
            }
        }

        public void dropVendedores()
        {
            VendedoresNeg _VendedorNeg = new VendedoresNeg();

            List<VendedoresMod> lista = new List<VendedoresMod>();
            lista = _VendedorNeg.listaVendedores();
            VendedoresMod vendedor = new VendedoresMod();
            vendedor.iCodigoVendedor = 0;
            vendedor.sNome = "Selecione um vendedor";
            lista.Add(vendedor);

            lista.Sort(new OrderVendedores(OrderVendedores.SortType.iCodigoVendedor, "Ascending"));

            ddlVendedor.DataSource = lista;
            ddlVendedor.DataTextField = "sNome";
            ddlVendedor.DataValueField = "iCodigoVendedor";
            ddlVendedor.DataBind();
        }

        public void dropClientes()
        {
            ClientesNeg _ClienteNeg = new ClientesNeg();

            List<ClientesMod> lista = new List<ClientesMod>();
            lista = _ClienteNeg.listaClientes();
            ClientesMod cliente = new ClientesMod();
            cliente.iCodigoCliente = 0;
            cliente.sDescricao = "Selecione um cliente";
            lista.Add(cliente);

            lista.Sort(new OrderClientes(OrderClientes.SortType.iCodigoCliente, "Ascending"));

            ddlClientes.DataSource = lista;
            ddlClientes.DataTextField = "sDescricao";
            ddlClientes.DataValueField = "iCodigoCliente";
            ddlClientes.DataBind();
        }

        protected void CarregaGrid()
        {
            RotasNeg _RotaNeg = new RotasNeg();

            List<RotasMod> listaGrid = new List<RotasMod>();
            listaGrid = _RotaNeg.listaRotas();
            Session.Add("ListaGrid", listaGrid);
            gdvRotas.DataSource = listaGrid;
            gdvRotas.DataBind();
        }

        protected void lnkNovo_Click(object sender, EventArgs e)
        {
            limpar();
            MultiView1.ActiveViewIndex = 1;
        }

        protected void btnGravar_Click(object sender, EventArgs e)
        {
            RotasNeg _RotaNeg = new RotasNeg();
            RotasMod _RotaMod = new RotasMod();

            if (!(lblCodRota.Text == string.Empty))
            {
                _RotaMod.iCodigoRota = Convert.ToInt32(lblCodRota.Text);
            }
            _RotaMod.sDescricao = txtDescricao.Text;
            _RotaMod.iCodVendedor = Convert.ToInt32(ddlVendedor.SelectedValue);

            _RotaNeg.salvar(_RotaMod);

            limpar();
            CarregaGrid();
            MultiView1.ActiveViewIndex = 0;
            lnkInserirClientes.Visible = false;
        }

        public void limpar()
        {
            txtDescricao.Text = string.Empty;
            ddlVendedor.SelectedValue = "0";
            ddlClientes.SelectedValue = "0";
            gdvRotas.SelectedIndex = -1;
            lnkInserirClientes.Visible = false;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
            limpar();
            lnkInserirClientes.Visible = false;
        }

        protected void gdvRotas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                RotasNeg _RotaNeg = new RotasNeg();
                _RotaNeg.excluir(Convert.ToInt32(gdvRotas.DataKeys[e.RowIndex].Value));
                CarregaGrid();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        protected void gdvRotas_SelectedIndexChanged(object sender, EventArgs e)
        {
            RotasNeg _RotaNeg = new RotasNeg();
            RotasMod _RotaMod = new RotasMod();
            _RotaMod.iCodigoRota = Convert.ToInt32(gdvRotas.SelectedDataKey.Value);
            try
            {
                foreach (RotasMod lista in _RotaNeg.listaRotas(_RotaMod))
                {
                    lblCodRota.Text = lista.iCodigoRota.ToString();
                    txtDescricao.Text = lista.sDescricao.Trim();
                    ddlVendedor.SelectedValue = lista.iCodVendedor.ToString();

                    lblCodigoRotaValor.Text = lista.iCodigoRota.ToString();
                    lblDescricaoRotaValor.Text = lista.sDescricao.Trim();
                    lblVendedorRotaValor.Text = lista.sVendedor.Trim();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            lnkInserirClientes.Visible = true;
            MultiView1.ActiveViewIndex = 1;
        }

        protected void gdvRotas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvRotas.PageIndex = e.NewPageIndex;
            gdvRotas.SelectedIndex = -1;
            CarregaGrid();
        }

        protected void lnkInserirClientes_Click(object sender, EventArgs e)
        {
            CarregaGridClientesRotas();
            MultiView1.ActiveViewIndex = 2;
        }

        protected void btnInserirCliente_Click(object sender, EventArgs e)
        {
            ClientesRotasNeg _ClienteRotaNeg = new ClientesRotasNeg();
            ClientesRotasMod _ClienteRotaMod = new ClientesRotasMod();

            if (!(lblCodClienteRota.Text == string.Empty))
            {
                _ClienteRotaMod.iCodigoClientesRotas = Convert.ToInt32(lblCodClienteRota.Text);
            }
            _ClienteRotaMod.iCodRota = Convert.ToInt32(lblCodigoRotaValor.Text);
            _ClienteRotaMod.iCodCliente = Convert.ToInt32(ddlClientes.SelectedValue);
            _ClienteRotaMod.iSequencialRota = gdvClientesRotas.Rows.Count + 1;

            _ClienteRotaNeg.salvar(_ClienteRotaMod);

            limpar();
            CarregaGridClientesRotas();
        }

        protected void CarregaGridClientesRotas()
        {
            ClientesRotasNeg _ClienteRotaNeg = new ClientesRotasNeg();
            ClientesRotasMod _ClienteRotaMod = new ClientesRotasMod();

            List<ClientesRotasMod> listaGrid = new List<ClientesRotasMod>();
            _ClienteRotaMod.iCodRota = Convert.ToInt32(lblCodigoRotaValor.Text);
            listaGrid = _ClienteRotaNeg.listaClientesRotas(_ClienteRotaMod);
            Session.Add("ListaGrid", listaGrid);
            gdvClientesRotas.DataSource = listaGrid;
            gdvClientesRotas.DataBind();
        }

        protected void gdvClientesRotas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                ClientesRotasNeg _ClienteRotaNeg = new ClientesRotasNeg();
                ClientesRotasMod _ClienteRotaMod = new ClientesRotasMod();

                _ClienteRotaNeg.excluir(Convert.ToInt32(gdvClientesRotas.DataKeys[e.RowIndex].Value));

                List<ClientesRotasMod> lista = new List<ClientesRotasMod>();
                _ClienteRotaMod.iCodRota = Convert.ToInt32(lblCodigoRotaValor.Text);
                lista = _ClienteRotaNeg.listaClientesRotas(_ClienteRotaMod);
                for (int i = 1; i <= lista.Count; i++)
                {
                    if(!(lista[i-1].iSequencialRota == i))
                    {
                        ClientesRotasMod cr = new ClientesRotasMod();
                        cr = lista[i - 1];
                        cr.iSequencialRota = lista[i - 1].iSequencialRota - 1;
                        _ClienteRotaNeg.update(cr);
                    }
                }

                CarregaGridClientesRotas();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        protected void gdvClientesRotas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ClientesRotasNeg _ClienteRotaNeg = new ClientesRotasNeg();

            if(e.CommandName == "Up" || e.CommandName == "Down")
            {
                int iChave = Convert.ToInt32(e.CommandArgument);
                int iCodigo = Convert.ToInt32(gdvClientesRotas.DataKeys[iChave].Value);
                GridViewRow linha = gdvClientesRotas.Rows[Convert.ToInt32(e.CommandArgument)];
                int iSequencia = Convert.ToInt32(linha.Cells[0].Text);

                if(e.CommandName == "Up")
                {
                    if(iChave != 0)
                    {
                        int iChaveAnterior = Convert.ToInt32(e.CommandArgument) - 1;
                        int iCodigoAnterior = Convert.ToInt32(gdvClientesRotas.DataKeys[iChaveAnterior].Value);
                        GridViewRow linhaAnterior = gdvClientesRotas.Rows[Convert.ToInt32(e.CommandArgument) - 1];
                        int iSequenciaAnterior = Convert.ToInt32(linhaAnterior.Cells[0].Text);

                        _ClienteRotaNeg.up(iCodigo, iCodigoAnterior, iSequencia, iSequenciaAnterior);
                    }
                }

                if(e.CommandName == "Down")
                {
                    if(iChave < gdvClientesRotas.Rows.Count - 1)
                    {
                        int iChavePosterior = Convert.ToInt32(e.CommandArgument) + 1;
                        int iCodigoPosterior = Convert.ToInt32(gdvClientesRotas.DataKeys[iChavePosterior].Value);
                        GridViewRow linhaPosterior = gdvClientesRotas.Rows[Convert.ToInt32(e.CommandArgument) + 1];
                        int iSequenciaPosteior = Convert.ToInt32(linhaPosterior.Cells[0].Text);

                        _ClienteRotaNeg.up(iCodigo, iCodigoPosterior, iSequencia, iSequenciaPosteior);
                    }
                }
            }

            CarregaGridClientesRotas();
        }

        protected void lnkVoltar_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }
    }
}