using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opex.Models
{
    public class DB_Context : DbContext
    {
        public DB_Context(DbContextOptions<DB_Context> options) : base(options)
        {

        }
        #region DataBase Tables
        
        public virtual DbSet<TblBinarys> TblBinarys { get; set; }
        public virtual DbSet<TblLetters> TblLetters { get; set; }
        public virtual DbSet<TblMembers> TblMembers { get; set; }
        public virtual DbSet<TblRefrences> TblRefrences { get; set; }
        public virtual DbSet<TblQuestionnaire> TblQuestionnaires { get; set; }
        public virtual DbSet<TblOfficeMember> TblOfficeMembers { get; set; }
        public virtual DbSet<TblOfficeMembers> TblFinancialBalances { get; set; }
        public virtual DbSet<TblPayments> TblPayments { get; set; } 
        public virtual DbSet<TblLettersGroup> TblLettersGroups { get; set; }
        public virtual DbSet<TblDocuments> TblDocuments { get; set; }
         
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");
            modelBuilder.Entity<TblBinarys>(entity =>
            {
                entity.HasKey(e => e.BinaryId);

                entity.ToTable("Tbl_Binarys");

                entity.Property(e => e.Binary).HasColumnType("image");

                entity.Property(e => e.Ddate)
                    .HasColumnName("DDate")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EditDate).HasColumnType("datetime");

                entity.Property(e => e.FileFormat)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.IsEdit).HasColumnName("isEdit");

                entity.Property(e => e.Number)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RelatedBinarys)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Subject)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });
            modelBuilder.Entity<TblLetters>(entity =>
            {
                entity.HasKey(e => e.LetterId);

                entity.ToTable("Tbl_Letters");
            });
            modelBuilder.Entity<TblMembers>(entity =>
            {
                entity.HasKey(e => e.MemberId);

                entity.ToTable("Tbl_Members");

                entity.Property(e => e.BinaryIds).IsUnicode(false);

                entity.Property(e => e.DeviceId)
                    .HasColumnName("deviceId")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirebaseToken)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.IsEdit).HasColumnName("isEdit");

                entity.Property(e => e.LastFingerPrintDetect).HasColumnType("datetime");

                entity.Property(e => e.LastSent).HasColumnType("datetime");

                entity.Property(e => e.LastUpdate)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Lat).HasColumnName("lat");

                entity.Property(e => e.LetterIds).IsUnicode(false);

                entity.Property(e => e.Lng).HasColumnName("lng");

                entity.Property(e => e.OrgPictures).IsUnicode(false);

                entity.Property(e => e.PicMobasherPath)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.PicSahebPath)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.SmsIds).IsUnicode(false);

                entity.Property(e => e.آخرینبازرسی)
                    .HasColumnName("آخرین بازرسی")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.آخرینعضویت).HasColumnName("آخرین عضویت");

                entity.Property(e => e.آدرس)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.آدرسشرکت)
                    .HasColumnName("آدرس شرکت")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.آدرسمباشر)
                    .HasColumnName("آدرس مباشر")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.آدرسمنزل)
                    .HasColumnName("آدرس منزل")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.آدرسواحدصنفیقبلی)
                    .HasColumnName("آدرس واحد صنفی قبلی")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.آموزشنظامصنفی)
                    .HasColumnName("آموزش نظام صنفی")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.آموزشنظامصنفیمسلسل)
                    .HasColumnName("آموزش نظام صنفی مسلسل")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ادارهبهداشت)
                    .HasColumnName("اداره بهداشت")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.انتقالازپرونده).HasColumnName("انتقال از پرونده");

                entity.Property(e => e.انتقالبهپرونده).HasColumnName("انتقال به پرونده");

                entity.Property(e => e.انقضاءمجوزدخانی)
                    .HasColumnName("انقضاء مجوز دخانی")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.انقضاءپروانهکار)
                    .HasColumnName("انقضاء پروانه کار")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ایمیل)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.بازرسیمرحلهاولبازرس)
                    .HasColumnName("بازرسی مرحله اول بازرس")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.بازرسیمرحلهاولتاریخ)
                    .HasColumnName("بازرسی مرحله اول تاریخ")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.بازرسیمرحلهاولشمارهنامه)
                    .HasColumnName("بازرسی مرحله اول شماره نامه")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.بازرسیمرحلهاولنقص)
                    .HasColumnName("بازرسی مرحله اول نقص")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.بخش)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.بدهیازسال)
                    .HasColumnName("بدهی از سال")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.بدهیتاسال)
                    .HasColumnName("بدهی تا سال")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.بدهیسالیانه)
                    .HasColumnName("بدهی سالیانه")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.تابعیت)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.تاریخابطال)
                    .HasColumnName("تاریخ ابطال")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.تاریخابطالپرونده)
                    .HasColumnName("تاریخ ابطال پرونده")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.تاریخابطالکارتمباشر)
                    .HasColumnName("تاریخ ابطال کارت مباشر")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.تاریخاستعلامدارایی)
                    .HasColumnName("تاریخ استعلام دارایی")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.تاریخانقضاء)
                    .HasColumnName("تاریخ انقضاء")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.تاریخانقضاءاقامت)
                    .HasColumnName("تاریخ انقضاء اقامت")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.تاریخانقضاءدرخواست)
                    .HasColumnName("تاریخ انقضاء درخواست")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.تاریخاولینپروانه)
                    .HasColumnName("تاریخ اولین پروانه")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.تاریختاییداماکن)
                    .HasColumnName("تاریخ تایید اماکن")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.تاریختاییدبهداشت)
                    .HasColumnName("تاریخ تایید بهداشت")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.تاریختمبر)
                    .HasColumnName("تاریخ تمبر")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.تاریختمدید)
                    .HasColumnName("تاریخ تمدید")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.تاریختولد)
                    .HasColumnName("تاریخ تولد")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.تاریختولدمباشر)
                    .HasColumnName("تاریخ تولد مباشر")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.تاریخثبتشرکت)
                    .HasColumnName("تاریخ ثبت شرکت")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.تاریخدرخواست)
                    .HasColumnName("تاریخ درخواست")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.تاریخشناسایی)
                    .HasColumnName("تاریخ شناسایی")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.تاریخصدور)
                    .HasColumnName("تاریخ صدور")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.تاریخصدوراقامت)
                    .HasColumnName("تاریخ صدور اقامت")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.تاریخصدورشناسنامه)
                    .HasColumnName("تاریخ صدور شناسنامه")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.تاریخصدورقیمنامه)
                    .HasColumnName("تاریخ صدور قیم نامه")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.تاریخصدورمباشر)
                    .HasColumnName("تاریخ صدور مباشر")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.تاریخصدورکارتمباشر)
                    .HasColumnName("تاریخ صدور کارت مباشر")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.تاریخطرحکمیسیون)
                    .HasColumnName("تاریخ طرح کمیسیون")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.تاریخطرحکمیسیونفنی)
                    .HasColumnName("تاریخ طرح کمیسیون فنی")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.تاریخطرحکمیسیونهیئتمدیره)
                    .HasColumnName("تاریخ طرح کمیسیون هیئت مدیره")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.تاریخغیرفعال)
                    .HasColumnName("تاریخ غیرفعال")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.تاریخفوت)
                    .HasColumnName("تاریخ فوت")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.تاریخمجوزدخانی)
                    .HasColumnName("تاریخ مجوز دخانی")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.تاریخمفاصاحساب)
                    .HasColumnName("تاریخ مفاصاحساب")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.تاریخپروانهقبلی)
                    .HasColumnName("تاریخ پروانه قبلی")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.تاریخپروانهکار)
                    .HasColumnName("تاریخ پروانه کار")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.تاریخکارتبازرگانی)
                    .HasColumnName("تاریخ کارت بازرگانی")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.تاریخگذرنامه)
                    .HasColumnName("تاریخ گذرنامه")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.تاهل)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.تاهلمباشر)
                    .HasColumnName("تاهل مباشر")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.تحتتکفل)
                    .HasColumnName("تحت تکفل")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.تحصیلات)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.تحصیلاتمباشر)
                    .HasColumnName("تحصیلات مباشر")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ترازودیجیتال)
                    .HasColumnName("ترازو دیجیتال")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.تعدادتکفلمباشر).HasColumnName("تعداد تکفل مباشر");

                entity.Property(e => e.تعدادشریک).HasColumnName("تعداد شریک");

                entity.Property(e => e.تعدادپروانههایکسب).HasColumnName("تعداد پروانه های کسب");

                entity.Property(e => e.تعدادکارکنان)
                    .HasColumnName("تعداد کارکنان")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.تغییرشغل).HasColumnName("تغییر شغل");

                entity.Property(e => e.تغییرمکان).HasColumnName("تغییر مکان");

                entity.Property(e => e.تلفنرابط)
                    .HasColumnName("تلفن رابط")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.تلفنمغازه)
                    .HasColumnName("تلفن مغازه")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.تلفنمنزل)
                    .HasColumnName("تلفن منزل")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.تلفنمنزلمباشر)
                    .HasColumnName("تلفن منزل مباشر")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.تلفنهایکارخانه)
                    .HasColumnName("تلفن های کارخانه")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.تلفنهمراه)
                    .HasColumnName("تلفن همراه")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.توضیحات).HasColumnType("text");

                entity.Property(e => e.توضیحاتتابلو)
                    .HasColumnName("توضیحات تابلو")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.توضیحاتطرحکمیسیون)
                    .HasColumnName("توضیحات طرح کمیسیون")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.توضیحاتطرحکمیسیونفنی)
                    .HasColumnName("توضیحات طرح کمیسیون فنی")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.توضیحاتکمیسیونهیئتمدیره)
                    .HasColumnName("توضیحات کمیسیون هیئت مدیره")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.جنسیت)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.جنسیتمباشر)
                    .HasColumnName("جنسیت مباشر")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.جهتصنفی)
                    .HasColumnName("جهت صنفی")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.حداقلمساحت).HasColumnName("حداقل مساحت");

                entity.Property(e => e.حدودصنفی).HasColumnName("حدود صنفی");

                entity.Property(e => e.حراجاز)
                    .HasColumnName("حراج از")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.حراجازتاریخ)
                    .HasColumnName("حراج از تاریخ")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.حراجتا)
                    .HasColumnName("حراج تا")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.حراجتاتاریخ)
                    .HasColumnName("حراج تا تاریخ")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.حوزهبیمه)
                    .HasColumnName("حوزه بیمه")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.حوزهمالیاتی)
                    .HasColumnName("حوزه مالیاتی")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.حوزهکلانتری)
                    .HasColumnName("حوزه کلانتری")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.دارایمجوزدخانی).HasColumnName("دارای مجوز دخانی");

                entity.Property(e => e.درجهصنفی).HasColumnName("درجه صنفی");

                entity.Property(e => e.دستهتحصیلی)
                    .HasColumnName("دسته تحصیلی")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.دستگاهها)
                    .HasColumnName("دستگاه ها")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.دستگاهکارتخوان)
                    .HasColumnName("دستگاه کارت خوان")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.دهستان)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.دوربینمداربسته)
                    .HasColumnName("دوربین مداربسته")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.دین)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.دینمباشر)
                    .HasColumnName("دین مباشر")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.رسته)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.رستهقبلی)
                    .HasColumnName("رسته قبلی")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.رشتهتحصیلی)
                    .HasColumnName("رشته تحصیلی")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.رشتهتحصیلیمباشر)
                    .HasColumnName("رشته تحصیلی مباشر")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.روستا)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.سالآخرینعضویت).HasColumnName("سال آخرین عضویت");

                entity.Property(e => e.سالتاسیس)
                    .HasColumnName("سال تاسیس")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.سایر)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.سریشناسنامه)
                    .HasColumnName("سری شناسنامه")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.سمتشرکت)
                    .HasColumnName("سمت شرکت")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.شبکهاجتماعی)
                    .HasColumnName("شبکه اجتماعی")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.شریکدارد)
                    .HasColumnName("شریک دارد")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.شمارهاستعلامدارایی)
                    .HasColumnName("شماره استعلام دارایی")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.شمارهاقامت)
                    .HasColumnName("شماره اقامت")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.شمارهاولینپروانه)
                    .HasColumnName("شماره اولین پروانه")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.شمارهبایگانی)
                    .HasColumnName("شماره بایگانی")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.شمارهتابلو).HasColumnName("شماره تابلو");

                entity.Property(e => e.شمارهتاییداماکن)
                    .HasColumnName("شماره تایید اماکن")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.شمارهتاییدبهداشت)
                    .HasColumnName("شماره تایید بهداشت")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.شمارهتمبر)
                    .HasColumnName("شماره تمبر")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.شمارهثبتشرکت)
                    .HasColumnName("شماره ثبت شرکت")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.شمارهدرخواست)
                    .HasColumnName("شماره درخواست")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.شمارهشناسنامه)
                    .HasColumnName("شماره شناسنامه")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.شمارهشناسنامهقیم)
                    .HasColumnName("شماره شناسنامه قیم")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.شمارهعضویت)
                    .HasColumnName("شماره عضویت")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.شمارهقیمنامه)
                    .HasColumnName("شماره قیم نامه")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.شمارهمجوزدخانی)
                    .HasColumnName("شماره مجوز دخانی")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.شمارهمسلسلمباشر)
                    .HasColumnName("شماره مسلسل مباشر")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.شمارهنامهغیرفعال)
                    .HasColumnName("شماره نامه غیرفعال")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.شمارهپروانهقبلی)
                    .HasColumnName("شماره پروانه قبلی")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.شمارهپروانهکار)
                    .HasColumnName("شماره پروانه کار")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.شمارهپروانهکسب)
                    .HasColumnName("شماره پروانه کسب")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.شمارهکارتبازرگانی)
                    .HasColumnName("شماره کارت بازرگانی")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.شمارهکارتمباشر)
                    .HasColumnName("شماره کارت مباشر")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.شمارهگذرنامه)
                    .HasColumnName("شماره گذرنامه")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.شناسنامهمباشر)
                    .HasColumnName("شناسنامه مباشر")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.شناسهثبتشرکت)
                    .HasColumnName("شناسه ثبت شرکت")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.شناسهشیوا)
                    .HasColumnName("شناسه شیوا")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.شناسهصنفی)
                    .HasColumnName("شناسه صنفی")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.شناسهملی)
                    .HasColumnName("شناسه ملی")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.شهر)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.صادره)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.صندوقمکانیزه)
                    .HasColumnName("صندوق مکانیزه")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.طبقه)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.علتابطالپرونده)
                    .HasColumnName("علت ابطال پرونده")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.علتتعلیق)
                    .HasColumnName("علت تعلیق")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.علترددرخواست)
                    .HasColumnName("علت رد درخواست")
                    .HasMaxLength(10);

                entity.Property(e => e.علتغیرفعالپرونده)
                    .HasColumnName("علت غیرفعال پرونده")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.عمدهکالا)
                    .HasColumnName("عمده کالا")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.عنوانسند)
                    .HasColumnName("عنوان سند")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.عنوانواحدصنفی)
                    .HasColumnName("عنوان واحد صنفی")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.فاصلهصنفی).HasColumnName("فاصله صنفی");

                entity.Property(e => e.فروشفوقالعادهاز)
                    .HasColumnName("فروش فوق العاده از")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.فروشفوقالعادهتا)
                    .HasColumnName("فروش فوق العاده تا")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.فوقاز)
                    .HasColumnName("فوق از")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.فوقتا)
                    .HasColumnName("فوق تا")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.فکسمباشر)
                    .HasColumnName("فکس مباشر")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.فکسمغازه)
                    .HasColumnName("فکس مغازه")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.فکسمنزل)
                    .HasColumnName("فکس منزل")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.قیم)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ماندهازقبل).HasColumnName("مانده از قبل");

                entity.Property(e => e.مباشردارد)
                    .HasColumnName("مباشر دارد")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.مبلغبدهی).HasColumnName("مبلغ بدهی");

                entity.Property(e => e.مبلغتمبر).HasColumnName("مبلغ تمبر");

                entity.Property(e => e.مجوزماهرمضان)
                    .HasColumnName("مجوز ماه رمضان")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.محصولاتصادراتی)
                    .HasColumnName("محصولات صادراتی")
                    .IsUnicode(false);

                entity.Property(e => e.محصولاتمندرجدرپرونده)
                    .HasColumnName("محصولات مندرج در پرونده")
                    .IsUnicode(false);

                entity.Property(e => e.محلاستقرار)
                    .HasColumnName("محل استقرار")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.محلبایگانی)
                    .HasColumnName("محل بایگانی")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.محلتولد)
                    .HasColumnName("محل تولد")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.محلتولدمباشر)
                    .HasColumnName("محل تولد مباشر")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.محلصدورشناسنامه)
                    .HasColumnName("محل صدور شناسنامه")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.محلصدورمباشر)
                    .HasColumnName("محل صدور مباشر")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.محله)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.مذهب)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.مرجعصادرکنندهقیمنامه)
                    .HasColumnName("مرجع صادر کننده قیم نامه")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.مرجعصدور)
                    .HasColumnName("مرجع صدور")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.مرحله)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.مرحلهدرخواست)
                    .HasColumnName("مرحله درخواست")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.مرکزشناسایی)
                    .HasColumnName("مرکز شناسایی")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.مسئولپرونده)
                    .HasColumnName("مسئول پرونده")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.مساحت)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.مساحتانبار)
                    .HasColumnName("مساحت انبار")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.مسلسلجدید)
                    .HasColumnName("مسلسل جدید")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.مسلسلشناسنامه)
                    .HasColumnName("مسلسل شناسنامه")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.مسلسلقدیم)
                    .HasColumnName("مسلسل قدیم")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.مسلسلمباشر)
                    .HasColumnName("مسلسل مباشر")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.مشارکت)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.مفاصاحسابشهرداری)
                    .HasColumnName("مفاصاحساب شهرداری")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ملاحضاتدرخواست)
                    .HasColumnName("ملاحضات درخواست")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.ملاحضاتشناسایی)
                    .HasColumnName("ملاحضات شناسایی")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ملیت)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.منطقه)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.موافقتنامه)
                    .HasColumnName("موافقت نامه")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ناحیهاماکن)
                    .HasColumnName("ناحیه اماکن")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ناحیهشهرداری)
                    .HasColumnName("ناحیه شهرداری")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.نام)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ناماتحادیه)
                    .HasColumnName("نام اتحادیه")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ناماتحادیهقبلی)
                    .HasColumnName("نام اتحادیه قبلی")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ناماستان)
                    .HasColumnName("نام استان")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.نامخانوادگی)
                    .HasColumnName("نام خانوادگی")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.نامخانوادگیمباشر)
                    .HasColumnName("نام خانوادگی مباشر")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.نامشرکت)
                    .HasColumnName("نام شرکت")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.نامشهرستان)
                    .HasColumnName("نام شهرستان")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.نامقیم)
                    .HasColumnName("نام قیم")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.ناممباشر)
                    .HasColumnName("نام مباشر")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ناممستعار)
                    .HasColumnName("نام مستعار")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ناممستعارمباشر)
                    .HasColumnName("نام مستعار مباشر")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.نامپدر)
                    .HasColumnName("نام پدر")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.نامپدرمباشر)
                    .HasColumnName("نام پدر مباشر")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.نشانیکارخانه)
                    .HasColumnName("نشانی کارخانه")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.نظاموظیفه)
                    .HasColumnName("نظام وظیفه")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.نواقصبازرسی)
                    .HasColumnName("نواقص بازرسی")
                    .IsUnicode(false);

                entity.Property(e => e.نوعسند)
                    .HasColumnName("نوع سند")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.نوعشخص)
                    .HasColumnName("نوع شخص")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.نوعشغلقبلی)
                    .HasColumnName("نوع شغل قبلی")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.نوععضویت)
                    .HasColumnName("نوع عضویت")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.نوعفروش)
                    .HasColumnName("نوع فروش")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.نوعفعالیت)
                    .HasColumnName("نوع فعالیت")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.نوعمالکیت)
                    .HasColumnName("نوع مالکیت")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.نوعپروانه)
                    .HasColumnName("نوع پروانه")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.نوعپروانهکسبقبلی)
                    .HasColumnName("نوع پروانه کسب قبلی")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.نوعکاربری)
                    .HasColumnName("نوع کاربری")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.همراهمباشر)
                    .HasColumnName("همراه مباشر")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.هویت)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.واحد)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.واگذاریااجاره).HasColumnName("واگذار یا اجاره");

                entity.Property(e => e.وبسایت)
                    .HasColumnName("وب سایت")
                    .HasMaxLength(10);

                entity.Property(e => e.ورثهمحجور)
                    .HasColumnName("ورثه محجور")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.وضعیتاستقرار)
                    .HasColumnName("وضعیت استقرار")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.وضعیتانتقال)
                    .HasColumnName("وضعیت انتقال")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.وضعیتتملک)
                    .HasColumnName("وضعیت تملک")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.وضعیترسیدگی)
                    .HasColumnName("وضعیت رسیدگی")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.وضعیتسند)
                    .HasColumnName("وضعیت سند")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.وضعیتمالکیت)
                    .HasColumnName("وضعیت مالکیت")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.وضعیتپرونده)
                    .HasColumnName("وضعیت پرونده")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ولیقهری)
                    .HasColumnName("ولی قهری")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.پاسخاماکنمثبت).HasColumnName("پاسخ اماکن مثبت");

                entity.Property(e => e.پاسخبهداشتمثبت).HasColumnName("پاسخ بهداشت مثبت");

                entity.Property(e => e.پلاکآبی)
                    .HasColumnName("پلاک آبی")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.پلاکآبیقدیم)
                    .HasColumnName("پلاک آبی قدیم")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.پلاکثبتی)
                    .HasColumnName("پلاک ثبتی")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.پلاکقدیم)
                    .HasColumnName("پلاک قدیم")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.پلاکپاساژ)
                    .HasColumnName("پلاک پاساژ")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.کداتحادیه)
                    .HasColumnName("کد اتحادیه")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.کداستان).HasColumnName("کد استان");

                entity.Property(e => e.کداقتصادی)
                    .HasColumnName("کد اقتصادی")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.کددفترکل)
                    .HasColumnName("کد دفترکل")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.کدرسته)
                    .HasColumnName("کد رسته")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.کدرهگیری)
                    .HasColumnName("کد رهگیری")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.کدشهرستان).HasColumnName("کد شهرستان");

                entity.Property(e => e.کدمعین)
                    .HasColumnName("کد معین")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.کدملی)
                    .HasColumnName("کد ملی")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.کدملیقیم)
                    .HasColumnName("کد ملی قیم")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.کدملیمباشر)
                    .HasColumnName("کد ملی مباشر")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.کدپستی)
                    .HasColumnName("کد پستی")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.کدپستیمباشر)
                    .HasColumnName("کد پستی مباشر")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.کدپستیمنزل)
                    .HasColumnName("کد پستی منزل")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.کدیکتا).HasColumnName("کد یکتا");

                entity.Property(e => e.کلاسهایآموزشی)
                    .HasColumnName("کلاس های آموزشی")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.کلسهم).HasColumnName("کل سهم");

                entity.Property(e => e.کمیسیونفرعی)
                    .HasColumnName("کمیسیون فرعی")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.گذرنامهانقضاء)
                    .HasColumnName("گذرنامه انقضاء")
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.محلثبتشرکت)
                    .HasColumnName("محل ثبت شرکت")
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.نامتجاری)
                    .HasColumnName("نام تجاری")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });
            modelBuilder.Entity<TblRefrences>(entity =>
            {
                entity.HasKey(e => e.RefrenceId);

                entity.ToTable("Tbl_Refrences");

                entity.Property(e => e.Command).IsUnicode(false);

                entity.Property(e => e.ExpireDate).HasColumnType("datetime");

                entity.Property(e => e.IsEdit).HasColumnName("isEdit");

                entity.Property(e => e.Periority)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReferAbout)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ReferDate)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ReferTime)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.ReplayMessage).IsUnicode(false);

                entity.Property(e => e.VisitDate).HasColumnType("datetime");
            });
            modelBuilder.Entity<TblOfficeMember>(entity =>
            {
                entity.HasKey(e => e.MemberId);

                entity.ToTable("Tbl_OfficeMember");
            });
            modelBuilder.Entity<TblQuestionnaire>(entity =>
            {
                entity.HasKey(e => e.Qid);

                entity.ToTable("Tbl_Questionnaire");
            });
            modelBuilder.Entity<TblOfficeMembers>(entity =>
            {
                entity.HasKey(e => e.BusinessId);

                entity.ToTable("Tbl_FinancialBalance");
            });
            modelBuilder.Query<LoginByUsernamePassword>();
            modelBuilder.Entity<TblPayments>(entity =>
            {
                entity.HasKey(e => e.PaymentId);

                entity.ToTable("Tbl_Payments");

                entity.Property(e => e.CheckBank)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CheckComment)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.CheckDate)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CheckNum)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CheckShobe)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.DateSabt)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FishBank)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FishComment)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.FishDate)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FishNum)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.IsEdit).HasColumnName("isEdit");

                entity.Property(e => e.PaymentAbout)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });
            modelBuilder.Entity<TblLettersGroup>(entity =>
            {
                entity.HasKey(e => e.GroupId);

                entity.ToTable("Tbl_Letters_Group");

                entity.Property(e => e.Address)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.EceAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EditDate).HasColumnType("datetime");

                entity.Property(e => e.EmailAddress).IsUnicode(false);

                entity.Property(e => e.Fax)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.GroupName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.IsEdit).HasColumnName("isEdit");

                entity.Property(e => e.Manager)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.PtoPaddress)
                    .HasColumnName("PToPAddress")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RelatedSubjects).IsUnicode(false);

                entity.Property(e => e.Tels)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });
            modelBuilder.Entity<TblDocuments>(entity =>
            {
                entity.HasKey(e => e.DocumentId);

                entity.ToTable("Tbl_Documents");

                entity.Property(e => e.DocumentName)
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

        }
    }
    
}
