using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Opex.Models;

namespace Opex.Pages.OfficeMember
{
    [Authorize]
    public class DeleteModel : PageModel
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
        public DeleteModel(Opex.Models.DB_Context context)
        {
            _context = context;
        }

        [BindProperty]
        public TblOfficeMember TblOfficeMember { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblOfficeMember = await _context.TblOfficeMembers.FirstOrDefaultAsync(m => m.MemberId == id);

            if (TblOfficeMember == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblOfficeMember = await _context.TblOfficeMembers.FindAsync(id);

            if (TblOfficeMember != null)
            {
                _context.TblOfficeMembers.Remove(TblOfficeMember);
                await _context.SaveChangesAsync();
            }
            Error = "اطلاعات عضو حذف شد.";
            TabPage = "payment";
            return RedirectToPage("../FinancialBalance/Index");
             
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
