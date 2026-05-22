using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

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
                Console.WriteLine("1. Beräkna kundens pris");
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
                        CalculateTicketCost();
                        Console.Clear();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine($"+--------------+{Environment.NewLine}| Ogiltigt val |{Environment.NewLine}+--------------+{Environment.NewLine}");
                        break;
                }
            } while (keepRunning);


            
        }

        public static void CalculateTicketCost()
        {
            string inputYears = "";
            int years = -1;
            bool validInput = false;

            Console.WriteLine("  Hitta pris  ");
            Console.WriteLine("--------------");

            do
            {
                // Print error message
                if (inputYears != "")
                {
                    Console.WriteLine($"+---------------+{Environment.NewLine}| Ogiltig ålder |{Environment.NewLine}+---------------+{Environment.NewLine}");
                }

                // Ask for customers age and calculate price
                Console.Write("Ange kundens ålder: ");
                inputYears = Console.ReadLine() ?? "";
                
                if (int.TryParse(inputYears, out years))
                {
                    if (years < 20)
                    {
                        Console.WriteLine("Ungdomspris: 80 kr");
                    }
                    else if (years > 64)
                    {
                        Console.WriteLine("Pensionärspris: 90 kr");
                    }
                    else
                    {
                        Console.WriteLine("Standartpris: 120 kr");
                    }

                    // Exit loop and return to main menu
                    Console.WriteLine($"{Environment.NewLine}Tryck på valfri tangent för att gå till huvudmenyn");
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.ToString() != "")
                    {
                        validInput = true;
                    }
                }
            } while (!validInput);
            // Console.Clear();
        }
    }
}
