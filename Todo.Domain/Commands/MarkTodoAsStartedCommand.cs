using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;

namespace Todo.Domain.Commands;

public class MarkTodoAsStartedCommand : Notifiable, ICommand
{
    public MarkTodoAsStartedCommand() { }

    public MarkTodoAsStartedCommand(Guid id, string user, StateTodo stateTodo)
    {
        Id = id;
        User = user;
        StateTodo = stateTodo;
    }

    public Guid Id { get; set; }
    public string User { get; set; }
    public StateTodo StateTodo { get; set; }

    public void Validate()
    {
        AddNotifications(
            new Contract()
            .Requires()
            .HasMinLen(User, 6, "Usuário", "Um usuário valido precisa ter no minimo 6 caracteres.")
            .AreEquals(StateTodo, StateTodo.Agendada, "Estado da Tarefa", "Somente é possivel marcar como Em Andamento, tarefas Agendadas.")
            );
    }
}
