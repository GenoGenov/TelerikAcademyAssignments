<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewState.aspx.cs" Inherits="_4.DeleteViewState.ViewState" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-2.1.1.min.js"></script>
</head>
<body>
    <strong>Try the submit with and without deleting the viewstate after writing some text in the input field.</strong>
    <form id="form1" runat="server" EnableViewState="True">
    <div>
        <asp:TextBox runat="server" ViewStateMode="Enabled" EnableViewState="True"></asp:TextBox>
    </div>
        <asp:Button runat="server" Text="Submit"/>
        
    </form>
    <br/>
    <br/>
    <button onclick="deleteViewstate()">Delete Viewstate</button>
    <script>
            function deleteViewstate() {
                $('#__VIEWSTATE').remove();
            }
        

    </script>
</body>
</html>
