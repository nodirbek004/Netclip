using Microsoft.EntityFrameworkCore;
using Netclip.Application.Absreactions;
using Netclip.Domain.Models;

namespace Netclip.Infrastructure.Persistance;

public class AppDbContext : DbContext, IAppDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext>options):base(options) 
    {
        
    }

    public DbSet<Order> Orders { get; set; }


}
