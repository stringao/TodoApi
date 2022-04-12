using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Repositories;

namespace Todo.Domain.API.Controllers;

[ApiController]
[Route("v1/todos")]
public class TodoController : ControllerBase
{
    [Route("{user}")]
    [HttpGet]
    public IEnumerable<TodoItem> GetAll(
        string user,
        [FromServices] ITodoRepository repository)
    {
        return repository.GetAll(user);
    }

    [Route("{user}/done")]
    [HttpGet]
    public IEnumerable<TodoItem> GetAllDone(
        string user,
        [FromServices] ITodoRepository repository)
    {
        return repository.GetAllDone(user);
    }


    [Route("{user}/undone")]
    [HttpGet]
    public IEnumerable<TodoItem> GetAllUndone(
        string user,
        [FromServices] ITodoRepository repository)
    {
        return repository.GetAllUndone(user);
    }

    [Route("{user}/done/today")]
    [HttpGet]
    public IEnumerable<TodoItem> GetDoneForToday(
       string user,
       [FromServices] ITodoRepository repository)
    {
        var today = DateTime.Now.Date;
        var done = StateTodo.EmAndamento;
        return repository.GetByPeriod(user, today, done);
    }

    [Route("{user}/started/today")]
    [HttpGet]
    public IEnumerable<TodoItem> GetStartedForToday(
       string user,
       [FromServices] ITodoRepository repository)
    {
        var today = DateTime.Now.Date;
        var started = StateTodo.EmAndamento;
        return repository.GetByPeriod(user, today, started);
    }

    [Route("{user}/undone/today")]
    [HttpGet]
    public IEnumerable<TodoItem> GetUndoneForToday(
       string user,
       [FromServices] ITodoRepository repository)
    {
        var today = DateTime.Now.Date;
        var undone = StateTodo.Agendada;
        return repository.GetByPeriod(user, today, undone);
    }

    [Route("{user}/done/tomorrow")]
    [HttpGet]
    public IEnumerable<TodoItem> GetDoneForTomorrow(
       string user,
       [FromServices] ITodoRepository repository)
    {
        var today = DateTime.Now.Date.AddDays(1);
        var done = StateTodo.Finalizada;
        return repository.GetByPeriod(user, today, done);
    }

    [Route("{user}/started/tomorrow")]
    [HttpGet]
    public IEnumerable<TodoItem> GetStartedForTomorrow(
       string user,
       [FromServices] ITodoRepository repository)
    {
        var today = DateTime.Now.Date.AddDays(1);
        var started = StateTodo.EmAndamento;
        return repository.GetByPeriod(user, today, started);
    }

    [Route("{user}/undone/tomorrow")]
    [HttpGet]
    public IEnumerable<TodoItem> GetUndoneForTomorrow(
       string user,
       [FromServices] ITodoRepository repository)
    {
        var today = DateTime.Now.Date.AddDays(1);
        var undone = StateTodo.Agendada;
        return repository.GetByPeriod(user, today, undone);
    }

    [Route("")]
    [HttpPost]
    public GenericCommandResult Create(
        [FromBody] CreateTodoCommand command,
        [FromServices] TodoHandler handler) 
    {
        return (GenericCommandResult)handler.Handle(command);
    }

    [Route("")]
    [HttpPut]
    public GenericCommandResult Update(
        [FromBody] UpdateTodoCommand command,
        [FromServices] TodoHandler handler)
    {
        return (GenericCommandResult)handler.Handle(command);
    }

    [Route("mark-as-done")]
    [HttpPut]
    public GenericCommandResult MarkAsDone(
        [FromBody] MarkTodoAsFinishCommand command,
        [FromServices] TodoHandler handler)
    {
        return (GenericCommandResult)handler.Handle(command);
    }

    [Route("mark-as-undone")]
    [HttpPut]
    public GenericCommandResult MarkAsUndone(
        [FromBody] MarkTodoAsUnfinishedCommand command,
        [FromServices] TodoHandler handler)
    {
        return (GenericCommandResult)handler.Handle(command);
    }

    [Route("mark-as-started")]
    [HttpPut]
    public GenericCommandResult MarkAsStarted(
        [FromBody] MarkTodoAsStartedCommand command,
        [FromServices] TodoHandler handler)
    {
        return (GenericCommandResult)handler.Handle(command);
    }

    [Route("mark-as-unstarted")]
    [HttpPut]
    public GenericCommandResult MarkAsUnstarted(
        [FromBody] MarkTodoAsUnstartedCommand command,
        [FromServices] TodoHandler handler)
    {
        return (GenericCommandResult)handler.Handle(command);
    }
}
