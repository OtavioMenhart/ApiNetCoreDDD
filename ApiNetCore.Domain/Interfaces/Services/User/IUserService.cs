﻿using ApiNetCore.Domain.Dtos.User;
using ApiNetCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiNetCore.Domain.Interfaces.Services.User
{
    public interface IUserService
    {
        Task<UserDtoCreate> Get(Guid id);
        Task<IEnumerable<UserDtoCreate>> GetAll();
        Task<UserDtoCreateResult> Post(UserDtoCreate user);
        Task<UserDtoUpdateResult> Put(UserDtoUpdate user);
        Task<bool> Delete(Guid id);
    }
}
