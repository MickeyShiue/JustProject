using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public interface IArticleService
{
    IEnumerable<ArticleDTO> GetArticleByType(string MovieType);

    ArticleDTO GetArticleById(string Id);

    string DeleteArticle(string Id);
}