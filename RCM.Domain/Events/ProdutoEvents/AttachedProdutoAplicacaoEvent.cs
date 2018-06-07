using RCM.Domain.Models.ProdutoModels;

namespace RCM.Domain.Events.ProdutoEvents
{
    public class AttachedProdutoAplicacaoEvent : ProdutoEvent
    {
        public Aplicacao Aplicacao { get; private set; }

        public AttachedProdutoAplicacaoEvent(Produto produto, Aplicacao aplicacao) : base(produto)
        {
            Aplicacao = aplicacao;
        }

        public override void Normalize()
        {
            Args.Add("AplicacaoId", Aplicacao.Id);

            Args.Add(nameof(Aplicacao.Carro.Marca), Aplicacao.Carro.Marca);
            Args.Add(nameof(Aplicacao.Carro.Modelo), Aplicacao.Carro.Modelo);
            Args.Add(nameof(Aplicacao.Carro.Motor), Aplicacao.Carro.Motor);
            Args.Add(nameof(Aplicacao.Carro.Ano), Aplicacao.Carro.Ano);
            Args.Add(nameof(Aplicacao.Carro.Observacao), Aplicacao.Carro.Observacao);
        }
    }
}
