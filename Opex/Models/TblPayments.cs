using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opex.Models
{
    public class TblPayments
    {
        public int PaymentId { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? CreateUser { get; set; }
        public int? EtCode { get; set; }
        public int? SystemCode { get; set; }
        public int? PaymentType { get; set; }
        public string PaymentAbout { get; set; }
        public long? PaymentPrice { get; set; }
        public int? FromYear { get; set; }
        public int? ToYear { get; set; }
        public long? Discount { get; set; }
        public long? TotalPrice { get; set; }
        public long? Mandeh { get; set; }
        public string FishNum { get; set; }
        public string FishDate { get; set; }
        public string FishBank { get; set; }
        public string FishComment { get; set; }
        public string CheckNum { get; set; }
        public string CheckDate { get; set; }
        public string CheckShobe { get; set; }
        public string CheckBank { get; set; }
        public string CheckComment { get; set; }
        public int? OldPaymentId { get; set; }
        public bool? IsEdit { get; set; }
        public int? CheckStateId { get; set; }
        public string DateSabt { get; set; }
        public int? BinaryId { get; set; }
    }
}
