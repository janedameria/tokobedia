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
    public partial class Profile : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["email"] == null)
            {
                Response.Redirect("LoginForm.aspx");
            }
            User u = UserController.GetUser(Session["email"].ToString());
            
            emailLabel.Text = u.Email;
            nameLabel.Text = u.Name;
            genderLabel.Text = u.Gender;

        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateProfile.aspx");

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangePassword.aspx");
        }
    }
}