using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opex.Models
{
    public class TblLettersGroup
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public string Name { get; set; }
        public string Tels { get; set; }
        public string Fax { get; set; }
        public string Manager { get; set; }
        public string Address { get; set; }
        public string EceAddress { get; set; }
        public int? EtCode { get; set; }
        public int? CreateUser { get; set; }
        public DateTime? EditDate { get; set; }
        public int? OldGroupId { get; set; }
        public string RelatedSubjects { get; set; }
        public bool? IsEdit { get; set; }
        public string PtoPaddress { get; set; }
        public string EmailAddress { get; set; }
    }
}
