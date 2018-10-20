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
public partial class MoviePage : BasePage
{
    private readonly IArticleService _ArticleService;

    public MoviePage()
    {
        _ArticleService = new ArticleService(new ConnDB());
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsLogin)
        {
            Response.Redirect("Index.aspx");
        }

        GridView_喜劇.DataSource = _ArticleService.GetArticleByType("喜劇片");
        GridView_喜劇.DataBind();

        GridView_動作.DataSource = _ArticleService.GetArticleByType("動作片");
        GridView_動作.DataBind();

        GridView_愛情.DataSource = _ArticleService.GetArticleByType("愛情片");
        GridView_愛情.DataBind();

    }
}