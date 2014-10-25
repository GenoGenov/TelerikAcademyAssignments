<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImageToText.aspx.cs" Inherits="WebForms.ImageToText" MasterPageFile="~/Site.Master" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="jumbotron">
            <asp:TextBox runat="server" ID="MyTextBox" CssClass="form-control"></asp:TextBox>
        <br/>
        <asp:Button runat="server" OnClick="RenderImageButtonClicked" Text="Imgfy now!" CssClass="btn btn-lg btn-primary" />

        <br />
        <asp:Image runat="server" ID="MyTextImage" />
    </div>
</asp:Content>
