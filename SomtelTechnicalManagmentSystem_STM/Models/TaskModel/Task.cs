using SomtelTechnicalManagmentSystem_STM.Models.LoginModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SomtelTechnicalManagmentSystem_STM.Models.TaskModel
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Task Name")]
        public string Name { get; set; }
        [Display(Name = "Task eMail")]
        public string Email { get; set; }
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }
        [Display(Name = "Deleted By")]
        public string DeletedBy { get; set; }
        [Display(Name = "Updated By")]
        public string UpdatedBy { get; set; }
        [Display(Name = "Creation Date")]
        public DateTime CreationDate { get; set; }
        [Display(Name = "Update Date")]
        public DateTime UpdateDate { get; set; }
        [Display(Name = "Deletion Date")]
        public DateTime DeletionDate { get; set; }
        [Display(Name = "Completion Date")]
        public DateTime CompletionDate { get; set; }

        public string MembersAssigned { get; set; }
        public int TaskTypeId { get; set; }
        [ForeignKey("TaskTypeId")]
        public TaskType TaskType { get; set; }
        public int  StatusId { get; set; }
        [ForeignKey("StatusId")]
        public TaskStatus TaskStatus { get; set; }
        public string TaskEquibment { get; set; }

        public int TeamMemberId { get; set; }
        [ForeignKey("TeamMemberId")]
        public TeamMember TeamMember { get; set; }
     
        public int? TeamId { get; set; }
        [ForeignKey("TeamId")]
        public Team Team { get; set; }
    }
}
