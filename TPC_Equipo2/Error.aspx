<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="TPC_Equipo2.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <div class="container d-flex justify-content-center align-items-center"
         style="min-height: 65vh;">

        <div class="card shadow-sm text-center p-5"
             style="max-width: 550px; width: 100%;">

            <div class="mb-3">
                <i class="bi bi-shield-exclamation text-danger"
                   style="font-size: 55px;"></i>
            </div>

            <h2 class="mb-3">
                <asp:Label ID="lblTitulo" runat="server"
                    Text="No pudiste iniciar sesión">
                </asp:Label>
            </h2>

            <p class="text-muted mb-4">
                <asp:Label ID="lblMensaje" runat="server"
                    Text="El correo electrónico o la contraseña ingresados son incorrectos. Verificá tus datos e intentá nuevamente.">
                </asp:Label>
            </p>

            <asp:HyperLink ID="hlVolver" runat="server"
                NavigateUrl="Login.aspx"
                CssClass="btn btn-primary">
                Volver
            </asp:HyperLink>

        </div>

    </div>

</asp:Content>
