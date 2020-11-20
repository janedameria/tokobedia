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
    public partial class AddToCart : System.Web.UI.Page
    {
        User u;
        int productid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorLabel.Visible = false;
            if(Session["email"] == null)
            {
                Response.Redirect("LoginForm.aspx");
            }
            u = UserController.GetUser(Session["email"].ToString());
            if(u.RoleID == 2)
            {
                if(Request.QueryString["productid"] != null)
                {
                    productid = int.Parse(Request.QueryString["productid"]);
                    Product product = ProductController.GetProduct(productid);

                
                        NameTxt.Text = product.Name.ToString();
                        PriceTxt.Text = product.Price.ToString();
                        StockTxt.Text = product.Stock.ToString();
                        ProductTypeTxt.Text = product.Product_Types.Name.ToString();
                  
                }

                else
                {
                    Response.Redirect("ViewProduct.aspx");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            Response response = CartController.InsertCart(u.ID, productid, QuanityTxt.Text);

            if (response.successStatus)
            {
                Response.Redirect("ViewCart.aspx");
            }
            else
            {
                ErrorLabel.Visible = true;
                ErrorLabel.Text = response.message;
            }
        }
    }
}