using RCM.Domain.Core.Commands;
using RCM.Domain.UnitOfWork;
using RCM.Infra.Models;
using System;

namespace RCM.Infra.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RCMDbContext _RCMDbContext;

        public UnitOfWork(RCMDbContext dbContext)
        {
            _RCMDbContext = dbContext;
        }

        public CommandResult Commit()
        {
            CommandResult result = new CommandResult();

            try
            {
                if (_RCMDbContext.SaveChanges() > 0)
                    return new CommandResult(true);
            }
            catch (Exception e)
            {
                result.Errors.Add(e);
            }

            return result;
        }
    }
}
