using SomtelTechnicalManagmentSystem_STM.Models.LoginModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SomtelTechnicalManagmentSystem_STM.Models.TaskModel
{
    public class TaskStatus
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Status")]
        public string StatusName { get; set; }
        public string Style { get; set; }
        public bool DeleteFlag { get; set; }
        public DateTime CreationDate { get; set; }
        public int? TeamId { get; set; }
        [ForeignKey("TeamId")]
        public Team Team { get; set; }

    }
}
