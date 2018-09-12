using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace DTO
{
    public class UserDTO
    {
        public string Account { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public byte Authority { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime Birthday { get; set; }
        public byte Status { get; set; }
    }
}