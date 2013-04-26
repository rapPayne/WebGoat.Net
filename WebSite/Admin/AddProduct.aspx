<%@ Page Title="WebGoat.Net - Add a new product" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="WebSite.Admin.AddProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Add a new product</h1>
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
    <br />
    <div class="accountInfo">
        <fieldset>
            <legend>Product information</legend>
<%--            <p>
                <asp:Label ID="ProductIdLabel" runat="server" AssociatedControlID="lblProductId">Product Id:</asp:Label><br />
                <asp:Label ID="lblProductId" runat="server" CssClass="textEntry"></asp:Label>
            </p>--%>
            <p>
                <asp:Label ID="lblProductName" runat="server" AssociatedControlID="txtProductName">Product Name:</asp:Label><br />
                <asp:TextBox ID="txtProductName" runat="server" CssClass="textEntry"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtProductName"
                    CssClass="failureNotification" ErrorMessage="Product name is required." ToolTip="Product name is required."
                    >*</asp:RequiredFieldValidator>
            </p>
            <p>
                <asp:Label ID="lblCategoryId" runat="server" AssociatedControlID="ddlCategoryId">Category:</asp:Label><br />
                <asp:DropDownList ID="ddlCategoryId" ClientIDMode="Static" runat="server" CssClass="textEntry"></asp:DropDownList>
            </p>
            <p>
                <asp:Label ID="QuantityPerUnitLabel" runat="server" AssociatedControlID="txtQuantityPerUnit">Quantity per unit:</asp:Label><br />
                <asp:TextBox ID="txtQuantityPerUnit" runat="server" CssClass="textEntry"></asp:TextBox>
                <asp:RequiredFieldValidator ID="QuantityPerUnitRequired" runat="server" ControlToValidate="txtQuantityPerUnit"
                    CssClass="failureNotification" ErrorMessage="E-mail is required." ToolTip="E-mail is required."
                    >*</asp:RequiredFieldValidator>
            </p>
            <p>
                <asp:Label ID="lblUnitPrice" runat="server" AssociatedControlID="txtUnitPrice">Unit price:</asp:Label><br />
                <asp:TextBox ID="txtUnitPrice" runat="server" CssClass="textEntry"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="lblUnitsInStock" runat="server" AssociatedControlID="txtUnitsinStock">Units in stock:</asp:Label><br />
                <asp:TextBox ID="txtUnitsInStock" runat="server" CssClass="textEntry"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="lblUnitsOnOrder" runat="server" AssociatedControlID="txtUnitsOnOrder">Units on order:</asp:Label><br />
                <asp:TextBox ID="txtUnitsOnOrder" runat="server" CssClass="textEntry"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="lblReorderLevel" runat="server" AssociatedControlID="txtReorderLevel">Reorder level:</asp:Label><br />
                <asp:TextBox ID="txtReorderLevel" runat="server" CssClass="textEntry"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="lblSupplierId" runat="server" AssociatedControlID="ddlSupplierId">Supplier:</asp:Label><br />
                <asp:DropDownList ID="ddlSupplierId" ClientIDMode="Static" runat="server" CssClass="textEntry"></asp:DropDownList>
            </p>
            <p>
                <asp:CheckBox id="chkDiscontinued" runat="server" Text="Discontinued" />
            </p>
        </fieldset>
        <p class="submitButton">
            <asp:Button ID="btnSaveChanges" runat="server" Text="Save changes" 
                onclick="btnSaveChanges_Click" />
        </p>
    </div>
</asp:Content>
