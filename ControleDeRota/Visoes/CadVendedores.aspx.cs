using System;
using ControleDeRota.Modelos;
using ControleDeRota.Negocios;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace ControleDeRota.Visoes
{
    public partial class CadVendedores : System.Web.UI.Page
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
            VendedoresNeg _VendedorNeg = new VendedoresNeg();

            List<VendedoresMod> listaGrid = new List<VendedoresMod>();
            listaGrid = _VendedorNeg.listaVendedores();
            Session.Add("ListaGrid", listaGrid);
            gdvVendedores.DataSource = listaGrid;
            gdvVendedores.DataBind();
        }

        protected void btnGravar_Click(object sender, EventArgs e)
        {
            VendedoresNeg _VendedorNeg = new VendedoresNeg();
            VendedoresMod _VendedorMod = new VendedoresMod();

            if (!(lblCodigoVendedor.Text == string.Empty))
            {
                _VendedorMod.iCodigoVendedor = Convert.ToInt32(lblCodigoVendedor.Text);
            }
            _VendedorMod.sNome = txtNome.Text;
            _VendedorMod.sCpf = txtCpf.Text;
            _VendedorMod.sEndereco = txtEndereco.Text;
            _VendedorMod.sNumero = txtNumero.Text;
            _VendedorMod.sCidade = txtCidade.Text;
            _VendedorMod.sUF = txtUF.Text;
            _VendedorMod.sCEP = txtCEP.Text;

            _VendedorNeg.salvar(_VendedorMod);

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
            txtNome.Text = string.Empty;
            txtCpf.Text = string.Empty;
            txtEndereco.Text = string.Empty;
            txtNumero.Text = string.Empty;
            txtCidade.Text = string.Empty;
            txtUF.Text = string.Empty;
            txtCEP.Text = string.Empty;
            gdvVendedores.SelectedIndex = -1;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
            limpar();
        }

        protected void gdvVendedores_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                VendedoresNeg _VendedorNeg = new VendedoresNeg();
                _VendedorNeg.excluir(Convert.ToInt32(gdvVendedores.DataKeys[e.RowIndex].Value));
                CarregaGrid();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        protected void gdvVendedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            VendedoresNeg _VendedorNeg = new VendedoresNeg();
            VendedoresMod _VendedorMod = new VendedoresMod();
            _VendedorMod.iCodigoVendedor = Convert.ToInt32(gdvVendedores.SelectedDataKey.Value);
            try
            {
                foreach (VendedoresMod lista in _VendedorNeg.listaVendedores(_VendedorMod))
                {
                    lblCodigoVendedor.Text = lista.iCodigoVendedor.ToString();
                    txtNome.Text = lista.sNome.Trim();
                    txtCpf.Text = lista.sCpf.Trim();
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

        protected void gdvVendedores_Sorting(object sender, GridViewSortEventArgs e)
        {
            List<VendedoresMod> listaGrid = new List<VendedoresMod>();
            listaGrid = (List<VendedoresMod>)Session["ListaGrid"];

            string _coluna = e.SortExpression;

            if (hidSortDirection.Value == "")
            {
                hidSortDirection.Value = e.SortDirection.ToString();
            }
            else
            {
                if (hidSortDirection.Value == SortDirection.Ascending.ToString())
                {
                    hidSortDirection.Value = SortDirection.Descending.ToString();
                }
                else
                {
                    hidSortDirection.Value = SortDirection.Ascending.ToString();
                }
            }

            if (e.SortExpression == "iCodigoVendedor")
            {
                listaGrid.Sort(new OrderVendedores(OrderVendedores.SortType.iCodigoVendedor, hidSortDirection.Value));
            }

            if (e.SortExpression == "sNome")
            {
                listaGrid.Sort(new OrderVendedores(OrderVendedores.SortType.sNome, hidSortDirection.Value));
            }

            gdvVendedores.DataSource = listaGrid;
            gdvVendedores.DataBind();
        }

        protected void gdvVendedores_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvVendedores.PageIndex = e.NewPageIndex;
            gdvVendedores.SelectedIndex = -1;
            CarregaGrid();
        }
    }
}