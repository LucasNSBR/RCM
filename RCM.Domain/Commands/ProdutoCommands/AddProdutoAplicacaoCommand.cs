using RCM.Domain.Validators.ProdutoCommandValidators;
using System;

namespace RCM.Domain.Commands.ProdutoCommands
{
    public class AddProdutoAplicacaoCommand : ProdutoCommand
    {
        public int AnoAplicacao { get; set; }
        public string MarcaAplicacao { get; set; }
        public string ModeloAplicacao { get; set; }
        public string MotorAplicacao { get; set; }
        public string ObservacaoAplicacao { get; set; }

        public AddProdutoAplicacaoCommand(Guid produtoId, string marca, string modelo, int ano, string motor = null, string observacao = null)
        {
            Id = produtoId;
            MarcaAplicacao = marca;
            ModeloAplicacao = modelo;
            AnoAplicacao = ano;
            MotorAplicacao = motor;
            ObservacaoAplicacao = observacao;
        }

        public override bool IsValid()
        {
            ValidationResult = new AddProdutoAplicacaoCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
