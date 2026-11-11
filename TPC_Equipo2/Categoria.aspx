<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categoria.aspx.cs" Inherits="TPC_Equipo2.Categoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="row">

            <asp:Repeater ID="repRepeater" runat="server">
                <ItemTemplate>

                    <div class="col-12 col-md-4 mb-3">

                        <div class="card h-100">

                            <img src="<%# Eval("Imagen.ImagenUrl") %>"
                                class="card-img-top"
                                alt="Imagen del producto"
                                style="height: 220px; object-fit: contain; background-color: #f0f0f0;" />

                            <div class="card-body">

                                <h4 class="card-title">
                                    <%# Eval("Nombre") %>
                                </h4>

                                <p class="card-text">
                                    <%# Eval("Descripcion") %>
                                </p>

                                <p class="card-text">
                                    <%# Eval("Precio") %>
                                </p>
                                <asp:LinkButton ID="btnCarrito" runat="server"
                                CssClass="btn btn-primary" OnClick="btnCarrito_Click"
                                CommandArgument='<%# Eval("IdProducto")%>'
                                >Agregar al carrito</asp:LinkButton>
                            </div>

                        </div>

                    </div>

                </ItemTemplate>
            </asp:Repeater>

        </div>
    </div>

</asp:Content>
