﻿using System;
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
using System.Web.SessionState;

public partial class Look : System.Web.UI.Page
{
    DataTable timeDt = new DataTable();
    ConnDB conns = new ConnDB();
    string dtn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    protected void Page_Load(object sender, EventArgs e)
    {

        string Numbr;
        Numbr = Request["SuppNumb"];
        DataTable dt = new DataTable();
        string page_src = "select src from 發文資料表 where 發文編號='" + Numbr + "'";
        dt = conns.LoadTable_SQL(page_src, "");
        string page_youtube = dt.Rows[0]["src"].ToString();
        MoviePlay.Attributes.Add("src", page_youtube);

        if (IsPostBack)//第二次進來
        {
            DataList1.DataBind();
        }
        else //第一次進來
        {
            if (Session["帳號"] == null && Session["暱稱"] == null)
            {
                this.TextBox_Contents.Enabled = false;
                this.Button_into.Enabled = false;
            }
            Numbr = Request["SuppNumb"];
            Session["Number"] = Numbr;
            ViewState["Number"] = Numbr;
            string sqlStr = "Select * from 發文資料表 where 發文編號 ='" + Numbr + "' ";
            timeDt = conns.LoadTable_SQL(sqlStr, "");
            this.Label_nowtime.Text = DateTime.Now.ToString();
            this.Label_Nickname.Text = timeDt.Rows[0]["暱稱"].ToString();
            this.Label_title.Text = timeDt.Rows[0]["標題"].ToString();
            this.Label_Keynote.Text = timeDt.Rows[0]["主旨"].ToString();
            this.Label_time.Text = timeDt.Rows[0]["時間"].ToString();
            this.Label_Contents.Text = timeDt.Rows[0]["內容"].ToString();
        }
    }
    protected void Button_into_Click1(object sender, EventArgs e)
    {
        string Numbr = ViewState["Number"].ToString();
        if (TextBox_Contents.Text == "")
        {
            Label_Message.Visible = true;
            this.Label_Message.Text = "回文內容不可空白";
        }
        else
        {
            string sqlStr = "Insert into 回文資料表 values('" + Numbr + "','" + Session["暱稱"] + "','" + TextBox_Contents.Text.Trim() + "','" + dtn + "')";
            string rtnMsg;
            rtnMsg = conns.RunSqlStr(sqlStr, "");
            DataList1.DataBind();
            this.TextBox_Contents.Text = "";
            DataTable dt = new DataTable();
            string sqlStr2 = "Update  發文資料表 Set 最後回覆='" + dtn + "'where 發文編號='" + ViewState["Number"] + "'";
            dt = conns.LoadTable_SQL(sqlStr2, "");
        }
    }

    protected void Image2_Load(object sender, EventArgs e)
    {
        string Numbr;
        Numbr = Request["SuppNumb"];
        ConnDB conns = new ConnDB();
        DataTable dt = new DataTable();
        string str = "select * from 發文資料表 Where 發文編號='" + Numbr + "'";
        dt = conns.LoadTable_SQL(str, "");
        string url = dt.Rows[0]["ImageUrl"].ToString();
        Image2.ImageUrl = url;
    }

    protected void Item_Command(object source, DataListCommandEventArgs e)
    {
        Label lblnum = (Label)e.Item.FindControl("lblnum");
        ConnDB conn = new ConnDB();
        DataTable dt = new DataTable();
        string str = "Delete FROM 回文資料表 Where 回文編號='" + lblnum.Text + "'";
        dt = conn.LoadTable_SQL(str, "");
        DataList1.DataBind();
    }
    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        string Max;
        LinkButton LB = (LinkButton)e.Item.FindControl("DeleteButton");
        ConnDB conn = new ConnDB();
        DataTable dt = new DataTable();
        if (Session["帳號"] == null && Session["暱稱"] == null)
        {
            LB.Visible = false;
            return;
        }
        else
        {
            string str = "Select 權限 From 會員基本資料表 Where 帳號='" + Session["帳號"] + "'";
            dt = conn.LoadTable_SQL(str, "");
            Max = dt.Rows[0]["權限"].ToString();
            if (Max == "1")
            {
                LB.Visible = true;
            }
            else 
            {
                LB.Visible = false;
            }
        }    
    }
}
