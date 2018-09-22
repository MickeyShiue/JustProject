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

public partial class Download : BasePage
{
    public string DownLoadFileName
    {
        get
        {
            return Request.QueryString["FileName"] != null ? Request.QueryString["FileName"] : null;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsLogin)
        {
            Response.Redirect("Index.aspx");
        }

        if (DownLoadFileName != null)
        {
            DownLoad();
        }

        var FileInfo = Directory.GetFiles(Server.MapPath("~/MovieImage"));
        for (int i = 0; i < FileInfo.Length; i++)
        {
            var ItemInfo = FileInfo[i].Split('\\');

            string FolderName = ItemInfo[3];
            string FileName = ItemInfo[4];

            Image img = new Image();
            img.ImageUrl = string.Format("{0}/{1}", FolderName, FileName);
            img.ID = FileName;
            img.CssClass = "imgclick";
            this.Mycontainer.Controls.Add(img);
        }

    }

    private void DownLoad()
    {
        Response.ContentType = "application/octet-stream";
        Response.AppendHeader("content-disposition", "attachment;FileName=" + DownLoadFileName);
        Response.TransmitFile(Server.MapPath("~/MovieImage/" + DownLoadFileName));
        Response.End();
    }
}