using ByteBank.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPT7
{
    class Program
    {
        static void Main(string[] args)
        {
            Ordenando();

            Console.ReadLine();
        }

        static void ArrayDeInt()
        {
            int[] idades = new int[5];

            Console.WriteLine(idades.Length);

            idades[0] = 14;
            idades[1] = 45;
            idades[2] = 16;
            idades[3] = 22;
            idades[4] = 28;

            for (int indice = 0; indice < idades.Length; indice++)
            {
                int idade = idades[indice];
                Console.WriteLine($"Idade no índice {indice}: {idade}");
            }
        }
        static void ArrayDeContas()
        {
            // Array initializer
            var contas = new ContaCorrente[]
            {
                new ContaCorrente(865, 78846),
                new ContaCorrente(865, 87998),
                new ContaCorrente(865, 87981),
                new ContaCorrente(865, 12489),
                new ContaCorrente(865, 54668)
            };

            EscreverContasNoConsole(contas);
        }

        static void UsandoArgumentoParams()
        {
            //EscreverContasNoConsole(new ContaCorrente[] { ... });
            var conta1 = new ContaCorrente(865, 87981);
            var conta2 = new ContaCorrente(865, 12489);
            var contasEmArray = new ContaCorrente[] { conta1, conta2 };


            EscreverContasNoConsole(conta1);
            EscreverContasNoConsole(conta1, conta2);
            EscreverContasNoConsole(contasEmArray);
        }

        static void EscreverContasNoConsole(params ContaCorrente[] contas)
        {
            foreach (var conta in contas)
            {
                Console.WriteLine($"Conta número {conta.Numero}");
            }
        }

        static void ListaDeContas()
        {
            var lista = new ListaDeContas();

            var conta = new ContaCorrente(865, 87998);

            lista.Adicionar(conta);

            Console.WriteLine(lista.QuantidadeDeItems);

            lista.Adicionar(new ContaCorrente(865, 87998));
            lista.Adicionar(new ContaCorrente(865, 87981));
            lista.Adicionar(new ContaCorrente(865, 12489));
            lista.Adicionar(new ContaCorrente(865, 54668));

            Console.WriteLine(lista.QuantidadeDeItems);
            lista.Remover(conta);

            ContaCorrente contaDaLista = lista[2];
            Console.WriteLine($"Conta número {contaDaLista.Numero}");

            Console.WriteLine(lista.QuantidadeDeItems);
        }
        static void ListaDeObjetos()
        {
            var listaDeClientes = new ListaDeObjetos();

            // Object initializer
            var pedro = new Cliente
            {
                Nome = "Pedro",
                CPF = "486.789.139-20",
                Profissao = "Desenvolvedor Java"
            };

            listaDeClientes.Adicionar(pedro);
            listaDeClientes.Adicionar(new Cliente { Nome = "Ana", Profissao = "Desenvolvedora PHP", CPF = "456.445.644-1" });

            // Ops, aí não, né
            listaDeClientes.Adicionar(123);

            var cliente = (Cliente)listaDeClientes[2]; // InvalidCastException

            Console.WriteLine($"Cliente {cliente.Nome}");
        }
        static void ListaGenerica()
        {
            ListaGenerica<Cliente> listaDeClientes = new ListaGenerica<Cliente>();

            // JOVIS: Oportunidade de falar de obj initializer
            Cliente pedro = new Cliente
            {
                Nome = "Pedro",
                CPF = "486.789.139-20",
                Profissao = "Desenvolvedor Java"
            };

            listaDeClientes.Adicionar(pedro);
            listaDeClientes.Adicionar(new Cliente { Nome = "Ana", Profissao = "Desenvolvedora PHP", CPF = "456.445.644-1" });

            // Agora dá erro de compilacao
            // listaDeClientes.Adicionar(123);

            var cliente = listaDeClientes[1];

            Console.WriteLine($"Cliente {cliente.Nome}");
        }

        static void ListaDotNet()
        {
            var listaDeClientes = new List<Cliente>();

            var pedro = new Cliente
            {
                Nome = "Pedro",
                CPF = "486.789.139-20",
                Profissao = "Desenvolvedor Java"
            };

            listaDeClientes.Add(pedro);
            listaDeClientes.Add(new Cliente { Nome = "Ana", Profissao = "Desenvolvedora PHP", CPF = "456.445.644-1" });
            listaDeClientes.Add(new Cliente { Nome = "Pedro", Profissao = "Designer", CPF = "687.486.844-1" });
            listaDeClientes.Add(new Cliente { Nome = "Caroline", Profissao = "Estagiária", CPF = "162.415.123-1" });
            listaDeClientes.Add(new Cliente { Nome = "Igor", Profissao = "Estagiário", CPF = "498.498.123-5" });

            var cliente = listaDeClientes[1];

            Console.WriteLine($"Cliente {cliente.Nome}");
        }

        static void Ordenando()
        {
            var listaDeContas = GetContas();

            Console.WriteLine("Antes de ordenar por Saldo: ");
            foreach (var item in listaDeContas) // code snippet com nome "item"
            {
                Console.WriteLine($" - Conta Ag:{item.Agencia} Nº {item.Numero}: R$ {item.Saldo}");
            }

            listaDeContas.Sort(new ComparadorDeContaCorrentePorSaldo());

            Console.WriteLine("Depois de ordenar por Saldo: ");
            foreach (var item in listaDeContas) // code snippet com nome "item"
            {
                Console.WriteLine($" - Conta Ag:{item.Agencia} Nº {item.Numero}: R$ {item.Saldo}");
            }
        }
        static void OrdenandoComLambda()
        {
            var listaDeContas = GetContas();

            // Aqui fala de método de extensão e que vem do System.Linq
            var listaOrdenada = listaDeContas.OrderBy(conta => conta.GetSaldoTeste()); // método com WriteLine pra ver lazy

            // listaOrdenada.ToList(); depois testa com o ToList pra ver sem lazy

            Console.WriteLine("Antes de iterar.");
            foreach (var item in listaOrdenada)
            {
                Console.WriteLine($" - Conta Ag:{item.Agencia} Nº {item.Numero}: R$ {item.Saldo}");
            }
        }
        static void OrdenandoComLinq()
        {
            var listaDeContas = GetContas();

            var listaOrdenada = from conta in listaDeContas
                                orderby conta.GetSaldoTeste() // Aqui tem lazy tb
                                select conta;

            Console.WriteLine("Antes de iterar toda a lista");

            foreach (var item in listaOrdenada)
            {
                Console.WriteLine($" - Conta Ag:{item.Agencia} Nº {item.Numero}: R$ {item.Saldo}");
            }
        }

        static List<ContaCorrente> GetContas()
        {
            var conta1 = new ContaCorrente(546, 89798);
            conta1.Depositar(2673);

            var conta2 = new ContaCorrente(865, 27998);
            conta2.Depositar(100);

            var conta3 = new ContaCorrente(865, 57981);
            conta3.Depositar(400);

            var conta4 = new ContaCorrente(865, 12489);
            conta4.Depositar(1400);

            var conta5 = new ContaCorrente(865, 54668);
            conta5.Depositar(3000);

            return new List<ContaCorrente>
            {
                conta1,
                conta2,
                conta3,
                conta4,
                conta5
            };
        }
    }
}
