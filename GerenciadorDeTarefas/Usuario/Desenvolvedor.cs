﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarefas;

namespace Usuarios;

public class Desenvolvedor : Usuario
{
    public Desenvolvedor(string nome) : base(nome)
    {
    }
    public Desenvolvedor(int idUsuario, string nome) : base(idUsuario, nome)
    {
    }

    //public override void VisualizarTarefas<T>(List<T> listaDeTarefas);
    //public override void VisualizarEstatisticas<T>(List<T> listaDeTarefas);
    //public override Tarefa CriarTarefa(StatusTarefaEnum statusTarefa, string titulo, string local);
    //public override void ModificarStatusDaTarefa(Tarefa tarefa);
}
