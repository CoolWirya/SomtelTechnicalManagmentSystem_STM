using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SomtelTechnicalManagmentSystem_STM.Models.LoginModel
{
    public class Privileges
    {
        [Key]
        public int Id { get; set; }
        public string PermissionName { get; set; }
        public int LoginId { get; set; }
        [ForeignKey("LoginId")]
        public Login Login { get; set; }
    }
}
