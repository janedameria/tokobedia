<%@ Page Title="Home" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true" CodeBehind="HomeWithMaster3.aspx.cs" Inherits="TM1.Views.HomeWithMaster3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        *{
            padding: 0;
            margin: 0;
        }
         
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
        nav{
            padding: 10px;           
            background-color: lightgrey;
            margin-top: 10px;
        }

        .nav-item{
             padding: 0.5em 0em 0.5em 0.5em; 
             text-decoration: none;
        }
        .LoginBtn{
            position : absolute;
            right : 0;
            top: 10px;
            padding: 4px;
        }
        .welcome-msg{
            font-size: 1em;
            text-align: right;
            position: absolute;
            right: 0;
            top: 10px;
        }
        .LogoutBtn{
            right: 5px;
            margin: 2px 2px;
            padding: 4px;
        }
        .navbtn{
            margin: 3px;
            padding: 5px;
        }

</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
  <div>
      <asp:Button CssClass="LoginBtn" ID="loginBtn" runat="server" Text="Login" OnClick="loginBtn_Click" />
      <asp:Label CssClass="welcome-msg" ID="UserName" runat="server" ></asp:Label>
   </div>
    <div>
       <asp:Button class="LogoutBtn" ID="LogoutBtn" runat="server" Text="Logout" OnClick="Button1_Click" />
    </div>
    <nav>
        <asp:Button ID="ViewProduct" CssClass="navbtn" runat="server" Text="View Product" OnClick="ViewProduct_Click" />
        <asp:Button ID="ViewProfile" CssClass="navbtn" runat="server" Text="View Profile" OnClick="ViewProfile_Click" />
        <asp:Button ID="ViewUser" CssClass="navbtn" runat="server" Text="View User" OnClick="ViewUser_Click" />
        <asp:Button ID="InsertProduct" CssClass="navbtn" runat="server" Text="Insert Product" OnClick="InsertProduct_Click" />
        <asp:Button ID="UpdateProduct" CssClass="navbtn" runat="server" Text="Update Product" OnClick="UpdateProduct_Click" />
        <asp:Button ID="ViewProductType" CssClass="navbtn" runat="server" Text="View Product Type" OnClick="ViewProductType_Click" />
        <asp:Button ID="UpdateProductType" CssClass="navbtn" runat="server" Text="Update Product Type" OnClick="UpdateProductType_Click" />
        <asp:Button ID="InsertProductType" CssClass="navbtn" runat="server" Text="Insert Product Type" OnClick="InsertProductType_Click" />
        <asp:Button ID="ViewPaymentType" CssClass="navbtn" runat="server" Text="View Payment Type" OnClick="ViewPaymentType_Click" />
        <asp:Button ID="UpdatePaymentType" CssClass="navbtn" runat="server" Text="Update Payment Type" OnClick="UpdatePaymentType_Click" />
        <asp:Button ID="InsertPaymentType" CssClass="navbtn" runat="server" Text="Insert Payment Type" OnClick="InsertPaymentType_Click" />
        <asp:Button ID="ViewCart" CssClass="navbtn" runat="server" Text="View Cart" OnClick="ViewCart_Click" />
        <asp:Button ID="TransactionHistory" CssClass="navbtn" runat="server" Text="View Transaction History" OnClick="TransactionHistory_Click" />
        <asp:Button ID="TransactionReport" CssClass="navbtn" runat="server" Text="View Transaction Report" OnClick="TransactionReport_Click" />
    </nav>
    

    <asp:Table ID="ProductTable" runat="server">
            <asp:TableHeaderRow CssClass="th">
                <asp:TableHeaderCell CssClass="td">No.</asp:TableHeaderCell>
                <asp:TableHeaderCell CssClass="td">ID</asp:TableHeaderCell>
                <asp:TableHeaderCell CssClass="td">Name</asp:TableHeaderCell>
                <asp:TableHeaderCell CssClass="td">Stock</asp:TableHeaderCell>
                <asp:TableHeaderCell CssClass="td">Type</asp:TableHeaderCell>
                <asp:TableHeaderCell CssClass="td">Price</asp:TableHeaderCell>
                <asp:TableHeaderCell Id="actionHeader" CssClass="td" ColumnSpan="2">Action</asp:TableHeaderCell>
            </asp:TableHeaderRow>
            
        </asp:Table>
</asp:Content>
