<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NuevaDireccion.aspx.cs" Inherits="TPC_Equipo2.NuevaDireccion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<div class="container-fluid py-5">

    <div class="row justify-content-center">

        <div class="col-12 col-md-9 col-lg-7 col-xl-6">

            <div class="card shadow-sm border-0 rounded-4">

                <!-- ENCABEZADO -->
                <div class="text-center pt-4 px-4">

                    <i class="bi bi-geo-alt text-primary"
                       style="font-size: 2.5rem;"></i>

                    <h3 class="fw-bold mt-2 mb-1">
                        Nueva dirección
                    </h3>

                    <p class="text-muted mb-0">
                        Completá los datos de tu domicilio
                    </p>

                </div>

                <hr class="mx-4 mt-4" />

                <!-- FORMULARIO -->
                <div class="card-body px-4 px-md-5 pb-4">

                    <asp:Panel ID="pnlDireccion" runat="server"
                        CssClass="w-100">

                        <asp:Panel ID="pnlCalle" runat="server" CssClass="mb-3">
                            <asp:Label ID="lblCalle" runat="server" Text="Calle" CssClass="form-label" />
                            <asp:TextBox ID="txtCalle" runat="server" CssClass="form-control" MaxLength="50" />
                        </asp:Panel>

                        <div class="row">

                            <div class="col-md-6">
                                <asp:Panel ID="pnlNumero" runat="server" CssClass="mb-3">
                                    <asp:Label ID="lblNumero" runat="server" Text="Número" CssClass="form-label" />
                                    <asp:TextBox ID="txtNumero" runat="server" CssClass="form-control" MaxLength="50" />
                                </asp:Panel>
                            </div>

                            <div class="col-md-6">
                                <asp:Panel ID="pnlCodigoPostal" runat="server" CssClass="mb-3">
                                    <asp:Label ID="lblCodigoPostal" runat="server" Text="Código Postal" CssClass="form-label" />
                                    <asp:TextBox ID="txtCodigoPostal" runat="server" CssClass="form-control" MaxLength="10" />
                                </asp:Panel>
                            </div>

                        </div>

                        <div class="row">

                            <div class="col-md-6">
                                <asp:Panel ID="pnlLocalidad" runat="server" CssClass="mb-3">
                                    <asp:Label ID="lblLocalidad" runat="server" Text="Localidad" CssClass="form-label" />
                                    <asp:TextBox ID="txtLocalidad" runat="server" CssClass="form-control" MaxLength="50" />
                                </asp:Panel>
                            </div>

                            <div class="col-md-6">
                                <asp:Panel ID="pnlProvincia" runat="server" CssClass="mb-3">
                                    <asp:Label ID="lblProvincia" runat="server" Text="Provincia" CssClass="form-label" />
                                    <asp:TextBox ID="txtProvincia" runat="server" CssClass="form-control" MaxLength="50" />
                                </asp:Panel>
                            </div>

                        </div>

                        <asp:Panel ID="pnlObservacion" runat="server" CssClass="mb-4">
                            <asp:Label ID="lblObservacion" runat="server" Text="Observaciones (opcional)" CssClass="form-label" />
                            <asp:TextBox ID="txtObservacion" runat="server" CssClass="form-control" MaxLength="50" />
                        </asp:Panel>

                        <div class="d-flex gap-2">

                            <asp:Button ID="btnGuardar" Text="Guardar dirección"
                                runat="server"
                                CssClass="btn btn-primary px-4"
                                OnClick="btnGuardar_Click" />

                            <asp:HyperLink ID="lnkCancelar" runat="server"
                                Text="Volver"
                                NavigateUrl="~/AdministrarDireccion.aspx"
                                CssClass="btn btn-outline-secondary px-4" />

                        </div>

                        <div class="mt-3">
                            <asp:Label ID="lblRespuesta" runat="server" CssClass="text-danger"/>
                        </div>

                    </asp:Panel>

                </div>

            </div>

        </div>

    </div>

</div>

</asp:Content>
