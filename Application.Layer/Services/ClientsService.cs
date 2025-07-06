using Application.Layer.Interfaces;
using Domain.Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Layer.Services
{
    public class ClientsService<T> where T: ClientsEntity 
    {
        private IRepository<T> _ClientsRepository;
        public ClientsService(IRepository<T> ClientsRepository)
        {
            _ClientsRepository = ClientsRepository;
        }
    }
}
