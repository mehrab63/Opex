using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opex.Models
{
    public class TblDocuments
    {
        public int DocumentId { get; set; }
        public string DocumentName { get; set; }// varchar(300)    Checked
        public int? EtCode { get; set; }
        public int? CreateUser { get; set; }
        public DateTime? EditDate { get; set; }
        public bool? IsForce { get; set; }
        public bool? isEdit { get; set; } 
       
    }
}
