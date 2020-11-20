using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TM1.Controller;
using TM1.Helpers;
using TM1.Models;

namespace TM1.Views
{
    public partial class InsertProduct : System.Web.UI.Page
    {
        public void CantAccessView()
        {
            Page.Visible = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorLabel.Visible = false;
            if(Session["email"] == null)
            {
                Response.Redirect("LoginForm.aspx");
            }

            User u = UserController.GetUser(Session["email"].ToString());
            if (u.RoleID == 1)
            {
                if (!IsPostBack)
                {
                    List<Product_Type> pro = ProductTypeController.GetProductTypes();
                    for (int i = 0; i < pro.Count; i++)
                    {
                        ListItem list = new ListItem() { Text = pro[i].Name, Value = pro[i].ID.ToString() };
                        dropdownlist.Items.Add(list);
                    }
                    dropdownlist.DataBind();
                }
            }

            else
            {
                CantAccessView();
            }   
      

        }

      

        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = nameTxt.Text;
            int productTypeID = int.Parse(dropdownlist.SelectedValue);

            Response response = ProductController.InsertProduct(productTypeID, name, priceTxt.Text, stockTxt.Text);
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