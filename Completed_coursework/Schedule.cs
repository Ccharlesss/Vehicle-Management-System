using System;
namespace Completed_coursework
{
    public class Schedule
    {
        private DateOnly pick_up_date;
        private DateOnly drop_off_date;

        public Schedule(DateOnly pick_up, DateOnly drop_off)
        {
            pick_up_date = pick_up;
            drop_off_date = drop_off;
        }


        // Constructor chaining;
        public Schedule()
            : this(DateOnly.MinValue, DateOnly.MinValue)
        {

        }


        // Purpose: Set the pick up date for a reservation
        // string: pick_up: Date in the format <YYYY/MM/DD>
        public void Set_Pick_Up(string pick_up)
        {
            if (DateOnly.TryParse(pick_up, out DateOnly pud))
            {
                pick_up_date = pud;
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid date format. Please enter in the format YYYY/MM/DD.");
                Console.ResetColor();
            }
        }


        // Purpose: Set the drop off date for a reservation
        // string: drop_up: Date in the format <YYYY/MM/DD>
        public void Set_Drop_Off(string drop_off)
        {
            if (DateOnly.TryParse(drop_off, out DateOnly dod))
            {
                drop_off_date = dod;
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid date format. Please enter in the format YYYY/MM/DD.");
                Console.ResetColor();
            }
        }


        // Purpose: Get the reservation's pick_up_date
        public DateOnly Get_Pick_Up()
        {
            return pick_up_date;
        }


        // Purpose: Get the reservation's drop_off_date
        public DateOnly Get_Drop_Off()
        {
            return drop_off_date;
        }


        // Purpose: Calculate the number of days in a reservation to compute the total rental price in $
        // DateOnly Pick_up: Pick_up_date of the vehicle
        // DateOnly Drop_off: Drop_off_date of the vehicle
        // Returns int number_of_days
        public int Calculate_Nbr_Days(DateOnly pick_up, DateOnly drop_off)
        {
            int number_of_days = 0;
            number_of_days = (drop_off.DayNumber - pick_up.DayNumber);

            return number_of_days;
        }




    }
}

