using Domain.Layer.Models;

namespace Domain.Layer
{
    public class Strategy
    {
        List<TiresModel> _tires;
        public Strategy(List<TiresModel> Tires) 
        {
            _tires = Tires;
        }


        public string BuilOptimalEstrategy(int maxLaps) 
        {
        
            return "Optimal Strategy Built Successfully!";
        }

    }
}
