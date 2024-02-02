using DebitCardService.DataAccess.CQRS.Queries;

namespace DebitCardService.DataAccess.CQRS;

public interface IQueryExecutor
{
    Task<TResult> Execute<TResult>(QueryBase<TResult> query);
}
