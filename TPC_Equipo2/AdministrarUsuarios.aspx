<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdministrarUsuarios.aspx.cs" Inherits="TPC_Equipo2.AdministrarUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Panel ID="pnlFormulario" runat="server" CssClass="container py-4">

        <asp:Panel ID="pnlEmailUsuario" runat="server" CssClass="mb-3">
            <asp:Label ID="lblEmailUsuario" runat="server" Text="Ingresar Usuario" AssociatedControlID="txtEmailUsuario" CssClass="form-label" />
            <asp:TextBox ID="txtEmailUsuario" runat="server" CssClass="form-control" MaxLength="50" placeholder="correo@ejemplo.com" />
        </asp:Panel>

        <asp:Panel ID="pnlAdministrarUsuario" runat="server" CssClass="mb-3">
            <asp:Label ID="lblAdministrarDrop" runat="server" Text="Administrar Usuario" CssClass="form-label"></asp:Label>
            <asp:DropDownList ID="ddlRol" runat="server" OnSelectedIndexChanged="btnGuardar_Click" CssClass="form-select"></asp:DropDownList>
        </asp:Panel>

        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
        <asp:HyperLink ID="lnkCancelar" runat="server" Text="Cancelar" NavigateUrl="~/Default.aspx" CssClass="btn btn-outline-secondary" />

        <asp:Panel ID="Panel1" runat="server" CssClass="mb-3">
            <asp:Label ID="lblRespuesta" runat="server" Text="" CssClass="form-label" Style="color: red" />
        </asp:Panel>

    </asp:Panel>
</asp:Content>
