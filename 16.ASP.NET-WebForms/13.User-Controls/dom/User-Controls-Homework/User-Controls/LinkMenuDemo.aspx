<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LinkMenuDemo.aspx.cs" Inherits="User_Controls.LinkMenuDemo" %>

<%@ Register src="/LinkMenu/LinkMenuControl.ascx" tagName="LinkMenu" tagPrefix="lm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <lm:LinkMenu runat="server" ID="MyLinkMenu"></lm:LinkMenu>
    </div>
    </form>
</body>
</html>
