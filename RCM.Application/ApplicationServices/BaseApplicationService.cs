using AutoMapper;
using RCM.Application.ApplicationInterfaces;
using RCM.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper.QueryableExtensions;
using System.Linq;
using RCM.Domain.Core.MediatorServices;

namespace RCM.Application.ApplicationServices
{
    public class BaseApplicationService<TModel, TViewModel> : IBaseApplicationService<TModel, TViewModel> where TModel : class
                                                                                                          where TViewModel : class
    {
        protected IBaseRepository<TModel> _baseRepository;
        protected IMapper _mapper;
        protected TModel _model;
        protected IMediatorHandler _mediator;
        private IChequeRepository chequeRepository;
        private IMapper mapper;

        public BaseApplicationService(IBaseRepository<TModel> baseRepository, IMapper mapper, IMediatorHandler mediator)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public BaseApplicationService(IChequeRepository chequeRepository, IMapper mapper)
        {
            this.chequeRepository = chequeRepository;
            this.mapper = mapper;
        }

        public IEnumerable<TViewModel> Get()
        {
            return _baseRepository.Get().AsQueryable().ProjectTo<TViewModel>();
        }

        public IEnumerable<TViewModel> Get(Expression<Func<TModel, bool>> expression)
        {
            return _baseRepository.Get(expression).AsQueryable().ProjectTo<TViewModel>();
        }

        public TViewModel GetById(int id)
        {
            var model = _mapper.Map<TViewModel>(_baseRepository.GetById(id));
            return model;
        }

        public virtual void Add(TViewModel viewModel)
        {
        }

        public virtual void Remove(TViewModel viewModel)
        {
        }

        public virtual void Update(TViewModel viewModel)
        {
        }
    }
}
