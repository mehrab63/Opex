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

namespace Opex.Pages.Payments
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
        public TblPayments TblPayments { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

           // TblPayments = await _context.TblPayments.FirstOrDefaultAsync(m => m.PaymentId == id);

            if (TblPayments == null)
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

           // TblPayments = await _context.TblPayments.FindAsync(id);

            if (TblPayments != null)
            {
              //  _context.TblPayments.Remove(TblPayments);
               // await _context.SaveChangesAsync();
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
