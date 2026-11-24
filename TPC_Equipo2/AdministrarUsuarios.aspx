<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdministrarUsuarios.aspx.cs" Inherits="TPC_Equipo2.AdministrarUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<div class="container-fluid py-5">

    <div class="row justify-content-center">

        <div class="col-12 col-md-8 col-lg-6 col-xl-5">

            <div class="card shadow-sm border-0 rounded-4">

                <!-- ENCABEZADO -->
                <div class="text-center pt-4 px-4">

                    <i class="bi bi-people text-primary"
                       style="font-size: 2.5rem;"></i>

                    <h3 class="fw-bold mt-2 mb-1">
                        Administrar administradores
                    </h3>

                    <p class="text-muted mb-0">
                        Gestioná los permisos de acceso al panel administrativo.
                    </p>

                </div>

                <hr class="mx-4 mt-4" />

                <!-- FORMULARIO -->
                <div class="card-body px-4 px-md-5 pb-4">

                    <asp:Panel ID="pnlFormulario" runat="server"
                        CssClass="w-100">

                        <asp:Panel ID="pnlEmailUsuario" runat="server"
                            CssClass="mb-3">

                            <asp:Label ID="lblEmailUsuario" runat="server"
                                Text="Correo electrónico"
                                AssociatedControlID="txtEmailUsuario"
                                CssClass="form-label fw-medium" />

                            <asp:TextBox ID="txtEmailUsuario" runat="server"
                                CssClass="form-control"
                                MaxLength="50"
                                placeholder="correo@ejemplo.com" />

                        </asp:Panel>

                        <asp:Panel ID="pnlPassword" runat="server"
                            CssClass="mb-4">

                            <asp:Label ID="lblPassword" runat="server"
                                Text="Contraseña"
                                AssociatedControlID="txtPassword"
                                CssClass="form-label fw-medium" />

                            <asp:TextBox ID="txtPassword" runat="server"
                                CssClass="form-control"
                                MaxLength="50"
                                TextMode="Password" />

                        </asp:Panel>

                        <!-- ACCIONES -->
                        <div class="d-flex gap-2">

                            <asp:Button ID="btnAlta" runat="server"
                                Text="Dar de alta"
                                CssClass="btn btn-primary flex-fill"
                                OnClick="btnAlta_Click" />

                            <asp:Button ID="btnBaja" runat="server"
                                Text="Dar de baja"
                                CssClass="btn btn-outline-danger flex-fill"
                                OnClick="btnBaja_Click" />

                        </div>

                        <div class="text-center mt-3">

                            <asp:HyperLink ID="lnkCancelar" runat="server"
                                Text="Cancelar"
                                NavigateUrl="~/HerramientasAdmin.aspx"
                                CssClass="btn btn-outline-secondary px-4" />

                        </div>

                        <!-- RESPUESTA -->
                        <asp:Panel ID="Panel1" runat="server"
                            CssClass="mt-3">

                            <asp:Label ID="lblRespuesta" runat="server"
                                Text=""
                                CssClass="d-block text-center small" Style="color: red" />

                        </asp:Panel>

                    </asp:Panel>

                </div>

            </div>

        </div>

    </div>

</div>
</asp:Content>
