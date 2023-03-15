using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SomtelTechnicalManagmentSystem_STM.Models.HWAlarmModel
{
    public class ServerAlarm
    {
        [Key]
        public int Id { get; set; }
        public int SystemAlarmID { get; set; }
        public string Server { get; set; }
        public bool Status { get; set; }
        public DateTime AlarmDate { get; set; }
        [ForeignKey("SystemAlarmID")]
        public SystemAlarm SystemAlarm { get; set; }

    }
}

