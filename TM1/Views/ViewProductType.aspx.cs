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
    public partial class ViewProductType : System.Web.UI.Page
    {
        public void CantAccessView()
        {
            Page.Visible = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorLabel.Visible = false;
            if (Session["email"] != null)
            {
                
                User u = UserController.GetUser(Session["email"].ToString());

                if (u.RoleID == 1)
                {
                   
                        List<Product_Type> proType = ProductTypeController.GetProductTypes();

                        for (int i = 0; i < proType.Count; i++)
                        {
                            TableRow newRow = new TableRow();
                            ProductTypeTable.Controls.Add(newRow);

                            TableCell noCell = new TableCell();
                            noCell.Controls.Add(new Label() { Text = (i + 1) + "." });
                            newRow.Cells.Add(noCell);
                            noCell.CssClass = "td";

                            TableCell idCell = new TableCell();
                            idCell.Controls.Add(new Label() { Text = proType[i].ID.ToString() });
                            newRow.Cells.Add(idCell);
                            idCell.CssClass = "td";

                            TableCell nameCell = new TableCell();
                            nameCell.Controls.Add(new Label() { Text = proType[i].Name });
                            newRow.Cells.Add(nameCell);
                            nameCell.CssClass = "td";

                            TableCell descCell = new TableCell();
                            descCell.Controls.Add(new Label() { Text = proType[i].Description });
                            newRow.Cells.Add(descCell);
                            descCell.CssClass = "td";

                            TableCell updateCell = new TableCell();
                            Button UpdateBtn = new Button() { ID = (i + 1) + "_UB", Text = "Update" };
                            UpdateBtn.Click += UpdateBtn_Click;
                            updateCell.Controls.Add(UpdateBtn);
                            updateCell.CssClass = "td";
                            newRow.Cells.Add(updateCell);

                            TableCell deleteCell = new TableCell();
                            Button deleteBtn = new Button() { ID = (i + 1) + "_DB", Text = "Delete" };
                            deleteBtn.Click += DeleteBtn_Click;

                            deleteCell.Controls.Add(deleteBtn);
                            deleteCell.CssClass = "td";
                            newRow.Cells.Add(deleteCell);

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

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            Button currentButton = (Button)sender;
            int selectedIndex = 0;
            int.TryParse(currentButton.ID.Substring(0, currentButton.ID.Length - 3), out selectedIndex);
            int proTypeID = 0;
            proTypeID = int.Parse(((Label)ProductTypeTable.Rows[selectedIndex].Cells[1].Controls[0]).Text);

            Response response = ProductTypeController.DeleteProductType(proTypeID);

            if (response.successStatus)
            {
                Response.Redirect(Request.RawUrl);
            }
            else
            {
                ErrorLabel.Visible = true;
                ErrorLabel.Text = response.message;
            }

        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            Button currentButton = (Button)sender;
            int selectedIndex = 0;
            int.TryParse(currentButton.ID.Substring(0, currentButton.ID.Length - 3), out selectedIndex);
            int proTypeID = 0;
            proTypeID = int.Parse(((Label)ProductTypeTable.Rows[selectedIndex].Cells[1].Controls[0]).Text);
            Response.Redirect("UpdateProductType.aspx?protypeid=" +proTypeID);
          
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsertProductType.aspx");
        }
    }
}