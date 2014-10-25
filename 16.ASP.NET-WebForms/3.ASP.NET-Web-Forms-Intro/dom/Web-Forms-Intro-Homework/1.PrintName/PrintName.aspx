<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintName.aspx.cs" Inherits="_1.PrintName.PrintName" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <asp:TextBox runat="server" placeholder="Your name here" ID="inputName">
                
            </asp:TextBox>
            <asp:Button runat="server" ID="GenerateName" Text="Generate greeting!" OnClick="GenerateName_Click"/>
        <br/>
        <asp:Label runat="server" Visible="False" ID="greeting"></asp:Label>
    </div>
    </form>
</body>
</html>
