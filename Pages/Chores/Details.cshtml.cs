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
    public class DetailsModel : PageModel
    {
        private readonly RazorChoreList.Data.RazorChoreListContext _context;

        public DetailsModel(RazorChoreList.Data.RazorChoreListContext context)
        {
            _context = context;
        }

        public Chore Chore { get; set; } = default!;
        public Person Person { get; set; } = default!;

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
            else
            {
                Chore = chore;
            }

            // Trying to use Linq to get Person.Name using Chore.PersonId
            // var name = 
            //     from Person in Person 
            //     where Person.PersonId == Chore.PersonId 
            //     select Person.Name;

            return Page();
        }
    }
}
