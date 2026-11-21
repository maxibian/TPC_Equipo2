<%@ page title="" language="C#" masterpagefile="~/Site.Master" autoeventwireup="true" codebehind="Categoria.aspx.cs" inherits="TPC_Equipo2.Categoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="row">

            <asp:Repeater ID="repRepeater" runat="server">
                <itemtemplate>

                    <div class="col-12 col-md-4 mb-3">

                        <div class="card h-100">

                            <img src="<%# Eval("Imagen.ImagenUrl") %>"
                                class="card-img-top card_style"
                                alt="Imagen del producto" />

                            <div class="card-body d-flex flex-column">

                                <h5 class="card-title">
                                    <%# Eval("Nombre") %>
                                </h5>

                                <p class="card-text">
                                    <%# Eval("Descripcion") %>
                                </p>

                                <div class="mt-auto">

                                    <h5 class="text-success fw-bold mb-3">
                                        $ <%# Eval("Precio", "{0:N2}") %>
                                    </h5>
                                    <asp:LinkButton ID="btnAgregarAlCarrito" runat="server"
                                        CssClass="btn btn-primary" OnClick="btnAgregarAlCarrito_Click"
                                        CommandArgument='<%# Eval("IdProducto")%>'>
                                        Agregar al carrito</asp:LinkButton>

                                </div>

                            </div>

                        </div>

                    </div>

                </itemtemplate>
            </asp:Repeater>

        </div>
    </div>

</asp:Content>
