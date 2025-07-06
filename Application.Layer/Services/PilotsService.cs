using Application.Layer.DTOs;
using Application.Layer.Enum;
using Application.Layer.Interfaces;
using Domain.Layer.Entities;
using Domain.Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.Layer.Services
{
    public class PilotsService<T> where T : PilotsEntity
    {
        private IRepository<T> _PilotsRepository;
        private IModelResult<PilotsModel> _ModelResult;
        public PilotsService(IRepository<T> PilotsRepository)
        {
            _PilotsRepository = PilotsRepository;
            _ModelResult = new ModelResult<PilotsModel>();
        }


        public async Task<ModelResult<PilotsModel>> GetAll()
        {
            try
            {
                var result = await _PilotsRepository.GetAllAsync();

                if (!result.Any())
                    throw new Exception("No strategies found.");

                List<PilotsModel> pilots = [.. result.Select(pilot => new PilotsModel
                {
                    Id = pilot.Id,
                    Name = pilot.Name,
                    Team = pilot.Team,
                    nationality = pilot.nationality
                })];

                if (!pilots.Any())
                    throw new Exception("No strategies found.");

                _ModelResult.Data = pilots; // Assuming you want the first item or modify as needed
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

            return (ModelResult<PilotsModel>)_ModelResult;
        }

        public async Task<ModelResult<PilotsModel>> GetById(string  id)
        {
            try
            {
                if ( string.IsNullOrEmpty(id))
                    throw new ArgumentException("Invalid input parameters.");
                int _id = int.Parse(id);
                var result = await _PilotsRepository.GetByIdAsync(_id);

                if (result == null )
                    throw new Exception("No strategies found.");

                List<PilotsModel> pilots = new List<PilotsModel>();
                pilots.Add(new PilotsModel { 
                    Id =result.Id,
                    Name = result.Name,
                    Team = result.Team,
                    nationality = result.nationality
                });

                if (!pilots.Any())
                    throw new Exception("No strategies found.");

                _ModelResult.Data = pilots; // Assuming you want the first item or modify as needed
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

            return (ModelResult<PilotsModel>)_ModelResult;
        }

    }
}
