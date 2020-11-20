<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertProductType.aspx.cs" Inherits="TM1.Views.InsertProductType" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Insert Product Type</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Insert Product Type</h2>
    <div>
        <div>
            <asp:Label ID="Label1" runat="server" Text="Product Type: "></asp:Label>
            <asp:TextBox ID="productTypeTxt" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label2" runat="server" Text="Description: "></asp:Label>
            <asp:TextBox ID="descTxt" runat="server"></asp:TextBox>
        </div>
        <br />
        <asp:Label ID="ErrorLabel" runat="server" Text="Label"></asp:Label>
        <div>
            <asp:Button ID="Button1" runat="server" Text="Insert" OnClick="Button1_Click1" />
        </div>
    </div>
    </form>
</body>
</html>
