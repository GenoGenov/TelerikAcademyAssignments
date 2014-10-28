<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Bulgaria.aspx.cs" Inherits="Site_Maps_Homework.Bulgaria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row text-center ">
             <h1 class="alert alert-success">
                 <asp:Label runat="server" ID="city"></asp:Label>
             </h1>
        <div class="col-lg-6 col-lg-offset-3" runat="server" ID="cities" Visible="False">
             <ul class="list-group">
                    <li class="list-group-item">
                        <a href="/Bulgaria.aspx?city=Sofia">Sofia</a>
                        
                    </li>
                 <li class="list-group-item">
                     <a href="/Bulgaria.aspx?city=Varna">Varna</a>
                 </li>
                </ul>
        </div>
        </div>
</asp:Content>
