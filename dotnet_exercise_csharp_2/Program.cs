namespace dotnet_exercise_csharp_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "";  // Main menu user input
            int menuSelection = -1;  // Main menu selection
            bool keepRunning = true;  // Flag main menu loop

            do
            {
                // Print main menu
                Console.WriteLine("         Huvudmeny         ");
                Console.WriteLine("===========================");
                Console.WriteLine("1. Val 1");
                Console.WriteLine("0. Avsluta programmet");
                Console.Write($"{Environment.NewLine}Ange siffra för ditt val: ");

                // Capture user input and validate it
                input = Console.ReadLine() ?? "";
                if (!int.TryParse(input, out menuSelection))
                {
                    menuSelection = -1;
                }

                // Handle main menu selection
                Console.Clear();
                switch (menuSelection)
                {
                    case 0:
                        keepRunning = false;
                        Console.WriteLine("Avslutar programmet...");
                        break;
                    case 1:
                        Console.WriteLine("Du valde alternativ 1");
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine($"+--------------+{Environment.NewLine}| Ogiltigt val |{Environment.NewLine}+--------------+{Environment.NewLine}");
                        break;
                }
            } while (keepRunning);  // (menuSelection != 0);
        }
    }
}
