using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opex.Models
{
    public class TblLetters
    {
        public int LetterId { get; set; }
        public int? CreateUser { get; set; }
        public DateTime? CreateDate { get; set; }
        public string LetterNum { get; set; }
        public string SystemLetterNum { get; set; }
        public string LetterDate { get; set; }
        public string Arjaiat { get; set; }
        public string DocumentType { get; set; }
        public string SendType { get; set; }
        public int? RelateLetterId { get; set; }
        public int? supplier { get; set; }
        public int? Sender { get; set; }
        public int? Reciver { get; set; }
        public string Subjects { get; set; }
        public int? SubjectId { get; set; }
        public string Peyvast { get; set; }
        public string MemberIds { get; set; }
        public string BinaryIds { get; set; }
        public int? ReportId { get; set; }
        public string Copy { get; set; }
        public int? LetterType { get; set; }
        public string RelateLetterType { get; set; }
        public DateTime? SignDateTime { get; set; }
        public int? SignUserId { get; set; }
        public int? WhoSouldSign { get; set; }
        public int? WhoSigned { get; set; }
        public string OldLetterId { get; set; }
        public int? SignType { get; set; }
        public string Params { get; set; }
        public bool? isEdit { get; set; }
        public bool? IsVisit { get; set; }
        public string SenderName { get; set; }
        public string ReciverName { get; set; }
        public string SubjectName { get; set; }
        public string LetterTime { get; set; }
        public string CreateUserName { get; set; }
        public string Comment { get; set; }
        public int? TempFID { get; set; }
        public string TempFieldValue { get; set; }
        public string LetterContent { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string BayganiNumber { get; set; }
        public bool? IsDeactive { get; set; }
        public string DeactiveComment { get; set; }
        public string Result { get; set; }
        public string LinksLetterIds { get; set; }
        public int ArchiveId { get; set; }
        public string OtherEce { get; set; }
        public bool? EceToCopy { get; set; }
    }
}
