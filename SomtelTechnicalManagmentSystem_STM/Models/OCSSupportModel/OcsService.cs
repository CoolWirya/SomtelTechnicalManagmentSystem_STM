using System.ComponentModel.DataAnnotations;

namespace SomtelTechnicalManagmentSystem_STM.Models.OCSSupportModel
{
    public class OcsService
    {
        [Key]
        public int id { get; set; }
        public string ServiceName { get; set; }
        public int ServiceID { get; set; }
        public string ServiceType { get; set; }
        public int Duration { get; set; }
        public string DurationType { get; set; }
        public string Channel { get; set; }
        public string FreeUnitVolume { get; set; }
        public string FreeUnitName{ get; set; }
        public string FreeUnitId { get; set; }
        public float Price { get; set; }
        public bool DeleteFlag { get; set; }
    }
}
