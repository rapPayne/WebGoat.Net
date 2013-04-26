<%@ Page Title="WebGoat.Net - Frequently Asked Questions" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="FAQ.aspx.cs" Inherits="WebSite.FAQ" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="Scripts/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="http://code.jquery.com/ui/1.10.2/jquery-ui.js"></script>
    <link rel="Stylesheet" href="http://code.jquery.com/ui/1.10.2/themes/smoothness/jquery-ui.css" />
    <script type="text/javascript">
    $(document).ready(function () {
            $("#accordion").accordion({heightStyle: "content", collapsible: true, active: false });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Frequently Asked Questions</h1>
    <div id="accordion" class="owaspTopTen">
        <h3>So, what's this site all about?</h3>
        <div>
            Welcome to WebGoat.Net. This is an intentionally insecure ecommerce website created
            so that you and I can learn to create intentionally secure websites. We've introduced
            vulnerabilities covering the OWASP Top Ten as well as several others. We're using
            the Northwind Traders database as a base. It was then modified to handle the provider
            framework. And finally, the blog tables were added to allow the blog to be created.
        </div>
        <h3>
            How is the data different from the baseline Northwind database?
        </h3>
        <div>
            First, to make it work with Entity Framework (EF), we had to rename the "Order Details"
            table to "OrderDetails". To do that, we ran the sp_rename stored procedure. Do this:
            <pre>sp_rename [Order Details], OrderDetails</pre>
            <p>
                Then we took the default Northwind database and added some things. First, we made
                it work with the membership provider model by running aspnet_regsql which added
                these tables:</p>
            <ul>
                <li>aspnet_Applications</li>
                <li>aspnet_Membership</li>
                <li>aspnet_Roles</li>
                <li>aspnet_SchemaVersions</li>
                <li>aspnet_Users</li>
                <li>aspnet_UsersInRoles</li>
            </ul>
            <p>
                It also added a bunch of stored procedures.</p>
            <p>
                Then, we had to join the Northwind tables to the membership profile tables.
                We repurposed the Customer.ContactName column to hold the foreign key to the aspnet_Users
                table.&nbsp; To join them, go &quot;aspnet_Users.username == customer.ContactName&quot;.</p>
            <p>
                Then we added these tables manually:</p>
            <ul>
                <li>BlogEntries - to store employees' blog posts.</li>
                <li>BlogResponses - store customers' replies to the blog posts.</li>
                <li>OrderPayments - to record online payments for the orders.</li>
                <li>Shipments - Holds tracking numbers for orders.</li>
            </ul>
            <p>
                We modified certain tables:</p>
            <ul>
                <li>Shippers - Added ServiceName column (nvarchar(50)) and ShippingCostMultiplier column (float).</li>
            </ul>
            <p>
                To make the database seem more relevant, we updated all of the dates. They ranged
                from 1996 - 1998. We added 13 years to make them range from 2009 - 2011. We did
                this like so:</p>
            <pre>
            update Orders set OrderDate = DATEADD(yyyy, 13, OrderDate);
            update Orders set RequiredDate = DATEADD(yyyy, 13, RequiredDate);
            update Orders set ShippedDate = DATEADD(yyyy, 13, ShippedDate);
            </pre>
            <p>
                Then we added some administrative users for A6 - Security Misconfiguration:
            </p>
            <ul>
                <li>User: jeffortson Password: ca$hi$king ("cash is king" with no spaces but dollar signs.)</li>
                <li>User: kmitnick Password: kmitnick</li>
            </ul>
        </div>
    </div>
</asp:Content>
