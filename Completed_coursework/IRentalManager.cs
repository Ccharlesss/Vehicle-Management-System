using System;
namespace Completed_coursework
{
    public interface IRentalManager
    {
        // Purpose: Add a new Vehicle in the list;
        // Vehicle v: Reference type to a vehicle
        // Return True: Vehicule successfully added to the system
        // Return False: Vehicule coudn't be added to the system
        public bool Add_Vehicle(Vehicle v);

        // Purpose: Delete a new Vehicle in the list;
        // string v_reg_nbr: vehicule registration number
        // Return true: Vehicule was successfully deleted
        // Return false: Vehicule coudn't be deleted
        public bool Delete_Vehicle(string v_nbr);

        // Purpose: List all the vehicle in the garage;
        public void List_Vehicle();

        // Purpose: List all the vehicle in the garage according to alphabetic order;
        public void List_Ordered_Vehicle();

        // Purpose: Generate a report text file with all the current vehicle;
        // string file_name: name of the file the admin use to save the report
        public void Generate_report(string file_name);
    }
}

