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
    public partial class UpdateCart : System.Web.UI.Page
    {
        int productid = 0;
        User u;
        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorLabel.Visible = false;
            if(Session["email"] != null)
            {
               u = UserController.GetUser(Session["email"].ToString());

                if(u.RoleID == 2)
                {
                    if(Request.QueryString["productid"] != null)
                    {
                        productid = int.Parse(Request.QueryString["productid"]);
                        Cart cart = CartController.GetCart(productid, u.ID);
                        Product pro = ProductController.GetProduct(productid);

                        NameTxt.Text = pro.Name.ToString();
                        PriceTxt.Text = pro.Price.ToString();
                        StockTxt.Text = pro.Stock.ToString();
                        ProductTypeTxt.Text = pro.Product_Types.Name.ToString();

                        if (!IsPostBack)
                        {
                            QuanityTxt.Text = cart.Quantity.ToString();
                        }
                    }

                    else
                    {
                        Response.Redirect("ViewCart.aspx");
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

        protected void Button1_Click(object sender, EventArgs e)
        {
           

            Response response = CartController.UpdateCart(productid, u.ID, QuanityTxt.Text);
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