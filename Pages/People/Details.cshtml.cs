using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorChoreList.Data;

namespace RazorChoreList.Pages_People
{
    public class DetailsModel : PageModel
    {
        private readonly RazorChoreList.Data.RazorChoreListContext _context;

        public DetailsModel(RazorChoreList.Data.RazorChoreListContext context)
        {
            _context = context;
        }

        public Person People { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var people = await _context.Person.FirstOrDefaultAsync(m => m.PersonId == id);
            if (people == null)
            {
                return NotFound();
            }
            else
            {
                People = people;
            }
            return Page();
        }
    }
}
