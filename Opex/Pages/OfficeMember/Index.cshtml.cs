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
    public class IndexModel : PageModel
    {
        private readonly Opex.Models.DB_Context _context;

        public IndexModel(Opex.Models.DB_Context context)
        {
            _context = context;
        }

        public IList<TblOfficeMember> TblOfficeMember { get;set; }

        public async Task OnGetAsync()
        {
            TblOfficeMember = await _context.TblOfficeMembers.ToListAsync();
        }
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
