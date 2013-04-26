<%@ Page Title="Check out" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Checkout.aspx.cs" Inherits="WebSite.Checkout.Checkout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Check Out</h1>
    <div>
        <asp:Label ID="lblErrorMessage" runat="server" Text="" CssClass="failureNotification"></asp:Label>
        <asp:ValidationSummary ID="CheckoutValidationSummary" runat="server" CssClass="failureNotification"
            ValidationGroup="ShippingValidationGroup" />
    </div>
    <asp:Label ID="lblCart" runat="server" Text=""></asp:Label>
    <fieldset title="Where shall we ship this?">
        <legend>Where shall we ship this?</legend>
        <asp:Label ID="lblShipName" runat="server" AssociatedControlID="txtShipName">Name to ship to:</asp:Label><br />
        <asp:TextBox ID="txtShipName" runat="server" CssClass="textEntry" MaxLength="40"></asp:TextBox>
        <asp:RequiredFieldValidator ID="ShipNameRequired" runat="server" ControlToValidate="txtShipName"
            CssClass="failureNotification" ErrorMessage="Name is required." ToolTip="Name is required."
            ValidationGroup="ShippingValidationGroup">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="lblShipAddress" runat="server" AssociatedControlID="txtShipName">Address:</asp:Label><br />
        <asp:TextBox ID="txtShipAddress" runat="server" CssClass="textEntry" MaxLength="60"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtShipAddress"
            CssClass="failureNotification" ErrorMessage="Address is required." ToolTip="Address is required."
            ValidationGroup="ShippingValidationGroup">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="lblShipCity" runat="server" AssociatedControlID="txtShipCity">City:</asp:Label><br />
        <asp:TextBox ID="txtShipCity" runat="server" CssClass="textEntry" MaxLength="15"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtShipCity"
            CssClass="failureNotification" ErrorMessage="City is required." ToolTip="City is required."
            ValidationGroup="ShippingValidationGroup">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="lblShipRegion" runat="server" AssociatedControlID="txtShipRegion">Region/State:</asp:Label><br />
        <asp:TextBox ID="txtShipRegion" runat="server" CssClass="textEntry" MaxLength="15"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtShipRegion"
            CssClass="failureNotification" ErrorMessage="Region is required." ToolTip="Region is required."
            ValidationGroup="ShippingValidationGroup">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="lblShipPostalCode" runat="server" AssociatedControlID="txtShipName">Zip/Postal Code:</asp:Label><br />
        <asp:TextBox ID="txtShipPostalCode" runat="server" CssClass="textEntry" MaxLength="10"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtShipPostalCode"
            CssClass="failureNotification" ErrorMessage="Postal code is required." ToolTip="Postal Code is required."
            ValidationGroup="ShippingValidationGroup">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="lblShipCountry" runat="server" AssociatedControlID="txtShipName">Country:</asp:Label><br />
        <asp:TextBox ID="txtShipCountry" runat="server" CssClass="textEntry" MaxLength="15"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtShipCountry"
            CssClass="failureNotification" ErrorMessage="Country is required." ToolTip="Country is required."
            ValidationGroup="ShippingValidationGroup">*</asp:RequiredFieldValidator>
    </fieldset>
    <fieldset>
        <legend>How shall we ship it?</legend>
        <asp:Label ID="lblShipVia" runat="server" AssociatedControlID="ddlShipVia">Shipping method:</asp:Label><br />
        <asp:DropDownList ID="ddlShipVia" runat="server" CssClass="textEntry">
        </asp:DropDownList>
    </fieldset>
    <fieldset>
        <legend>How would you like to pay for it?</legend>
        <asp:Label ID="lblCreditCardNumber" runat="server" AssociatedControlID="txtCreditCardNumber">Credit card number:</asp:Label><br />
        <asp:TextBox ID="txtCreditCardNumber" runat="server" CssClass="textEntry" MaxLength="20"></asp:TextBox>
        <asp:RequiredFieldValidator ID="CreditCardNumberRequired" runat="server" ControlToValidate="txtCreditCardNumber"
            CssClass="failureNotification" ErrorMessage="Credit card number is required." ToolTip="Credit card number is required."
            ValidationGroup="ShippingValidationGroup">*</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="CCNRegularExpressionValidator" runat="server" ControlToValidate="txtCreditCardNumber"
            ValidationExpression="^(\d{1,6}[ -]?){3,4}$"
            CssClass="failureNotification" ErrorMessage="That doesn't look like a credit card number." ToolTip="That doesn't look like a credit card number"
            ValidationGroup="ShippingValidationGroup">*</asp:RegularExpressionValidator>
        <br />
        <asp:Label ID="lblExpiry" runat="server" AssociatedControlID="ddlExpiryMonth">Expiration:</asp:Label><br />
        <asp:DropDownList ID="ddlExpiryMonth" runat="server">
            <asp:ListItem>--</asp:ListItem>
            <asp:ListItem Value="01">January</asp:ListItem>
            <asp:ListItem Value="02">February</asp:ListItem>
            <asp:ListItem Value="03">March</asp:ListItem>
            <asp:ListItem Value="04">April</asp:ListItem>
            <asp:ListItem Value="05">May</asp:ListItem>
            <asp:ListItem Value="06">June</asp:ListItem>
            <asp:ListItem Value="07">July</asp:ListItem>
            <asp:ListItem Value="08">August</asp:ListItem>
            <asp:ListItem Value="09">September</asp:ListItem>
            <asp:ListItem Value="10">October</asp:ListItem>
            <asp:ListItem Value="11">November</asp:ListItem>
            <asp:ListItem Value="12">December</asp:ListItem>
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlExpiryMonth"
            CssClass="failureNotification" ErrorMessage="Month is required." ToolTip="Month is required."
            ValidationGroup="ShippingValidationGroup">*</asp:RequiredFieldValidator>
        <asp:DropDownList ID="ddlExpiryYear" runat="server">
            <asp:ListItem>--</asp:ListItem>
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlExpiryYear"
            CssClass="failureNotification" ErrorMessage="Year is required." ToolTip="Year is required."
            ValidationGroup="ShippingValidationGroup">*</asp:RequiredFieldValidator>
        <br />
        <asp:CheckBox ID="chkStoreCCNumber" runat="server" Text="Remember this credit card number for next time I check out."
            ToolTip="Store credit card number?" />
    </fieldset>
<%--    <fieldset title="Security check">
        <legend>Security check</legend>
        <recaptcha:RecaptchaControl ID="recaptcha" runat="server" PublicKey="6Lf8LMkSAAAAAEKR0lkvKnlaU-7IZwy6Ayo3Re8C"
            PrivateKey="6Lf8LMkSAAAAANEpuHz0RMOTa-TtLdxyuDEIScP7" />
    </fieldset>--%>
    <asp:Button ID="btnPlaceOrder" runat="server" Text="Place Order" OnClick="btnPlaceOrder_Click" ValidationGroup="ShippingValidationGroup" />
</asp:Content>
