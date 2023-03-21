using Microsoft.EntityFrameworkCore;
using SomtelTechnicalManagmentSystem_STM.Models.HWAlarmModel;
using SomtelTechnicalManagmentSystem_STM.Models.LoginModel;
using SomtelTechnicalManagmentSystem_STM.Models.TaskModel;
using SomtelTechnicalManagmentSystem_STM.Models.NavBarModel;

namespace SomtelTechnicalManagmentSystem_STM.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) {}

        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskStatus> TaskStatus { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<TaskType> TaskTypes { get; set; }

        public DbSet<TaskUpdate> TaskUpdates { get; set; }

        public DbSet<TeamEquibment> TeamEquibment { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Privilege> Privileges { get; set; }
        public DbSet<Alarm> Alarms { get; set; }
        public DbSet<ServerAlarm> ServerAlarms { get; set; }
        public DbSet<SystemAlarm> SystemAlarms { get; set; }
        public DbSet<NavbarParent> NavbarParent { get; set; }
        public DbSet<PrivilegeName> PrivilegeNames { get; set; }






    }
}
