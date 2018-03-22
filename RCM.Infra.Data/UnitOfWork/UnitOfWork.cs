using RCM.Domain.Core.Commands;
using RCM.Domain.Exceptions;
using RCM.Domain.UnitOfWork;
using RCM.Infra.Data.Context;
using System;

namespace RCM.Infra.Data.UnitOfWork
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
                    return new CommandResult(success: true);
                else
                    result.Errors.Add(new DataNotModifiedException());
            }
            catch (Exception ex)
            {
                result.Errors.Add(ex);
            }

            return result;
        }
    }
}
