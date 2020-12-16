using ApiNetCore.CrossCutting.Mappings;
using AutoMapper;
using System;
using Xunit;

namespace Api.Service.Test
{
    public abstract class BaseTestService
    {
        public IMapper mapper { get; set; }
        public BaseTestService()
        {
            mapper = new AutoMapperFixture().GetMapper();
        }

        public class AutoMapperFixture : IDisposable
        {
            public IMapper GetMapper()
            {
                var config = new MapperConfiguration(x =>
                {
                    x.AddProfile(new ModelToEntityProfile());
                    x.AddProfile(new DtoToModelProfile());
                    x.AddProfile(new EntityToDtoProfile());
                });
                return config.CreateMapper();
            }
            public void Dispose()
            {
                
            }
        }
    }
}
