<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterForm.aspx.cs" Inherits="TM1.Views.RegisterForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Register</h1>
    <div>
        <asp:Label ID="Label1" runat="server" Text="Email : "></asp:Label>
        <asp:TextBox ID="emailTxt" runat="server"></asp:TextBox>
    </div>
        
    <div>
        <asp:Label ID="Label2" runat="server" Text="Name : "></asp:Label>
        <asp:TextBox ID="nameTxt" runat="server"></asp:TextBox>
    </div>
        
    <div>
        <asp:Label ID="Label3" runat="server" Text="Password : "></asp:Label>
        <asp:TextBox ID="passTxt" TextMode="Password" runat="server"></asp:TextBox>
    </div>
        
    <div>
        <asp:Label ID="Label4" runat="server" Text="Confirm Password : "></asp:Label>
        <asp:TextBox ID="confPassTxt" TextMode="Password" runat="server"></asp:TextBox>
    </div>
        
    <div>
        <asp:Label ID="Label5" runat="server" Text="Gender : "></asp:Label>
        
        <asp:RadioButton ID="Female" runat="server" Text="Female" GroupName ="Label5"/> 
        <asp:RadioButton ID="Male" runat="server" Text="Male" GroupName ="Label5"/>
        
    </div>
        <br />
        
        <asp:Label ID="ErrorLabel" runat="server" Text="Label"></asp:Label>
        <div>
            <asp:Button ID="Button1" runat="server" Text="Register" OnClick="Button1_Click" />
        </div>

    </div>
    </form>
</body>
</html>
