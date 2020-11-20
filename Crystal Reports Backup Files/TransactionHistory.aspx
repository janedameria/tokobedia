<%@ Page Title="Transaction History" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true" CodeBehind="TransactionHistory.aspx.cs" Inherits="TM1.Views.TransactionHistory" %>
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
        
        .t{
            border-bottom: 1px solid black;
            border-right: 1px solid black;
        }

        .tr{
            border-right: 1px solid black;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Transaction History</h2>
        <div class="wrapper">
            <asp:Label ID="NoTransactionText" runat="server" Text="You never made any transactions."></asp:Label>
        </div>
    <div>
        <asp:Table ID="TransactionHistoryTable" runat="server">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell CssClass="th">Transaction Date</asp:TableHeaderCell>
                <asp:TableHeaderCell CssClass="th">Payment Type</asp:TableHeaderCell>
                <asp:TableHeaderCell CssClass="th">Product Name</asp:TableHeaderCell>
                <asp:TableHeaderCell CssClass="th">Quantity</asp:TableHeaderCell>
                <asp:TableHeaderCell CssClass="th">Subtotal</asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>

         <asp:Table ID="TransactionHistoryTableForAdmin" runat="server">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell ID="UserHeader" CssClass="th">User </asp:TableHeaderCell>
                <asp:TableHeaderCell CssClass="th">Transaction Date</asp:TableHeaderCell>
                <asp:TableHeaderCell CssClass="th">Payment Type</asp:TableHeaderCell>
                <asp:TableHeaderCell CssClass="th">Product Name</asp:TableHeaderCell>
                <asp:TableHeaderCell CssClass="th">Quantity</asp:TableHeaderCell>
                <asp:TableHeaderCell CssClass="th">Subtotal</asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
        <div class="wrapper">
            
            <asp:Button ID="TransactionReportButton" runat="server" Text="Transaction Report" OnClick="TransactionReportButton_Click" />
        </div>
    </div>
    <div>

    </div>
</asp:Content>
