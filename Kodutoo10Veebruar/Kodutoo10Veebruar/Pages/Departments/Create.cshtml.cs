using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Kodutoo10Veebruar.Data;
using Kodutoo10Veebruar.Models;

namespace Kodutoo10Veebruar.Pages.Departments
{
    public class CreateModel : PageModel
    {
        private readonly Kodutoo10Veebruar.Data.Kodutoo10VeebruarContext _context;

        public CreateModel(Kodutoo10Veebruar.Data.Kodutoo10VeebruarContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["InstructorID"] = new SelectList(_context.Instructors, "ID", "FirstMidName");
            return Page();
        }

        [BindProperty]
        public Department Department { get; set; }

        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Departments.Add(Department);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
