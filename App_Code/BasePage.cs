using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Security;

public class BasePage : System.Web.UI.Page
{
    public UserDTO BackUser { get; private set; }
    public bool IsLogin { get; private set; }

    public BasePage()
    {
        FormsIdentity formsIdentity = HttpContext.Current.User.Identity as FormsIdentity;
        if (formsIdentity != null)
        {
            BackUser = new UserDTO();
            GetUserInfo(formsIdentity.Ticket);
            IsLogin = true;
        }
    }

    private void GetUserInfo(FormsAuthenticationTicket ticket)
    {  
        var _userData = ticket.UserData.Split(';');

        foreach (var item in _userData)
        {
            string key = item.Split('=')[0];
            string value = item.Split('=')[1];

            switch (key)
            {
                case "Account":
                    BackUser.Account = value;
                    break;
                case "Name":
                    BackUser.Name = value;
                    break;
                case "Authority":
                    BackUser.Authority = (byte)int.Parse(value);
                    break;
                case "Status":
                    BackUser.Status = (byte)int.Parse(value);
                    break; 
            }
        }
    }
}