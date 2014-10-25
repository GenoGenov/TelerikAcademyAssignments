<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegStudent.aspx.cs" Inherits="_4.Students.RegStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel runat="server" ID="reg">
            <asp:Label runat="server" AssociatedControlID="fName">First Name:</asp:Label>
            <asp:TextBox runat="server" ID="fName"></asp:TextBox>
            <br/>
            <asp:Label runat="server" AssociatedControlID="lName">Last Name:</asp:Label>
            <asp:TextBox runat="server" ID="lName"></asp:TextBox>
            <br/>
            <asp:Label runat="server" AssociatedControlID="fNum">Facoulty Number:</asp:Label>
            <asp:TextBox runat="server" ID="fNum" TextMode="Number"></asp:TextBox>
            <br/>
            <asp:Label runat="server" AssociatedControlID="uni">University:</asp:Label>
            <asp:DropDownList runat="server" ID="uni" AutoPostBack="True" OnSelectedIndexChanged="uni_OnSelectedIndexChanged">
                <asp:ListItem Value="FMI">FMI</asp:ListItem>
                <asp:ListItem Value="UNSS">UNSS</asp:ListItem>
                <asp:ListItem Value="TU">TU</asp:ListItem>
            </asp:DropDownList>
            <br/>
            <asp:Label runat="server" AssociatedControlID="courses">Courses:</asp:Label>
            <br/>
            <asp:ListBox runat="server" SelectionMode="Multiple" ID="courses"/>
            <br/>
            <asp:Button runat="server" ID="btnsubmit" Text="Submit" OnClick="btnsubmit_OnClick"/>
        </asp:Panel>
    </div>
        
    </form>
    
    <asp:Panel runat="server" ID="info">
        
    </asp:Panel>
</body>
</html>
