<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConfirmarCompra.aspx.cs" Inherits="TPC_Equipo2.ConfirmarCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Confirmar compra</h2>

    <asp:Label ID="lblCarrito" runat="server" />


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


</asp:Content>
