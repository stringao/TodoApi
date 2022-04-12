using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Tests.Repositories;

namespace Todo.Domain.Tests.HandlerTests;

[TestClass]
public class MarkTodoAsUnfinishHandlerTests
{

    private readonly MarkTodoAsUnfinishedCommand _invalidCommand = new(Guid.NewGuid(),"Usuário Valido", StateTodo.Agendada);
    private readonly MarkTodoAsUnfinishedCommand _validCommand = new(Guid.NewGuid(), "Usuário Valido", StateTodo.Finalizada);
    private readonly TodoHandler _handler = new(new FakeTodoRepository());
    private GenericCommandResult _result = new GenericCommandResult();

    public MarkTodoAsUnfinishHandlerTests()
    {

    }

    [TestMethod]
    public void Dado_um_comando_invalido_Deve_interromper_execucao_MarkTodoAsUnfinished()
    {
        _result = (GenericCommandResult)_handler.Handle(_invalidCommand);
        Assert.IsFalse(_result.Success);
    }

    [TestMethod]
    public void Dado_um_comando_valido_Deve_marcar_tarefa_como_EmAndamento_MarkTodoAsUnfinished()
    {
        _result = (GenericCommandResult)_handler.Handle(_validCommand);
        Assert.IsTrue(_result.Success);
    }
}
