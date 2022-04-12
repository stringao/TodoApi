using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers;

public class TodoHandler :
    Notifiable,
    IHandler<CreateTodoCommand>,
    IHandler<UpdateTodoCommand>,
    IHandler<MarkTodoAsFinishCommand>,
    IHandler<MarkTodoAsUnfinishedCommand>,
    IHandler<MarkTodoAsStartedCommand>,
    IHandler<MarkTodoAsUnstartedCommand>
{
    private readonly ITodoRepository _repository;

    public TodoHandler(ITodoRepository repository)
    {
        _repository = repository;
    }
    
    public ICommandResult Handle(CreateTodoCommand command)
    {
        command.Validate();
        if (command.Invalid)
            return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada.", command.Notifications);

        var todo = new TodoItem(command.Title, command.User, command.BeginDate);

        _repository.Create(todo);

        return new GenericCommandResult(true, "Tarefa foi salva", todo);
    }

    public ICommandResult Handle(UpdateTodoCommand command)
    {
        command.Validate();
        if (command.Invalid)
            return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada.", command.Notifications);

        var todo = _repository.GetById(command.Id, command.User);

        todo.UpdateTitle(command.Title);

        _repository.Update(todo);

        return new GenericCommandResult(true, "Tarefa foi salva", todo);
    }

    public ICommandResult Handle(MarkTodoAsFinishCommand command)
    {
        command.Validate();
        if (command.Invalid)
            return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada.", command.Notifications);

        var todo = _repository.GetById(command.Id, command.User);

        todo.FinishTodo();

        _repository.Update(todo);

        return new GenericCommandResult(true, "Tarefa foi salva", todo);
    }

    public ICommandResult Handle(MarkTodoAsUnfinishedCommand command)
    {
        command.Validate();
        if (command.Invalid)
            return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada.", command.Notifications);

        var todo = _repository.GetById(command.Id, command.User);

        todo.UndoFinishTodo();

        _repository.Update(todo);

        return new GenericCommandResult(true, "Tarefa foi salva", todo);
    }

    public ICommandResult Handle(MarkTodoAsStartedCommand command)
    {
        command.Validate();
        if (command.Invalid)
            return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada.", command.Notifications);

        var todo = _repository.GetById(command.Id, command.User);

        todo.StartTodo();

        _repository.Update(todo);

        return new GenericCommandResult(true, "Tarefa foi salva", todo);
    }

    public ICommandResult Handle(MarkTodoAsUnstartedCommand command)
    {
        command.Validate();
        if (command.Invalid)
            return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada.", command.Notifications);

        var todo = _repository.GetById(command.Id, command.User);

        todo.UndoStartTodo();

        _repository.Update(todo);

        return new GenericCommandResult(true, "Tarefa foi salva", todo);
    }
}
