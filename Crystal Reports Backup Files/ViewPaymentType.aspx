<%@ Page Title="Payment Type" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true" CodeBehind="ViewPaymentType.aspx.cs" Inherits="TM1.Views.ViewPaymentType" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
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

        #InsertBtn {
            float: right;
        }
        .wrapper{
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Payment Type</h2>
    <div style="align-items:center">
        
    </div>
    <div>
        <asp:Button ID="InsertBtn" runat="server" Text="Insert" OnClick="InsertBtn_Click" />
          
          <asp:Table ID="PaymentTable" runat="server">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell CssClass="td">No.</asp:TableHeaderCell>
                <asp:TableHeaderCell CssClass="td">ID</asp:TableHeaderCell>
                <asp:TableHeaderCell CssClass="td">Payment Type</asp:TableHeaderCell>
                <asp:TableHeaderCell CssClass="td" ColumnSpan="2">Action</asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
    </div>
    <div class="wrapper">
        
        <asp:Label ID="ErrorLabel" runat="server" Text="Label"></asp:Label>
    </div>
</asp:Content>
