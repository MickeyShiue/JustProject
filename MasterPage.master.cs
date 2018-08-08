using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class MasterPage : System.Web.UI.MasterPage
{
     protected void Page_Load(object sender, EventArgs e)
    {
            try
        {
            if (Session["帳號"] == null)
            {
                foreach (MenuItem item in Menu1.Items)
                {
                    if (item.Text == "會員專區")
                        item.Enabled = false;
                    if (item.Text == "會員登入")
                        item.Enabled = true;
                }
            }
            else
            {
                foreach (MenuItem item in Menu1.Items)
                {
                    if (item.Text == "會員專區")
                        item.Enabled = true;
                    if (item.Text == "會員登入")
                        item.Enabled = false;
                }
            }
        }
        catch
        {

        }
    }
    protected void LinkButton_Login_Click(object sender, EventArgs e)
    {
        if (Session.Count > 1)
        {
            Session.Clear();
            Response.Redirect("FirstPage.aspx");
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }
}
