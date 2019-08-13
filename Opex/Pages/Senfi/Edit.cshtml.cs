using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Opex.Helpers;
using Opex.Models;

namespace Opex.Pages.Senfi
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly DB_Context _context;
        [TempData]
        public string Message { get; set; }
        public bool ShowMessage => !string.IsNullOrEmpty(Message);
        [TempData]
        public string Error { get; set; }
        public bool ShowError => !string.IsNullOrEmpty(Error);
        [TempData]
        public string TabPage { get; set; } 
        public EditModel(DB_Context context)
        {
            _context = context;
        }

        [BindProperty]
        public TblMembers tblMembers { get; set; }  
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (id == null)
                {
                    return NotFound();
                }
                if (Services.CurrentMember != null) 
                    tblMembers = Services.CurrentMember; 
                else
                {

                    tblMembers = await _context.TblMembers.FirstOrDefaultAsync(m => m.MemberId == id);
                  
                }
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (!ModelState.IsValid)
                {
                    Error = "اطلاعات شما ذخیره نشد.";
                    return RedirectToPage("/Senfi/Index");
                } 
                try
                {
                    var newMem = Services.CurrentMember;
                    if (tblMembers.نوعشخص == "حقیقی")
                    {
                        newMem.نوعشخص = "حقیقی";
                        newMem.نام = tblMembers.نام;
                        newMem.نامخانوادگی = tblMembers.نامخانوادگی;
                        newMem.نامپدر = tblMembers.نامپدر;
                        newMem.تلفنهمراه = tblMembers.تلفنهمراه;
                        newMem.آدرس = tblMembers.آدرس;
                        newMem.ایمیل = tblMembers.ایمیل;
                        newMem.وبسایت = tblMembers.وبسایت;
                        newMem.نوعمالکیت = tblMembers.نوعمالکیت;
                        newMem.نوعفعالیت = tblMembers.نوعفعالیت;
                        _context.TblMembers.Update(newMem);
                        _context.SaveChanges(); 
                        TabPage= "type";
                        Message = "اطلاعات شما ذخیره شد.";
                        return RedirectToPage("/Senfi/Index"); 
                    }
                    else
                    {
                        newMem.نوعشخص = "حقوقی";
                        newMem.نام = tblMembers.نام;
                        newMem.نامخانوادگی = tblMembers.نامخانوادگی;
                        newMem.نامپدر = tblMembers.نامپدر;
                        newMem.تلفنهمراه = tblMembers.تلفنهمراه;
                        newMem.آدرس = tblMembers.آدرس;
                        newMem.ایمیل = tblMembers.ایمیل;
                        newMem.وبسایت = tblMembers.وبسایت;
                        newMem.نوعمالکیت = tblMembers.نوعمالکیت;
                        newMem.نوعفعالیت = tblMembers.نوعفعالیت;
                        newMem.نامشرکت = tblMembers.نامشرکت;
                        newMem.تلفنرابط = tblMembers.تلفنرابط;
                        newMem.شناسهملی = tblMembers.شناسهملی;
                        newMem.شمارهکارتبازرگانی = tblMembers.شمارهکارتبازرگانی;
                        newMem.سالتاسیس = tblMembers.سالتاسیس;
                        newMem.شمارهثبتشرکت = tblMembers.شمارهثبتشرکت;
                        newMem.نامتجاری = tblMembers.نامتجاری;
                        newMem.محلثبتشرکت = tblMembers.محلثبتشرکت;
                         _context.TblMembers.Update(newMem);
                         _context.SaveChanges();
                        TempData["TabPage"] = "type";
                        Message = "اطلاعات شما ذخیره شد.";
                        TempData["Message"] = "اطلاعات شما ذخیره شد.";

                        return RedirectToPage("/Senfi/Index");
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblMembersExists(tblMembers.MemberId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            } 
            TempData["Message"] = "دوباره وارد شوید";
            return RedirectToPage("/Index");
        }

        private bool TblMembersExists(int id)
        {
            return _context.TblMembers.Any(e => e.MemberId == id);
        }
        public async Task<IActionResult> OnPostLogOff()
        {
            try
            {
                var authenticationManager = Request.HttpContext;
                await authenticationManager.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Redirect("Index");
        }
    }
}
