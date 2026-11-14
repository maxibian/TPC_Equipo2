<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetallePedido.aspx.cs" Inherits="TPC_Equipo2.DetallePedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="mt-4 mb-4">
        <h2>Detalle de venta</h2>
        <p class="text-muted">
            Información del pedido seleccionado.
        </p>
    </div>

    <div class="card shadow-sm mb-4">
        <div class="card-body">

            <h5 class="card-title mb-3">Información general
        </h5>

            <div class="row g-3">

                <div class="col-md-6">
                    <strong>Número de venta:</strong>
                    <asp:Label ID="lblIdVenta" runat="server" />
                </div>

                <div class="col-md-6">
                    <strong>Fecha:</strong>
                    <asp:Label ID="lblFecha" runat="server" />
                </div>

                <div class="col-md-6">
                    <strong>Cliente:</strong>
                    <asp:Label ID="lblCliente" runat="server" />
                </div>

                <div class="col-md-6">
                    <strong>Estado:</strong>
                    <asp:Label ID="lblEstado" runat="server" />
                </div>

                <div class="col-md-6">
                    <strong>Forma de pago:</strong>
                    <asp:Label ID="lblFormaPago" runat="server" />
                </div>

                <div class="col-md-6">
                    <strong>Forma de entrega:</strong>
                    <asp:Label ID="lblFormaEntrega" runat="server" />
                </div>

            </div>
        </div>
    </div>


</asp:Content>
