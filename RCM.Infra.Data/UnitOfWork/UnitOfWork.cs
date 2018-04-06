using Microsoft.EntityFrameworkCore;
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

        public CommitResult Commit()
        {
            CommitResult result = new CommitResult();

            try
            {
                if (_RCMDbContext.SaveChanges() > 0)
                    return new CommitResult(success: true);
                else
                    result.AddError(new DataNotModifiedException());
            }
            catch(DbUpdateException ex)
            {
                result.AddError(ex);
            }
            catch (Exception ex)
            {
                result.AddError(ex);
            }

            return result;
        }
    }
}
