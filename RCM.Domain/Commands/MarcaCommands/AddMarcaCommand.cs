namespace RCM.Domain.Commands.MarcaCommands
{
    public class AddMarcaCommand : MarcaCommand
    {
        public AddMarcaCommand(string nome, string observacao)
        {
            Nome = nome;
            Observacao = observacao;
        }

        public override bool IsValid()
        {
            throw new System.NotImplementedException();
        }
    }
}
