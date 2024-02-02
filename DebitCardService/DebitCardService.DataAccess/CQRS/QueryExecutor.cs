using DebitCardService.DataAccess.CQRS.Queries;

namespace DebitCardService.DataAccess.CQRS;

public class QueryExecutor : IQueryExecutor
{
    private readonly DebitCardServiceStorageContext _context;

    public QueryExecutor(DebitCardServiceStorageContext context)
    {
        _context = context;
    }

    public Task<TResult> Execute<TResult>(QueryBase<TResult> query)
    {
        return query.Execute(_context);
    }
}
