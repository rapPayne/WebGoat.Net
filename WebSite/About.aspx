<%@ Page Title="About WebGoat.Net" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="About.aspx.cs" Inherits="WebSite.About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="owaspTopTen">
        <h2>
            About WebGoat.Net
        </h2>
        <div>
            Welcome to WebGoat.Net, an intentionally insecure ecommerce website created so that
            you and I can learn to create intentionally secure websites. We've introduced vulnerabilities
            covering the OWASP Top Ten as well as several others.
        </div>
        <div>
            See our <a href="FAQ.aspx">FAQ</a> section for details.&nbsp; Probably more information
            than you really care about.</div>
    </div>
    <div class="owaspTopTen">
        <h2>
            A1 - Injection Flaws</h2>
        <div>
            In the BlogCreate.aspx page, The user is able to create a blog entry.&nbsp; Both
            the title and the contents input boxes allow the entry of SQL.&nbsp; The user could
            launch a SQL injection attack.&nbsp; We should harden the site by either parameterizing
            the query or by using the BlogRepository that is in the Infrastructure project.
            This will use Entity Framework which is pre-parameterized.
        </div>
    </div>
    <div class="owaspTopTen">
        <h2>
            A2 - Cross-Site Scripting</h2>
        <div>
            The Blog Entry response page allows markup to be added. The markup will appear in
            the Blog.aspx page as a stored XSS attack.&nbsp; This XSS-vulnerable page can by
            used to lift session cookies by tricking the user into calling http://localhost:8888/StealCookie.aspx?Cookie=[Enter
            cookie value here].</div>
    </div>
    <div class="owaspTopTen">
        <h2>
            A3 - Broken Authentication</h2>
        <div>
            Typical ASP.NET Membership provider model is used on this site which is about as
            secure as you can get.&nbsp; But we can demonstrate its vulnerabilities by sniffing
            the traffic and pulling the cookies that make up the authentication.&nbsp; Those
            can be inserted into another browser session anywhere in the world and have the
            session stolen.&nbsp; We can help to harden the site by performing IP checking.
            (Is the request for a sensitive page coming from the same IP where the user logged
            in?)&nbsp; But the only sure-fire hardening for session-stealing is asking the user
            to re-authenticate on sensitive pages.&nbsp;
        </div>
    </div>
    <div class="owaspTopTen">
        <h2>
            A4 - Insecure Direct Object Reference</h2>
        <div>
            Customers can edit their own info via EditCustomer.aspx/ID=12345. Hackers can change
            the ID to edit another customer's info. We can harden against this by checking the
            identity; if currentUser == ID, let them continue. Otherwise deny.
        </div>
    </div>
    <div class="owaspTopTen">
        <h2>
            A5 - Cross-site request Forgery</h2>
        <div>
            In the Evil site, there is a page (http://localhost:8888/CSRF.html) that mounts a
            CSRF attack.&nbsp; If the user surfs to it while he is logged in on the legitimate
            site, it will load his cart with a particular product and check out using the logged-in
            user&#39;s credentials.&nbsp; To protect against this, add a CAPTCHA to the checkout
            page.</div>
    </div>
    <div class="owaspTopTen">
        <h2>
            A6 - Security misconfiguration</h2>
        <div>
            In the site, we've left a couple of administrative users who are no longer 'employed'
            by us. One of them has a password that is the same as his username. There is a plain
            text file called users.txt with a dump of some users. This gives the attackers an
            idea of which account names to try to crack. This file is accessible by simple http
            from the root of the website. Finally, there is an "old" unused page called AddUserTemp.aspx
            that can add other administrative users.
        </div>
    </div>
    <div class="owaspTopTen">
        <h2>
            A7 - Insecure cryptographic storage</h2>
        <div>
            Credit cards are being stored in an XML file in the main site in clear text.&nbsp;
            If this file were lost or stolen or copied by a developer so he could test offline,
            the customers&#39; card information would be compromised.&nbsp; We should harden
            the site by encrypting this page on write and decrypting it on read.&nbsp; The connectionString
            to the database is also stored in web.config in clear text. That should be encrypted
            through the aspnet_regiis command-line tool.
        </div>
    </div>
    <div class="owaspTopTen">
        <h2>
            A8 - Failure to Restricted URL Access</h2>
        <div>
            To view the details for a product, any user should be able to browse to Products/12345.&nbsp;
            And any administrator can log in and follow the normal path to edit a product.&nbsp;
            This path is not published for regular users but if they type in the direct url
            Products/Edit/12345 they can get to the edit page.&nbsp; To harden the site, put
            that page behind authentication.</div>
    </div>
    <div class="owaspTopTen">
        <h2>
            A9 - Insufficient Transport Layer Protectionn</h2>
        <div>
            Several sensitive forms (Login.aspx, ChangePassword.aspx, Register.aspx) are unprotected.
            When being used, the username and/or password can be read off the wire with a packet
            sniffing program. The solution is to force these pages to connect using SSL/TLS
            (https) only. Also, login cookies are not being written securely. To correct that,
            go to the web.config file and add
            <pre>requireSSL="true"</pre>
            to the &lt;forms&gt; tag.
        </div>
        <div class="owaspTopTen">
            <h2>
                A10 - Unvalidated Redirects and Forwards</h2>
            <div>
                The Package Tracking page allows the user to pass in a carrier and tracking number
                in the querystring. If present, the page simply forwards him to the proper page
                for the carrier. This can be used as an unvalidated redirect.</div>
        </div>
        <div class="owaspTopTen">
            <h2>
                Information Leakage and Improper error handling</h2>
            <div>
                Currently, any unhandled error flows through to the YSOD (The ASP.NET Yellow Screen
                of Death). This exposes our stack and would allow for an automated attack.&nbsp;
                To harden against this, we should create a custom error page and edit web.config
                to show this generic error page whenever any 500-series error is encountered.</div>
        </div>
        <div class="owaspTopTen">
            <h2>
                Clickjacking</h2>
            <div>
                A clickjacker will post an evil page and then trick surfers into visiting it.&nbsp;
                This harmless-looking page has a link that you&#39;d want to click.&nbsp; But on
                top of that link, there is an iframe with its opacity set to zero.&nbsp; The iframe
                holds another page ... the one that the attacker wants you to click on.&nbsp; To
                see a clickjacking attack, first log in to this legitimate site.&nbsp; Then visit
                <a href="http://localhost:8888/Clickjacking.html">http://localhost:8888/Clickjacking.html</a>.&nbsp;
                After you&#39;ve clicked on the video in just the right spot, go back to this site
                and examine your cart.&nbsp; The clickjacker tricked you into adding product number
                eight to your cart.</div>
        </div>
        <div class="owaspTopTen">
            <h2>
                Phishing</h2>
            <div>
                A successful phishing attacker will trick the victim into clicking on a link that
                points to his evil website and tricking the victim into typing in personal information.
                Although there&#39;s nothing that a developer can do to prevent this, we can make
                it more obvious that the attacker&#39;s URL is bogus.&nbsp; We do this by making
                our URLs less complex. To help with that, we can make the URLs less complicated
                by creating routes in global.asax in a register routes method.</div>
        </div>
        <div class="owaspTopTen">
            <h2>
                Other Notes</h2>
            <div>
                When a user registers, he must enter a username and company name. His customerId
                will be based on CompanyName. His contact Name will be his UserName. Customer.ContactName
                cannot be changed once set or the link between ASP.NET's authentication and the
                Northwind tables will be broken.
            </div>
        </div>
</asp:Content>
