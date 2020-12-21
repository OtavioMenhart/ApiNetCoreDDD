using ApiNetCore.Application;
using ApiNetCore.CrossCutting.Mappings;
using ApiNetCore.Data.Context;
using ApiNetCore.Domain.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Api.Integration.Test
{
    public abstract class BaseIntegration : IDisposable
    {
        public MyContext myContext { get; private set; }
        public HttpClient client { get; private set; }
        public IMapper mapper { get; set; }
        public string hostApi { get; set; }
        public HttpResponseMessage response{ get; set; }

        public BaseIntegration()
        {
            hostApi = "http://localhost:5000/api/";
            var builder = new WebHostBuilder().UseEnvironment("Testing").UseStartup<Startup>();
            var server = new TestServer(builder);

            myContext = server.Host.Services.GetService(typeof(MyContext)) as MyContext;
            myContext.Database.Migrate();

            mapper = new AutoMapperFixture().GetMapper();

            client = server.CreateClient();



        }

        public async Task AdicionarToken()
        {
            var loginDto = new LoginDto
            {
                Email = "otavio@gmail.com"
            };
            var resultLogin = await PostJsonAsync(loginDto, $"{hostApi}Login/Login", client);
            var json = await resultLogin.Content.ReadAsStringAsync();

            var loginObject = JsonConvert.DeserializeObject<LoginResponseDto>(json);

            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", loginObject.accessToken);

        }

        public static async Task<HttpResponseMessage> PostJsonAsync(object data, string url, HttpClient client)
        {
            return await client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"));
        }

        public void Dispose()
        {
            myContext.Dispose();
            client.Dispose();
        }
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
