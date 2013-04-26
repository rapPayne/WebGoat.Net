<%@ Page Title="My receipts" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Receipts.aspx.cs" Inherits="WebSite.Checkout.Receipts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblError" runat="server" CssClass="failureNotification" Text=""></asp:Label>
    <asp:Label ID="lblReceipts" runat="server" Text=""></asp:Label>
</asp:Content>
