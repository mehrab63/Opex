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
    public class EditModel : PageModel
    {
        private readonly Opex.Models.DB_Context _context;
        [TempData]
        public string Message { get; set; } 
        [TempData]
        public string TabPage { get; set; } 
        public byte[] Binary { get; set; }
        public string Subject { get; set; }
        public EditModel(Opex.Models.DB_Context context)
        {
            _context = context;
        }

        [BindProperty]
        public TblBinarys tblBinarys { get; set; }
        [BindProperty]
        public List<TblDocuments> DocumentsList { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return Redirect("/Binarys/Index");
            }

            tblBinarys = await _context.TblBinarys.FirstOrDefaultAsync(m => m.BinaryId == id);
            DocumentsList= _context.TblDocuments.ToList();
            if (tblBinarys == null)
            {
                return Redirect("/Binarys/Index");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(IFormFile Binary, string Subject)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (Binary != null)
            {
                var res = await Services.Upload(Binary);
                tblBinarys.Binary = res;
                tblBinarys.FileFormat = Path.GetExtension(Binary.FileName).Replace(".", "");
            }
            tblBinarys.Subject = Subject;
            _context.Attach(tblBinarys).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            ViewData["OnTab"] = "upload";
            TabPage = "upload";
            Message = "مدرک '"+tblBinarys.Subject+"' ویرایش شد."; 
            TempData["Message"] = "مدرک '" + tblBinarys.Subject + "' ویرایش شد.";
            try
            {
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblBinarysExists(tblBinarys.BinaryId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            } 
            return RedirectToPage("./Index");
        } 
        private bool TblBinarysExists(long id)
        {
            return _context.TblBinarys.Any(e => e.BinaryId == id);
        }
    }
}
