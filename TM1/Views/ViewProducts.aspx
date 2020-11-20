<%@ Page Title="View Products" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true" CodeBehind="ViewProducts.aspx.cs" Inherits="TM1.Views.ViewProducts" %>
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
        #InsetProductBtn{
            background-color: lightgreen;
            float: right;
            padding: 4px;
        }
        .center{
            text-align: center;
        }
        
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h3>List of the Product</h3>
        <asp:button ID="InsetProductBtn" runat="server" text="Insert Product" OnClick="InsetProductBtn_Click1"/>
    </div>
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
  <div class="center">
        <asp:Label ID="ErrorLabel" runat="server" Text="Label"></asp:Label>
  </div>

</asp:Content>
