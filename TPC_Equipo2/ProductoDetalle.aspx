<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductoDetalle.aspx.cs" Inherits="TPC_Equipo2.ProductoDetalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



    <div class="container mt-5">

    <div class="row justify-content-center">

        <div class="col-12 col-lg-10">

            <div class="card shadow-sm border-0 p-3">

                <div class="row g-4 align-items-center">

                    <!-- Imagen del producto -->
                    <div class="col-12 col-md-5 text-center">

                        <asp:Image
                            ID="imgProducto"
                            runat="server"
                            CssClass="img-fluid rounded"
                            Style="max-height: 350px; object-fit: contain;" />

                    </div>

                    <!-- Detalles del producto -->
                    <div class="col-12 col-md-7">

                        <h2 class="fw-bold mb-3">
                            <asp:Label ID="lblNombre" runat="server" />
                        </h2>

                        <p class="text-muted mb-4">
                            <asp:Label ID="lblDescripcion" runat="server" />
                        </p>

                        <hr />

                        <h3 class="text-success fw-bold mb-3">
                            $ <asp:Label ID="lblPrecio" runat="server" />
                        </h3>

                        <p class="mb-4">
                            <strong>Stock disponible:</strong>
                            <asp:Label ID="lblStock" runat="server" />
                        </p>

                        <asp:Button
                            ID="btnAgregarCarrito"
                            runat="server"
                            Text="Agregar al carrito"
                            CssClass="btn btn-primary btn-lg" />

                        <a href="Default.aspx"
                           class="btn btn-outline-secondary btn-lg ms-2">
                            Volver
                        </a>

                    </div>

                </div>

            </div>

        </div>

    </div>

</div>























    <%--<div class="container mt-4">

        <div class="row justify-content-center">

            <div class="col-12 col-md-10">

                <div class="card shadow-sm">

                    <div class="row g-0">

                        <div class="col-md-5">
                            <asp:Image
                                ID="imgProducto"
                                runat="server"
                                CssClass="img-fluid w-100 h-100"
                                Style="object-fit: contain; min-height: 300px; background-color: #f0f0f0;" />
                        </div>

                        <div class="col-md-7">

                            <div class="card-body">

                                <h2 class="card-title">
                                    <asp:Label ID="lblNombre" runat="server" />
                                </h2>

                                <p class="card-text text-muted">
                                    <asp:Label ID="lblDescripcion" runat="server" />
                                </p>

                                <h3 class="text-success mt-4">
                                    $ <asp:Label ID="lblPrecio" runat="server" />
                                </h3>

                                <asp:Label
                                    ID="lblStock"
                                    runat="server"
                                    CssClass="text-muted" />

                                <div class="mt-4">
                                    <a href="Default.aspx" class="btn btn-outline-secondary">
                                        Volver al catálogo
                                    </a>
                                </div>

                            </div>

                        </div>

                    </div>

                </div>

            </div>

        </div>

    </div>--%>


</asp:Content>
