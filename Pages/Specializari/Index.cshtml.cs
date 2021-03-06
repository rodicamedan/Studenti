﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Studenti.Data;
using Studenti.Models;

namespace Studenti.Pages.Specializari
{
    public class IndexModel : PageModel
    {
        private readonly Studenti.Data.StudentiContext _context;

        public IndexModel(Studenti.Data.StudentiContext context)
        {
            _context = context;
        }

        public IList<Specializare> Specializare { get;set; }

        public async Task OnGetAsync()
        {
            Specializare = await _context.Specializare.ToListAsync();
        }
    }
}
