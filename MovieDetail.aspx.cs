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
using System.Web.SessionState;
using DTO;

public partial class MovieDetail : System.Web.UI.Page
{

    DataTable timeDt = new DataTable();
    ConnDB conns = new ConnDB();
    string dtn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

    private readonly IArticleService _ArticleService;

    public MovieDetail()
    {
        _ArticleService = new ArticleService(new ConnDB());
    }

    public string Querystring
    {
        get
        {
            return Request["Id"];
        }
    }

    public string Account
    {
        get
        {
            return Session["帳號"] == null ? "" : Session["帳號"].ToString();
        }
    }

    public string Name
    {
        get
        {
            return Session["暱稱"] == null ? "" : Session["暱稱"].ToString();
        }

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Querystring))
            Response.Redirect("MoviePage.aspx");

        ArticleDTO _ArticleDTO = _ArticleService.GetArticleById(Querystring);
        if (_ArticleDTO != null)
        {
            //MoviePlay.Attributes.Add("YoutubeUrl", _ArticleDTO.YoutubeUrl);
            MoviePlay.Attributes.Add("src", _ArticleDTO.YoutubeUrl);
            this.Label_Contents.Text = _ArticleDTO.Content;
        }

    }

    protected void Images_Load(object sender, EventArgs e)
    {
        ArticleDTO _ArticleDTO = _ArticleService.GetArticleById(Querystring);
        Images.ImageUrl = _ArticleDTO.ImagePath; ;
    }

 
}
