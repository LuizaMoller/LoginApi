using WebApi.Controllers;
using WebApi.Models.Users;
using WebApi.Entities;
using WebApi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Moq;

namespace TestLogin
{
    public class UnitTest
    {

        public readonly Mock<IUserService> _dbServiceMock = new();
        public readonly Mock<UsersController> _usersControllerMock = new();

        [Fact]
        public void GetByIdTest()
        {
            var user = new User { Id = 1, FirstName = "teste1", LastName = "teste", Username = "teste", PasswordHash = "senha-segura"};
            _dbServiceMock.Setup(x => x.GetById(user.Id)).Returns(user);
            
            var result = _dbServiceMock.Object;

            var teste = result.GetById(1);

            Assert.NotNull(teste);
        
        }
        [Fact]
        public void DeleteTest()
        {
            var user = new User { Id = 1, FirstName = "teste1", LastName = "teste", Username = "teste", PasswordHash = "senha-segura" };
            _dbServiceMock.Setup(x => x.Delete(user.Id));

            var result = _dbServiceMock.Object;           

            var getDelete = result.GetById(1);

            Assert.Null(getDelete);
        }     

    }
}