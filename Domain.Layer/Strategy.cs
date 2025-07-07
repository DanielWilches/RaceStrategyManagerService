using Domain.Layer.DTOs;
using Domain.Layer.Models;

namespace Domain.Layer
{
    public class Strategy
    {
        private readonly List<TiresModel> _tires;
        public Strategy(List<TiresModel> tires)
        {
            _tires = tires;
        }

        public CombinationsDTO GetOptimalStrategies(int maxLaps)
        {
            return GetCombinations(maxLaps);
        }
        
        private CombinationsDTO GetCombinations(int maxVueltas)
        {
            List<CombinationsDTO> resultados = CreateCombinations(maxVueltas);
            var maxVueltasLogradas =  resultados.First(item => item.TotalLabs == resultados.Max(r => r.TotalLabs)) ;
            return maxVueltasLogradas;
        }

        private List<CombinationsDTO> CreateCombinations(int maxVueltas) 
        {
            var Soft = _tires.First(tire => (tire?.type ?? string.Empty).Equals("Soft"));
            var Medium = _tires.First(tire => (tire?.type ?? string.Empty).Equals("Medium"));
            var Hard = _tires.First(tire => (tire?.type ?? string.Empty).Equals("Hard"));
            List<CombinationsDTO> resultados = new List<CombinationsDTO>();
            for (int s = 0; s <= maxVueltas / Soft.EstimatedLaps; s++)
            {
                for (int n = 0; n <= (maxVueltas - Soft.EstimatedLaps * s) / Medium.EstimatedLaps; n++)
                {
                    for (int h = 0; h <= (maxVueltas - Soft.EstimatedLaps * s - Medium.EstimatedLaps * n) / 25; h++)
                    {
                        int totalVueltas = (Soft.EstimatedLaps ?? 0) * s + (Medium.EstimatedLaps ?? 0) * n + (Hard.EstimatedLaps ?? 0) * h;

                        if (totalVueltas <= maxVueltas)
                        {
                            List<int>? avgPerformance = new List<int>() ;
                            List<double>? avgConsumption = new List<double>();
                            var tires = new List<TiresModel>();
                            for (int i = 0; i < s; i++) tires.Add(Soft);
                            for (int i = 0; i < n; i++) tires.Add(Medium);
                            for (int i = 0; i < h; i++) tires.Add(Hard);

                            foreach (var item in tires)
                            {
                                avgPerformance.Add(item?.Performance??0);
                                avgConsumption.Add(item?.ConsumptionLap ??  0);
                            }
                            resultados.Add(new CombinationsDTO
                            {
                                TotalLabs = totalVueltas,
                                Strateys = tires,
                                AvgConsumption = avgConsumption,
                                AvgPerformance = avgPerformance,
                            });
                        }
                    }
                }
            }
            return resultados;
        }

    }


}
