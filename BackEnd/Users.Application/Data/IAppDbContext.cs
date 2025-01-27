using Microsoft.EntityFrameworkCore;
using Users.Domain.Models;

namespace Users.Application.Data;
public interface IAppDbContext
{
    DbSet<User> Users { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    int SaveChanges();
}
