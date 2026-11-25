<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleCompra.aspx.cs" Inherits="TPC_Equipo2.DetalleCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


 <div class="container py-4">

    <!-- ENCABEZADO -->
    <div class="mb-4">
        <h3 class="fw-bold mb-1">Detalle de compra</h3>
        <p class="text-muted mb-0">
            Aquí podés consultar los productos que compraste.
        </p>
    </div>

    <!-- TARJETA PRINCIPAL -->
    <div class="card border-0 shadow-sm">

        <div class="card-body p-4">

            <!-- TITULO DE LA TABLA -->
            <div class="d-flex justify-content-between
                        align-items-center mb-3">

                <div>
                    <h5 class="fw-bold mb-1">Productos comprados</h5>
                    <small class="text-muted">
                        Detalle de los artículos de tu pedido
                    </small>
                </div>

            </div>

            <!-- GRIDVIEW -->
            <div class="table-responsive">

                <asp:GridView ID="dgvDetalle"
                    runat="server"
                    CssClass="table table-hover align-middle mb-0"
                    AutoGenerateColumns="false"
                    GridLines="None"
                    HeaderStyle-CssClass="table-light">

                    <Columns>

                        <asp:BoundField
                            DataField="IdDetalleVenta"
                            Visible="false" />

                        <asp:BoundField
                            DataField="IdVenta"
                            Visible="false" />

                        <asp:TemplateField HeaderText="Producto">
                            <ItemTemplate>
                                <span class="fw-semibold">
                                    <%# Eval("Producto.Nombre") %>
                                </span>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField
                            DataField="Cantidad"
                            HeaderText="Cantidad" />

                        <asp:BoundField
                            DataField="PrecioUnitario"
                            HeaderText="Precio unitario"
                            DataFormatString="{0:C2}" />

                    </Columns>

                </asp:GridView>

            </div>

            <hr class="my-4" />

            <!-- BOTONES -->
            <div class="d-flex justify-content-between
                        align-items-center flex-wrap gap-2">

                <asp:HyperLink
                    ID="HyperLink1"
                    runat="server"
                    Text="Volver"
                    NavigateUrl="~/HistorialPedidos.aspx"
                    CssClass="btn btn-outline-secondary px-4" />

                <asp:HyperLink
                    ID="hlComprobante"
                    runat="server"
                    CssClass="btn btn-primary px-4">

                    <i class="bi bi-receipt me-2"></i>
                    Ver comprobante

                </asp:HyperLink>

            </div>

        </div>
    </div>

</div>

</asp:Content>
