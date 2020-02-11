using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Kodutoo10Veebruar.Data;
using Kodutoo10Veebruar.Models.SchoolViewModels;
using Microsoft.EntityFrameworkCore;

namespace Kodutoo10Veebruar.Pages
{
    public class AboutModel : PageModel
    {
        private readonly Kodutoo10VeebruarContext _context;

        public AboutModel(Kodutoo10VeebruarContext context)
        {
            _context = context;
        }

        public IList<EnrollmentDateGroup> Students { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<EnrollmentDateGroup> data =
                from student in _context.Students
                group student by student.EnrollmentDate into dateGroup
                select new EnrollmentDateGroup()
                {
                    EnrollmentDate = dateGroup.Key,
                    StudentCount = dateGroup.Count()
                };

            Students = await data.AsNoTracking().ToListAsync();
        }
    }
}