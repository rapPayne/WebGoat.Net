<%@ Page Title="Reply to a blog post" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    ValidateRequest="false" CodeBehind="BlogEntryReply.aspx.cs" Inherits="WebSite.BlogEntryReply" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Posting a blog response</h1>
    <asp:Label ID="lblErrorMessage" runat="server" Text=""  CssClass="failureNotification"></asp:Label>

    <asp:Label ID="lblBlogEntry" runat="server" Text=""></asp:Label>
    <h1>Your response</h1>
    <asp:TextBox ID="txtBlogEntryReply" class="BlogEntryReplyText" runat="server" Text="" TextMode="MultiLine"></asp:TextBox><br />
    <a href="javascript:history.go(-1)" style="float: left;">Cancel</a>
    <asp:Button ID='btnSubmit' style="float: right;" runat="server" Text="Submit Response" OnClick="btnSubmit_Click" />
</asp:Content>
