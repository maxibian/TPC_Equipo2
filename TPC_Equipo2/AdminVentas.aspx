<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminVentas.aspx.cs" Inherits="TPC_Equipo2.AdminVentas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="mt-4 mb-4">
        <h2>Administración de ventas</h2>
        <p class="text-muted">
            Consultá y gestioná las ventas de la tienda.
        </p>
    </div>


    <div class="row g-3 mb-3 align-items-end">

        <div class="col-md-3">
            <label class="form-label">N° de venta</label>
            <asp:TextBox ID="txtBuscarVenta" runat="server" CssClass="form-control" placeholder="Número de venta" />
        </div>

        <div class="col-md-3">
            <label class="form-label">Cliente</label>
            <asp:TextBox ID="txtBuscarCliente" runat="server" CssClass="form-control" placeholder="Nombre o apellido" />
        </div>

        <div class="col-md-3">
            <label class="form-label">Estado</label>
            <asp:DropDownList ID="ddlFiltroEstado" runat="server" CssClass="form-select" />
        </div>

        <div class="col-md-3 d-flex gap-2">
            <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" CssClass="btn btn-primary" OnClick="btnFiltrar_Click"/>

            <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="btn btn-outline-secondary" OnClick="btnLimpiar_Click" />
        </div>

    </div>

    <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger d-block mb-3" />



    <div class="card shadow-sm mb-4">
        <div class="card-body">

            <h5 class="card-title mb-3">Ventas registradas
            </h5>

            <div class="table-responsive">

                <asp:GridView ID="gvVentas" runat="server" AutoGenerateColumns="false" DataKeyNames="IdVenta" CssClass="table table-striped table-hover align-middle" GridLines="None" EmptyDataText="No hay ventas para mostrar." OnSelectedIndexChanged="gvVentas_SelectedIndexChanged">

                    <Columns>

                        <asp:BoundField DataField="IdVenta" HeaderText="N° Venta" />

                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" />

                        <asp:BoundField DataField="VentaTotal" HeaderText="Total" DataFormatString="{0:N2}" />

                        <asp:TemplateField HeaderText="Cliente">
                            <ItemTemplate>
                                <%# Eval("Cliente.Nombre") %>
                                <%# Eval("Cliente.Apellido") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Estado">
                            <ItemTemplate>
                                <%# Eval("EstadoVenta.Nombre") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Acciones">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnVerDetalle" runat="server" Text="Ver detalle" CommandName="Select" CssClass="btn btn-sm btn-outline-primary" />
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>

                </asp:GridView>

            </div>
        </div>
    </div>

</asp:Content>
