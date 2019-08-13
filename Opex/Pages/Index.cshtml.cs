using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Opex.Helpers;
using Opex.Models;

namespace Opex.Pages 
{
    public class IndexModel : PageModel
    {
        #region Private Properties. 
        [Required(ErrorMessage = "شماره تلفن همراه را وارد کنید")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(13,ErrorMessage = "شماره همراه صحیح نیست", MinimumLength =11)]
        [RegularExpression(@"^\(?([0-9]{11})$", ErrorMessage = "شماره تلفن صحیح نیست")]
        public string PhoneNumber { get; set; }
        [TempData]
        public string Message { get; set; }
        public bool ShowMessage => !string.IsNullOrEmpty(Message);
        public IFormFile FormFile { get; set; }
        private readonly DB_Context dB_Context;
        #endregion
        public IndexModel(DB_Context databaseManagerContext)
        {
            try
            {
                this.dB_Context = databaseManagerContext;
            }
            catch (Exception ex)
            {
                // Info  
                Console.Write(ex);
            }
        }
        public IActionResult OnGet()
        {
            //var letternum = Services.NewLetterNum(dB_Context);
            HttpContext.Session.Clear();
            Response.Cookies.Delete("CodeMelli");
            if (User.Identity.IsAuthenticated)
                return RedirectToPage("/Senfi/Index");

            return Page();
        }
        #region Public Properties  
        /// Gets or sets login model property.  
        public Services service { get; set; }
        [BindProperty]
        public LoginViewModel LoginModel { get; set; }
        [BindProperty]
        public TblLetters tblLetter { get; set; }
        [BindProperty]
        public TblQuestionnaire Questionnaire { get; set; }
        [BindProperty]
        public TblRefrences TblRefrence { get; set; }
        [BindProperty]
        public TblBinarys tblbinary { get; set; }
        [BindProperty]
        public List<string> binaryIds { get; set; } 
        [BindProperty]
        public List<TblMembers> memberlist { get; set; }
        [BindProperty]
        public List<TblBinarys> BinaryList { get; set; }
        public byte[] Binary { get; set; }
        public bool Registered { get; set; }
        #endregion

        #region On Post Login method. 
        [HttpPost]
        public async Task<IActionResult> OnPostLogIn()
        {
            try
            {
                Response.Cookies.Delete("CodeMelli");
                // Verification.  
                if (ModelState.IsValid)
                {
                    if (LoginModel.Username == null || LoginModel.Password == null)
                    {
                        ViewData["Error"] = "نام کاربری و رمز عبور را وارد کنید.";
                        ViewData["OnTab"] = "rquest-type";
                        return Page();
                    }
                    // Initialization.  
                    var loginInfo = await this.LoginMethod(this.LoginModel.Username, this.LoginModel.Password);
                    // Verification.  
                    if (loginInfo != null && loginInfo.Count() > 0)
                    {
                        // Initialization.  
                        HttpContext.Session.SetString("CodeMelli", LoginModel.Username);
                        var logindetails = loginInfo.First();
                        Services.UserMemberId = logindetails.MemberId;
                        var id = this.SignInUser(logindetails.کدملی, false);
                        // Login In.  
                        await this.SignInUser(logindetails.نامخانوادگی, false); 
                        return RedirectToPage("/Senfi/Index");
                    }
                    else
                    {
                        ViewData["Error"] = "نام کاربری یا کلمه عبور اشتباه است.";
                        ViewData["OnTab"] = "rquest-type";
                        Registered = true;
                        return Page();
                    } 
                }
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;
                // Info  
                return Page();
            }
            // Info.  
            TempData["message"] = "نام کاربری و کلمه عبور را وارد کنید.";
            ViewData["OnTab"] = "rquest-type";
            return Page();
        }
        #endregion
        #region Sign In method. 
        /// <returns>Returns - await task</returns>
        public async Task<List<TblMembers>> LoginMethod(string usernameVal, string passwordVal)
        {
            try
            {
                await Services.GetMember(dB_Context, usernameVal);
                if (Services.CurrentMember.کدملی == usernameVal && Services.CurrentMember.شمارهشناسنامه == passwordVal)
                    memberlist.Add(Services.CurrentMember);
                Services.RunInBackground(dB_Context);
                //binaryIds = Services.GetBinaryIds(Services.CurrentMember.BinaryIds);
            }
            catch (Exception ex)
            {
                ViewData["Error1"] = ex.Message.ToString(); 
                return null;
            }
            return memberlist;
        }
        private async Task SignInUser(string username, bool isPersistent)
        {
            // Initialization.  
            var claims = new List<Claim>();
            try
            {
                // Setting  
                claims.Add(new Claim(ClaimTypes.Name, username));
                claims.Add(new Claim(ClaimTypes.UserData, username));
                var claimIdenties = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimPrincipal = new ClaimsPrincipal(claimIdenties);
                var authenticationManager = Request.HttpContext;

                // Sign In.  
                await authenticationManager.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrincipal, new AuthenticationProperties() { IsPersistent = isPersistent });
            }
            catch (Exception ex)
            {
                // Info  
                throw ex;
            }
        }
        #endregion
        #region Rquest method.  
        public async Task<ActionResult> OnPostSendRequestAsync(IFormFile Binary , [StringLength(13, ErrorMessage = "تعداد ارقام صحیح نیست", MinimumLength = 11)] [RegularExpression(@"^(\+98|0)?9\d{9}$", ErrorMessage = "تلفن همراه نامعتبر است")]string PhoneNumber)
        {
            try
            { 
                if (Binary == null)
                {
                    TempData["nofile"] = "فایل انتخاب نشده است";
                    ViewData["OnTab"] = "rquest-type";
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
                    ViewData["OnTab"] = "rquest-type";
                    return Page();
                } 
                if(!await Services.RequestCheck(dB_Context,PhoneNumber))
                { 
                    TblBinarys tblBinarys = new TblBinarys();
                    var res = await Services.Upload(Binary);
                    if (res != null)
                    {
                        tblBinarys.Binary = res;
                        tblBinarys.Subject = "درخواست از سایت";
                        tblBinarys.Description = "ثبت از سایت";
                        tblBinarys.FileFormat = Path.GetExtension(Binary.FileName).Replace(".", "");
                        dB_Context.TblBinarys.Add(tblBinarys);
                        dB_Context.SaveChanges();
                    }
                    TblLetters NewLetter = new TblLetters
                    {
                        BinaryIds = tblBinarys.BinaryId.ToString(),
                        CreateDate = DateTime.Now,
                        SignDateTime = DateTime.Now,
                        Comment =  PhoneNumber,
                        LetterDate=Services.ToShamsi(DateTime.Now.Date),
                        Sender=15377,
                        Reciver=6519,
                        SubjectId=828,
                        Subjects= "درخواست عضويت در اتحاديه (سايت)",
                        Peyvast="دارد 1 برگ",
                        LetterNum ="",
                        DocumentType = "نامه",
                        Arjaiat = "عادی",
                        SendType = "اپلیکشن",
                        SubjectName = "",
                        SenderName = "متقاضي عضويت در اتحاديه",
                        ReciverName = "عباسعلي اسلامي -  رييس اتحاديه اتحاديه صادرکنندگان فراورده هاي نفت، گاز و پتروشيمي ايران",
                        LetterType = 0,
                        RelateLetterId = 0,
                        RelateLetterType = "وارده"
                    };
                     dB_Context.Add(NewLetter);
                     dB_Context.SaveChanges();
                    var id = NewLetter.LetterId;
                    TblRefrences refrence = new TblRefrences
                    {
                        LetterId = id,
                        ToUser = 57,
                        Status = 0,
                        FromUser = Services.UserMemberId,
                        ReferAbout = "درخواست از سایت",
                        Periority = "عادی"
                    };
                    Services.InsertReference(dB_Context, refrence);
                    ViewData["OnTab"] = "rquest-type";
                    ViewData["Success"] = "درخواست شما ثبت گردید| شماره درخواست الکترونیکی شما:" + NewLetter.LetterId.ToString() + "";
                    Registered = true;
                    return Page();
                }
                else
                {
                    ViewData["OnTab"] = "rquest-type";
                    ViewData["Error"] = "شما درخواست عضویت را قبلا ثبت کردید. اگر نام کاربری و کلمه عبور دریافت نکردید لطفا به اتحادیه مراجعه فرمایید.";
                    Registered = true;
                    return Page();
                }
            }
            catch (Exception ex)
            {
                TempData["nofile"] = ex;
                ViewData["OnTab"] = "rquest-type";
                return Page();
            }
        }
        #endregion
        #region Log Out method.  
        /// <returns>Return log off action</returns>  
        public async Task<IActionResult> OnPostLogOff()
        {
            try
            {
                // Setting.  
                var authenticationManager = Request.HttpContext;

                // Sign Out.  
                await authenticationManager.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
            catch (Exception ex)
            {
                // Info  
                throw ex;
            }

            // Info.  
            return Redirect("Index");
        }
        #endregion

    }
}
