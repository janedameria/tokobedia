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
    public partial class ViewProducts : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorLabel.Visible = false;
            if(Session["email"] == null)
            {
                actionHeader.Visible = false;
                InsetProductBtn.Visible = false;

                List<Product> products = ProductController.GetProducts();


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

            else
            {
                User u = UserController.GetUser(Session["email"].ToString());
                if (u.RoleID == 2)
                {
                   
                    InsetProductBtn.Visible = false;

                }
                List<Product> products = ProductController.GetProducts();


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

                    if(u.RoleID == 2)
                    {
                        TableCell AddToCart = new TableCell();
                        Button AddCartBtn = new Button() { ID = (i + 1) + "_ATC" , Text = "Add to Cart"};
                        AddCartBtn.Click += AddCartBtn_Click;
                        AddToCart.Controls.Add(AddCartBtn);
                        AddToCart.CssClass = "td";
                        newRow.Cells.Add(AddToCart);
                    }
                    if (u.RoleID == 1)
                    {
                        TableCell updateBtnCell = new TableCell();
                        Button UpdateBtn = new Button() { ID = (i + 1) + "_UB", Text = "Update" };
                        UpdateBtn.Click += UpdateButton_Click;
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
                }
               

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

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            Button currentButton = (Button)sender;
            int selectedindex = 0;
            int.TryParse(currentButton.ID.Substring(0, currentButton.ID.Length - 3), out selectedindex);
            int productID = 0;
            productID = int.Parse(((Label)ProductTable.Rows[selectedindex].Cells[1].Controls[0]).Text);

            Response response = ProductController.DeleteProduct(productID);
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

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            Button currentButton = (Button)sender;
            int selectedindex = 0;
            int.TryParse(currentButton.ID.Substring(0, currentButton.ID.Length - 3), out selectedindex);
            int productID = 0;
            productID = int.Parse(((Label)ProductTable.Rows[selectedindex].Cells[1].Controls[0]).Text);
            Response.Redirect("UpdateProduct.aspx?productid=" + productID);

        }
        

        protected void InsetProductBtn_Click1(object sender, EventArgs e)
        {
            Response.Redirect("InsertProduct.aspx");
        }
    }
}