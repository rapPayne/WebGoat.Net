<%@ Page Title="Receipt" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Receipt.aspx.cs" Inherits="WebSite.Checkout.CheckoutResults" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblError" runat="server" CssClass="failureNotification" Text=""></asp:Label>
    <asp:Label ID="lblOutput" runat="server" Text=""></asp:Label>
    <br />
    <a href="~/Default.aspx" runat="server">Keep shopping</a>
</asp:Content>
