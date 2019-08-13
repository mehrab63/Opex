using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Opex.Models;

namespace Opex.Pages.Questionnaire
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly Opex.Models.DB_Context _context;

        public DetailsModel(Opex.Models.DB_Context context)
        {
            _context = context;
        }

        public TblQuestionnaire TblQuestionnaire { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblQuestionnaire = await _context.TblQuestionnaires.FirstOrDefaultAsync(m => m.Qid == id);

            if (TblQuestionnaire == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
