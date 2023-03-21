using System.Threading.Tasks;

namespace SomtelTechnicalManagmentSystem_STM.Data.Services
{
    public interface ISMSService
    {
        void InsertSMS(string statusId, string channelId, string toAddress, string fromAddress, string body);
    }
}
