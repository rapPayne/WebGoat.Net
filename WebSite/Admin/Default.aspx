<%@ Page Title="WebGoat.Net - Administrator Menu" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WebSite.Admin.Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h1>Administrator Functions</h1>
    <a href="/Category/Manage">Manage catgories</a><br />
    <a href="/Customers/Manage">Manage customers</a><br />
    <a href="/Order/Manage">Manage orders</a><br />
    <a href="/Product/Manage">Manage products</a><br />
    <a href="/BlogCreate.aspx">Write a blog entry</a><br />
</asp:Content>
