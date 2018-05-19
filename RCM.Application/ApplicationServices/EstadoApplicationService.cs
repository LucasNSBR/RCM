using AutoMapper;
using AutoMapper.QueryableExtensions;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels;
using RCM.Domain.Repositories;
using System;
using System.Linq;

namespace RCM.Application.ApplicationServices
{
    public class EstadoApplicationService : IEstadoApplicationService
    {
        private readonly IEstadoRepository _estadoRepository;
        private readonly IMapper _mapper;

        public EstadoApplicationService(IEstadoRepository estadoRepository, IMapper mapper)
        {
            _estadoRepository = estadoRepository;
            _mapper = mapper;
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
