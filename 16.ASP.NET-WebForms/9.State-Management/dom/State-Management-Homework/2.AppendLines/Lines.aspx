<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Lines.aspx.cs" Inherits="_2.AppendLines.Lines" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox type="text" id="line" runat="server" EnableViewState="False"/>
        <asp:Button runat="server" ID="appendLine" OnClick="appendLine_OnClick" Text="Append"/>
        <br/>
        <br/>
        <asp:Label runat="server" ID="lines" EnableViewState="False"></asp:Label>
    </div>
    </form>
</body>
</html>
