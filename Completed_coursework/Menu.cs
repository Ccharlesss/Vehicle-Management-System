using System;
namespace Completed_coursework
{
    public class Menu
    {
        public Menu()
        {
        }

        // Purpose: Display a fun welcome message when the program is launched;
        public static void Display_Sarting_Screen()
        {
            Console.WriteLine("▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂");
            Console.WriteLine("▌                                                                                                   ▌");
            Console.WriteLine("▌ ||    //\\    ||  ||====  ||      ||=====   0000000  MMMMMMMMM  {{~~~~                             ▌");
            Console.WriteLine("▌ ||   //  \\   ||  ||      ||      ||        0     0  M   M   M  {{                                 ▌");
            Console.WriteLine("▌ ||  //    \\  ||  ||====  ||      ||        0     0  M   M   M  {{~~~~                             ▌");
            Console.WriteLine("▌ || //      \\ ||  ||      ||      ||        0     0  M   M   M  {{                                 ▌");
            Console.WriteLine("▌ ||//        \\||  ||====  ||====  ||=====   0000000  M   M   M  {{~~~~                             ▌");
            Console.WriteLine("▌                                                                                                   ▌");
            Console.WriteLine("▌ TTTTTTTTTT  OOOOOOOOO                                                                             ▌");
            Console.WriteLine("▌   TTT     OO       OO                                                                             ▌");
            Console.WriteLine("▌   TTT     OO       OO                                                                             ▌");
            Console.WriteLine("▌   TTT     OO       OO                                                                             ▌");
            Console.WriteLine("▌   TTT      OOOOOOOOO                                                                              ▌");
            Console.WriteLine("▌                                                                                                   ▌");
            Console.WriteLine("▌ ||    //\\    ||  ||====  SSSSSS  MMMMMMMMM  IIIIIIII  NNNN    NN  SSSSSS TTTTTTT ||====  RRRRRRR  ▌");
            Console.WriteLine("▌ ||   //  \\   ||  ||      SS      M   M   M     II     NN NN   NN  SS        T    ||      RR   RR  ▌");
            Console.WriteLine("▌ ||  //    \\  ||  ||====  SSSSSS  M   M   M     II     NN  NN  NN  SSSSSS    T    ||====  RR RRRR  ▌");
            Console.WriteLine("▌ || //      \\ ||  ||          SS  M   M   M     II     NN   NN NN      SS    T    ||      RR  RR   ▌");
            Console.WriteLine("▌ ||//        \\||  ||====  SSSSSS  M   M   M  IIIIIIII  NN    NNNN  SSSSSS    T    ||====  RR    RR ▌");
            Console.WriteLine("▌                                                                                                   ▌");
            Console.WriteLine("▌ RRRRRRR  $$$$$$  $$$$    $$ $$$$$$$$  $$      $$                                                  ▌");
            Console.WriteLine("▌ RR   RR  $$      $$ $$   $$    $     $$ $$    $$                                                  ▌");
            Console.WriteLine("▌ RR RRRR  $$$$$$  $$  $$  $$    $    $$   $$   $$                                                  ▌");
            Console.WriteLine("▌ RR  RR   $$      $$   $$ $$    $   $$$$$$$$$  $$                                                  ▌");
            Console.WriteLine("▌ RR   RR  $$$$$$  $$    $$$$    $  $$       $$ $$$$$$  TM                                          ▌");
            Console.WriteLine("▌                                                                                                   ▌");
            Console.WriteLine("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
            Console.WriteLine("");
        }


        // Putpose: Display loggin menu;
        public static void Loggin_Menu()
        {
            Console.WriteLine("╔══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                      Logging Menu                            ║");
            Console.WriteLine("╠══════════════════════════════════════════════════════════════╣");
            Console.WriteLine("║          'Admin':       Log in admin menu                    ║");
            Console.WriteLine("║          'Customer':    Log in customer menu                 ║");
            Console.WriteLine("║          'Exit':        Exit the program                     ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════╝");
            Console.Write("Select a command: ");
        }


        // Purpose: Display Admin's menu w/ all commands;
        public static void Display_Admin_Menu()
        {
            Console.WriteLine("╔══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                       ADMIN MENU                             ║");
            Console.WriteLine("╠══════════════════════════════════════════════════════════════╣");
            Console.WriteLine("║  1) Add Vehicle          4) List vehicles in alphabetic order║");
            Console.WriteLine("║  2) Delete Vehicle       5) Generate a report                ║");
            Console.WriteLine("║  3) List Vehicles        6) Exit Admin's menu                ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════╝");
        }


        // Putpose: Display Customer's menu w/ all commands;
        public static void Display_Customer_Menu()
        {
            Console.WriteLine("╔══════════════════════════════════════════════════╗");
            Console.WriteLine("║                  Customer MENU                   ║");
            Console.WriteLine("╠══════════════════════════════════════════════════╣");
            Console.WriteLine("║  1) List Available Vehicles                      ║");
            Console.WriteLine("║  2) Add a reservation                            ║");
            Console.WriteLine("║  3) Change a reservation                         ║");
            Console.WriteLine("║  4) Delete a reservation                         ║");
            Console.WriteLine("║  5) Back to loggin menu                          ║");
            Console.WriteLine("╚══════════════════════════════════════════════════╝");
        }



        // Purpose: Display all types of Vehicules for the admin in case he wants to add a new vehicule;
        public static void Display_Vehicle_type()
        {
            Console.WriteLine("");
            Console.WriteLine("╔═════════════════════════════════════════════════════╗");
            Console.WriteLine("║                Vehicle Types                        ║");
            Console.WriteLine("╠═════════════════════════════════════════════════════╣");
            Console.WriteLine("║   car:       Car                                    ║");
            Console.WriteLine("║   electric:  Electric Car                           ║");
            Console.WriteLine("║   truck:     Truck                                  ║");
            Console.WriteLine("║   moto:      Motorbike                              ║");
            Console.WriteLine("╚═════════════════════════════════════════════════════╝");
        }



        // Purpose: Get the vehicule's type from the user to list the all available vehicules type on the system;
        public static Type Get_type()
        {
            Console.WriteLine("");
            Console.WriteLine("╔═════════════════════════════════════════════════════╗");
            Console.WriteLine("║               Vehicle Types                         ║");
            Console.WriteLine("╠═════════════════════════════════════════════════════╣");
            Console.WriteLine("║ 1. Car                                              ║");
            Console.WriteLine("║ 2. Electric Car                                     ║");
            Console.WriteLine("║ 3. Truck                                            ║");
            Console.WriteLine("║ 4. Motorbike                                        ║");
            Console.WriteLine("╚═════════════════════════════════════════════════════╝");
            Console.Write("Select the type of Vehicle: ");
            string v_type = Console.ReadLine();

            switch (v_type)
            {
                case "1":
                    v_type = "Completed_coursework.Car";
                    Type car_type = Type.GetType(v_type);
                    return car_type;
                    break;


                case "2":
                    v_type = "Completed_coursework.Electric_Car";
                    Type ecar_type = Type.GetType(v_type);
                    return ecar_type;
                    break;


                case "3":
                    v_type = "Completed_coursework.Truck";
                    Type truk_type = Type.GetType(v_type);
                    return truk_type;
                    break;

                case "4":
                    v_type = "Completed_coursework.MotorBike";
                    Type moto_type = Type.GetType(v_type);
                    return moto_type;
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error! Must enter a number between 1-4:");
                    Console.ResetColor();
                    break;
            }
            return null;
        }



        // Purpose: Get file name from the admin when generate a report is selected;
        public static string Get_file_name()
        {
            Console.Write("Enter a file name where you wish to store the list of vehicules: ");
            string admin_input = Console.ReadLine();
            return admin_input;
        }



        // Purpose: Get vehicul's id from the user;
        public static string Get_V_ID()
        {
            Console.Write("Enter a 6 character ID starting w/ 'VV': ");
            string id = Console.ReadLine();
            return id;
        }



        // Purpose: Enable the admin to initialize a car to add it in the system;
        public static Car Initialize_Car()
        {
            Car new_car = new Car();

            // Get the Vehicle's maker from the admin;
            Console.Write("Enter the vehicle's maker: ");
            string v_maker = Console.ReadLine();
            new_car.Set_Maker(v_maker);

            // Get the Vehicle's Model from the admin;
            Console.Write("Enter the vehicle's model: ");
            string v_model = Console.ReadLine();
            new_car.Set_Model(v_model);

            // Get the Vehicle's daily rental price from the admin;
            Console.Write("Enter the daily rental price in $: ");
            string v_rental_price = Console.ReadLine();
            new_car.Set_Rental_Price(v_rental_price);

            // Set the Vehicle's ID;
            new_car.Generate_VehicleID();

            return new_car;
        }


        // Purpose: Enable the admin to initialize an electric car to add it in the system;
        public static Electric_Car Initialize_Ecar()
        {
            Electric_Car new_Ecar = new Electric_Car();

            // Get the Vehicle's maker from the admin;
            Console.Write("Enter the vehicle's maker: ");
            string v_maker = Console.ReadLine();
            new_Ecar.Set_Maker(v_maker);

            // Get the Vehicle's Model from the admin;
            Console.Write("Enter the vehicle's model: ");
            string v_model = Console.ReadLine();
            new_Ecar.Set_Model(v_model);

            // Get the Vehicle's daily rental price from the admin;
            Console.Write("Enter the daily rental price in $: ");
            string v_rental_price = Console.ReadLine();
            new_Ecar.Set_Rental_Price(v_rental_price);

            // Set the Vehicle's ID;
            new_Ecar.Generate_VehicleID();

            return new_Ecar;
        }


        // Purpose: Enable the admin to initialize a truck to add it in the system;
        public static Truck Initialize_Truck()
        {
            Truck new_vtruck = new Truck();

            // Get the Vehicle's maker from the admin;
            Console.Write("Enter the vehicle's maker: ");
            string v_maker = Console.ReadLine();
            new_vtruck.Set_Maker(v_maker);

            // Get the Vehicle's Model from the admin;
            Console.Write("Enter the vehicle's model: ");
            string v_model = Console.ReadLine();
            new_vtruck.Set_Model(v_model);

            // Get the Vehicle's daily rental price from the admin;
            Console.Write("Enter the daily rental price in $: ");
            string v_rental_price = Console.ReadLine();
            new_vtruck.Set_Rental_Price(v_rental_price);

            // Set the Vehicle's ID;
            new_vtruck.Generate_VehicleID();

            return new_vtruck;
        }


        // Purpose: Enable the admin to initialize a motorbike to add it in the system;
        public static Motorbike Initialize_Motorbike()
        {
            Motorbike new_vmoto = new Motorbike();

            // Get the Vehicle's maker from the admin;
            Console.Write("Enter the vehicle's maker: ");
            string v_maker = Console.ReadLine();
            new_vmoto.Set_Maker(v_maker);

            // Get the Vehicle's Model from the admin;
            Console.Write("Enter the vehicle's model: ");
            string v_model = Console.ReadLine();
            new_vmoto.Set_Model(v_model);

            // Get the Vehicle's daily rental price from the admin;
            Console.Write("Enter the daily rental price in $: ");
            string v_rental_price = Console.ReadLine();
            new_vmoto.Set_Rental_Price(v_rental_price);

            // Set the Vehicle's ID;
            new_vmoto.Generate_VehicleID();

            return new_vmoto;
        }


        // Purpose: Get all the information from the customer regarding an the creation of a new reservation for a vehicle;
        public static Schedule Create_Customer_reservation()
        {
            Schedule new_reservation = new Schedule();
            Console.Write("Enter a pick up date in the format YYYY/MM/DD: ");
            string pick_up = Console.ReadLine();
            new_reservation.Set_Pick_Up(pick_up);

            Console.Write("Enter a Drop off date in the format YYYY/MM/DD: ");
            string drop_off = Console.ReadLine();
            new_reservation.Set_Drop_Off(drop_off);

            return new_reservation;
        }



        // Purpose: Get all the information from the customer regarding an old reservation to modify for a vehicle;
        public static Schedule Get_Old_Reservation()
        {
            Schedule old_reservation = new Schedule();
            Console.Write("Enter an old pick up date you want to change in the format YYYY/MM/DD: ");
            string pick_up = Console.ReadLine();
            old_reservation.Set_Pick_Up(pick_up);

            Console.Write("Enter an old Drop off date you want to change in the format YYYY/MM/DD: ");
            string drop_off = Console.ReadLine();
            old_reservation.Set_Drop_Off(drop_off);

            return old_reservation;
        }



        // Purpose: Get all the information from the customer regarding a reservation to delete for a vehicle;
        public static Schedule Get_Reservation_to_Delete()
        {
            Schedule reservation_to_del = new Schedule();

            Console.Write("Enter a pick up date you want to remove in the format YYYY/MM/DD: ");
            string pick_up = Console.ReadLine();
            reservation_to_del.Set_Pick_Up(pick_up);

            Console.Write("Enter an Drop off date you want to remove in the format YYYY/MM/DD: ");
            string drop_off = Console.ReadLine();
            reservation_to_del.Set_Drop_Off(drop_off);


            return reservation_to_del;
        }


        // Purpose: Display a successful entry message when a new vehicle is added into the system;
        public static void Display_System_Entry(Vehicle v)
        {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("===============================================");
            Console.WriteLine("      Vehicle Successfully Added to System     ");
            Console.WriteLine("===============================================");
            v.Display_Features();
            Console.ResetColor();
            Console.WriteLine("");
        }


        // Purpose: Display an error message when the admin attempts to add a new vehicle when the system is full;
        public static void Display_Entry_Error()
        {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("   Parking is full, no more vehicles can be added! ");
            Console.WriteLine("-------------------------------------------------");
            Console.ResetColor();
            Console.WriteLine("");
        }
    }
}

