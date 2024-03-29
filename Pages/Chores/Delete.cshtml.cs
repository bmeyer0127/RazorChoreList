using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorChoreList.Data;

namespace RazorChoreList.Pages_Chores
{
    public class DeleteModel : PageModel
    {
        private readonly RazorChoreList.Data.RazorChoreListContext _context;

        public DeleteModel(RazorChoreList.Data.RazorChoreListContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Chore Chore { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chore = await _context.Chore.FirstOrDefaultAsync(m => m.ChoreID == id);

            if (chore == null)
            {
                return NotFound();
            }
            else
            {
                Chore = chore;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chore = await _context.Chore.FindAsync(id);
            if (chore != null)
            {
                Chore = chore;
                _context.Chore.Remove(Chore);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
