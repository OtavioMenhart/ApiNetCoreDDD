using ApiNetCore.Application.Controllers;
using ApiNetCore.Domain.Dtos.User;
using ApiNetCore.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Application.Test.Usuario.QuandoRequisitarCreate
{
    public class Retorno_Created
    {
        private UsersController _controller;

        [Fact(DisplayName = "É possível realizar o create")]
        public async Task E_Possivel_Invocar_Controller_Create()
        {
            var serviceMock = new Mock<IUserService>();

            string nome = Faker.Name.FullName();
            string email = Faker.Internet.Email();

            serviceMock.Setup(x => x.Post(It.IsAny<UserDtoCreate>())).ReturnsAsync(new UserDtoCreateResult 
            {
                Id = Guid.NewGuid(),
                Email = email,
                Name = nome,
                CreateAt = DateTime.UtcNow
            });

            _controller = new UsersController(serviceMock.Object);

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");

            _controller.Url = url.Object;

            var userDtoCreate = new UserDtoCreate
            {
                Name = nome,
                Email = email
            };

            var result = await _controller.Post(userDtoCreate);
            Assert.True(result is CreatedResult);

            var resultValue = ((CreatedResult)result).Value as UserDtoCreateResult;
            Assert.NotNull(resultValue);
            Assert.Equal(userDtoCreate.Name, resultValue.Name);
            Assert.Equal(userDtoCreate.Email, resultValue.Email);
        }
    }
}
