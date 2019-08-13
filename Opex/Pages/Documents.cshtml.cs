using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Opex.Models;

namespace Opex.Pages
{
    public class DocumentsModel : PageModel
    {
        private readonly DB_Context _context;
        public DocumentsModel(DB_Context context)
        {
            _context = context;
        }
        [TempData]
        public string Error { get; set; }
        public bool ShowMessage => !string.IsNullOrEmpty(Error);
        [TempData]
        public string TabPage { get; set; }
        public bool ShowTab => !string.IsNullOrEmpty(TabPage);
        public TblBinarys binarys { get; set; }
        public async Task<IActionResult> OnGet(int? id)
        {
            try
            {
                if (id == null)
                {
                    Error = "فایل یافت نشد.";
                    return RedirectToPage("/Binarys");
                }
                binarys = _context.TblBinarys.Where(b => b.BinaryId == id).FirstOrDefault();

                if (binarys == null)
                {
                    Error = "فایل یافت نشد.";
                    return RedirectToPage("/Error");
                }
                if (binarys.FileFormat == "pdf")
                    return File(binarys.Binary, "application/pdf");
                if (binarys.FileFormat == "png" || binarys.FileFormat == "jpg" || binarys.FileFormat == "jpeg")
                    return File(binarys.Binary, "image/png");
                return RedirectToPage("/Index");
            }
            catch (Exception ex)
            {

                Error = ex.Message.ToString();
                return RedirectToPage("/Error");
            }

        }
        public FileResult GetFileFromBytes(byte[] bytesIn)
        {
            if (binarys.FileFormat == "pdf")
                return File(bytesIn, "application/pdf");
            return File(bytesIn, "image/png");
        }
    }
}