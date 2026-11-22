<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConfirmarCompra.aspx.cs" Inherits="TPC_Equipo2.ConfirmarCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Confirmar compra</h2>

    <asp:Label ID="lblCarrito" runat="server" />

    <div class="mt-3">
        <asp:HyperLink ID="lnkVolverCarrito" runat="server" NavigateUrl="~/Carrito.aspx" Text="Volver al carrito" CssClass="btn btn-outline-secondary me-2" />

        <asp:HyperLink ID="lnkVolverCatalogo" runat="server" NavigateUrl="~/Inicio.aspx" Text="Seguir comprando" CssClass="btn btn-outline-primary" />
    </div>

    <div class="card shadow-sm mt-4">
        <div class="card-body">

            <h5 class="card-title mb-3">Resumen de compra
            </h5>

            <asp:GridView ID="gvResumen" runat="server" AutoGenerateColumns="false" CssClass="table table-striped">

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

        </div>
    </div>


    <div class="card shadow-sm mt-4">
        <div class="card-body">

            <h5 class="card-title mb-3">Datos de la compra
            </h5>

            <div class="mb-3">
                <label class="form-label">
                    Forma de pago
                </label>

                <asp:DropDownList ID="ddlFormaPago" runat="server" CssClass="form-select" />
            </div>

            <div class="mb-3">
                <label class="form-label">
                    Forma de entrega
                </label>

                <asp:DropDownList ID="ddlFormaEntrega" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlFormaEntrega_SelectedIndexChanged" />
                <asp:Panel ID="pnlDireccion" runat="server" Visible="false" CssClass="border rounded p-3 mb-3">

                    <h5>Dirección de entrega</h5>

                    <p>Seleccioná una dirección guardada o ingresá una nueva.</p>

                    <div class="mb-3">
                        <asp:Label ID="lblDireccion" runat="server" Text="Dirección de entrega" AssociatedControlID="ddlDireccion" CssClass="form-label" />

                        <asp:DropDownList ID="ddlDireccion" runat="server" CssClass="form-select" />
                    </div>

                </asp:Panel>

            </div>

            <asp:Button ID="btnConfirmarCompra" runat="server" Text="Confirmar compra" CssClass="btn btn-primary" Enabled="false" OnClick="btnConfirmarCompra_Click" />

            <asp:Label ID="lblMensaje" runat="server" CssClass="d-block mt-3" />

        </div>
    </div>



</asp:Content>
