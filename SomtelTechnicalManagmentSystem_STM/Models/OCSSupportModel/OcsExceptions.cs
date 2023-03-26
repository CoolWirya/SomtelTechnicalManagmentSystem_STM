using System;
using System.ComponentModel.DataAnnotations;

namespace SomtelTechnicalManagmentSystem_STM.Models.OCSSupportModel
{
    public class OcsExceptions
    {
        [Key]
        public int id { get; set; }
        public int ExchangeNo { get; set; }
        public string Exception { get; set; }
        public string ExceptionFrom { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
