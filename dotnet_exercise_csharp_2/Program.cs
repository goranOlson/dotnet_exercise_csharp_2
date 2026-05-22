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
                Console.WriteLine("1. Beräkna pris för kund");
                Console.WriteLine("2. Beräkna pris för grupp");
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
                    case 2:
                        Console.WriteLine("Alternativ 2");
                        CalculateGroupPrice();
                        //Console.Clear();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine($"+--------------+{Environment.NewLine}| Ogiltigt val |{Environment.NewLine}+--------------+{Environment.NewLine}");
                        break;
                }
                Console.Clear();
                // Console.WriteLine("Next loop");
            } while (keepRunning);
        }

        public static void CalculateGroupPrice()
        {
            int sum = 0;
            int count = 0;
            int years = -1;
            string input = "";
            
            Console.WriteLine("  Beräkna pris för grupp  ");
            Console.WriteLine("--------------------------");
            Console.WriteLine($"Avbryt med tom rad{Environment.NewLine}");


            do
            {
                Console.Write("Ange ålder: ");
                input = Console.ReadLine() ?? "";
                if (int.TryParse(input, out years) && years > 0)
                {
                    // Console.WriteLine("Good years");

                    count++;
                    switch (years)
                    {
                        case < 20:
                            sum += 80;
                            break;
                        case > 64:
                            sum += 90;
                            break;
                        default:
                            sum += 120;
                            break;
                    }
                }
                else if (input != "")
                {
                    Console.WriteLine("Bad years");
                }

            } while(input != "");
            // Console.WriteLine("Klar med grupp...");

            // sum och antal
            // Console.WriteLine($"Antal personer: {count}, summa: {sum} kr");
            Console.WriteLine($"Pris: {sum} för {count} personer");

            Stopper();
            // Console.Clear();
        }

        public static void CalculateTicketCost()
        {
            string inputYears = "";
            int years = -1;
            bool validInput = false;

            Console.WriteLine("  Beräkna pris för enskild kund  ");
            Console.WriteLine("-------------------------");

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
                    //Console.WriteLine($"{Environment.NewLine}Tryck på valfri tangent för att gå till huvudmenyn");
                    //ConsoleKeyInfo key = Console.ReadKey();
                    //if (key.ToString() != "")
                    //{
                    //    validInput = true;
                    //}
                    validInput = Stopper();
                }
            } while (!validInput);
            // Console.Clear();
        }

        public static bool Stopper()
        {
            bool validInput = false;
            Console.WriteLine($"{Environment.NewLine}Tryck på valfri tangent för att gå till huvudmenyn");
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.ToString() != "")
            {
                validInput = true;
            }

            return validInput;
        }
    }
}
