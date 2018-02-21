namespace RCM.Domain.UnitOfWork
{
    public interface IUnitOfWork
    {
        bool Commit();
    }
}
