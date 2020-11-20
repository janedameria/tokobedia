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
    public partial class UpdateProduct : System.Web.UI.Page
    {
        public void CantAccessView()
        {
            Page.Visible = false;
        }
     
        int productid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorLabel.Visible = false;
            if (Session["email"] != null)
            {
                User u = UserController.GetUser(Session["email"].ToString());

                if (u.RoleID == 1)
                {
                    if (Request.QueryString["productid"] != null)
                    {
                        productid = int.Parse(Request.QueryString["productid"]);

                        Product currentProduct = ProductController.GetProduct(productid);
                        if (!IsPostBack)
                        {
                            nameTxt.Text = currentProduct.Name.ToString();
                            stockTxt.Text = currentProduct.Stock.ToString();
                            priceTxt.Text = currentProduct.Price.ToString();
                        }

                    }

                    else
                    {
                        Response.Redirect("ViewProducts.aspx");
                    }
                }

                else
                {
                    CantAccessView();
                }
                

            }

            else
            {
                Response.Redirect("LoginForm.aspx");
            }
        



        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            string name = nameTxt.Text;

            Response response = ProductController.UpdateProduct(productid, name, priceTxt.Text, stockTxt.Text);
            if (response.successStatus)
            {
                Response.Redirect("ViewProducts.aspx");
            }

            else
            {
                ErrorLabel.Visible = true;
                ErrorLabel.Text = response.message;
            }
          
            
        }
    }
}