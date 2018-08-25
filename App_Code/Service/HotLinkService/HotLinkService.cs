using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using DTO;

/// <summary>
/// HotLinkService 的摘要描述
/// </summary>
public class HotLinkService :IHotLinkService
{
    IConnDB _coonDB;

    public HotLinkService(IConnDB connDB)
    {
        _coonDB = connDB;
    }

    public IEnumerable<HotLinkDTO> GetHotSrc(string SortNumber)
    {
        string str = string.Format("select 'linkbtn'+Convert(varchar,Sort) as Sort, title , src from HotLink where Sort IN({0})", SortNumber);
        DataTable dt = _coonDB.LoadTable_SQL(str);

        List<HotLinkDTO> _hotLinkDTO = dt.AsEnumerable().Select(x => new HotLinkDTO()
        {
            Sort = x.Field<string>("Sort"),
            title = x.Field<string>("title"),
            src = x.Field<string>("src"),
        }).ToList();

        return _hotLinkDTO;
    }
}