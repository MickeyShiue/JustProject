using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;

public partial class Download : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {      
        ArrayList dataArray = new ArrayList();
        string[] data;
        data = Directory.GetFiles(Server.MapPath("~/上傳資料夾"));

        foreach (string item in data)
        {
            dataArray.Add(new FileInfo(item));
        }
        this.GridView1.DataSource = dataArray;
        this.GridView1.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string select = FineName_TextBox.Text.Trim();
        string[] data;
        data = Directory.GetFiles(Server.MapPath("~/上傳資料夾"));

        foreach (string item in data)
        {
            string[] strArray = item.Split('\\');
            if (select == strArray[strArray.Length-1])
            {
                string FileName = this.FineName_TextBox.Text;
                Response.ContentType = "application/octet-stream";
                Response.AppendHeader("content-disposition", "attachment;FileName=" + FileName);
                Response.TransmitFile(Server.MapPath("~/上傳資料夾/" + FileName));
                Response.End();
                LabeMessage.Visible = false;
                return;
            }
        }
        LabeMessage.Visible = true;
        LabeMessage.Text = "上未輸入下載檔案名稱";
    }
}