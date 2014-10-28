<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UK.aspx.cs" Inherits="Site_Maps_Homework.UK" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row text-center ">
             <h1 class="alert alert-success">
                 <asp:Label runat="server" ID="city"></asp:Label>
             </h1>
        
        <div class="col-lg-6 col-lg-offset-3" runat="server" ID="cities" Visible="False">
             <ul class="list-group">
                    <li class="list-group-item">
                        <a href="/UK.aspx?city=London">London</a>
                        
                    </li>
                 <li class="list-group-item">
                     <a href="/UK.aspx?city=Bristol">Bristol</a>
                 </li>
                   <li class="list-group-item">
                     <a href="/UK.aspx?city=Manchester">Manchester</a>
                 </li>
                </ul>
        </div>
        </div>
</asp:Content>
