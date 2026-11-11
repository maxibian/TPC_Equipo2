<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPC_Equipo2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="row">

            <asp:Repeater ID="repRepeater" runat="server">
                <ItemTemplate>

                    <div class="col-12 col-md-4 mb-3">

                        <asp:LinkButton
                            ID="btnProducto"
                            runat="server"
                            CssClass="text-decoration-none text-dark"
                            CommandArgument='<%# Eval("IdProducto") %>'
                            OnClick="btnProducto_Click">

                            <div class="card h-100">

                                <img src="<%# Eval("Imagen.ImagenUrl") %>"
                                    class="card-img-top"
                                    alt="Imagen del producto"
                                    style="height: 220px; object-fit: contain; background-color: #f0f0f0;" />

                                <div class="card-body">

                                    <h5 class="card-title">
                                        <%# Eval("Nombre") %>
                                    </h5>

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

                        </asp:LinkButton>

                    </div>

                </ItemTemplate>
            </asp:Repeater>

        </div>
    </div>

</asp:Content>
