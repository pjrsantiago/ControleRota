<%@ Page Title="" Language="C#" MasterPageFile="~/Visoes/ControleDeRota.Master" AutoEventWireup="true" CodeBehind="CadRotas.aspx.cs" Inherits="ControleDeRota.Visoes.CadRotas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblTitulo" runat="server" Text="Cadastro de Rotas" CssClass="titulo"></asp:Label>
    <br />
    <br />
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
        <asp:View ID="View1" runat="server">
            <fieldset style="width: 96%">
                <legend class="conteudo">Listagem de Rotas</legend>
                <br />
                <asp:LinkButton ID="lnkNovo" runat="server" CssClass="label" OnClick="lnkNovo_Click">Nova Rota</asp:LinkButton>
                <br /><br />
                <asp:GridView ID="gdvRotas" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="boxEscuro" DataKeyNames="iCodigoRota" ForeColor="#333333" GridLines="None" Width="40%" AllowSorting="True" PageSize="5" OnPageIndexChanging="gdvRotas_PageIndexChanging" OnRowDeleting="gdvRotas_RowDeleting" OnSelectedIndexChanged="gdvRotas_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="iCodigoRota" HeaderText="Código" SortExpression="iCodigoRota" >
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="sDescricao" HeaderText="Descrição" SortExpression="sDescricao" />
                        <asp:BoundField DataField="sVendedor" HeaderText="Vendedor" SortExpression="sVendedor" >
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Imagens/edit.png" ToolTip="Editar / Inserir Clientes" CommandName="Select" />
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
                        <asp:Label ID="lblMensagem" runat="server" CssClass="label" Text="Não existem rotas cadastradas."></asp:Label>
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
                <legend class="conteudo">Cadastrar Rota</legend>
                <br />
                <asp:Label ID="lblDescricao" runat="server" Text="Descrição: " CssClass="label"></asp:Label>
                &nbsp;<asp:TextBox ID="txtDescricao" runat="server" Width="286px" CssClass="boxEscuro"></asp:TextBox>
                <asp:Label ID="lblCodRota" runat="server" Visible="False"></asp:Label>
                <br />
                <asp:Label ID="lblVendedor" runat="server" CssClass="label" Text="Vendedor: "></asp:Label>
                &nbsp;<asp:DropDownList ID="ddlVendedor" runat="server" CssClass="box" Width="289px">
                </asp:DropDownList>
                <br />
                <br />
                <asp:LinkButton ID="lnkInserirClientes" runat="server" CssClass="label" OnClick="lnkInserirClientes_Click" Visible="False">Inserir/movimentar clientes na rota</asp:LinkButton>
                <br />
                <br />
                <asp:Button ID="btnGravar" runat="server" CssClass="btn_beige" OnClick="btnGravar_Click" Text="Gravar" />
                &nbsp;<asp:Button ID="btnCancelar" runat="server" CssClass="btn_beige" OnClick="btnCancelar_Click" Text="Cancelar" />
                <br />
                <br />
            </fieldset>
        </asp:View>
        <asp:View ID="View3" runat="server">
            <fieldset style="width: 96%">
                <legend class="conteudo">Incluir Clientes na Rota</legend>
                <br />
                <asp:Label ID="lblCodigoRota" runat="server" Text="Código da rota: " CssClass="label"></asp:Label>
                &nbsp;<asp:Label ID="lblCodigoRotaValor" runat="server" CssClass="labelCinza"></asp:Label>
                <br />
                <asp:Label ID="lblDescricaoRota" runat="server" Text="Descrição: " CssClass="label"></asp:Label>
                &nbsp;<asp:Label ID="lblDescricaoRotaValor" runat="server" CssClass="labelCinza"></asp:Label>
                <br />
                <asp:Label ID="lblVendedorRota" runat="server" Text="Vendedor: " CssClass="label"></asp:Label>
                &nbsp;<asp:Label ID="lblVendedorRotaValor" runat="server" CssClass="labelCinza"></asp:Label>
                <br />
                <br />
                <asp:Label ID="lblCliente" runat="server" Text="Cliente a inserir: " CssClass="label"></asp:Label>
                &nbsp;<asp:DropDownList ID="ddlClientes" runat="server" Width="380px" CssClass="box">
                </asp:DropDownList>
                &nbsp;<asp:Button ID="btnInserirCliente" runat="server" Text="Inserir" CssClass="btn_beige" OnClick="btnInserirCliente_Click" />
                &nbsp;<asp:Label ID="lblCodClienteRota" runat="server" Visible="False"></asp:Label>
                <br />
                <br />
                <asp:GridView ID="gdvClientesRotas" runat="server" AllowPaging="False" AutoGenerateColumns="False" CssClass="boxEscuro" DataKeyNames="iCodigoClientesRotas" ForeColor="#333333" GridLines="None" Width="40%" PageSize="5" OnRowDeleting="gdvClientesRotas_RowDeleting" OnRowCommand="gdvClientesRotas_RowCommand">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="iSequencialRota" HeaderText="Sequencial" >
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="sCliente" HeaderText="Cliente" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Imagens/delete.png" ToolTip="Excluir" CommandName="Delete" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:ButtonField ButtonType="Image" CommandName="Up" ImageUrl="~/Imagens/icone_up.GIF" Text="Up" />
                        <asp:ButtonField ButtonType="Image" CommandName="Down" ImageUrl="~/Imagens/icone_down.gif" Text="Down" />
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
                <asp:LinkButton ID="lnkVoltar" runat="server" CssClass="label" OnClick="lnkVoltar_Click">Voltar</asp:LinkButton>
                <br />
                <br />
            </fieldset>
        </asp:View>
    </asp:MultiView>
</asp:Content>
