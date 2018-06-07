using RCM.Domain.Models.ProdutoModels;

namespace RCM.Domain.Events.ProdutoEvents
{
    public class RemovedProdutoAplicacaoEvent : ProdutoEvent
    {
        public Aplicacao Aplicacao { get; private set; }

        public RemovedProdutoAplicacaoEvent(Produto produto, Aplicacao aplicacao) : base(produto)
        {
            Aplicacao = aplicacao;
        }

        public override void Normalize()
        {
            Args.Add("AplicacaoId", Aplicacao.Id);
        }
    }
}
