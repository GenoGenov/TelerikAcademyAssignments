<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LinkMenuControl.ascx.cs" Inherits="User_Controls.LinkMenuControl" %>
<ul runat="server" ID="LinkMenu_Wrapper" class="LinkMenu_Wrapper col-md-6 col-md-offset-3">
    <asp:DataList runat="server" ID="LinkMenu" ShowHeader="True" ShowFooter="True">

        <ItemTemplate>
            <li>
                <a href="<%# Eval("Url") %>"><%# Eval("Title") %></a>
            </li>
        </ItemTemplate>
    </asp:DataList>
</ul>
