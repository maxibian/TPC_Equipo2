<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HistorialPedidos.aspx.cs" Inherits="TPC_Equipo2.HistorialPedidos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-4">

    <h3 class="mb-2">Historial de compras</h3>

    <p class="text-muted mb-4">
        Aquí podés consultar los productos que compraste
        y el estado de tus pedidos.
    </p>

    <hr />

    <div class="mt-4">

        <h5 class="mb-3">Mis compras</h5>

        <div class="table-responsive">

            <asp:GridView ID="dgvHistorial"
                runat="server"
                CssClass="table table-hover table-bordered align-middle"
                AutoGenerateColumns="false"
                EmptyDataText="Todavía no realizaste ninguna compra."
                GridLines="None">

                <Columns>

                    <asp:BoundField
                        DataField="Producto"
                        HeaderText="Producto" />

                    <asp:BoundField
                        DataField="Cantidad"
                        HeaderText="Cantidad" />

                    <asp:BoundField
                        DataField="Fecha"
                        HeaderText="Fecha de compra"
                        DataFormatString="{0:dd/MM/yyyy}" />

                    <asp:BoundField
                        DataField="Precio"
                        HeaderText="Precio"
                        DataFormatString="{0:C}" />

                    <asp:BoundField
                        DataField="Estado"
                        HeaderText="Estado" />

                </Columns>

            </asp:GridView>

        </div>

    </div>

</div>
</asp:Content>
