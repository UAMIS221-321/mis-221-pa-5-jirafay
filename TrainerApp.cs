using mis_221_pa_5_jirafay;

namespace mis_221_pa_5_jirafay
{
    class TrainerApp {
        private List<Trainer> trainers = new List<Trainer>();
        private string trainersFile = "trainers.txt";
        //read in trainers from file



        public TrainerApp() {
            LoadTrainers();
        }

        public void ManageTrainers(){
            Console.WriteLine("Enter 1 to add a new trainer.");
            Console.WriteLine("Enter 2 to update an existing trainer.");
            Console.WriteLine("Enter 3 to delete an existing trainer.");
            Console.WriteLine("Enter 4 to view all trainers.");
            System.Console.WriteLine("Enter 5 to return to the main menu.");

            int choice = int.Parse(Console.ReadLine());

            switch(choice){
                case 1:
                    
                    int id = trainers.Count + 1;

                    System.Console.WriteLine("Enter the trainer's name: ");
                    string name = Console.ReadLine();

                    System.Console.WriteLine("Enter the trainer's mailing address: ");
                    string mailingAddress = Console.ReadLine();

                    System.Console.WriteLine("Enter the trainer's email address: ");
                    string emailAddress = Console.ReadLine();

                    Trainer newTrainer = new Trainer(id, name, mailingAddress, emailAddress);
                        
                    trainers.Add(newTrainer);

                    System.Console.WriteLine("Trainer added successfully.");
                    break;
                
                case 2:
                    // Update an existing trainer
                    Console.WriteLine("Enter trainer ID to update:");
                    int idToUpdate = int.Parse(Console.ReadLine());

                    Trainer trainerToUpdate = trainers.Find(trainer => trainer.ID == idToUpdate);

                    if (trainerToUpdate == null) {
                        Console.WriteLine("Trainer not found!");
                        break;
                    }
                    else {
                        Console.WriteLine("Enter updated trainer name:");
                        string updatedName = Console.ReadLine();
                        trainerToUpdate.Name = updatedName;

                        Console.WriteLine("Enter updated trainer mailing address:");
                        string updatedMailingAddress = Console.ReadLine();
                        trainerToUpdate.MailingAddress = updatedMailingAddress;

                        Console.WriteLine("Enter updated trainer email address:");
                        string updatedEmailAddress = Console.ReadLine();
                        trainerToUpdate.EmailAddress = updatedEmailAddress;

                        SaveTrianers(trainers);

                        Console.WriteLine("Trainer updated successfully!");
                        break;
                    }

                case 3:
                    // Delete an existing trainer
                    Console.WriteLine("Enter trainer ID to delete:");
                    int idToDelete = int.Parse(Console.ReadLine());

                    Trainer trainerToDelete = trainers.Find(t => t.ID == idToDelete);

                    if (trainerToDelete == null) {
                        Console.WriteLine("Trainer not found!");
                        break;
                    }

                    trainers.Remove(trainerToDelete);

                    Console.WriteLine("Trainer deleted successfully!");
                    break;

                case 4:
                    // View all trainers
                    foreach (Trainer trainer in trainers) {
                        Console.WriteLine($"ID: {trainer.ID}, Name: {trainer.Name}, Mailing Address: {trainer.MailingAddress}, Email Address: {trainer.EmailAddress}");
                    }
                    break;

                case 5:
                    // Return to main menu
                    break;

                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
            SaveTrianers( trainers);
        }
            private static List<Trainer> LoadTrainers() {
                List<Trainer> trainers = new List<Trainer>();

                // Read the trainers from the trainers.txt file
                string filePath = "trainers.txt";

                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines) {
                    string[] fields = line.Split('#');
                    int id = int.Parse(fields[0]);
                    string name = fields[1];
                    string mailingAddress = fields[2];
                    string emailAddress = fields[3];

                    Trainer trainer = new Trainer(id, name, mailingAddress, emailAddress);
                    trainers.Add(trainer);
                }

                Console.WriteLine("Trainers loaded successfully!");
                return trainers;
            }

            private static void SaveTrianers(List<Trainer> trainers) {
                string filePath = "trainers.txt";
                List<string> lines = new List<string>();

                foreach (Trainer trainer in trainers) {
                    string line = $"{trainer.ID}#{trainer.Name}#{trainer.MailingAddress}#{trainer.EmailAddress}";
                    lines.Add(line);
                    
                }

                File.WriteAllLines(filePath, lines);

                Console.WriteLine("Trainers saved successfully!");
            }
    }
}