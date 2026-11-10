<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminFormasPago.aspx.cs" Inherits="TPC_Equipo2.AdminFormasPago" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="mt-4 mb-4">
        <h2>Administración de formas de pago</h2>
        <p class="text-muted">
            Gestioná los medios de pago de la tienda.
        </p>
    </div>

    <div class="card mb-4">
        <div class="card-body">

            <h5 class="card-title mb-3">Agregar forma de pago</h5>
            <div class="mb-3">
                <asp:Label ID="lblNombreFormaPago" runat="server" Text="Nombre" AssociatedControlID="txtNombreFormaPago" CssClass="form-label" />

                <asp:TextBox ID="txtNombreFormaPago" runat="server" CssClass="form-control" />
            </div>
            <asp:Button ID="btnAgregarFormaPago" runat="server" Text="Agregar" CssClass="btn btn-primary" OnClick="btnAgregarFormaPago_Click" />
            <asp:Label ID="lblMensaje" runat="server" CssClass="d-block mt-2" />

        </div>
    </div>

    <div class="card">
        <div class="card-body">
            <h5 class="card-title">Formas de pago registradas</h5>

            <asp:GridView ID="gvFormasPago" runat="server" DataKeyNames="IdFormaPago" AutoGenerateColumns="false" CssClass="table table-striped table-hover" OnSelectedIndexChanged="gvFormasPago_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:CheckBoxField HeaderText="Activo" DataField="Estado" />
                    <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="Seleccionar" />
                </Columns>
            </asp:GridView>

        </div>
    </div>



</asp:Content>
