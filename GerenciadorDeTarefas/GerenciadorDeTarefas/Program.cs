using Usuarios;
using Functions;

namespace GerenciadorDeTarefas;

public class Program
{
    static List<Usuario> listaDeUsuarios = new List<Usuario>
    {
        new TechLeader(1, "Charles Serafim", NivelAcessoEnum.TechLeader);
    };

    static List<Acesso> acessos = new List<Acesso>
    {
        new Acesso(1, "charles", "88c208f1649ffc294e7bf77350a8ec63381a2b9421369c19d6f2aab2e9fd380a")
    };
    
    static void Main(string[] args)
    {
        Usuario usuarioLogado = Autenticar();
        if (usuarioLogado == null)
        {
            
        }
    }

    private static Usuario Autenticar()
    {
        string chaveDeAcesso, senha;

        Console.WriteLine("Para entrar no sistema, digite suas credenciais\n");
        Console.WriteLine("Chave de acesso:");
        chaveDeAcesso = Console.ReadLine();
        Console.WriteLine("Senha:");
        senha = LerSenha();

        Console.WriteLine(senha);

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

    static string LerSenha()
    {
        string senha = "";
        ConsoleKeyInfo key;

        do
        {
            key = Console.ReadKey(true);

            // verifica se a tecla pressionada é uma tecla de caractere
            if (char.IsLetterOrDigit(key.KeyChar) || char.IsSymbol(key.KeyChar))
            {
                senha += key.KeyChar;
                Console.Write("*");
            }
            else if (key.Key == ConsoleKey.Backspace && senha.Length > 0)
            {
                senha = senha.Substring(0, senha.Length - 1);
                Console.Write("\b \b"); // apaga o último caractere digitado
            }
        } while (key.Key != ConsoleKey.Enter);

        return Utils.Hash(senha);
    }
}
