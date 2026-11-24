<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdministrarDireccion.aspx.cs" Inherits="TPC_Equipo2.AdministrarDireccion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView
        ID="dgvDireccion"
        runat="server"
        CssClass="table table-hover table-bordered align-middle"
        AutoGenerateColumns="false"
        GridLines="None"
        EmptyDataText="No tenés direcciones registradas.">

        <Columns>

            <asp:BoundField
                DataField="IdDireccion"
                HeaderText="ID"
                Visible="false" />

            <asp:BoundField
                DataField="IdCliente"
                HeaderText="Cliente"
                Visible="false" />

            <asp:BoundField
                DataField="Calle"
                HeaderText="Calle" />

            <asp:BoundField
                DataField="Numero"
                HeaderText="Número" />

            <asp:BoundField
                DataField="Localidad"
                HeaderText="Localidad" />

            <asp:BoundField
                DataField="Provincia"
                HeaderText="Provincia" />

            <asp:BoundField
                DataField="CodigoPostal"
                HeaderText="Código Postal" />

            <asp:TemplateField HeaderText="Observaciones">
                <ItemTemplate>
                    <%# string.IsNullOrWhiteSpace(Eval("Observacion")?.ToString()) ? "No tiene observación" : Eval("Observacion") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Eliminar">
                <ItemTemplate>
                    <asp:Button ID="btnEliminar" runat="server"
                        Text="Eliminar"
                        CssClass="btn btn-outline-danger btn-sm"
                        CommandName="EliminarTarjeta"
                        CommandArgument='<%# Eval("IdDireccion") %>'
                        OnClick="btnEliminar_Click" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>

    </asp:GridView>

    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn btn-primary" OnClick="btnAgregar_Click" />
    <asp:HyperLink ID="lnkCancelar" runat="server" Text="Volver" NavigateUrl="~/MiCuenta.aspx" CssClass="btn btn-outline-secondary" />


</asp:Content>
