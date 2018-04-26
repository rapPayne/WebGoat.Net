<%@ Page ValidateRequest="false" Title="WebGoat.Net blog" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Blog.aspx.cs" Inherits="WebSite.Blog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="/Scripts/Blog.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        WebGoat.Net Blog</h1>
    <div id="entriesDiv" runat="server">
    </div>
</asp:Content>
