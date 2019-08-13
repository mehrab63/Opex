using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opex.Models
{
    public class TblRefrences
    {

        public int RefrenceId { get; set; }
        public int? LetterId { get; set; }
        public string Command { get; set; }
        public int? Status { get; set; }
        public DateTime? VisitDate { get; set; }
        public int? FromUser { get; set; }
        public int? ToUser { get; set; }
        public string ReplayMessage { get; set; }
        public int? ReferId { get; set; }
        public bool? IsClose { get; set; }
        public string ReferAbout { get; set; }
        public string Periority { get; set; }
        public bool? IsEdit { get; set; }
        public string ReferDate { get; set; }
        public string ReferTime { get; set; }
        public DateTime? ExpireDate { get; set; }
    }
}
