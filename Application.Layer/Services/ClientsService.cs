using Application.Layer.DTOs;
using Application.Layer.Enum;
using Application.Layer.Interfaces;
using Domain.Layer.Entities;
using Domain.Layer.Models;
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
        private IModelResult<ClientsModels> _ModelResult;
        public ClientsService(IRepository<T> ClientsRepository)
        {
            _ClientsRepository = ClientsRepository;
            _ModelResult = new ModelResult<ClientsModels>();
        }


        public async Task<ModelResult<ClientsModels>> GetById(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    throw new ArgumentException("Invalid input parameters.");
                int _id = int.Parse(id);
                var result = await _ClientsRepository.GetByIdAsync(_id);

                if (result == null)
                    throw new Exception("No strategies found.");

                List<ClientsModels> clients = new List<ClientsModels>();
                clients.Add(new ClientsModels
                {
                    Description = result.Description,
                    Email = result.Email,
                    Id = result.Id,
                    Name = result.Name,
                    isActivo = result.isActivo
                });

                if (!clients.Any())
                    throw new Exception("No strategies found.");

                _ModelResult.Data = clients; // Assuming you want the first item or modify as needed
                _ModelResult.Success = true;
                _ModelResult.Message = StatusCodeHTTPEnum.OK.ToString();
                _ModelResult.StatusCode = (int)StatusCodeHTTPEnum.OK;
            }
            catch (Exception ex)
            {
                _ModelResult.Success = false;
                _ModelResult.Message = ex.Message;
                _ModelResult.StatusCode = (int)StatusCodeHTTPEnum.GatewayTimeout;
            }

            return (ModelResult<ClientsModels>)_ModelResult;
        }
    }
}
