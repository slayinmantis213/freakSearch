#pragma warning disable CS8618

using Microsoft.EntityFrameworkCore;
using freakSearch.Models; // Replace with your actual models namespace

public class MyContext : DbContext
{
    public MyContext(DbContextOptions<MyContext> options) : base(options) { }
    public DbSet<Episode> Episodes { get; set; }
    public DbSet<Presenter> Presenters { get; set; }
    public DbSet<PresentedBy> PresentedBys { get; set; }
    public DbSet<Guest> Guests { get; set; }
    public DbSet<GuestofEpisode> GuestsofEpisodes { get; set; }
}