using DebitCardService.DataAccess.CQRS.Commands;

namespace DebitCardService.DataAccess.CQRS;

public class CommandExecutor : ICommandExecutor
{
    private readonly DebitCardServiceStorageContext _context;

    public CommandExecutor(DebitCardServiceStorageContext context)
    {
        _context = context;
    }

    public Task<TResult> Execute<TParameter, TResult>(CommandBase<TParameter, TResult> command)
    {
        return command.Execute(_context);
    }
}
