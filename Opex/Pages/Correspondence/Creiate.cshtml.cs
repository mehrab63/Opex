using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Opex.Models;

namespace Opex.Pages.Correspondence
{
    public class CreateModel : PageModel
    {
        private readonly Opex.Models.DB_Context _context;

        public CreateModel(Opex.Models.DB_Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TblLetters TblLetters { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TblLetters.Add(TblLetters);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}