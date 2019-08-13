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
using Opex.Helpers;
using Opex.Models;

namespace Opex.Pages.Payments
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly Opex.Models.DB_Context _context;

        public IndexModel(Opex.Models.DB_Context context)
        {
            _context = context;
        }

        public IList<TblPayments> TblPayments { get;set; }

        public async Task OnGetAsync()
        {
            TblPayments = await _context.TblPayments.Where(p=>p.SystemCode==Services.UserMemberId).ToListAsync();
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
