<%@ Page Title="" Language="C#" MasterPageFile="~/Visoes/ControleDeRota.Master" AutoEventWireup="true" CodeBehind="CadVendedores.aspx.cs" Inherits="ControleDeRota.Visoes.CadVendedores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblTitulo" runat="server" Text="Cadastro de Vendedores" CssClass="titulo"></asp:Label>
    <br />
    <br />
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
        <asp:View ID="View1" runat="server">
            <fieldset style="width: 96%">
                <legend class="conteudo">Listagem de Vendedores</legend>
                <br />
                <asp:LinkButton ID="lnkNovo" runat="server" CssClass="label" OnClick="lnkNovo_Click">Novo Vendedor</asp:LinkButton>
                <br /><br />
                <asp:GridView ID="gdvVendedores" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="boxEscuro" DataKeyNames="iCodigoVendedor" ForeColor="#333333" GridLines="None" Width="40%" AllowSorting="True" OnRowDeleting="gdvVendedores_RowDeleting" OnSelectedIndexChanged="gdvVendedores_SelectedIndexChanged" OnSorting="gdvVendedores_Sorting" PageSize="5" OnPageIndexChanging="gdvVendedores_PageIndexChanging">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="iCodigoVendedor" HeaderText="Código" SortExpression="iCodigoVendedor" >
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="sNome" HeaderText="Nome" SortExpression="sNome" />
                        <asp:BoundField DataField="sCpf" HeaderText="CPF" >
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Imagens/edit.png" ToolTip="Editar" CommandName="Select" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Imagens/delete.png" ToolTip="Excluir" CommandName="Delete" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <EmptyDataTemplate>
                        <asp:Label ID="lblMensagem" runat="server" CssClass="label" Text="Não existem vendedores cadastrados."></asp:Label>
                    </EmptyDataTemplate>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                </asp:GridView>
                <input id="hidSortDirection" type="hidden" name="hidSortDirection" runat="server" />
            </fieldset>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <fieldset style="width: 96%">
                <legend class="conteudo">Cadastrar Vendedor</legend>
                <br />
                <asp:Label ID="lblNome" runat="server" Text="Nome: " CssClass="label"></asp:Label>
                &nbsp;<asp:TextBox ID="txtNome" runat="server" Width="286px" CssClass="boxEscuro"></asp:TextBox>
                <asp:Label ID="lblCodigoVendedor" runat="server" Visible="False"></asp:Label>
                <br />
                <asp:Label ID="lblCpf" runat="server" Text="CPF: " CssClass="label"></asp:Label>
                &nbsp;<asp:TextBox ID="txtCpf" runat="server" CssClass="boxEscuro"></asp:TextBox>
                <br />
                <asp:Label ID="lblEndereco" runat="server" Text="Endereço: " CssClass="label"></asp:Label>
                &nbsp;<asp:TextBox ID="txtEndereco" runat="server" Width="293px" CssClass="boxEscuro"></asp:TextBox>
                &nbsp;<asp:Label ID="lblNumero" runat="server" Text="Número: " CssClass="label"></asp:Label>
                &nbsp;<asp:TextBox ID="txtNumero" runat="server" CssClass="boxEscuro"></asp:TextBox>
                <br />
                <asp:Label ID="lblCidade" runat="server" Text="Cidade: " CssClass="label"></asp:Label>
                &nbsp;<asp:TextBox ID="txtCidade" runat="server" Width="227px" CssClass="boxEscuro"></asp:TextBox>
                &nbsp;<asp:Label ID="lblUF" runat="server" Text="UF: " CssClass="label"></asp:Label>
                &nbsp;<asp:TextBox ID="txtUF" runat="server" Width="43px" CssClass="boxEscuro"></asp:TextBox>
                <br />
                <asp:Label ID="lblCEP" runat="server" Text="CEP: " CssClass="label"></asp:Label>
                &nbsp;<asp:TextBox ID="txtCEP" runat="server" CssClass="boxEscuro"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="btnGravar" runat="server" Text="Gravar" OnClick="btnGravar_Click" CssClass="btn_beige" />
                &nbsp;<asp:Button ID="btnCancelar" runat="server" CssClass="btn_beige" OnClick="btnCancelar_Click" Text="Cancelar" />
                <br />
                <br />
            </fieldset>
        </asp:View>
    </asp:MultiView>
</asp:Content>
