using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SomtelTechnicalManagmentSystem_STM.Models.HWAlarmModel
{
    public class Alarm
    {
        [Key]
        public int Id { get; set; }
        public int ServerAlarmID { get; set; }
        public string AlarmType { get; set; }
        public string Server { get; set; }
        public string System { get; set; }
        public string Description { get; set; }
        public DateTime AlarmDate { get; set; }
        [ForeignKey("ServerAlarmID")]
        public ServerAlarm ServerAlarm { get; set; }
        public bool DeleteFlag { get; set; }
    }
}
