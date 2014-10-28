<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileUpload.aspx.cs" Inherits="File_Upload_Homework.FileUpload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="Content/kendo/2014.2.716/kendo.common.core.min.css" rel="stylesheet" />
        <link href="Content/kendo/2014.2.716/kendo.common.min.css" rel="stylesheet" />
    <link href="Content/kendo/2014.2.716/kendo.metro.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.9.1.min.js"></script>
    <script src="Scripts/kendo/2014.2.716/jquery.min.js"></script>
    <script src="Scripts/kendo/2014.2.716/kendo.core.min.js"></script>
    <script src="Scripts/kendo/2014.2.716/kendo.ui.core.min.js"></script>
    <script src="Scripts/kendo/2014.2.716/kendo.web.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <input name="uploaded" id="uploaded" type="file" runat="server" />
    
        
        <script>
     $(document).ready(function () {
         $("#uploaded").kendoUpload({
             async: {
                 saveUrl: "Upload",
                 autoUpload: false,
                }
            });
        });
</script>

    </div>
    </form>
</body>
</html>
