<%@ page title="" language="C#" masterpagefile="~/Site.Master" autoeventwireup="true" codebehind="ProductoDetalle.aspx.cs" inherits="TPC_Equipo2.ProductoDetalle" %>

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
                                CssClass="img-fluid rounded productoDetalle"
                                onerror="this.onerror=null; this.src='https://www.svgrepo.com/show/508699/landscape-placeholder.svg';"/>

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

                            <h3 class="text-success fw-bold mb-3">$
                                <asp:Label ID="lblPrecio" runat="server" />
                            </h3>

                            <p class="mb-4">
                                <strong>Stock disponible:</strong>
                                <asp:Label ID="lblStock" runat="server" />
                            </p>

                            <asp:LinkButton ID="btnAgregarAlCarrito" runat="server"
                                CssClass="btn btn-primary btn-lg" OnClick="btnAgregarAlCarrito_Click">
                                Agregar al carrito</asp:LinkButton>
                            

                            <a href="Inicio.aspx"
                                class="btn btn-outline-secondary btn-lg ms-2">Volver
                            </a>

                            

                            <asp:Button
                                ID="btnModificar"
                                runat="server"
                                Text="Modificar"
                                CssClass="btn btn-primary btn-lg"
                                OnClick="btnModificar_Click" />

                            <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger d-block mt-2" />
                        </div>

                    </div>

                </div>

            </div>

        </div>

    </div>

</asp:Content>
