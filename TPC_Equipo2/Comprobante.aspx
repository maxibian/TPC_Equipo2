<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Comprobante.aspx.cs" Inherits="TPC_Equipo2.Comprobante" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="pnlComprobante" runat="server" CssClass="container py-5">

        <div class="card border-0 shadow-sm mx-auto"
            style="max-width: 950px; border-radius: 15px;">

            <div class="card-body p-4 p-md-5">

                <!-- ENCABEZADO -->
                <div class="text-center mb-4">
                    <h4 class="fw-bold mt-3">Comprobante de compra</h4>
                    <span class="badge bg-success mt-2">Compra realizada</span>
                </div>

                <hr />

                <!-- INFORMACIÓN DE LA VENTA -->
                <div class="bg-light rounded-3 p-4 mb-4">
                    <div class="row g-3">

                        <div class="col-md-4">
                            <small class="text-muted">Número de venta</small>
                            <h4 class="fw-bold text-primary">#<asp:Label ID="lblIdVenta" runat="server" />
                            </h4>
                        </div>

                        <div class="col-md-4">
                            <small class="text-muted">Fecha de compra</small>
                            <h6 class="fw-semibold">
                                <asp:Label ID="lblFecha" runat="server" />
                            </h6>
                        </div>

                        <div class="col-md-4">
                            <small class="text-muted">Cliente</small>
                            <h6 class="fw-semibold">
                                <asp:Label ID="lblCliente" runat="server" />
                            </h6>
                        </div>

                    </div>
                </div>

                <!-- PRODUCTOS -->
                <h5 class="fw-bold mb-3">Detalle de productos</h5>

                <div class="table-responsive">

                    <asp:GridView ID="dgvComprobante"
                        runat="server"
                        AutoGenerateColumns="false"
                        CssClass="table table-bordered table-hover align-middle"
                        GridLines="None"
                        EmptyDataText="No hay productos para mostrar.">

                        <Columns>

                            <asp:TemplateField HeaderText="Producto">
                                <ItemTemplate>
                                    <%# Eval("Producto.Nombre") %>
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

                <!-- TOTAL -->
                <div class="row justify-content-end mt-4">
                    <div class="col-md-5">

                        <div class="bg-light rounded-3 p-3">
                            <div class="d-flex justify-content-between
                                    align-items-center">

                                <h4 class="fw-bold mb-0">TOTAL</h4>

                                <h3 class="fw-bold text-primary mb-0">
                                    <asp:Label ID="lblTotal" runat="server" />
                                </h3>

                            </div>
                        </div>

                    </div>
                </div>

                <!-- PIE -->
                <div class="text-center mt-5">

                    <i class="bi bi-check-circle-fill text-success"
                        style="font-size: 45px;"></i>

                    <h4 class="fw-bold mt-3">¡Gracias por tu compra!
                </h4>

                    <p class="text-muted">
                        Tu compra fue registrada correctamente.
               
                    </p>

                    <asp:HyperLink
                        ID="hlInicio"
                        runat="server"
                        NavigateUrl="~/Inicio.aspx"
                        CssClass="btn btn-primary px-4">

                    Volver al inicio

                </asp:HyperLink>

                </div>

            </div>
        </div>

    </asp:Panel>


</asp:Content>
