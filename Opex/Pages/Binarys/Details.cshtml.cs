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
    public class DetailsModel : PageModel
    {
        private readonly Opex.Models.DB_Context _context;

        public DetailsModel(Opex.Models.DB_Context context)
        {
            _context = context;
        }

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
    }
}
