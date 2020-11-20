using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TM1.Controller;
using TM1.Models;

namespace TM1.Views
{
    public partial class TransactionHistory : System.Web.UI.Page
    {
        private User u;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["email"] == null)
            {
                Response.Redirect("LoginForm.aspx");
            }
            NoTransactionText.Visible = false;

            u = UserController.GetUser(Session["email"].ToString());
            if(u.RoleID == 2)
            {
                List<Header_Transaction> HeaderTran = TransactionController.GetHeaderTransactionsByUser(u.ID);
                TransactionHistoryTableForAdmin.Visible = false;
                TransactionReportButton.Visible = false;
                if (!HeaderTran.Any())
                {
                    NoTransactionText.Visible = true;
                    TransactionHistoryTable.Visible = false;
                }

                else
                {
                    for (int i = 0; i<HeaderTran.Count; i++)
                    {
                        List<Detail_Transaction> DetailTran = TransactionController.GetDetailTransactionsByTransactionID(HeaderTran[i].ID);

                        for (int j = 0; j < DetailTran.Count; j++)
                        {
                            TableRow newRow = new TableRow();
                            TransactionHistoryTable.Controls.Add(newRow);

                            TableCell DateCell = new TableCell();
                            newRow.Controls.Add(DateCell);
                            DateCell.CssClass = "tr";

                            TableCell PaymentCell = new TableCell();
                            newRow.Controls.Add(PaymentCell);
                            PaymentCell.CssClass = "tr";
                           

                            if (j == 0)
                            {
                                DateCell.Controls.Add(new Label { Text = HeaderTran[i].Date.ToShortDateString() });
                                PaymentCell.Controls.Add(new Label { Text = HeaderTran[i].PaymentType.Type });
                            }
                            if(j == DetailTran.Count - 1)
                            {
                                DateCell.CssClass = "t";
                                PaymentCell.CssClass = "t";
                            }
                            TableCell ProductNameCell = new TableCell();
                            Product pro = ProductController.GetProduct(DetailTran[j].ProductID);                            
                            ProductNameCell.Controls.Add(new Label { Text = pro.Name });
                            ProductNameCell.CssClass = "td";
                            newRow.Controls.Add(ProductNameCell);

                            int Quan = DetailTran[j].Quantity;
                            TableCell QuantityCell = new TableCell();
                            QuantityCell.Controls.Add(new Label { Text = Quan.ToString()});
                            QuantityCell.CssClass = "td";
                            newRow.Controls.Add(QuantityCell);

                            
                            int Subtotal = pro.Price * Quan;

                            TableCell SubtotalCell = new TableCell();
                            SubtotalCell.Controls.Add(new Label { Text = Subtotal.ToString() });
                            SubtotalCell.CssClass = "td";
                            newRow.Controls.Add(SubtotalCell);
                            
                        }


                    }
                       
                }
            }

            else
            {
                TransactionHistoryTable.Visible = false;
                TransactionHistoryTableForAdmin.Visible = true;
                TransactionReportButton.Visible = true;
                List<Header_Transaction> HeaderTran = TransactionController.GetHeaderTransactions();

                for (int i = 0; i < HeaderTran.Count; i++)
                {
                    List<Detail_Transaction> DetailTran = TransactionController.GetDetailTransactionsByTransactionID(HeaderTran[i].ID);

                    for (int j = 0; j < DetailTran.Count; j++)
                    {
                        TableRow newRow = new TableRow();
                        TransactionHistoryTableForAdmin.Controls.Add(newRow);

                        TableCell UserCell = new TableCell();
                        newRow.Controls.Add(UserCell);
                        UserCell.CssClass = "tr";

                        TableCell DateCell = new TableCell();
                        newRow.Controls.Add(DateCell);
                        DateCell.CssClass = "tr";

                        TableCell PaymentCell = new TableCell();
                        newRow.Controls.Add(PaymentCell);
                        PaymentCell.CssClass = "tr";

                        if (j == 0)
                        {
                            UserCell.Controls.Add(new Label { Text = HeaderTran[i].User.Name });
                            DateCell.Controls.Add(new Label { Text = HeaderTran[i].Date.ToShortDateString() });
                            PaymentCell.Controls.Add(new Label { Text = HeaderTran[i].PaymentType.Type });
                        }
                        if (j == DetailTran.Count - 1)
                        {
                            DateCell.CssClass = "t";
                            UserCell.CssClass = "t";
                            PaymentCell.CssClass = "t";
                        }

                        Product pro = ProductController.GetProduct(DetailTran[j].ProductID);
                        TableCell ProductNameCell = new TableCell();
                        ProductNameCell.Controls.Add(new Label { Text = pro.Name });
                        ProductNameCell.CssClass = "td";
                        newRow.Controls.Add(ProductNameCell);

                        int Quan = DetailTran[j].Quantity;
                        TableCell QuantityCell = new TableCell();
                        QuantityCell.Controls.Add(new Label { Text = Quan.ToString() });
                        QuantityCell.CssClass = "td";
                        newRow.Controls.Add(QuantityCell);
                        
                        int Subtotal = pro.Price * Quan;
                        TableCell SubtotalCell = new TableCell();
                        SubtotalCell.Controls.Add(new Label { Text = Subtotal.ToString() });
                        SubtotalCell.CssClass = "td";
                        newRow.Controls.Add(SubtotalCell);
                        
                    }


                }


            }
            
        }

        private void ReportButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void TransactionReportButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("TransactionReport.aspx");
        }
    }
}