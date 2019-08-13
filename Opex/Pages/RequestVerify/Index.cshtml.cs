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

namespace Opex.Pages.RequestVerify
{
    [Authorize]
    public class RequestVerifyModel : PageModel
    {
        private readonly Opex.Models.DB_Context _context;
        public string SystemCode { get; set; }
        public string FullName { get; set; }
        public string CreateDate { get; set; }
        public RequestVerifyModel( DB_Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            CreateDate = Services.CurrentMember.تاریخشناسایی;
            SystemCode = Services.UserMemberId.ToString();
            FullName = Services.CurrentMember.نام + " " + Services.CurrentMember.نامخانوادگی;
            
            return Page();
        }

        [BindProperty]
        public TblLetters TblLetters { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {  
            return RedirectToPage("./Index");
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