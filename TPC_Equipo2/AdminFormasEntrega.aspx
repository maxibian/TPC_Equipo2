<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminFormasEntrega.aspx.cs" Inherits="TPC_Equipo2.AdminFormasEntrega" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="mt-4 mb-4">
        <h2>Administración de formas de entrega</h2>
        <p class="text-muted">
            Gestioná los medios de entrega de la tienda.
        </p>
    </div>

    <div class="card mb-4">
        <div class="card-body">

            <h5 class="card-title mb-3">Agregar forma de entrega</h5>
            <div class="mb-3">
                <asp:Label ID="lblNombreFormaEntrega" runat="server" Text="Nombre" AssociatedControlID="txtNombreFormaEntrega" CssClass="form-label" />
                <asp:TextBox ID="txtNombreFormaEntrega" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
            </div>
            <asp:Button ID="btnAgregarFormaEntrega" runat="server" Text="Agregar" OnClick="btnAgregarFormaEntrega_Click" CssClass="btn btn-primary" />
            <asp:Label ID="lblMensaje" runat="server" CssClass="d-block mt-2"></asp:Label>
        </div>
    </div>

    <div class="card">
        <div class="card-body">
            <h5 class="card-title">Formas de pago registradas</h5>
            <div class="table-responsive">
                <asp:GridView ID="gvFormasEntrega" runat="server" DataKeyNames="IdFormaEntrega" AutoGenerateColumns="false" CssClass="table" OnSelectedIndexChanged="gvFormasEntrega_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                        <asp:CheckBoxField HeaderText="Activo" DataField="Estado" />
                        <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="Seleccionar" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>






</asp:Content>
