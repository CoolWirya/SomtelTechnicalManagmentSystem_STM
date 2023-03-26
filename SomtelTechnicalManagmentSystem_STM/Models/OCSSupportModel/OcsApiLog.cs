using System;

namespace SomtelTechnicalManagmentSystem_STM.Models.OCSSupportModel
{
    public class OcsApiLog
    {
        public int id { get; set; }
        public string ExchangeNo { get; set; }
        public string ApiRequest { get; set; }
        public string ApiResponse { get; set; }
        public string ApiFunction { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
