using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ProcessadorTarefas.Entidades;
using ProcessadorTarefas.Repositorios;
using ProcessadorTarefas.Servicos;

namespace ProcessadorTarefas.Repositorios
{
    public class Memoria : IRepository<Tarefa>
    {
        ﻿using Microsoft.Extensions.Configuration;
using ProcessadorTarefas.Entidades;
using ProcessadorTarefas.Repositorios;

namespace Repositorio
{
    public class MemoryRepository : IRepository<Tarefa>
    {
        private List<Tarefa> InicializarDatabase()
        {
            const int NumeroTarefas = 100;

            var result = new List<Tarefa>();

            for (int i = 0; i < NumeroTarefas; i++)
                result.Add(Tarefa.Criar(i + 1, _configs));

            return result;
        }

        private static List<Tarefa>? _staticDb;
        private readonly IConfiguration _configs;

        private List<Tarefa> _db
        {
            get
            {
                if (_staticDb == null)
                    _staticDb = InicializarDatabase();

                return _staticDb;
            }

            set
            {
                _staticDb = value;
            }
        }
        public MemoryRepository(IConfiguration configuration)
        {
            _configs = configuration;
        }

        public void Add(Tarefa entity)
        {
            _db.Add(entity);
        }

        public void Delete(int id)
        {
            _db.Remove(GetById(id)!);
        }

        public IEnumerable<Tarefa> GetAll()
        {
            return _db;
        }

        public Tarefa? GetById(int id)
        {
            return _db.FirstOrDefault(t => t.Id == id);
        }          

        public void Update(Tarefa tarefa)
        {
            var tarefaExistente = GetById(tarefa.Id);

            if (tarefaExistente != null)
            {
                tarefaExistente.Id = tarefa.Id;
                tarefaExistente.Estado = tarefa.Estado;
                tarefaExistente.IniciadaEm = tarefa.IniciadaEm;
                tarefaExistente.EncerradaEm = tarefa.EncerradaEm;
                tarefaExistente.SubtarefasPendentes = tarefa.SubtarefasPendentes;
                tarefaExistente.SubtarefasExecutadas = tarefa.SubtarefasExecutadas;
            }
            else
            {
                throw new InvalidOperationException("Tarefa não encontrada.");
            }
        }

        /*private List<Tarefa> TarefasExistentes()
        {
            return new List<Tarefa>
            {
            new Tarefa { Id = 1, Estado = EstadoTarefa.Concluida, IniciadaEm = DateTime.MinValue, EncerradaEm = DateTime.MinValue, SubtarefasPendentes = new List<Subtarefa> { new Subtarefa { Duracao = TimeSpan.FromSeconds(17) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(58) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(19) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(4) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(29) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(32) } }, SubtarefasExecutadas = new List<Subtarefa>() }
            new Tarefa { Id = 2, Estado = EstadoTarefa.Agendada, IniciadaEm = new DateTime(2024, 2, 4, 13, 16, 21), EncerradaEm = new DateTime(2024, 2, 4, 13, 16, 21), SubtarefasPendentes = new List<Subtarefa> { new Subtarefa { Duracao = TimeSpan.FromSeconds(15) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(26) } }, SubtarefasExecutadas = new List<Subtarefa>() },
            new Tarefa { Id = 3, Estado = EstadoTarefa.EmPausa, IniciadaEm = DateTime.MinValue, EncerradaEm = DateTime.MinValue, SubtarefasPendentes = new List<Subtarefa> { new Subtarefa { Duracao = TimeSpan.FromSeconds(47) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(47) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(19) } }, SubtarefasExecutadas = new List<Subtarefa>() },
            new Tarefa { Id = 4, Estado = EstadoTarefa.Cancelada, IniciadaEm = DateTime.MinValue, EncerradaEm = DateTime.MinValue, SubtarefasPendentes = new List<Subtarefa> { new Subtarefa { Duracao = TimeSpan.FromSeconds(23) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(46) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(46) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(23) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(25) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(57) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(59) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(16) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(7) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(24) } }, SubtarefasExecutadas = new List<Subtarefa>() },
            new Tarefa { Id = 5, Estado = EstadoTarefa.EmPausa, IniciadaEm = DateTime.MinValue, EncerradaEm = DateTime.MinValue, SubtarefasPendentes = new List<Subtarefa> { new Subtarefa { Duracao = TimeSpan.FromSeconds(47) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(36) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(56) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(4) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(60) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(31) } }, SubtarefasExecutadas = new List<Subtarefa>() },
            new Tarefa { Id = 6, Estado = EstadoTarefa.Agendada, IniciadaEm = new DateTime(2024, 2, 4, 13, 16, 21), EncerradaEm = new DateTime(2024, 2, 4, 13, 16, 21), SubtarefasPendentes = new List<Subtarefa> { new Subtarefa { Duracao = TimeSpan.FromSeconds(26) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(46) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(29) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(52) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(53) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(30) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(45) } }, SubtarefasExecutadas = new List<Subtarefa>() },
            new Tarefa { Id = 7, Estado = EstadoTarefa.Concluida, IniciadaEm = DateTime.MinValue, EncerradaEm = DateTime.MinValue, SubtarefasPendentes = new List<Subtarefa> { new Subtarefa { Duracao = TimeSpan.FromSeconds(44) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(19) } }, SubtarefasExecutadas = new List<Subtarefa>() },
            new Tarefa { Id = 8, Estado = EstadoTarefa.Cancelada, IniciadaEm = DateTime.MinValue, EncerradaEm = DateTime.MinValue, SubtarefasPendentes = new List<Subtarefa> { new Subtarefa { Duracao = TimeSpan.FromSeconds(50) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(49) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(54) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(41) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(22) } }, SubtarefasExecutadas = new List<Subtarefa>() },
            new Tarefa { Id = 9, Estado = EstadoTarefa.Cancelada, IniciadaEm = DateTime.MinValue, EncerradaEm = DateTime.MinValue, SubtarefasPendentes = new List<Subtarefa> { new Subtarefa { Duracao = TimeSpan.FromSeconds(29) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(20) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(15) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(18) } }, SubtarefasExecutadas = new List<Subtarefa>() },
            new Tarefa { Id = 10, Estado = EstadoTarefa.Agendada, IniciadaEm = new DateTime(2024, 2, 4, 13, 16, 21), EncerradaEm = new DateTime(2024, 2, 4, 13, 16, 21), SubtarefasPendentes = new List<Subtarefa> { new Subtarefa { Duracao = TimeSpan.FromSeconds(9) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(47) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(19) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(53) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(25) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(26) } }, SubtarefasExecutadas = new List<Subtarefa>() },
            new Tarefa { Id = 11, Estado = EstadoTarefa.Agendada, IniciadaEm = new DateTime(2024, 2, 4, 13, 16, 21), EncerradaEm = new DateTime(2024, 2, 4, 13, 16, 21), SubtarefasPendentes = new List<Subtarefa> { new Subtarefa { Duracao = TimeSpan.FromSeconds(36) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(32) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(25) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(11) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(8) } }, SubtarefasExecutadas = new List<Subtarefa>() },
            new Tarefa { Id = 12, Estado = EstadoTarefa.Agendada, IniciadaEm = new DateTime(2024, 2, 4, 13, 16, 21), EncerradaEm = new DateTime(2024, 2, 4, 13, 16, 21), SubtarefasPendentes = new List<Subtarefa> { new Subtarefa { Duracao = TimeSpan.FromSeconds(35) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(30) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(32) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(23) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(29) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(22) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(47) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(11) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(33) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(30) } }, SubtarefasExecutadas = new List<Subtarefa>() },
            new Tarefa { Id = 13, Estado = EstadoTarefa.Criada, IniciadaEm = DateTime.MinValue, EncerradaEm = DateTime.MinValue, SubtarefasPendentes = new List<Subtarefa> { new Subtarefa { Duracao = TimeSpan.FromSeconds(6) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(40) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(43) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(41) } }, SubtarefasExecutadas = new List<Subtarefa>() },
            new Tarefa { Id = 14, Estado = EstadoTarefa.Agendada, IniciadaEm = DateTime.MinValue, EncerradaEm = DateTime.MinValue, SubtarefasPendentes = new List<Subtarefa> { new Subtarefa { Duracao = TimeSpan.FromSeconds(60) } }, SubtarefasExecutadas = new List<Subtarefa>() },
            new Tarefa { Id = 15, Estado = EstadoTarefa.Agendada, IniciadaEm = DateTime.MinValue, EncerradaEm = DateTime.MinValue, SubtarefasPendentes = new List<Subtarefa> { new Subtarefa { Duracao = TimeSpan.FromSeconds(39) } }, SubtarefasExecutadas = new List<Subtarefa>() },
            new Tarefa { Id = 16, Estado = EstadoTarefa.Concluida, IniciadaEm = DateTime.MinValue, EncerradaEm = DateTime.MinValue, SubtarefasPendentes = new List<Subtarefa> { new Subtarefa { Duracao = TimeSpan.FromSeconds(7) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(37) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(30) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(58) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(42) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(37) } }, SubtarefasExecutadas = new List<Subtarefa>() },
            new Tarefa { Id = 17, Estado = EstadoTarefa.Criada, IniciadaEm = DateTime.MinValue, EncerradaEm = DateTime.MinValue, SubtarefasPendentes = new List<Subtarefa> { new Subtarefa { Duracao = TimeSpan.FromSeconds(27) } }, SubtarefasExecutadas = new List<Subtarefa>() },
            new Tarefa { Id = 18, Estado = EstadoTarefa.Agendada, IniciadaEm = DateTime.MinValue, EncerradaEm = DateTime.MinValue, SubtarefasPendentes = new List<Subtarefa> { new Subtarefa { Duracao = TimeSpan.FromSeconds(25) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(40) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(55) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(38) } }, SubtarefasExecutadas = new List<Subtarefa>() },
            new Tarefa { Id = 19, Estado = EstadoTarefa.Criada, IniciadaEm = DateTime.MinValue, EncerradaEm = DateTime.MinValue, SubtarefasPendentes = new List<Subtarefa> { new Subtarefa { Duracao = TimeSpan.FromSeconds(33) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(6) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(36) } }, SubtarefasExecutadas = new List<Subtarefa>() },
            new Tarefa { Id = 20, Estado = EstadoTarefa.EmPausa, IniciadaEm = DateTime.MinValue, EncerradaEm = DateTime.MinValue, SubtarefasPendentes = new List<Subtarefa> { new Subtarefa { Duracao = TimeSpan.FromSeconds(7) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(32) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(59) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(52) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(44) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(20) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(12) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(49) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(3) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(53) } }, SubtarefasExecutadas = new List<Subtarefa>() },
            new Tarefa { Id = 21, Estado = EstadoTarefa.Agendada, IniciadaEm = new DateTime(2024, 2, 4, 13, 16, 21), EncerradaEm = new DateTime(2024, 2, 4, 13, 16, 21), SubtarefasPendentes = new List<Subtarefa> { new Subtarefa { Duracao = TimeSpan.FromSeconds(43) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(51) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(39) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(38) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(54) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(39) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(59) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(27) } }, SubtarefasExecutadas = new List<Subtarefa>() },
            new Tarefa { Id = 22, Estado = EstadoTarefa.Cancelada, IniciadaEm = DateTime.MinValue, EncerradaEm = DateTime.MinValue, SubtarefasPendentes = new List<Subtarefa> { new Subtarefa { Duracao = TimeSpan.FromSeconds(5) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(35) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(25) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(45) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(30) } }, SubtarefasExecutadas = new List<Subtarefa>() },
            new Tarefa { Id = 23, Estado = EstadoTarefa.Agendada, IniciadaEm = DateTime.MinValue, EncerradaEm = DateTime.MinValue, SubtarefasPendentes = new List<Subtarefa> { new Subtarefa { Duracao = TimeSpan.FromSeconds(51) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(12) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(20) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(54) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(27) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(3) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(13) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(20) } }, SubtarefasExecutadas = new List<Subtarefa>() },
            new Tarefa { Id = 24, Estado = EstadoTarefa.Agendada, IniciadaEm = new DateTime(2024, 2, 4, 13, 16, 21), EncerradaEm = new DateTime(2024, 2, 4, 13, 16, 21), SubtarefasPendentes = new List<Subtarefa> { new Subtarefa { Duracao = TimeSpan.FromSeconds(27) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(23) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(51) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(22) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(52) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(16) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(17) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(39) } }, SubtarefasExecutadas = new List<Subtarefa>() },
            new Tarefa { Id = 25, Estado = EstadoTarefa.EmPausa, IniciadaEm = DateTime.MinValue, EncerradaEm = DateTime.MinValue, SubtarefasPendentes = new List<Subtarefa> { new Subtarefa { Duracao = TimeSpan.FromSeconds(59) } }, SubtarefasExecutadas = new List<Subtarefa>() },
            new Tarefa { Id = 26, Estado = EstadoTarefa.Agendada, IniciadaEm = new DateTime(2024, 2, 4, 13, 16, 21), EncerradaEm = new DateTime(2024, 2, 4, 13, 16, 21), SubtarefasPendentes = new List<Subtarefa> { new Subtarefa { Duracao = TimeSpan.FromSeconds(19) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(23) } }, SubtarefasExecutadas = new List<Subtarefa>() },
            new Tarefa { Id = 27, Estado = EstadoTarefa.Concluida, IniciadaEm = DateTime.MinValue, EncerradaEm = DateTime.MinValue, SubtarefasPendentes = new List<Subtarefa> { new Subtarefa { Duracao = TimeSpan.FromSeconds(59) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(16) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(25) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(12) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(8) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(10) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(58) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(4) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(52) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(5) } }, SubtarefasExecutadas = new List<Subtarefa>() },
            new Tarefa { Id = 28, Estado = EstadoTarefa.EmPausa, IniciadaEm = DateTime.MinValue, EncerradaEm = DateTime.MinValue, SubtarefasPendentes = new List<Subtarefa> { new Subtarefa { Duracao = TimeSpan.FromSeconds(50) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(22) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(45) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(31) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(32) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(30) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(39) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(10) } }, SubtarefasExecutadas = new List<Subtarefa>() },
            new Tarefa { Id = 29, Estado = EstadoTarefa.Concluida, IniciadaEm = DateTime.MinValue, EncerradaEm = DateTime.MinValue, SubtarefasPendentes = new List<Subtarefa> { new Subtarefa { Duracao = TimeSpan.FromSeconds(50) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(27) } }, SubtarefasExecutadas = new List<Subtarefa>() },
            new Tarefa { Id = 30, Estado = EstadoTarefa.EmPausa, IniciadaEm = DateTime.MinValue, EncerradaEm = DateTime.MinValue, SubtarefasPendentes = new List<Subtarefa> { new Subtarefa { Duracao = TimeSpan.FromSeconds(47) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(47) }, new Subtarefa { Duracao = TimeSpan.FromSeconds(19) } }, SubtarefasExecutadas = new List<Subtarefa>() }
            };
        }*/
    }
}