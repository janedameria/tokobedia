<%@ Page Title="View Users" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true" CodeBehind="ViewUser.aspx.cs" Inherits="TM1.Views.ViewUser" %>
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
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <h3>List of User(s)</h3>

    <asp:Table ID="TableUser" runat="server">
        <asp:TableHeaderRow CssClass="th">
            <asp:TableHeaderCell CssClass="td">No.</asp:TableHeaderCell>
            <asp:TableHeaderCell CssClass="td">User Name</asp:TableHeaderCell>
            <asp:TableHeaderCell CssClass="td">Role</asp:TableHeaderCell>
            <asp:TableHeaderCell CssClass="td">Status</asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>
    <div style="text-align:center">
        <asp:Label ID="CantACcess" runat="server" Text="Label"></asp:Label>
    </div>
</asp:Content>
