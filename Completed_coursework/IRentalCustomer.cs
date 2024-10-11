using System;
namespace Completed_coursework
{
    public interface IRentalCustomer
    {

        // Purpose: List all the available vehicle to rent according to a particular schedule and type;
        // Info concerning vehicule: 'Maker'/'Model'/'Registration_nbr'/'Rental_price'/ 'Type'
        // Info converrning reservation: Key {pick_up_date and drop_off_date} value {driver_fname/river_lname/DOB/license_nbr/total_price$}
        public void List_Available_Vehicle(Schedule wantedSchedule, Type type);

        // Add a reservation on a vehicle for a particular date;
        // string v_reg_nbr: Vehicule registration number
        // Schedule wantedSchedule: reservation that the customer enters with a pick up an drop off date.
        // Returns true: Reservation was successfully added
        // Return false: Reservation coudn't be added
        public bool Add_Reservation(string v_nbr, Schedule wantedSchedule);

        // Change reservation for a vehicle for a particular date;
        // string v_reg_nbr: Vehicule registration number
        // Schedule oldSchedule: old reservation that the customer wants to change
        // Schedule newSchedule: new reservation that the customer wants with a pick up an drop off date.
        // Returns true: The reservation was successfully modified
        // Returns false: The reservation couldn't be modified
        public bool Change_Reservation(string v_nbr, Schedule oldSchedule, Schedule newSchedule);

        // Delete a reservation for a vehicle for a particular date;
        // string v_reg_nbr: Vehicule registration number
        // Schedule oldSchedule: old reservation that the customer wants to delete.
        public bool Delete_Reservation(string v_nbr, Schedule wantedSchedule);

    }
}

