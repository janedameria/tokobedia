<%@ Page Title="Update Product" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true" CodeBehind="UpdateProduct.aspx.cs" Inherits="TM1.Views.UpdateProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Update Product</h2>
    <div>
        <asp:Label ID="Label1" runat="server" Text="Name : "></asp:Label>
        <asp:TextBox ID="nameTxt" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Label2" runat="server" Text="Stock : "></asp:Label>
        <asp:TextBox ID="stockTxt" runat="server"></asp:TextBox>
    </div>
     <div>
        <asp:Label ID="Label3" runat="server" Text="Price : "></asp:Label>
        <asp:TextBox ID="priceTxt" runat="server"></asp:TextBox>
    </div>
    <br />
    <asp:Label ID="ErrorLabel" runat="server" Text="Label"></asp:Label>
    <br />

    <asp:Button ID="UpdateBtn" runat="server" Text="Update" OnClick="UpdateBtn_Click" />
</asp:Content>
