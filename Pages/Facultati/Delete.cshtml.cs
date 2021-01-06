﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Studenti.Data;
using Studenti.Models;

namespace Studenti.Pages.Facultati
{
    public class DeleteModel : PageModel
    {
        private readonly Studenti.Data.StudentiContext _context;

        public DeleteModel(Studenti.Data.StudentiContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Facultate Facultate { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Facultate = await _context.Facultate.FirstOrDefaultAsync(m => m.ID == id);

            if (Facultate == null)
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

            Facultate = await _context.Facultate.FindAsync(id);

            if (Facultate != null)
            {
                _context.Facultate.Remove(Facultate);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
