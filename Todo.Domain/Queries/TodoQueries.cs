using System.Linq.Expressions;
using Todo.Domain.Entities;

namespace Todo.Domain.Queries;

public static class TodoQueries
{
    public static Expression<Func<TodoItem, bool>> GetById(Guid id, string user) 
    {
        return x => x.Id == id && x.User == user;
    }

    public static Expression<Func<TodoItem, bool>> GetAll(string user)
    {
        return x => x.User == user;
    }

    public static Expression<Func<TodoItem, bool>> GetAllDone(string user)
    {
        return x => x.User == user && x.StateTodo == StateTodo.Finalizada;
    }
    public static Expression<Func<TodoItem, bool>> GetAllUndone(string user)
    {
        return x => x.User == user && x.StateTodo != StateTodo.Finalizada;
    }

    public static Expression<Func<TodoItem, bool>> GetByPeriod(string user, DateTime date, StateTodo stateTodo)
    {
        return x =>
                        x.User == user &&
                        x.StateTodo == stateTodo &&
                        x.BeginDate == date.Date
        ;
    }
}
