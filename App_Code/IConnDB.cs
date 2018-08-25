using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// IConnDB 的摘要描述
/// </summary>
public interface IConnDB
{
     DataTable LoadTable_SQL(string sqlStr);

     string RunSqlStr(string sqlStr);
}