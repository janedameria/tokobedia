using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TM1.Controller;
using TM1.Factories;
using TM1.Helpers;
using TM1.Models;

namespace TM1.Views
{
    public partial class InsertProductType : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorLabel.Visible = false;

            if (Session["email"] != null)
            {
                
                User u = UserController.GetUser(Session["email"].ToString());

                if (u.RoleID != 1)
                {
                    Page.Visible = false;
                }
            }
            else
            {
                Page.Visible = false;
            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {

            string name = productTypeTxt.Text;
            string desc = descTxt.Text;

            Response response = ProductTypeController.InsertProductType(name, desc);
            if (response.successStatus)
            {
                Response.Redirect("ViewProductType.aspx");
            }
            else
            {
                ErrorLabel.Visible = true;
                ErrorLabel.Text = response.message;
            }
      

        }

        
    }
}