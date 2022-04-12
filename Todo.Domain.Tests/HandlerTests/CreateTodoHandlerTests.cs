using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Todo.Domain.Commands;
using Todo.Domain.Handlers;
using Todo.Domain.Tests.Repositories;

namespace Todo.Domain.Tests.HandlerTests;

[TestClass]
public class CreateTodoHandlerTests
{
    private readonly CreateTodoCommand _invalidCommand = new ("", "", DateTime.Now);
    private readonly CreateTodoCommand _validCommand = new ("Titulo Tarefa", "Usuário Válido", DateTime.Now);
    private readonly TodoHandler _handler = new(new FakeTodoRepository());
    private GenericCommandResult _result = new GenericCommandResult();

    public CreateTodoHandlerTests()
    {
        
    }

    [TestMethod]
    public void Dado_um_comando_invalido_Deve_interromper_execucao()
    {
        _result = (GenericCommandResult)_handler.Handle(_invalidCommand);
        Assert.AreEqual(_result.Success,false);
    }
    
    [TestMethod]
    public void Dado_um_comando_valido_Deve_criar_tarefa()
    {
        _result = (GenericCommandResult)_handler.Handle(_validCommand);
        Assert.AreEqual(_result.Success, true);
    }
}
