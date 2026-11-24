<%@ page title="" language="C#" masterpagefile="~/Site.Master" autoeventwireup="true" codebehind="DetalleCompra.aspx.cs" inherits="TPC_Equipo2.DetalleCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="container mt-4">

        <h3 class="mb-2">Detalle</h3>

        <p class="text-muted mb-4">
            Aquí podés consultar los productos que compraste
        </p>

        <div class="mt-4">

            <h5 class="mb-3">Mis compras</h5>

            <div class="table-responsive">

                <asp:GridView ID="dgvDetalle"
                    runat="server"
                    CssClass="table table-hover table-bordered align-middle"
                    AutoGenerateColumns="false"
                    GridLines="None">

                    <columns>
                        <asp:BoundField
                            DataField="IdDetalleVenta"
                            HeaderText="DetalleVenta"
                            Visible="false" />

                        <asp:BoundField
                            DataField="IdVenta"
                            HeaderText="Venta"
                            Visible="false" />

                        <asp:TemplateField HeaderText="Producto">
                            <itemtemplate>
                                <%# Eval("Producto.Nombre") %>
                            </itemtemplate>
                        </asp:TemplateField>

                        <asp:BoundField
                            DataField="Cantidad"
                            HeaderText="Cantidad" />

                        <asp:BoundField
                            DataField="PrecioUnitario"
                            HeaderText="Precio unidad" />

                    </columns>

                </asp:GridView>

                <div class="d-flex gap-2 mt-3">
                    <asp:HyperLink ID="HyperLink1" runat="server"
                        Text="Volver"
                        NavigateUrl="~/HistorialPedidos.aspx"
                        CssClass="btn btn-outline-secondary" />
                </div>

            </div>
        </div>

    </div>

</asp:Content>
