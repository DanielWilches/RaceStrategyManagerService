using Application.Layer.DTOs;
using Application.Layer.Enum;
using Application.Layer.Interfaces;
using Domain.Layer;
using Domain.Layer.DTOs;
using Domain.Layer.Entities;
using Domain.Layer.Models;


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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<ResultDTO<StrategiesModel>> GetAll()
        {
            try
            {
    
                IEnumerable< StrategiesPilotClientDTO > result = await _StrategiesRepository.ExecuteSP("GetAllStrategies");
                if (!result.Any())
                    throw new Exception("No strategies found.");

                List<StrategiesModel> strategies = [.. result.Select(strategy => new StrategiesModel
                {
                    Id = strategy.Id_Strategy,
                    clients = new ClientsModels{
                        Id = strategy.Client_Id,
                        Description = strategy.Description,
                        Email = strategy.Email,
                        isActivo = strategy.isActivo,
                        Name= strategy.Name_Client
                    },
                    pilots = new PilotsModel
                    {
                        Id = strategy.Id_Pilot,
                        Name = strategy.Name_Pilot,
                        Team = strategy.Team,
                    },
                    Date = strategy.Date,
                    TotalLaps = strategy.Total_Laps,
                    MaxLaps = strategy.Max_Laps,
                    avgPerformance = strategy.Avg_Performance,
                    avgConsumption = strategy.avg_Consumption,
                    optimalStrategy = strategy.Optimal_Strategy
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
            return (ResultDTO<StrategiesModel>)_ModelResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="maxLaps"></param>
        /// <param name="ClientId"></param>
        /// <param name="PilotId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<ResultDTO<StrategiesModel>> CreateStrategy(string maxLaps, string ClientId, string PilotId)
        {
            try
            {
                if (string.IsNullOrEmpty(maxLaps) || string.IsNullOrEmpty(ClientId) || string.IsNullOrEmpty(PilotId))
                    throw new ArgumentException("Invalid input parameters.");

                int mlaps = int.Parse(maxLaps);
                int clientId = int.Parse(ClientId);
                int pilotId = int.Parse(PilotId);

                List<TiresModel> tires = GetTires().Result;
                if (tires.Min(item => item.EstimatedLaps) > mlaps)
                    throw new Exception("The minimum estimated laps of the tires is less than the total laps.");

                Strategy strategy = new Strategy(tires);

                CombinationsDTO optimal = strategy.BuilOptimalEstrategy(mlaps);
                if (optimal == null || optimal.Strateys == null || !optimal.Strateys.Any())
                    throw new Exception("No optimal strategy found.");

                if (optimal.totalLabs > mlaps)
                    throw new Exception("The total laps of the optimal strategy exceeds the maximum laps.");

                string optimalStrategy = string.Empty;
                foreach (var item in optimal.Strateys) 
                   optimalStrategy += $"{item}|";
                    
                    
                var newStrategy = new StrategiesEntity
                {
                    ClientId = clientId,
                    PilotId = pilotId,
                    Date = DateTime.Now,
                    TotalLaps = optimal?.totalLabs ?? 0,
                    MaxLaps = mlaps,
                    avgPerformance = optimal?.avgPerformance ?? 0,
                    avgConsumption = optimal?.avgConsumption?? 0,
                    optimalStrategy = optimalStrategy
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
            return (ResultDTO<StrategiesModel>)_ModelResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private async Task<List<TiresModel>> GetTires()
        {
            ResultDTO<TiresModel> tiresResult = await _tiresService.GetAll();

            if (!tiresResult.Success)
                throw new Exception(tiresResult.Message);

            if (tiresResult.Data == null || !tiresResult.Data.Any())
                throw new Exception("No tires available.");

            return tiresResult.Data;


        }
    }
}



