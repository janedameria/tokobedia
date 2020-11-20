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
    public partial class ChangePassword : System.Web.UI.Page
    {
        string email;

        protected void Page_Load(object sender, EventArgs e)
        {
           
            if(Session["email"] == null)
            {
                Response.Redirect("LoginForm.aspx");
            }

            email = Session["email"].ToString();
            ErrorLabel.Visible = false;
           

        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            string oldPass = oldPassTxt.Text;
            string newPass = newPassTxt.Text;
            string confPass = confPassTxt.Text;
           

      
            Helpers.Response response = UserController.doChangePassword(email, oldPass, newPass, confPass);
            if (response.successStatus)
            {
                Response.Redirect("Profile.aspx");
            }

            else
            {
                ErrorLabel.Visible = true;
                ErrorLabel.Text = response.message;
            }
        
            
        }
    }
}