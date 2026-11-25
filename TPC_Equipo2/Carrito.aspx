<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="TPC_Equipo2.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="py-4">

        <div class="mb-4">
            <h2 class="fw-bold mb-2">Mi carrito</h2>

            <p class="text-muted">
                Revisá los productos antes de finalizar tu compra.     
            </p>
        </div>

        <asp:Panel ID="pnlCarritoVacio" runat="server" Visible="false" CssClass="card shadow-sm border-0">

            <div class="card-body text-center p-5">

                <i class="bi bi-cart-x display-4 text-secondary d-block mb-3"></i>

                <asp:Label ID="lblVacio" runat="server" CssClass="d-block fs-4 fw-bold mb-2" />

                <p class="text-muted mb-4">
                    Todavía no agregaste productos al carrito.
            Explorá nuestro catálogo y encontrá algo que te guste.    
                </p>

                <a runat="server" href="~/Inicio" class="btn btn-primary btn-lg px-4">Explorar productos
                </a>
            </div>

        </asp:Panel>


        <asp:Panel ID="pnlCarritoConProductos" runat="server" CssClass="row g-4 align-items-start">

            <div class="col-12 col-lg-8">

                <div class="card shadow-sm border-0">

                    <div class="card-body p-4">

                        <h5 class="fw-bold mb-3">Productos del carrito
                    </h5>

                        <div class="table-responsive">

                            <asp:GridView ID="dgvCarrito" runat="server" AutoGenerateColumns="false" GridLines="None" CssClass="table table-hover align-middle mb-0" OnRowDeleting="dgvCarrito_BorrarFila">

                                <Columns>

                                    <asp:BoundField DataField="NombreProducto" HeaderText="Producto" />

                                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />

                                    <asp:BoundField DataField="PrecioUnitario" HeaderText="Precio unitario" DataFormatString="${0:N2}" HtmlEncode="false" />


                                    <asp:TemplateField HeaderText="Subtotal">

                                        <ItemStyle CssClass="text-end text-nowrap fw-semibold" />
                                        <HeaderStyle CssClass="text-end" />

                                        <ItemTemplate>
                                            $<%# (Convert.ToDecimal(Eval("PrecioUnitario")) *
                                            Convert.ToInt32(Eval("Cantidad"))).ToString("N2") %>
                                        </ItemTemplate>

                                    </asp:TemplateField>


                                    <asp:CommandField ShowDeleteButton="true" DeleteText="Eliminar" ButtonType="Button" ControlStyle-CssClass="btn btn-outline-danger btn-sm" />

                                </Columns>

                            </asp:GridView>

                        </div>

                    </div>

                </div>

            </div>
        

        <div class="col-12 col-lg-4">

            <asp:Panel ID="pnlTotales" runat="server" CssClass="card shadow-sm border-0">

                <div class="card-body p-4">

                    <h5 class="fw-bold mb-3">Resumen del carrito
                    </h5>

                    <div class="border-top pt-3">

                        <asp:Label ID="lblSubtotal" runat="server" CssClass="d-block fs-4 fw-bold text-primary mb-3" />

                        <p class="text-muted small">
                            El costo de entrega se calculará
                            al confirmar la compra.
                       
                        </p>

                    </div>

                    <asp:Button ID="btnRealizarCompra" runat="server" Text="Realizar compra" CssClass="btn btn-primary btn-lg w-100 mt-2" OnClick="btnRealizarCompra_Click" />

                </div>

            </asp:Panel>

        </div>

    </asp:Panel>.

    </div>








</asp:Content>
