<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdministrarContrasena.aspx.cs" Inherits="TPC_Equipo2.AdministrarContrasena" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Panel ID="pnlFormulario" runat="server" CssClass="container py-4">



        <div class="container mt-4">

            <h3 class="mb-2">Administración de contraseña</h3>

            <p class="text-muted mb-4">
                Desde aquí podés actualizar la contraseña de tu cuenta.
            </p>

            <hr />
            <div class="mb-4">
                <h5>Verificación de identidad</h5>

                <asp:Panel ID="pnlPassword" runat="server" CssClass="mb-3">
                    <asp:Label ID="lblPassword" runat="server" Text="Contraseña actual" AssociatedControlID="txtPassword" CssClass="form-label" />
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" MaxLength="50" TextMode="Password" />
                </asp:Panel>
            </div>
            <hr />

            <div class="mb-3">
                <h5>Nueva contraseña</h5>

                <asp:Panel ID="pnlPasswordNuevo" runat="server" CssClass="mb-3">
                    <asp:Label ID="lblPasswordNuevo" runat="server" Text="Contraseña nueva" AssociatedControlID="txtPassword" CssClass="form-label" />
                    <asp:TextBox ID="txtPasswordNuevo" runat="server" CssClass="form-control" MaxLength="50" TextMode="Password" />
                </asp:Panel>

                <asp:Panel ID="pnlConfirmacionPassword" runat="server" CssClass="mb-3">
                    <asp:Label ID="lblConfirmacionPassword" runat="server" Text="Confirmar contraseña" AssociatedControlID="txtPassword" CssClass="form-label" />
                    <asp:TextBox ID="txtConfirmacionPassword" runat="server" CssClass="form-control" MaxLength="50" TextMode="Password" />
                </asp:Panel>

            </div>

            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />

            <asp:HyperLink ID="lnkCancelar" runat="server" Text="Cancelar" NavigateUrl="~/Default.aspx" CssClass="btn btn-outline-secondary" />

        </div>
    </asp:Panel>

</asp:Content>
