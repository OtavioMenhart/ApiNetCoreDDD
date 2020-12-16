using ApiNetCore.Domain.Dtos.User;
using ApiNetCore.Domain.Entities;
using ApiNetCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Test.AutoMapper
{
    public class UsuarioMapper : BaseTestService
    {
        [Fact(DisplayName = "É possível mapear os modelos")]
        public async Task E_Possivel_Mapear_Modelos()
        {
            var model = new UserModel
            {
                id = Guid.NewGuid(),
                Name = Faker.Name.FullName(),
                Email = Faker.Internet.Email(),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };

            //model para entity
            var dtoToEntity = mapper.Map<UserEntity>(model);
            Assert.Equal(dtoToEntity.Id, model.id);
            Assert.Equal(dtoToEntity.Name, model.Name);
            Assert.Equal(dtoToEntity.Email, model.Email);
            Assert.Equal(dtoToEntity.CreateAt, model.CreateAt);
            Assert.Equal(dtoToEntity.UpdateAt, model.UpdateAt);

            //entity para dto
            var userDto = mapper.Map<UserDto>(dtoToEntity);
            Assert.Equal(dtoToEntity.Id, userDto.Id);
            Assert.Equal(dtoToEntity.Name, userDto.Name);
            Assert.Equal(dtoToEntity.Email, userDto.Email);
            Assert.Equal(dtoToEntity.CreateAt, userDto.CreateAt);

            List<UserEntity> listaEntity = new List<UserEntity>();
            for (int i = 0; i < 5; i++)
            {
                UserEntity dto = new UserEntity
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email(),
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow
                };
                listaEntity.Add(dto);
            }

            var listaEntityToDto = mapper.Map<List<UserDto>>(listaEntity);
            Assert.True(listaEntity.Count == listaEntityToDto.Count);

            for (int i = 0; i < listaEntityToDto.Count; i++)
            {
                Assert.Equal(listaEntityToDto[i].Id, listaEntity[i].Id);
                Assert.Equal(listaEntityToDto[i].Name, listaEntity[i].Name);
                Assert.Equal(listaEntityToDto[i].Email, listaEntity[i].Email);
                Assert.Equal(listaEntityToDto[i].CreateAt, listaEntity[i].CreateAt);
            }

            var userDtoCreateResult = mapper.Map<UserDtoCreateResult>(dtoToEntity);
            Assert.Equal(userDtoCreateResult.Id, dtoToEntity.Id);
            Assert.Equal(userDtoCreateResult.Name, dtoToEntity.Name);
            Assert.Equal(userDtoCreateResult.Email, dtoToEntity.Email);
            Assert.Equal(userDtoCreateResult.CreateAt, dtoToEntity.CreateAt);

            var userDtoUpdateResult = mapper.Map<UserDtoUpdateResult>(dtoToEntity);
            Assert.Equal(userDtoUpdateResult.Id, dtoToEntity.Id);
            Assert.Equal(userDtoUpdateResult.Name, dtoToEntity.Name);
            Assert.Equal(userDtoUpdateResult.Email, dtoToEntity.Email);
            Assert.Equal(userDtoUpdateResult.UpdateAt, dtoToEntity.UpdateAt);

            //Dto para Model
            var userModel = mapper.Map<UserModel>(userDto);
            Assert.Equal(userModel.id, userDto.Id);
            Assert.Equal(userModel.Name, userDto.Name);
            Assert.Equal(userModel.Email, userDto.Email);
            Assert.Equal(userModel.CreateAt, userDto.CreateAt);

            var userDtoCreate = mapper.Map<UserDtoCreate>(userModel);
            Assert.Equal(userDtoCreate.Name, userModel.Name);
            Assert.Equal(userDtoCreate.Email, userModel.Email);

            var userDtoUpdate = mapper.Map<UserDtoUpdate>(userModel);
            Assert.Equal(userDtoUpdate.Id, userModel.id);
            Assert.Equal(userDtoUpdate.Name, userModel.Name);
            Assert.Equal(userDtoUpdate.Email, userModel.Email);
        }
    }
}
