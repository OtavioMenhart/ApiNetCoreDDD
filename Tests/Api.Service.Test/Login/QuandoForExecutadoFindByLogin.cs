using ApiNetCore.Domain.Dtos;
using ApiNetCore.Domain.Interfaces.Services.User;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Test.Login
{
    public class QuandoForExecutadoFindByLogin
    {
        private ILoginService _service;
        private Mock<ILoginService> _serviceMock;

        [Fact(DisplayName = "É possível executar método find by login")]
        public async Task E_Possivel_Executar_Metodo_FindByLogin()
        {
            string email = Faker.Internet.Email();
            var objRetorno = new
            {
                authenticated = true,
                created = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = DateTime.UtcNow.AddHours(8).ToString("yyyy-MM-dd HH:mm:ss"),
                accessToken = Guid.NewGuid().ToString(),
                userName = email,
                message = "Usuário logado com sucesso"
            };

            LoginDto loginDto = new LoginDto
            {
                Email = email
            };

            _serviceMock = new Mock<ILoginService>();
            _serviceMock.Setup(x => x.FindByLogin(loginDto)).ReturnsAsync(objRetorno);
            _service = _serviceMock.Object;

            var logado = await _service.FindByLogin(loginDto);
            Assert.NotNull(logado);
        }
    }
}
