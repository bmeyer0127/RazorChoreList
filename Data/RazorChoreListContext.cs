using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RazorChoreList.Data
{
    public class RazorChoreListContext : DbContext
    {
        public RazorChoreListContext(DbContextOptions<RazorChoreListContext> options)
            : base(options)
        {
        }

        public DbSet<Chore> Chore { get; set; } = default!;
        public DbSet<Person> People { get; set; } = default!;
    }
}
