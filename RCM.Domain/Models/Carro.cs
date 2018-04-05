using RCM.Domain.Core.Models;

namespace RCM.Domain.Models
{
    public class Carro : ValueObject
    {
        public string Marca { get; private set; }
        public string Modelo { get; private set; }
        public int Ano { get; private set; }
        public string Observacao { get; private set; }
        public string Cor { get; private set; }
        public string Placa { get; private set; }

        public Carro(string marca, string modelo, int ano, string placa, string cor = null, string observacao = null)
        {
            Marca = marca;
            Modelo = modelo;
            Ano = ano;
            Placa = placa;
            Cor = cor;
            Observacao = observacao;
        }
    }
}
