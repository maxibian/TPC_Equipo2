<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Prueba.aspx.cs" Inherits="TPC_Equipo2.Prueba" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Repeater ID="repRepeater" runat="server">
        <ItemTemplate>
            <section class="card" style="max-width: 320px">
                <img src="<%#Eval("ImagenUrl") %>" class="card-img-top" alt="...">
                <div class="card-body">
                    <h4 class="card-title"><%#Eval("Nombre") %></h4>
                    <p class="card-text"><%#Eval("Descripcion") %></p>
                </div>
            </section>
        </ItemTemplate>
    </asp:Repeater>

</asp:Content>

