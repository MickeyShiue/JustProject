using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class help : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {

        if (LinkButton_註冊.Visible == true)
        {
            LinkButton_註冊.Visible = false;
            LinkButton_登入.Visible = false;
            return;
        }
        if (LinkButton_註冊.Visible == false)
        {
             LinkButton_註冊.Visible = true;
            LinkButton_登入.Visible = true;
            return;
        }
    }
    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        if(LinkButton_發文.Visible == true)
        {
            LinkButton_發文.Visible = false;
            LinkButton_回復.Visible = false;
            LinkButton_上傳.Visible = false;
            return;
        }
        if (LinkButton_發文.Visible == false)
        {
            LinkButton_發文.Visible = true;
            LinkButton_回復.Visible = true;
            LinkButton_上傳.Visible = true;
            return;

        }
    }
    protected void LinkButton9_Click(object sender, EventArgs e)
    {
        if (LinkButton_設好友.Visible == true)
        {
            LinkButton_設好友.Visible = false;
            LinkButton_設追蹤.Visible = false;
            LinkButton_舉報.Visible = false;
            LinkButton_搜文.Visible = false;
            return;
        }
        if (LinkButton_設好友.Visible == false)
        {
            LinkButton_設好友.Visible = true;
            LinkButton_設追蹤.Visible = true;
            LinkButton_舉報.Visible = true;
            LinkButton_搜文.Visible = true;
            return;
        }
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        if (Label_註冊解答.Visible == false)
        {
            Label_註冊解答.Visible = true;
            LinkButton_導註冊.Visible = true;
            Label2.Visible = true;
            return;
        }
        if (Label_註冊解答.Visible == true)
        {
            Label_註冊解答.Visible = false;
            LinkButton_導註冊.Visible = false;
            Label2.Visible = false;
            return;
        }
    }
    protected void  LinkButton4_Click(object sender, EventArgs e)
{
    if (Label_登入解答.Visible == false)
        {
            Label_登入解答.Visible = true;
            return;
        }
    if (Label_登入解答.Visible == true)
        {
            Label_登入解答.Visible = false;
            return;
        }
}
protected void  LinkButton6_Click(object sender, EventArgs e)
{
    if (Label_發文解答.Visible == false)
        {
            Label_發文解答.Visible = true;
            return;
        }
    if (Label_發文解答.Visible == true)
        {
            Label_發文解答.Visible = false;
            return;
        }

}
protected void  LinkButton7_Click(object sender, EventArgs e)
{
    if (Label_回復解答.Visible == false)
        {
            Label_回復解答.Visible = true;
            return;
        }
    if (Label_回復解答.Visible == true)
        {
            Label_回復解答.Visible = false;
            return;
        }
}
protected void LinkButton8_Click(object sender, EventArgs e)
{
    if (Label_上傳解答.Visible == false)
    {
        Label_上傳解答.Visible = true;
        return;
    }
    if (Label_上傳解答.Visible == true)
    {
        Label_上傳解答.Visible = false;
        return;
    }
}
protected void LinkButton10_Click(object sender, EventArgs e)
{
    if (Label_好友解答.Visible == false)
    {
        Label_好友解答.Visible = true;
        return;
    }
    if (Label_好友解答.Visible == true)
    {
        Label_好友解答.Visible = false;
        return;
    }
}
protected void LinkButton11_Click(object sender, EventArgs e)
{
    if (Label_追蹤解答.Visible == false)
    {
        Label_追蹤解答.Visible = true;
        return;
    }
    if (Label_追蹤解答.Visible == true)
    {
        Label_追蹤解答.Visible = false;
        return;
    }
}
protected void LinkButton12_Click(object sender, EventArgs e)
{
    if (Label_舉報解答.Visible == false)
    {
        Label_舉報解答.Visible = true;
        return;
    }
    if (Label_舉報解答.Visible == true)
    {
        Label_舉報解答.Visible = false;
        return;
    }
}
protected void LinkButton13_Click(object sender, EventArgs e)
{
    if (Label_搜文解答.Visible == false)
    {
        Label_搜文解答.Visible = true;
        return;
    }
    if (Label_搜文解答.Visible == true)
    {
        Label_搜文解答.Visible = false;
        return;
    }
}
}