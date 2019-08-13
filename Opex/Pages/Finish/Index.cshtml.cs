using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Opex.Helpers;
using Opex.Models;

namespace Opex.Pages.Finish
{
    [Authorize]

    public class IndexModel : PageModel
    {
        public string Parvande { get; set; }
        public List<TblMembers> Member { get; set; }
        [BindProperty]
        public  TblMembers Members { get; set; }
        public void OnGet()
        {
            Parvande = Services.CurrentMember.وضعیتپرونده;
            Members=Services.CurrentMember;
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