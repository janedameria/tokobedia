<%@ Page Title="Insert Payment Type" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true" CodeBehind="InsertPaymentType.aspx.cs" Inherits="TM1.Views.InsertPaymentType" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Insert Payment Type</h2>

    <div>
        <asp:Label ID="Label1" runat="server" Text="Payment Type : "></asp:Label>
        <asp:TextBox ID="PaymentText" runat="server"></asp:TextBox>
    </div>
    <asp:Label ID="ErrorLabel" runat="server" Text="Label"></asp:Label>
    <div>
        <asp:Button ID="SubmitButton" runat="server" Text="Submit" OnClick="SubmitButton_Click" />
    </div>
</asp:Content>
