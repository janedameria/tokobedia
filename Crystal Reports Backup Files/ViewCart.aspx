<%@ Page Title="Cart" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true" CodeBehind="ViewCart.aspx.cs" Inherits="TM1.Views.ViewCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
         h3{
            margin-top: 60px;
            text-align: center;
            
        }
        table, .th, .td{
             border: 1px solid black;
             text-align: center;
           
        }

        table{
            width: 60%;
            border-collapse: collapse;
            margin-left: auto;
            margin-right: auto;
        }
        
        .th{
            height: 50px;
            text-align: center;
        }
        .wrapper{
           text-align: center;
        }
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Cart</h3>
    <asp:Table ID="CartTable" runat="server">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell CssClass="th">No.</asp:TableHeaderCell>
            <asp:TableHeaderCell CssClass="th">ID</asp:TableHeaderCell>
            <asp:TableHeaderCell CssClass="th">Name</asp:TableHeaderCell>
            <asp:TableHeaderCell CssClass="th">Price</asp:TableHeaderCell>
            <asp:TableHeaderCell CssClass="th">Quantity</asp:TableHeaderCell>
            <asp:TableHeaderCell CssClass="th">Subtotal</asp:TableHeaderCell>
            <asp:TableHeaderCell CssClass="th" ColumnSpan="2">Action</asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>
    <div>
        <%                     
             if (carts == null || carts.Count < 1)
             {                
         %> 
        <h3>Your cart is empty</h3>
         <%
            }
        %>
    </div>
      <div class="wrapper">
          <br />
            <asp:Label ID="Label4" runat="server" Text="Choose Payment : "></asp:Label>
            <asp:DropDownList ID="dropdownlist" runat="server"></asp:DropDownList>
        </div>
    <div class="wrapper">
        <asp:Button ID="CheckoutBtn" runat="server" Text="Checkout" OnClick="Button1_Click" />
        <br />
        <asp:Label ID="ErrorLabel" runat="server" Text="Label"></asp:Label>
    </div>
</asp:Content>
