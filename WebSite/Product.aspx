<%@ Page Title="WebGoat.Net - Product details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Product.aspx.cs" Inherits="WebSite.Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
    <br />
    <asp:Label ID="lblDescription" runat="server"></asp:Label>

    <asp:Panel ID="pnlAddToCart" Visible="false" runat="server">
        <label>Quantity:</label>
        <asp:TextBox ID="txtQuantity" runat="server" Text="1" AutoCompleteType="Disabled"></asp:TextBox>
        <asp:Button ID="btnAddToCart" runat="server" Text="Add to cart" OnClick="btnAddToCart_Click" />
    </asp:Panel>
    <br />
    <br />
</asp:Content>
