using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Default2 : System.Web.UI.Page
{
    ConnDB conns = new ConnDB();
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        if (IsPostBack)
        {

        }
        else
        {
            int i = 0;
            for (i = int.Parse(DateTime.Now.Year.ToString()) - 100; i <= int.Parse(DateTime.Now.Year.ToString()); i++)
                this.ddlBirthday.Items.Add(i.ToString());
            TextBox_Birthday.Text = "1月1日";

            dt = conns.Citylist();
            ddlcity.DataSource = dt;
            ddlcity.DataTextField = "Counties";
            ddlcity.DataBind();
            dt = new DataTable();
            string Counties = ddlcity.SelectedItem.Text;
            dt = conns.Arealist(Counties);
            ddlarea.DataSource = dt;
            ddlarea.DataTextField = "Area";
            ddlarea.DataBind();
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (Panel5.Visible)
        {
            Panel5.Visible = false;
        }
        else
        {
            Panel5.Visible = true;
        }
    }
    protected void Calendar1_SelectionChanged1(object sender, EventArgs e)
    {
        if (this.Calendar1.SelectedDate.Year <= int.Parse(DateTime.Now.Year.ToString()) && this.Calendar1.SelectedDate.Year > int.Parse(DateTime.Now.Year.ToString()) - 100)
        {
            this.TextBox_Birthday.Text = this.Calendar1.SelectedDate.Month.ToString() + "月"
            + this.Calendar1.SelectedDate.Day.ToString() + "日";
            Panel5.Visible = false;
            this.ddlBirthday.SelectedValue = this.Calendar1.SelectedDate.Year.ToString();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string account = this.TextBox_Account.Text.Trim();
        string password = this.TextBox_Password.Text.Trim();
        string password1 = this.TextBox_Password1.Text.Trim();
        string nickname = this.TextBox_Nickname.Text.Trim();
        string city = this.ddlcity.SelectedItem.Text;
        string area = this.ddlarea.SelectedItem.Text;
        string address = this.TextBox_Address.Text.Trim();
        string email = this.TextBox_Email.Text.Trim();
        string phone = this.TextBox_Phone.Text.Trim();
        string birthday = ddlBirthday.SelectedItem + "/" + this.Calendar1.SelectedDate.Month.ToString() + "/" + this.Calendar1.SelectedDate.Day.ToString();
        string Max = "0";

        if (account == "" || password == "" || nickname == "" || address == "" || email == "" || phone == "" || birthday == "")
        {
            this.Label_Message.Text = "欄位不可空白";
            return;
        }
        if (password != password1)
        {
            this.Label_Message.Text = "確認密碼不同";
            return;
        }
        string str = "Select * from 會員基本資料表 where 帳號 ='" + account + "'";
        DataTable timeDt = new DataTable();
        timeDt = conns.LoadTable_SQL(str, "");
        if (timeDt.Rows.Count > 0)
        {
            Label_Message.Text = "此帳號已被使用";
            return;
        }

        string salt = "ABCD";

        //原輸入密碼1234加上salt字串，再進行加密動作

        password = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(password + salt, "sha1");

        address = city + "," + area + "," + address;
        string sqlStr = " Insert into 會員基本資料表 values ('" + account + "','" + password + "','" + nickname +
            "','" + Max + "','" + address + "','" + email + "','" + phone + "','" + birthday + "')";
        string rtnMsg;

        rtnMsg = conns.RunSqlStr(sqlStr, "");

        if (rtnMsg == "Success")
        {
            this.Label_Message.Text = "申請會員成功";
            this.Button_Send.Text = "會員登入";
            Response.Redirect("Login.aspx");
        }
        else
        {
            this.Label_Message.Text = "申請會員失敗";
        }
    }
    protected void ddlBirthday_SelectedIndexChanged(object sender, EventArgs e)
    {
        DateTime dt = new DateTime(Convert.ToInt32(ddlBirthday.SelectedValue), 1, 1);
        this.Calendar1.VisibleDate = dt;

    }
    protected void Button_Rest_Click(object sender, EventArgs e)
    {
        this.TextBox_Account.Text = "";
        this.TextBox_Password.Text = "";
        this.TextBox_Password1.Text = "";
        this.TextBox_Nickname.Text = "";
        this.TextBox_Address.Text = "";
        this.TextBox_Email.Text = "";
        this.TextBox_Phone.Text = "";
        this.TextBox_Birthday.Text = "";
    }
    protected void ddlcity_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        string Counties = ddlcity.SelectedItem.Text;
        dt = conns.Arealist(Counties);
        ddlarea.DataSource = dt;
        ddlarea.DataTextField = "Area";
        ddlarea.DataBind();
    }
}