using ApiNetCore.Data.Context;
using ApiNetCore.Data.Implementations;
using ApiNetCore.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Data.Test
{
    public class UsuarioCrudCompleto : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvider;

        public UsuarioCrudCompleto(DbTeste dbTeste)
        {
            _serviceProvider = dbTeste.ServiceProvider;
        }

        [Fact(DisplayName = "Crud de usuário")]
        [Trait("CRUD", "UserEntity")]
        public async Task E_Possivel_Realizar_Crud_Usuario()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                UserImplementation _repositorio = new UserImplementation(context);
                UserEntity entity = new UserEntity
                {
                    Email = Faker.Internet.Email(),
                    Name = Faker.Name.FullName()
                };
                var registroCriado = await _repositorio.InsertAsync(entity);
                Assert.NotNull(registroCriado);
                Assert.Equal(entity.Email, registroCriado.Email);
                Assert.Equal(entity.Name, registroCriado.Name);
                Assert.False(registroCriado.Id == Guid.Empty);


                entity.Name = Faker.Name.First();
                var registroAtualizado = await _repositorio.UpdateAsync(entity);
                Assert.NotNull(registroAtualizado);
                Assert.Equal(entity.Email, registroAtualizado.Email);
                Assert.Equal(entity.Name, registroAtualizado.Name);

                var registroExiste = await _repositorio.ExistAsync(registroAtualizado.Id);
                Assert.True(registroExiste);

                var registroSelecionado = await _repositorio.SelectAsync(registroAtualizado.Id);
                Assert.NotNull(registroSelecionado);
                Assert.Equal(registroAtualizado.Email, registroSelecionado.Email);
                Assert.Equal(registroAtualizado.Name, registroSelecionado.Name);

                var todosRegistros = await _repositorio.SelectAsync();
                Assert.NotNull(todosRegistros);
                Assert.True(todosRegistros.Count() > 0);

                var logarEmail = await _repositorio.FindByLogin(registroSelecionado.Email);
                Assert.NotNull(logarEmail);
                Assert.Equal(logarEmail.Email, registroSelecionado.Email);
                Assert.Equal(logarEmail.Name, registroSelecionado.Name);

                var registroDeletado = await _repositorio.ExistAsync(registroSelecionado.Id);
                Assert.True(registroDeletado);
            }

        }
    }
}
