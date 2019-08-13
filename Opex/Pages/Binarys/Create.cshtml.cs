using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Opex.Helpers;
using Opex.Models;

namespace Opex.Pages.Binarys
{
    [Authorize]
    public class CreateModel : PageModel
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
        public CreateModel(Opex.Models.DB_Context context)
        {
            _context = context;
        }
        [BindProperty]
        public TblBinarys TblBinarys { get; set; }
        [BindProperty]
        public List<TblDocuments> DocumentsList { get; set; }

        public IActionResult OnGet()
        {
            DocumentsList = _context.TblDocuments.ToList();
            
            return Page();

        }
        public async Task<IActionResult> OnPostAsync(IFormFile Binary, string Subject, string Description)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                var res = await Services.Upload(Binary);
                TblBinarys binarys = new TblBinarys
                { 
                    Subject = Subject,
                    Ddate = Services.ToShamsi(DateTime.Now.Date),
                    Description = Description,
                    FileFormat =Path.GetExtension(Binary.FileName).Replace(".", ""),
                    Binary = res
                };
                _context.TblBinarys.Add(binarys);
                await _context.SaveChangesAsync();
                var member = _context.TblMembers.SingleOrDefault(m => m.MemberId == Services.UserMemberId);
                member.BinaryIds += binarys.BinaryId + ",";
                Services.CurrentMember = member;
                _context.TblMembers.Update(member);
                await _context.SaveChangesAsync();
                ViewData["OnTab"] = "upload";
                Message = "مدرک '" + Subject + "' ثبت شد.";
                return Redirect("./Index");
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return Redirect("./Index");
            }
            
        }
    }
}