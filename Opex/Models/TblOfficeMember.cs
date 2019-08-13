using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Opex.Models
{
    public class TblOfficeMember
    {
        [Key]
        public int MemberId { get; set; } //آی دی
        public string Name { get; set; }//خالی
        [Required(ErrorMessage = "نام و نام خانوادگی را وارد کنید")]
        public string Lname { get; set; }//نام و نام خانوادگی
        public string FatherName { get; set; }//نام پدر
        public string ShShenasnameh { get; set; }//شماره شناسنامه
        [Required(ErrorMessage = "شماره ملی را وارد کنید")]
        public string ShMelli { get; set; }//شماره ملی
        public string mobile { get; set; }//شماره موبایل
        public string CenterOfficeTell { get; set; }//شماره تلفن دفتر مرکزی
        public string ProductiveUnitTell { get; set; }//شماره فکس واحد تولیدی
        public string PostAddress { get; set; }//آدرس پستی
        public string CenterOfficeName { get; set; }//نام واحد تولیدی
        public string PostCode { get; set; }//کد پستی
        public string Email { get; set; }//ایمبل
        public string WebAddress { get; set; }//آدرس وب‌ سایت
        public string OfficeRole { get; set; }// خالی
        public int? SystemCode { get; set; }//membrId->Tbl_Members
        public string CodeYekta { get; set; }//کدیکتا ->Tbl_Members
        public string BusinessName { get; set; }//نام تجاری
        public string CompanyRegisterPlace { get; set; }//محل ثبت شرکت
        public string ConnectorName { get; set; }//نام و نام خانوادگی رابط
        public string ConnectorRole { get; set; }//سمت رابط
        public string ConnectorPhone { get; set; }//شماره موبایل رابط
        [Required(ErrorMessage = "سمت شخص را وارد کنید")]
        public string Role { get; set; }                //سمت:
        public string Reshteh { get; set; }//رشته تحصیلات 
        public string DReshte { get; set; }//تحصیلات  درجه
        public string LicenceDate { get; set; }//تاریخ اخذ مدرک
        public string WorkeFlow { get; set; }//سابقه کار مرتبط با فعالیت‌های شرکت
        public DateTime? CreateDate { get; set; }//تاریخ ثبت
    }
}
