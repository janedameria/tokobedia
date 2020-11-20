using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TM1.Controller;

namespace TM1.Views
{
    public partial class LoginForm : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

            Label3.Visible = false;
            if (Session["email"] != null)
            {
                Response.Redirect("HomeWithMaster3.aspx");
            }

           
            if (!IsPostBack)
            {
                if (Request.Cookies["email"] != null && Request.Cookies["password"] != null)
                {
                    emailTxt.Text = Response.Cookies["email"].Value;
                    passTxt.Text = Response.Cookies["password"].Value;
                }
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Label3.Visible = false;
            string email = emailTxt.Text;
            string password = passTxt.Text;

            Helpers.Response response = LoginController.doLogin(email, password);
            if(response.successStatus == true)
            {
                Session["email"] = email;

                if (rememberCheck.Checked)
                {
                    Response.Cookies["email"].Value = email;
                    Response.Cookies["password"].Value = password;
                    Response.Cookies["email"].Expires = DateTime.Now.AddDays(1);
                    Response.Cookies["password"].Expires = DateTime.Now.AddDays(1);
                }
                    Response.Redirect("HomeWithMaster3.aspx");
            }

            else
            {

                Label3.Visible = true;
                Label3.Text = response.message;
            }
            

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterForm.aspx");
        }
    }
}

