using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Opex.Models;

namespace Opex.Pages.Binarys
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly Opex.Models.DB_Context _context;
        [TempData]
        public string Message { get; set; }
        public bool ShowMessage => !string.IsNullOrEmpty(Message);
        [TempData]
        public string TabPage { get; set; }
        public bool ShowTab => !string.IsNullOrEmpty(TabPage);
        public DeleteModel(Opex.Models.DB_Context context)
        {
            _context = context;
        }

        [BindProperty]
        public TblBinarys TblBinarys { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblBinarys = await _context.TblBinarys.FirstOrDefaultAsync(m => m.BinaryId == id);

            if (TblBinarys == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblBinarys = await _context.TblBinarys.FindAsync(id);

            if (TblBinarys != null)
            {
                _context.TblBinarys.Remove(TblBinarys);
                await _context.SaveChangesAsync();
            }
            TabPage = "upload";
            Message = "مدرک  '" + TblBinarys.Subject + "' حذف شد.";
            return RedirectToPage("./Index");
        }
    }
}
