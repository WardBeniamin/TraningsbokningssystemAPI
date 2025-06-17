using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TraningsbokningssystemAPI.Models;

namespace TraningsbokningssystemAPI.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Kund> Kunder => Set<Kund>();
    public DbSet<TräningsPass> Träningspass => Set<TräningsPass>();
    public DbSet<Bokning> Bokningar => Set<Bokning>();
}
