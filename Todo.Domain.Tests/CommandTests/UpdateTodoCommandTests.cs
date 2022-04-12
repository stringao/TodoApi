using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Todo.Domain.Commands;

namespace Todo.Domain.Tests.CommandTests;

[TestClass]
public class UpdateTodoCommandTests
{
    private readonly UpdateTodoCommand _invalidCommand = new (Guid.NewGuid(), "Ab", "Usuário Válido");
    private readonly UpdateTodoCommand _validCommand = new (Guid.NewGuid(),"Titulo Tarefa", "Usuário Válido");

    public UpdateTodoCommandTests()
    {
        _invalidCommand.Validate();
        _validCommand.Validate();
    }

    [TestMethod]
    public void Dado_um_comando_invalido()
    {
        Assert.IsFalse(_invalidCommand.Valid);
    }

    [TestMethod]
    public void Dado_um_comando_valido()
    {
        Assert.IsTrue(_validCommand.Valid);
    }
}
