using System.ComponentModel.DataAnnotations;

namespace SomtelTechnicalManagmentSystem_STM.Models.NavBarModel
{
    public class NavbarParent
    {
        [Key]
        public int Id { get; set; }
        public string ParentNavbarName { get; set; }
        public string ParentAspControl { get; set; }
        public string ParentAspAction { get; set; }
        public bool DeleteFlag { get; set; }


    }
}
