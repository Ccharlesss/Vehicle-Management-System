using System;
namespace Completed_coursework
{
	public class WestminsterRentalVehicless : IRentalManager, IRentalCustomer
    {
        static int nbr_vehicle = 0;
        static List<Vehicle> vehicles_list = new List<Vehicle>();

        public WestminsterRentalVehicless()
        {

        }


        // Purpose: Add a new Vehicle in the vehicle_list only if it isn't full. (Use static attribute 'nbr_vehicle' To determine whether system is full);
        // Vehicle v: Reference type to a vehicle
        // Return True: Vehicule successfully added to the system
        // Return False: Vehicule coudn't be added to the system
        public bool Add_Vehicle(Vehicle v)
        {
            // In case the vehicle_list is full ( nbr_vehicle == 50); Display error message.
            if (nbr_vehicle == 50)
            {
                return false;
            }

            // In case the vehicle_list isn't full (<50) Add the vehicle.
            vehicles_list.Add(v);

            // Increment the static attribute 'nbr_vehicle' by 1.
            nbr_vehicle++;
            return true;
        }



        // Purpose: Delete a Vehicle in the list given its registration_nbr;
        // string v_reg_nbr: vehicule registration number
        // Return true: Vehicule was successfully deleted
        // Return false: Vehicule coudn't be deleted
        public bool Delete_Vehicle(string v_reg_nbr)
        {
            // Case where the company owns vehicles ('nbr_vehicle' > 0): => Can delete a vehicle only if 'registration_nbr' matches one on the 'vehicles_list'.
            if (nbr_vehicle != 0)
            {
                foreach (Vehicle v in vehicles_list)
                {
                    if (v.Get_Registration() == v_reg_nbr)
                    {
                        // If 'registration_nbr' matches one on 'vehicles_list', remove the vehicle.
                        vehicles_list.Remove(v);
                        // Decrement the static attribute 'nbr_vehicle' by 1 to update the current nbr of vehicles own by the company.
                        nbr_vehicle--;
                        Console.WriteLine($"The car w/ the registration nbr {v_reg_nbr} got deleted! \n");
                        return true;
                    }
                }
            }

            // Case where company doesn't own any vehicles ('nbr_vehicle'  == 0): => Can't delete a vehicle that doesn't exist.
            else if (nbr_vehicle == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The company doesn't own any vehicles!");
                Console.ResetColor();
                return false;
            }

            // Case where the 'regostration_nbr' doesn't match one from the 'vehicles_list'.
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"The registratuon number: {v_reg_nbr} doesn't match! \n");
            Console.ResetColor();
            return false;
        }



        // Purpose: List all the current vehicle owned by the company w/ information converning vehicule + information concerning reservation
        // Info concerning vehicule: 'Maker'/'Model'/'Registration_nbr'/'Rental_price'/ 'Type'
        // Info converrning reservation: Key {pick_up_date and drop_off_date} value {driver_fname/river_lname/DOB/license_nbr/total_price$}
        public void List_Vehicle()
        {
            // Case where the company owns vehicles ('nbr_vehicle' > 0).
            if (nbr_vehicle != 0)
            {
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"WestminsterRentalVehicle owns {nbr_vehicle} Vehicles.");
                Console.WriteLine("We own the following vehicle: ");
                Console.WriteLine("=======================================");
                foreach (Vehicle v in vehicles_list)
                {
                    v.Display_Features();
                    v.Display_Order_Reservations();
                    Console.WriteLine("=======================================");
                }
                Console.ResetColor();
            }

            // Case where company doesn't own any vehicles ('nbr_vehicle'  == 0)
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The company doesnt own any vehicles!");
                Console.ResetColor();

            }
        }



        // Purpose Display the vehicle owned by the company according to its maker in alphabetic order w/ information converning vehicule + information concerning reservation;
        // Info concerning vehicule: 'Maker'/'Model'/'Registration_nbr'/'Rental_price'/ 'Type'
        // Info converrning reservation: Key {pick_up_date and drop_off_date} value {driver_fname/river_lname/DOB/license_nbr/total_price$}
        public void List_Ordered_Vehicle()
        {
            // company must own more than 1 vehicle
            if (nbr_vehicle != 0 && vehicles_list.Count > 1)
            {
                List<Vehicle> ordered_list = new List<Vehicle>(vehicles_list);
                ordered_list.Sort(new MyComparer());
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Ordered Vehicle are:");
                Console.WriteLine("⊵⊵⊵⊵⊵⊵⊵⊵⊵⊵⊵⊵⊵⊵⊵⊵⊵⊵⊵⊵⊵⊵⊵⊵");
                Console.WriteLine("");


                foreach (Vehicle v in ordered_list)
                {
                    v.Display_Features();
                    v.Display_Order_Reservations();
                    Console.WriteLine("\n");
                }
                Console.ResetColor();
            }

            // Case where company doesn't own any vehicles ('nbr_vehicle'  == 0)
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The company doesnt own any vehicles!");
                Console.ResetColor();
            }
        }



        // Purpose: Overwrite a file entered by the user with all the current Vehicles in the garage w/ their current information
        // If the file exist, it will overwrite it, if it doesn't exist, it will create it.
        // Written file will be placed in the folder called 'Project' in the desktop.
        public void Generate_report(string file_name)
        {
            try
            {
                // Generate the path where the report file will be written on the desktop.
                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Completed_courseworkk", file_name);

                // Open a StreamWriter to write to the file, and ensure it appends to existing content.
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    // Write the header of the report to the file.
                    writer.WriteLine("Here is the report on the current vehicles possessed by the company: \n");

                    // Iterate through the vehicles in the list.
                    foreach (Vehicle v in vehicles_list)
                    {
                        // Create a new StringWriter to capture the output of the display method.
                        StringWriter reservationsOutput = new StringWriter();

                        // Redirect the standard output to the reservationsOutput StringWriter.
                        Console.SetOut(reservationsOutput);

                        // Call the display method and capture the output.
                        v.Display_Order_Reservations();

                        // Restore the standard output to its original state.
                        Console.SetOut(Console.Out);

                        // Write vehicle details and captured output to the file.
                        writer.WriteLine($"Maker: {v.Get_Maker()}");
                        writer.WriteLine($"Model: {v.Get_Model()}");
                        writer.WriteLine($"Registration Number: {v.Get_Registration()}");
                        writer.WriteLine($"Rental Price: {v.Get_Rental_Price()}");
                        writer.WriteLine("Reservations:");
                        writer.WriteLine(reservationsOutput.ToString());
                        writer.WriteLine("\n");
                    }
                }
                Console.WriteLine("File appended successfully.");
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during the process.
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }



        // Purpose: List all the available vehicle to rent according to a particular schedule and type;
        // Info concerning vehicule: 'Maker'/'Model'/'Registration_nbr'/'Rental_price'/ 'Type'
        // Info converrning reservation: Key {pick_up_date and drop_off_date} value {driver_fname/river_lname/DOB/license_nbr/total_price$}
        public void List_Available_Vehicle(Schedule wantedSchedule, Type type)
        {
            if (nbr_vehicle != 0)
            {
                foreach (Vehicle v in vehicles_list)
                {
                    if (v.GetType() == type && !v.Does_Overlap_V2(wantedSchedule))
                    {
                        v.Display_Features();
                        v.Display_Order_Reservations();
                    }
                }
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The company doesn't own any vehicles! ");
                Console.ResetColor();
            }
        }



        // Purpose: Add a reservation on a vehicle for a particular date based on a vehicule registration number entered by the user;
        // string v_reg_nbr: Vehicule registration number
        // Schedule wantedSchedule: reservation that the customer enters with a pick up an drop off date.
        // Returns true: Reservation was successfully added
        // Return false: Reservation coudn't be added
        public bool Add_Reservation(string v_reg_nbr, Schedule wantedSchedule)
        {

            if (nbr_vehicle != 0)
            {
                foreach (Vehicle v in vehicles_list)
                {
                    // Check if 'registration_nbr' entered by the user matches one on the 'vehicles_list'.
                    // Also assess if the schedule entered by the user doesn't overlap with one from the reservation_list tied to a specific vehicle
                    if (v.Get_Registration() == v_reg_nbr && !v.Does_Overlap_V2(wantedSchedule))
                    {

                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("The Date entered does not overlapp with other reservations \n");
                        Console.ResetColor();

                        double daily_rental_price = v.Get_Rental_Price();
                        int nbr_days = wantedSchedule.Calculate_Nbr_Days(wantedSchedule.Get_Pick_Up(), wantedSchedule.Get_Drop_Off());
                        double total_price = daily_rental_price * nbr_days;
                        Console.WriteLine($"The total price is: {total_price}");

                        // Add the schedule to the vehicle's reservation_list
                        string drivers_data = v.Get_driver_data(total_price);
                        v.Add_Reservation_And_Detail(drivers_data, wantedSchedule);
                        Console.WriteLine("Reservation was added for the following vehicle");
                        Console.WriteLine($"{v.Get_Maker()}/{v.Get_Model()}/{v_reg_nbr}");
                        return true;
                    }


                    else if (v.Get_Registration() == v_reg_nbr && v.Does_Overlap_V2(wantedSchedule))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("The Date entered overlapp with other reservations \n");
                        Console.ResetColor();
                        return false;
                    }

                }
            }

            // If there is an overlap or no vehicle could be found.
            Console.WriteLine("No reservation could be done for the vehicle");
            return false;
        }



        // Purpose: Change reservation for a specific vehicle for a particular schedule. Vehicle is selected based on a 'registration_nbr' entered by the user
        // string v_reg_nbr: Vehicule registration number
        // Schedule oldSchedule: old reservation that the customer wants to change
        // Schedule newSchedule: new reservation that the customer wants with a pick up an drop off date.
        // Returns true: The reservation was successfully modified
        // Returns false: The reservation couldn't be modified
        public bool Change_Reservation(string v_reg_nbr, Schedule oldSchedule, Schedule newSchedule)
        {
            if (nbr_vehicle != 0)
            {
                foreach (Vehicle v in vehicles_list)
                {
                    // Check if 'registration_nbr' entered by the user matches one on the 'vehicles_list'.
                    // Also assess if the schedule entered by the user doesn't overlap with one from the reservation_list tied to a specific vehicle.
                    if (v.Get_Registration() == v_reg_nbr && !v.Does_Overlap_V2(newSchedule))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("The Date entered does not overlapp with other reservations \n");
                        Console.ResetColor();
                        // If 'olScheule' has been found on the reservation_list, replace it by the 'newSchedule.
                        // Return true to indicate the reservation has been modified.
                        if (v.Modify_Reservation_V3(oldSchedule, newSchedule))
                        {
                            //Console.WriteLine($"Reservation has been changed to {newSchedule.Get_Pick_Up()} {newSchedule.Get_Drop_Off()}");
                            double daily_rental_price = v.Get_Rental_Price();
                            int nbr_days = newSchedule.Calculate_Nbr_Days(newSchedule.Get_Pick_Up(), newSchedule.Get_Drop_Off());
                            double total_price = daily_rental_price * nbr_days;
                            Console.WriteLine($"The total price is: {total_price}");
                            v.Update_Total_Price(total_price, newSchedule);

                            return true;
                        }

                        // Return false to inicate the reservation with 'oldSchedule' hasn't been found on the reservation_list.
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("No Reservation has been found! ");
                        Console.ResetColor();
                        return false;
                    }

                    else if (v.Get_Registration() == v_reg_nbr && v.Does_Overlap_V2(newSchedule))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("The Date entered overlapp with other reservations \n");
                        Console.ResetColor();
                        return false;
                    }

                }

                // In case the 'registration_nbr' doesn't mach one on the 'vehicles_list'.
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"The following registration nbr: {v_reg_nbr} was not found on the list");
                Console.ResetColor();
                return false;
            }

            // In case the company d0esn't own any vehicles.
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The Company doesn't own any behicle! ");
            Console.ResetColor();
            return false;
        }



        // Purpose: Remove a reservation for a specific vehicle on a particular schedule vehicle is selected based on a 'registration_nbr' entered by the user;
        // string v_reg_nbr: Vehicule registration number
        // Schedule oldSchedule: old reservation that the customer wants to delete.
        public bool Delete_Reservation(string v_reg_nbr, Schedule wantedSchedule)
        {
            if (nbr_vehicle != 0)
            {
                foreach (Vehicle v in vehicles_list)
                {
                    if (v.Get_Registration() == v_reg_nbr)
                    {
                        // In case 'registration_nbr' matches one on the 'vehicles_list'
                        // If 'wantedSchedule' matches a schedule on the vehicle's reservation_list, return true and removes it from the list
                        if (v.Remove_Reservation(wantedSchedule))
                        {
                            //Console.WriteLine($"The following reservation got removed {wantedSchedule.Get_Pick_Up()}, {wantedSchedule.Get_Drop_Off()}");
                            return true;
                        }

                        // Return false if 'wantedSchedule' doesn't match any schedule on the vehicle's reservation_list
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"No reservation matches the following schedule: {wantedSchedule.Get_Pick_Up()}, {wantedSchedule.Get_Drop_Off()}");
                        Console.ResetColor();
                        return false;
                    }
                }
                // In case the 'registration_nbr' doesn't mach one on the 'vehicles_list'.
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"The following registration nbr: {v_reg_nbr} was not found on the list");
                Console.ResetColor();
                return false;
            }
            // In case the company d0esn't own any vehicles.
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The company can't delete a reservation since it doesn't own any vehicles! ");
            Console.ResetColor();
            return false;
        }
    }
}

