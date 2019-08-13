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

namespace Opex.Pages.SenfiDetails
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly Opex.Models.DB_Context _context;
        [TempData]
        public string Message { get; set; }
        public EditModel(Opex.Models.DB_Context context)
        {
            _context = context;
        }

        [BindProperty]
        public TblMembers tblMembers { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                tblMembers = Services.CurrentMember;
                if (id == null || tblMembers == null)
                {
                    return RedirectToPage("/Error");
                }
                if (Services.CurrentMember == null)
                {
                    tblMembers = await _context.TblMembers.FirstOrDefaultAsync(m => m.MemberId == id);
                }
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, string کمیسیونفرعی2, string کمیسیونفرعی1,int? city,int? province)
        {
            if (!ModelState.IsValid)
            { 
                var errorList=ModelState.Values.SelectMany(v => v.Errors).ToList();
                foreach(var e in errorList)
                {
                    TempData["message"] = e.ErrorMessage;
                }
                return Page();
            }
            if (id == null || tblMembers == null)
            {
                return NotFound();
            }

            try
            {
                var member = Services.CurrentMember;
                member.آدرس = tblMembers.آدرس;
                member.کداستان = province;
                member.کدشهرستان = city;
                member.شهر = tblMembers.شهر;
                member.کدپستی = tblMembers.کدپستی;
                member.تلفنمغازه = tblMembers.تلفنمغازه;
                member.فکسمغازه = tblMembers.فکسمغازه;
                member.وبسایت = tblMembers.وبسایت;
                member.تعدادکارکنان = tblMembers.تعدادکارکنان;
                member.رسته = tblMembers.رسته;
                if (کمیسیونفرعی1 != null || کمیسیونفرعی2 != null)
                    member.کمیسیونفرعی = "";
                if (member.کمیسیونفرعی != null)
                {
                    if (member.کمیسیونفرعی.TrimEnd() != ",")
                    {
                        member.کمیسیونفرعی += "," + کمیسیونفرعی1;
                    }
                }
                else
                {
                    member.کمیسیونفرعی = کمیسیونفرعی1;
                }
                if (member.کمیسیونفرعی.TrimEnd() != ",")
                {
                    member.کمیسیونفرعی += "," + کمیسیونفرعی2;
                }
                else
                {
                    member.کمیسیونفرعی += کمیسیونفرعی2;
                }
                _context.TblMembers.Update(member);
                await _context.SaveChangesAsync();
                Services.CurrentMember = tblMembers;
                TempData["message"] = "اطلاعات صنفی شما ثبت گردید"; 
                ViewData["OnTab"] = "facilities";
                return RedirectToPage("/SenfiDetails/Index");
            }
            catch (Exception ex)
            {
                TempData["Erorr"] = ex.Message.ToString();
                ViewData["OnTab"] = "facilities";
                return RedirectToPage("/SenfiDetails/Index");
            }
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
