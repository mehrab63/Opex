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

namespace Opex.Pages.OfficeMember
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly Opex.Models.DB_Context _context;
        [TempData]
        public string Message { get; set; }
        public bool ShowMessage => !string.IsNullOrEmpty(Message);
        [TempData]
        public string Error { get; set; }
        public bool ShowError => !string.IsNullOrEmpty(Error);
        [TempData]
        public string TabPage { get; set; }
        public bool ShowTab => !string.IsNullOrEmpty(TabPage);
        public CreateModel(Opex.Models.DB_Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TblOfficeMember tblOfficeMember { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (User.Identity.IsAuthenticated) { 
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if(await Services.CheckDuplicate(_context, tblOfficeMember.ShMelli))
            {
                Error = "این عضو قبلا اضافه شده است.";
                TabPage = "payment";
                return RedirectToPage("../FinancialBalance/Index");
            }
                tblOfficeMember.SystemCode = Services.UserMemberId;
            _context.TblOfficeMembers.Add(tblOfficeMember);
            await _context.SaveChangesAsync();
            Message = "عضو جدید اضافه شد";
            TabPage = "payment";
            return RedirectToPage("../FinancialBalance/Index");
            }
            return RedirectToPage("/Index");
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