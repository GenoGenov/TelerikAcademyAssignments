<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sumator.aspx.cs" Inherits="_1.WebForms.Sumator" MasterPageFile="~/Site.Master" %>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">    
    <div class="jumbotron">
        <h1 class="page-header text-center">Sumator</h1>
        First number:
    <asp:TextBox ID="TextBoxFirstNum" runat="server" CssClass="form-control"></asp:TextBox>
        <br />
        Second number:  
    <asp:TextBox ID="TextBoxSecondNum" runat="server" CssClass="form-control"></asp:TextBox>
        <br />
        <asp:Button ID="ButtonCalculateSum" runat="server"
            OnClick="ButtonCalculateSum_Click" Text="Calculate Sum" CssClass="btn btn-lg btn-primary" />
        <br />
        Sum:
    <asp:TextBox ID="TextBoxSum" runat="server" CssClass="text-success text-center lead" disabled="disabled"></asp:TextBox>
    </div>
    </asp:Content>
