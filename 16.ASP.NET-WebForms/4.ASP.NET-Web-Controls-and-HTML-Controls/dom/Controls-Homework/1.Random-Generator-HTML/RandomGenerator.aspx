<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RandomGenerator.aspx.cs" Inherits="_1.Random_Generator_HTML.RandomGenerator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                 <strong id="err" runat="server" Visible="False" style="color: red; font-size: 20px;"></strong>
            </div>
           

            <input type="number" id="min" runat="server" placeholder="Min Value" required="required"/>
            <input type="number" id="max" runat="server" placeholder="Max Value" required="required"/>

            <button id="generate" runat="server" OnServerClick="generate_OnServerClick">Generate</button>
            <br/>
            <br/>
            <strong id="generated" runat="server" Visible="False"></strong>
        </div>
    </form>
</body>
</html>
