using Application.Layer.Interfaces;
using Domain.Layer.Entities;

namespace Application.Layer.Services
{
    public class ApiKeysService<T> where T : ApiKeysEntity
    {
        private  IRepository<T> _apiKeysRepository;

        public ApiKeysService(IRepository<T> apiKeysRepository)
        {
            _apiKeysRepository = apiKeysRepository;
        }
    }
}
