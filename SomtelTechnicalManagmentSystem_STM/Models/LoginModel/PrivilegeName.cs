using System.ComponentModel.DataAnnotations;

namespace SomtelTechnicalManagmentSystem_STM.Models.LoginModel
{
    public class PrivilegeName
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool DeleteFlag { get; set; }
    }
}
