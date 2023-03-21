using System;
using System.Collections.Generic;

#nullable disable

namespace SomtelTechnicalManagmentSystem_STM.Models.ActiveXpertModel
{
    public partial class InsertSm
    {
        public int Id { get; set; }
        public string DirectionId { get; set; }
        public string TypeId { get; set; }
        public string StatusId { get; set; }
        public int? StatusDetailsId { get; set; }
        public string TriggerStatusId { get; set; }
        public int? TriggerDetailsId { get; set; }
        public string AckStatusId { get; set; }
        public string ChannelId { get; set; }
        public string BillingId { get; set; }
        public DateTime? ScheduledTime { get; set; }
        public DateTime? SentTime { get; set; }
        public DateTime? ReceivedTime { get; set; }
        public DateTime? LastUpdate { get; set; }
        public int? Priority { get; set; }
        public int? BatchId { get; set; }
        public int? ConversationId { get; set; }
        public string Hash { get; set; }
        public string Creator { get; set; }
        public bool? Archive { get; set; }
        public int? CustomField1 { get; set; }
        public string CustomField2 { get; set; }
        public string Trace { get; set; }
        public int? Retries { get; set; }
        public int MessageId { get; set; }
        public string ToAddress { get; set; }
        public int? ToAddressTon { get; set; }
        public int? ToAddressNpi { get; set; }
        public string FromAddress { get; set; }
        public int? FromAddressTon { get; set; }
        public int? FromAddressNpi { get; set; }
        public bool? RequestDeliveryReport { get; set; }
        public bool? IsDeliveryReport { get; set; }
        public string DeliveryStatus { get; set; }
        public int? ValidityPeriod { get; set; }
        public int? DataCoding { get; set; }
        public int? BodyFormat { get; set; }
        public bool? HasUdh { get; set; }
        public int? TotalParts { get; set; }
        public int? PartNumber { get; set; }
        public int? MultipartReference { get; set; }
        public string GsmSmscAddress { get; set; }
        public int? GsmSmscAddressTon { get; set; }
        public int? GsmSmscAddressNpi { get; set; }
        public int? SmppPriority { get; set; }
        public int? SmppStatusCode { get; set; }
        public string SmppServiceType { get; set; }
        public string SmppClient { get; set; }
        public int? SmppSequenceNumber { get; set; }
        public string SmppTlvs { get; set; }
        public string Body { get; set; }
        public string Reference { get; set; }
        public int? LanguageLockingShift { get; set; }
        public int? LanguageSingleShift { get; set; }
    }
}
