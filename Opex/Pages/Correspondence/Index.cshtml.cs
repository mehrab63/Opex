using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Opex.Helpers;
using Opex.Models;

namespace Opex.Pages.Correspondence
{

    public class IndexModel : PageModel
    {
        private readonly DB_Context _context;
        public IndexModel(DB_Context context)
        {
            _context = context;
        }
        [TempData]
        public string Message { get; set; }
        public bool ShowMessage => !string.IsNullOrEmpty(Message);
        [TempData]
        public string TabPage { get; set; }
        public bool ShowTab => !string.IsNullOrEmpty(TabPage);

        [Required(ErrorMessage = "شماره تلفن همراه را وارد کنید")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(13, ErrorMessage = "شماره همراه صحیح نیست", MinimumLength = 11)]
        [RegularExpression(@"^\(?([0-9]{11})$", ErrorMessage = "شماره تلفن صحیح نیست")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "کد رهگیری را وارد کنید")]
        [StringLength(10, ErrorMessage = "کد رهگیری صحیح نیست", MinimumLength = 8)]
        [RegularExpression(@"^\(?([0-9]{11})$", ErrorMessage = "کد رهگیری صحیح نیست")]
        public string LetterNum { get; set; }
        public string LetterSubject { get; set; }
        public string LetterDisp { get; set; }
        public string FullName { get; set; }
        public string CompanyName { get; set; }
        public bool Registered { get; set; }
        public bool Find { get; set; }
        public byte[] Binary { get; set; }
        public List<long> BinaryIds { get; set; }
        [BindProperty]
        public TblLetters Letter { get; set; }
        [BindProperty]
        public TblLetters sendedLetter { get; set; }

        public async Task OnGetAsync()
        {

        }
        public async Task<ActionResult> OnPostSendRequestAsync(IFormFile Binary, [StringLength(13, ErrorMessage = "تعداد ارقام صحیح نیست", MinimumLength = 11)] [RegularExpression(@"^(\+98|0)?9\d{9}$", ErrorMessage = "تلفن همراه نامعتبر است")]string PhoneNumber,
            string FullName, string LetterSubject, string LetterDisp, string CompanyName)
        {
            try
            {
                if (Binary == null)
                {
                    TempData["nofile"] = "فایل انتخاب نشده است";
                    return Page();
                } 
                if (!ModelState.IsValid)
                {
                    ViewData["OnTab"] = "rquest-type";
                    return Page();
                }
                if (PhoneNumber == null)
                {
                    TempData["noPhone"] = "تلفن همراه را وارد کنید ";
                    return Page();
                }

                TblBinarys tblBinarys = new TblBinarys();
                var res = await Services.Upload(Binary);
                if (res != null)
                {
                    tblBinarys.Binary = res;
                    tblBinarys.Subject = LetterSubject;
                    tblBinarys.Description = "ثبت از سایت";
                    tblBinarys.FileFormat = Path.GetExtension(Binary.FileName).Replace(".", "");
                    _context.TblBinarys.Add(tblBinarys);
                    _context.SaveChanges();
                }
                TblLetters NewLetter = new TblLetters
                {
                    BinaryIds = tblBinarys.BinaryId.ToString(),
                    CreateDate = DateTime.Now,
                    SignDateTime = DateTime.Now,
                    Comment = FullName + " " + PhoneNumber + " " + CompanyName + " " + LetterDisp,
                    LetterDate = Services.ToShamsi(DateTime.Now.Date),
                    Sender = 7820,
                    SenderName = "سيستم مکاتبات اعضاء",
                    Reciver = 6519,
                    ReciverName = "عباسعلی اسلامی -  رييس اتحاديه اتحاديه صادرکنندگان فراورده های نفت، گاز و پتروشيمی ايران",
                    SubjectId = 829,
                    SubjectName = "سيستم مکاتبات سايت",
                    Subjects = LetterSubject,
                    Peyvast = "دارد 1 برگ",
                    LetterNum = "",
                    DocumentType = "نامه",
                    Arjaiat = "عادی",
                    SendType = "اپلیکشن", 
                    LetterType = 0,
                    RelateLetterId = 0,
                    RelateLetterType = "وارده"
                };
                _context.Add(NewLetter);
                _context.SaveChanges();
                var id = NewLetter.LetterId;
                TblRefrences refrence = new TblRefrences
                {
                    LetterId = id,
                    ToUser = 57,
                    Status = 0,
                    FromUser = Services.UserMemberId,
                    ReferAbout = "نامه ثبتی از سایت",
                    Periority = "عادی"
                };
                Services.InsertReference(_context, refrence);
                ViewData["OnTab"] = "rquest-type";
                Registered = true;
                TempData["Success"] = Services.EncryptString(NewLetter.LetterId.ToString());
                TempData["Date"] = NewLetter.LetterDate.ToString();
                return Page();
            }
            catch (Exception ex)
            {
                TempData["nofile"] = ex.Message;
                return Page();
            }
        }
        public async Task<ActionResult> OnPostSearchAsync(string LetterNum)
        {
            if (LetterNum == null)
            {
                TempData["Error"] = "* کد رهگیری وارد شده صحیح نیست. ";
                ViewData["OnTab"] = "Search";
                Find = false;
                return Page();
            }
            if (LetterNum.Length <= 3)
            {
                TempData["Error"] = "* کد رهگیری وارد شده صحیح نیست. ";
                ViewData["OnTab"] = "Search";
                Find = false;
                return Page();
            }
             LetterNum = Services.DecryptString(LetterNum);
            var nn = Convert.ToInt32(LetterNum);
            try
            {
                sendedLetter = await _context.TblLetters.Where(l => l.LetterId == Convert.ToInt32(LetterNum)).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                TempData["Error"] = "خطا: کد رهگیری وارد شده صحیح نیست. ";
                ViewData["OnTab"] = "Search";
                Find = false;
                return Page();
                throw;
            }
            if(sendedLetter==null)
            {
                TempData["Error"] = "* کد رهگیری وارد شده صحیح نیست. ";
                ViewData["OnTab"] = "Search";
                Find = false;
                return Page();
            }
            Letter = await _context.TblLetters.Where(l => l.RelateLetterId == sendedLetter.LetterId).FirstOrDefaultAsync();
            
            if (Letter != null)
            {
                Find = true;
                BinaryIds = Services.GetBinaryIds(Letter.BinaryIds);
            }
            else
            {
                TempData["Error"] = "* هنوز پاسخی برای این نامه ثبت نشده است. ";
                ViewData["OnTab"] = "Search";
                Find = false; 
            }
            ViewData["OnTab"] = "Search";
            return Page();
        }
    }
}
