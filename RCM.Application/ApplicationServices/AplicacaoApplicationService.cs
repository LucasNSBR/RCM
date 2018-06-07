using AutoMapper;
using AutoMapper.QueryableExtensions;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels.ProdutoViewModels;
using RCM.Domain.Repositories;
using System;
using System.Linq;

namespace RCM.Application.ApplicationServices
{
    public class AplicacaoApplicationService : IAplicacaoApplicationService
    {
        private readonly IAplicacaoRepository _aplicacaoRepository;
        private readonly IMapper _mapper;

        public AplicacaoApplicationService(IAplicacaoRepository aplicacaoRepository, IMapper mapper)
        {
            _aplicacaoRepository = aplicacaoRepository;
            _mapper = mapper;
        }

        public IQueryable<AplicacaoViewModel> Get()
        {
            return _aplicacaoRepository.Get().ProjectTo<AplicacaoViewModel>()
                .OrderBy(a => a.CarroMarca)
                .ThenBy(a => a.CarroModelo)
                .ThenBy(a => a.CarroMotor)
                .ThenByDescending(a => a.CarroAno);
        }

        public AplicacaoViewModel GetById(Guid id)
        {
            var aplicacao = _mapper.Map<AplicacaoViewModel>(_aplicacaoRepository.GetById(id));
            return aplicacao;
        }
    }
}
