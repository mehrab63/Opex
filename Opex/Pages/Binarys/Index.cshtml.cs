using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Opex.Helpers;
using Opex.Models;

namespace Opex.Pages.Binarys
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
        public string Subject { get; set; }
        public string Description { get; set; }
        public byte[] Binary { get; set; }
        public IndexModel(Opex.Models.DB_Context context)
        {
            _context = context;
        }

        [BindProperty]
        public TblBinarys tblBinarys { get; set; }
        [BindProperty]
        public List<TblBinarys> Binaryslist { get;set; }
        public List<long> BinaryIds { get; set; }
        public async Task OnGetAsync()
        {
            if(Services.CurrentMember.BinaryIds!=null)
            BinaryIds= Services.GetBinaryIds(Services.CurrentMember.BinaryIds);
            Binaryslist = await _context.TblBinarys.Where(b => BinaryIds.Contains(b.BinaryId)).ToListAsync();
           
        }
        public async Task<ActionResult> readBinary()
        {
            var read =  System.IO.File.ReadAllBytes(tblBinarys.Binary.ToString());
            return File(read, "");
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
