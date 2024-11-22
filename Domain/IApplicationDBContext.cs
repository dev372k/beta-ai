using Microsoft.EntityFrameworkCore;

namespace Domain;

public interface IApplicationDBContext
{
    DbSet<TEntity> Set<TEntity>() where TEntity : class;
}
