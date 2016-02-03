using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.Interface.Entities;

namespace WebUI.Models
{
    public class CreateUserModel
    {
        public List<BllRoleEntity> Roles { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}