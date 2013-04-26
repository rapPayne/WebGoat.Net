<%@ Page Title="WebGoat.Net - My Account" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="MyAccount.aspx.cs" Inherits="WebSite.MyAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Activities</h2>
    <ul>
        <li><a href="Account/ViewAccountInfo.aspx">My account information</a></li>
        <li><a href="Checkout/Receipts.aspx">My orders</a></li>
        <li><a href="Account/ChangePassword.aspx">Change my password</a></li>
    </ul>
</asp:Content>
