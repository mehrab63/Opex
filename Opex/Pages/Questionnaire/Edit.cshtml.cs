using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Opex.Helpers;
using Opex.Models;

namespace Opex.Pages.Questionnaire
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly Opex.Models.DB_Context _context;
        public int? Qid { get; set; }
        public EditModel(Opex.Models.DB_Context context)
        {
            _context = context;
        }

        [BindProperty]
        public TblQuestionnaire tblQuestionnaire { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                Qid = id;
                if (id == null)
                {
                    return  Page();

                }
                else
                {
                    tblQuestionnaire = await _context.TblQuestionnaires.FirstOrDefaultAsync(m => m.SystemCode == Services.UserMemberId);

                }


                if (tblQuestionnaire == null)
                {
                    return NotFound();
                }
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? yesno3, int? yesno4)
        {
            
            try
            {
                TblQuestionnaire Questionnaire = new TblQuestionnaire
                {
                    Question1 = tblQuestionnaire.Question1,
                    Question11 = tblQuestionnaire.Question11,
                    Question12 = tblQuestionnaire.Question12,
                    Question13 = tblQuestionnaire.Question13,
                    Question14 = tblQuestionnaire.Question14,
                    Question2 = tblQuestionnaire.Question2,
                    Question3Disp = tblQuestionnaire.Question3Disp,
                    Question4Disp = tblQuestionnaire.Question4Disp,
                    Question5 = tblQuestionnaire.Question5,
                        CreateTime = DateTime.Now
                    };
                    if (yesno3 == 1)
                        Questionnaire.Question3 = "بلی";
                    else
                        Questionnaire.Question3 = "خیر";
                    if (yesno4 == 1)
                        Questionnaire.Question4 = "بلی";
                    else
                        Questionnaire.Question4 = "خیر";
                
                    Questionnaire.SystemCode = Services.UserMemberId;
                    Questionnaire.CodeYekta = Services.CurrentMember.کدیکتا;
                Questionnaire.Qid = tblQuestionnaire.Qid;
                Qid = tblQuestionnaire.Qid;
                if(Qid==null||Qid==0)
                    _context.TblQuestionnaires.Update(Questionnaire);
                else
                _context.Attach(Questionnaire).State = EntityState.Modified;
                
                    await _context.SaveChangesAsync();
                    TempData["TabPage"] = "question";
                    TempData["Message"] = "پرسشنامه ذخیره شد.";
                     return RedirectToPage("/Questionnaire/Index");  
              

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblQuestionnaireExists(tblQuestionnaire.Qid))
                {
                    TempData["TabPage"] = "question";
                    TempData["Error"] = "خطا.";
                    return RedirectToPage("/Questionnaire/Index");
                }
                else
                {
                    throw;
                }
            } 
        }

        private bool TblQuestionnaireExists(int id)
        {
            return _context.TblQuestionnaires.Any(e => e.Qid == id);
        }
    }
}
