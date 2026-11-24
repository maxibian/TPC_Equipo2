<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdministrarDireccion.aspx.cs" Inherits="TPC_Equipo2.AdministrarDireccion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="container py-4">

    <!-- ENCABEZADO -->
    <div class="d-flex justify-content-between align-items-center mb-4">

        <div>
            <h2 class="fw-bold mb-1">
                Mis direcciones
            </h2>

            <p class="text-muted mb-0">
                Administrá tus domicilios de entrega.
            </p>
        </div>

        <i class="bi bi-geo-alt text-primary"
           style="font-size: 2.5rem;"></i>

    </div>

    <!-- INFORMACIÓN -->
    <div class="alert alert-light border d-flex align-items-start gap-2 mb-4">

        <i class="bi bi-info-circle text-primary fs-5"></i>

        <div>
            <strong>Tus direcciones guardadas</strong>
            <p class="mb-0 text-muted small">
                Podés registrar diferentes domicilios y eliminar
                aquellos que ya no utilices.
            </p>
        </div>

    </div>

    <!-- GRILLA -->
    <div class="table-responsive">

           <asp:GridView
       ID="dgvDireccion"
       runat="server"
       CssClass="table table-hover table-bordered align-middle"
       AutoGenerateColumns="false"
       GridLines="None"
       EmptyDataText="No tenés direcciones registradas.">

       <Columns>

           <asp:BoundField
               DataField="IdDireccion"
               HeaderText="ID"
               Visible="false" />

           <asp:BoundField
               DataField="IdCliente"
               HeaderText="Cliente"
               Visible="false" />

           <asp:BoundField
               DataField="Calle"
               HeaderText="Calle" />

           <asp:BoundField
               DataField="Numero"
               HeaderText="Número" />

           <asp:BoundField
               DataField="Localidad"
               HeaderText="Localidad" />

           <asp:BoundField
               DataField="Provincia"
               HeaderText="Provincia" />

           <asp:BoundField
               DataField="CodigoPostal"
               HeaderText="Código Postal" />

           <asp:TemplateField HeaderText="Observaciones">
               <ItemTemplate>
                   <%# string.IsNullOrWhiteSpace(Eval("Observacion")?.ToString()) ? "No tiene observación" : Eval("Observacion") %>
               </ItemTemplate>
           </asp:TemplateField>

           <asp:TemplateField HeaderText="Eliminar">
               <ItemTemplate>
                   <asp:Button ID="btnEliminar" runat="server"
                       Text="Eliminar"
                       CssClass="btn btn-outline-danger btn-sm"
                       CommandName="EliminarTarjeta"
                       CommandArgument='<%# Eval("IdDireccion") %>'
                       OnClick="btnEliminar_Click" />
               </ItemTemplate>
           </asp:TemplateField>
       </Columns>

   </asp:GridView>

    </div>

    <!-- BOTONES -->
    <div class="d-flex gap-2 mt-3">

        <asp:Button ID="Button1" runat="server"
            Text="Agregar dirección"
            CssClass="btn btn-primary"
            OnClick="btnAgregar_Click" />

        <asp:HyperLink ID="HyperLink1" runat="server"
            Text="Volver"
            NavigateUrl="~/MiCuenta.aspx"
            CssClass="btn btn-outline-secondary" />

    </div>

</div>
    

</asp:Content>
