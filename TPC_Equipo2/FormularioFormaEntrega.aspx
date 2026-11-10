<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioFormaEntrega.aspx.cs" Inherits="TPC_Equipo2.FormularioFormaEntrega" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="mt-4 mb-4">
        <h2>Modificar forma de entrega</h2>
        <p class="text-muted">
            Actualizá los datos de la forma de entrega seleccionada.
        </p>
    </div>

    <div class="card mb-4">
        <div class="card-body">

            <div class="col-md-6 mb-3">
                <asp:Label ID="lblNombre" runat="server" Text="Nombre:" CssClass="form-label" AssociatedControlID="txtNombreFormaEntrega"></asp:Label>
                <asp:TextBox ID="txtNombreFormaEntrega" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
            </div>

            <div class="mb-3">
                <asp:CheckBox ID="chkEstado" Enabled="false" runat="server" Text="Activo" />
            </div>

            <div class="d-flex flex-wrap gap-2 mt-3">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar cambios" OnClick="btnGuardar_Click" CssClass="btn btn-primary" />
                <asp:Button ID="btnCambiarEstado" runat="server" Text="Cambiar estado" OnClick="btnCambiarEstado_Click" CssClass="btn btn-outline-secondary" />
                <a href="AdminFormasEntrega.aspx" class="btn btn-outline-secondary">Volver al listado
                </a>
            </div>

            <asp:Label ID="lblMensaje" runat="server" Text="" CssClass="d-block mt-2"></asp:Label>

        </div>
    </div>











</asp:Content>
