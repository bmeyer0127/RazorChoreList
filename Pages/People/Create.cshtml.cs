using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorChoreList.Data;

namespace RazorChoreList.Pages_People
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
            return Page();
        }

        [BindProperty]
        public CreatePerson Person { get; set; }
        public Chore Chore { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var newPerson = new Person
            {
                Name = Person.Name
            };

            if (_context.Person.Any(i => i.Name == newPerson.Name))
            {
                ModelState.AddModelError("SamePersonError", $"{newPerson.Name} is already a person here");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Person.Add(newPerson);
            await _context.SaveChangesAsync();

            return RedirectToPage("../Chores/Index");
        }
    }
}
