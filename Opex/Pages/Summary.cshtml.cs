using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Opex.Helpers;
using Opex.Models;

namespace Opex.Pages
{
    public class SummaryModel : PageModel
    {
        private readonly Opex.Models.DB_Context _context;
        public SummaryModel(DB_Context context)
        {
            _context = context;
        }
        [BindProperty]
        public TblMembers Members { get; set; }
        [BindProperty]
        public List<TblOfficeMember> OfficeMembers { get; set; }
        [BindProperty]
        public TblOfficeMembers FinancialBalance { get; set; }
        [BindProperty]
        public TblQuestionnaire Questionnaire { get; set; }
        [BindProperty]
        public List<TblBinarys> Binarys { get; set; }
        public bool MemberIsValid = true;
        public bool FinancialBalanceIsValid =true;
        public bool QuestionnaireIsValid = true;
        public bool OfficeMembersIsValid = true;
        public bool BinaryIsValid = true;
        public async Task<IActionResult> OnGet(int? id)

        {
            try
            {
                if (id == null)
                {
                    ViewData["message"] = "اطلاعات یافت نشد.";
                    MemberIsValid = false;
                    FinancialBalanceIsValid = false;
                    QuestionnaireIsValid = false;
                    OfficeMembersIsValid = false;
                    BinaryIsValid = false;
                    return Page();
                }
                Members = await _context.TblMembers.FirstOrDefaultAsync(m => m.MemberId == id);
                if (Members == null)
                {
                    ViewData["messageM"] = "اطلاعات  عضو یافت نشد.";
                    MemberIsValid = false;
                }
                OfficeMembers = await _context.TblOfficeMembers.Where(Om => Om.SystemCode == id).ToListAsync();
                if (OfficeMembers.Count<= 0|| OfficeMembers==null)
                {
                    ViewData["messageOM"] = "اطلاعات اعضاء هیئت مدیره یافت نشد.";
                    OfficeMembersIsValid = false;
                }
                FinancialBalance = await _context.TblFinancialBalances.FirstOrDefaultAsync(f => f.SystemCode == id);
                if (FinancialBalance == null)
                {
                    ViewData["messageFB"] = "اطلاعات مالی بازرگانی یافت نشد.";
                    FinancialBalanceIsValid = false;
                }
                Questionnaire = await _context.TblQuestionnaires.FirstOrDefaultAsync(q => q.SystemCode == id);
                if (Questionnaire == null)
                {
                    ViewData["messageQ"] = "اطلاعات پرسشنامه یافت نشد.";
                    QuestionnaireIsValid = false;
                }
                Binarys = await _context.TblBinarys.Where(b => b.CreateUser == Services.UserMemberId).ToListAsync();
                if (Binarys == null)
                {
                    ViewData["messageB"] = "مدارک بارگذاری نشده است.";
                    BinaryIsValid = false;
                }
                return Page();


            }
            catch (Exception ex)
            {
                ViewData["message"] = ex.Message;
                return Page();
            }

        }
    }
}