using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TM1.Controller;
using TM1.Models;

namespace TM1.Views
{
    public partial class TransactionReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null)
            {
                Response.Redirect("LoginForm.aspx");
            }
            User u = UserController.GetUser(Session["email"].ToString());
            if (u.RoleID == 2)
            {
                Page.Visible = false;
            }
            else
            {

                ReportTransaction report = new ReportTransaction();
                CrystalReportViewer1.ReportSource = report;

                report.SetDataSource(GetData());
            }

        }

        private ReportDataset GetData()
        {
            ReportDataset dataset = new ReportDataset();

            ReportDataset.HeaderTransactionDataTable headerTable = dataset.HeaderTransaction;
            ReportDataset.DetailTransactionDataTable detailTable = dataset.DetailTransaction;
            List<Header_Transaction> headerTransactions = TransactionController.GetHeaderTransactions();

            foreach (Header_Transaction ht in headerTransactions)
            {
                DataRow headerRow = headerTable.NewRow();
                headerRow["TransactionID"] = ht.ID;
                headerRow["Username"] = ht.User.Name;
                headerRow["PaymentType"] = ht.PaymentType.Type;
                headerRow["Date"] = ht.Date;
                headerTable.Rows.Add(headerRow);

                foreach (Detail_Transaction dt in ht.Detail_Transactions)
                {
                    DataRow detailRow = detailTable.NewRow();
                    detailRow["ProductName"] = dt.Product.Name;
                    detailRow["ProductPrice"] = dt.Product.Price;
                    detailRow["Quantity"] = dt.Quantity;
                    detailRow["TransactionID"] = dt.TransactionID;
                    detailTable.Rows.Add(detailRow);
                }
            }

            return dataset;
        }
    }
}