using System;
namespace Completed_coursework
{
    public class Car : Vehicle
    {
        public Car(string v_maker, string v_registration, double v_price)
            : base(v_maker, v_registration, v_price)
        {
            // Additional Car-specific initialization if needed
        }

        public Car()
            : base("Randon_maker", "Random_model", 0)
        {

        }


    }
}

