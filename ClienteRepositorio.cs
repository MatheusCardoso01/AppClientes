using System.Runtime.InteropServices;
using System.Threading.Channels;
using Cadastro;

namespace Repositorio;

public class ClienteRepositorio
{
    public List<Cadastro.Cliente> clientes = new List<Cadastro.Cliente>();
    private static int proximoID;

    public void imprimirCliente(Cliente cliente)
    {
        System.Console.WriteLine("---------INFORMAÇÕES DO CLIENTE--------");
        System.Console.WriteLine("ID: " + cliente.id);
        System.Console.WriteLine("Nome: " + cliente.Nome);
        System.Console.WriteLine("Desconto: " + cliente.Desconto);
        System.Console.WriteLine("Data de Nascimento: " + cliente.DataNascimento);
        System.Console.WriteLine("Data de Cadastro: " + cliente.CadastradoEm);
        System.Console.WriteLine("---------------------------------------");
    }

    public void ExibirClientes()
    {
        Console.Clear();

        if (clientes.Count == 0)
        {
            System.Console.WriteLine("Nenhum cliente cadastrado");
        }
        else
        {
            foreach (var cliente in clientes)
            {
                imprimirCliente(cliente);
            }
        }

        System.Console.WriteLine("Total de Clientes Cadastrados: " + clientes.Count);

        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey(true);
        Console.Clear();
    }

    public void CadastrarCliente()
    {

        Console.Clear();

        System.Console.WriteLine("-----INSIRA OS DADOS DO CLIENTE-----");

        Cliente cliente = new Cliente();
        cliente.id = proximoID + 1;

        System.Console.Write("Nome do Cliente: ");
        cliente.Nome = Console.ReadLine();
        System.Console.WriteLine(Environment.NewLine);

        System.Console.Write("Data de Nascimento: ");
        cliente.DataNascimento = DateOnly.Parse(Console.ReadLine());
        System.Console.WriteLine(Environment.NewLine);

        System.Console.Write("Desconto: ");
        cliente.Desconto = Decimal.Parse(Console.ReadLine());
        System.Console.WriteLine(Environment.NewLine);

        cliente.CadastradoEm = DateTime.Now;

        ConfirmarDadosCadastro(cliente);
    }

    private void ConfirmarDadosCadastro(Cliente cliente)
    {
        Console.Clear();
        imprimirCliente(cliente);

        System.Console.WriteLine("Os dados estão corretos? (s/n)");
        while (true)
        {
            string verificacaoDados = Console.ReadLine().ToLower();

            if (verificacaoDados == "s")
            {
                clientes.Add(cliente);
                proximoID++;
                break;
            }
            else if (verificacaoDados == "n")
            {
                break;
            }
            else
            {
                System.Console.WriteLine("Tecla incorreto. Digite 's' para Sim e 'n' para não.");
            }
        }

    }

    public void EditarCliente()
    {

        int IdEscolhido;

        Console.Clear();

        while (true)
        {
            try
            {
                System.Console.Write("Qual o ID do cliente a ser editado? ");
                IdEscolhido = int.Parse(Console.ReadLine());

                Cliente? ClienteEncontrado = VerificarSeIdValido(IdEscolhido);


                if (ClienteEncontrado != null)
                {
                    imprimirCliente(ClienteEncontrado);
                    AtualizarDadosCliente(ClienteEncontrado);
                    break;
                }

            }
            catch (Exception exception)
            {
                System.Console.WriteLine("ID Inválido. Insira qualquer tecla para continuar ou 'n' para encerrar a aplicação. Depois Aperte Enter");

                var decisao = Console.ReadLine();

                if (decisao == "n")
                {
                    break;
                }
            }
        }

    }

    private void AtualizarDadosCliente(Cliente cliente)
    {
        Console.Clear();

        System.Console.WriteLine("---INSIRA OS DADOS ATUALIZADOS---");
        System.Console.Write("Nome do Cliente: ");
        cliente.Nome = Console.ReadLine();

        System.Console.Write("Data de Nascimento: ");
        cliente.DataNascimento = DateOnly.Parse(Console.ReadLine());

        System.Console.Write("Desconto: ");
        cliente.Desconto = Decimal.Parse(Console.ReadLine());
    }

    private Cliente? VerificarSeIdValido(int IdEscolhido)
    {
        for (int i = 0; i < clientes.Count; i++)
        {
            if (clientes[i].id == IdEscolhido)
            {
                return clientes[i];
            }
        }

        System.Console.WriteLine("ID informado não está cadastrado. Tente novamente.");

        return null;
    }

    public void RemoverCliente()
    {

        int IdEscolhido;

        Console.Clear();

        while (true)
        {
            try
            {
                System.Console.Write("Qual o ID do cliente a ser Removido? ");
                IdEscolhido = int.Parse(Console.ReadLine());

                Cliente? ClienteEncontrado = VerificarSeIdValido(IdEscolhido);


                if (ClienteEncontrado != null)
                {
                    imprimirCliente(ClienteEncontrado);
                    clientes.Remove(ClienteEncontrado);
                    break;
                }

            }
            catch (Exception exception)
            {
                var decisao = Console.ReadLine();

                if (decisao == "n")
                {
                    break;
                }
            }
        }

    }


}