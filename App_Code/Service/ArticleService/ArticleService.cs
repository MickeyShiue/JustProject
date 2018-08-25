using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using DTO;

public class ArticleService : IArticleService
{
    IConnDB _coonDB;

    public ArticleService(IConnDB connDB)
    {
        this._coonDB = connDB;
    }

    public IEnumerable<ArticleDTO> GetArticleByType(string MovieType)
    {
        string str = string.Format("SELECT * FROM Article Where MovieType='{0}' ORDER BY LastReplyTime DESC ", MovieType);
        DataTable dt = _coonDB.LoadTable_SQL(str);

        List<ArticleDTO> _ArticleDTO = dt.AsEnumerable()
            .Select(x => new ArticleDTO()
            {
                id = x.Field<int>("id"),
                MovieType = x.Field<string>("MovieType"),
                Name = x.Field<string>("Name"),
                Content = x.Field<string>("Content"),
                CreateTime = x.Field<DateTime>("CreateTime"),
                Title = x.Field<string>("Title"),
                LastReplyTime = x.Field<DateTime>("LastReplyTime"),
                YoutubeUrl = x.Field<string>("YoutubeUrl"),
                ImagePath = x.Field<string>("ImagePath")
              }).ToList();

        return _ArticleDTO;
    }

    public string DeleteArticle(int Id)
    {
        throw new NotImplementedException();
    }
}