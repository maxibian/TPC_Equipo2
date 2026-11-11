<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioAgregarCliente.aspx.cs" Inherits="TPC_Equipo2.FormularioAgregarCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Panel ID="pnlFormulario" runat="server" CssClass="container py-4">

        <asp:Label ID="lblTitulo" runat="server" Text="Registro" CssClass="h4 d-block mb-3" />

        <asp:Label ID="lblDatosPersonales" runat="server" Text="Datos personales" CssClass="h4 d-block mb-4" />

        <asp:Panel ID="pnlNombre" runat="server" CssClass="mb-3">
            <asp:Label ID="lblNombre" runat="server" Text="Nombre" AssociatedControlID="txtNombre" CssClass="form-label" />
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" MaxLength="50" />
        </asp:Panel>

        <asp:Panel ID="pnlApellido" runat="server" CssClass="mb-3">
            <asp:Label ID="lblApellido" runat="server" Text="Apellido" AssociatedControlID="txtApellido" CssClass="form-label" />
            <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" MaxLength="50" />
        </asp:Panel>


        <asp:Panel ID="pnlEmail" runat="server" CssClass="mb-3">
            <asp:Label ID="lblEmail" runat="server" Text="Email" AssociatedControlID="txtEmail" CssClass="form-label" />
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" MaxLength="50" placeholder="correo@ejemplo.com" />
        </asp:Panel>

        <asp:Panel ID="pnlTelefono" runat="server" CssClass="mb-3">
            <asp:Label ID="lblTelefono" runat="server" Text="Telefono" AssociatedControlID="txtTelefono" CssClass="form-label" />
            <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" MaxLength="50" />
        </asp:Panel>

        <asp:Label ID="Label1" runat="server" Text="Datos de acceso" CssClass="h4 d-block mb-3" />

        <asp:Panel ID="pnlEmailUsuario" runat="server" CssClass="mb-3">
            <asp:Label ID="lblEmailUsuario" runat="server" Text="Email de usuario" AssociatedControlID="txtEmailUsuario" CssClass="form-label" />
            <asp:TextBox ID="txtEmailUsuario" runat="server" CssClass="form-control" MaxLength="50" placeholder="correo@ejemplo.com" />
        </asp:Panel>

        <asp:Panel ID="pnlPassword" runat="server" CssClass="mb-3">
            <asp:Label ID="lblPassword" runat="server" Text="Contraseña" AssociatedControlID="txtPassword" CssClass="form-label" />
            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" MaxLength="50" TextMode="Password" />
        </asp:Panel>

                <asp:Panel ID="pnlPasswordConfirmacion" runat="server" CssClass="mb-3">
            <asp:Label ID="lblPasswordConfirmacion" runat="server" Text="Confirmar contraseña " AssociatedControlID="txtPasswordConfirmacion" CssClass="form-label" />
            <asp:TextBox ID="txtPasswordConfirmacion" runat="server" CssClass="form-control" MaxLength="50" TextMode="Password" />
        </asp:Panel>


        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
        <asp:HyperLink ID="lnkCancelar" runat="server" Text="Cancelar" NavigateUrl="~/Default.aspx" CssClass="btn btn-outline-secondary" />

        <asp:Label ID="lblRespuesta" runat="server" Text="" CssClass="form-label" />


    </asp:Panel>



</asp:Content>
