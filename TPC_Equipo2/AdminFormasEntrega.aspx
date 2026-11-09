<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminFormasEntrega.aspx.cs" Inherits="TPC_Equipo2.AdminFormaEntrega" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:GridView ID="gvFormasEntrega" runat="server" DataKeyNames="IdFormaEntrega" AutoGenerateColumns="false" CssClass="table" OnSelectedIndexChanged="gvFormasEntrega_SelectedIndexChanged">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:CheckBoxField HeaderText="Activo" DataField="Estado" />
            <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="Seleccionar" />
        </Columns>
    </asp:GridView>

</asp:Content>
