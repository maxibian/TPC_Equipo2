<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConfirmarCompra.aspx.cs" Inherits="TPC_Equipo2.ConfirmarCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Confirmar compra</h2>

    <asp:Label ID="lblCarrito" runat="server" />

    <div class="mt-3">
        <asp:HyperLink ID="lnkVolverCarrito" runat="server" NavigateUrl="~/Carrito.aspx" Text="Volver al carrito" CssClass="btn btn-outline-secondary me-2" />

        <asp:HyperLink ID="lnkVolverCatalogo" runat="server" NavigateUrl="~/Inicio.aspx" Text="Seguir comprando" CssClass="btn btn-outline-primary" />
    </div>


    <div class="row g-4 mt-2 align-items-start">

        <div class="col-12 col-lg-5 order-2 order-lg-2">

            <div class="card shadow-sm border-0">

                <div class="card-body">

                    <h5 class="card-title fw-bold mb-2">Resumen de compra
                    </h5>

                    <p class="text-muted small mb-3">
                        Revisá los productos antes de confirmar tu pedido.
                    </p>


                    <div class="table-responsive">

                        <asp:GridView ID="gvResumen" runat="server" AutoGenerateColumns="false" GridLines="None" CssClass="table table-hover align-middle mb-0">

                            <Columns>

                                <asp:TemplateField HeaderText="Producto">
                                    <ItemTemplate>

                                        <div class="fw-semibold">
                                            <%# Eval("Producto.Nombre") %>
                                        </div>

                                        <div class="text-muted small">
                                            Cant.: <%# Eval("Cantidad") %>
                                            · Unit.: $<%# Eval("PrecioUnitario", "{0:N2}") %>
                                        </div>

                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Importe" HeaderStyle-CssClass="text-end" ItemStyle-CssClass="text-end text-nowrap">

                                    <ItemTemplate>
                                        $<%# Eval("Subtotal", "{0:N2}") %>
                                    </ItemTemplate>

                                </asp:TemplateField>

                            </Columns>

                        </asp:GridView>

                    </div>

                    <div class="bg-light rounded-3 p-3 mt-3">

                        <div class="d-flex justify-content-between mb-3 gap-2">

                            <span class="text-muted">Subtotal de productos
                            </span>

                            <span class="fw-semibold">$<asp:Label ID="lblSubtotal" runat="server" />
                            </span>

                        </div>

                        <div class="d-flex justify-content-between mb-3 gap-2">

                            <span class="text-muted">Costo de entrega
                            </span>

                            <span class="fw-semibold">
                                <asp:Label ID="lblCostoEntrega" runat="server" />
                            </span>

                        </div>

                        <div class="d-flex justify-content-between align-items-center border-top pt-3 gap-2">

                            <strong>Total a pagar</strong>

                            <span class="fs-4 fw-bold text-primary">
                                <asp:Label ID="lblTotal" runat="server" />
                            </span>

                        </div>

                    </div>

                    <div class="d-grid mt-4">

                        <asp:Button ID="btnConfirmarCompra" runat="server" Text="Confirmar compra" CssClass="btn btn-primary btn-lg w-100" Enabled="false" OnClick="btnConfirmarCompra_Click" />

                    </div>
                    <asp:Label ID="lblMensaje" runat="server" CssClass="d-block mt-3 text-danger fw-semibold" />

                </div>
            </div>



        </div>

        <div class="col-12 col-lg-7 order-1 order-lg-1">

            <div class="card shadow-sm border-0">

                <div class="card-body">

                    <h5 class="card-title fw-bold mb-2">Datos de la compra
                    </h5>

                    <p class="text-muted small mb-4">
                        Completá los siguientes pasos para finalizar tu pedido.
                    </p>

                    <div class="mb-4 pb-3 border-bottom">

                        <div class="d-flex align-items-center gap-2 mb-2">
                            <span class="badge bg-primary rounded-pill">1</span>
                            <h6 class="fw-semibold mb-0">Método de pago
                             </h6>
                        </div>

                        <p class="text-muted small mb-2">
                            Seleccioná cómo querés pagar tu pedido.
   
                        </p>

                        <asp:DropDownList ID="ddlFormaPago" runat="server" CssClass="form-select" />

                    </div>

                    <div class="mb-3">

                        <div class="d-flex align-items-center gap-2 mb-2">
                            <span class="badge bg-primary rounded-pill">2</span>
                            <h6 class="fw-semibold mb-0">Método de entrega
                            </h6>
                        </div>

                        <p class="text-muted small mb-2">
                            Elegí cómo querés recibir tus productos.
   
                        </p>

                        <asp:DropDownList
                            ID="ddlFormaEntrega"
                            runat="server"
                            CssClass="form-select"
                            AutoPostBack="true"
                            OnSelectedIndexChanged="ddlFormaEntrega_SelectedIndexChanged" />

                        <p class="text-muted small mt-2 mb-0">
                            El costo de entrega se actualizará en el resumen
                            de tu compra.
   
                        </p>


                        <asp:Panel ID="pnlDireccion" runat="server" Visible="false" CssClass="bg-light border rounded-3 p-3 mt-4">

                            <div class="d-flex align-items-center gap-2 mb-2">
                                <span class="badge bg-primary rounded-pill">3</span>
                                <h6 class="fw-semibold mb-0">Dirección de entrega
                                </h6>
                            </div>

                            <p class="text-muted small mb-3">
                                Seleccioná una dirección guardada o ingresá una nueva.
                            </p>


                            <div class="mb-3">
                                <asp:Label ID="lblDireccion" runat="server" Text="Dirección de entrega" AssociatedControlID="ddlDireccion" CssClass="form-label" />

                                <asp:DropDownList ID="ddlDireccion" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlDireccion_SelectedIndexChanged" />


                                <asp:Panel ID="pnlNuevaDireccion" runat="server" Visible="false" CssClass="mt-4 pt-3 border-top">

                                    <h6 class="fw-semibold mb-2">Nueva dirección</h6>

                                    <p class="text-muted small mb-3">
                                        Completá los datos de tu domicilio.
                                    </p>

                                    <div class="row">

                                        <div class="col-md-6 mb-3">
                                            <label class="form-label">Calle</label>
                                            <asp:TextBox ID="txtCalle" runat="server" CssClass="form-control" MaxLength="100" />
                                        </div>

                                        <div class="col-md-6 mb-3">
                                            <label class="form-label">Número</label>
                                            <asp:TextBox ID="txtNumero" runat="server" CssClass="form-control" TextMode="Number" />
                                        </div>

                                        <div class="col-md-6 mb-3">
                                            <label class="form-label">Localidad</label>
                                            <asp:TextBox ID="txtLocalidad" runat="server" CssClass="form-control" MaxLength="50" />
                                        </div>

                                        <div class="col-md-6 mb-3">
                                            <label class="form-label">Provincia</label>
                                            <asp:TextBox ID="txtProvincia" runat="server" CssClass="form-control" MaxLength="50" />
                                        </div>

                                        <div class="col-md-6 mb-3">
                                            <label class="form-label">Código postal</label>
                                            <asp:TextBox ID="txtCodigoPostal" runat="server" CssClass="form-control" MaxLength="10" />
                                        </div>

                                        <div class="col-12 mb-3">
                                            <label class="form-label">
                                                Observaciones (opcional)
           
                                            </label>
                                            <asp:TextBox ID="txtObservacion" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" MaxLength="200" />
                                        </div>

                                    </div>

                                </asp:Panel>

                            </div>

                        </asp:Panel>

                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

