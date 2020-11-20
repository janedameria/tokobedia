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
    public partial class ViewCart : System.Web.UI.Page
    {
        private User u;
        protected static List<Cart> carts = new List<Cart>();

        protected int CountTotal (List<int> subTot)
        {
            int tot = 0;
            for(int i = 0; i<subTot.Count; i++)
            {
                tot += subTot[i];
            }

            return tot;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorLabel.Visible = false;
            if(Session["email"] != null)
            {

                u = UserController.GetUser(Session["email"].ToString());
                if(u.RoleID == 2)
                {
                    carts = CartController.GetCartbyUser(u.ID);
                    if(carts.Any())
                    {
                        List<int> subtotal = new List<int>();

                        for (int i = 0; i < carts.Count; i++)
                        {
                            TableRow newRow = new TableRow();
                            CartTable.Controls.Add(newRow);


                            TableCell numberCell = new TableCell();
                            numberCell.Controls.Add(new Label() { Text = (i + 1) + "." });
                            numberCell.CssClass = "td";
                            newRow.Cells.Add(numberCell);
                            
                            TableCell IdCell = new TableCell();
                            IdCell.Controls.Add(new Label() { Text = (carts[i].ProductID).ToString() });
                            IdCell.CssClass = "td";
                            newRow.Cells.Add(IdCell);

                            Product pro = ProductController.GetProduct(carts[i].ProductID);

                          

                            TableCell nameCell = new TableCell();
                            nameCell.Controls.Add(new Label() { Text = pro.Name });
                            nameCell.CssClass = "td";
                            newRow.Cells.Add(nameCell);

                            int price = pro.Price;
                            TableCell priceCell = new TableCell();
                            priceCell.Controls.Add(new Label() { Text = (price).ToString() });
                            priceCell.CssClass = "td";
                            newRow.Cells.Add(priceCell);

                            int quan = carts[i].Quantity;
                            TableCell quanCell = new TableCell();
                            quanCell.Controls.Add(new Label() { Text = (quan).ToString() });
                            quanCell.CssClass = "td";
                            newRow.Cells.Add(quanCell);

                            subtotal.Add(price * quan);

                            TableCell subtotCell = new TableCell();
                            subtotCell.Controls.Add(new Label() { Text = (subtotal[i]).ToString() });
                            subtotCell.CssClass = "td";
                            newRow.Cells.Add(subtotCell);

                            TableCell updateBtnCell = new TableCell();
                            Button UpdateBtn = new Button() { ID = (i + 1) + "_UB", Text = "Update" };
                            UpdateBtn.Click += UpdateBtn_Click; ;
                            updateBtnCell.Controls.Add(UpdateBtn);
                            updateBtnCell.CssClass = "td";
                            newRow.Cells.Add(updateBtnCell);

                            TableCell deleteBtnCell = new TableCell();
                            Button DeleteBtn = new Button() { ID = (i + 1) + "_DB", Text = "Delete" };
                            DeleteBtn.Click += DeleteBtn_Click;
                            deleteBtnCell.Controls.Add(DeleteBtn);
                            deleteBtnCell.CssClass = "td";
                            newRow.Cells.Add(deleteBtnCell);

                        }

                       
                            TableRow newRows = new TableRow();
                            CartTable.Controls.Add(newRows);

                            TableCell TotalCell = new TableCell();
                            TotalCell.Controls.Add(new Label() { Text = "Total : " });
                            TotalCell.CssClass = "td";
                            newRows.Cells.Add(TotalCell);

                            TableCell TotCell = new TableCell();
                            TotCell.Controls.Add(new Label() { Text = CountTotal(subtotal).ToString() });
                            TotCell.CssClass = "td";
                            newRows.Cells.Add(TotCell);
                        
                    }
                    if (!IsPostBack)
                    {
                        List<PaymentType> payment = PaymentController.GetPaymentTypes();
                        for (int i = 0; i < payment.Count; i++)
                        {
                            ListItem list = new ListItem() { Text = payment[i].Type, Value = payment[i].ID.ToString() };
                            dropdownlist.Items.Add(list);
                        }
                        dropdownlist.DataBind();
                    }

                }
                else
                {
                    Page.Visible = false;
                }

            }
            else
            {
                Response.Redirect("LoginForm.aspx");
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            Button currentButton = (Button)sender;
            int selectedindex = 0;
            int.TryParse(currentButton.ID.Substring(0, currentButton.ID.Length - 3), out selectedindex);
            int productID = 0;
            productID = int.Parse(((Label)CartTable.Rows[selectedindex].Cells[1].Controls[0]).Text);

            Response response = CartController.DeleteCart(productID, u.ID);
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

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            Button currentButton = (Button)sender;
            int selectedindex = 0;
            int.TryParse(currentButton.ID.Substring(0, currentButton.ID.Length - 3), out selectedindex);
            int productID = 0;
            productID = int.Parse(((Label)CartTable.Rows[selectedindex].Cells[1].Controls[0]).Text);
            Response.Redirect("UpdateCart.aspx?productid=" + productID);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int PaymentTypeID = int.Parse(dropdownlist.SelectedValue);
            DateTime date = DateTime.Now;

            Response response = CheckoutController.doCheckout(carts, u.ID, PaymentTypeID, date);

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
    }
}