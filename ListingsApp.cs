using mis_221_pa_5_jirafay;

public class Listing
{
    public int ID { get; set; }
    public string TrainerName { get; set; }
    public DateTime SessionDate { get; set; }
    public DateTime Time { get; set; }
    public decimal Cost { get; set; }
    public bool Taken { get; set; }

    public Listing(int id, string trainerName, DateTime date, DateTime time, decimal cost, bool taken)
    {
        ID = id;
        TrainerName = trainerName;
        SessionDate = date;
        Time = time;
        Cost = cost;
        Taken = taken;
    }

}
public class ListingsApp
{
    private const string FILE_NAME = "listings.txt";
    private List<Listing> listings;

    public ListingsApp()
    {
        listings = LoadListings();
    }

    public void Run()
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Select an option:");
            Console.WriteLine("1. Add a listing");
            Console.WriteLine("2. Edit a listing");
            Console.WriteLine("3. Delete a listing");
            Console.WriteLine("4. List all listings");
            Console.WriteLine("5. Exit");

            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    AddListing();
                    break;
                case "2":
                    EditListing();
                    break;
                case "3":
                    DeleteListing();
                    break;
                case "4":
                    ListAllListings();
                    break;
                case "5":
                    SaveListings();
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
    }

    private List<Listing> LoadListings()
    {
        List<Listing> listings = new List<Listing>();
        string filePath = FILE_NAME;
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Listings file not found!");
            return listings;
        }

        string[] lines = File.ReadAllLines(filePath);
        foreach (string line in lines)
        {
            string[] fields = line.Split('#');
            int id = int.Parse(fields[0]);
            string trainerName = fields[1];
            DateTime sessionDate = DateTime.Parse(fields[2]);
            DateTime time = DateTime.Parse(fields[3]);
            decimal cost = decimal.Parse(fields[4]);
            bool taken = bool.Parse(fields[5]);
            Listing listing = new Listing(id, trainerName, sessionDate, time, cost, taken);
            listings.Add(listing);
        }

        Console.WriteLine("Listings loaded successfully!");
        return listings;
    }

    private void AddListing()
    {
        Console.WriteLine("=== Add a New Listing ===");

        Console.Write("Trainer Name: ");
        string trainerName = Console.ReadLine();

        Console.Write("Session Date (MM/dd/yyyy): ");
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime sessionDate))
        {
            Console.WriteLine("Invalid date format. Please enter the date in the format MM/dd/yyyy.");
            return;
        }

        Console.Write("Session Time (hh:mm AM/PM): ");
        if (!DateTime.TryParse(sessionDate.ToShortDateString() + " " + Console.ReadLine(), out DateTime sessionTime))
        {
            Console.WriteLine("Invalid time format. Please enter the time in the format hh:mm AM/PM.");
            return;
        }

        Console.Write("Cost: $");
        if (!decimal.TryParse(Console.ReadLine(), out decimal cost))
        {
            Console.WriteLine("Invalid cost. Please enter a number.");
            return;
        }

        int id = listings.Count + 1;

       Listing newListing = new Listing(id, trainerName, sessionDate, sessionTime, cost, false);

        listings.Add(newListing);

        Console.WriteLine($"Listing added with ID {id}.");
    }

    private void EditListing()
        {
        Console.WriteLine("\nEDIT LISTING");
        Console.Write("Enter the ID of the listing you want to edit: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Listing listingToUpdate = listings.Find(l => l.ID == id);
        if (listingToUpdate == null)
        {
            Console.WriteLine($"Listing with ID {id} not found.");
            return;
        }

        Console.Write("Enter the new trainer name (leave blank to keep the current one): ");
        string trainerName = Console.ReadLine();
        if (!string.IsNullOrEmpty(trainerName))
        {
            listingToUpdate.TrainerName = trainerName;
        }

        Console.Write("Enter the new session date (leave blank to keep the current one): ");
        string sessionDate = Console.ReadLine();
        if (!string.IsNullOrEmpty(sessionDate))
        {
            listingToUpdate.SessionDate = DateTime.Parse(sessionDate);
        }

        Console.Write("Enter the new session time (leave blank to keep the current one): ");
        string Time = Console.ReadLine();
        if (!string.IsNullOrEmpty(Time))
        {
            listingToUpdate.Time = DateTime.Parse(Time);
        }

        Console.Write("Enter the new cost (leave blank to keep the current one): ");
        string cost = Console.ReadLine();
        if (!string.IsNullOrEmpty(cost))
        {
            listingToUpdate.Cost = Convert.ToDecimal(cost);
        }

        Console.Write("Has the listing been taken? (y/n, leave blank to keep the current value): ");
        string takenInput = Console.ReadLine();
        if (!string.IsNullOrEmpty(takenInput))
        {
            bool taken = takenInput.ToLower() == "y";
            listingToUpdate.Taken = taken;
        }

        UpdateListingsFile();
        Console.WriteLine($"Listing with ID {id} updated successfully.");
    }

    private void UpdateListingsFile()
    {
        List<string> lines = new List<string>();
        foreach (Listing listing in listings)
        {
            string line = $"{listing.ID}#{listing.TrainerName}#{listing.SessionDate.ToString("MM/dd/yyyy")}#{listing.Time.ToString("hh:mm tt")}#{listing.Cost}#{listing.Taken}";
            lines.Add(line);
        }
        File.WriteAllLines(FILE_NAME, lines);
        Console.WriteLine("Listings saved successfully!");
    }

    private void DeleteListing()
    {
        Console.WriteLine("\nDELETE LISTING");
        Console.Write("Enter the ID of the listing you want to delete: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Listing listingToDelete = listings.Find(l => l.ID == id);
        if (listingToDelete == null)
        {
            Console.WriteLine($"Listing with ID {id} not found.");
            return;
        }

        listings.Remove(listingToDelete);
        UpdateListingsFile();
        Console.WriteLine($"Listing with ID {id} deleted successfully.");
    }

    private void ListAllListings()
    {
        Console.WriteLine("\nLIST ALL LISTINGS");
        Console.WriteLine("ID\tTrainer Name\tSession Date\tSession Time\tCost\tTaken");
        foreach (Listing listing in listings)
        {
            Console.WriteLine($"{listing.ID}\t{listing.TrainerName}\t{listing.SessionDate.ToString("MM/dd/yyyy")}\t{listing.Time.ToString("hh:mm tt")}\t{listing.Cost}\t{listing.Taken}");
        }
    }

    private void SaveListings()
    {
        UpdateListingsFile();
    }


}