using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SomtelTechnicalManagmentSystem_STM.Models.LoginModel
{
    public class Privilege 
    {
        [Key]
        public int Id { get; set; }
        public int PrivilegeId { get; set; }
        [ForeignKey("PrivilegeId")]
        public PrivilegeName PrivilegeName { get; set; }
        public int LoginId { get; set; }
        [ForeignKey("LoginId")]
        public Login Login { get; set; }
        public bool DeleteFlag { get; set; }
    }
}
