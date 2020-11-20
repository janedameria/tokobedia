<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginForm.aspx.cs" Inherits="TM1.Views.LoginForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <style>
        .text-danger{
            color: red;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Login</h1>
    <div>
        <asp:Label ID="Label1" runat="server" Text="Email : "></asp:Label>   
        <asp:TextBox ID="emailTxt" runat="server"></asp:TextBox>

    </div>
        
    <div>
        <asp:Label ID="Label2" runat="server" Text="Password : "></asp:Label>
        <asp:TextBox ID="passTxt" TextMode="Password" runat="server"></asp:TextBox>

    </div>
        <br />
        <asp:CheckBox ID="rememberCheck" runat="server" Text="Remember Me" />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />
    </div>
    <div>
        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Dont have an account?"></asp:Label>
        <asp:Button ID="Button2" runat="server" Text="Register" OnClick="Button2_Click" />
    </div>
    </form>
</body>
</html>
