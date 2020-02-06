using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Kodutoo3Veebruar.Data;
using Kodutoo3Veebruar.Models;

namespace Kodutoo3Veebruar
{
    public class DetailsModel : PageModel
    {
        private readonly Kodutoo3Veebruar.Data.Kodutoo3VeebruarContext _context;

        public DetailsModel(Kodutoo3Veebruar.Data.Kodutoo3VeebruarContext context)
        {
            _context = context;
        }

        public Movie Movie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie = await _context.Movie.FirstOrDefaultAsync(m => m.ID == id);

            if (Movie == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
