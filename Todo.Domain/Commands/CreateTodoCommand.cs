using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;

namespace Todo.Domain.Commands;

public class CreateTodoCommand : Notifiable, ICommand
{
    public CreateTodoCommand() { }
    public CreateTodoCommand(string title, string user, DateTime beginDate)
    {
        Title = title;
        User = user;
        BeginDate = beginDate;
    }
    public string Title { get; set; }
    public string User { get; set; }
    public DateTime BeginDate { get; set; }

    public void Validate()
    {
        AddNotifications(
            new Contract()
            .Requires()
            .HasMinLen(Title, 3,"Titulo","O Titulo precisa ter no mínimo 3 caracteres.")
            .HasMinLen(User,6, "Usuário", "Um usuário valido precisa ter no minimo 6 caracteres.")
        );
    }
}
