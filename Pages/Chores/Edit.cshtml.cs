using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorChoreList.Data;

namespace RazorChoreList.Pages_Chores
{
    public class EditModel : PageModel
    {
        private readonly RazorChoreList.Data.RazorChoreListContext _context;

        public EditModel(RazorChoreList.Data.RazorChoreListContext context)
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

            var chore = await _context.Chore.FirstOrDefaultAsync(m => m.ChoreId == id);
            if (chore == null)
            {
                return NotFound();
            }
            Chore = chore;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Chore).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChoreExists(Chore.ChoreId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ChoreExists(int id)
        {
            return _context.Chore.Any(e => e.ChoreId == id);
        }
    }
}
