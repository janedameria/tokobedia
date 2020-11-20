<%@ Page Title="Update Profile" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true" CodeBehind="UpdateProfile.aspx.cs" Inherits="TM1.Views.UpdateProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Update Profile</h2>
    <div>
        <asp:Label ID="Label1" runat="server" Text="Email :"></asp:Label>
         <asp:TextBox ID="emailTxt" runat="server"></asp:TextBox>
    </div>
    <div>
       <asp:Label ID="Label2" runat="server" Text="Name :"></asp:Label>
        <asp:TextBox ID="nameTxt" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="gender" runat="server" Text="Gender : "></asp:Label>
        <asp:RadioButton ID="femaleRadio" runat="server" Text="Female" GroupName="gender"/>
        <asp:RadioButton ID="maleRadio" runat="server" Text="Male" GroupName="gender"/>

    </div>
    <div>
        <asp:Button ID="updateBtm" runat="server" Text="Update" OnClick="updateBtm_Click" />
    </div>
    <asp:Label ID="ErrorLabel" runat="server" Text="Text"></asp:Label>
</asp:Content>
