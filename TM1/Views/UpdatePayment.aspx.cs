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
    public partial class UpdatePayment : System.Web.UI.Page
    {
        public void CantAccessView()
        {
            Page.Visible = false;
        }
        int paymentid = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorLabel.Visible = false;
            if (Session["email"] != null)
            {
                User u = UserController.GetUser(Session["email"].ToString());

                if (u.RoleID == 1)
                {
                    if (Request.QueryString["paymentid"] != null)
                    {
                        paymentid = int.Parse(Request.QueryString["paymentid"]);

                        PaymentType currentProduct = PaymentController.GetPayment(paymentid);
                        if (!IsPostBack)
                        {

                            TypeTex.Text = currentProduct.Type.ToString();
                        }

                    }

                    else
                    {
                        Response.Redirect("ViewPaymentType.aspx");
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
            
            string newType = TypeTex.Text;
            Helpers.Response response = PaymentController.UpdatePayment(paymentid, newType);

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