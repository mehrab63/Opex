using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Opex.Helpers;
using Opex.Models;

namespace Opex.Pages
{
    public class loginModel : PageModel
    {
        private readonly DB_Context _context;
        public loginModel(DB_Context context)
        {
            _context = context;
        }
        [TempData]
        public string Error { get; set; }
        public bool ShowMessage => !string.IsNullOrEmpty(Error);
        [TempData]
        public string TabPage { get; set; }
        public bool ShowTab => !string.IsNullOrEmpty(TabPage);
        public bool Registered { get; set; }
        [BindProperty]
        public List<TblMembers> memberlist { get; set; }

        [BindProperty]
        public LoginViewModel LoginModels { get; set; }

        public async Task<IActionResult> OnGet()
        {
            return Page();

        }

        public async Task<IActionResult> OnPostLogIn()
        {
            try
            {
                Response.Cookies.Delete("CodeMelli");
                // Verification.  
                if (ModelState.IsValid)
                {
                    if (LoginModels.Username == null || LoginModels.Password == null)
                    {
                        ViewData["Error"] = "نام کاربري و رمز عبور را وارد کنيد.";
                        ViewData["OnTab"] = "rquest-type";
                        return Page();
                    }
                    // Initialization.  
                    var loginInfo = await this.LoginMethod(this.LoginModels.Username, this.LoginModels.Password);
                    // Verification.  
                    if (loginInfo != null && loginInfo.Count() > 0)
                    {
                        // Initialization.  
                        HttpContext.Session.SetString("CodeMelli", LoginModels.Username);
                        var logindetails = loginInfo.First();
                        Services.UserMemberId = logindetails.MemberId;
                        var id = this.SignInUser(logindetails.کدملی, false);
                        // Login In.  
                        await this.SignInUser(logindetails.نامخانوادگی, false);
                        return RedirectToPage("/Senfi/Index");
                    }
                    else
                    {
                        ViewData["Error"] = "نام کاربري يا کلمه عبور اشتباه است.";
                        ViewData["OnTab"] = "rquest-type";
                        Registered = true;
                        return Page();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;
                // Info  
                return Page();
            }
            // Info.  
            TempData["message"] = "نام کاربري و کلمه عبور را وارد کنيد.";
            ViewData["OnTab"] = "rquest-type";
            return Page();
        }
        #region Sign In method. 
        /// <returns>Returns - await task</returns>
        public async Task<List<TblMembers>> LoginMethod(string usernameVal, string passwordVal)
        {
            try
            {
                await Services.GetMember(_context, usernameVal);
                if (Services.CurrentMember.کدملی == usernameVal && Services.CurrentMember.شمارهشناسنامه == passwordVal)
                    memberlist.Add(Services.CurrentMember);
                Services.RunInBackground(_context);
                //binaryIds = Services.GetBinaryIds(Services.CurrentMember.BinaryIds);
            }
            catch (Exception ex)
            {
                ViewData["Error1"] = ex.Message.ToString();
                return null;
            }
            return memberlist;
        }
        private async Task SignInUser(string username, bool isPersistent)
        {
            // Initialization.  
            var claims = new List<Claim>();
            try
            {
                // Setting  
                claims.Add(new Claim(ClaimTypes.Name, username));
                claims.Add(new Claim(ClaimTypes.UserData, username));
                var claimIdenties = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimPrincipal = new ClaimsPrincipal(claimIdenties);
                var authenticationManager = Request.HttpContext;

                // Sign In.  
                await authenticationManager.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrincipal, new AuthenticationProperties() { IsPersistent = isPersistent });
            }
            catch (Exception ex)
            {
                // Info  
                throw ex;
            }
        }
        #endregion
    }
}