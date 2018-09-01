using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using DTO;


public class UserService : IUserService
{
    private readonly IConnDB _coonDB;

    public UserService(IConnDB connDB)
    {
        this._coonDB = connDB;
    }

    public UserDTO GetUser(LoginDTO loginDTO)
    {
        if (string.IsNullOrEmpty(loginDTO.Account) || string.IsNullOrEmpty(loginDTO.Password))
            return null;

        loginDTO.Password = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(loginDTO.Password + "ABCD", "sha1");

        string sqlstr = "SELECT * FROM [dbo].[User] where Account=@Account and Password=@Password";
        IDictionary<string, string> SqlParameter = new Dictionary<string, string>();
        SqlParameter.Add("@Account", loginDTO.Account);
        SqlParameter.Add("@Password", loginDTO.Password);
        DataTable dt = _coonDB.LoadTable_SQL(sqlstr, SqlParameter);

        UserDTO userDTO = dt.AsEnumerable()
                   .Select(x => new UserDTO()
                   {
                       Account = x.Field<string>("Account"),
                       Authority = x.Field<byte>("Authority"),
                       Name = x.Field<string>("Name"),
                       Email = x.Field<string>("Email"),
                       Phone = x.Field<string>("Phone"),
                       Birthday = x.Field<DateTime>("Birthday"),
                       Status = x.Field<byte>("Status")
                   }).SingleOrDefault();

        return userDTO;
    }
}