using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Select : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button_Search_Click(object sender, EventArgs e)
    {
        ConnDB conns = new ConnDB();
        DataTable ch = new DataTable();
        string txt = this.TextBox_Search.Text;

        if (TextBox_Search.Text == "")
        {
            Response.Write("<script language=javascript>alert('請輸入搜尋內容')</script>");
            Response.Write("<script language=javascript>window.location.href='Select.aspx'</script>");
        }
        else
        {
            //ConnDB conns = new ConnDB();
            //DataTable dt = new DataTable();
            //string sqlStr = "Select 發文編號,主旨,暱稱,時間,最後回覆 from 發文資料表 where 主旨 ='" + txt + "' or 暱稱 ='" + txt + "'";
            //dt = conns.LoadTable_SQL(sqlStr, "");
            //GridView1.DataSource = dt;
            //GridView1.DataBind();
            //Panel1.Visible = true;
            Check(txt);
            

        }

    }
    private bool Check(string txt)
    {

        ConnDB conns = new ConnDB();
        DataTable ch = new DataTable();

        string sqlStr = "Select 發文編號,主旨,暱稱,時間,最後回覆 from 發文資料表 where 主旨 Like '%" + txt + "%'   or 暱稱 like '%" + txt + "%'";
        ch = conns.LoadTable_SQL(sqlStr,"");

        if (ch.Rows.Count > 0)
        {                
            GridView1.DataSource =ch;
            GridView1.DataBind();
            Panel1.Visible = true;
            return true;
        }
        else
        {
            Response.Write("<script language=javascript>alert('查無此內容項目,請重新輸入')</script>");
            Response.Write("<script language=javascript>window.location.href='Select.aspx'</script>");
            return false;
        }
    } 
}