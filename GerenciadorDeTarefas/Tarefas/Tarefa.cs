namespace Tarefas;

public class Tarefa
{
    private static int s_contadorTarefas = 0;
    public int IdTarefa { get; set; }
    public int IdCriador { get; set; }
    public StatusTarefaEnum StatusTarefa { get; set; }
    public List<int> IdResponsaveis { get; set; }
    public DateTime? DataInicio { get; set; }
    public DateTime? DataLimite { get; set; }
    public string Titulo { get; set; }
    public string? Descricao { get; set; }
    public string Local { get; set; }

    public Tarefa(int idCriador, StatusTarefaEnum statusTarefa, List<int> idResponsaveis, string titulo, string local)
    {
        IdTarefa = ++s_contadorTarefas;
        IdCriador = idCriador;
        StatusTarefa = statusTarefa;
        IdResponsaveis = idResponsaveis;
        Titulo = titulo;
        Local = local;
        IdResponsaveis = new List<int>();
    }

    public Tarefa(int idTarefa, int idCriador, StatusTarefaEnum statusTarefa, List<int> idResponsaveis, DateTime dataInicio, DateTime dataLimite, string titulo, string descricao, string local)
    {
        s_contadorTarefas++;
        IdTarefa = idTarefa;
        IdCriador = idCriador;
        StatusTarefa = statusTarefa;
        IdResponsaveis = idResponsaveis;
        DataInicio = dataInicio;
        DataLimite = dataLimite;
        Titulo = titulo;
        Descricao = descricao;
        Local = local;
    }

    public bool AlocarResponsaveis(List<int> idResponsaveis)
    {
        try
        {
            IdResponsaveis.AddRange(idResponsaveis);
            Console.WriteLine("Responsáveis adicionados com sucesso!");
            return true;
        }
        catch
        {
            Console.WriteLine("Erro ao adicionar responsáveis pela tarefa.");
            return false;
        }
    }

    public bool DefinirDataInicio(DateTime dataInicio)
    {
        try
        {
            DataInicio = dataInicio;
            Console.WriteLine($"Início da tarefa definido para: {dataInicio.ToString()}.");
            return true;
        }
        catch
        {
            Console.WriteLine("Erro ao definir a data de início da tarefa.");
            return false;
        }
    }

    public bool DefinirDataLimite(DateTime dataLimite)
    {
        try
        {
            DataLimite = dataLimite;
            Console.WriteLine($"Limite da tarefa definido para: {dataLimite.ToString()}.");
            return true;
        }
        catch
        {
            Console.WriteLine("Erro ao definir a data de limite da tarefa.");
            return false;
        }
    }

    public bool AdicionarDescricao(string descricao)
    {
        try
        {
            Descricao = descricao;
            Console.WriteLine("Descrição da tarefa adicionada com sucesso!");
            return true;
        }
        catch
        {
            Console.WriteLine("Erro ao adicionar a descrição da tarefa.");
            return false;
        }
    }
}
