<%@ Page Title="Profile" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="TM1.Views.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Views/HomeWithMaster3.aspx">Home</asp:HyperLink>
        <asp:Button ID="Button1" runat="server" Text="Udpate Profile" OnClick="UpdateBtn_Click" />
        <asp:Button ID="Button2" runat="server" Text="Change Password" OnClick="Button2_Click" />
    </nav>
    
   <div>
       Email : <asp:Label ID="emailLabel" runat="server" Text="Label"></asp:Label>
   </div> 
    <div>
       Name : <asp:Label ID="nameLabel" runat="server" Text="Label"></asp:Label>
   </div>
   <div>
       Gender : <asp:Label ID="genderLabel" runat="server" Text="Label"></asp:Label>
   </div>
</asp:Content>
