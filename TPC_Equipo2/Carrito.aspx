<%@ page title="" language="C#" masterpagefile="~/Site.Master" autoeventwireup="true" codebehind="Carrito.aspx.cs" inherits="TPC_Equipo2.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



    <asp:GridView ID="dgvCarrito" runat="server" AutoGenerateColumns="false" CssClass="table table-borderer" OnRowDeleting="dgvCarrito_BorrarFila">

        <columns>
            <asp:BoundField DataField="NombreProducto" HeaderText="Producto" />
            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
            <asp:BoundField DataField="PrecioUnitario" HeaderText="Precio unitario" />
            <asp:CommandField ShowDeleteButton="true" DeleteText="Eliminar" ButtonType="Button" />
        </columns>

    </asp:GridView>

    <asp:Panel ID="pnlTotales" runat="server" CssClass="pnl-totales">

        <asp:Label ID="lblSubtotal" runat="server" CssClass="lbl-subtotal"/>

        <asp:Button runat="server" ID="btnRealizarCompra" Text="Realizar compra" OnClick="btnRealizarCompra_Click" />

    </asp:Panel>

    

    <asp:Label ID="lblVacio" runat="server" Text=""></asp:Label>







</asp:Content>
