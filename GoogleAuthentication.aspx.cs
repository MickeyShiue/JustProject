using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GoogleAuthentication : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string postString = string.Empty;

        if (Request["code"] != null)
        {
            string code = Request["code"].ToString();
            TokenInfo token = GetToken(code);

            if (token != null)
            {
                UserInfo LoginUserData = GetUserInfo(token);

                string userData = string.Format("Account={0};Name={1};Authority={2};Status={3};LoginTime={4}",
                                      LoginUserData.email,
                                      LoginUserData.name,
                                      "1",
                                      "0",
                                      HttpUtility.UrlEncode(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")));

                FormsAuthenticationTicket fat = new FormsAuthenticationTicket(1, LoginUserData.name, DateTime.Now, DateTime.Now.AddMinutes(600), false, userData);
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(fat));
                cookie.HttpOnly = true;
                Response.Cookies.Add(cookie);
                Response.Redirect("Index.aspx");
            }
        }
        else
        {
            
        }
    }

    private TokenInfo GetToken(string code)
    {
        string client_id = "199438328579-aohhe0iahj2u6afd5f6uc3j45eg867c0.apps.googleusercontent.com";  //google client_id
        string client_secret = "6SzFl0qZTMd41nXgwHjSwJ6Z";                                              //google client_secret
        string redirect_uri = "http://localhost:51371/GoogleAuthentication.aspx";                                   //Callbackurl

        string postString = string.Format("code={0}&client_id={1}&client_secret={2}&redirect_uri={3}&grant_type=authorization_code", code, client_id, client_secret, redirect_uri);

        string url = "https://accounts.google.com/o/oauth2/token";

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url.ToString());
        request.Method = "POST";
        request.ContentType = "application/x-www-form-urlencoded";

        UTF8Encoding utfenc = new UTF8Encoding();
        byte[] bytes = utfenc.GetBytes(postString);
        Stream os = null;
        try
        {
            request.ContentLength = bytes.Length;
            os = request.GetRequestStream();
            os.Write(bytes, 0, bytes.Length);
        }
        catch
        {

        }

        HttpWebResponse webResponse = (HttpWebResponse)request.GetResponse();
        Stream responseStream = webResponse.GetResponseStream();
        StreamReader responseStreamReader = new StreamReader(responseStream);
        var result = responseStreamReader.ReadToEnd();//parse token from result
        TokenInfo token = JsonConvert.DeserializeObject<TokenInfo>(result);

        return token;
    }

    private UserInfo GetUserInfo(TokenInfo token)
    {
        string uri = "https://www.googleapis.com/oauth2/v1/userinfo";
        string result = "";

        HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
        request.Method = "GET";
        request.Headers.Add(HttpRequestHeader.AcceptLanguage, "zh-tw");
        request.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token.access_token);

        using (var response = request.GetResponse())
        {
            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
            {
                result = sr.ReadToEnd();
            }
        }

        UserInfo userinfo = JsonConvert.DeserializeObject<UserInfo>(result);
        return userinfo;
    }

    public class TokenInfo //Token 相關資訊
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
        public string id_token { get; set; }
        public string token_type { get; set; }
    }

    public class UserInfo  //user 相關資運
    {
        public string id { get; set; }
        public string email { get; set; }
        public string verified_email { get; set; }
        public string name { get; set; }
        public string given_name { get; set; }
        public string family_name { get; set; }
        public string picture { get; set; }
        public string gender { get; set; }
        public string locale { get; set; }
    }
}