using ByteBank.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPT7
{
    public class ListaDeContas
    {
        private ContaCorrente[] _contas;
        private int _proximaPosicaoLivre;

        public int QuantidadeDeItems
        {
            get
            {
                return _proximaPosicaoLivre;
            }
        }
        
        public ListaDeContas()
        {
            _contas = new ContaCorrente[5];
            _proximaPosicaoLivre = 0;
        }

        public void Adicionar(ContaCorrente conta)
        {
            VerificarCapacidade(_contas.Length + 1);

            _contas[_proximaPosicaoLivre] = conta;
            _proximaPosicaoLivre++;
        }

        // JOVIS: Implementar método Remover?
        // Talvez possamos tirar isso do curso
        // Mas, é uma oportunidade de falar sobre named arguments
        // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/named-and-optional-arguments
        public void Remover(ContaCorrente conta)
        {
            int indiceConta = Array.IndexOf(_contas, conta);

            Array.Copy(
                sourceArray: _contas,
                sourceIndex: indiceConta + 1,
                
                destinationArray: _contas,
                destinationIndex: indiceConta,
                
                length: _proximaPosicaoLivre - indiceConta);

            _proximaPosicaoLivre--;
        }

        private void VerificarCapacidade(int capacidadeNecessaria)
        {
            if(_contas.Length < capacidadeNecessaria)
            {
                ContaCorrente[] arrayComMaiorCapapacidade = new ContaCorrente[_contas.Length * 2];
                Array.Copy(_contas, arrayComMaiorCapapacidade, _contas.Length);

                _contas = arrayComMaiorCapapacidade;
            }
        }

        // JOVIS: recurso indexer
        // agora podemos usar listaDeContas[1] no lugar de listaDeContas.GetContaNoIndice(1)
        public ContaCorrente this[int indice]
        {
            get { return _contas[indice]; }
        }
    }
}
