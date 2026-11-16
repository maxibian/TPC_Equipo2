<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="TPC_Equipo2.Carrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



<asp:GridView ID="dgvCarrito" runat="server" AutoGenerateColumns="false" CssClass="table table-borderer">

    <Columns>
        <asp:BoundField DataField="NombreProducto" HeaderText="Producto" />
        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
        <asp:BoundField DataField="PrecioUnitario" HeaderText="Precio unitario" />
    </Columns>
   
</asp:GridView>
    <asp:Label ID="lblVacio" runat="server" Text=""></asp:Label>







</asp:Content>
