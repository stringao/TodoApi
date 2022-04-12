using System;
using System.Collections.Generic;
using Todo.Domain.Entities;
using Todo.Domain.Repositories;

namespace Todo.Domain.Tests.Repositories;

public class FakeTodoRepository : ITodoRepository
{
    public void Create(TodoItem todo)
    {
    }

    public IEnumerable<TodoItem> GetAll(string user)
    {
        return new List<TodoItem>();
    }

    public IEnumerable<TodoItem> GetAllDone(string user)
    {
        return new List<TodoItem>();
    }

    public IEnumerable<TodoItem> GetAllUndone(string user)
    {
        return new List<TodoItem>();
    }

    public TodoItem GetById(Guid id, string user)
    {
        return new TodoItem("Titulo Valido", "Usuário Valido", DateTime.Now);
    }

    public IEnumerable<TodoItem> GetByPeriod(string user, DateTime date, StateTodo stateTodo)
    {
        return new List<TodoItem>();
    }

    public void Update(TodoItem todo)
    {
    }
}
