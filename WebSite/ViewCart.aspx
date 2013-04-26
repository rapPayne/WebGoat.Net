<%@ Page Title="My cart" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ViewCart.aspx.cs" Inherits="WebSite.ViewCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script type='text/javascript'>
    $(document).ready(function () {
        $('.quantityInput').change(function () {
            //alert('amount changed');
        });
    });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Your cart</h1>
    <asp:Label ID="lblOutput" runat="server" Text=""></asp:Label>
    <asp:Button ID="btnCheckOut" runat="server" Text="Check out" OnClick="btnCheckOut_Click" />
    <a href="Default.aspx">Keep shopping</a>
</asp:Content>
