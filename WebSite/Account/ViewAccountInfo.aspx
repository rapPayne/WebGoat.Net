<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewAccountInfo.aspx.cs" Inherits="WebSite.Account.ViewAccountInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblFeedback" class="failureNotification" runat="server" Text=""></asp:Label>
    <asp:Label ID="lblCustomerInfo" runat="server" Text=""></asp:Label>
</asp:Content>
