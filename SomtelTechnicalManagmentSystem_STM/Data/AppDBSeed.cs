using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SomtelTechnicalManagmentSystem_STM.Models.TaskModel;
using SomtelTechnicalManagmentSystem_STM.Models.LoginModel;

using System.Collections.Generic;
using System.Linq;
using System;

namespace SomtelTechnicalManagmentSystem_STM.Data
{
    public class AppDBSeed
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();
                if (!context.Logins.Any())
                {
                    context.Logins.AddRange(new List<Login>()
                    {
                        new Login ()
                        {
                            FullName="Ismail Osman",
                            CreationDate = DateTime.Now,
                            LastLoginDate = DateTime.Now,

                            Activate = true,
                        },
                         new Login ()
                        {
                            FullName="Rashid Mahamoud",
                            CreationDate = DateTime.Now,
                            LastLoginDate = DateTime.Now,
                            Activate = true,
                        },

                           new Login ()
                        {
                            FullName="Mustafa Saeed",
                            CreationDate = DateTime.Now,
                            LastLoginDate = DateTime.Now,
                            Activate = true,
                        },
                    });

                }
                context.SaveChanges();
                var logins = context.Logins.ToList();
                var UserIsmail = logins.Where(x => x.FullName == "Ismail Osman").Select(x => x.Id);
                var UserMustafa = logins.Where(x => x.FullName == "Mustafa Saeed").Select(x => x.Id);
                if (!context.Privileges.Any())
                {
                   
                    //context.Privileges.AddRange(new List<Privilege>()
                    //{

                    //   //new Privilege()
                    //   //{

                    //   //    PermissionName = "Admin",
                    //   //    LoginId = UserIsmail.ElementAt(0),
                           
                           

                    //   //},
                    //   //new Privilege()
                    //   //{

                    //   //    PermissionName = "Employee",
                    //   //    LoginId =  UserMustafa.ElementAt(0)
                    //   //}
                    //});
                    //context.SaveChanges();

                }
                if (!context.Teams.Any())
                {
                    context.Teams.AddRange(new List<Team>()
                    {
                        new Team()
                        {
                            TeamName = "OCS",
                            CreationDate = DateTime.Now
                        },
                         new Team()
                        {
                            TeamName = "Development",
                            CreationDate = DateTime.Now
                        }

                    });

                }
                context.SaveChanges();
                var teams = context.Teams.ToList();
                var team1 = teams.Where(x => x.TeamName == "OCS").Select(x => x.Id);
                var team2 = teams.Where(x => x.TeamName == "Development").Select(x => x.Id);
                if (!context.TaskStatus.Any())
                {
                    context.TaskStatus.AddRange(new List<TaskStatus>()
                    {
                        new TaskStatus()
                        {
                          StatusName = "Ongoing",
                          CreationDate = DateTime.Now

                        },
                          new TaskStatus()
                        {
                          StatusName = "Onhold",
                          CreationDate = DateTime.Now

                        },
                          new TaskStatus()
                        {
                          StatusName = "Escalated",
                          CreationDate = DateTime.Now
                        },
                          new TaskStatus()
                        {
                          StatusName = "Cancelled",
                          CreationDate = DateTime.Now
                        },
                          new TaskStatus()
                        {
                          StatusName = "Completed",
                          CreationDate = DateTime.Now
                        }



                    });

                }
               
                if (!context.TaskTypes.Any())
                {
                    context.TaskTypes.AddRange(new List<TaskType>()
                    {
                        new TaskType ()
                        {
                            TypeName= "Integration",
                            TeamId = team1.ElementAt(0),
                            CreationDate = DateTime.Now 
                        },
                        new TaskType ()
                        {
                            TypeName= "Migration",
                            TeamId = team2.ElementAt(0),
                            CreationDate = DateTime.Now



                        }
                    }); 

                }
                if (!context.TeamEquibment.Any())
                {
                    context.TeamEquibment.AddRange(new List<TeamEquibment>()
                    {
                         new TeamEquibment()
                        {
                             EquibmentName = "OCS",
                              TeamId = team1.ElementAt(0),
                              CreationDate = DateTime.Now
                        },
                          new TeamEquibment()
                        {
                             EquibmentName = "SMSC",
                              TeamId = team2.ElementAt(0),
                              CreationDate = DateTime.Now
                        }
                    });

                }
                if (!context.TeamMembers.Any())
                {
                    context.TeamMembers.AddRange(new List<TeamMember>()
                    {
                        new TeamMember()
                        {
                            MemberId   = UserIsmail.ElementAt(0),
                            TeamId =  team1.ElementAt(0),
                            CreationDate = DateTime.Now
                        },
                         new TeamMember()
                        {
                            MemberId   = UserMustafa.ElementAt(0),
                            TeamId =  team2.ElementAt(0),
                            CreationDate = DateTime.Now
                        }
                    });

                }

                context.SaveChanges();
                var statuses = context.TaskStatus.ToList();
                var status1 = statuses.Where(x => x.StatusName == "Ongoing").Select(x => x.Id);
                var status2 = statuses.Where(x => x.StatusName == "Completed").Select(x => x.Id);
                var types = context.TaskTypes.ToList();
                var type1 = types.Where(x => x.TypeName == "Integration").Select(x => x.Id);
                var type2 = types.Where(x => x.TypeName == "Migration").Select(x => x.Id);
                var members = context.TeamMembers.ToList();
                var member1 = members.Where(x => x.TeamId == team1.ElementAt(0)).Select(x => x.Id);
                var member2 = members.Where(x => x.TeamId == team2.ElementAt(0)).Select(x => x.Id);
                if (!context.Tasks.Any())
                {
                    context.Tasks.AddRange(new List<Task>()
                    {
                        new Task()
                        {
                            Name = "Task1",
                            TaskEquibment = "OCS,SMSC",
                            MembersAssigned = "Ismail Jama & Mustafa Saed",
                            StatusId = status1.ElementAt(0),
                            TeamId = team1.ElementAt(0),
                            TeamMemberId = member1.ElementAt(0),
                            TaskTypeId = type1.ElementAt(0),
                            Email = "ismail.jama@somtelnetwork.net",
                            CreatedBy = "Ismail Jama",
                            CreationDate = DateTime.Now,



                        },
                         new Task()
                        {
                            Name = "Task2",
                            TaskEquibment = "Dev Server 1",
                            MembersAssigned = "Mustafa Saed",
                            StatusId = status2.ElementAt(0),
                            TeamId = team2.ElementAt(0),
                            TeamMemberId = member2.ElementAt(0),
                            TaskTypeId = type2.ElementAt(0),
                            Email = "mustafa.saed@dahabshiil.net",
                            CreatedBy = "Mustafa Saed",
                            CreationDate = DateTime.Now.AddMonths(-1),
                            CompletionDate = DateTime.Now



                        }
                    });

                }
                context.SaveChanges();
                var tasks = context.Tasks.ToList();
                var tasks1 = tasks.Where(x => x.Name == "Task1").Select(x => x.Id);
                var tasks2 = tasks.Where(x => x.Name == "Task2").Select(x => x.Id);
                if(!context.TaskUpdates.Any())
                {
                    context.TaskUpdates.AddRange(new List<TaskUpdate>()
                    {
                       new TaskUpdate()
                       {
                           TaskId = tasks1.ElementAt(0),
                           Description = "Task One Ongoing",
                           UpdateDate = DateTime.Now.AddMonths(-1)
                           
                       },
                       new TaskUpdate()
                       {
                           TaskId = tasks1.ElementAt(0),
                           Description = "Task Two Completed",
                           UpdateDate = DateTime.Now

                       },
                    });
                }
                context.SaveChanges();
            }
        }
    }
}
