using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPT7
{
    // JOVIS: CopyPaste da ListaDeObjetos
    public class ListaGenerica<T>
    {
        private T[] _items;
        private int _proximaPosicaoLivre;

        public int QuantidadeDeItems
        {
            get
            {
                return _proximaPosicaoLivre;
            }
        }

        public ListaGenerica()
        {
            _items = new T[5];
            _proximaPosicaoLivre = 0;
        }

        public void Adicionar(T item)
        {
            VerificarCapacidade(_items.Length + 1);

            _items[_proximaPosicaoLivre] = item;
            _proximaPosicaoLivre++;
        }

        public void Remover(T item)
        {
            int indiceItem = Array.IndexOf(_items, item);

            Array.Copy(
                sourceArray: _items,
                sourceIndex: indiceItem + 1,

                destinationArray: _items,
                destinationIndex: indiceItem,

                length: _proximaPosicaoLivre - indiceItem);

            _proximaPosicaoLivre--;
        }

        private void VerificarCapacidade(int capacidadeNecessaria)
        {
            if (_items.Length < capacidadeNecessaria)
            {
                T[] arrayComMaiorCapapacidade = new T[_items.Length * 2];
                Array.Copy(_items, arrayComMaiorCapapacidade, _items.Length);

                _items = arrayComMaiorCapapacidade;
            }
        }

        public T this[int indice]
        {
            get { return _items[indice]; }
        }
    }
}
