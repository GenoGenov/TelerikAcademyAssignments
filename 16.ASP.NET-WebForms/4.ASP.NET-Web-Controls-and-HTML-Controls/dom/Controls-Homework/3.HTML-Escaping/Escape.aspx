<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Escape.aspx.cs" Inherits="_3.HTML_Escaping.Escape" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox runat="server" ID="input"></asp:TextBox>
        <asp:Button runat="server" ID="showText" OnClick="showText_OnClick" Text="Show Transformed"/>
        <br/>
        <hr/>
        <asp:Panel runat="server" Visible="False" ID="results">
            <asp:Label runat="server">Escaped(by default for the textbox):</asp:Label>
            <asp:TextBox ValidateRequestMode="Disabled" runat="server" ID="nonEscaped" ReadOnly="True"></asp:TextBox>
            <hr/>
            <asp:Label runat="server">Escaped(programatically):</asp:Label>
            <asp:Label runat="server" ID="escaped"></asp:Label>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
