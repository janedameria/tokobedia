<%@ Page Title="Add to Cart" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true" CodeBehind="AddToCart.aspx.cs" Inherits="TM1.Views.AddToCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Add To Cart</h3>
    <div>
        <asp:Label ID="Label1" runat="server" Text="Name : "></asp:Label>
        <asp:Label ID="NameTxt" runat="server" Text="Label"></asp:Label>
    </div>
      <div>
        <asp:Label ID="Label2" runat="server" Text="Price : "></asp:Label>
        <asp:Label ID="PriceTxt" runat="server" Text="Label"></asp:Label>
    </div>
     <div>
        <asp:Label ID="Label3" runat="server" Text="Stock : "></asp:Label>
        <asp:Label ID="StockTxt" runat="server" Text="Label"></asp:Label>
    </div>
     <div>
        <asp:Label ID="Label4" runat="server" Text="Product Type : "></asp:Label>
        <asp:Label ID="ProductTypeTxt" runat="server" Text="Label"></asp:Label>
    </div>
    <div>
        <asp:Label ID="Label5" runat="server" Text="Quantity :"></asp:Label>
        <asp:TextBox ID="QuanityTxt" runat="server"></asp:TextBox>
    </div>
    <br />
    <asp:Label ID="ErrorLabel" runat="server" Text="Label"></asp:Label>
    <div>
        <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
    </div>
</asp:Content>
