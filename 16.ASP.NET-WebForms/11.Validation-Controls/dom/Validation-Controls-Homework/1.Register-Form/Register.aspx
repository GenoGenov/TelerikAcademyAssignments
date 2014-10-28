<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="_1.Register_Form.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-1.10.2.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/bootstrap.theme.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="col-lg-4 col-lg-offset-4">
            <div class="form-horizontal">

                <h1 class="panel-heading text-primary">Register</h1>
                    <asp:ValidationSummary runat="server" ID="summary" ForeColor="Red" />


                <div class="form-group">
                    <h2 class="text-info">Logon Info</h2>
                    <div class="form-group">
                        <asp:TextBox runat="server" ID="username" placeholder="User Name" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server"
                            EnableClientScript="true"
                            ControlToValidate="username"
                            ErrorMessage="Username is required!"
                            Text="*"
                            ID="username_required"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <asp:TextBox runat="server" ID="password" placeholder="Password" TextMode="Password" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator EnableClientScript="true" runat="server" ControlToValidate="password" ErrorMessage="Password field is required!" Text="*"></asp:RequiredFieldValidator>


                        <asp:TextBox runat="server" ID="repeatpassword" placeholder="Repeat Password" TextMode="Password" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" EnableClientScript="true" ControlToValidate="repeatpassword" ErrorMessage="Repeat Password field is required!" Text="*"></asp:RequiredFieldValidator>
                    </div>
                    <asp:CompareValidator runat="server" EnableClientScript="true" ControlToValidate="password" ControlToCompare="repeatpassword" Text="*" ErrorMessage="Password and repeat password must match!"></asp:CompareValidator>
                </div>

                <div class="form-group">
                    <h2 class="text-info">Personal Info</h2>
                    <div class="form-group">
                        <asp:TextBox runat="server" ID="firstname" placeholder="First Name" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator EnableClientScript="true" runat="server" ControlToValidate="firstname" ErrorMessage="First Name field is required!" Text="*"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <asp:TextBox runat="server" ID="lastname" placeholder="Last Name" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator EnableClientScript="true" runat="server" ControlToValidate="lastname" ErrorMessage="Last Name field is required!" Text="*"></asp:RequiredFieldValidator>
                    </div>

                    <div class="form-group">
                        <asp:TextBox runat="server" ID="age" placeholder="Age" CssClass="form-control" TextMode="Number"></asp:TextBox>
                        <asp:RequiredFieldValidator EnableClientScript="true" runat="server" ControlToValidate="age" ErrorMessage="Age field is required!" Text="*"></asp:RequiredFieldValidator>
                        <asp:RangeValidator EnableClientScript="true" runat="server" MinimumValue="18" Type="Integer" MaximumValue="81" ControlToValidate="age" Text="*" ErrorMessage="Age must be between 18 and 81!"></asp:RangeValidator>
                    </div>

                    <div class="form-group">
                        <asp:TextBox runat="server" ID="email" placeholder="Email" CssClass="form-control" TextMode="Email"></asp:TextBox>
                        <asp:RequiredFieldValidator EnableClientScript="true" runat="server" ControlToValidate="email" Text="*" ErrorMessage="Email field is required!"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator runat="server" ValidationExpression="^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$" ControlToValidate="email" EnableClientScript="true" Text="*" ErrorMessage="Invalid email address!"></asp:RegularExpressionValidator>
                    </div>

                </div>


                <div class="form-group">
                    <h2 class="text-info">Address Info</h2>
                    <div class="form-group">
                        <asp:TextBox runat="server" ID="address" placeholder="Local Address" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" EnableClientScript="true" Text="*" ControlToValidate="address" ErrorMessage="Address field is required!"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <asp:TextBox runat="server" ID="phone" placeholder="Phone" CssClass="form-control" TextMode="Phone"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="phone" Text="*" ErrorMessage="Phone field is required!"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator runat="server" ControlToValidate="phone" Text="*" ErrorMessage="Invalid phone number!" ValidationExpression="((\+|00)+[0-4]+[0-9]+)?([ -]?[0-9]{2,15}){1,5}"
                            EnableClientScript="true"></asp:RegularExpressionValidator>
                    </div>

                </div>

                <div class="form-group">
                    <asp:CheckBox runat="server" ID="accept" Text="I Accept" />
                    <asp:CustomValidator runat="server" ID="CheckBoxRequired" EnableClientScript="true"
                        OnServerValidate="CheckBoxRequired_ServerValidate"
                        ClientValidationFunction="CheckBoxRequired_ClientValidate" ErrorMessage="You must accept the agreement" Text="You must select this box to proceed."></asp:CustomValidator>
                </div>

                <div class="form-group">
                    <asp:Button runat="server" UseSubmitBehavior="True" Text="Submit" CssClass="btn btn-lg btn-primary" />
                </div>

            </div>

        </div>

    </form>
    <script>
        function CheckBoxRequired_ClientValidate(sender, e) {
            e.IsValid = jQuery('#accept').is(':checked');
        }
    </script>
</body>
</html>
