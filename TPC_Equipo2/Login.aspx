<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TPC_Equipo2.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <asp:Panel ID="pnlFormulario" runat="server" CssClass="container py-4">

        <asp:Label ID="lblTitulo" runat="server" Text="Iniciar Sesión" CssClass="h4 d-block mb-3" />

        <asp:Panel ID="pnlEmail" runat="server" CssClass="mb-3">
            <asp:Label ID="lblEmail" runat="server" Text="Email Usuario" AssociatedControlID="txtEmail" CssClass="form-label" />
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" MaxLength="50" placeholder="correo@ejemplo.com" />
        </asp:Panel>

        <asp:Panel ID="pnlPassword" runat="server" CssClass="mb-3">
            <asp:Label ID="lblPassword" runat="server" Text="Contraseña" AssociatedControlID="txtPassword" CssClass="form-label" />
            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" MaxLength="50" TextMode="Password" />
        </asp:Panel>

        <asp:Button ID="btnGuardar" runat="server" Text="Aceptar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
        <asp:HyperLink ID="lnkCancelar" runat="server" Text="Cancelar" NavigateUrl="~/Inicio.aspx" CssClass="btn btn-outline-secondary" />

    </asp:Panel>



</asp:Content>
