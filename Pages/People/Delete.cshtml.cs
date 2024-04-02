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
    public class DeleteModel : PageModel
    {
        private readonly RazorChoreList.Data.RazorChoreListContext _context;

        public DeleteModel(RazorChoreList.Data.RazorChoreListContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Person People { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var people = await _context.People.FirstOrDefaultAsync(m => m.PersonId == id);

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var people = await _context.People.FindAsync(id);
            if (people != null)
            {
                People = people;
                _context.People.Remove(people);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
