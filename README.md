# Todo API

o projeto está dividido em 4 projetos, Api, Infra, Domain e testes.

o projeto a ser iniciado é o Todo.Domain.API, no program.cs existe na linha 13 a dependencia do repositório em memoria,
se desejar verificar o projeto a rodar com a persistencia no SQL server, existe algums passos que são necessários fazer.

1. Comentar a linha 13 e descomentar a linha 14 e 15;
2. rodar o docker-compose que está na raiz da solution, é necessário ter o docker instalado;
3. rodar as migrations, que encontram-se no projeto de Todo.Domain.Infra executando a linha abaixo
    > dotnet ef database update --startup-project ..\Todo.Domain.API\

## O texto é o descritivo do projeto que me foi passado

### TESTE PARA BACKEND TEST

A paySimplex precisa implementar uma API REST para gestão de tarefas. Cada tarefa tem data

de início, duração estimada, e diferentes estados para indicar se a tarefa se encontra

agendada, em andamento ou finalizada. A tarefa precisa ser atribuída a uma pessoa e ter uma

data de finalização.

Os seguintes métodos têm de ser implementados:

1\. Criar uma tarefa associada ao user João Silva agendada para o dia 31/12/2021.

2\. Criar uma tarefa associada à Ana Silva com data atual.

3\. Atualizar o estado da tarefa da Ana Silva para Em Andamento.

4\. Retornar o período de tempo em que a tarefa esteve em Andamento.

5\. Finalizar uma tarefa.

6\. Iniciar uma tarefa que estava com estado Agendada.

7\. Anexar um ficheiro à uma tarefa

Requisitos obrigatórios:

1\. A API tem de ser em .NET Core e usar Entity Framework Core com Code First.

2\. Utilizar GitHub

3\. Utilizar Swagger

4\. C#

Requisitos diferenciais (Será melhor avaliado se os cumprir)

1\. Criar um app Service no Azure para a API.

2\. Criar uma Azure Function para algum dos métodos

3\. Usar Blob Storage para guardar ficheiros das tarefas

Avaliação:

1\. Iremos avaliar a organização do código, tal como as definições das classes e

relacionamentos.

2\. As boas práticas em Orientação a Objetos e Entity Framework.

3\. As boas práticas no uso de API REST

4\. Pensamento lógico

5\. Conhecimentos de Azure.
