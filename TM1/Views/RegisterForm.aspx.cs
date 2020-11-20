using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TM1.Controller;
using TM1.Helpers;
namespace TM1.Views
{
    public partial class RegisterForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorLabel.Visible = false;

            if(Session["email"] != null)
            {
                Response.Redirect("HomeWithMaster3.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string email = emailTxt.Text;
            string name = nameTxt.Text;
            string pass = passTxt.Text;
            string confpass = confPassTxt.Text;
            string status = "Active";
            ErrorLabel.Visible = false;
            int roleID = 2;

            Response response = UserController.InsertUser(roleID, name, email, pass, confpass, Female.Checked, Male.Checked, status);

            if (response.successStatus == true)
            {
                Response.Redirect("LoginForm.aspx");
            }
            else
            {
                ErrorLabel.Visible = true;
                ErrorLabel.Text = response.message;
            }
            

            
        }
    }
}