using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GoogleLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string clinet_id = "199438328579-aohhe0iahj2u6afd5f6uc3j45eg867c0.apps.googleusercontent.com";   //申請的Client_id
        string redirect_uri = "http://localhost:51371/GoogleAuthentication.aspx";       // CallBack URL，在設定的時候後就要指定你授權給哪個URL，Google callBack 丟資訊回來，會丟到這頁
        string scope = "https://www.googleapis.com/auth/userinfo.profile+https://www.googleapis.com/auth/userinfo.email";  //存取範圍，你要要存取那些範圍的資料 可以一次多個 只要用 + 連接就可以

        #region Google OAuth2 API，v2 Scope 
        //=> https://developers.google.com/identity/protocols/googlescopes

        //Example
        //https://www.googleapis.com/auth/plus.login	    了解您圈子中的人員名單，年齡範圍和語言
        //https://www.googleapis.com/auth/plus.me	        知道你是誰在Google上
        //https://www.googleapis.com/auth/userinfo.email	查看您的電子郵件地址
        //https://www.googleapis.com/auth/userinfo.profile  查看您的基本資料信息
        #endregion

        var getGoogleCodeUrl = string.Format("https://accounts.google.com/o/oauth2/auth?response_type=code&client_id={0}&redirect_uri={1}&scope={2}", clinet_id, redirect_uri, scope);

        Response.Redirect(getGoogleCodeUrl);  //導向登入頁
    }
}