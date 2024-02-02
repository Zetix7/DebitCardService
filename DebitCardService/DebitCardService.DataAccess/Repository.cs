using DebitCardService.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DebitCardService.DataAccess;

public class Repository<T> : IRepository<T> where T : EntityBase
{
    private readonly DebitCardServiceStorageContext _context;
    private readonly DbSet<T> _entities;

    public Repository(DebitCardServiceStorageContext context)
    {
        _context = context;
        _entities = context.Set<T>();
    }

    public Task<List<T>> GetAll()
    {
        return _entities.ToListAsync();
    }

    public Task<T?> GetById(int id)
    {
        return _entities.SingleOrDefaultAsync(x => x.Id == id);
    }

    public Task Insert(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        _entities.Add(entity);
        return _context.SaveChangesAsync();
    }

    public Task Update(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }
        return _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        T? entity = await GetById(id);
        _entities.Remove(entity!);
        await _context.SaveChangesAsync();
    }
}
