using RCM.Domain.Validators.ProdutoCommandValidators;
using System;

namespace RCM.Domain.Commands.ProdutoCommands
{
    public class AddProdutoAplicacaoCommand : ProdutoCommand
    {
        public int AnoCarroAplicacao { get; set; }
        public string MarcaCarroAplicacao { get; set; }
        public string ModeloCarroAplicacao { get; set; }
        public string MotorCarroAplicacao { get; set; }
        public string ObservacaoCarroAplicacao { get; set; }
        public Guid AplicacaoId { get; set; }

        public AddProdutoAplicacaoCommand(Guid produtoId, Guid aplicacaoId, string marca, string modelo, int ano, string motor = null, string observacao = null)
        {
            Id = produtoId;
            MarcaCarroAplicacao = marca;
            ModeloCarroAplicacao = modelo;
            AnoCarroAplicacao = ano;
            MotorCarroAplicacao = motor;
            ObservacaoCarroAplicacao = observacao;
            AplicacaoId = aplicacaoId;
        }

        public override bool IsValid()
        {
            ValidationResult = new AddProdutoAplicacaoCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
