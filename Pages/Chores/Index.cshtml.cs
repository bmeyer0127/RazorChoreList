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
    public class IndexModel : PageModel
    {
        private readonly RazorChoreList.Data.RazorChoreListContext _context;

        public IndexModel(RazorChoreList.Data.RazorChoreListContext context)
        {
            _context = context;
        }

        public IList<Chore> Chore { get; set; } = default!;
        public IList<Person> People { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Chore = await _context.Chore.ToListAsync();
            People = await _context.Person.ToListAsync();
        }
    }
}
