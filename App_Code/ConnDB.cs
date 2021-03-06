﻿using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

public class ConnDB : IConnDB
{
    private readonly SqlConnection SqlConn;
    private DataTable dt;

    public ConnDB()
    {
        try
        {
            SqlConn = new SqlConnection();
            SqlConn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["JustConnectionString"].ConnectionString;
            SqlConn.Open();
        }
        catch (Exception ex)
        {
            string ErrorMsg = ex.Message;
        }
    }

    public void CloseSQL()
    {
        if (SqlConn.State == ConnectionState.Open) { SqlConn.Close(); }
        SqlConn.Dispose();
    }

    public DataTable LoadTable_SQL(string sqlStr, string sCondi)
    {
        return LoadTable_SQL(sqlStr);
    }

    //介面實作
    public string RunSqlStr(string sqlStr)
    {
        string result = string.Empty;
        SqlCommand cmd = new SqlCommand(sqlStr);
        try
        {
            int RowCount = cmd.ExecuteNonQuery();
            result = "Success，執行成功!";
        }
        catch (Exception ex)
        {
            result = "資料庫執行發生錯誤:" + ex.Message;
        }

        //CloseSQL();
        cmd.Dispose();
        cmd = null;
        return result;
    }

    //介面實作
    public DataTable LoadTable_SQL(string sqlStr)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter ad = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand(sqlStr, SqlConn);

        try
        {
            ad.SelectCommand = cmd;
            ad.Fill(dt);
        }
        catch (Exception ex)
        {
            string ErrorMsg = ex.Message;
        }

        //CloseSQL();
        ad.Dispose();
        ad = null;

        return dt;
    }

    public DataTable LoadTable_SQL(string sqlStr, IDictionary<string, string> SqlParameter)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter ad = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand(sqlStr, SqlConn);
        foreach (var item in SqlParameter)
        {
            cmd.Parameters.AddWithValue(item.Key, item.Value);
        }

        try
        {
            ad.SelectCommand = cmd;
            ad.Fill(dt);
        }
        catch (Exception ex)
        {
            string ErrorMsg = ex.Message;
        }

        //CloseSQL();
        ad.Dispose();
        ad = null;

        return dt;
    }





    public string RunSqlStr(string sqlStr, string sCondi)
    {
        SqlCommand cmd = new SqlCommand(sqlStr, SqlConn);
        SqlTransaction trans;
        trans = SqlConn.BeginTransaction();
        cmd.Transaction = trans;

        try
        {
            cmd.ExecuteNonQuery();
            trans.Commit();
            //tmpStr = "Success";
        }
        catch (Exception ex)
        {
            trans.Rollback();
            //tmpStr = "資料庫執行發生錯誤:" + ex.Message;
        }

        CloseSQL();
        cmd.Dispose();
        cmd = null;

        return "";
    }

    public string twoSqlStr(string sqlStr, string sqlaa, string sCondi)
    {
        string tmpStr = "Success";
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
