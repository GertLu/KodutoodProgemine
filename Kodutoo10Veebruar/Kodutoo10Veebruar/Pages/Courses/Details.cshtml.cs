using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Kodutoo10Veebruar.Data;
using Kodutoo10Veebruar.Models;

namespace Kodutoo10Veebruar.Pages.Courses
{
    public class DetailsModel : PageModel
    {
        private readonly Kodutoo10Veebruar.Data.Kodutoo10VeebruarContext _context;

        public DetailsModel(Kodutoo10Veebruar.Data.Kodutoo10VeebruarContext context)
        {
            _context = context;
        }

        public Course Course { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Course = await _context.Courses
                .AsNoTracking()
                .Include(c => c.Department).FirstOrDefaultAsync(m => m.CourseID == id);

            if (Course == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
