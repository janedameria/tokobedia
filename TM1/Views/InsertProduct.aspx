<%@ Page Title="Insert New Product" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true" CodeBehind="InsertProduct.aspx.cs" Inherits="TM1.Views.InsertProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        h3{
            text-align: center;
            
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   

    <h3>Insert New Product</h3>
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
        <div>
            <asp:Label ID="Label4" runat="server" Text="Product Type: "></asp:Label>
            <asp:DropDownList ID="dropdownlist" runat="server"></asp:DropDownList>
        </div>
        <br />
    <asp:Label ID="ErrorLabel" runat="server" Text="Label"></asp:Label>
        <div>
            <asp:Button ID="Button1" runat="server" Text="Insert"  OnClick="Button1_Click" />
        </div>
        
</asp:Content>
