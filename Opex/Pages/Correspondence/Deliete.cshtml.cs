using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Opex.Models;

namespace Opex.Pages.Correspondence
{
    public class DeleteModel : PageModel
    {
        private readonly Opex.Models.DB_Context _context;

        public DeleteModel(Opex.Models.DB_Context context)
        {
            _context = context;
        }

        [BindProperty]
        public TblLetters TblLetters { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

           // TblLetters = await _context.TblLetters.FirstOrDefaultAsync(m => m.LetterId == id);

            if (TblLetters == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblLetters = await _context.TblLetters.FindAsync(id);

            if (TblLetters != null)
            {
                _context.TblLetters.Remove(TblLetters);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
