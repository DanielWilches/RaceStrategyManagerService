
using Application.Layer.DTOs;
using Application.Layer.Enum;
using Application.Layer.Interfaces;
using Domain.Layer.Entities;
using Domain.Layer.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Layer.Services
{
    public class TiresService<T> where T : TiresEntity
    {

        private IRepository<T> _TiresRepository;
        private IModelResult<TiresModel> _ModelResult;
        public TiresService(IRepository<T> TiresRepository, IModelResult<TiresModel> modelResult)
        {
            _TiresRepository = TiresRepository;
            _ModelResult = modelResult;
        }


        /// <summary>
        /// this method retrieves all tires from the repository and maps them to a list of TiresModel.
        /// </summary>
        /// <returns></returns>
        public async Task<ModelResult<TiresModel>> GetAll()
        {
            try
            {
                var result = await _TiresRepository.GetAllAsync();

                if (!result.Any())
                    throw new Exception("No tires found.");

                var tires = result.Select(tire => new TiresModel
                {
                    Id = tire.Id,
                    type = tire.type,
                    EstimatedLaps = tire.EstimatedLaps,
                    ConsumptionLap = tire.ConsumptionLap,
                    Performance = tire.Performance
                }).ToList();

                if (!tires.Any())
                    throw new Exception("No tires found.");

                _ModelResult.Data = tires; // Assuming you want the first item or modify as needed
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

            return (ModelResult<TiresModel>)_ModelResult;
        }
    }
}
