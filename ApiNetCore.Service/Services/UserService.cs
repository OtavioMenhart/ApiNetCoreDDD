﻿using ApiNetCore.Domain.Dtos.User;
using ApiNetCore.Domain.Entities;
using ApiNetCore.Domain.Interfaces;
using ApiNetCore.Domain.Interfaces.Services.User;
using ApiNetCore.Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiNetCore.Service.Services
{
    public class UserService : IUserService
    {
        private IRepository<UserEntity> _repository;
        private readonly IMapper _mapper;

        public UserService(IRepository<UserEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<UserDto> Get(Guid id)
        {
            UserEntity entity = await _repository.SelectAsync(id);
            return _mapper.Map<UserDto>(entity);
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            IEnumerable<UserEntity> entities = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<UserDto>>(entities);
        }

        public async Task<UserDtoCreateResult> Post(UserDtoCreate user)
        {
            UserModel model = _mapper.Map<UserModel>(user);
            UserEntity entity = _mapper.Map<UserEntity>(model);
            UserEntity result = await _repository.InsertAsync(entity);
            return _mapper.Map<UserDtoCreateResult>(result);
        }

        public async Task<UserDtoUpdateResult> Put(UserDtoUpdate user)
        {
            UserModel model = _mapper.Map<UserModel>(user);
            UserEntity entity = _mapper.Map<UserEntity>(model);
            UserEntity result = await _repository.UpdateAsync(entity);
            return _mapper.Map<UserDtoUpdateResult>(result);
        }
    }
}
