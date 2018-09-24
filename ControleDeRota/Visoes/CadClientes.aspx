<%@ Page Title="" Language="C#" MasterPageFile="~/Visoes/ControleDeRota.Master" AutoEventWireup="true" CodeBehind="CadClientes.aspx.cs" Inherits="ControleDeRota.Visoes.CadClientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblTitulo" runat="server" Text="Cadastro de Clientes" CssClass="titulo"></asp:Label>
    <br />
    <br />
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
        <asp:View ID="View1" runat="server">
            <fieldset style="width: 96%">
                <legend class="conteudo">Listagem de Clientes</legend>
                <br />
                <asp:LinkButton ID="lnkNovo" runat="server" CssClass="label" OnClick="lnkNovo_Click">Novo Cliente</asp:LinkButton>
                <br /><br />
                <asp:GridView ID="gdvClientes" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="boxEscuro" DataKeyNames="iCodigoCliente" ForeColor="#333333" GridLines="None" Width="40%" AllowSorting="True" OnRowDeleting="gdvClientes_RowDeleting" OnSelectedIndexChanged="gdvClientes_SelectedIndexChanged" OnSorting="gdvClientes_Sorting" PageSize="5" OnPageIndexChanging="gdvClientes_PageIndexChanging">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="iCodigoCliente" HeaderText="Código" SortExpression="iCodigoCliente" >
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="sDescricao" HeaderText="Descrição" SortExpression="sDescricao" />
                        <asp:BoundField DataField="sCpfCnpj" HeaderText="CPF / CNPJ" >
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
                        <asp:Label ID="lblMensagem" runat="server" CssClass="label" Text="Não existem clientes cadastrados."></asp:Label>
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
                <legend class="conteudo">Cadastrar Cliente</legend>
                <br />
                <asp:Label ID="lblDescricao" runat="server" Text="Descrição: " CssClass="label"></asp:Label>
                &nbsp;<asp:TextBox ID="txtDescricao" runat="server" Width="286px" CssClass="boxEscuro"></asp:TextBox>
                <asp:Label ID="lblCodigoCliente" runat="server" Visible="False"></asp:Label>
                <br />
                <asp:Label ID="lblCpfCnpj" runat="server" Text="CPF / CNPJ: " CssClass="label"></asp:Label>
                &nbsp;<asp:TextBox ID="txtCpfCnpj" runat="server" CssClass="boxEscuro"></asp:TextBox>
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
