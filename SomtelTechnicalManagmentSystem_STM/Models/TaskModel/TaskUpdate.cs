using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SomtelTechnicalManagmentSystem_STM.Models.TaskModel
{
    public class TaskUpdate
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime UpdateDate { get; set; }
        public int TaskId { get; set; }
        [ForeignKey("TaskId")]
        public Task Task { get; set; }

    }
}
