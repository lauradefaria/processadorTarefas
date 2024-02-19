using static ProcessadorTarefas.Entidades.Tarefa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessadorTarefas.Entidades
{
    public interface ITarefa
    {
        int Id { get; }
        EstadoTarefa Estado { get; }
        DateTime IniciadaEm { get; }
        DateTime EncerradaEm { get; }
        IEnumerable<Subtarefa> SubtarefasPendentes { get; }
        IEnumerable<Subtarefa> SubtarefasExecutadas { get; }
    }

    public class Tarefa : ITarefa
    {
        ﻿using Microsoft.Extensions.Configuration;

namespace ProcessadorTarefas.Entidades
    {
        public interface IEntidade
        {
            int Id { get; }
        }
        public interface ITarefa : IEntidade
        {
            EstadoTarefa Estado { get; }
            DateTime? IniciadaEm { get; }
            DateTime? EncerradaEm { get; }
            IEnumerable<Subtarefa> SubtarefasPendentes { get; }
            IEnumerable<Subtarefa> SubtarefasExecutadas { get; }
        }

        public class Tarefa : ITarefa
        {

            private static Random random = new Random();
            public int Id { get; set; }
            public EstadoTarefa Estado { get; private set; } = EstadoTarefa.Criada;
            public DateTime? IniciadaEm { get; set; }
            public DateTime? EncerradaEm { get; set; }
            public IEnumerable<Subtarefa> SubtarefasPendentes { get; set; } = new List<Subtarefa>();
            public IEnumerable<Subtarefa> SubtarefasExecutadas { get; set; } = new List<Subtarefa>();

            private Tarefa() { }

            public static Tarefa Criar(int id, IConfiguration? configs = null)
            {
                var novaTarefa = new Tarefa
                {
                    Id = id,
                    SubtarefasPendentes = CriarSubtarefas(configs),
                    SubtarefasExecutadas = new List<Subtarefa>()
                };

                return novaTarefa;
            }

            private static IEnumerable<Subtarefa> CriarSubtarefas(IConfiguration? configs)
            {
                var result = new List<Subtarefa>();

                var quantidadeSubtarefas = random.Next(int.Parse(configs?[Consts.MIN_SUBTASKS] ?? "1"), int.Parse(configs?[Consts.MAX_SUBTASKS] ?? "10")); ;

                for (int i = 0; i < quantidadeSubtarefas; i++)
                    result.Add(
                        new Subtarefa()
                        {
                            Duracao = TimeSpan.FromSeconds(random.Next(int.Parse(configs?[Consts.MIN_DURATION_SUBTASKS] ?? "1"), int.Parse(configs?[Consts.MAX_DURATION_SUBTASKS] ?? "10")))
                        });

                return result;
            }

            public void ConcluirSubtarefa(Subtarefa subtarefa)
            {
                SubtarefasPendentes = SubtarefasPendentes.Except(new[] { subtarefa });
                SubtarefasExecutadas = SubtarefasExecutadas.Append(subtarefa);
            }


            /*private static void CriarSubtarefas()
            {
                Random random = new Random();

                List<Subtarefa> subtarefas = new List<Subtarefa>();


                for (int i = 0; i < random.Next(10, Configuration.QuantidadeMaximaDeSubtarefas + 1); i++)
                {
                    Subtarefa subtarefa = new Subtarefa();
                    subtarefa.Duracao = TimeSpan.FromSeconds(random.Next(3, 60));
                    subtarefas.Add(subtarefa);
                }

                this.SubtarefasPendentes = subtarefas;
            }*/

            public void Iniciar()
        {
            if (Estado == EstadoTarefa.EmExecucao)
            {
                throw new InvalidOperationException($"Tarefa {Id} já está sendo executada.");
            }
            else if (PermitirExecutar())
            {
                Estado = EstadoTarefa.EmExecucao;
                if (IniciadaEm = null)
                {
                    IniciadaEm = DateTime.Now;
                }
            }
            else
            {
                throw new InvalidOperationException($"Não é possível iniciar a Tarefa {Id}.");
            }
        }

        public void ConcluirSubtarefa(Subtarefa subtarefa)
        {
            SubtarefasPendentes = SubtarefasPendentes.Except(new[] { subtarefa });
            SubtarefasExecutadas = SubtarefasExecutadas.Append(subtarefa);
        }

        public void Agendar()
        {
            if (Estado == EstadoTarefa.Agendada)
            {
                throw new InvalidOperationException($"Tarefa {Id}´já está agendada");
            }

            else if (Estado == EstadoTarefa.Criada)
            {
                Estado = EstadoTarefa.Agendada


        }
            else
            {
                throw new InvalidOperationException($"Não é possível agendar a Tarefa {Id}.");
            }

        }

        public void Cancelar()
        {
            if (Estado == EstadoTarefa.Cancelada)
            {
                throw new InvalidOperationException($"Tarefa {Id} já foi cancelada.");
            }
            else if (Estado == EstadoTarefa.Agendada || Estado == EstadoTarefa.EmExecucao || Estado == EstadoTarefa.Criada)
            {
                Estado = EstadoTarefa.Cancelada;
                EncerradaEm = DateTime.Now;
            }
            else
            {
                throw new InvalidOperationException($"Não foi possível cancelar a Tarefa {Id}.");
            }
        }

        public void Pausar()
        {
            if (Estado == EstadoTarefa.EmPausa)
            {
                throw new InvalidOperationException($"Tarefa {Id} já está em pausa.");
            }
            else if (Estado == EstadoTarefa.EmExecucao)
            {
                Estado = EstadoTarefa.EmPausa;
            }
            else
            {
                throw new InvalidOperationException($"Não foi possível pausar a Tarefa {Id}");
            }
        }

        public void Concluir()
        {
            if (Estado = EstadoTarefa.Concluída)
                throw new InvalidOperationException($"Tarefa {Id} já foi concluída.");

            else if (Estado == EstadoTarefa.EmExecucao)
            {
                if (SubtarefasPendentes.Count() > 0)
                {
                    throw new InvalidOperationException($"Tarefa {Id} possui subtarefas pendentes.");
                }

                Estado = EstadoTarefa.Concluida;
                EncerradaEm = DateTime.Now;
            }
        }

        public bool PermitirExecutar()
            => Estado = EstadoTarefa.Agendada || Estado = EstadoTarefa.EmPausa;
    }

}
