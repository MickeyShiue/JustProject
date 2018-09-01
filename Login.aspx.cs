using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.IO;
using DTO;
using System.Web.Security;

public partial class Login : System.Web.UI.Page
{
    private readonly IUserService _IUserService;

    private bool ModelStateIsValid
    {
        get
        {
            if (!string.IsNullOrWhiteSpace(_Account) && !string.IsNullOrWhiteSpace(_Password))
            {
                return true;
            }
            return false;
        }
    }

    public string _Account
    {
        get
        {
            return Request.Form["ctl00$ContentPlaceHolder1$Account"];
        }
    }

    public string _Password
    {
        get
        {
            return Request.Form["ctl00$ContentPlaceHolder1$Password"];
        }
    }

    private enum AlertStatus
    {
        error = 0,
        success = 1,
        warning = 2
    }

    public Login()
    {
        _IUserService = new UserService(new ConnDB());
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (ModelStateIsValid)
        {
            LoginDTO loginDTO = new LoginDTO();
            loginDTO.Account = _Account;
            loginDTO.Password = _Password;
            UserDTO userinfo = _IUserService.GetUser(loginDTO);

            if (userinfo == null)
            {
                SetAlertMsg(AlertStatus.error);
            }
            else
            {
                string userData = string.Format("Account={0};Name={1};Authority={2};Status={3};LoginTime={4};",
                                        userinfo.Account,
                                        userinfo.Name,
                                        userinfo.Authority.ToString(),
                                        userinfo.Status.ToString(),
                                        HttpUtility.UrlEncode(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")));

                FormsAuthenticationTicket fat = new FormsAuthenticationTicket(1, userinfo.Name, DateTime.Now, DateTime.Now.AddMinutes(600), false, userData);
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(fat));
                cookie.HttpOnly = true;
                Response.Cookies.Add(cookie);
                SetAlertMsg(AlertStatus.success);
            }
        }
        else
        {
            SetAlertMsg(AlertStatus.warning);
        }
    }

    private void SetAlertMsg(AlertStatus status)
    {
        switch (status)
        {
            case AlertStatus.error:
                AlertTitle.Value = "錯誤";
                AlertContent.Value = "帳號密碼錯誤!!";
                AlertType.Value = "error";
                break;

            case AlertStatus.success:
                AlertTitle.Value = "成功";
                AlertContent.Value = "登入成功";
                AlertType.Value = "success";
                break;

            case AlertStatus.warning:
                AlertTitle.Value = "提醒";
                AlertContent.Value = "請確實輸入帳號密碼!!";
                AlertType.Value = "warning";
                break;
        }
    }

}
