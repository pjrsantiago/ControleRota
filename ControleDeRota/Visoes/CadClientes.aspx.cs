using System;
using ControleDeRota.Modelos;
using ControleDeRota.Negocios;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace ControleDeRota.Visoes
{
    public partial class CadClientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregaGrid();
            }
            
        }

        protected void CarregaGrid()
        {
            ClientesNeg _ClienteNeg = new ClientesNeg();

            List<ClientesMod> listaGrid = new List<ClientesMod>();
            listaGrid = _ClienteNeg.listaClientes();
            Session.Add("ListaGrid", listaGrid);
            gdvClientes.DataSource = listaGrid;
            gdvClientes.DataBind();
        }

        protected void btnGravar_Click(object sender, EventArgs e)
        {
            ClientesNeg _ClienteNeg = new ClientesNeg();
            ClientesMod _ClienteMod = new ClientesMod();

            if(!(lblCodigoCliente.Text == string.Empty))
            {
                _ClienteMod.iCodigoCliente = Convert.ToInt32(lblCodigoCliente.Text);
            }
            _ClienteMod.sDescricao = txtDescricao.Text;
            _ClienteMod.sCpfCnpj = txtCpfCnpj.Text;
            _ClienteMod.sEndereco = txtEndereco.Text;
            _ClienteMod.sNumero = txtNumero.Text;
            _ClienteMod.sCidade = txtCidade.Text;
            _ClienteMod.sUF = txtUF.Text;
            _ClienteMod.sCEP = txtCEP.Text;

            _ClienteNeg.salvar(_ClienteMod);

            limpar();
            CarregaGrid();
            MultiView1.ActiveViewIndex = 0;
        }

        protected void lnkNovo_Click(object sender, EventArgs e)
        {
            limpar();
            MultiView1.ActiveViewIndex = 1;
        }

        public void limpar()
        {
            txtDescricao.Text = string.Empty;
            txtCpfCnpj.Text = string.Empty;
            txtEndereco.Text = string.Empty;
            txtNumero.Text = string.Empty;
            txtCidade.Text = string.Empty;
            txtUF.Text = string.Empty;
            txtCEP.Text = string.Empty;
            gdvClientes.SelectedIndex = -1;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
            limpar();
        }

        protected void gdvClientes_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            try
            {
                ClientesNeg _ClienteNeg = new ClientesNeg();
                _ClienteNeg.excluir(Convert.ToInt32(gdvClientes.DataKeys[e.RowIndex].Value));
                CarregaGrid();
            }catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        protected void gdvClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClientesNeg _ClienteNeg = new ClientesNeg();
            ClientesMod _ClienteMod = new ClientesMod();
            _ClienteMod.iCodigoCliente = Convert.ToInt32(gdvClientes.SelectedDataKey.Value);
            try
            {
                foreach (ClientesMod lista in _ClienteNeg.listaClientes(_ClienteMod))
                {
                    lblCodigoCliente.Text = lista.iCodigoCliente.ToString();
                    txtDescricao.Text = lista.sDescricao.Trim();
                    txtCpfCnpj.Text = lista.sCpfCnpj.Trim();
                    txtEndereco.Text = lista.sEndereco.Trim();
                    txtNumero.Text = lista.sNumero.Trim();
                    txtCidade.Text = lista.sCidade.Trim();
                    txtUF.Text = lista.sUF.Trim();
                    txtCEP.Text = lista.sCEP.Trim();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            MultiView1.ActiveViewIndex = 1;
        }

        protected void gdvClientes_Sorting(object sender, System.Web.UI.WebControls.GridViewSortEventArgs e)
        {
            List<ClientesMod> listaGrid = new List<ClientesMod>();
            listaGrid = (List<ClientesMod>)Session["ListaGrid"];

            string _coluna = e.SortExpression;
            
            if(hidSortDirection.Value == "")
            {
                hidSortDirection.Value = e.SortDirection.ToString();
            }
            else
            {
                if(hidSortDirection.Value == SortDirection.Ascending.ToString())
                {
                    hidSortDirection.Value = SortDirection.Descending.ToString();
                }
                else
                {
                    hidSortDirection.Value = SortDirection.Ascending.ToString();
                }
            }
            
            if(e.SortExpression == "iCodigoCliente")
            {
                listaGrid.Sort(new OrderClientes(OrderClientes.SortType.iCodigoCliente, hidSortDirection.Value));
            }

            if(e.SortExpression == "sDescricao")
            {
                listaGrid.Sort(new OrderClientes(OrderClientes.SortType.sDescricao, hidSortDirection.Value));
            }

            gdvClientes.DataSource = listaGrid;
            gdvClientes.DataBind();
        }


        protected void gdvClientes_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            gdvClientes.PageIndex = e.NewPageIndex;
            gdvClientes.SelectedIndex = -1;
            CarregaGrid();
        }
    }
}