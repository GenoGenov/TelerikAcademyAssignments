<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NorthwindData.aspx.cs" Inherits="_1.NorthwindData.NorthwindData" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView runat="server" ID="GV_Employees" AllowPaging="True" AllowSorting="True" DataKeyNames="EmployeeID" DataSourceID="EmployeesDataSource" AutoGenerateColumns="False" OnSelectedIndexChanged="GV_Employees_OnSelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID" ReadOnly="True" SortExpression="EmployeeID" />
                <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                <asp:BoundField DataField="TitleOfCourtesy" HeaderText="TitleOfCourtesy" SortExpression="TitleOfCourtesy" />
                <asp:BoundField DataField="BirthDate" HeaderText="BirthDate" SortExpression="BirthDate" />
                <asp:BoundField DataField="HireDate" HeaderText="HireDate" SortExpression="HireDate" />
                <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                <asp:BoundField DataField="Region" HeaderText="Region" SortExpression="Region" />
                <asp:BoundField DataField="PostalCode" HeaderText="PostalCode" SortExpression="PostalCode" />
                <asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country" />
                <asp:BoundField DataField="HomePhone" HeaderText="HomePhone" SortExpression="HomePhone" />
                <asp:BoundField DataField="Extension" HeaderText="Extension" SortExpression="Extension" />
                <asp:BoundField DataField="ReportsTo" HeaderText="ReportsTo" SortExpression="ReportsTo" />
                <asp:BoundField DataField="PhotoPath" HeaderText="PhotoPath" SortExpression="PhotoPath" />
            </Columns>
        </asp:GridView>
        <asp:EntityDataSource ID="EmployeesDataSource" runat="server" ConnectionString="name=NORTHWNDEntities" DefaultContainerName="NORTHWNDEntities" EnableFlattening="False" EntitySetName="Employees">
        </asp:EntityDataSource>
        
        <asp:ScriptManager runat="server"></asp:ScriptManager>

        <asp:UpdatePanel runat="server" ID="OrderDetailsPanel">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="GV_Employees" EventName="SelectedIndexChanged" />
            </Triggers>
            
            <ContentTemplate>
                

                <asp:GridView runat="server" ID="GV_EmployeeOrders" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="OrderID" DataSourceID="OrdersDataSource">
            <Columns>
                <asp:BoundField DataField="OrderID" HeaderText="OrderID" ReadOnly="True" SortExpression="OrderID" />
                <asp:BoundField DataField="CustomerID" HeaderText="CustomerID" SortExpression="CustomerID" />
                <asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID" SortExpression="EmployeeID" />
                <asp:BoundField DataField="OrderDate" HeaderText="OrderDate" SortExpression="OrderDate" />
                <asp:BoundField DataField="RequiredDate" HeaderText="RequiredDate" SortExpression="RequiredDate" />
                <asp:BoundField DataField="ShippedDate" HeaderText="ShippedDate" SortExpression="ShippedDate" />
                <asp:BoundField DataField="ShipVia" HeaderText="ShipVia" SortExpression="ShipVia" />
                <asp:BoundField DataField="Freight" HeaderText="Freight" SortExpression="Freight" />
                <asp:BoundField DataField="ShipName" HeaderText="ShipName" SortExpression="ShipName" />
                <asp:BoundField DataField="ShipAddress" HeaderText="ShipAddress" SortExpression="ShipAddress" />
                <asp:BoundField DataField="ShipCity" HeaderText="ShipCity" SortExpression="ShipCity" />
                <asp:BoundField DataField="ShipRegion" HeaderText="ShipRegion" SortExpression="ShipRegion" />
                <asp:BoundField DataField="ShipPostalCode" HeaderText="ShipPostalCode" SortExpression="ShipPostalCode" />
                <asp:BoundField DataField="ShipCountry" HeaderText="ShipCountry" SortExpression="ShipCountry" />
            </Columns>
        </asp:GridView>
            </ContentTemplate>
            
            
            
        </asp:UpdatePanel>
        
        <asp:UpdateProgress runat="server" DisplayAfter="20" DynamicLayout="True" >
                <ProgressTemplate>
                    <asp:Image runat="server" ImageUrl="~/Content/updateProgress.gif"/>
                </ProgressTemplate>
            </asp:UpdateProgress>

        <asp:EntityDataSource ID="OrdersDataSource" runat="server" ConnectionString="name=NORTHWNDEntities" DefaultContainerName="NORTHWNDEntities" EnableFlattening="False" EntitySetName="Orders"
            Where="it.EmployeeID=@EmployeeID">
            <WhereParameters>
                <asp:ControlParameter Name="EmployeeID" Type="Int32"
                    ControlID="GV_Employees" />
            </WhereParameters>
        </asp:EntityDataSource>
    </div>
    </form>
</body>
</html>
