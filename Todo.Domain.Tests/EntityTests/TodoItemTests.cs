using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Todo.Domain.Entities;

namespace Todo.Domain.Tests.EntityTests;

[TestClass]
public class TodoItemTests
{
    private readonly TodoItem _validTodo = new TodoItem("Titulo Tarefa", "Usuário Válido", DateTime.Now);

    [TestMethod]
    public void DadoUmNovoTodo_NaoPodeEstarFinalizada()
    {
        Assert.AreNotEqual(_validTodo.StateTodo, StateTodo.Finalizada);
    }

    [TestMethod]
    public void DadoUmNovoTodo_DeveEstarAgendada()
    {
        Assert.AreEqual(_validTodo.StateTodo, StateTodo.Agendada);
    }

    [TestMethod]
    public void DadoUmNovoTodo_IniciarTarefa_DeveEstarAgendada()
    {
        _validTodo.StartTodo();
        Assert.AreEqual(_validTodo.StateTodo, StateTodo.EmAndamento);
    }

}
