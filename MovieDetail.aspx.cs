using System;
using DTO;

public partial class MovieDetail : BasePage
{
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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsLogin)
        {
            Response.Redirect("Index.aspx");
        }

        if (string.IsNullOrEmpty(Querystring))
            Response.Redirect("MoviePage.aspx");

        ArticleDTO _ArticleDTO = _ArticleService.GetArticleById(Querystring);
        if (_ArticleDTO != null)
        {           
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
