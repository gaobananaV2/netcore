<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Layered.WebUI._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:DropDownList AutoPostBack="true" ID="ddlCustomerType" runat="server">
            <asp:ListItem Value="0">Standard</asp:ListItem>
            <asp:ListItem Value="1">Trade</asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="lblErrorMessage" runat="server"></asp:Label>
        <asp:Repeater ID="rptProducts" runat="server">
            <HeaderTemplate>
                <table>
                    <tr>
                        <td>Name</td>
                        <td>RRP</td>
                        <td>Selling Price</td>
                        <td>Discount</td>
                        <td>Savings</td>
                    </tr>
                    <tr>
                        <td colspan="5">
                            <hr />
                        </td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("Name") %></td>
                    <td><%# Eval("RRP")%></td>
                    <td><%# Eval("SellingPrice") %></td>
                    <td><%# Eval("Discount") %></td>
                    <td><%# Eval("Savings") %></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </form>
</body>
</html>
