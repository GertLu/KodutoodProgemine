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
    public class IndexModel : PageModel
    {
        private readonly Kodutoo10Veebruar.Data.Kodutoo10VeebruarContext _context;

        public IndexModel(Kodutoo10Veebruar.Data.Kodutoo10VeebruarContext context)
        {
            _context = context;
        }
        public IList<Course> Courses { get; set; }


        public async Task OnGetAsync()
        {
            Courses = await _context.Courses
                .Include(c => c.Department)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
