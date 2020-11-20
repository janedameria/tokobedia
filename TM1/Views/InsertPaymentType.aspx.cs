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
    public partial class InsertPaymentType : System.Web.UI.Page
    {
        public void CantAccessView()
        {
            Page.Visible = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorLabel.Visible = false;

            if(Session["email"] == null )
            {
                Response.Redirect("LoginForm.aspx");
               
            }
            else
            {
                User u = UserController.GetUser(Session["email"].ToString());
                if (u.RoleID != 1)
                {
                    CantAccessView();
                }
            }
            
            
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            string payment = PaymentText.Text;

            Helpers.Response response = PaymentController.InsertPaymentType(payment);
            if (response.successStatus)
            {
                Response.Redirect("ViewPaymentType.aspx");
            }

            else
            {
                ErrorLabel.Visible = true;
                ErrorLabel.Text = response.message;
            }
        }
    }
}