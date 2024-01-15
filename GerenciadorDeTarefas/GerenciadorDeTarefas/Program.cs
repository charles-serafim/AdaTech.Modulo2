using Usuarios;
using Functions;
using Tarefas;

namespace GerenciadorDeTarefas;

public class Program
{
    static List<Usuario> listaDeUsuarios = new List<Usuario>
    {
        new TechLeader(1, "Charles Serafim"),
        new Desenvolvedor(2, "Kelle Pereira"),
        new TechLeader(3, "Suely Pereira"),
        new Desenvolvedor(4, "Maria Aparecida Serafim"),
        new Desenvolvedor(5, "Adalberto Morais")
    };

    static List<Acesso> acessos = new List<Acesso>
    {
        new Acesso(1, "charles", "88c208f1649ffc294e7bf77350a8ec63381a2b9421369c19d6f2aab2e9fd380a"),
        new Acesso(2, "kelle", "88c208f1649ffc294e7bf77350a8ec63381a2b9421369c19d6f2aab2e9fd380a"),
        new Acesso(3, "suely", "88c208f1649ffc294e7bf77350a8ec63381a2b9421369c19d6f2aab2e9fd380a"),
        new Acesso(4, "cida", "88c208f1649ffc294e7bf77350a8ec63381a2b9421369c19d6f2aab2e9fd380a"),
        new Acesso(5, "beto", "88c208f1649ffc294e7bf77350a8ec63381a2b9421369c19d6f2aab2e9fd380a")
    };

    static List<Tarefa> listaDeTarefas = new List<Tarefa>
    {
        new Tarefa(1, 2, StatusTarefaEnum.EmAndamento, new List<int>{ 2 }, new DateTime(2024, 1, 15), new DateTime(2024, 1, 18), "Terminar projeto individual", "Finalizar desenvolvimento do projeto do módulo OOP I", "VS"),
        new Tarefa(1, StatusTarefaEnum.APlanejar, new List<int>{ 4, 5 }, "Fazer compras", "Casa"),
        new Tarefa(3, 3, StatusTarefaEnum.Planejada, new List<int>{ 2, 4, 5 }, new DateTime(2024, 1, 10), new DateTime(2024, 1, 14), "Fazer reforma", " ", "Casa"),
        new Tarefa(4, 4, StatusTarefaEnum.Concluida, new List<int>{ 4 }, new DateTime(2024, 1, 9), new DateTime(2024, 1, 14), "Desenvolver app de passagem", "Comprar passagem com script", "VS"),
        new Tarefa(5, 5, StatusTarefaEnum.Abandonada, new List<int>{ 5 }, new DateTime(2024, 1, 15), new DateTime(2024, 1, 18), "Pintar casa do vizinho", " ", "Casa do vizinho"),
        new Tarefa(6, 4, StatusTarefaEnum.Impedida, new List<int>{ 4 }, new DateTime(2024, 1, 9), new DateTime(2024, 1, 18), "Pagar IPVA", " ", "Casa"),
        new Tarefa(7, 5, StatusTarefaEnum.EmAnalise, new List<int>{ 5 }, new DateTime(2024, 1, 15), new DateTime(2024, 1, 18), "Construir edícula", " ", "Casa"),
        new Tarefa(1, StatusTarefaEnum.APlanejar, new List<int>{ 5 }, "Viajar", "Praia"),
        new Tarefa(1, StatusTarefaEnum.APlanejar, new List<int>{ 4 }, "Correr", "Rua"),
        new Tarefa(2, StatusTarefaEnum.APlanejar, new List<int>{ 2 }, "Estudar", "Casa"),
        new Tarefa(2, StatusTarefaEnum.APlanejar, new List<int>{ 2 }, "Passear com o Maru", "Rua"),
        new Tarefa(3, StatusTarefaEnum.APlanejar, new List<int>{ 2 }, "Passear com o Toddy", "Rua")
    };
    
    static void Main(string[] args)
    {
        Usuario usuarioLogado;
        while (true)
        {
            Console.Clear();
            usuarioLogado = Autenticar();
            if (usuarioLogado == null)
            {
                Console.WriteLine("Chave de acesso ou senha incorretas.");
                Utils.GoOn();
                continue;
            }
            
            //Console.WriteLine($"Nome: {usuarioLogado.Nome}\n" +
            //                  $"ID: {usuarioLogado.IdUsuario}\n" +
            //                  $"Nível de acesso: {usuarioLogado.GetType().Name}\n");
            //Utils.GoOn();

            ShowMenu(usuarioLogado);
            Utils.GoOn();
        }
        
    }

    public static void ShowMenu(Usuario usuario)
    {
        while (true)
        {
            Console.Clear();
            usuario.ShowMenu();
            int option = Utils.ReadOption(0, 5, "Escolha uma opção");
            
        }
    }

    private static Usuario Autenticar()
    {
        string chaveDeAcesso, senha;

        Console.WriteLine("Para entrar no sistema, digite suas credenciais\n");
        Console.WriteLine("Chave de acesso:");
        chaveDeAcesso = Console.ReadLine();
        Console.WriteLine("Senha:");
        senha = Utils.LerSenha();

        int idUsuario = LocalizarAcesso(chaveDeAcesso, senha);

        if (idUsuario != -1)
        {
            Usuario? usuario = listaDeUsuarios.SingleOrDefault(u => u.IdUsuario == idUsuario);
            return usuario;
        }

        return null;
    }

    private static int LocalizarAcesso(string chaveDeAcesso, string senha)
    {
        Acesso acesso = acessos.SingleOrDefault(a =>
            string.Equals(a.ChaveDeAcesso, chaveDeAcesso, StringComparison.OrdinalIgnoreCase) &&
            string.Equals(a.Senha, senha, StringComparison.Ordinal));

        return acesso?.IdUsuario ?? -1;
    }
}
