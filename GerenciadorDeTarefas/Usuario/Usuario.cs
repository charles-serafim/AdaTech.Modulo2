using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Tarefas;

namespace Usuarios;

public abstract class Usuario
{
    private static int s_contadorUsuarios = 0;
    public int IdUsuario { get; set; }
    public string Nome { get; private set; }

    public Usuario(string nome)
    {
        IdUsuario = ++s_contadorUsuarios;
        Nome = nome;
    }
    public Usuario(int idUsuario, string nome)
    {
        IdUsuario = idUsuario;
        Nome = nome;
    }

    public abstract void ShowMenu();

    //public abstract void VisualizarTarefas<T>(List<T> listaDeTarefas);
    //public abstract void VisualizarEstatisticas<T>(List<T> listaDeTarefas);
    //public abstract Tarefa CriarTarefa(StatusTarefaEnum statusTarefa, string titulo, string local);
    //public abstract void ModificarStatusDaTarefa(Tarefa tarefa);
}
