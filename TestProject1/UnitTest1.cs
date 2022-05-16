using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Test.v1.Controllers;
using Xunit;

namespace TestProject1
{
    public class UnitTest1
    {
        //TODO PLUS - Adicionar validação para testar a consulta de todos usuarios cadastrados

        [Trait("Controller", "Usuario")]
        [Fact]
        public void Get_UsuariosOk_ConsultarTodos()
        {
            // Arrange
            var controller = new UsuarioController();

            // Act
            var response = controller.ConsultarTodos();

            // Assert
            response.Should().BeOfType<OkResult>();
        }
    }
}