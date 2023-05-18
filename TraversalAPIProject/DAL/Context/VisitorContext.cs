using Microsoft.EntityFrameworkCore;
using TraversalAPIProject.DAL.Entities;

namespace TraversalAPIProject.DAL.Context
{
    public class VisitorContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-Q9UD8RF;database=TraversalDBApi;integrated security=true;");
        }
        public DbSet<Visitor> Visitors { get; set; }
    }
}
