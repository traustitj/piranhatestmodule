using System;
using Microsoft.EntityFrameworkCore;


namespace testmodule.EFModels
{
    public class NameContext : DbContext
    {
        public DbSet<Name> Names { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=names.db");
    }
}
