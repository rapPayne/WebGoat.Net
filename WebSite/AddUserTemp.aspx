<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="AddUserTemp.aspx.cs" Inherits="WebSite.AddUserTemp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Add a new user</h1>
    <p>
        Note: This page was created for the big staffing push. It is intented to be a temporary
        solution. When the staffing crunch is over, it should be deleted. It is secure,
        though. It will check to make sure that the user is an adminstrative user before
        allowing him/her to add new users.
    </p>
    <div>
        <asp:Label ID="lblErrorMessage" runat="server" Text="" CssClass="failureNotification"></asp:Label>
        <asp:ValidationSummary ID="CheckoutValidationSummary" runat="server" CssClass="failureNotification" />
    </div>
    <fieldset>
        <legend>New user's information</legend>
        <asp:Label ID="lblUsername" runat="server" AssociatedControlID="txtUsername">New user's name:</asp:Label><br />
        <asp:TextBox ID="txtUsername" runat="server" CssClass="textEntry" MaxLength="40"></asp:TextBox>
        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="txtUsername"
            CssClass="failureNotification" ErrorMessage="Name is required." ToolTip="Name is required.">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="lblPassword" runat="server" AssociatedControlID="txtPassword">Password:</asp:Label><br />
        <asp:TextBox ID="txtPassword" runat="server" CssClass="textEntry" MaxLength="60"></asp:TextBox>
        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="txtPassword"
            CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required.">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="lblEmail" runat="server" AssociatedControlID="txtEmail">Email address:</asp:Label><br />
        <asp:TextBox ID="txtEmail" runat="server" CssClass="textEntry" MaxLength="60"></asp:TextBox>
        <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="txtEmail"
            CssClass="failureNotification" ErrorMessage="Email is required." ToolTip="Email is required.">*</asp:RequiredFieldValidator>
        <br />
        <asp:CheckBox ID="chkAdminUser" runat="server" Text="Make this user an administrator."
            ToolTip="Make admin user?" />
    </fieldset>
    <asp:Button ID="btnAddUser" runat="server" Text="Add User" OnClick="btnAddUser_Click" />
</asp:Content>
