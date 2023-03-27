using SomtelTechnicalManagmentSystem_STM.Models.LoginModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SomtelTechnicalManagmentSystem_STM.Models.ViewPrivilegesModel
{
    public class PrivilegesView
    {
        [Display(Name ="Username")]
        public string Username { get; set; }
        [Display(Name = "Privileges Names")]
        public string MyPrivileges { get; set; }
        public List<Login> logins { get; set; }
        public List<PrivilegeName> PrivilegeNames { get; set; }

    }
}
