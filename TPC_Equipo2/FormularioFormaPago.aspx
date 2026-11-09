<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioFormaPago.aspx.cs" Inherits="TPC_Equipo2.FormularioFormaPago" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label>

    <asp:TextBox ID="txtNombreFormaPago" runat="server"></asp:TextBox>

    <asp:CheckBox ID="chkEstado" Enabled="false" runat="server" Text="Activo" />

    <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>

    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click"/>

    <asp:Button ID="btnCambiarEstado" runat="server" Text="Cambiar estado" OnClick="btnCambiarEstado_Click"/>

</asp:Content>
