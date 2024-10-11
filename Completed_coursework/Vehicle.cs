using System;
using System.Collections.Generic;
namespace Completed_coursework
{
    public abstract class Vehicle : IOverlappable
    {
        // Set of private attributes for the Vehicle's class:
        // List <Scheule> is there to store any nbr of reservations for a particular vehicle.
        private string maker;
        private string model;
        private string registratiion_nbr;
        private double rental_price;
        private Dictionary<Schedule, string> reservation_detail = new Dictionary<Schedule, string>();


        // Constructor to initialize the attributes of the Vehicle's class:
        // The registration number isnt set with the constructor to avoir adding the same registration nbr
        public Vehicle(string v_maker, string v_model, double v_price)
        {
            maker = v_maker;
            model = v_model;
            rental_price = v_price;
        }


        // Purpose: Set the vehicle's maker
        // string v_maker: Vehicle's maker
        public void Set_Maker(string v_maker)
        {
            maker = v_maker;
        }

        // Purpose: Set the vehicle's model
        // string v_model: Vehicle's model
        public void Set_Model(string v_model)
        {
            model = v_model;
        }

        // Purpose: Set the vehicle's registration number
        // string v_registration: Registration number
        public void Set_Registration(string v_registration)
        {
            registratiion_nbr = v_registration;
        }

        // Purpose: Set the vehicle's rental price in double
        // string v_price: Vehicle's daily rental price and then converts it to double
        public void Set_Rental_Price(string v_price)
        {
            try
            {
                if (Double.TryParse(v_price, out double v_rental_p))
                {
                    rental_price = v_rental_p;
                }
                else
                {
                    Console.WriteLine("Error! Must be digits.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error! Invalid input format. Must be a valid number.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Error! Input value is too large or too small for a double.");
            }
        }


        // Purpose: Get the vehicle's maker
        // Return: string maker 
        public string Get_Maker()
        {
            return maker;
        }

        // Purpose: Get the vehicle's model
        // Return: string model
        public string Get_Model()
        {
            return model;
        }

        // Purpose: Get the vehicle's registration number
        // Return: string registration number
        public string Get_Registration()
        {
            return registratiion_nbr;
        }

        // Purpose: Get the vehicle's daily rental price
        // Return: Double daily rental price
        public double Get_Rental_Price()
        {
            return rental_price;
        }



        // Add a reservation with the driver's personal detail in the system;
        // Info converrning reservation: Key {pick_up_date and drop_off_date} value {driver_fname/river_lname/DOB/license_nbr/total_price$}
        // string personal_detail: "driver_fname/river_lname/DOB/license_nbr/total_price$"
        // Schedule reservation: reservation date of the customer w/ a pick_up_date and a drop_off_date
        public void Add_Reservation_And_Detail(string personal_detail, Schedule reservation)
        {
            reservation_detail.Add(reservation, personal_detail);

        }


        // Purpose: Get the driver's details necessary to book a reservation;
        // double total_rental_price: calculated by muultiplying daily_rental_price by number_of_days
        // Returns: string driver_details = "driver_fname/river_lname/DOB/license_nbr/total_price$"
        public string Get_driver_data(double total_rental_price)
        {
            Console.WriteLine("Driver's details: ");

            Console.Write("Enter the driver's first name: ");
            string driver_first_name = Console.ReadLine();

            Console.Write("Enter the driver's last name: ");
            string driver_last_name = Console.ReadLine();

            Console.Write("Enter the driver's date of birth in the format YYYY.MM.DD: ");
            string driver_DOB = Console.ReadLine();

            Console.Write("Enter the deriver's license number: ");
            string driver_license_nbr = Console.ReadLine();

            string total_price = total_rental_price.ToString();

            string driver_details = $"{driver_first_name}/{driver_last_name}/{driver_DOB}/{driver_license_nbr}/Total_price:{total_rental_price}$";
            return driver_details;
        }


        // Purpose: Update the total rental price in case a reservation is modified by the customer:
        // double total_rental_price: calculated by muultiplying daily_rental_price by number_of_days
        // Scheule new_schedule: new reservation date of the customer w/ a pick_up_date and a drop_off_date
        public void Update_Total_Price(double total_rental_price, Schedule new_schedule)
        {
            string total_price = $"Total_price:{total_rental_price.ToString()}$";

            // Update values in the dictionary
            foreach (var kvp in reservation_detail.ToList()) // ToList to create a copy of the dictionary while iterating
            {
                Schedule schedule = kvp.Key;
                string originalValue = kvp.Value;

                if (schedule.Get_Pick_Up() == new_schedule.Get_Pick_Up() && schedule.Get_Drop_Off() == new_schedule.Get_Drop_Off())
                {
                    int lastSlashIndex = originalValue.LastIndexOf('/');

                    if (lastSlashIndex != -1)
                    {
                        // If '/' is found, replace the substring after it with the replacement string
                        string updatedValue = originalValue.Substring(0, lastSlashIndex + 1) + total_price;

                        // Update the dictionary with the modified value
                        reservation_detail[schedule] = updatedValue;
                    }

                }
            }
        }



        // Purpose: Display every reservations for a particular vehicle in order according to their pick_up_date
        public void Display_Order_Reservations()
        {
            if (reservation_detail.Count != 0)
            {
                var sortedReservationDetails = reservation_detail
                .OrderBy(x => x.Key.Get_Pick_Up())
                .ToDictionary(x => x.Key, x => x.Value);

                // Sorted reservations;
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("Sorted Reservation Details:");
                foreach (var kvp in sortedReservationDetails)
                {
                    Console.WriteLine($"Key: PickUpDate={kvp.Key.Get_Pick_Up()}, DropOffDate={kvp.Key.Get_Drop_Off()}, Value: {kvp.Value}");
                }
                Console.ResetColor();
            }

            else
            {
                // Case where registration_list is empty.
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("The vehicle has no reservations!");
                Console.ResetColor();
            }
        }




        // Purpose: The registration_nbr is uniquely attributed by the Random Class provided by the System namespace;
        // Registration_nbr format: VV+6characters(Numbers or Capital letters).
        public void Generate_VehicleID()
        {
            Random random = new Random();
            const string characters = "0123456789ABCDEFGHIFKLMNOPQRSTUVWXYZ";
            char[] vehicle_ID_Array = new char[6];

            // Set the first 2 characters to 'V';
            vehicle_ID_Array[0] = 'V';
            vehicle_ID_Array[1] = 'V';

            // Appends 4 random characters to the vehicle_ID_Array;
            for (int i = 2; i < vehicle_ID_Array.Length; i++)
            {
                vehicle_ID_Array[i] = characters[random.Next(characters.Length)];
            }

            // Copy the registration_nbr stored in the array into the Vehicle's attribute 'Registration_nbr'
            this.registratiion_nbr = new string(vehicle_ID_Array);
        }



        // Purpose: Display the maker, model, registration nbr, type and daily rental price of a car;
        public void Display_Features()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine($"Maker: {Get_Maker()}");
            Console.WriteLine($"Model: {Get_Model()}");
            Console.WriteLine($"Registration nbr: {Get_Registration()}");
            Console.WriteLine($"The type of vehicle is: {GetType()}");
            Console.WriteLine($"Daily Rental price: {Get_Rental_Price()}");
            Console.ResetColor();
        }



        // Purpose: Remove a reservation in the reservation_detail dictionary of a particular_vehicle
        // Scheule reservation_to_delete: Reservation the customer wants to delete from the dictionnary.
        // Returns true: Reservation was successfully deleted
        // Return false: Reservation couldn't be deleted
        public bool Remove_Reservation(Schedule reservation_to_delete)
        {
            // Case where the reservation list isn't empty (Contains reservations)
            if (reservation_detail.Count != 0)
            {
                // Assess whether a Schedule 'pick_up_date' and 'Drop_off_date' match the one entered by the user 'reservation_to_delete'.
                // If true, deletes the reservation using the key.
                foreach (var kvp in reservation_detail.ToList()) // Use ToList to create a copy of the dictionary while iterating
                {
                    if (kvp.Key.Get_Pick_Up() == reservation_to_delete.Get_Pick_Up() &&
                        kvp.Key.Get_Drop_Off() == reservation_to_delete.Get_Drop_Off())
                    {
                        reservation_detail.Remove(kvp.Key);
                        this.Display_Order_Reservations();
                        //Console.WriteLine($"The following reservation got removed {reservation_to_delete.Get_Pick_Up()}, {reservation_to_delete.Get_Drop_Off()}");
                        return true;
                    }
                }
            }
            // Case where the reservation list is empty (Doesn't contain any reservations)
            return false;
        }




        // Purpose: Assess whether two dates reservations overlap;
        // Schedule date: date entered by the customer to assess if it overlap with a reservation in the dictionary of a vehicle
        // Returns true: It overlaps
        // Returns false: It doesn't overlap
        public bool Does_Overlap_V2(Schedule date)
        {
            // Iterates through each keys in reservation list;
            foreach (var kvp in reservation_detail)
            {
                // Case where pick up date and drop off date overlaps with one from the reservation list
                // Ex-1 PUD1: 2023/12/12, DOD1: 2023/12/16 -- PUD2: 2023/12/13, DOD2: 2023/12/14
                if ((date.Get_Pick_Up() >= kvp.Key.Get_Pick_Up()) && (date.Get_Drop_Off() <= kvp.Key.Get_Drop_Off()))
                {
                    return true;
                }

                // Case where pick up date overlaps with a date in reservation list:
                // Ex-1 PUD1: 2023/12/12, DOD1: 2023/12/16 -- PUD2: 2023/12/13, DOD2: 2023/12/19
                // Ex-2 PUD1: 2023/12/12, DOD1: 2023/12/16 -- PUD2: 2023/12/13, DOD2: 2023/12/14
                else if ((date.Get_Pick_Up() >= kvp.Key.Get_Pick_Up()) && (date.Get_Pick_Up() <= kvp.Key.Get_Drop_Off() || date.Get_Pick_Up() < kvp.Key.Get_Pick_Up()))
                {
                    return true;
                }

                // Case where drop off date overlaps with a date in reservation list:
                // Ex-1 PUD1: 2023/12/12, DOD1: 2023/12/16 -- PUD2: 2023/12/09, DOD2: 2023/12/25
                // Ex-2 PUD1: 2023/12/12, DOD1: 2023/12/16 -- PUD2: 2023/12/09, DOD2: 2023/12/14
                else if ((date.Get_Pick_Up() < kvp.Key.Get_Pick_Up()) && (date.Get_Drop_Off() >= kvp.Key.Get_Drop_Off() || date.Get_Drop_Off() >= kvp.Key.Get_Pick_Up()))
                {
                    return true;
                }
            }

            // Case where the reservation list is empty (No reservation)
            return false;
        }



        // Purpose:Modify a reservation in the reservation list for a specific Vehicle.
        // Schedule oldSchedule: Old reservation the customer wants to modify
        // Schedule newSchedule: New reservation the customer wants to implement
        // Returns true: Modification was successfully made;
        // Returns false: Moification coudn't be done
        public bool Modify_Reservation_V3(Schedule oldSchedule, Schedule newSchedule)
        {
            // Case where the reservation list isn't empty (Contains reservations)
            if (reservation_detail.Count != 0)
            {
                // Create a new dictionary to store modified reservations
                Dictionary<Schedule, string> modifiedReservations = new Dictionary<Schedule, string>();

                // Assess whether a Schedule 'pick_up_date' and 'Drop_off_date' match the one entered by the user 'oldSchedule'
                foreach (var kvp in reservation_detail)
                {
                    if (kvp.Key.Get_Pick_Up() == oldSchedule.Get_Pick_Up() && kvp.Key.Get_Drop_Off() == oldSchedule.Get_Drop_Off())
                    {
                        // If true, replace 'oldSchedule' by 'newSchedule' in the new dictionary
                        string customer_detail = kvp.Value;
                        modifiedReservations.Add(newSchedule, customer_detail);
                    }
                    else
                    {
                        // If not matching, add the existing reservation to the new dictionary as it is
                        modifiedReservations.Add(kvp.Key, kvp.Value);
                    }
                }

                // Update the original reservation_detail with the modified reservations
                reservation_detail = modifiedReservations;

                return modifiedReservations.Count > 0; // Return true if any modification occurred
            }

            // Case where the reservation list is empty (Doesn't contain any reservations)
            // Console.WriteLine("Can't change reservation knowing the list doesn't contain any reservations! ");
            return false;
        }

    }
}

