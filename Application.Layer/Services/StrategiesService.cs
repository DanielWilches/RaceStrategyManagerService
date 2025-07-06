using Application.Layer.DTOs;
using Application.Layer.Enum;
using Application.Layer.Interfaces;
using Domain.Layer;
using Domain.Layer.Entities;
using Domain.Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.Layer.Services
{
    public class StrategiesService<T> where T : StrategiesEntity
    {
        private IRepository<T> _StrategiesRepository;
        private IModelResult<StrategiesModel> _ModelResult;
        private TiresService<TiresEntity> _tiresService;
        public StrategiesService(IRepository<T> StrategiesRepository, IModelResult<StrategiesModel> ModelResult, TiresService<TiresEntity> tiresService)
        {
            _StrategiesRepository = StrategiesRepository;
            _ModelResult = ModelResult;
            _tiresService = tiresService;
        }


        public async Task<ModelResult<StrategiesModel>> GetAll()
        {
            try
            {
                var result = await _StrategiesRepository.GetAllAsync();

                if (!result.Any())
                    throw new Exception("No strategies found.");

                List<StrategiesModel> strategies = [.. result.Select(strategy => new StrategiesModel
                {
                    Id = strategy.Id,
                    ClientId = strategy.ClientId,
                    Date = strategy.Date,
                    PilotId = strategy.PilotId,
                    TotalLaps = strategy.TotalLaps
                })];

                if (!strategies.Any())
                    throw new Exception("No strategies found.");

                _ModelResult.Data = strategies; // Assuming you want the first item or modify as needed
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

            return (ModelResult<StrategiesModel>)_ModelResult;
        }


        public async Task<ModelResult<StrategiesModel>> CreateStrategy(string maxLaps, string ClientId, string PilotId)
        {
            try
            {
                if (string.IsNullOrEmpty(maxLaps) || string.IsNullOrEmpty(ClientId) || string.IsNullOrEmpty(PilotId))
                    throw new ArgumentException("Invalid input parameters.");

                int laps = int.Parse(maxLaps);
                int clientId = int.Parse(ClientId);
                int pilotId = int.Parse(PilotId);

                List<TiresModel> tires = GetTires().Result;
                Strategy strategy = new Strategy(tires);

                var optimal = strategy.BuilOptimalEstrategy(laps);
                var newStrategy = new StrategiesEntity
                {
                    ClientId = clientId,
                    PilotId = pilotId,
                    Date = DateTime.Now,
                    TotalLaps = laps,
                    optimalStrategy = optimal
                };
                await _StrategiesRepository.AddAsync((T)newStrategy);

                _ModelResult.Success = true;
                _ModelResult.Message = "Strategy created successfully.";
                _ModelResult.StatusCode = (int)StatusCodeHTTPEnum.OK;
            }
            catch (Exception ex)
            {
                _ModelResult.Success = false;
                _ModelResult.Message = ex.Message;
                _ModelResult.StatusCode = (int)StatusCodeHTTPEnum.GatewayTimeout;
            }



            return (ModelResult<StrategiesModel>)_ModelResult;
        }


        private async Task<List<TiresModel>> GetTires()
        {
            ModelResult<TiresModel> tiresResult = await _tiresService.GetAll();

            if (!tiresResult.Success)
                throw new Exception(tiresResult.Message);

            if (tiresResult.Data == null || !tiresResult.Data.Any())
                throw new Exception("No tires available.");

            return tiresResult.Data;


        }
    }
}



