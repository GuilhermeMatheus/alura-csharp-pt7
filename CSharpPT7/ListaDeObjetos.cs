using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPT7
{
    // JOVIS: CopyPaste da ListaDeContas
    public class ListaDeObjetos
    {
        private object[] _objetos;
        private int _proximaPosicaoLivre;

        public int QuantidadeDeItems
        {
            get
            {
                return _proximaPosicaoLivre;
            }
        }

        public ListaDeObjetos()
        {
            _objetos = new object[5];
            _proximaPosicaoLivre = 0;
        }

        public void Adicionar(object obj)
        {
            VerificarCapacidade(_objetos.Length + 1);

            _objetos[_proximaPosicaoLivre] = obj;
            _proximaPosicaoLivre++;
        }

        public void Remover(object obj)
        {
            int indiceObj = Array.IndexOf(_objetos, obj);

            Array.Copy(
                sourceArray: _objetos,
                sourceIndex: indiceObj + 1,

                destinationArray: _objetos,
                destinationIndex: indiceObj,

                length: _proximaPosicaoLivre - indiceObj);

            _proximaPosicaoLivre--;
        }

        private void VerificarCapacidade(int capacidadeNecessaria)
        {
            if (_objetos.Length < capacidadeNecessaria)
            {
                object[] arrayComMaiorCapapacidade = new object[_objetos.Length * 2];
                Array.Copy(_objetos, arrayComMaiorCapapacidade, _objetos.Length);

                _objetos = arrayComMaiorCapapacidade;
            }
        }

        public object this[int indice]
        {
            get { return _objetos[indice]; }
        }
    }
}
