<%@ Page Title="" Language="C#" MasterPageFile="~/Visoes/ControleDeRota.Master" AutoEventWireup="true" CodeBehind="ListaRota.aspx.cs" Inherits="ControleDeRota.Visoes.ListaRota" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblTitulo" runat="server" Text="Listagem de Rotas" CssClass="titulo"></asp:Label>
    <br />
    <br />
    <fieldset style="width: 96%">
        <legend class="conteudo">Listagem de Rotas</legend>
        <br />
        <asp:Label ID="lblRota" runat="server" Text="Rota: " CssClass="label"></asp:Label>
&nbsp;<asp:DropDownList ID="ddlRota" runat="server" CssClass="box" Width="420px" AutoPostBack="True" OnSelectedIndexChanged="ddlRota_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="lblDescricao" runat="server" CssClass="label" Text="Descrição: "></asp:Label>
&nbsp;<asp:Label ID="lblDescricaoValor" runat="server" CssClass="labelCinza"></asp:Label>
        <br />
        <asp:Label ID="lblVendedor" runat="server" CssClass="label" Text="Vendedor: "></asp:Label>
&nbsp;<asp:Label ID="lblVendedorValor" runat="server" CssClass="labelCinza"></asp:Label>
        <br />
        <br />
        <asp:GridView ID="gdvRotas" runat="server" AutoGenerateColumns="False" CssClass="boxEscuro" DataKeyNames="iCodigoClientesRotas" ForeColor="#333333" GridLines="None" Width="40%" PageSize="5">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="iSequencialRota" HeaderText="Sequencial" >
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="sCliente" HeaderText="Cliente" />
                        <asp:BoundField DataField="sEndereco" HeaderText="Endereço" />
                        <asp:BoundField DataField="sNumero" HeaderText="Número" />
                        <asp:BoundField DataField="sCidade" HeaderText="Cidade" />
                        <asp:BoundField DataField="sUF" HeaderText="UF" />
                        <asp:BoundField DataField="sCEP" HeaderText="CEP" />
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <EmptyDataTemplate>
                        <asp:Label ID="lblMensagem" runat="server" CssClass="label" Text="Não existem clientes cadastrados para esta rota."></asp:Label>
                    </EmptyDataTemplate>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                </asp:GridView>
        <br />
        <br />
    </fieldset>
</asp:Content>
