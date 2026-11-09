<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminFormasPago.aspx.cs" Inherits="TPC_Equipo2.AdminFormasPago" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:GridView ID="gvFormasPago" runat="server" DataKeyNames="IdFormaPago" AutoGenerateColumns="false" CssClass="table" OnSelectedIndexChanged="gvFormasPago_SelectedIndexChanged">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:CheckBoxField HeaderText="Activo" DataField="Estado" />
            <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="Seleccionar" />
        </Columns>
    </asp:GridView>
    <asp:TextBox ID="txtNombreFormaPago" runat="server"></asp:TextBox>
    <asp:Button ID="btnAgregarFormaPago" runat="server" Text="Agregar" OnClick="btnAgregarFormaPago_Click" />
    <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
</asp:Content>
