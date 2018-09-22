using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;

public partial class MasterPage : System.Web.UI.MasterPage
{   
    protected void Page_Load(object sender, EventArgs e)
    {
        FormsIdentity formsIdentity = HttpContext.Current.User.Identity as FormsIdentity;
        if (formsIdentity != null)
        {
            IsMemberMenu.Visible = true;
            IsShareMenu.Visible = true;
            IsLoginTag.Visible = false;
        }
        else
        {
            IsMemberMenu.Visible = false;
            IsShareMenu.Visible = false;
            IsLoginTag.Visible = true;
        }
    }
}
