using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Opex.Models
{
    public class TblQuestionnaire
    {
        [Key]
        public int Qid { get; set; }
        public string Question1 { get; set; }//عضو كدام تشكل يا انجمن صنفي هستيد؟  (با ذكر تاريخ عضويت)
        public string Question11 { get; set; }//- اتاق های بازرگانی سراسر کشور: (لطفاً نام ببرید)
        public string Question12 { get; set; }// اتاق های مشترک ایران با سایر کشورها  (لطفاً نام ببرید)
        public string Question13 { get; set; }//اتحادیه ها و تشکل های صنفی دیگر  (لطفاً نام ببرید)
        public string Question14 { get; set; }//هرگونه تشکل یا سازمان و ارگانهای غیر دولتی  (لطفاً نام ببرید)
        public string Question2 { get; set; }//2- آیا اعضاء هیئت مدیره یا مدیر عامل آن شرکت محترم عضو هیأت مدیره تشکل های دیگر صنفی، اقتصادی، اجتماعی و امثالهم میباشد؟ (لطفاً نام ببرید
        public string Question3 { get; set; }// 3- آیا اعضاء هیئت مدیره یا مدیر عامل آن شرکت محترم عضو هیأت مدیره یا مدیر عامل و یا سهامدار عمده شرکت های دیگری نیز می باشند؟
        public string Question3Disp { get; set; }//لطفاً نام هر یک از شرکت ها و سمت فرد مربوطه و نوع فعالیت شرکت مزبور را مرقوم فرمائید. (لطفاً نام ببرید
        public string Question4 { get; set; }//4- آیا آن شرکت در خارج از ایران دارای دفتر یا نمایندگی و یا شعبه می باشد؟
        public string Question4Disp { get; set; }//لطفاً اسم کشورها را مرقوم فرمائید
        public string Question5 { get; set; }//5- در صورت نیاز به برگزاری جلسات و یا پیگیری کارهای اتحادیه در سازمان ها، نهادها و مراجع قانونی تحت پوشش سه قوه مملکتی آیا اتحادیه می تواند از کمک آن عضو محترم بهره گیری نماید؟
        public int? SystemCode { get; set; }//Tbl_members->MemberId
        public int? CodeYekta { get; set; }//Tbl_Members -> کد یکنا
        public DateTime? CreateTime { get; set; }//تاریخ ثبت
    }
}
