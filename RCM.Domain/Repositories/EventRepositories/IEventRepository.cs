using System;

namespace RCM.Domain.Repositories.EventRepositories
{
    public interface IEventRepository
    {
        void Save(Guid id, Guid aggregateId, DateTime dateCreated, string type, string data);
    }
}
