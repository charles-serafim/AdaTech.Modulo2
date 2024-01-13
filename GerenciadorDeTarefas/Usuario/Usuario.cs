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
    public NivelAcessoEnum NivelAcesso { get; private set; }

    public Usuario(string nome, NivelAcessoEnum nivelAcesso)
    {
        IdUsuario = ++s_contadorUsuarios;
        Nome = nome;
        NivelAcesso = nivelAcesso;
    }
    public Usuario(int idUsuario, string nome, NivelAcessoEnum nivelAcesso)
    {
        IdUsuario = idUsuario;
        Nome = nome;
        NivelAcesso = nivelAcesso;
    }

    //public abstract void VisualizarTarefas<T>(List<T> listaDeTarefas);
    //public abstract void VisualizarEstatisticas<T>(List<T> listaDeTarefas);
    //public abstract Tarefa CriarTarefa(StatusTarefaEnum statusTarefa, string titulo, string local);
    //public abstract void ModificarStatusDaTarefa(Tarefa tarefa);
}
