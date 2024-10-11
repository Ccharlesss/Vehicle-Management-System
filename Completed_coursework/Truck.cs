using System;
namespace Completed_coursework
{
    public class Truck : Vehicle
    {
        public Truck(string v_maker, string v_registration, double v_price)
            : base(v_maker, v_registration, v_price)
        {
            // Additional Car-specific initialization if needed
        }

        public Truck()
            : base("Randon_maker", "Random_model", 0)
        {

        }
    }
}

