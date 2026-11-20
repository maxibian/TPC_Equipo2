<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MiCuenta.aspx.cs" Inherits="TPC_Equipo2.MiCuenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-fluid mt-4">

        <div class="d-flex flex-column align-items-start gap-3">

            <a href="AdministrarContrasena.aspx"
                class="btn btn-outline-primary">
                Administrar Contraseña
            </a>

            <a href="HistorialPedidos.aspx"
                class="btn btn-outline-primary">
                Historial Compras
            </a>

            <a href="AdministrarTarjetas.aspx"
                class="btn btn-outline-primary">
                Administrar Tarjetas
            </a>

            <a href="AdministrarDireccion.aspx"
                class="btn btn-outline-primary">
                Administrar Direcciones
            </a>

        </div>

    </div>

</asp:Content>
