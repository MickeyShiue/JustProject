using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class share : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["帳號"] == null) { Response.Redirect("FirstPage.aspx"); }
    }
    protected void UploadButton_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            string[] Route = FileUpload1.FileName.Split(Convert.ToChar("\\"));
            string FileName = Route[Route.Length - 1];
            string savePath = (Request.PhysicalApplicationPath + ("上傳資料夾\\" + Server.HtmlDecode(FileName)));

            try
            {
                FileUpload1.SaveAs(savePath);
                this.UploadStatusLabel.Text = "已經上傳成功";

            }
            catch (Exception ex)
            {
                UploadStatusLabel.Text = ex.Message;
            }
        }
        else
        {
            UploadStatusLabel.Text = "您沒有指定所要上傳的檔案";        
        }

    }
}