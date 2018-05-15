using AutoMapper;
using AutoMapper.QueryableExtensions;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels;
using RCM.Domain.Commands.CidadeCommands;
using RCM.Domain.Core.Commands;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.Models.CidadeModels;
using RCM.Domain.Repositories;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RCM.Application.ApplicationServices
{
    public class CidadeApplicationService : ICidadeApplicationService
    {
        private readonly IMediatorHandler _mediator;
        private readonly IMapper _mapper;
        private readonly ICidadeRepository _cidadeRepository;

        public CidadeApplicationService(IMediatorHandler mediator, IMapper mapper, ICidadeRepository cidadeRepository)
        {
            _mediator = mediator;
            _mapper = mapper;
            _cidadeRepository = cidadeRepository;
        }

        public IQueryable<CidadeViewModel> Get(Expression<Func<Cidade, bool>> expression = null)
        {
            return _cidadeRepository.Get(expression).ProjectTo<CidadeViewModel>();
        }

        public IQueryable<CidadeViewModel> Get()
        {
            return _cidadeRepository.Get().ProjectTo<CidadeViewModel>();
        }

        public CidadeViewModel GetById(Guid id)
        {
            var cidade = _mapper.Map<CidadeViewModel>(_cidadeRepository.GetById(id));
            return cidade;
        }

        public Task<CommandResult> Add(CidadeViewModel viewModel)
        {
            return _mediator.SendCommand(new AddCidadeCommand(viewModel.Nome, viewModel.EstadoId));
        }

        public Task<CommandResult> Remove(Guid id)
        {
            return _mediator.SendCommand(new RemoveCidadeCommand(id));
        }
    }
}
