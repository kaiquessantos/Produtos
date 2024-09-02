using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produtos
{
    internal class Program
    {

        struct Produtos
        {
            string nome;
            float preco;
            string marca;
            string espec;

            public Produtos(string nome, float preco, string marca, string espec)
            {
                this.nome = nome;
                this.preco = preco;
                this.marca = marca;
                this.espec = espec;
            }

            public void ExibirInf()
            {
                Console.WriteLine($"Nome: {this.nome}");
                Console.WriteLine($"Preço: R${this.preco}");
                Console.WriteLine($"Marca: {this.marca}");
                Console.WriteLine($"Especificações: {this.espec}");
            }

            public float CupomDesconto(float preco)
            {
                float desconto = preco - (preco * 20 / 100);
                return desconto;
            }

            public void ExibirDescontoVinte()
            {
                Console.WriteLine($"Nome: {this.nome}");
                Console.WriteLine($"Preço: R${CupomDesconto(this.preco)}");
                Console.WriteLine($"Marca: {this.marca}");
                Console.WriteLine($"Especificações: {this.espec}");
            }


        }


        enum Opcao
        {
            Sair, Comprar
        }

        enum Buy
        {
            Voltar, monitorLG , tecladoK500, mouseAttShark
        }

        enum finalizarCompra
        {
            Sim = 1, Nao
        }


        static void Main(string[] args)
        {

            Produtos monitorLG = new Produtos("Monitor UltraGear", 899.99f, "LG", "165Hz, 24polegadas");
            Produtos tecladoK500 = new Produtos("Teclado Machenike K500", 259.99f, "Machenike", "Mechanical Keyboard");
            Produtos mouseAttShark = new Produtos("Mouse Attack Shark X3", 198.99f, "Attack Shark", "Mouse Wireless");

            

            bool fecharLoja = false;
            while (!fecharLoja)
            {
                Console.WriteLine("Bem-Vindo a CSharp Store!");
                Console.WriteLine("Deseja:\n1-Comprar\n0-Sair");
                int escolha = int.Parse(Console.ReadLine());
                Opcao selecionado = (Opcao)escolha;

                switch(selecionado)
                {
                    case Opcao.Sair:
                        fecharLoja = true;
                        break;

                    case Opcao.Comprar:


                        bool limparMenu = false;
                        while (!limparMenu)
                        {

                            Console.WriteLine("Selecione o item que deseja comprar, para ver suas especificações: ");
                            Console.WriteLine("1-Monitor UltraGear\n2-Teclado Machenike K500\n3-Mouse Attack Shark X3\n0-Voltar");
                            int compra = int.Parse(Console.ReadLine());
                            Buy comprou = (Buy)compra;

                            switch (comprou)
                            {
                                case Buy.Voltar:
                                    limparMenu = true;
                                    Console.Clear();
                                    break;

                                case Buy.monitorLG:
                                    monitorLG.ExibirInf();
                                    FinalizarCompra(monitorLG, ref limparMenu);
                                    break;

                                case Buy.tecladoK500:
                                    tecladoK500.ExibirInf();
                                    FinalizarCompra(tecladoK500, ref limparMenu);
                                    break;

                                case Buy.mouseAttShark:
                                    mouseAttShark.ExibirInf();
                                    FinalizarCompra(mouseAttShark, ref limparMenu);
                                    break;


                            }
                        }
                        break;
                }
            }          
        }

        static void AlterarValorLimparMenu(ref bool limparMenu, bool novoValor)
        {
            limparMenu = novoValor;
        }

        static void FinalizarCompra(Produtos product, ref bool limparMenu)
        {
            Console.WriteLine("Finalizar compra?\n1-Sim\n2-Não");
            int finalizar = int.Parse(Console.ReadLine());
            finalizarCompra fim = (finalizarCompra)finalizar;

            switch (fim)
            {

                case finalizarCompra.Nao:
                    Console.WriteLine("Tecle ENTER para voltar ao menu de compras: ");
                    Console.ReadLine();
                    Console.Clear();

                    break;

                case finalizarCompra.Sim:
                    Console.WriteLine("Compra realizada com sucesso!");
                    Console.WriteLine("Digite:\n1-Continuar comprando!\n0-Voltar ao menu.");
                    int contVoltar = int.Parse(Console.ReadLine());

                    switch(contVoltar)
                    {
                        case 0:
                            AlterarValorLimparMenu(ref limparMenu, true);
                            Console.Clear();
                            break;

                        case 1:
                            Console.Clear();
                            break;

                        default:
                            Console.WriteLine("ERRO! Informação inválida, tecle ENTER para voltar ao menu inicial!");
                            Console.ReadLine();
                            Console.Clear();
                            AlterarValorLimparMenu(ref limparMenu, true);
                            break;
                    }

                    break;

            }
        }
    }
}
