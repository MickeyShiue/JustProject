using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public interface IArticleService
{
    IEnumerable<ArticleDTO> GetArticleByType(string MovieType);

    string DeleteArticle(int Id);
}