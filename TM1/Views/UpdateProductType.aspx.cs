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
    public partial class UpdateProductType : System.Web.UI.Page
    {
        public void CantAccessView()
        {
            Page.Visible = false;
        }
        int protypeid;
        Product_Type pro;

        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorLabel.Visible = false;
            if (Session["email"] != null)
            {
                User u = UserController.GetUser(Session["email"].ToString());

                if (u.RoleID == 1)
                {
                    if (Request.QueryString["protypeid"] != null)
                    {
                        protypeid = int.Parse(Request.QueryString["protypeid"]);
                        pro = ProductTypeController.GetProductType(protypeid);
                        if (!IsPostBack)
                        {
                            proTypeText.Text = pro.Name.ToString();
                            descTxt.Text = pro.Description.ToString();
                        }
                    }
                    else
                    {
                        Response.Redirect("ViewProductType.aspx");
                    }
                }
                else
                {
                    CantAccessView();
                }
            }
            else
            {
                CantAccessView();
            }

        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            string name = proTypeText.Text;
            string desc = descTxt.Text;

            Response response = ProductTypeController.UpdateProductType(protypeid, name, desc);
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