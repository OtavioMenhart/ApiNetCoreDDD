using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Integration.Test
{
    public class TesteLogin : BaseIntegration
    {
        [Fact(DisplayName = "É possível fazer requisição na API Login")]
        public async Task TesteToken()
        {
            await AdicionarToken();
        }
    }
}
