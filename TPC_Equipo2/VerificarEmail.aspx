<%@ page title="" language="C#" masterpagefile="~/Site.Master" autoeventwireup="true" codebehind="VerificarEmail.aspx.cs" inherits="TPC_Equipo2.VerificarEmail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container py-4">
        <asp:Label ID="lblMensaje" runat="server" CssClass="h4 d-block mb-3" />
        <asp:HyperLink ID="lnkLogin" runat="server" Text="Ir a iniciar sesión" NavigateUrl="~/Login.aspx" CssClass="btn btn-primary" />
    </div>

</asp:Content>
