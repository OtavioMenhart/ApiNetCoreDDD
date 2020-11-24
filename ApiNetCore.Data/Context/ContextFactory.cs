using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNetCore.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            string connectionString = "Server=localhost; Port=3306;Database=db_apinetcore; Uid=root; Pwd=ombr@170398";
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            optionsBuilder.UseMySql(connectionString);
            return new MyContext(optionsBuilder.Options);
        }
    }
}
