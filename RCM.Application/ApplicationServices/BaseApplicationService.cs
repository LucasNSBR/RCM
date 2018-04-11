using AutoMapper;
using AutoMapper.QueryableExtensions;
using RCM.Application.ApplicationInterfaces;
using RCM.Domain.Core.Commands;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.Repositories;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RCM.Application.ApplicationServices
{
    public class BaseApplicationService<TModel, TViewModel> : IBaseApplicationService<TModel, TViewModel> where TModel : class
                                                                                                          where TViewModel : class
    {
        protected IBaseRepository<TModel> _baseRepository;
        protected IMapper _mapper;
        protected IMediatorHandler _mediator;


        public BaseApplicationService(IBaseRepository<TModel> baseRepository, IMapper mapper, IMediatorHandler mediator)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public IQueryable<TViewModel> Get()
        {
            return _baseRepository.Get().ProjectTo<TViewModel>();
        }

        public IQueryable<TViewModel> Get(Expression<Func<TModel, bool>> expression)
        {
            return _baseRepository.Get(expression).AsQueryable().ProjectTo<TViewModel>();
        }

        public TViewModel GetById(Guid id)
        {
            var model = _mapper.Map<TViewModel>(_baseRepository.GetById(id));
            return model;
        }

        public virtual Task<CommandResult> Add(TViewModel viewModel) { throw new ArgumentException("Direct base calling is not allowed. You need to override this method."); }
        public virtual Task<CommandResult> Remove(TViewModel viewModel){ throw new ArgumentException("Direct base calling is not allowed. You need to override this method."); }
        public virtual Task<CommandResult> Update(TViewModel viewModel) { throw new ArgumentException("Direct base calling is not allowed. You need to override this method."); }

        public void Dispose()
        {
            _baseRepository.Dispose();
        }
    }
}
