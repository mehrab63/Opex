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
using Opex.Helpers;
using Opex.Models;

namespace Opex.Pages.FinancialBalance
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly Opex.Models.DB_Context _context;
        [TempData]
        public string Message { get; set; } 
        [TempData]
        public string Error { get; set; } 
        [TempData]
        public string TabPage { get; set; }
        public CreateModel(Opex.Models.DB_Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TblOfficeMembers TblFinancialBalance { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            TblFinancialBalance.SystemCode = Services.UserMemberId;
            TblFinancialBalance.CodeYekta = Services.CurrentMember.کدیکتا;
            TblFinancialBalance.CreateTime = DateTime.Now;
            _context.TblFinancialBalances.Add(TblFinancialBalance);
            await _context.SaveChangesAsync();
            Message = "اطلاعات مالی با موفقیت ثبت شد.";
            TabPage = "payment";
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