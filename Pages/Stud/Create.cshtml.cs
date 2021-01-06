using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Studenti.Data;
using Studenti.Models;

namespace Studenti.Pages.Stud
{
    public class CreateModel : PageModel
    {
        private readonly Studenti.Data.StudentiContext _context;

        public CreateModel(Studenti.Data.StudentiContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["IDFacultate"] = new SelectList(_context.Set<Facultate>(), "ID", "Facultate");
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Student.Add(Student);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
