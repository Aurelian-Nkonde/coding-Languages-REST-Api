using System;
using Microsoft.EntityFrameworkCore;
using codingLanguages.Models;


namespace codingLanguages.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt): base(opt)
        {
            
        }

        public DbSet<Language>? languages {get;set;}
    }
}
