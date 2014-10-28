<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SlideShow.aspx.cs" Inherits="_3.ImageSlider.Slideshow" %>

<%@ Register Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxtoolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-1.9.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/bootstrap-dialog.min.js"></script>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="Content/bootstrap-dialog.min.css" rel="stylesheet" />
    <style>
        .modal-dialog {
            position: relative;
            width: 80%;
            height: 70%
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <ajaxToolkit:ToolkitScriptManager runat="Server" ID="ToolkitScriptManagerSlider" />
            <br />
            <br />
            <div class="row" runat="server">
                <asp:Image CssClass="img-thumbnail" ID="ImageHolder" runat="server" Width="400px" Height="300px" />
            </div>
            <div class="row text-center">
                <asp:Button ID="ButtonPrevious" runat="server" Text="<" CssClass="btn btn-default" />
                <asp:Button ID="ButtonNext" runat="server" Text=">" CssClass="btn btn-default" />
                <asp:Label runat="server" ID="LabelDescription"></asp:Label>
            </div>


            <asp:Button runat="server" ID="test" />
            <ajaxToolkit:SlideShowExtender ID="ImageHolder_SlideShowExtender" runat="server"
                Enabled="True"
                TargetControlID="ImageHolder"
                SlideShowServiceMethod="GetSlides"
                AutoPlay="False"
                NextButtonID="ButtonNext"
                ImageDescriptionLabelID="LabelDescription"
                PlayButtonText="Play"
                StopButtonText="Stop"
                PreviousButtonID="ButtonPrevious"
                Loop="true" />
        </div>
    </form>
    <script>
        $('#ImageHolder').on('click', function () {
            BootstrapDialog.show({
                title: $('#LabelDescription').text(),
                cssClass:'modal-dialog',
                message: $('<img src="' + $('#ImageHolder').attr('src') + '"' + '/>').attr('width','90%').attr('height','90%'),
                draggable: false
            });
        });
    </script>
</body>
</html>
