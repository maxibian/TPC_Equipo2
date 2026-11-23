<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdministrarTarjetas.aspx.cs" Inherits="TPC_Equipo2.AdministrarTarjetas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="container mt-4">

        <h3 class="mb-2">Mis tarjetas</h3>

        <p class="text-muted mb-4">
            Administrá los medios de pago asociados a tu cuenta.
   
        </p>

        <hr />

        <div class="row mt-4">

            <asp:Repeater ID="rptTarjetas" runat="server">

                <ItemTemplate>

                    <div class="col-md-5 col-lg-4 mb-4">

                        <div class="card text-white shadow"
                            style="background-color: #233B67; border-radius: 12px;">

                            <div class="card-body p-4">

                                <div class="d-flex justify-content-between mb-4">
                                    <i class="bi bi-credit-card"
                                        style="font-size: 28px;"></i>

                                    <strong>
                                        <%# Eval("MarcaTarjeta.Nombre") %>
                                </strong>
                                </div>

                                <h5 class="mb-4">
                                    <%# Eval("NumeroTarjeta") %>
                            </h5>

                                <p class="small mb-1">
                                    TITULAR
                           
                                </p>

                                <strong>
                                    <%# Eval("NombreYApellidoTitular") %>
                            </strong>

                                <div class="mt-3 small">
                                    Vencimiento:
                               
                                    <%# Eval("FechaVencimiento", "{0:MM/yy}") %>
                                </div>

                            </div>

                        </div>

                    </div>

                </ItemTemplate>

            </asp:Repeater>

        </div>

    </div>
</asp:Content>
