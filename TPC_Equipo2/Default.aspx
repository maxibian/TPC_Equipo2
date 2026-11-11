<%@ page title="Home Page" language="C#" masterpagefile="~/Site.Master" autoeventwireup="true" codebehind="Default.aspx.cs" inherits="TPC_Equipo2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="row">

            <asp:Repeater ID="repRepeater" runat="server">
                <itemtemplate>

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

                                </div>

                            </div>

                        </asp:LinkButton>

                    </div>

                </itemtemplate>
            </asp:Repeater>

        </div>
    </div>

</asp:Content>
