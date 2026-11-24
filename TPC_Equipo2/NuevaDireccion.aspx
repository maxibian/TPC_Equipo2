<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NuevaDireccion.aspx.cs" Inherits="TPC_Equipo2.NuevaDireccion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Panel ID="pnlDireccion" runat="server" CssClass="container py-4">

        <asp:Panel ID="pnlCalle" runat="server" CssClass="mb-3">
            <asp:Label ID="lblCalle" runat="server" Text="Calle" CssClass="form-label" />
            <asp:TextBox ID="txtCalle" runat="server" CssClass="form-control" MaxLength="50" />
        </asp:Panel>

        <asp:Panel ID="pnlNumero" runat="server" CssClass="mb-3">
            <asp:Label ID="lblNumero" runat="server" Text="Numero" CssClass="form-label" />
            <asp:TextBox ID="txtNumero" runat="server" CssClass="form-control" MaxLength="50" />
        </asp:Panel>

        <asp:Panel ID="pnlLocalidad" runat="server" CssClass="mb-3">
            <asp:Label ID="lblLocalidad" runat="server" Text="Localidad" CssClass="form-label" />
            <asp:TextBox ID="txtLocalidad" runat="server" CssClass="form-control" MaxLength="50" />
        </asp:Panel>

        <asp:Panel ID="pnlProvincia" runat="server" CssClass="mb-3">
            <asp:Label ID="lblProvincia" runat="server" Text="Provincia" CssClass="form-label" />
            <asp:TextBox ID="txtProvincia" runat="server" CssClass="form-control" MaxLength="50" />
        </asp:Panel>

        <asp:Panel ID="pnlCodigoPostal" runat="server" CssClass="mb-3">
            <asp:Label ID="lblCodigoPostal" runat="server" Text="Codigo Postal" CssClass="form-label" />
            <asp:TextBox ID="txtCodigoPostal" runat="server" CssClass="form-control" MaxLength="50" />
        </asp:Panel>

        <asp:Panel ID="pnlObservacion" runat="server" CssClass="mb-3">
            <asp:Label ID="lblObservacion" runat="server" Text="Observacion" CssClass="form-label" />
            <asp:TextBox ID="txtObservacion" runat="server" CssClass="form-control" MaxLength="50" />
        </asp:Panel>


        <asp:Button ID="btnGuardar" Text="Guardar" runat="server" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
        <asp:HyperLink ID="lnkCancelar" runat="server" Text="Volver" NavigateUrl="~/AdministrarDireccion.aspx" CssClass="btn btn-outline-secondary" />
        <asp:Label ID="lblRespuesta" runat="server" Text=""></asp:Label>
    </asp:Panel>

</asp:Content>
