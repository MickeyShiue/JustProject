using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.IO;

public partial class Member_Login : System.Web.UI.Page
{

    DataTable timeDt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    private bool CheckID(string 帳號, string 密碼)
    {
        ConnDB conns = new ConnDB();

        string sqlStr = "Select * from 會員基本資料表 where 帳號 ='" + 帳號 + "' and 密碼 ='" + 密碼 + "'";

        timeDt = conns.LoadTable_SQL(sqlStr, "");
        if (timeDt.Rows.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    protected void Button_Login_Click1(object sender, EventArgs e)
    {
        string Name = TextBox_Id.Text;
        string password = TextBox_Pwd.Text;
        string salt = "ABCD";

        //原輸入密碼1234加上salt字串，再進行加密動作

        password = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(password + salt, "sha1");
        if (Name == "" || password == "")
        {
            Label_Message.Text = "帳號密碼不可為空";
            return;
        }

        if (CheckID(Name, password))
        {
            Session["暱稱"] = timeDt.Rows[0]["暱稱"].ToString();
            Session["帳號"] = Name;
            Session["密碼"] = password;
            Response.Redirect("FirstPage.aspx");
        }
        else
        {
            Label_Message.Text = "帳號或密碼錯誤";
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Create Account.aspx");
    }
   
}
