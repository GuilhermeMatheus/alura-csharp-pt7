using ByteBank.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPT7
{
    public class ComparadorDeContaCorrentePorSaldo : IComparer<ContaCorrente>
    {
        public int Compare(ContaCorrente conta1, ContaCorrente conta2)
        {
            if (conta1.Saldo < conta2.Saldo)
            {
                return -1;
            }

            if (conta1.Saldo > conta2.Saldo)
            {
                return 1;
            }

            return 0;
        }
    }
}
