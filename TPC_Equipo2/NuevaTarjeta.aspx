<%@ page title="" language="C#" masterpagefile="~/Site.Master" autoeventwireup="true" codebehind="NuevaTarjeta.aspx.cs" inherits="TPC_Equipo2.NuevaTarjeta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container py-4">
        <div class="formulario-centrado formulario-chico">

            <h4 class="mb-4 text-center">Agregar tarjeta</h4>

            <div class="mb-3">
                <asp:Label runat="server" Text="Número de tarjeta" AssociatedControlID="txtNumero" CssClass="form-label" />
                <asp:TextBox ID="txtNumero" runat="server" CssClass="form-control" MaxLength="19" placeholder="Ej: 4111 1111 1111 1111" />
                <asp:RegularExpressionValidator runat="server" ControlToValidate="txtNumero"
                    ValidationExpression="^[0-9 ]{13,19}$" ErrorMessage="Ingresá solo números (podés separarlos con espacios)."
                    CssClass="text-danger small" Display="Dynamic" />
            </div>

            <div class="mb-3">
                <asp:Label runat="server" Text="Nombre y apellido del titular" AssociatedControlID="txtTitular" CssClass="form-label" />
                <asp:TextBox ID="txtTitular" runat="server" CssClass="form-control" MaxLength="100" />
            </div>

            <div class="mb-3">
                <asp:Label runat="server" Text="Vencimiento" AssociatedControlID="txtVencimiento" CssClass="form-label" />
                <asp:TextBox ID="txtVencimiento" runat="server" CssClass="form-control" TextMode="Month" />
            </div>

            <div class="row">
                <div class="col mb-3">
                    <asp:Label runat="server" Text="Tipo" AssociatedControlID="ddlTipo" CssClass="form-label" />
                    <asp:DropDownList ID="ddlTipo" runat="server" CssClass="form-select" />
                </div>
                <div class="col mb-3">
                    <asp:Label runat="server" Text="Marca" AssociatedControlID="ddlMarca" CssClass="form-label" />
                    <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-select" />
                </div>
            </div>

            <asp:Label ID="lblRespuesta" runat="server" CssClass="text-danger d-block mb-3" />

            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
            <asp:HyperLink runat="server" Text="Volver" NavigateUrl="~/AdministrarTarjetas.aspx" CssClass="btn btn-outline-secondary" />

        </div>
    </div>

</asp:Content>
