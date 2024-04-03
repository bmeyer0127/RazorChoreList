using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorChoreList.Data;

namespace RazorChoreList.Pages_Chores
{
    public class CreateModel : PageModel
    {
        private readonly RazorChoreList.Data.RazorChoreListContext _context;

        public CreateModel(RazorChoreList.Data.RazorChoreListContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            People = _context.Person.ToList();
            return Page();
        }

        [BindProperty]
        public CreateChore Chore { get; set; }
        public IList<Person> People { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var newChore = new Chore
            {
                ChoreName = Chore.ChoreName,
                CompletionStatus = Chore.CompletionStatus,
                PersonId = Chore.PersonId
            };

            _context.Chore.Add(newChore);

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
