namespace Completed_coursework;

class Program
{
    static void Main(string[] args)
    {
        // Instantiation of vehicles for the company
        Car sport_car1 = new Car("Lamborghini", "Huracan", 550);
        sport_car1.Generate_VehicleID();

        Truck truck_1 = new Truck("Renault", "T-High", 400.2);
        truck_1.Generate_VehicleID();

        Motorbike moto_1 = new Motorbike("Vespa", "Dolce", 10.20);
        moto_1.Generate_VehicleID();

        Car car2 = new Car("Mazzeratti", "ESP-300", 300.50);
        car2.Generate_VehicleID();

        Electric_Car e_car_1 = new Electric_Car("Tesla", "Model-X", 150.50);
        e_car_1.Generate_VehicleID();

        Electric_Car e_car_2 = new Electric_Car("Tesla", "CyberTruck", 300);
        e_car_2.Generate_VehicleID();



        WestminsterRentalVehicless user = new WestminsterRentalVehicless();
        user.Add_Vehicle(sport_car1);
        user.Add_Vehicle(car2);
        user.Add_Vehicle(e_car_1);
        user.Add_Vehicle(moto_1);


        bool continue_display_menue = true; bool continue_session = true;
        Menu.Display_Sarting_Screen();

        // Prompt the user if he is an 'Admin' or a 'Customer':
        while (continue_session)
        {
            Menu.Loggin_Menu();
            string user_input = Console.ReadLine();

            // Clear the console
            Console.Clear();

            // User logs as Admin:
            if (user_input.Equals("Admin", StringComparison.OrdinalIgnoreCase))
            {
                while (continue_display_menue)
                {
                    Menu.Display_Admin_Menu();
                    Console.Write("Select a command: ");
                    string admin_input = Console.ReadLine();
                    Console.Clear();

                    switch (admin_input)
                    {

                        // Admin choose to add a 'Car';
                        case "1":
                            Menu.Display_Vehicle_type();
                            Console.Write("Which vehicle do you want to add: ");
                            string admin_answer = Console.ReadLine();
                            if (admin_answer.Equals("car", StringComparison.OrdinalIgnoreCase))
                            {
                                Car newly_added_car = new Car();
                                newly_added_car = Menu.Initialize_Car();

                                if (user.Add_Vehicle(newly_added_car))
                                {
                                    Menu.Display_System_Entry(newly_added_car);
                                }

                                else
                                {
                                    Menu.Display_Entry_Error();
                                }
                            }


                            // Admin chooses to add an 'Electric car';
                            else if (admin_answer.Equals("electric", StringComparison.OrdinalIgnoreCase))
                            {
                                Electric_Car new_ecar = new Electric_Car();
                                new_ecar = Menu.Initialize_Ecar();
                                if (user.Add_Vehicle(new_ecar))
                                {
                                    Menu.Display_System_Entry(new_ecar);
                                }

                                else
                                {
                                    Menu.Display_Entry_Error();
                                }

                            }


                            // Admin chooses to add a 'Truck';
                            else if (admin_answer.Equals("truck", StringComparison.OrdinalIgnoreCase))
                            {
                                Truck new_truck = new Truck();
                                new_truck = Menu.Initialize_Truck();

                                if (user.Add_Vehicle(new_truck))
                                {
                                    Menu.Display_System_Entry(new_truck);
                                }

                                else
                                {
                                    Menu.Display_Entry_Error();
                                }
                            }


                            // Admin chooses to add a 'Motorbike';
                            else if (admin_answer.Equals("moto", StringComparison.OrdinalIgnoreCase))
                            {
                                Motorbike new_moto = new Motorbike();
                                new_moto = Menu.Initialize_Motorbike();

                                if (user.Add_Vehicle(new_moto))
                                {
                                    Menu.Display_System_Entry(new_moto);
                                }

                                else
                                {
                                    Menu.Display_Entry_Error();
                                }
                            }

                            break;

                        // 2) Delete a vehicle;
                        case "2":
                            string vehicle_ID = Menu.Get_V_ID();
                            user.Delete_Vehicle(vehicle_ID);
                            break;

                        // 3) List vehicles owned by the company;
                        case "3":
                            user.List_Vehicle();
                            break;

                        // 4) List vehicles owned by the company in alphabetic order;
                        case "4":
                            user.List_Ordered_Vehicle();
                            break;


                        // 5) List vehicles owned by the company in a file;
                        case "5":
                            string file_name = Menu.Get_file_name();
                            user.Generate_report(file_name);
                            break;

                        // 6) Return back to the loggin;
                        case "6":
                            continue_display_menue = false;
                            break;

                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid input! must enter a digit btw 1-6");
                            Console.ResetColor();
                            break;
                    }
                }
                continue_display_menue = true;
            }



            // Case where user logs as a customer.
            else if (user_input.Equals("Customer", StringComparison.OrdinalIgnoreCase))
            {
                while (continue_display_menue)
                {
                    Menu.Display_Customer_Menu();
                    Console.Write("Select a command: ");
                    string customer_input = Console.ReadLine();


                    switch (customer_input)
                    {
                        // 1) List Available Vehicles;
                        case "1":
                            Type vehicle_type = Menu.Get_type();

                            Schedule customer_reservation = new Schedule();
                            customer_reservation = Menu.Create_Customer_reservation();
                            Console.WriteLine($"Type is {vehicle_type}");
                            user.List_Available_Vehicle(customer_reservation, vehicle_type);
                            break;


                        // 2) Add a reservation;
                        case "2":
                            string vehicule_reg_nbr = Menu.Get_V_ID();

                            Schedule reservation = new Schedule();
                            reservation = Menu.Create_Customer_reservation();
                            if (user.Add_Reservation(vehicule_reg_nbr, reservation))
                            {
                                Console.WriteLine("It worked!!!");
                            }

                            else
                            {
                                Console.WriteLine("It didnt work");
                            }


                            break;


                        // 3) Modify a reservation;
                        case "3":
                            // Get Vehicle ID from user.
                            vehicule_reg_nbr = Menu.Get_V_ID();

                            // Get the old reservation to change from the user.
                            Schedule old_reservation = new Schedule();
                            old_reservation = Menu.Get_Old_Reservation();
                            // Get the new reservation from the user.
                            Schedule new_reservation = new Schedule();
                            new_reservation = Menu.Create_Customer_reservation();

                            if (user.Change_Reservation(vehicule_reg_nbr, old_reservation, new_reservation))
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine($"Reservation has been changed to {new_reservation.Get_Pick_Up()} {new_reservation.Get_Drop_Off()}");
                                Console.ResetColor();
                            }

                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("No reservation Could be changed! ");
                                Console.ResetColor();
                            }
                            break;


                        // 4) Delete a reservation;
                        case "4":
                            // Get Vehicle ID from user.
                            vehicule_reg_nbr = Menu.Get_V_ID();

                            // Get the old reservation to change from the user.
                            Schedule reservation_to_delete = new Schedule();
                            reservation_to_delete = Menu.Get_Reservation_to_Delete();

                            if (user.Delete_Reservation(vehicule_reg_nbr, reservation_to_delete))
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine($"The following reservation got removed {reservation_to_delete.Get_Pick_Up()}, {reservation_to_delete.Get_Drop_Off()}");
                                Console.ResetColor();
                            }

                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("No reservation could be removed! ");
                                Console.ResetColor();
                            }
                            break;


                        // 5) Back to the loggin menue;
                        case "5":
                            continue_display_menue = false;
                            break;


                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid input! must enter a digit btw 1-6");
                            Console.ResetColor();
                            break;

                    }
                }
                continue_display_menue = true;
            }

            // Case where user wants to exit the program.
            else if (user_input.Equals("Exit", StringComparison.OrdinalIgnoreCase))
            {
                continue_session = false;
                break;
            }

            // Case where user enters the inadequat input.
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid output! Please enter 'Admin', 'Customer' or 'Exit'. ");
                Console.ResetColor();
            }


        }
    }
}

