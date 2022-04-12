namespace Todo.Domain.Entities;

public class TodoItem : Entity
{
    public string Title { get; private set; }
    public DateTime BeginDate { get; private set; }
    public TimeSpan DurationTime { get; private set; }
    public StateTodo StateTodo { get; private set; }
    public string User { get; private set; }

    public TodoItem(string title, string user, DateTime beginDate)
    {
        Title = title;
        BeginDate = beginDate;
        StateTodo = StateTodo.Agendada;
        User = user;
    }

    public void StartTodo() 
    {
        StateTodo = StateTodo.EmAndamento;
    }

    public void UndoStartTodo()
    {
        StateTodo = StateTodo.Agendada;
    }

    public void FinishTodo()
    {
        DurationTime = DateTime.Now - BeginDate;
        StateTodo = StateTodo.Finalizada;
    }

    public void UndoFinishTodo()
    {
        DurationTime = TimeSpan.Zero;
        StateTodo = StateTodo.EmAndamento;
    }

    
    public void UpdateTitle(string title)
    {
        Title = title;
    }
}
