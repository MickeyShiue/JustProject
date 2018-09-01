using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public interface IUserService
{
    UserDTO GetUser(LoginDTO loginDTO);
}