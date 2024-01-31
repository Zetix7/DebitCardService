using DebitCardService.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

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

    public IEnumerable<T> GetAll()
    {
        return _entities.AsEnumerable();
    }

    public T? GetById(int id)
    {
        return _entities.SingleOrDefault(x => x.Id == id);
    }

    public void Insert(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        _entities.Add(entity);
        _context.SaveChanges();
    }

    public void Update(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }
    }

    public void Delete(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }
    }
}
