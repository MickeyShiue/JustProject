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
        this._coonDB = connDB;
    }

    public IEnumerable<HotLinkDTO> GetHotSrc(List<string> listHotSortNum)
    {

        string sqlstr = "SELECT 'linkbtn'+Convert(VARCHAR,Sort) AS Sort,title,src FROM HotLink WHERE Sort BETWEEN @MIN AND @MAX ";
        IDictionary<string, string> SqlParameter = new Dictionary<string, string>();
        SqlParameter.Add("@MIN", listHotSortNum[0]);
        SqlParameter.Add("@MAX", listHotSortNum[1]);

        DataTable dt = _coonDB.LoadTable_SQL(sqlstr, SqlParameter);

        IEnumerable<HotLinkDTO> _hotLinkDTO = dt.AsEnumerable().Select(x => new HotLinkDTO()
        {
            Sort = x.Field<string>("Sort"),
            title = x.Field<string>("title"),
            src = x.Field<string>("src"),
        });

        return _hotLinkDTO;
    }
}