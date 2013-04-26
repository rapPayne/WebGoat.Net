<%@ Page Title="WebGoat.Net - Change my account info" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="ChangeAccountInfo.aspx.cs" Inherits="WebSite.Account.ChangeAccountInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Change my account info</h1>
    <asp:Label ID="lblFeedback" class="failureNotification" runat="server" Text=""></asp:Label>
    <fieldset class="login">
        <legend>My personal information</legend>
        <asp:Label ID="lblCompanyName" runat="server" Text="Company name"></asp:Label>
        <br />
        <asp:TextBox ID="txtCompanyName" runat="server" CssClass="textEntry"></asp:TextBox><br />
        <asp:Label ID="lblContactTitle" runat="server" Text="My title"></asp:Label>
        <br />
        <asp:TextBox ID="txtContactTitle" runat="server" CssClass="textEntry"></asp:TextBox><br />
    </fieldset>
    <fieldset class="login">
        <legend>My address information</legend>
        <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
        <br />
        <asp:TextBox ID="txtAddress" runat="server" CssClass="textEntry"></asp:TextBox><br />
        <asp:Label ID="lblCity" runat="server" Text="City"></asp:Label>
        <br />
        <asp:TextBox ID="txtCity" runat="server" CssClass="textEntry"></asp:TextBox><br />
        <asp:Label ID="Label2" runat="server" Text="Region/State"></asp:Label>
        <br />
        <asp:TextBox ID="txtRegion" runat="server" CssClass="textEntry"></asp:TextBox><br />
        <asp:Label ID="Label3" runat="server" Text="Postal Code"></asp:Label>
        <br />
        <asp:TextBox ID="txtPostalCode" runat="server" CssClass="textEntry"></asp:TextBox><br />
        <asp:Label ID="Label4" runat="server" Text="Country"></asp:Label>
        <br />
        <asp:TextBox ID="txtCountry" runat="server" CssClass="textEntry"></asp:TextBox>
        <br />
    </fieldset>
    <asp:Button ID="btnUpdate" runat="server" Text="Update" 
        onclick="btnUpdate_Click" />
    <br />
</asp:Content>
