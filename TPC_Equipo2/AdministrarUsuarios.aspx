<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdministrarUsuarios.aspx.cs" Inherits="TPC_Equipo2.AdministrarUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Panel ID="pnlFormulario" runat="server" CssClass="container py-4">

        <asp:Panel ID="pnlEmailUsuario" runat="server" CssClass="mb-3">
            <asp:Label ID="lblEmailUsuario" runat="server" Text="Ingresar Usuario" AssociatedControlID="txtEmailUsuario" CssClass="form-label" />
            <asp:TextBox ID="txtEmailUsuario" runat="server" CssClass="form-control" MaxLength="50" placeholder="correo@ejemplo.com" />
        </asp:Panel>

        <asp:Panel ID="pnlPassword" runat="server" CssClass="mb-3">
            <asp:Label ID="lblPassword" runat="server" Text="Contraseña" AssociatedControlID="txtPassword" CssClass="form-label" />
            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" MaxLength="50" TextMode="Password" />
        </asp:Panel>

        <asp:Button ID="btnAlta" runat="server" Text="Alta" CssClass="btn btn-primary" OnClick="btnAlta_Click" />
        
        <asp:Button ID="btnBaja" runat="server" Text="Baja" CssClass="btn btn-primary" OnClick="btnBaja_Click" />
        
        <asp:HyperLink ID="lnkCancelar" runat="server" Text="Cancelar" NavigateUrl="~/Inicio.aspx" CssClass="btn btn-outline-secondary" />

        <asp:Panel ID="Panel1" runat="server" CssClass="mb-3">
            <asp:Label ID="lblRespuesta" runat="server" Text="" CssClass="form-label" Style="color: red" />
        </asp:Panel>

    </asp:Panel>
</asp:Content>
