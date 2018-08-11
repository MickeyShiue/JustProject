using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.IO;

public partial class FirsrPage : System.Web.UI.Page
{

    private ConnDB conns;
    private DataTable dt;

    private string SessionAccount
    {
        get
        {
            return Session["帳號"] != null ? Session["帳號"].ToString() : "";
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        conns = new ConnDB();
        string listHotSortNum = string.Empty;

        if (!IsPostBack)
        {
            Panel_Update.Visible = false;

            for (int i = 1; i < 11; i++)
                this.ddlnumber.Items.Add(i.ToString());

            foreach (Control c in Panel_link.Controls)
            {
                if (c.GetType() == typeof(LinkButton))
                {
                    listHotSortNum += "'" + (((LinkButton)(c)).ID.Replace("linkbtn", "")) + "'" + ",";
                }
            }

            var hotLinkDTOs = conns.HotSrc(listHotSortNum.Trim(','));
            if (hotLinkDTOs.Any())
            {
                foreach (Control c in Panel_link.Controls)
                {
                    if (c.GetType() == typeof(LinkButton))
                    {
                        ((LinkButton)(c)).Text = hotLinkDTOs.Where(x => x.Sort == c.ID.ToString()).Select(x => x.title).SingleOrDefault();
                        ((LinkButton)(c)).ToolTip = hotLinkDTOs.Where(x => x.Sort == c.ID.ToString()).Select(x => x.src).SingleOrDefault();
                    }
                }
            }
        }

        PageLoadVisible(false);
        if (SessionAccount == "G10") { PageLoadVisible(true); }
    }

    private void PageLoadVisible(bool value)
    {
        
        td_btnUpData.Visible = value;
        Delete_SuggestWeb.Visible = value;
        Add_SuggestWeb.Visible = value;
        btn_mastersug.Visible = value;
    }
  
    protected void btninto_Click(object sender, EventArgs e)
    {

        DataTable dt = new DataTable();
        string title = TextBox_名稱.Text;
        string Src = TextBox_路徑.Text;
        string number = ddlnumber.SelectedItem.ToString();
        if (TextBox_名稱.Text == "" || TextBox_路徑.Text == "")
        {
            Response.Write("<script language=javascript>alert('連結名稱及內容不可空白')</script>");
            Response.Write("<script language=javascript>javascript:window.history.back(-1)</script>");
        }
        else
        {
            string sqlStr = "Update HotLink Set Title='" + title + "',Src='" + Src + "' Where Idnumber='" + number + "'";
            string rtnMsg;
            rtnMsg = conns.RunSqlStr(sqlStr, "");
            if (rtnMsg == "Success")
            {
                Response.Write("<script language=javascript>if(confirm('成功修改連結;是否離開修改介面')==true)window.location.href='FirstPage.aspx' ;else javascript:window.history.back(-1) </script>");
                foreach (Control c in Panel_link.Controls)
                {
                    if (c.GetType() == typeof(LinkButton))
                    {
                        string j = ((LinkButton)(c)).ID.Replace("linkbtn", "");

                        //dt = conns.HotSrc(j);
                        //if (dt.Rows.Count > 0)
                        //{
                        //    ((LinkButton)(c)).Text = dt.Rows[0]["title"].ToString();
                        //    ((LinkButton)(c)).ToolTip = dt.Rows[0]["src"].ToString();
                        //}
                    }
                }
            }
            else
            {


            }

        }
    }
    protected void btnUpData_Click(object sender, EventArgs e)
    {
        Panel_link.Visible = false;
        Panel_Update.Visible = true;
    }
    protected void btnend_Click(object sender, EventArgs e)
    {
        Panel_Update.Visible = false;
        Panel_link.Visible = true;
    }
    protected void Top10()
    {

        DataTable dt = new DataTable();
        string str = "select top(10) * from 發文資料表 order by 時間 DESC";
        dt = conns.LoadTable_SQL(str, "");

        Label lb;
        LinkButton linBtn;
        Image imge;
        for (int z = 0; z < 1; z++)
        {
            TableRow aRow = new TableRow();
            {

                for (int y = 0; y < 1; y++)
                {
                    //AddTitle("圖片");
                    //AddTitle("類別");
                    TableCell Ti0 = new TableCell();
                    lb = new Label();
                    lb.Text = "圖片";
                    Ti0.Controls.Add(lb);
                    Ti0.Style[HtmlTextWriterStyle.TextAlign] = "center";
                    //aCell.Style[HtmlTextWriterStyle.Width]="15%";
                    Ti0.BorderWidth = 1;
                    aRow.Cells.Add(Ti0);
                    TB_mov_top10.Rows.Add(aRow);

                    Ti0 = new TableCell();
                    lb = new Label();
                    lb.Text = "標題";
                    Ti0.Controls.Add(lb);
                    Ti0.Style[HtmlTextWriterStyle.TextAlign] = "center";
                    //aCell.Style[HtmlTextWriterStyle.Width]="15%";
                    Ti0.BorderWidth = 1;
                    aRow.Cells.Add(Ti0);
                    TB_mov_top10.Rows.Add(aRow);

                    Ti0 = new TableCell();
                    lb = new Label();
                    lb.Text = "類別";
                    Ti0.Controls.Add(lb);
                    Ti0.Style[HtmlTextWriterStyle.TextAlign] = "center";
                    //aCell.Style[HtmlTextWriterStyle.Width]="15%";
                    Ti0.BorderWidth = 1;
                    aRow.Cells.Add(Ti0);
                    TB_mov_top10.Rows.Add(aRow);

                    Ti0 = new TableCell();
                    lb = new Label();
                    lb.Text = "發文人";
                    Ti0.Controls.Add(lb);
                    Ti0.Style[HtmlTextWriterStyle.TextAlign] = "center";
                    //aCell.Style[HtmlTextWriterStyle.Width]="15%";
                    Ti0.BorderWidth = 1;
                    aRow.Cells.Add(Ti0);
                    TB_mov_top10.Rows.Add(aRow);

                    Ti0 = new TableCell();
                    lb = new Label();
                    lb.Text = "發文時間";
                    Ti0.Controls.Add(lb);
                    Ti0.Style[HtmlTextWriterStyle.TextAlign] = "center";
                    //aCell.Style[HtmlTextWriterStyle.Width]="15%";
                    Ti0.BorderWidth = 1;
                    aRow.Cells.Add(Ti0);
                    TB_mov_top10.Rows.Add(aRow);

                    Ti0 = new TableCell();
                    lb = new Label();
                    lb.Text = "留言人數";
                    Ti0.Controls.Add(lb);
                    Ti0.Style[HtmlTextWriterStyle.TextAlign] = "center";
                    //aCell.Style[HtmlTextWriterStyle.Width]="15%";
                    Ti0.BorderWidth = 1;
                    aRow.Cells.Add(Ti0);
                    TB_mov_top10.Rows.Add(aRow);
                }
            }
        }


        for (int i = 0; i < 10; i++)
        {
            TableRow cRow = new TableRow();
            for (int j = 0; j < 1; j++)
            {
                //cell標題
                TableCell imgCell = new TableCell();
                imge = new Image();
                imge.Width = 45;
                imge.Height = 70;
                imge.ImageUrl = dt.Rows[i]["ImageUrl"].ToString();
                imgCell.Controls.Add(imge);
                imgCell.Style[HtmlTextWriterStyle.TextAlign] = "center";
                imgCell.Style[HtmlTextWriterStyle.Width] = "10%";
                imgCell.BorderWidth = 1;

                cRow.Cells.Add(imgCell);
                TB_mov_top10.Rows.Add(cRow);


                //cell主旨

                TableCell cCell = new TableCell();
                linBtn = new LinkButton();
                linBtn.Text = dt.Rows[i]["主旨"].ToString();
                string g;
                g = dt.Rows[i]["發文編號"].ToString();
                linBtn.PostBackUrl = ("Look.aspx?SuppNumb= " + g);
                cCell.Controls.Add(linBtn);
                cCell.Style[HtmlTextWriterStyle.TextAlign] = "center";
                cCell.Style[HtmlTextWriterStyle.Width] = "30%";
                cCell.BorderWidth = 1;
                cRow.Cells.Add(cCell);
                TB_mov_top10.Rows.Add(cRow);

                //標題
                TableCell aCell = new TableCell();
                lb = new Label();
                lb.Text = dt.Rows[i]["標題"].ToString();
                aCell.Controls.Add(lb);
                aCell.Style[HtmlTextWriterStyle.TextAlign] = "center";
                aCell.Style[HtmlTextWriterStyle.Width] = "10%";
                aCell.BorderWidth = 1;
                cRow.Cells.Add(aCell);
                TB_mov_top10.Rows.Add(cRow);

                //cell暱稱

                TableCell bCell = new TableCell();
                lb = new Label();
                lb.Text = dt.Rows[i]["暱稱"].ToString();
                bCell.Controls.Add(lb);
                bCell.Style[HtmlTextWriterStyle.TextAlign] = "center";
                bCell.Style[HtmlTextWriterStyle.Width] = "20%";
                bCell.BorderWidth = 1;
                cRow.Cells.Add(bCell);
                TB_mov_top10.Rows.Add(cRow);


                //cell時間

                TableCell dCell = new TableCell();
                lb = new Label();
                lb.Text = dt.Rows[i]["時間"].ToString();
                dCell.Controls.Add(lb);
                dCell.Style[HtmlTextWriterStyle.TextAlign] = "center";
                dCell.Style[HtmlTextWriterStyle.Width] = "10%";
                dCell.BorderWidth = 1;
                cRow.Cells.Add(dCell);
                TB_mov_top10.Rows.Add(cRow);

                //cell留言人數

                TableCell eCell = new TableCell();
                DataTable dt1 = new DataTable();
                string ponumber = dt.Rows[i]["發文編號"].ToString();
                string str1 = "select count(*) as 回覆人數 from 回文資料表 where 編號='" + ponumber + "'";

                dt1 = conns.LoadTable_SQL(str1, "");
                lb = new Label();
                lb.Text = dt1.Rows[0]["回覆人數"].ToString();
                eCell.Controls.Add(lb);
                eCell.Style[HtmlTextWriterStyle.TextAlign] = "center";
                eCell.Style[HtmlTextWriterStyle.Width] = "10%";
                eCell.BorderWidth = 1;
                cRow.Cells.Add(eCell);
                TB_mov_top10.Rows.Add(cRow);
            }
        }
    }

    protected void mastersug()
    {
        string str111 = "select * from HotLink where type='mastersug'";
        DataTable dt = new DataTable();
        dt = conns.LoadTable_SQL(str111, "");

        for (int i = 0; i < 2; i++)
        {
            TableRow pRow = new TableRow();

            ImageButton imgbtn;
            for (int j = 0; j < 5; j++)
            {
                imgbtn = new ImageButton();
                TableCell pCell = new TableCell();
                imgbtn.Width = 150;
                imgbtn.Height = 200;
                imgbtn.ID = dt.Rows[(i * 5) + j]["Idnumber"].ToString();
                string z = imgbtn.ID.Replace("0", "");
                imgbtn.ImageUrl = "~/image/" + (dt.Rows[(i * 5) + j]["Title"].ToString());

                //img.OnClientClick = "return idl(" + img.ID + ");";

                imgbtn.ToolTip = dt.Rows[(i * 5) + j]["Src"].ToString();

                //圖片連結影片阿
                imgbtn.Click += new ImageClickEventHandler(img_Click);
                pCell.Controls.Add(imgbtn);
                pCell.Style[HtmlTextWriterStyle.TextAlign] = "center";
                pCell.Style[HtmlTextWriterStyle.BorderStyle] = "5";
                pCell.BorderWidth = 2;
                pRow.Cells.Add(pCell);
                tbl_mastersug.Rows.Add(pRow);

            }
        }
    }

    void img_Click(object sender, EventArgs e)
    {
        ImageButton imgbtn = (ImageButton)sender;
        string page_youtube = imgbtn.ToolTip;
        MoviePlay.Attributes.Add("src", page_youtube);
    }

    protected void WebLinkbtn()
    {

        //string str = "select COUNT(*) 總數 from HotLink where type='SuggestWeb'";
        //DataTable dt = new DataTable();
        //dt = conns.LoadTable_SQL(str, "");
        //int nRow = int.Parse(dt.Rows[0]["總數"].ToString());
        //LinkButton linkbtn;
        //for (int i = 11; i <= nRow + 10; ++i)
        //{
        //    TableRow kRow = new TableRow();
        //    for (int j = 0; j < 1; ++j)
        //    {
        //        TableCell kCell = new TableCell();
        //        linkbtn = new LinkButton();
        //        dt = new DataTable();
        //        dt = conns.HotSrc(i.ToString());
        //        //linkbtn.ID = "linkbtn" + i;
        //        linkbtn.Text = dt.Rows[0]["title"].ToString();
        //        linkbtn.PostBackUrl = dt.Rows[0]["src"].ToString();
        //        //linkbtn.Click += new EventHandler(Click);
        //        kCell.Controls.Add(linkbtn);
        //        kCell.Style[HtmlTextWriterStyle.TextAlign] = "center";
        //        kCell.BorderWidth = 2;
        //        kRow.Cells.Add(kCell);
        //        SuggestWeb.Rows.Add(kRow);
        //    }
        //}
    }
    protected void Delete_SuggestWeb_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt = conns.HotLink();
        CheckBox_SuggestWeb.DataSource = dt;
        CheckBox_SuggestWeb.DataTextField = "Title";
        CheckBox_SuggestWeb.DataBind();
        Sug_web.Visible = false;
        Del_Sug.Visible = true;

    }
    protected void End_SuggestWeb_Click(object sender, EventArgs e)
    {
        Sug_web.Visible = true;
        Del_Sug.Visible = false;
    }
    protected void Add_SuggestWeb_Click(object sender, EventArgs e)
    {
        Sug_web.Visible = false;
        Add_Sug.Visible = true;
    }

    protected void add_ok_Click(object sender, EventArgs e)
    {

        //ConnDB coons = new ConnDB();
        if (TextBox_add_title.Text == "" || Text_add_src.Text == "")
        {
            Response.Write("<script language=javascript>alert('欄位不可為空')</script>");
            Response.Write("<script language=javascript>javascript:window.history.back(-1)</script>");
        }
        else
        {
            string cnt = (int.Parse(conns.getHotlinkcnt()) + 1).ToString();

            string sqlStr = "Insert into HotLink(Title,Src,Idnumber,type) values ('" + TextBox_add_title.Text + "','" + Text_add_src.Text + "','" + cnt + "','SuggestWeb')";
            string rtnMsg;
            rtnMsg = conns.RunSqlStr(sqlStr, "");
            if (rtnMsg == "Success")
            {

                lbladd_sug.Text = "更改連結成功";

            }
            else
            {

                lbladd_sug.Text = "更改連結失敗";

            }
            TextBox_add_title.Text = "";
            Text_add_src.Text = "";

        }

    }

    protected void add_end_Click(object sender, EventArgs e)
    {
        Add_Sug.Visible = false;
        Sug_web.Visible = true;

    }
    protected void Delete_ok_SuggestWeb_Click(object sender, EventArgs e)
    {
        //ConnDB coons = new ConnDB();
        DataTable dt = new DataTable();
        string str = "";
        foreach (ListItem item in CheckBox_SuggestWeb.Items)
        {
            if (item.Selected == true)
            {
                string[] Varry = item.Value.Split('.');
                int number = int.Parse(Varry[0]) + 10;
                if (str == "")
                {
                    str += number.ToString();
                }
                else
                {
                    str += "," + number.ToString();
                }
            }
        }


        if (str != "")
        {
            string[] arry = str.Split(',');
            string tmpStr;
            int i = 0;
            for (i = 0; i < arry.Length; i++)
            {
                string spstr = (int.Parse(arry[i]) - i).ToString();
                tmpStr = conns.delIdnumber(spstr);
            }

            dt = conns.HotLink();
            CheckBox_SuggestWeb.DataSource = dt;
            CheckBox_SuggestWeb.DataTextField = "Title";
            CheckBox_SuggestWeb.DataBind();
        }
        else
        {
            Response.Write("<script language=javascript>alert('請選擇欲刪除的項目')</script>");
            Response.Write("<script language=javascript>javascript:window.history.back(-1)</script>");
        }

    }
    protected void btn_pagemov_update_Click(object sender, EventArgs e)
    {
        MoviePlay.Visible = false;
     
    }
    protected void btn_pagemov_update_ok_Click(object sender, EventArgs e)
    {
      
    }
    protected void btn_pagemov_update_end_Click(object sender, EventArgs e)
    {
        MoviePlay.Visible = true;
    
        Response.Write("<script language=javascript>if(confirm('確定離開修改介面?')==true)window.location.href='FirstPage.aspx' ;else javascript:window.history.back(-1) </script>");


    }
    protected void btn_mastersug_Add_image_Click(object sender, EventArgs e)
    {

    }
    protected void btn_mastersug_Click(object sender, EventArgs e)
    {
        btn_mastersug.Visible = false;
        mastersuggest.Visible = false;
        Change_mastersug.Visible = true;
        string str = "select * from HotLink where type='mastersug'";
        DataTable dt = new DataTable();
        dt = conns.LoadTable_SQL(str, "");
        ddl_mastersug.DataTextField = "title";
        ddl_mastersug.DataSource = dt;
        ddl_mastersug.DataBind();
    }
    protected void btn_check_image_Click(object sender, EventArgs e)
    {
        btn_check_image.Visible = false;
        btn_mastersug_Add_ok.Visible = true;

        lbl_mastersug_Add_tip.Visible = false;
        string strPath = Server.MapPath("~/") + "default";
        string[] strFileDirEnteries = System.IO.Directory.GetFileSystemEntries(strPath);
        foreach (string strFileName in strFileDirEnteries)
        {
            System.IO.File.Delete(strFileName);
        }
        if (FileUpload_img.HasFile)
        {

            FileUpload_img.Visible = false;
            btn_ReFileUpload_img.Visible = true;
            string FileName = FileUpload_img.FileName;
            //string spath = Server.MapPath("default");
            //int n = spath.LastIndexOf("\\");
            //string Rpath = spath.Substring(0, n);
            //ViewState["Rpath"] = Rpath;
            FileUpload_img.SaveAs(strPath + "//" + FileUpload_img.FileName);
            ViewState["FileName"] = FileUpload_img.FileName;
            Image_mastersug_Add_image.ImageUrl = "~/default/" + FileName;
            lbl_mastersug_Add_title2.Text = FileName.Replace(".jpg", "");
        }
        else

        {


            lbl_mastersug_Add_title2.Text = "尚未選取內容";
            Response.Write("<script language=javascript>alert('請選擇上傳圖片')</script>");
            Response.Write("<script language=javascript>javascript:window.history.back(-1)</script>");
        }

    }
    protected void btn_mastersug_Add_ok_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();

        if (ViewState["FileName"] == null || tb_mastersug_Add_src.Text == "" || lbl_mastersug_Add_title2.Text == "尚未選取內容")
        {

            Response.Write("<script language=javascript>alert('欲更改建議連結,請填寫連結網址及選擇上傳圖片')</script>");
            Response.Write("<script language=javascript>javascript:window.history.back(-1)</script>");

        }
        else
        {
            try
            {

                string title = ViewState["FileName"].ToString();
                string src = tb_mastersug_Add_src.Text;
                string orignfile, newfile;
                orignfile = Server.MapPath("~/") + "default//" + ViewState["FileName"];
                newfile = Server.MapPath("~/") + "image//" + ViewState["FileName"];
                File.Move(orignfile, newfile);
                string sqlStr = "Update HotLink Set Title='" + title + "',Src='" + src + "' where type='mastersug' and Title ='" + ddl_mastersug.SelectedItem + "'";
                string rtnMsg;
                rtnMsg = conns.RunSqlStr(sqlStr, "");

            }
            catch
            {

            }


        }
        //Dim di As New DirectoryInfo("C:\test")
        //di.MoveTo("C:\test2")
        //string strPath = Server.MapPath("~/") + "yymm"; ;
        //string FileName = "";
        //if (ViewState["FileName"] == null)
        //{
        //    return;
        //}
        //else
        //{
        //    FileName = ViewState["FileName"].ToString();
        //    // Response.Write("<script language=javascript>if(confirm('確定更改更改" + ddl_mastersug.SelectedItem + "連結並離開修改介面?')==true)window.location.href='FirstPage.aspx' ;else javascript:window.history.back(-1) </script>");
        //    //if (tb_mastersug_Add_src.Text == "" || lbl_mastersug_Add_title2.Text == "尚未選取內容")
        //    FileUpload_img.SaveAs(strPath + "//" + FileName);
        //    ViewState["FileName"] = "";
        //}

    }

    protected void btn_mastersug_Add_end_Click(object sender, EventArgs e)
    {
        Response.Write("<script language=javascript>if(confirm('確定離開修改介面?')==true)window.location.href='FirstPage.aspx' ;else javascript:window.history.back(-1) </script>");
    }

    protected void btn_ReFileUpload_img_Click(object sender, EventArgs e)
    {
        btn_mastersug_Add_ok.Visible = false;
        FileUpload_img.Visible = true;
        btn_ReFileUpload_img.Visible = false;
        btn_check_image.Visible = true;
        lbl_mastersug_Add_tip.Visible = true;
    }

}