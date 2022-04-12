using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Tests.Repositories;

namespace Todo.Domain.Tests.HandlerTests;

[TestClass]
public class UpdateTodoHandlerTests
{
    private readonly UpdateTodoCommand _invalidCommand = new (Guid.NewGuid(), "Novo Título da Tarefa", "");
    private readonly UpdateTodoCommand _validCommand = new (Guid.NewGuid(), "Novo Título da Tarefa", "Usuário Válido");
    private readonly TodoHandler _handler = new(new FakeTodoRepository());
    private GenericCommandResult _result = new GenericCommandResult();

    public UpdateTodoHandlerTests()
    {
        
    }

    [TestMethod]
    public void Dado_um_comando_invalido_Deve_interromper_execucao()
    {
        _result = (GenericCommandResult)_handler.Handle(_invalidCommand);
        Assert.IsFalse(_result.Success);
    }
    
    [TestMethod]
    public void Dado_um_comando_valido_Deve_Atualizar_tarefa_com_novo_titulo()
    {
        _result = (GenericCommandResult)_handler.Handle(_validCommand);
        TodoItem todoItem = (TodoItem)_result.Data;
        Assert.AreEqual(todoItem.Title, "Novo Título da Tarefa");
        Assert.IsTrue(_result.Success);
    }
}
