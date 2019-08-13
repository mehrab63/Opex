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
    public class DetailsModel : PageModel
    {
        private readonly Opex.Models.DB_Context _context;

        public DetailsModel(Opex.Models.DB_Context context)
        {
            _context = context;
        }

        public TblLetters TblLetters { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblLetters = await _context.TblLetters.FirstOrDefaultAsync(m => m.LetterId == id);

            if (TblLetters == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
