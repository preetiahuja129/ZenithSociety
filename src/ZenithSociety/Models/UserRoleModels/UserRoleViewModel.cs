using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZenithSociety.Models.UserRoleModels
{
    public class UserRoleViewModel
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }
        public List<SelectListItem> Users { get; set; }
        public List<SelectListItem> Roles { get; set; }
        public string UserName { get; set; }
        public string RoleName { get; set; }
    }
}
