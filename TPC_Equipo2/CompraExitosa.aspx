<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CompraExitosa.aspx.cs" Inherits="TPC_Equipo2.CompraExitosa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container py-5" style="max-width: 960px;">

        <asp:Label ID="lblMensaje" runat="server"
            CssClass="d-block text-danger mb-3" />

        <asp:Panel ID="pnlComprobante" runat="server" Visible="false">

            <div class="text-center mb-4">

                <div class="d-inline-flex align-items-center justify-content-center rounded-circle bg-success bg-opacity-10 text-success mb-3" style="width: 72px; height: 72px; font-size: 2.25rem;">
                    ✓              
                </div>

                <h2 class="fw-bold">¡Tu pedido fue registrado!</h2>

                <p class="text-muted">
                    Recibimos tu pedido correctamente.
                A continuación podés consultar sus datos.
            
                </p>

            </div>

            <div class="card border-0 shadow-sm rounded-3 mb-4">
                <div class="card-body p-4">

                    <div class="d-flex flex-wrap justify-content-between align-items-center gap-3 mb-4">

                        <div>
                            <p class="text-muted small mb-1">
                                NÚMERO DE PEDIDO
                       
                            </p>

                            <h3 class="fw-bold mb-0">#<asp:Label ID="lblIdVenta" runat="server" />
                            </h3>
                        </div>

                        <span class="badge bg-secondary rounded-pill px-3 py-2">Estado:
                       
                        <asp:Label ID="lblEstado" runat="server" />
                        </span>

                    </div>

                    <div class="row g-3">

                        <div class="col-md-4">
                            <p class="text-muted small mb-1">
                                Fecha de compra
                       
                            </p>

                            <span class="fw-semibold">
                                <asp:Label ID="lblFecha" runat="server" />
                            </span>
                        </div>

                        <div class="col-md-4">
                            <p class="text-muted small mb-1">
                                Forma de pago
                       
                            </p>

                            <span class="fw-semibold">
                                <asp:Label ID="lblFormaPago" runat="server" />
                            </span>
                        </div>

                        <div class="col-md-4">
                            <p class="text-muted small mb-1">
                                Forma de entrega
                       
                            </p>

                            <span class="fw-semibold">
                                <asp:Label ID="lblFormaEntrega" runat="server" />
                            </span>
                        </div>

                    </div>
                </div>
            </div>

            <asp:Panel ID="pnlSeguimiento" runat="server" Visible="false" CssClass="card border-0 shadow-sm rounded-3 mb-4">

                <div class="card-body p-4">

                    <h5 class="fw-semibold mb-3">Seguimiento del pedido
                    </h5>

                    <p class="text-muted mb-2">
                        Tu pedido tiene un código de seguimiento asignado.       
                    </p>

                    <div class="alert alert-info mb-0">

                        <strong>Código de seguimiento:</strong>

                        <asp:Label ID="lblCodigoSeguimiento" runat="server" />

                    </div>
                </div>

            </asp:Panel>


            <div class="card border-0 shadow-sm rounded-3 mb-4">
                <div class="card-body p-4">

                    <h4 class="fw-semibold mb-3">Productos del pedido
                    </h4>

                    <div class="table-responsive">

                        <asp:GridView ID="gvDetalles" runat="server" AutoGenerateColumns="false" GridLines="None" CssClass="table table-striped table-hover align-middle">

                            <Columns>

                                <asp:TemplateField HeaderText="Producto">
                                    <ItemTemplate>
                                        <%#: Eval("Producto.Nombre") %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />

                                <asp:BoundField DataField="PrecioUnitario" HeaderText="Precio unitario" DataFormatString="${0:N2}" HeaderStyle-CssClass="text-end" ItemStyle-CssClass="text-end" />

                                <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" DataFormatString="${0:N2}" HeaderStyle-CssClass="text-end" ItemStyle-CssClass="text-end" />

                            </Columns>

                        </asp:GridView>

                    </div>

                    <div class="border-top pt-3 mt-3">

                        <div class="d-flex justify-content-between mb-2">
                            <span class="text-muted">Subtotal de productos:
                            </span>

                            <span>$<asp:Label ID="lblSubtotal" runat="server" />
                            </span>
                        </div>

                        <div class="d-flex justify-content-between mb-2">
                            <span class="text-muted">Costo de entrega:
                            </span>

                            <span>$<asp:Label ID="lblCostoEntrega" runat="server" />
                            </span>
                        </div>

                        <div class="d-flex justify-content-between align-items-center border-top pt-3 mt-3">

                            <strong>Total del pedido:</strong>

                            <h3 class="fw-bold text-primary mb-0">$<asp:Label ID="lblTotal" runat="server" />
                            </h3>

                        </div>

                    </div>


                </div>
            </div>

            <div class="alert alert-light border mb-4">

                <strong>¿Qué sigue?</strong>

                <p class="mb-0 mt-2">
                    Tu pedido fue registrado correctamente.
                Podrás consultar su estado a medida que
                avance el proceso de preparación y entrega.
           
                </p>

            </div>

        </asp:Panel>

        <div class="text-center">

            <a href="Inicio.aspx" class="btn btn-primary px-4 py-2">Volver al catálogo
            </a>

        </div>

    </div>

</asp:Content>
