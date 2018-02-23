using RCM.Domain.Core.Commands;

namespace RCM.Domain.UnitOfWork
{
    public interface IUnitOfWork
    {
        CommandResult Commit();
    }
}
