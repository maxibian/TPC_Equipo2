<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminCategorias.aspx.cs" Inherits="TPC_Equipo2.AdminCategorias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="mt-4 mb-4">
        <h2>Administración de categorías</h2>
        <p class="text-muted">
            Gestioná las categorías de productos de la tienda.
   
        </p>
    </div>

    <div class="card mb-4">
        <div class="card-body">

            <h5 class="card-title">Agregar categoría</h5>

            <div class="mb-3">
                <asp:Label ID="lblNombreCategoria" runat="server" Text="Nombre de la categoría" AssociatedControlID="txtNombreCategoria" CssClass="form-label" />

                <asp:TextBox ID="txtNombreCategoria" runat="server" CssClass="form-control" MaxLength="50" />
            </div>

            <asp:Button ID="btnAgregarCategoria" runat="server" Text="Agregar categoría" CssClass="btn btn-primary" OnClick="btnAgregarCategoria_Click"/>

            <asp:Label ID="lblMensaje" runat="server" CssClass="d-block mt-2" />

        </div>
    </div>

    <div class="card">
        <div class="card-body">
            <h5 class="card-title">Categorías registradas
        </h5>

            <asp:GridView ID="gvCategorias" runat="server" AutoGenerateColumns="false" DataKeyNames="IdCategoria" CssClass="table table-striped table-hover" OnSelectedIndexChanged="gvCategorias_SelectedIndexChanged">

                <Columns>
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />

                    <asp:CheckBoxField DataField="Estado" HeaderText="Activo" />

                    <asp:CommandField ShowSelectButton="true" SelectText="Modificar" HeaderText="Acción" />
                </Columns>

            </asp:GridView>

        </div>
    </div>

</asp:Content>
