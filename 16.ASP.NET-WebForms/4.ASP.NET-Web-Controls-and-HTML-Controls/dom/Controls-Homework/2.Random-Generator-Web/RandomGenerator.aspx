<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RandomGenerator.aspx.cs" Inherits="_2.Random_Generator_Web.RandomGenerator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel runat="server">
                   <asp:Label runat="server" Visible="False" ID="err" ForeColor="red" Font-Size="20px"></asp:Label>
        </asp:Panel>
 
        <asp:TextBox runat="server" ID="min" TextMode="Number" placeholder="Min Value"></asp:TextBox>
        <asp:TextBox runat="server" ID="max" TextMode="Number" placeholder="Max Value"></asp:TextBox>
        <asp:Button runat="server" ID="generate" OnClick="generate_OnClick" Text="Generate"/>
        <br/>
        <br/>
        <asp:Label runat="server" ID="generated" Visible="False" Font-Bold="True" Font-Size="20px" ForeColor="#333"></asp:Label>
    </div>
    </form>
</body>
</html>
