<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FirstPage.aspx.cs" Inherits="_3.SetCookie.FirstPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button runat="server" Text="Set cookie" ID="setCookie" OnClick="setCookie_OnClick" UseSubmitBehavior="False"/>
        <br/>
        <asp:Label runat="server" ID="msg" Visible="False">Cookie exists! Will expire in 1 minute or until deletion.</asp:Label>
        <asp:Button runat="server" Visible="False" ID="delCookie" OnClick="delCookie_OnClick" Text="Delete cookie" UseSubmitBehavior="False"/>
        <br/>
        <asp:LinkButton runat="server" PostBackUrl="SecondPage.aspx">To Second Page</asp:LinkButton>
    </div>
    </form>
</body>
</html>
