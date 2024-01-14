using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarefas;

namespace Usuarios;

public class TechLeader : Usuario
{
    public TechLeader(string nome) : base(nome)
    {
    }
    public TechLeader(int idUsuario, string nome) : base(idUsuario, nome)
    {
    }

    public override void ShowMenu()
    {
        Console.WriteLine("1 - Criar tarefa\n" +
                          "2 - Modificar tarefa\n" +
                          "3 - Visualizar todas as tarefas\n" +
                          "4 - Visualizar tarefas por responsável\n" +
                          "5 - Visualizar estatísticas\n" +
                          "0 - Sair\n");
    }

    public void MenuTarefa()
    {
        Console.WriteLine("1 - Alocar responsável\n" +
                          "2 - Adicionar tarefa relacionada\n" +
                          "3 - Editar data de início\n" +
                          "4 - Editar data limite\n" +
                          "5 - Autorizar início\n" +
                          "6 - Analisar tarefa\n" +
                          "7 - Modificar status\n" +
                          "0 - Voltar\n");
    }

    //public override void VisualizarTarefas<T>(List<T> listaDeTarefas);
    //public override void VisualizarEstatisticas<T>(List<T> listaDeTarefas);
    //public override Tarefa CriarTarefa(StatusTarefaEnum statusTarefa, string titulo, string local);
    //public override void ModificarStatusDaTarefa(Tarefa tarefa);

    //public void AssumirTarefa(); // idem AlocarResponsavel()
    //public void AlocarResponsavel(); // implementação na classe Tarefa
    //public void RealocarResponsavel(); // idem AlocarResponsavel()
    //public void RelacionarTarefas();
    //public void AnalisarTarefas();
    //public void AutorizarInicioDaTarefa();
    //public void DefinirTempoDaTarefa(); // implementação na classe Tarefa
}
