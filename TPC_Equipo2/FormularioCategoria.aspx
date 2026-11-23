<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioCategoria.aspx.cs" Inherits="TPC_Equipo2.FormularioCategoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-4">

        <h2>Modificar categoría</h2>

        <div class="mb-3">
            <asp:Label runat="server" Text="Nombre de la categoría" AssociatedControlID="txtNombre" CssClass="form-label" />

            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" MaxLength="50" />
        </div>

        <div class="mb-3">
            <asp:CheckBox ID="chkEstado" runat="server" Text="Categoría activa" Enabled="false" />
        </div>

        <asp:Button ID="btnGuardar" runat="server" Text="Guardar cambios" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />

        <asp:Button ID="btnCambiarEstado" runat="server" Text="Desactivar categoría" CssClass="btn btn-danger" OnClick="btnCambiarEstado_Click"/>

        <asp:Label ID="lblMensaje" runat="server" CssClass="d-block mt-3" />

        <a href="AdminCategorias.aspx" class="btn btn-outline-secondary">Volver al listado</a>

    </div>

</asp:Content>
