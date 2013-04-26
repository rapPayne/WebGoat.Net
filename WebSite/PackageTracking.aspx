<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PackageTracking.aspx.cs"
    MasterPageFile="~/Site.Master" Inherits="WebSite.Redirect" Title="Package Tracking" %>

<asp:Content ID="mainContent" ContentPlaceHolderID="MainContent" runat="server">
    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    <h1>
        Package Tracking</h1>
    <div>
        <asp:Label ID="lblErrorMessage" runat="server" Text="" CssClass="failureNotification"></asp:Label>
    </div>
    <asp:Panel ID="yourOrdersPanel" Visible="false" runat="server">
        <div>
            <p>
                Here are all of your current orders.
            </p>
            <h3>
                Your orders</h3>
            <asp:Label ID="lblOrders" runat="server" Text=""></asp:Label>
        </div>
    </asp:Panel>
    <div>
        <p>
            Please enter your carrier and tracking number below.
        </p>
        <asp:Label ID="lblCarrier" runat="server" Text="Carrier"></asp:Label>
        <br />
        <asp:TextBox ID="txtCarrier" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblTrackingNumber" runat="server" Text="Tracking Number"></asp:Label>
        <br />
        <asp:TextBox ID="txtTrackingNumber" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnTrackPackage" runat="server" Text="Track Package" OnClick="btnTrackPackage_Click" />
    </div>
</asp:Content>
