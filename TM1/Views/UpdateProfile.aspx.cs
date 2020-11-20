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
    public partial class UpdateProfile : System.Web.UI.Page
    {
        private int UserID = 0;
        private User currentUser;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorLabel.Visible = false;
            if(Session["email"] == null)
            {
                Response.Redirect("LoginForm.aspx");
            }

            currentUser = UserController.GetUser(Session["email"].ToString());
            if (currentUser != null)
            {
                if (!IsPostBack)
                {
                    UserID = currentUser.ID;
                    emailTxt.Text = currentUser.Email.ToString();
                    nameTxt.Text = currentUser.Name.ToString();

                    if(currentUser.Gender == "Female")
                    {
                        femaleRadio.Checked = true;
                    }
                    else
                    {
                        maleRadio.Checked = true;
                    }
                }
                
            }

        }
      
            protected void updateBtm_Click(object sender, EventArgs e)
        {
            
            string email = emailTxt.Text;
            string name = nameTxt.Text;
            string gender ="";
            
            if (femaleRadio.Checked)
            {
                gender = "Female";
            }

            else if (maleRadio.Checked)
            {
                gender = "Male";
            }
            Response response = UserController.UpdateUser(currentUser.ID, name, email, gender);
            if(response.successStatus == true)
            {
                Session["email"] = email;
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