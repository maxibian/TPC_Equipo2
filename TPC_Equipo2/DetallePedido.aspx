<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetallePedido.aspx.cs" Inherits="TPC_Equipo2.DetallePedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="mt-4 mb-4">
        <h2>Detalle de venta</h2>
        <p class="text-muted">
            Información del pedido seleccionado.
        </p>
    </div>


    <div class="card shadow-sm mb-4">
        <div class="card-body">

            <h5 class="card-title mb-3">Información general
            </h5>

            <div class="row g-3">

                <div class="col-md-6">
                    <strong>Número de venta:</strong>
                    <asp:Label ID="lblIdVenta" runat="server" />
                </div>

                <div class="col-md-6">
                    <strong>Fecha:</strong>
                    <asp:Label ID="lblFecha" runat="server" />
                </div>

                <div class="col-md-6">
                    <strong>Cliente:</strong>
                    <asp:Label ID="lblCliente" runat="server" />
                </div>

                <div class="col-md-6">
                    <strong>Estado:</strong>
                    <asp:Label ID="lblEstado" runat="server" />
                </div>

                <div class="col-md-6">
                    <strong>Forma de pago:</strong>
                    <asp:Label ID="lblFormaPago" runat="server" />
                </div>

                <div class="col-md-6">
                    <strong>Forma de entrega:</strong>
                    <asp:Label ID="lblFormaEntrega" runat="server" />
                </div>

            </div>
        </div>
    </div>


    <div class="card shadow-sm mb-4">
        <div class="card-body">

            <h5 class="card-title mb-3">Productos comprados
            </h5>

            <div class="table-responsive">
                <asp:GridView ID="gvDetalles" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-hover align-middle" GridLines="None" EmptyDataText="No hay productos registrados.">

                    <Columns>

                        <asp:TemplateField HeaderText="Producto">
                            <ItemTemplate>
                                <%# Eval("Producto.Nombre") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />

                        <asp:BoundField DataField="PrecioUnitario" HeaderText="Precio unitario" DataFormatString="{0:N2}" />

                        <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" DataFormatString="{0:N2}" />

                    </Columns>

                </asp:GridView>
            </div>


            <div class="border-top pt-3 mt-3">

                <div class="d-flex justify-content-between mb-2">
                    <span>Subtotal de productos:</span>
                    <span>$<asp:Label ID="lblSubtotal" runat="server" />
                    </span>
                </div>

                <div class="d-flex justify-content-between mb-2">
                    <span>Costo de entrega:</span>
                    <span>$<asp:Label ID="lblCostoEntrega" runat="server" />
                    </span>
                </div>

                <div class="d-flex justify-content-between align-items-center border-top pt-3 mt-3">
                    <strong>Total de la venta:</strong>
                    <h4 class="fw-bold text-primary mb-0">$<asp:Label ID="lblTotal" runat="server" />
                    </h4>
                </div>

            </div>


        </div>
    </div>


    <div class="card shadow-sm mb-4">
        <div class="card-body">

            <h5 class="card-title mb-3">Gestión del pedido
            </h5>

            <div class="mb-3">
                <label class="form-label">
                    Estado del pedido
                </label>

                <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged" />
            </div>

            <div class="mb-3">
                <label class="form-label">
                    Código de seguimiento
                </label>

                <asp:TextBox ID="txtCodigoSeguimiento" runat="server" CssClass="form-control" MaxLength="100" placeholder="Ej.: AR123456789" />

                <div class="form-text">
                    El código de seguimiento se habilita al seleccionar
                    el estado "Enviado".
                </div>
            </div>


            <div class="mb-3">
                <label class="form-label">
                    Observaciones internas
                </label>

                <asp:TextBox ID="txtObservaciones" runat="server" TextMode="MultiLine" Rows="3" MaxLength="500" CssClass="form-control" />
            </div>

            <div class="d-flex justify-content-end gap-2">

                <a href="AdminVentas.aspx" class="btn btn-outline-secondary">Volver a ventas</a>

                <asp:Button ID="btnGuardarCambios" runat="server" Text="Guardar cambios" CssClass="btn btn-primary" OnClick="btnGuardarCambios_Click" />

            </div>

            <div class="d-flex justify-content-end">
                <asp:Label ID="lblMensaje" runat="server" />
            </div>

        </div>
    </div>




</asp:Content>
