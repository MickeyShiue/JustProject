using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FacebookLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string client_id = "619431961751584"; //申請的Client_id
        string redirect_uri = "http://localhost:51371/FacebookAuthentication.aspx"; // CallBack URL code會掉到那頁
        string scpoe = "email,user_gender,user_birthday";  //可以存取那些範圍 ，多個scope 可以用 , 隔開

        #region Permissions Reference - Facebook Login

        //https://developers.facebook.com/docs/facebook-login/permissions/v3.0 //scope document

        //***************Default Fields*****************
        //id
        //first_name
        //last_name
        //middle_name
        //name
        //name_format
        //picture
        //short_name
        //***********************************************
        #endregion

        string url = string.Format("https://www.facebook.com/v3.0/dialog/oauth?client_id={0}&redirect_uri={1}&scope={2}", client_id, redirect_uri, scpoe);

        Response.Redirect(url);
    }
}