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

public partial class Updata : System.Web.UI.Page
{
    ConnDB conns = new ConnDB();
    protected void Page_Load(object sender, EventArgs e)
    {
        string UserName;
        DataTable dt = new DataTable();
        if (Session["帳號"] == null) { Response.Redirect("FirstPage.aspx"); }
        UserName = Session["帳號"].ToString();
        DataTable timeDt = new DataTable();
        if (!IsPostBack)
        {
            string sqlStr = "Select * from 會員基本資料表 where 帳號 ='" + UserName + "' ";
            timeDt = conns.LoadTable_SQL(sqlStr, "");
            this.TextBox_Account.Text = timeDt.Rows[0]["帳號"].ToString();
            this.TextBox_Nickname.Text = timeDt.Rows[0]["暱稱"].ToString();
            string Address = timeDt.Rows[0]["地址"].ToString();
            string[] add = Address.Split(',');

            dt = conns.Citylist();
            ddlcity.DataSource = dt;
            ddlcity.DataTextField = "Counties";
            ddlcity.DataBind();
            this.ddlcity.Items.FindByText(add[0]).Selected = true;

            dt = conns.Arealist(add[0]);
            ddlarea.DataSource = dt;
            ddlarea.DataTextField = "Area";
            ddlarea.DataBind();
            this.ddlarea.Items.FindByText(add[1]).Selected = true;

            this.TextBox_Address.Text = add[2];
            this.TextBox_Email.Text = timeDt.Rows[0]["電子信箱"].ToString();
            this.TextBox_Phone.Text = timeDt.Rows[0]["連絡電話"].ToString();
            string str = timeDt.Rows[0]["生日"].ToString();
            string[] strry = str.Split('/');
            if (strry.Length >= 0)
            {
                str = strry[0];
                ddlBirthday.SelectedItem.Text = str;
            }
            if (strry.Length >= 2)
            {
                str = strry[1] + "月" + strry[2] + "日";
                this.TextBox_Birthday.Text = str;
            }
            int i = 0;
            for (i = int.Parse(DateTime.Now.Year.ToString()) - 100; i <= int.Parse(DateTime.Now.Year.ToString()); i++)
                this.ddlBirthday.Items.Add(i.ToString());
        }

    }
    protected void ddlBirthday_SelectedIndexChanged(object sender, EventArgs e)
    {
        DateTime dt = new DateTime(Convert.ToInt32(ddlBirthday.SelectedValue), 1, 1);
        this.Calendar1.VisibleDate = dt;
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
    protected void Button_Rest_Click(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string address = TextBox_Address.Text;
        string city = this.ddlcity.SelectedItem.Text;
        string area = this.ddlarea.SelectedItem.Text;
        string UserName = this.TextBox_Account.Text;
        if (TextBox_Nickname.Text == "" || address == "" || TextBox_Email.Text == "" || TextBox_Phone.Text == "")
        {
            this.Label_Message.Text = "欄位不可空白";
            return;
        }
        else
        {
            DataTable timeDt = new DataTable();
            address = city + "," + area + "," + address;
            string birthday = ddlBirthday.SelectedItem + "/" + this.Calendar1.SelectedDate.Month.ToString() + "/" + this.Calendar1.SelectedDate.Day.ToString();
            ConnDB conns = new ConnDB();
            string sqlStr = "Update  會員基本資料表 Set 暱稱='" + TextBox_Nickname.Text.Trim() + "',地址='" + address + "',電子信箱='" + TextBox_Email.Text.Trim() + "',連絡電話='" + TextBox_Phone.Text.Trim() + "',生日='" + birthday + "'where 帳號='" + UserName + "'";
            timeDt = conns.LoadTable_SQL(sqlStr, "");
            this.Label_Message.Text = "修改成功";
                       
        }
    }
    protected void ddlcity_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        string city = this.ddlcity.SelectedItem.Text;
        dt = conns.Arealist(city);
        ddlarea.DataSource = dt;
        ddlarea.DataTextField = "Area";
        ddlarea.DataBind();
    }
}