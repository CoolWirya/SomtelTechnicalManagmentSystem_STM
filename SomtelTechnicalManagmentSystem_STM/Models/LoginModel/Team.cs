using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SomtelTechnicalManagmentSystem_STM.Models.LoginModel
{
    public class Team
    {
        [Key]
        public int Id { get; set; }
        public string TeamName { get; set; }
        public bool DeleteFlag { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
