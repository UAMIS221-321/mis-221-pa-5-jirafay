using mis_221_pa_5_jirafay;
class Program
{
    static void Main(string[] args)
    {
        TrainerApp app = new TrainerApp();
        ListingsApp app2 = new ListingsApp();
        bool exit = false;

        do {
            Console.WriteLine("Welcome to Train Like A Champion - Personal Fitness");
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. Manage Trainers");
            Console.WriteLine("2. Manage Listings");
            Console.WriteLine("3. Manage Customer Bookings");
            Console.WriteLine("4. Run Reports");
            Console.WriteLine("5. Exit");

            string userInput = Console.ReadLine();

            switch (userInput) {
                case "1":
                    // Call method in TLACApp to manage trainers
                    app.ManageTrainers();
                    break;
                case "2":
                    // Call method in ListingsApp to manage listings
                    app2.Run();
                    break;
                case "3":
                    // Call method in TLACApp to manage customer bookings
                    //app.ManageBookings();
                    break;
                case "4":
                    // Call method in TLACApp to run reports
                    //app.RunReports();
                    break;
                case "5":
                    // Exit the application
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid input. Please try again.");
                    break;
            }

        } while (!exit);
    }
}