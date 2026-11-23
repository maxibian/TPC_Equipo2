<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminCategorias.aspx.cs" Inherits="TPC_Equipo2.AdminCategorias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="mt-4 mb-4">
        <h2>Administración de categorías</h2>
        <p class="text-muted">
            Gestioná las categorías de productos de la tienda.
   
        </p>
    </div>

    <div class="card">
        <div class="card-body">
            <h5 class="card-title">Categorías registradas
        </h5>

            <asp:GridView ID="gvCategorias" runat="server" AutoGenerateColumns="false" DataKeyNames="IdCategoria" CssClass="table table-striped table-hover">

                <Columns>
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />

                    <asp:CheckBoxField DataField="Estado" HeaderText="Activo" />
                </Columns>

            </asp:GridView>

        </div>
    </div>

</asp:Content>
