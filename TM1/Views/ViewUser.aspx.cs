using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using TM1.Controller;
using TM1.Helpers;
using TM1.Models;

namespace TM1.Views
{
    public partial class ViewUser : System.Web.UI.Page
    {
        User u;
        public void CantAccessView()
        {
            Page.Visible = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            CantACcess.Visible = false;
            if(Session["email"] != null)
            {
                
                u = UserController.GetUser(Session["email"].ToString());

                if(u.RoleID == 1)
                {
                   
                        List<User> users = UserController.GetUsers();

                        for (int i = 0; i < users.Count; i++)
                        {


                            TableRow newRow = new TableRow();
                            TableUser.Controls.Add(newRow);

                            TableCell noCell = new TableCell();
                            noCell.Controls.Add(new Label() { Text = (i + 1) + "." });
                            newRow.Controls.Add(noCell);
                            noCell.CssClass = "td";

                            
                            TableCell nameCell = new TableCell();
                            nameCell.Controls.Add(new Label() { Text = users[i].Name });
                            newRow.Controls.Add(nameCell);
                            nameCell.CssClass = "td";

                            TableCell roleCell = new TableCell();
                            roleCell.Controls.Add(new Label() { Text = users[i].Role.Name });
                            newRow.Controls.Add(roleCell);
                            roleCell.CssClass = "td";


                            TableCell statusCell = new TableCell();
                            Button statusBtn = new Button() { ID = (i + 1) + "_SB" };

                            if (users[i].Status == "Active")
                            {

                                statusBtn.Text = "Active";
                                statusBtn.BackColor = System.Drawing.Color.LimeGreen;

                            }
                            else
                            {

                                statusBtn.Text = "Blocked";
                                statusBtn.BackColor = System.Drawing.Color.Gray;
                            }
                            statusBtn.Click += StatusBtn_Click;
                            statusCell.Controls.Add(statusBtn);
                            newRow.Controls.Add(statusCell);
                            statusCell.CssClass = "td";

                            TableCell idCell = new TableCell();
                            idCell.Controls.Add(new Label() { Text =  users[i].ID.ToString()});
                            newRow.Controls.Add(idCell);
                            idCell.Visible = false;
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

      
      
        private void StatusBtn_Click(object sender, EventArgs e)
        {
            Button currentButton = (Button)sender;
            int selectedindex = 0;
            int.TryParse(currentButton.ID.Substring(0, currentButton.ID.Length - 3), out selectedindex);
            int clickedUserID = int.Parse(((Label)TableUser.Rows[selectedindex].Cells[4].Controls[0]).Text);

            int nowSessionID = u.ID;

            Response response = UserController.UpdateUserActiviation(clickedUserID, nowSessionID);

            if (response.successStatus)
            {
                Response.Redirect(Request.RawUrl);
            }

            else
            {
                CantACcess.Visible = true;
                CantACcess.Text = response.message;
            }
            
            
            
        }
    }
}