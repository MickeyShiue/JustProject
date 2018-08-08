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

public partial class 發文 : System.Web.UI.Page
{
    DataTable timeDt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["帳號"] == null) { Response.Redirect("FirstPage.aspx.aspx"); }

        string ID = Session["帳號"].ToString();
        ConnDB conns = new ConnDB();
        DataTable dt = new DataTable();
        string sqlStr = "Select * from 會員基本資料表 where 帳號 ='" + ID + "' ";
        dt = conns.LoadTable_SQL(sqlStr, "");
        string Max = dt.Rows[0]["權限"].ToString();

        if (Max != "1")
        {
            Response.Redirect("FirstPage.aspx");
        }
        this.Label_nowtime.Text = DateTime.Now.ToString();  
    }

    protected void Button_into_Click1(object sender, EventArgs e)
    {
        string FileName;
        if (FileUpload1.HasFile)
        {
            string[] Route = FileUpload1.FileName.Split(Convert.ToChar("\\"));
            FileName = Route[Route.Length - 1];
            ViewState["FileName"] = FileName;
            string savePath = (Request.PhysicalApplicationPath + ("MovieImage\\" + Server.HtmlDecode(FileName)));

            try
            {
                FileUpload1.SaveAs(savePath);      
            }
            catch (Exception ex)
            {
           
            }
        }
        else
        {
            this.Label_Message.Visible = true;
            this.Label_Message.Text = "上為夾帶圖片";
            return;
        }

        if (TextBox_title.Text == "")
        {
            this.Label_Message.Visible = true;
            this.Label_Message.Text = "尚未輸入主旨";
        }

        else if (TextBox_post.Text == "")
        {
            this.Label_Message.Visible = true;
            this.Label_Message.Text = "尚未輸入訊息";
        }
        else if (txt_src.Text == "")
        {
            this.Label_Message.Visible = true;
            this.Label_Message.Text = "尚未輸入影片連結";
        }
        else
        {
            string dtn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string MovieTilte = ddl_title.SelectedItem.Text.ToString();
            string MovieNames = TextBox_title.Text.Trim();
            string post = TextBox_post.Text.Trim();
            string src = txt_src.Text.Trim();
            string ImageUrl = "~/MovieImage/" + ViewState["FileName"].ToString();

            DataTable dt = new DataTable();
            ConnDB conn = new ConnDB();
            string str = "Insert into 發文資料表 (標題, 暱稱, 內容, 時間, 主旨, 最後回覆, src, ImageUrl) values('" + MovieTilte + "','" + Session["暱稱"] + "','" + post + "','" + dtn + "','" + MovieNames + "','" + dtn + "','" + src + "','" + ImageUrl + "')";
            dt = conn.LoadTable_SQL(str, "");
            Response.Redirect("FirstPage.aspx");
        }
    }
}