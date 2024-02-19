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
- [Autor](#autor)

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

 EM DESENVOLVIMENTO

---

## Dados

EM DESENVOLVIMENTO

---

## Regras de Negocio

- [ ] Criação, cancelamento e listaagem de tarefas ativas. <br/>
- [ ] Listagem tarefas inativas. <br/>
- [ ] Processamento de uma quantidade determinada de tarefas deve ocorrer em segundo plano.<br/>
- [ ] Ao ser criada, a tarefa deve atribuir a si mesma um número aleatório de sub-tarefas entre 10 e 100.<br/>
- [ ] O processamento de cada sub-tarefa deve levar entre 3 e 60 (gerar tempo aleatório ao criar).<br/>
- [ ] Caso o sistema seja interrompido e o armazenamento for persistente, o sistema deve ser capaz de continuar a execução das tarefas de onde parou.<br/>
- [ ] O armazenamento em memória deve conter estaticamente uma lista de 100 tarefas para ser trabalhada a cada execução.<br/>

## Requisitos

**OBRIGATÓRIOS**
- [ ] Injeção de dependência para repositórios e possíveis serviços.<br/>
- [ ] Execução de tarefas deve ser assíncrona.<br/>
- [ ] A implementação do repositório deve usar Generics.<br/>
- [ ] Implementar a máquina de estado.<br/>
- [ ] Permitir configurar: Quantidade de tarefas que podem ser executadas por vez.<br/>
- [ ] Permitir configurar: Quantidade máxima de sub-tarefas que cada tarefa pode receber.<br/>
- [ ] Permitir configurar: O tipo de armazenamento que será utilizado pela aplicação (em memória, sqlite ou sql server).<br/>

**BÔNUS**
- [ ] Implementar padrão de projeto State.<br/>
- [ ] Mostrar progresso das tarefas no console.<br/>
- [ ] Permitir interagir com sistema tanto pela API quanto pelo console simultâneamente.<br/>


---

## Clonar

- Clone esse repositório na sua máquila local utilizando
    > https://github.com/lauradefaria/GerenciadorTarefas.git

---
## Autor
|<a href="https://www.linkedin.com/in/lauradefaria/" target="_blank">**Laura de Faria**</a> | 
|:-----------------------------------------------------------------------------------------:|
|                   <img src="imgs/laura.png" width="200px"> </img>                            |
|               <a href="http://github.com/lauradefaria" target="_blank">`github.com/lauradefaria`</a>      |
