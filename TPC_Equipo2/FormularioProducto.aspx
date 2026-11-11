<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioProducto.aspx.cs" Inherits="TPC_Equipo2.FormularioProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Panel ID="pnlFormulario" runat="server" CssClass="container py-4">

        <asp:Label ID="lblTitulo" runat="server" Text="Agregar producto" CssClass="h4 d-block mb-4" />

        <asp:Panel ID="pnlNombre" runat="server" CssClass="mb-3">
            <asp:Label ID="lblNombre" runat="server" Text="Nombre" AssociatedControlID="txtNombre" CssClass="form-label" />
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" MaxLength="50" />
            <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre"
                ErrorMessage="El nombre es obligatorio." CssClass="text-danger small" Display="Dynamic" />
        </asp:Panel>

        <asp:Panel ID="pnlDescripcion" runat="server" CssClass="mb-3">
            <asp:Label ID="lblDescripcion" runat="server" Text="Descripción (opcional)" AssociatedControlID="txtDescripcion" CssClass="form-label" />
            <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control"
                TextMode="MultiLine" Rows="3" MaxLength="150" />
        </asp:Panel>

        <asp:Panel ID="pnlPrecio" runat="server" CssClass="mb-3">
            <asp:Label ID="lblPrecio" runat="server" Text="Precio" AssociatedControlID="txtPrecio" CssClass="form-label" />
            <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" />
            <asp:RequiredFieldValidator ID="rfvPrecio" runat="server" ControlToValidate="txtPrecio"
                ErrorMessage="El precio es obligatorio." CssClass="text-danger small" Display="Dynamic" />
        </asp:Panel>

        <asp:Panel ID="pnlStock" runat="server" CssClass="mb-3">
            <asp:Label ID="lblStock" runat="server" Text="Stock" AssociatedControlID="txtStock" CssClass="form-label" />
            <asp:TextBox ID="txtStock" runat="server" CssClass="form-control" TextMode="Number" />
            <asp:RequiredFieldValidator ID="rfvStock" runat="server" ControlToValidate="txtStock"
                ErrorMessage="El stock es obligatorio." CssClass="text-danger small" Display="Dynamic" />
            <asp:RangeValidator ID="rvStock" runat="server" ControlToValidate="txtStock" Type="Integer"
                MinimumValue="0" MaximumValue="1000000"
                ErrorMessage="El stock no puede ser negativo." CssClass="text-danger small" Display="Dynamic" />
        </asp:Panel>

        <asp:Panel ID="pnlCategoria" runat="server" CssClass="mb-3">
            <asp:Label ID="lblCategoria" runat="server" Text="Categoría" AssociatedControlID="ddlCategoria" CssClass="form-label" />
            <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-select" />
            <asp:RequiredFieldValidator ID="rfvCategoria" runat="server" ControlToValidate="ddlCategoria"
                InitialValue="0" ErrorMessage="Seleccioná una categoría."
                CssClass="text-danger small" Display="Dynamic" />
        </asp:Panel>

        <asp:Panel ID="pnlImagen" runat="server" CssClass="mb-3">
            <asp:Label ID="lblImagenUrl" runat="server" Text="URL de la imagen (opcional)" AssociatedControlID="txtImagenUrl" CssClass="form-label" />
            <asp:TextBox ID="txtImagenUrl" runat="server" CssClass="form-control" MaxLength="255" />
        </asp:Panel>

        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
        <asp:HyperLink ID="lnkCancelar" runat="server" Text="Cancelar" NavigateUrl="~/Default.aspx" CssClass="btn btn-outline-secondary" />

        <asp:Label ID="lblMensaje" runat="server" CssClass="d-block mt-3" />

    </asp:Panel>


</asp:Content>
