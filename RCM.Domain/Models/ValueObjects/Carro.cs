using RCM.Domain.Core.Models;

namespace RCM.Domain.Models.ValueObjects
{
    public class Carro : ValueObject
    {
        public int Ano { get; private set; }
        public string Marca { get; private set; }
        public string Modelo { get; private set; }
        public string Motor { get; private set; }
        public string Observacao { get; private set; }


        protected Carro() { }

        public Carro(string marca, string modelo)
        {
            Marca = marca;
            Modelo = modelo;
        }

        public Carro(string marca, string modelo, int ano, string motor = null, string observacao = null)
        {
            Marca = marca;
            Modelo = modelo;
            Ano = ano;
            Motor = motor;
            Observacao = observacao;
        }
    }
}
