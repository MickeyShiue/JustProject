using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class bulletin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        string sqlStr = "Select 公告種類,公告內容,發表日期 from 公告";
        ConnDB conns = new ConnDB();

        dt = conns.LoadTable_SQL(sqlStr, "");

        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
}