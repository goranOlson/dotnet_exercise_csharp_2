namespace dotnet_exercise_csharp_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            string input = "";
            int menuSelection = -1;

            do
            {
                // Print main menu
                Console.WriteLine($"{Environment.NewLine}___Huvudmeny___");
                Console.WriteLine("1. Val 1");
                Console.WriteLine("0. Avsluta programmet");
                Console.Write($"{Environment.NewLine}Ditt val: ");
                input = Console.ReadLine() ?? "";

                // Capture user input and validate it
                if (!int.TryParse(input, out menuSelection))
                {
                    menuSelection = -1;
                }

                // Handle main menu selection
                Console.Clear();
                switch (menuSelection)
                {
                    case 0:
                        Console.WriteLine("Avslutar programmet...");
                        break;
                    case 1:
                        Console.WriteLine("Du valde alternativ 1");
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine($"+--------------+{Environment.NewLine}| Ogiltigt val |{Environment.NewLine}+--------------+");
                        break;
                }
            } while (menuSelection != 0);
        }
    }
}
