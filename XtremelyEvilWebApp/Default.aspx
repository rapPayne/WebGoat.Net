<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="XtremelyEvilWebApp._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Web vulnerabilities demonstrations</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <p>
            This is the evil website. From it we can launch several attacks. We will use it
            to demonstrate attacks that involve two or more sites.</p>
        <ul>
            <li><a href="Clickjacking.html">Clickjacking</a></li>
            <li><a href="CSRF.html">Cross-site request forgery (CSRF)</a></li>
        </ul>
    </div>
    </form>
</body>
</html>
