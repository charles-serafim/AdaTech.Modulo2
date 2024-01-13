using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarefas;

namespace Usuarios;

public class TechLeader : Usuario
{
    public TechLeader(int idUsuario, string nome, NivelAcessoEnum nivelAcesso) : base(idUsuario, nome, nivelAcesso)
    {
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
