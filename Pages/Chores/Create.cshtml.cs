using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            return Page();
        }

        [BindProperty]
        public Chore Chore { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Chore.Add(Chore);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
