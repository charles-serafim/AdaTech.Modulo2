using Usuarios;
using Functions;

namespace GerenciadorDeTarefas;

public class Program
{
    static List<Usuario> listaDeUsuarios = new List<Usuario>
    {
        new TechLeader(1, "Charles Serafim")
    };

    static List<Acesso> acessos = new List<Acesso>
    {
        new Acesso(1, "charles", "88c208f1649ffc294e7bf77350a8ec63381a2b9421369c19d6f2aab2e9fd380a")
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
        Console.Clear();
        usuario.ShowMenu();
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
