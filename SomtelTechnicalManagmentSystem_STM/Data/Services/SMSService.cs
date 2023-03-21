using SomtelTechnicalManagmentSystem_STM.Models.ActiveXpertModel;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System;

namespace SomtelTechnicalManagmentSystem_STM.Data.Services
{
    public class SMSService : ISMSService
    {
        private readonly ActiveXpertDbContext _context;
        public SMSService(ActiveXpertDbContext context)
        {
            _context = context;
        }
        public void InsertSMS(string statusId, string channelId, string toAddress, string fromAddress, string body)
        {
  

            object[] paramItems = new object[]
                {
            new SqlParameter("@StatusId", statusId),
            new SqlParameter("@ChannelId", channelId),
            new SqlParameter("@ToAddress", toAddress),
            new SqlParameter("@FromAddress", fromAddress),
            new SqlParameter("@Body", body),
              };
            //_contextSMS.InsertSms.Add(insertSMS);
            //_contextSMS.SaveChanges();

            _context.Database.ExecuteSqlRaw($"INSERT INTO InsertSms (StatusID, ChannelID, ToAddress, FromAddress, Body) VALUES (@StatusId, @ChannelId,@ToAddress,@FromAddress,@Body)", paramItems);
            _context.SaveChanges();
        }
    }
}
