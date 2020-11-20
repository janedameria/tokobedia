<%@ Page Title="Update Payment Type" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true" CodeBehind="UpdatePayment.aspx.cs" Inherits="TM1.Views.UpdatePayment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Update Payment</h2>
    <div>
        <asp:Label ID="Label1" runat="server" Text="Type : "></asp:Label>
        <asp:TextBox ID="TypeTex" runat="server"></asp:TextBox>
    </div>
    <br />
    <asp:Label ID="ErrorLabel" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
</asp:Content>
