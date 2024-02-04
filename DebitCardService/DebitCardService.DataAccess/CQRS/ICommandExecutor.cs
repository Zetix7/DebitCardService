using DebitCardService.DataAccess.CQRS.Commands;

namespace DebitCardService.DataAccess.CQRS;

public interface ICommandExecutor
{
    Task<TResult> Execute<TParameter, TResult>(CommandBase<TParameter, TResult> command);
}
