<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CompraExitosa.aspx.cs" Inherits="TPC_Equipo2.CompraExitosa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

        <div class="container mt-4">
            <h2>¡Pedido registrado correctamente!</h2>
            <p class="text-muted">
                Recibimos tu pedido. Podés consultar los datos de tu compra a continuación.
            </p>

            <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger" />

            <asp:Panel ID="pnlComprobante" runat="server" Visible="false">

                <div class="card mt-4">
                    <div class="card-body">

                        <h5>Resumen del pedido</h5>

                        <p>
                            Número de pedido:
                       
                            <asp:Label ID="lblIdVenta" runat="server" />
                        </p>

                        <p>
                            Fecha:
                       
                            <asp:Label ID="lblFecha" runat="server" />
                        </p>

                        <p>
                            Estado:
                       
                            <asp:Label ID="lblEstado" runat="server" />
                        </p>

                        <p>
                            Forma de pago:
                       
                            <asp:Label ID="lblFormaPago" runat="server" />
                        </p>

                        <p>
                            Forma de entrega:
                       
                            <asp:Label ID="lblFormaEntrega" runat="server" />
                        </p>

                        <asp:GridView ID="gvDetalles" runat="server" AutoGenerateColumns="false" CssClass="table table-striped mt-3">
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

                        <h5 class="text-end">Total: $
                       
                            <asp:Label ID="lblTotal" runat="server" />
                        </h5>

                        <p class="text-muted">  El pedido fue registrado. Su estado se actualizará a medida que avance el proceso de compra.
                        </p>

                    </div>
                </div>

            </asp:Panel>

            <a href="Inicio.aspx" class="btn btn-primary mt-3">Volver al catálogo
        </a>
        </div>

</asp:Content>
