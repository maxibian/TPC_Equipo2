<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MiCuenta.aspx.cs" Inherits="TPC_Equipo2.MiCuenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<asp:Panel ID="pnlMiCuenta" runat="server"
    CssClass="container mt-5 mb-5">

    <asp:Panel ID="pnlEncabezado" runat="server" CssClass="mb-4">

        <asp:Label ID="lblTitulo" runat="server"
            Text="Mi cuenta"
            CssClass="h2 fw-bold d-block" />

        <asp:Label ID="lblDescripcion" runat="server"
            Text="Administrá tus datos personales y preferencias."
            CssClass="text-muted" />

    </asp:Panel>

    <div class="row g-4">

        <!-- SEGURIDAD -->
        <div class="col-md-6 col-lg-3">

            <asp:Panel ID="pnlSeguridad" runat="server"
                CssClass="card h-100 shadow-sm border-0">

                <div class="card-body p-4">

                    <i class="bi bi-shield-lock fs-1 text-primary"></i>

                    <asp:Label ID="lblSeguridad" runat="server"
                        Text="Seguridad"
                        CssClass="h5 fw-bold d-block mt-3" />

                    <asp:Label ID="lblDescripcionSeguridad" runat="server"
                        Text="Administrá y actualizá tu contraseña."
                        CssClass="text-muted small d-block mb-3" />

                    <asp:HyperLink ID="hlContrasena" runat="server"
                        NavigateUrl="~/AdministrarContrasena.aspx"
                        Text="Administrar →"
                        CssClass="text-primary fw-semibold text-decoration-none" />

                </div>

            </asp:Panel>

        </div>

        <!-- HISTORIAL DE COMPRAS -->
        <div class="col-md-6 col-lg-3">

            <asp:Panel ID="pnlCompras" runat="server"
                CssClass="card h-100 shadow-sm border-0">

                <div class="card-body p-4">

                    <i class="bi bi-bag-check fs-1 text-primary"></i>

                    <asp:Label ID="lblCompras" runat="server"
                        Text="Mis compras"
                        CssClass="h5 fw-bold d-block mt-3" />

                    <asp:Label ID="lblDescripcionCompras" runat="server"
                        Text="Consultá tus pedidos y compras anteriores."
                        CssClass="text-muted small d-block mb-3" />

                    <asp:HyperLink ID="hlCompras" runat="server"
                        NavigateUrl="~/HistorialPedidos.aspx"
                        Text="Ver historial →"
                        CssClass="text-primary fw-semibold text-decoration-none" />

                </div>

            </asp:Panel>

        </div>

        <!-- TARJETAS -->
        <div class="col-md-6 col-lg-3">

            <asp:Panel ID="pnlTarjetas" runat="server"
                CssClass="card h-100 shadow-sm border-0">

                <div class="card-body p-4">

                    <i class="bi bi-credit-card fs-1 text-primary"></i>

                    <asp:Label ID="lblTarjetas" runat="server"
                        Text="Mis tarjetas"
                        CssClass="h5 fw-bold d-block mt-3" />

                    <asp:Label ID="lblDescripcionTarjetas" runat="server"
                        Text="Gestioná tus medios de pago."
                        CssClass="text-muted small d-block mb-3" />

                    <asp:HyperLink ID="hlTarjetas" runat="server"
                        NavigateUrl="~/AdministrarTarjetas.aspx"
                        Text="Administrar →"
                        CssClass="text-primary fw-semibold text-decoration-none" />

                </div>

            </asp:Panel>

        </div>

        <!-- DIRECCIONES -->
        <div class="col-md-6 col-lg-3">

            <asp:Panel ID="pnlDirecciones" runat="server"
                CssClass="card h-100 shadow-sm border-0">

                <div class="card-body p-4">

                    <i class="bi bi-geo-alt fs-1 text-primary"></i>

                    <asp:Label ID="lblDirecciones" runat="server"
                        Text="Mis direcciones"
                        CssClass="h5 fw-bold d-block mt-3" />

                    <asp:Label ID="lblDescripcionDirecciones" runat="server"
                        Text="Administrá tus domicilios de entrega."
                        CssClass="text-muted small d-block mb-3" />

                    <asp:HyperLink ID="hlDirecciones" runat="server"
                        NavigateUrl="~/AdministrarDireccion.aspx"
                        Text="Administrar →"
                        CssClass="text-primary fw-semibold text-decoration-none" />

                </div>

            </asp:Panel>

        </div>

    </div>

</asp:Panel>

</asp:Content>
