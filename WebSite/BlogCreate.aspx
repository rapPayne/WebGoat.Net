<%@ Page Title="WebGoat.Net - Create a blog entry" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="BlogCreate.aspx.cs" Inherits="WebSite.BlogCreate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Create a new blog entry</h1>
    <asp:Label ID="lblFeedback" class="failureNotification" runat="server" Text=""></asp:Label>
    <div>
        Title:<br />
        <asp:TextBox ID="txtTitle" class="blogCreateTitleText" runat="server"></asp:TextBox>
    </div>
    <div>
        Contents:<br />
        <asp:TextBox class="blogCreateContents" ID="txtContents" runat="server" TextMode="MultiLine"></asp:TextBox></div>
    <br />
    <a href="javascript:history.go(-1)" style="float: left;">Cancel</a>
    <asp:Button ID="btnSubmit" Style="float: right;" runat="server" Text="Submit" OnClick="btnSubmit_Click" /><br />
    <asp:Label ID="lblReview" runat="server" Text=""></asp:Label>
</asp:Content>
