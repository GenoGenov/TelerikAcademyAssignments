<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Chat.aspx.cs" Inherits="_2.SimpleChat.Chat" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-1.9.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/bootstrap-theme.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <h1 class="text-center page-header">Simple Chat</h1>
        
        
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <div class="row form-inline">
            <div class="form-group">
                    <asp:TextBox CssClass="form-control" runat="server" ID="MsgContent" placeholder="Your Message here"></asp:TextBox>
                </div>
                <asp:Button runat="server" ID="CreateMsg" Text="Create message" OnClick="CreateMsg_OnClick" CssClass="btn btn-success"></asp:Button>
            </div>
        <br/>
        </div>
        <asp:UpdatePanel runat="server" ID="UpdateMessages" UpdateMode="Conditional">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="UpdateMessagesTimer" EventName="Tick"/>
            </Triggers>
            <ContentTemplate>
                <asp:ListView runat="server" ID="LV_Messages" SelectMethod="Select" ItemType="_2.SimpleChat.models.Message">
                    <LayoutTemplate>
                        <div class="container jumbotron text-center" runat="server" ID="itemPlaceHolder">
                            
                        </div>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <div class="row">
                            <li class="list-group-item col-md-6 col-md-offset-3">
                            <span class="col-md-8">
                                  <%#: Item.Text %>
                            </span>
                          <span class="col-md-4"><i>Created On: <%#: Item.Created %></i></span>
                        </li>
                        </div>
                        
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        <div class="jumbotron text-center">
                            <span class="alert alert-warning">No messages to show.</span>
                        </div>
                        
                    </EmptyDataTemplate>
                </asp:ListView>
            </ContentTemplate>
        </asp:UpdatePanel>
        
        <asp:Timer runat="server" Interval="500" ID="UpdateMessagesTimer"></asp:Timer>
    </form>
</body>
</html>
