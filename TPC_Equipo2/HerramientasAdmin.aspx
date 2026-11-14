<%@ Page Title="Herramientas Admin" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HerramientasAdmin.aspx.cs" Inherits="TPC_Equipo2.HerramientasAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="mt-4 mb-4">
        <h2>Herramientas de administración</h2>
        <p class="text-muted">
            Seleccioná la sección que querés administrar.
   
        </p>
    </div>

    <div class="row g-4">

        <div class="col-md-6 col-lg-4">
            <div class="card h-100 shadow-sm">
                <div class="card-body d-flex flex-column">

                    <h5 class="card-title">Formas de entrega</h5>

                    <p class="card-text text-muted">
                        Gestioná las opciones de entrega
                    disponibles en la tienda.
               
                    </p>

                    <a href="AdminFormasEntrega.aspx"
                        class="btn btn-outline-primary mt-auto">Administrar entregas
                </a>

                </div>
            </div>
        </div>

        <div class="col-md-6 col-lg-4">
            <div class="card h-100 shadow-sm">
                <div class="card-body d-flex flex-column">

                    <h5 class="card-title">Formas de pago</h5>

                    <p class="card-text text-muted">
                        Administrá los medios de pago
                    que acepta la tienda.
               
                    </p>

                    <a href="AdminFormasPago.aspx"
                        class="btn btn-outline-primary mt-auto">Administrar pagos
                </a>

                </div>
            </div>
        </div>

        <div class="col-md-6 col-lg-4">
            <div class="card h-100 shadow-sm">
                <div class="card-body d-flex flex-column">

                    <h5 class="card-title">Ventas y pedidos</h5>

                    <p class="card-text text-muted">
                        Consultá los pedidos realizados
                    y sus estados.
               
                    </p>

                    <a href="AdminVentas.aspx"
                        class="btn btn-outline-primary mt-auto">Administrar ventas
                </a>

                </div>
            </div>
        </div>

        <div class="col-md-6 col-lg-4">
            <div class="card h-100 shadow-sm">
                <div class="card-body d-flex flex-column">

                    <h5 class="card-title">Productos</h5>

                    <p class="card-text text-muted">
                        Administrá los productos de la tienda     
                    </p>

                     <a href="FormularioProducto.aspx"
                        class="btn btn-outline-primary mt-auto">Administrar Productos
                </a>
                </div>
            </div>
        </div>

        <div class="col-md-6 col-lg-4">
            <div class="card h-100 shadow-sm">
                <div class="card-body d-flex flex-column">

                    <h5 class="card-title">Administrar Usuarios</h5>

                    <p class="card-text text-muted">
                        Administrá los usuarios de la tienda     
                    </p>

                    <%-- <a href="paginaParaAdministrarLosUsuarios.aspx"
                        class="btn btn-outline-primary mt-auto">Administrar Usuarios
                </a>--%>
                </div>
            </div>
        </div>


    </div>



</asp:Content>
