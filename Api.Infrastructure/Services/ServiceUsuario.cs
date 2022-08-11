using Api.Core.Interfaces;
using Api.Infrastructure.Data;

namespace Api.Infrastructure.Services
{
    public class ServiceUsuario : IServiceUsuario
    {
        private readonly ApiContext context;

        public ServiceUsuario(ApiContext context)
        {
            this.context = context;
        }


    }
}
