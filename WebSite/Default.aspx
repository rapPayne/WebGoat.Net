<%@ Page Title="WebGoat.Net" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WebSite._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Welcome to the WebGoat.Net Store
    </h2>
    <p>
        We focus on supplying high-end specialty restaurants with the best quality foods
        sourced from around the world and shipped to your door.
    </p>
    <h3>
        Today's featured items
    </h3>
    <asp:Label ID="lblProductList" runat="server" />
    <div>
        <h3>
            Why us?</h3>
        <p>
            Because of our priorities:
        </p>
        <ul>
            <li>Our food is delicious. Only the finest and the freshest for you. </li>
            <li>It's all about your restaurant. We make you look good. We'll only sell the star
                of the plate, the conversation piece of the meal, or that hidden ingredient that
                makes a dish's character. </li>
            <li>We listen to you. When you call us we'll answer and take the time that we need with
                you. </li>
            <li>We're real. We don't fake our decisions about what to sell, how to describe the
                food or just about everything else. </li>
        </ul>
    </div>
</asp:Content>
