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
        string str = "SELECT * FROM Article WHERE MovieType=@MovieType ORDER BY LastReplyTime DESC";
        IDictionary<string, string> SqlParameter = new Dictionary<string, string>();
        SqlParameter.Add("@MovieType", MovieType);

        DataTable dt = _coonDB.LoadTable_SQL(str, SqlParameter);

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
                ImagePath = x.Field<string>("ImagePath"),
                StrCreateTime = x.Field<DateTime>("CreateTime").ToString("yyyy-MM-dd hh:mm:ss"),
                StrLastReplyTime = x.Field<DateTime>("LastReplyTime").ToString("yyyy-MM-dd hh:mm:ss"),
            }).ToList();

        return _ArticleDTO;
    }

    public ArticleDTO GetArticleById(string Id)
    {
        string str = "SELECT * FROM Article WHERE Id=@Id";
        IDictionary<string, string> SqlParameter = new Dictionary<string, string>();
        SqlParameter.Add("@Id", Id);

        DataTable dt = _coonDB.LoadTable_SQL(str, SqlParameter);

        ArticleDTO _ArticleDTO = dt.AsEnumerable()
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
                       ImagePath = x.Field<string>("ImagePath"),
                       StrCreateTime = x.Field<DateTime>("CreateTime").ToString("yyyy-MM-dd hh:mm:ss"),
                       StrLastReplyTime = x.Field<DateTime>("LastReplyTime").ToString("yyyy-MM-dd hh:mm:ss")
                   }).FirstOrDefault();

        return _ArticleDTO;
    }

    public string DeleteArticle(string Id)
    {
        throw new NotImplementedException();
    }


}