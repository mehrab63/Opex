using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Opex.Models
{
    public partial class TblBinarys
    {
        public long BinaryId { get; set; }
        public string FileFormat { get; set; }
        public byte[] Binary { get; set; }
        // [Required(ErrorMessage ="عنوان مدرک را انتخاب کنید")]
        public string Subject { get; set; }
        public string Description { get; set; }
        public int? CreateUser { get; set; }
        public DateTime? EditDate { get; set; }
        public int? EtCode { get; set; }
        public string Ddate { get; set; }
        public string Number { get; set; }
        public string RelatedBinarys { get; set; }
        public bool? IsEdit { get; set; }
        public bool? NoNeedScan { get; set; }
        public int? NoNeedScanUser { get; set; }
    }
}
