using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProcessadorTarefas.Entidades;
using ProcessadorTarefas.Repositorios;
using ProcessadorTarefas.Servicos;
using Repositorio;

namespace ConsoleUI
{
    internal partial class Program
    {
        private enum Visualizacao
        {
            NaoDefinida = 0,
            TarefasAtivas = 1,
            TarefasInativas = 2
        }

        static async Task Main(string[] args)
        {
            var visaoAtual = Visualizacao.NaoDefinida;
            bool flag = true;

            var serviceProvider = ConfigureServiceProvider();

            var processador = serviceProvider.GetService<IProcessadorTarefas>();
            var gerenciador = serviceProvider.GetService<IGerenciadorTarefas>();

            while (flag)
            {
                Console.Clear();
                Menus.ImprimirMenu();

                if (Console.KeyAvailable)
                {
                    try
                    {
                        var option = Console.ReadKey(intercept: true).KeyChar;
                        Console.WriteLine();
                        switch (option)
                        {
                            case '1':  //INICIAR
                                await processador.Iniciar();
                                break; 
                            case '2':  //CANCELAR
                                var tarefasAtivas = await gerenciador.ListarAtivas();
                                await processador.CancelarTarefa(VerificarCancelar(tarefasAtivas));
                                break;
                            case '3':  //LISTAR ATIVAS
                                visaoAtual = Visualizacao.TarefasAtivas;
                                break;
                            case '4':  //LISTAR INATIVAS
                                visaoAtual = Visualizacao.TarefasInativas;
                                break;
                            case '5':  //PARAR LISTAR TAREFAS
                                visaoAtual = Visualizacao.NaoDefinida;
                                break;
                            case '6':  //CRIAR
                                await gerenciador.Criar();
                                Console.WriteLine("Nova tarefa criada");
                                await Task.Delay(1000);
                                break;
                            case '7':  //CONSULTAR
                                var tarefasAtivas = await gerenciador.ListarAtivas();
                                var tarefasInativas = await gerenciador.ListarInativas();
                                await gerenciador.Consultar(VerificarConsultar(tarefasAtivas, tarefasInativas));
                                await Task.Delay(5000);
                                break;
                            case '8':  //ENCERRAR
                                Console.WriteLine("Encerrando...");
                                await processador.Encerrar();
                                Console.WriteLine("Tarefas encerradas.");
                                flag = false;
                                await Task.Delay(1000);
                                break;
                            default:
                                break;
                        }
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine($"Erro: {ex.Message}");
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadKey(intercept: true);
                    }
                }

                switch (visaoAtual)
                {
                    case Visualizacao.TarefasAtivas:
                        var tarefasAtivas = await gerenciador.ListarAtivas();
                        Menus.ImprimirTarefas(tarefasAtivas);
                        break;
                    case Visualizacao.TarefasInativas:
                        var tarefasInativas = await gerenciador.ListarInativas();
                        Menus.ImprimirTarefas(tarefasInativas);
                        break;
                    default:
                        break;
                }

                Console.WriteLine();
                Console.WriteLine();

                await Task.Delay(100);
            }
        }

        private static IServiceProvider ConfigureServiceProvider()
        {
            //string connectionString = "Data Source=database.db";

            IConfiguration configuration = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("settings.json", optional: true, reloadOnChange: true)
                            .Build();

            IServiceCollection services = new ServiceCollection();
            services.AddScoped(_ => configuration);
            services.AddScoped<IRepository<Tarefa>, MemoryRepository>();
            //services.AddScoped<IRepository<Tarefa>>(_ => new SqliteRepository<Tarefa>(connectionString) );
            services.AddSingleton<IProcessadorTarefas, Processador>();
            services.AddScoped<IGerenciadorTarefas, Gerenciador>(serviceProvider =>
            {
                var repository = serviceProvider.GetService<IRepository<Tarefa>>();
                return new Gerenciador(serviceProvider, repository, configuration);
            });

            return services.BuildServiceProvider(); ;
        }

        private int VerificarCancelar(List<Tarefa> tarefas)
        {
            int idTarefa;

            do
            {
                Console.Clear();
                Console.WriteLine("TAREFAS ATIVAS");

                foreach (Tarefa tarefa in tarefas)
                {
                    Console.WriteLine($"Tarefa {tarefa.ID}.");
                }

                Console.WriteLine($"\n\nDigite o ID da tarefa que deseja cancelar: ");
            } while (!int.TryParse(Console.ReadLine(), out idTarefa))

            return idTarefa;
        }

        private int VerificarConsultar(List<Tarefa> tarefasAtv, List<Tarefa> tarefasIna)
        {
            int idTarefa;

            do
            {
                Console.Clear();
                Console.WriteLine("TAREFAS ATIVAS");

                foreach (Tarefa tarefa in tarefasAtv)
                {
                    Console.WriteLine($"Tarefa {tarefa.ID}.");
                }

                Console.WriteLine("\nTAREFAS INATIVAS");

                foreach (Tarefa tarefa in tarefasIna)
                {
                    Console.WriteLine($"Tarefa {tarefa.ID}.");
                }

                Console.WriteLine($"\nDigite o ID da tarefa que deseja consultar: ");
            } while (!int.TryParse(Console.ReadLine(), out idTarefa))

            return idTarefa;
        }
    }
}
