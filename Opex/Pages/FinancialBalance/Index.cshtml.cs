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

namespace Opex.Pages.FinancialBalance
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly Opex.Models.DB_Context _context;
        [TempData]
        public string Message { get; set; }
        public bool ShowMessage => !string.IsNullOrEmpty(Message);
        [TempData]
        public string TabPage { get; set; }
        public bool ShowTab => !string.IsNullOrEmpty(TabPage);
        public IndexModel(Opex.Models.DB_Context context)
        {
            _context = context;
        }
        [BindProperty]
        public List<TblOfficeMember> officeMembers { get; set; }
        [BindProperty]
        public TblOfficeMember tblOfficeMember { get; set; }
        [BindProperty]
        public TblOfficeMembers tblFinancialBalance { get;set; }

        public async Task OnGetAsync()
        {
            if (User.Identity.IsAuthenticated)
            {
                officeMembers = _context.TblOfficeMembers.Where(m => m.SystemCode == Services.UserMemberId).ToList();
                tblFinancialBalance = await _context.TblFinancialBalances.Where(m => m.SystemCode == Services.UserMemberId).SingleOrDefaultAsync();
            }
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
