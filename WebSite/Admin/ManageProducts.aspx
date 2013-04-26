<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageProducts.aspx.cs" Inherits="WebSite.Admin.ManageProducts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h1>Manage Products</h1>
<div>
<p><a href="/Product/Add">Add</a> a product.</p>
<p>... or select a project from the list below to edit it.</p>
</div>
<asp:Label ID="lblOutput" runat="server"></asp:Label>
</asp:Content>
