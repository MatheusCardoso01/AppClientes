using Repositorio;

namespace AppClientes;

class Program
{
    static void Main(string[] args)
    {
        ClienteRepositorio gerenciarClientes = new ClienteRepositorio();

        while (true)
        {
            Console.Clear();
            Menu();

            string escolhaMenu = Console.ReadLine();


            EscolhaMenu(gerenciarClientes, escolhaMenu);
        }
    }

    static void Menu()
    {
        System.Console.WriteLine("Cadastro de Clientes");
        System.Console.WriteLine("--------------------");
        System.Console.WriteLine("1 - Cadastrar Clientes");
        System.Console.WriteLine("2 - Exibir Clientes");
        System.Console.WriteLine("3 - Editar Clientes");
        System.Console.WriteLine("4 - Excluir Clientes");
        System.Console.WriteLine("5 - Sair");
        System.Console.WriteLine("--------------------");
    }

    static void EscolhaMenu(ClienteRepositorio gerenciarClientes, string escolhaMenu)
    {
        switch (escolhaMenu)
        {
            case "1":
                gerenciarClientes.CadastrarCliente();
                break;
            case "2":
                gerenciarClientes.ExibirClientes();
                break;
            case "3":
                gerenciarClientes.EditarCliente();
                break;
            case "4":
                gerenciarClientes.RemoverCliente();
                break;
            case "5":
                Console.WriteLine("Encerrando aplicação...");
                Environment.Exit(0);
                break;
            default:
                System.Console.WriteLine("Tecla Incorreta. Escolha um valor de 1 a 5.");
                break;
        }
    }
}
