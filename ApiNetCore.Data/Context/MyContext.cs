﻿using ApiNetCore.Data.Mapping;
using ApiNetCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNetCore.Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<UserEntity> UserEntity { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>(new UserMap().Configure);
        }
    }
}
