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
    public partial class HomeWithMaster3 : System.Web.UI.Page
    {
        protected void ProductRecommendationForGuest()
        {
            
            actionHeader.Visible = false;

            for (int i = 0; i < products.Count; i++)
            {
                TableRow newRow = new TableRow();
                ProductTable.Controls.Add(newRow);


                TableCell numberCell = new TableCell();
                numberCell.Controls.Add(new Label() { Text = (i + 1) + "." });
                numberCell.CssClass = "td";
                newRow.Cells.Add(numberCell);


                TableCell idCell = new TableCell();
                idCell.Controls.Add(new Label() { Text = ((int)products[i].ID).ToString() });
                idCell.CssClass = "td";
                newRow.Cells.Add(idCell);


                TableCell nameCell = new TableCell();
                nameCell.Controls.Add(new Label() { Text = products[i].Name });
                nameCell.CssClass = "td";
                newRow.Cells.Add(nameCell);

                TableCell stockCell = new TableCell();
                stockCell.Controls.Add(new Label() { Text = ((int)products[i].Stock).ToString() });
                stockCell.CssClass = "td";
                newRow.Cells.Add(stockCell);

                TableCell typeCell = new TableCell();
                typeCell.Controls.Add(new Label() { Text = products[i].Product_Types.Name });
                typeCell.CssClass = "td";
                newRow.Cells.Add(typeCell);

                TableCell quanCell = new TableCell();
                quanCell.Controls.Add(new Label() { Text = (products[i].Price).ToString() });
                quanCell.CssClass = "td";
                newRow.Cells.Add(quanCell);
            }

        }
        protected static List<Product> products = ProductController.RandomizeProduct();

        protected void ProductRecommendationForMember()
        {
            
            for (int i = 0; i < products.Count; i++)
            {
                TableRow newRow = new TableRow();
                ProductTable.Controls.Add(newRow);


                TableCell numberCell = new TableCell();
                numberCell.Controls.Add(new Label() { Text = (i + 1) + "." });
                numberCell.CssClass = "td";
                newRow.Cells.Add(numberCell);


                TableCell idCell = new TableCell();
                idCell.Controls.Add(new Label() { Text = ((int)products[i].ID).ToString() });
                idCell.CssClass = "td";
                newRow.Cells.Add(idCell);


                TableCell nameCell = new TableCell();
                nameCell.Controls.Add(new Label() { Text = products[i].Name });
                nameCell.CssClass = "td";
                newRow.Cells.Add(nameCell);

                TableCell stockCell = new TableCell();
                stockCell.Controls.Add(new Label() { Text = ((int)products[i].Stock).ToString() });
                stockCell.CssClass = "td";
                newRow.Cells.Add(stockCell);

                TableCell typeCell = new TableCell();
                typeCell.Controls.Add(new Label() { Text = products[i].Product_Types.Name });
                typeCell.CssClass = "td";
                newRow.Cells.Add(typeCell);

                TableCell quanCell = new TableCell();
                quanCell.Controls.Add(new Label() { Text = (products[i].Price).ToString() });
                quanCell.CssClass = "td";
                newRow.Cells.Add(quanCell);



                TableCell AddToCart = new TableCell();
                Button AddCartBtn = new Button() { ID = (i + 1) + "_ATC", Text = "Add to Cart" };
                AddCartBtn.Click += AddCartBtn_Click;
                AddToCart.Controls.Add(AddCartBtn);
                AddToCart.CssClass = "td";
                newRow.Cells.Add(AddToCart);

            }

        }

        private void AddCartBtn_Click(object sender, EventArgs e)
        {
            Button currentButton = (Button)sender;
            int selectedIndex = 0;
            int.TryParse(currentButton.ID.Substring(0, currentButton.ID.Length - 4), out selectedIndex);
            int productID = 0;
            productID = int.Parse(((Label)ProductTable.Rows[selectedIndex].Cells[1].Controls[0]).Text);

            Response.Redirect("AddToCart.aspx?productid=" + productID);
        }

       
        private void UserView()
        {

            ViewUser.Visible = false;
            InsertProduct.Visible = false;
            UpdateProduct.Visible = false;
            ViewProductType.Visible = false;
            UpdateProductType.Visible = false;
            InsertProductType.Visible = false;
            InsertPaymentType.Visible = false;
            ViewPaymentType.Visible = false;
            ViewCart.Visible = true;
            ProductRecommendationForMember();
            UpdatePaymentType.Visible = false;
            TransactionHistory.Visible = true;
            TransactionReport.Visible = false;
        }

        private void AdminView()
        {
            ViewUser.Visible = true;
            InsertProduct.Visible = true;
            UpdateProduct.Visible = true;
            ViewProductType.Visible = true;
            UpdateProductType.Visible = true;
            InsertProductType.Visible = true;
            InsertPaymentType.Visible = true;
            ViewPaymentType.Visible = true;
            ViewCart.Visible = false;
            ProductTable.Visible = false;
            UpdatePaymentType.Visible = true;
            TransactionHistory.Visible = true;
            TransactionReport.Visible = true;
        }

        private void GuestView()
        {
            loginBtn.Visible = true;
            ViewProfile.Visible = false;
            UserName.Visible = false;
            LogoutBtn.Visible = false;
            ViewUser.Visible = false;
            InsertProduct.Visible = false;
            UpdateProduct.Visible = false;
            ViewProductType.Visible = false;
            UpdateProductType.Visible = false;
            InsertProductType.Visible = false;
            ViewCart.Visible = false;
            InsertPaymentType.Visible = false;
            ViewPaymentType.Visible = false;
            UpdatePaymentType.Visible = false;
            ProductRecommendationForGuest();
            TransactionHistory.Visible = false;
            TransactionReport.Visible = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null)
            {
                GuestView();

            }
            else
            {
                User u = UserController.GetUser(Session["email"].ToString());

                if (u.RoleID == 2)
                {


                    UserName.Visible = true;
                    UserName.Text = "Welcome, " + u.Name;
                    loginBtn.Visible = false;
                    ViewProfile.Visible = true;
                    LogoutBtn.Visible = true;
                    UserView();
                }
                else
                {
                    UserName.Visible = true;
                    UserName.Text = "Welcome, " + u.Name;
                    loginBtn.Visible = false;
                    ViewProfile.Visible = true;
                    LogoutBtn.Visible = true;

                    AdminView();
                }
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["email"] = null;
            Response.Cookies["email"].Expires = DateTime.Now.AddHours(-1);
            Response.Cookies["password"].Expires = DateTime.Now.AddHours(-1);
            Response.Redirect("LoginForm.aspx");
        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginForm.aspx");
        }
        

        protected void ViewProduct_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewProducts.aspx");
        }

        protected void ViewProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("Profile.aspx");
        }

        protected void ViewUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewUser.aspx");
        }

        protected void InsertProduct_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsertProduct.aspx");
        }

        protected void UpdateProduct_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateProduct.aspx");
        }

        protected void ViewProductType_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewProductType.aspx");
        }

        protected void UpdateProductType_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateProductType.aspx");
        }

        protected void InsertProductType_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsertProductType.aspx");
        }

        protected void ViewPaymentType_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewPaymentType.aspx");
        }

        protected void InsertPaymentType_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsertPaymentType.aspx");
        }

        protected void ViewCart_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewCart.aspx");
        }

        protected void TransactionHistory_Click(object sender, EventArgs e)
        {
            Response.Redirect("TransactionHistory.aspx");
        }

        protected void UpdatePaymentType_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdatePayment.aspx");
        }

        protected void TransactionReport_Click(object sender, EventArgs e)
        {
            Response.Redirect("TransactionReport.aspx");
        }
    }
}