using ConsoleUI;
using ProcessadorTarefas.Entidades;
using ProcessadorTarefas.Servicos;
using System.Text;

public static class Menus
{

    public static void ImprimirMenu()
    {
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("+            GERENCIAR TAREFAS             +");
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("+           Escolha uma opção:             +");
        Console.WriteLine("+      1 - Iniciar tarefas                 +");
        Console.WriteLine("+      2 - Cancelar tarefa                 +");
        Console.WriteLine("+      3 - Listar tarafas ativas           +");
        Console.WriteLine("+      4 - Listar tarefas inativas         +");
        Console.WriteLine("+      5 - Parar listagem de tarefas       +");
        Console.WriteLine("+      6 - Criar tarefa                    +");
        Console.WriteLine("+      7 - Consultar tarefa                +");
        Console.WriteLine("+      8 - Encerrar                        +");
        Console.WriteLine("--------------------------------------------");
    }
    
    public static void ImprimirTarefas(IEnumerable<Tarefa> tarefas)
    {
        var sb = new StringBuilder();
        sb.AppendLine(
            string.Join('|',
                "DESCRICÃO".PadRight(12, ' '),
                "ESTADO".PadRight(15, ' '),
                "INÍCIO".PadRight(30, ' '),
                "TÉRMINO".PadRight(30, ' '),
                "SUBTAREFAS".PadRight(10, ' '),
                "TEMPO TOTAL".PadRight(10, ' ')
                )
        );
        foreach (var tarefa in tarefas)
            if (tarefa != null)
            {
                sb.AppendLine($"{string.Join(
                        $"{Extensions.CodigoResetCor}|{Extensions.CodigoCor[tarefa.Estado]}",
                        $"{Extensions.CodigoCor[tarefa.Estado]} Tarefa {tarefa.Id}".PadRight(17, ' '),
                        $"{tarefa.Estado}".PadRight(15, ' '),
                        $"{tarefa.IniciadaEm}".PadRight(30, ' '),
                        $"{tarefa.EncerradaEm}".PadRight(30, ' '),
                        $"{tarefa.SubtarefasExecutadas.Count() + tarefa.SubtarefasPendentes.Count()}".PadRight(10, ' '),
                        $"{tarefa.SubtarefasExecutadas.Union(tarefa.SubtarefasPendentes).Sum(x => x.Duracao.TotalSeconds)}".PadRight(10, ' ')
                    )}{Extensions.CodigoResetCor}");
            }

        Console.WriteLine(sb.ToString());
    }
}