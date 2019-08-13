using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Opex.Models
{
    public class TblOfficeMembers
    {
        [Key]
        public int BusinessId { get; set; }                         //آی دی
        public DateTime CreateTime { get; set; }                    //تاریخ ثبت
        public string TotalExportYear { get; set; }                 // بلا استفاده
        public string ExportDegree1 { get; set; }                   //درجه1
        public string ExportDegree2 { get; set; }                   //درجه2
        public string ExportDegree3 { get; set; }                   //درجه3
        public string ExportValueRial { get; set; }                 //ارزش صادراتی ریالی
        public string ExportValueCurency { get; set; }              //ارزش صادراتی ارزی
        public string OtherProduct { get; set; }                    //سایر فرآورده‌ها
        public string TotalProductYear { get; set; }                //مجموع تناژ تولیدی یک سال
        public string NamedProductCapacity { get; set; }            //ظرفیت اسمی محصولات مندرج در پروانه بهره‌برداری
        public string OperationalProductCapacity { get; set; }      //ظرفیت عملیاتی محصولات بر اساس پروانه بهره‌برداری
        public string EquipmentName { get; set; }                   //نام ماشین‌آلات و تجهیزات
        public string EquipmentDisp { get; set; }                   //شرح مشخصات و مدت‌زمان کارکرد
        public string EquipmentQuantity { get; set; }               //تعداد
        public string EquipmentOwnerType { get; set; }              //ملکی/استیجاری
        public string AffordabilityYear { get; set; }               //سال- (توان مالی)
        public string TotalExportProduct5Year { get; set; }         //کل محصول صادرشده (تن / بشکه)
        public string TotalExport5Year { get; set; }                //مجموعه تناژ صادراتی طی یک سال گذشته
        public string ExprotCurencyPrice { get; set; }              //مبلغ صادراتی ارزی
        public string ExportRialPrice { get; set; }                 //مبلغ صادراتی ریالی
        public string InsuranceYear { get; set; }                   // سال(بیمه)
        public string TotalInsurance { get; set; }                  //کل مبلغ بیمه تأمین اجتماعی پرداخت‌شده
        public string TotalTaxPayment { get; set; }                 //کل مبلغ مالیات پرداختی
        public int? SystemCode { get; set; }                        //MemberID from Tbl
        public int? CodeYekta { get; set; }                         //کدیکتا
    }
}
