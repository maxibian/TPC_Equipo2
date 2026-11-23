<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdministrarTarjetas.aspx.cs" Inherits="TPC_Equipo2.AdministrarTarjetas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

 <div class="table-responsive">
    <asp:GridView ID="dgvTarjetas" runat="server"
        AutoGenerateColumns="False"
        CssClass="table table-hover align-middle"
        GridLines="None"
        EmptyDataText="No tenés tarjetas registradas.">

        <Columns>

            <asp:BoundField DataField="TipoTarjeta.NombreTipoTarjeta"
                HeaderText="Tipo" />

            <asp:BoundField DataField="NombreYApellidoTitular"
                HeaderText="Titular" />

            <asp:BoundField DataField="NumeroTarjeta"
                HeaderText="Número"
                DataFormatString="{0}" />

            <asp:BoundField DataField="FechaVencimiento"
                HeaderText="Vencimiento"
                DataFormatString="{0:MM/yyyy}" />

            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>
                    <asp:Button ID="btnEliminar" runat="server"
                        Text="Eliminar"
                        CssClass="btn btn-outline-danger btn-sm"
                        CommandName="EliminarTarjeta"
                        CommandArgument='<%# Eval("IdTarjeta") %>'
                        OnClick="btnEliminar_Click" />
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
    </asp:GridView>

    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" CssClass="btn btn-primary" />
    <asp:HyperLink ID="lnkVolver" runat="server" Text="Volver" NavigateUrl="~/MiCuenta.aspx" CssClass="btn btn-outline-secondary" />
    <asp:Label ID="lblRespuesta" runat="server" Text=""></asp:Label>
</div>
</asp:Content>
