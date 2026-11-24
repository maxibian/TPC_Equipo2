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
                            DataField="IdVenta"
                            HeaderText="Pedido" />

                        <asp:BoundField
                            DataField="Fecha"
                            HeaderText="Fecha"
                            DataFormatString="{0:dd/MM/yyyy}" />

                        <asp:BoundField
                            DataField="VentaTotal"
                            HeaderText="Total"
                            DataFormatString="{0:C}" />

                        <asp:BoundField
                            DataField="EstadoVenta.Nombre"
                            HeaderText="Estado" />

                        <asp:TemplateField HeaderText="Acciones">
                            <ItemTemplate>
                                <asp:LinkButton
                                    ID="btnDetalle"
                                    runat="server"
                                    Text="Ver detalle"
                                    CssClass="btn btn-outline-primary btn-sm"
                                    CommandArgument='<%# Eval("IdVenta") %>'
                                    OnClick="btnDetalle_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>

                </asp:GridView>

                <asp:HyperLink ID="lnkAgregar" runat="server" Text="Comprar" NavigateUrl="~/Inicio.aspx" CssClass="btn btn-primary" />
                <asp:HyperLink ID="lnkCancelar" runat="server" Text="Volver" NavigateUrl="~/MiCuenta.aspx" CssClass="btn btn-outline-secondary" />

            </div>
        </div>

    </div>
</asp:Content>
