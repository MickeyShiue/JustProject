using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

public class ConnDB
{
    SqlConnection SqlConn = new SqlConnection();
    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["JustConnectionString"].ConnectionString;

    public string OpenSQL()
    {

        try
        {
            SqlConn.ConnectionString = ConnectionString;
            SqlConn.Open();
            return ("Success");
        }
        catch (Exception ex)
        {
            return (ex.Message);
        }
    }

    public void CloseSQL()
    {

        if (SqlConn.State == ConnectionState.Open) { SqlConn.Close(); }
        SqlConn.Dispose();

    }

    public DataTable LoadTable_SQL(string sqlStr, string sCondi)
    {

        DataTable dt = new DataTable();
        string tmpStr = OpenSQL();

        SqlDataAdapter ad = new SqlDataAdapter();
        string str = sCondi;
        string[] sArr = str.Split(',');
        SqlCommand cmd = new SqlCommand(sqlStr, SqlConn);
        string sTmp;
        for (int i = 0; i < sArr.Length - 1; i++)
        {
            sTmp = "Param" + i;
            SqlParameter sVal = new SqlParameter(sTmp, sArr[i]);
            cmd.Parameters.Add(sVal);
        }

        try
        {
            ad.SelectCommand = cmd;
            ad.Fill(dt);
        }
        catch (Exception)
        {
        }

        CloseSQL();
        ad.Dispose();
        ad = null;

        return dt;
    }

    public string RunSqlStr(string sqlStr, string sCondi)
    {
        SqlCommand cmd = new SqlCommand(sqlStr, SqlConn);
        string tmpStr = OpenSQL();
        if (tmpStr != "Success") { return tmpStr; }

        SqlTransaction trans;

        trans = SqlConn.BeginTransaction();

        cmd.Transaction = trans;

        string str = sCondi;
        string[] sArr = str.Split(',');
        string sTmp;
        for (int i = 0; i < sArr.Length - 1; i++)
        {
            sTmp = "Param" + i;
            SqlParameter sVal = new SqlParameter(sTmp, sArr[i]);
            cmd.Parameters.Add(sVal);
        }

        try
        {
            cmd.ExecuteNonQuery();
            trans.Commit();
            tmpStr = "Success";
        }
        catch (Exception ex)
        {
            trans.Rollback();
            tmpStr = "資料庫執行發生錯誤:" + ex.Message;
        }

        CloseSQL();
        cmd.Dispose();
        cmd = null;

        return tmpStr;
    }

    public string twoSqlStr(string sqlStr, string sqlaa, string sCondi)
    {
            string tmpStr = OpenSQL();
            if (tmpStr != "Success") { return tmpStr; }
                SqlTransaction trans;
                trans = SqlConn.BeginTransaction();
                //..................................................................
                SqlCommand cmd = new SqlCommand(sqlStr, SqlConn);
                cmd.Transaction = trans;
                string str = sCondi;
                string[] sArr = str.Split(',');
                string sTmp;
                for (int i = 0; i < sArr.Length - 1; i++)
                {
                    sTmp = "Param" + i;
                    SqlParameter sVal = new SqlParameter(sTmp, sArr[i]);
                    cmd.Parameters.Add(sVal);
                }
                cmd.ExecuteNonQuery();
                //............................................................
                cmd = new SqlCommand(sqlaa, SqlConn);
                cmd.Transaction = trans;
                str = sCondi;
                string[] ssArr = str.Split(',');
                for (int i = 0; i < ssArr.Length - 1; i++)
                {
                    sTmp = "Param" + i;
                    SqlParameter sVal = new SqlParameter(sTmp, ssArr[i]);
                    cmd.Parameters.Add(sVal);
                }
                try
                {
                    cmd.ExecuteNonQuery();
                    trans.Commit();
                    tmpStr = "Success";
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    tmpStr = "資料庫執行發生錯誤:" + ex.Message;
                }
                CloseSQL();
                cmd.Dispose();
                cmd = null;
                return tmpStr;
    }
    public DataTable Citylist()
    {
        ConnDB conns = new ConnDB();
        string str = "select Counties from City";
        DataTable dt = new DataTable();
        dt = conns.LoadTable_SQL(str, "");
        return dt;
    }
    public DataTable Arealist(string Counties)
    {
        ConnDB conns = new ConnDB();
        string str = "select Area from City a inner join Area b on a.AqrefNbr=b.AqrefNbr where Counties ='" + Counties + "'";
        DataTable dt = new DataTable();
        dt = conns.LoadTable_SQL(str, "");
        return dt;
    }
    public DataTable HotLink()
    {
        ConnDB conns = new ConnDB();
        string str = "select CONVERT(varchar,CAST(Idnumber AS decimal(2, 0))-10)+ '.'+Title as title  from HotLink where type='SuggestWeb'";
        DataTable dt = new DataTable();
        dt = conns.LoadTable_SQL(str, "");
        return dt;
    }
    public DataTable HotSrc(string Idnumber)  
    {
        ConnDB conns = new ConnDB();
        string str = "select title,src from HotLink where Idnumber='" + Idnumber + "'";
        DataTable dt = new DataTable();
        dt = conns.LoadTable_SQL(str, "");
        return dt;
    }
    public string getHotlinkcnt()
    {
        ConnDB conns = new ConnDB();
        string str = "select COUNT(*) as 總數 from HotLink where type in('SuggestWeb','Hot') ";
        DataTable dt = new DataTable();
        dt = conns.LoadTable_SQL(str, "");
        string cnt = dt.Rows[0]["總數"].ToString();
        return cnt;
    }

    public string delIdnumber(string Idnumber)  
    {

        ConnDB conns = new ConnDB();
        string cnt = conns.getHotlinkcnt();
       
        string str1 = "delete from HotLink where Idnumber = '" + Idnumber + "'";
        //string str2 = "update HotLink set Idnumber ='" + Idnumber + "' where Idnumber ='" + cnt + "'";

        //string tmpStr = conns.twoSqlStr(str1, str2, "");
        //return tmpStr;
        string del = RunSqlStr(str1, "");
        int total = int.Parse(cnt) - int.Parse(Idnumber);
        for (int i = 0; i < total; i++)
       {
            //0 23 22 1 24 23 2 25 24
           string str2 = "update HotLink set Idnumber ='" + (int.Parse(Idnumber) + i).ToString() + "' where Idnumber ='" 
           + (int.Parse(Idnumber) + 1 + i).ToString() + "'";
           RunSqlStr(str2, "");
       }

        return del;
     }
    public string getNikebyName(string Name)
    {
        ConnDB conns = new ConnDB();
        string str = "select * from 會員基本資料表 where 帳號='" + Name + "'";
        DataTable dt = new DataTable();
        dt = conns.LoadTable_SQL(str, "");
        str = dt.Rows[0]["暱稱"].ToString();
        return str;
    }
    
}
