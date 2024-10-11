using System;
namespace Completed_coursework
{
    public class Motorbike : Vehicle
    {
        public Motorbike(string v_maker, string v_model, double v_price)
            : base(v_maker, v_model, v_price)
        {
            // Additional Car-specific initialization if needed
        }

        // Constructor Chaining;
        public Motorbike()
            : base("Randon_maker", "Random_model", 0)
        {

        }
    }
}

