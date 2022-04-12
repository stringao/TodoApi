using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Tests.QueryTests;

[TestClass]
public class TodoQueryTests
{

    private List<TodoItem> _items;

    public TodoQueryTests()
    {
        _items = new List<TodoItem>();
        _items.Add(new TodoItem("Tarefa 01", "usuarioA", DateTime.Now));
        _items.Add(new TodoItem("Tarefa 02", "usuarioA", DateTime.Now));
        _items.Add(new TodoItem("Tarefa 03", "JoaoTester", DateTime.Now));
        _items.Add(new TodoItem("Tarefa 04", "usuarioA", DateTime.Now));
        _items.Add(new TodoItem("Tarefa 05", "JoaoTester", DateTime.Now));
    }

    [TestMethod]
    public void DadaConsulta_DeveRetornarTarefas_ApenasDoUsuarioJoaoTester() 
    {
        var result = _items.AsQueryable().Where(TodoQueries.GetAll("JoaoTester"));
        Assert.AreEqual(2, result.Count());
    }

}
