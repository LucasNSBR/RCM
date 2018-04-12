using RCM.Domain.Models.DuplicataModels;
using System;

namespace RCM.Domain.Repositories
{
    public interface IDuplicataRepository : IBaseRepository<Duplicata>
    {
        bool CheckNumeroDocumentoExists(string numeroDocumento, Guid fornecedorId, Guid novaDuplicataId);
    }
}
