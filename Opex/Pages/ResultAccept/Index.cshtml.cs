using System;
using System.Collections.Generic; 
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Opex.Helpers;

namespace Opex.Pages.ResultAccept
{
    [Authorize]
    public class AcceptModel : PageModel
    {
        public string ParvandeState { get; set; }
        public string Step { get; set; }//مرحله
        public string cassationState { get; set; }//وضعیت رسیدگی
        public string Description { get; set; }
        public void OnGet()
        {
            if (Services.CurrentMember.وضعیتپرونده == "پرونده تائيد شده ي ثبت نام آنلاين" || Services.CurrentMember.وضعیتپرونده == "فعال(صادره)")
            {
                ParvandeState = Services.CurrentMember.وضعیتپرونده;
                Step = Services.CurrentMember.مرحله;
                cassationState = Services.CurrentMember.وضعیترسیدگی;
                var comments = Services.CurrentMember.توضیحات.Split('\n');
                string finalComment = "";
                foreach(string comment in comments)
                {
                    finalComment += comment.Split(':')[2] + "<br />";
                }
                Description = finalComment;
            }
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