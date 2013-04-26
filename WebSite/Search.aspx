<%@ Page Title="WebGoat.Net - Search for products" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="WebSite.Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h1>WebGoat.Net - Search for products</h1>
    Enter all or part of the description: <asp:TextBox ID="txtSearch" runat="server" CssClass="textEntry"></asp:TextBox>
    <asp:Button ID="btnGo" runat="server" Text="Search" onclick="LoadProducts" /><br />
    Category: <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="True" 
        onselectedindexchanged="LoadProducts">
        <asp:ListItem Value="0">All categories</asp:ListItem>
    </asp:DropDownList><br />
    <asp:GridView ID="gvProductList" runat="server" AutoGenerateColumns="False" 
        CssClass="productTable">
        <Columns>
            <asp:ImageField DataImageUrlField="ProductId" 
                DataImageUrlFormatString="Images/ProductImages/{0}.jpg" HeaderText="Photo" 
                ReadOnly="True">
                <ControlStyle Height="40px" Width="40px" />
            </asp:ImageField>
            <asp:HyperLinkField DataNavigateUrlFields="ProductId" 
                DataNavigateUrlFormatString="/Product/{0}" DataTextField="ProductName" 
                DataTextFormatString="{0}" HeaderText="Name" />
            <asp:BoundField DataField="QuantityPerUnit" HeaderText="Quantity Per Unit" />
            <asp:BoundField DataField="UnitPrice" DataFormatString="{0:C}" 
                HeaderText="Price" />
            <asp:HyperLinkField DataNavigateUrlFields="ProductId" 
                DataNavigateUrlFormatString="AddToCart.aspx?Id={0}" Text="Add to cart" 
                Visible="False" />
        </Columns>
    </asp:GridView>
</asp:Content>
