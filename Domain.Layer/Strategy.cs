using Domain.Layer.DTOs;
using Domain.Layer.Models;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace Domain.Layer
{
    public class Strategy
    {
        List<TiresModel> _tires;
        public Strategy(List<TiresModel> Tires) 
        {
            _tires = Tires;
        }


        public CombinationsDTO BuilOptimalEstrategy(int maxLaps) 
        {
            string optimalStrategy = string.Empty;
            List<List<TiresModel>> combinations = GetCombinations(maxLaps);
            List<CombinationsDTO>  processCombination = ProcessCombinations(combinations, maxLaps);
            return processCombination.First();
        }

        private List<CombinationsDTO> ProcessCombinations(List<List<TiresModel>> combinations, int maxLaps) 
        {
            List<CombinationsDTO> arrCombinations = new List<CombinationsDTO>();
            List<string> Strateys = new List<string>();
            List<string> IdStrateys = new List<string>();
            int? totalLabs = 0;
            foreach (var combination in combinations)
            {
                Strateys = new List<string>();
                IdStrateys = new List<string>();
                totalLabs = 0;
                
                foreach (var com in combination)
                {
                    Strateys.Add(com.type);
                    IdStrateys.Add(com.Id.ToString());
                    totalLabs += com.EstimatedLaps;
                }

                arrCombinations.Add(new CombinationsDTO
                {
                    avgPerformance = combination.Average(item => item.Performance),
                    avgConsumption = combination.Sum(item => item.ConsumptionLap),
                    IdStrateys = IdStrateys,
                    Strateys = Strateys,
                    totalLabs = totalLabs
                });
            }
            var ordenPerformance  =arrCombinations
                .OrderByDescending(item => item.avgPerformance)
                .ThenByDescending(item => item.totalLabs)
                .ToList();

            return ordenPerformance
                .OrderByDescending(item => item.totalLabs).ToList();

        }

        private double SumatoriaLimite(int totalTires)
        {
            double result = 0;
            double result2 = 0;
            for (int i = 0; i < totalTires; i++)   
                result += Math.Pow(totalTires, i + 1);
            return result;
        }

        private List<List<TiresModel>> GetCombinations(int maxlaps) 
        {

            double limit = SumatoriaLimite(_tires.Count());
            int numeroRandom = 0;
            Random random = new Random();
            TiresModel tiresTemporal = new TiresModel();
            List<List<TiresModel>> arrTires = new List<List<TiresModel>>();
            List<TiresModel> Arr = new List<TiresModel>();


            for (int i = 0; i < limit; i++)
            {
                Arr = new List<TiresModel>();
                int? sumLamps = 0;
                for (int j = 0; j < _tires.Count(); j++)
                {
                    numeroRandom = random.Next(0, _tires.Count());
                    tiresTemporal = _tires[numeroRandom];
                    //Arr.Add(tiresTemporal);
                    if (Arr.Any())
                    {
                        //int? LastItem = Arr.Last()?.EstimatedLaps;
                        //int? firstItem = Arr.First()?.EstimatedLaps;
                        
                        if ((sumLamps + tiresTemporal.EstimatedLaps) <= maxlaps)
                        {
                            sumLamps += tiresTemporal.EstimatedLaps;
                            Arr.Add(tiresTemporal);
                        }
                    }
                    else 
                    {
                        Arr.Add(tiresTemporal);
                        sumLamps = tiresTemporal.EstimatedLaps;
                    }
                        


                }

                if (!arrTires.Contains(Arr))
                    arrTires.Add(Arr);
                else
                    limit += 1;
            }

            return arrTires;
        }




    }
}
