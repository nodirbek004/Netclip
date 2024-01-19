using Microsoft.EntityFrameworkCore;
using Netclip.Domain.Models;

namespace Netclip.Application.Absreactions;

public interface IAppDbContext
{
    DbSet<Order> Orders { get; set; }
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken);

}
