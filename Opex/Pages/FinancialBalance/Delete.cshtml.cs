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

namespace Opex.Pages.FinancialBalance
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly Opex.Models.DB_Context _context;

        public DeleteModel(Opex.Models.DB_Context context)
        {
            _context = context;
        }

        [BindProperty]
        public TblOfficeMembers TblFinancialBalance { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblFinancialBalance = await _context.TblFinancialBalances.FirstOrDefaultAsync(m => m.BusinessId == id);

            if (TblFinancialBalance == null)
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

            TblFinancialBalance = await _context.TblFinancialBalances.FindAsync(id);

            if (TblFinancialBalance != null)
            {
                _context.TblFinancialBalances.Remove(TblFinancialBalance);
                await _context.SaveChangesAsync();
            }

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
