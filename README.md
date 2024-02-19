[![author](https://img.shields.io/badge/author-lauradefaria-blue.svg)](https://github.com/lauradefaria)
# Processador de Tarefas
O projeto tem como objetivo elaborar um sistema de processamento de tarefas. Nele, será possível criar, cancelar ou listar tarefas. O projeto tem como intuito aplicar os conceitos de POO e Técnicas de Programação em C#, no qual foram adquiridos durante os módulos 3 e 4 do curso DiverseDEV organizado pelas instituições: ADA Tech e Mercado Eletrônico. <br/>

---

## Tabela de conteúdos
- [Tarefas de Sistema](#tarefas-do-sistema)
- [Interface](#interface)
- [Dados](#dados)
- [Regras de Negocio](#regras-de-negocio)
- [Requisitos](#requisitos)
- [Clonar](#clonar)

---

## Tarefas do Sistema

As tarefas podem ser classificadas dos seguintes tipos: Tarefa em Atraso; Tarefa Concluída, Tarefa Abandonada, Tarefas com Impedimento, Tarefas em análise, Tarefas Aguardando Aprovação. <br/>
<pre>
  Descrição Tarefas Ativas:<br/>
  
  - Tarefa Em Execução: Tarefa que está sendo desenvolvida (se encontra dentro do seu limite de prazo). <br/>
  - Tarefa Em Pausa: Tarefa que não está sendo trabalhada no momento.<br/>

  Descrição Tarefas Desativadas:<br/>
  - Tarefa Criada: Tarefa que foi criada no sistema, mas não foi atribuida para agendamento ou cancelamento. <br/>
  - Tarefa Cancelada: Tarefa que foi iniciada, mas, por algum motivo, não foi concluída ou não está mais em andamento<br/>
  - Tarefas Agendada: Tarefas que foi atribuida uma data para iniciar. <br/>
  - Tarefa Concluída: Tarefa já foi finalizada pelo desenvolvedor. <br/>
</pre>

Para a ordem das tarefas, elas devem seguir a máquina de estados da figura abaixo:<br/>
<p align="center">
  <img src="https://github.com/lauradefaria/processadorTarefas/blob/main/imgs/MaquinaEstados.png" width="400"> <br/>
  Figura 1: Máquina de Estados das Tarefas     <br/>
</p>

---

## Interface

 A partir da interface, o usuário pode optar por: Iniciar (inicia a execução das tarefas), Cancelar (cancela alguma tarefa pelo seu ID), Listar Ativas (Lista as tarefas ativas e sua descrição básica), Listar Inativas (Lista as tarefas inativas e sua descrição básica), Parar Listagem de Tarefas (não listará mais as tarefas), Criar (cria uma tarefa nova aleatória), Consultar (consulta uma tarefa especícifa pelo seu ID) ou Encerrar (finaliza o programa e pausa as tarefas em execução para continuar quando retornar).

---

## Dados

As tarefas são criadas no início das configurações do programa. Além disso, os valores relacionados a `'quantidadeMinimaSubtasks'`, `'quantidadeMaximaSubtasks'`, `'duracaoMinimaSubtasks'`, `'duracaoMaximaSubtasks'`, `'quantidadeTarefasEmParalelo'` e `'quantidadeTarefasAgendadas'` podem ser alteradas no arquivo `settings.json` localizado no diretório **ConsoleUI**.

---

## Regras de Negocio

- [X] Criação, cancelamento e listaagem de tarefas ativas. <br/>
- [X] Listagem tarefas inativas. <br/>
- [X] Processamento de uma quantidade determinada de tarefas deve ocorrer em segundo plano.<br/>
- [X] Ao ser criada, a tarefa deve atribuir a si mesma um número aleatório de sub-tarefas entre 10 e 100.<br/>
- [X] O processamento de cada sub-tarefa deve levar entre 3 e 60 (gerar tempo aleatório ao criar).<br/>
- [X] Caso o sistema seja interrompido e o armazenamento for persistente, o sistema deve ser capaz de continuar a execução das tarefas de onde parou.<br/>
- [X] O armazenamento em memória deve conter estaticamente uma lista de 100 tarefas para ser trabalhada a cada execução.<br/>

## Requisitos

**OBRIGATÓRIOS**
- [X] Injeção de dependência para repositórios e possíveis serviços.<br/>
- [X] Execução de tarefas deve ser assíncrona.<br/>
- [X] A implementação do repositório deve usar Generics.<br/>
- [X] Implementar a máquina de estado.<br/>
- [X] Permitir configurar: Quantidade de tarefas que podem ser executadas por vez.<br/>
- [X] Permitir configurar: Quantidade máxima de sub-tarefas que cada tarefa pode receber.<br/>

**BÔNUS**
- [X] Implementar padrão de projeto State.<br/>
- [ ] Mostrar progresso das tarefas no console.<br/>


---

## Clonar

- Clone esse repositório na sua máquila local utilizando
    > https://github.com/lauradefaria/processadorTarefas.git
