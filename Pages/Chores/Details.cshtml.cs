using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using RazorChoreList.Data;

namespace RazorChoreList.Pages_Chores
{
    public class DetailsModel : PageModel
    {
        private readonly RazorChoreList.Data.RazorChoreListContext _context;

        public DetailsModel(RazorChoreList.Data.RazorChoreListContext context)
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

            var chore = await _context.Chore.
                Include(p => p.Person).FirstOrDefaultAsync(m => m.ChoreId == id);
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
    }
}
