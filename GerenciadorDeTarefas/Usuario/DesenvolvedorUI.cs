using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarefas;

namespace Usuarios;

public class DesenvolvedorUI
{
    public void ShowMenu()
    {
        Console.WriteLine("1 - Criar tarefa\n" +
                          "2 - Visualizar tarefa\n" +
                          "3 - Modificar status da tarefa\n" +
                          "4 - Visualizar minhas tarefas\n" +
                          "5 - Visualizar minhas estatísticas\n" +
                          "0 - Sair\n");
    }

    //public override void VisualizarTarefas<T>(List<T> listaDeTarefas);
    //public override void VisualizarEstatisticas<T>(List<T> listaDeTarefas);
    //public override Tarefa CriarTarefa(StatusTarefaEnum statusTarefa, string titulo, string local);
    //public override void ModificarStatusDaTarefa(Tarefa tarefa);
}
