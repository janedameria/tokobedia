using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TM1.Controller;
using TM1.Helpers;
using TM1.Models;

namespace TM1.Views
{
    public partial class ViewPaymentType : System.Web.UI.Page
    {
        public void CantAccessView()
        {
            Page.Visible = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorLabel.Visible = false;

            if (Session["email"] == null)
            {
                Response.Redirect("LoginForm.aspx");
               
            }
            User u = UserController.GetUser(Session["email"].ToString());

           

            if(u.RoleID == 1)
            {
                List<PaymentType> paymentList = PaymentController.GetPaymentTypes();

                for (int i = 0; i < paymentList.Count; i++)
                {
                    TableRow newRow = new TableRow();
                    PaymentTable.Controls.Add(newRow);

                    TableCell numberCell = new TableCell();
                    numberCell.Controls.Add(new Label() { Text = (i + 1) + "." });
                    numberCell.CssClass = "td";
                    newRow.Controls.Add(numberCell);

                    TableCell IDCell = new TableCell();
                    IDCell.Controls.Add(new Label() { Text = (paymentList[i].ID).ToString() });
                    IDCell.CssClass = "td";
                    newRow.Controls.Add(IDCell);

                    TableCell NameCell = new TableCell();
                    NameCell.Controls.Add(new Label() { Text = paymentList[i].Type });
                    NameCell.CssClass = "td";
                    newRow.Controls.Add(NameCell);

                    TableCell UpdateCell = new TableCell();
                    Button UpdateButton = new Button() { Text = "Update", ID = (i + 1) + "_UB" };
                    UpdateButton.Click += UpdateButton_Click;
                    UpdateCell.Controls.Add(UpdateButton);
                    UpdateCell.CssClass = "td";
                    newRow.Controls.Add(UpdateCell);

                    TableCell DeleteCell = new TableCell();
                    Button DeleteButton = new Button() { Text = "Delete", ID = (i + 1) + "_DB" };
                    DeleteButton.Click += DeleteButton_Click;
                    DeleteCell.Controls.Add(DeleteButton);
                    DeleteCell.CssClass = "td";
                    newRow.Controls.Add(DeleteCell);
                }
            }
            else
            {
                CantAccessView();
            }
            
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Button currentButton = (Button)sender;
            int selectedIndex = 0;
            int.TryParse(currentButton.ID.Substring(0, currentButton.ID.Length - 3), out selectedIndex);

            int paymentID = 0;
            paymentID =  int.Parse(((Label)PaymentTable.Rows[selectedIndex].Cells[1].Controls[0]).Text);

            Response response = PaymentController.DeletePayment(paymentID);
            if (response.successStatus)
            {
                Response.Redirect(Request.RawUrl);
            }

            else
            {
                ErrorLabel.Visible = true;
                ErrorLabel.Text = response.message;
            }

        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            Button currentButton = (Button)sender;
            int selectedIndex = 0;
            int.TryParse(currentButton.ID.Substring(0, currentButton.ID.Length - 3), out selectedIndex);

            int paymentID = 0;
            paymentID = int.Parse(((Label)PaymentTable.Rows[selectedIndex].Cells[1].Controls[0]).Text);
            Response.Redirect("UpdatePayment.aspx?paymentID=" + paymentID);
        }

        protected void InsertBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsertPaymentType.aspx");
        }
    }
}