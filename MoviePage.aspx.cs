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
public partial class MoviePage : System.Web.UI.Page
{
    private readonly IArticleService _ArticleService;
    private DataTable dt;

    public MoviePage()
    {
        _ArticleService = new ArticleService(new ConnDB());
    }


    protected void Page_Load(object sender, EventArgs e)
    {      
        GridView_喜劇.DataSource = _ArticleService.GetArticleByType("喜劇片");
        GridView_喜劇.DataBind();

        GridView_動作.DataSource = _ArticleService.GetArticleByType("動作片");
        GridView_動作.DataBind();

        GridView_愛情.DataSource = _ArticleService.GetArticleByType("愛情片");
        GridView_愛情.DataBind();


        if ("1" == "1")
        {
            GridView_喜劇.AutoGenerateDeleteButton = true;
            GridView_動作.AutoGenerateDeleteButton = true;
            GridView_愛情.AutoGenerateDeleteButton = true;
        
            GridView_喜劇.DataBind();
            GridView_動作.DataBind();
            GridView_愛情.DataBind();
        }

        #region 暫時取消
        //try
        //{
        //    string ID = Session["帳號"].ToString();
        //    ConnDB conns = new ConnDB();
        //    DataTable dt = new DataTable();
        //    string sqlStr = "Select * from 會員基本資料表 where 帳號 ='" + ID + "' ";
        //    dt = conns.LoadTable_SQL(sqlStr, "");
        //    string Max = dt.Rows[0]["權限"].ToString();

        //    if (Max == "1")
        //    {
        //        GridView_喜劇.AutoGenerateDeleteButton = true;
        //        GridView_動作.AutoGenerateDeleteButton = true;
        //        GridView_愛情.AutoGenerateDeleteButton = true;
        //        btnMax.Visible = true;
        //        GridView_喜劇.DataBind();
        //        GridView_動作.DataBind();
        //        GridView_愛情.DataBind();
        //    }
        //}
        //catch
        //{

        //}
        #endregion
    }
    protected void GridView_喜劇_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView_喜劇.PageIndex = e.NewPageIndex;
        GridView_喜劇.DataBind();
    }
    protected void GridView_動作_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView_動作.PageIndex = e.NewPageIndex;
        GridView_動作.DataBind();
    }
    protected void GridView_愛情_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView_愛情.PageIndex = e.NewPageIndex;
        GridView_愛情.DataBind();
    }
    protected void GridView_動作_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            string index = GridView_動作.DataKeys[e.RowIndex].Value.ToString();
            ConnDB conns = new ConnDB();
            DataTable dt = new DataTable();
            string sqlstr = "Delete from 發文資料表 where 發文編號 = '" + index + "'";
            dt = conns.LoadTable_SQL(sqlstr, "");
            GridView_動作.DataBind();
        }
        catch
        {

        }
    }
    protected void GridView_愛情_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            string index = GridView_愛情.DataKeys[e.RowIndex].Value.ToString();
            ConnDB conns = new ConnDB();
            DataTable dt = new DataTable();
            string sqlstr = "Delete from 發文資料表 where 發文編號 = '" + index + "'";
            dt = conns.LoadTable_SQL(sqlstr, "");
            GridView_愛情.DataBind();
        }
        catch
        {

        }
    }
    protected void GridView_喜劇_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            string index = GridView_喜劇.DataKeys[e.RowIndex].Value.ToString();
            ConnDB conns = new ConnDB();
            DataTable dt = new DataTable();
            string sqlstr = "Delete from 發文資料表 where 發文編號 = '" + index + "'";
            dt = conns.LoadTable_SQL(sqlstr, "");

            string str2 = "Select * from 發文資料表 Where 標題= '喜劇片' ORDER BY 最後回覆 DESC ";
            dt = conns.LoadTable_SQL(str2, "");
            GridView_喜劇.DataSource = dt;
            GridView_喜劇.DataBind();
        }
        catch
        {

        }
    }
    protected void GridView_喜劇_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowIndex != -1)
        //{
        //    if (e.Row.RowIndex % 2 == 1)
        //    {
        //        e.Row.BackColor = System.Drawing.Color.Yellow;
        //    }
        //    else
        //    {
        //        e.Row.BackColor = System.Drawing.Color.Pink;
        //    }
        //}
    }
    protected void GridView_動作_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowIndex != -1)
        //{
        //    if (e.Row.RowIndex % 2 == 1)
        //    {
        //        e.Row.BackColor = System.Drawing.Color.Yellow;
        //    }
        //    else
        //    {
        //        e.Row.BackColor = System.Drawing.Color.Pink;
        //    }
        //}
    }
    protected void GridView_愛情_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowIndex != -1)
        //{
        //    if (e.Row.RowIndex % 2 == 1)
        //    {
        //        e.Row.BackColor = System.Drawing.Color.Yellow;
        //    }
        //    else
        //    {
        //        e.Row.BackColor = System.Drawing.Color.Pink;
        //    }
        //}
    }
    protected void btnMax_Click(object sender, EventArgs e)
    {

    }
}