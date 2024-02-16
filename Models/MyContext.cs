using Microsoft.EntityFrameworkCore;
using freakSearch.Models; // Replace with your actual models namespace

public class MyContext : DbContext
{
    public MyContext(DbContextOptions<MyContext> options) : base(options)
    {
    }

    public DbSet<Episode> Episodes { get; set; }
}