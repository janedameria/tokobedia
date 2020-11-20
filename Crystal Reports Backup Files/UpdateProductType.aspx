<%@ Page Title="Update Product Type" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true" CodeBehind="UpdateProductType.aspx.cs" Inherits="TM1.Views.UpdateProductType" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h2>Update  Product Type</h2>
    <div>
        <asp:Label ID="Label1" runat="server" Text="Product Type : "></asp:Label>
        <asp:TextBox ID="proTypeText" runat="server"></asp:TextBox>
    </div>
      <div>
        <asp:Label ID="Label2" runat="server" Text="Description : "></asp:Label>
        <asp:TextBox ID="descTxt" runat="server"></asp:TextBox>
    </div>
    <br />
    <asp:Label ID="ErrorLabel" runat="server" Text="Label"></asp:Label>
    <div>
        <asp:Button ID="UpdateBtn" runat="server" Text="Update" OnClick="UpdateBtn_Click" />
    </div>
</asp:Content>
