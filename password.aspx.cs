using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class password : System.Web.UI.Page
{
   
    DataTable timeDt = new DataTable();
   
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["帳號"] == null) { Response.Redirect("FirstPage.aspx"); }

        if (!IsPostBack)
        {
            string username = Session["帳號"].ToString();
            ConnDB conns = new ConnDB();
            string sqlStr = "Select * from 會員基本資料表 where 帳號 ='" + username + "' ";
            timeDt = conns.LoadTable_SQL(sqlStr, "");
            string checkpassword = timeDt.Rows[0]["密碼"].ToString();
            ViewState["checkpassword"] = checkpassword;
        }
    
    }
    protected void Button_Save_Click(object sender, EventArgs e)
    {
        
        string oldpassword = TextBox_Password.Text;
        string checkpassword = ViewState["checkpassword"].ToString();
        string username = Session["帳號"].ToString();

        string salt = "ABCD";
        //原輸入密碼1234加上salt字串，再進行加密動作
        oldpassword = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(oldpassword + salt, "sha1");
        string newpassword = TextBox_NewPassword.Text;



        if (oldpassword == "" || newpassword == "" || TextBox_NewPassword2.Text == "")
        {
            this.Label_Message.Visible = true;
            this.Label_Message.Text = "欄位不可空白";
            return;
        }

        if (oldpassword != checkpassword)
        {
            this.Label_Message.Visible = true;
            this.Label_Message.Text = "舊密碼錯誤";
            return;
        }
        if (newpassword == checkpassword)
        {
            this.Label_Message.Visible = true;
            this.Label_Message.Text = "新密碼不可與舊密碼相同";
            return;
        }
        if (newpassword != TextBox_NewPassword2.Text)
        {
            this.Label_Message.Visible = true;
            this.Label_Message.Text = "新密碼與確認密碼不符合";
            return;
        }

        if (checkpassword == oldpassword && newpassword == TextBox_NewPassword2.Text)
         {

             newpassword = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(newpassword + salt, "sha1");
             ConnDB conns = new ConnDB();

             string sqlStr = "Update  會員基本資料表 Set 密碼='" + newpassword + "'where 帳號='" + username + "'";
             timeDt = conns.LoadTable_SQL(sqlStr, "");
             this.Label_Message.Visible = true;
             Label_Message.Text = "修改成功";
             this.Button_Save.Visible = false;
             this.TextBox_Password.Enabled = false;
             this.TextBox_NewPassword.Enabled = false;
             this.TextBox_NewPassword2.Enabled = false;        
        }
     }
    protected void Button_back_Click(object sender, EventArgs e)
    {
        Response.Redirect("FirstPage.aspx");
    }
}