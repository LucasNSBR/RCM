using RCM.Application.ViewModels;
using RCM.Domain.Models.DuplicataModels;
using System;

namespace RCM.Application.ApplicationInterfaces
{
    public interface IDuplicataApplicationService : IBaseApplicationService<Duplicata, DuplicataViewModel>
    {
        void Pagar(DuplicataViewModel viewModel, DateTime dataPagamento, decimal valorPago);
    }
}
