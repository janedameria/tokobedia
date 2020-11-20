<%@ Page Title="View Product Type" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true" CodeBehind="ViewProductType.aspx.cs" Inherits="TM1.Views.ViewProductType" %>
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
        .insertbtn{
            background-color: lightgreen;
            float: right;
            padding: 4px;
        }
        .wrapper{
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div>
        <h3>List of the Product Type</h3>
         <asp:Button CssClass="insertbtn" ID="Button1" runat="server" Text="Insert Product Type" OnClick="Button1_Click" />
    </div>
        <asp:Table ID="ProductTypeTable" runat="server">
            <asp:TableHeaderRow CssClass="th">
                <asp:TableHeaderCell CssClass="td">No.</asp:TableHeaderCell>      
                <asp:TableHeaderCell CssClass="td">ID</asp:TableHeaderCell>
                <asp:TableHeaderCell CssClass="td">Name</asp:TableHeaderCell>
                <asp:TableHeaderCell CssClass="td">Description</asp:TableHeaderCell>
                <asp:TableHeaderCell CssClass="td" ColumnSpan="2">Action</asp:TableHeaderCell>
            </asp:TableHeaderRow>
            
        </asp:Table>
    <div class="wrapper">
        <asp:Label ID="ErrorLabel" runat="server" Text="Label"></asp:Label>
    </div>
</asp:Content>
