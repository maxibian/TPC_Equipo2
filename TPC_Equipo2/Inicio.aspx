<%@ page title="" language="C#" masterpagefile="~/Site.Master" autoeventwireup="true" codebehind="Inicio.aspx.cs" inherits="TPC_Equipo2.Inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">





    <div class="row row-cols-1 row-cols-md-3 g-4">
        

        <% foreach(dominio.Producto producto in ListaProducto)
      {
        %>
        <div class="col">
            <div class="card h-100">
                <img src="<%: producto.Imagen.ImagenUrl %>" class="card-img-top" alt="<%: producto.Nombre%>">
                <div class="card-body">
                    <h5 class="card-title"><%: producto.Nombre%></h5>
                    <p class="card-text"><%: producto.Descripcion %></p>
                </div>
            </div>
            </div>
            <%
          }  
            %>
        </div>



        <%--<asp:Repeater runat="server" id="repetidor">
        <itemTemplate>
            <div class="col">
                <div class="card">
                    <img src="<%#Eval("ImagenUrl") %>" alt="Alternate Text" />
                    <div class "card-body">
                        <h5>Hola</h5>
                        <p></p>
                    </div>
                </div>
            </div>
        </itemTemplate>

    </asp:Repeater>--%>
</asp:Content>
