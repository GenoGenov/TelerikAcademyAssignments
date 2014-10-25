<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_2.DisplayAssemblyLocation._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1 class="page-header">Hello, ASP.NET - From ASPX.</h1>
        <h1 class="page-header" runat="server" id="fromcode"></h1>
        
        <div class="panel panel-default">
            <div class="panel-body">
                <span class="label label-info">Assembly location: </span>
                <strong runat="server" id="location" class="text-info"></strong>
            </div>
        </div>
    </div>

</asp:Content>
