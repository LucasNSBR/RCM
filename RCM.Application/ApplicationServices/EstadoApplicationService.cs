using System;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels;
using RCM.Domain.Repositories;

namespace RCM.Application.ApplicationServices
{
    public class EstadoApplicationService : IEstadoApplicationService
    {
        private readonly IMapper _mapper;
        private readonly IEstadoRepository _estadoRepository;

        public EstadoApplicationService(IMapper mapper, IEstadoRepository estadoRepository)
        {
            _mapper = mapper;
            _estadoRepository = estadoRepository;
        }

        public IQueryable<EstadoViewModel> Get()
        {
            return _estadoRepository.Get().ProjectTo<EstadoViewModel>();
        }

        public EstadoViewModel GetById(Guid id)
        {
            var estado = _mapper.Map<EstadoViewModel>(_estadoRepository.GetById(id));
            return estado;
        }
    }
}
