﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Opex.Models;

namespace Opex.Pages.SenfiDetails
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly Opex.Models.DB_Context _context;

        public DetailsModel(Opex.Models.DB_Context context)
        {
            _context = context;
        }

        public TblMembers TblMembers { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblMembers = await _context.TblMembers.FirstOrDefaultAsync(m => m.MemberId == id);

            if (TblMembers == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostLogOff()
        {
            try
            {
                var authenticationManager = Request.HttpContext;
                await authenticationManager.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Redirect("Index");
        }
    }
}
