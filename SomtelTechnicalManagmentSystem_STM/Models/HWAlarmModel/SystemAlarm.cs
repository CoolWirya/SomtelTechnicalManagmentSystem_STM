using SomtelTechnicalManagmentSystem_STM.Models.LoginModel;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SomtelTechnicalManagmentSystem_STM.Models.HWAlarmModel
{
    public class SystemAlarm
    {
        [Key]
        public int Id { get; set; }
        public string System { get; set; }
        public bool Status { get; set; }
        public int? TeamId { get; set; }
        [ForeignKey("TeamId")]
        public Team Team { get; set; }
        public DateTime AlarmDate { get; set; }
        public bool DeleteFlag { get; set; }
    }
}
