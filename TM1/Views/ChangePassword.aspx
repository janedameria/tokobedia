<%@ Page Title="Change Password" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="TM1.Views.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div> 
        <asp:Label ID="Label1" runat="server" Text="Old Password : "></asp:Label>
        <asp:TextBox ID="oldPassTxt" runat="server" TextMode="Password"></asp:TextBox>
    </div>
    <div> 
        <asp:Label ID="Label2" runat="server" Text="New Password : "></asp:Label>
        <asp:TextBox ID="newPassTxt" runat="server" TextMode="Password"></asp:TextBox>
    </div>
    <div> 
        <asp:Label ID="Label3" runat="server" Text="Confirm Password : "></asp:Label>
        <asp:TextBox ID="confPassTxt" runat="server" TextMode="Password"></asp:TextBox>
    </div>
    <br />
    <asp:Label ID="ErrorLabel" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:Button ID="SubmitBtn" runat="server" Text="Submit" OnClick="SubmitBtn_Click" />
</asp:Content>
