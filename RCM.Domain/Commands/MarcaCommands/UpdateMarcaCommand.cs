using System;

namespace RCM.Domain.Commands.MarcaCommands
{
    public class UpdateMarcaCommand : MarcaCommand
    {
        public UpdateMarcaCommand(Guid id, string nome, string observacao)
        {
            Id = id;
            Nome = nome;
            Observacao = observacao;
        }

        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
