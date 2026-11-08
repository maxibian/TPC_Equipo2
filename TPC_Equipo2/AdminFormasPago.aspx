<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminFormasPago.aspx.cs" Inherits="TPC_Equipo2.AdminFormasPago" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:GridView ID="gvFormasPago" runat="server"></asp:GridView>
    <asp:TextBox ID="txtNombreFormaPago" runat="server"></asp:TextBox>
    <asp:Button ID="btnAgregarFormaPago" runat="server" Text="Agregar" OnClick="btnAgregarFormaPago_Click"/>
</asp:Content>
