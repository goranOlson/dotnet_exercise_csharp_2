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
                // Print main menu and capture user selection
                Console.WriteLine("         Huvudmeny         ");
                Console.WriteLine("===========================");
                Console.WriteLine("1. Beräkna pris för kund");
                Console.WriteLine("2. Beräkna pris för grupp");
                Console.WriteLine("3. Loopa text");
                Console.WriteLine("4. Skriv ut tredje ordet");
                Console.WriteLine("0. Avsluta programmet");
                Console.Write($"{Environment.NewLine}");
                Console.Write("Ange siffra för ditt val: ");

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
                        CalculateIndividualPrice();
                        Console.Clear();
                        break;
                    case 2:
                        CalculateGroupPrice();
                        Console.Clear();
                        break;
                    case 3:
                        PrintTextInLoop();
                        Console.Clear();
                        break;
                    case 4:
                        SplitText();
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("+--------------+");
                        Console.WriteLine("| Ogiltigt val |");
                        Console.WriteLine("+--------------+");
                        Console.WriteLine("");
                        break;
                }
            } while (keepRunning);
        }

        public static void CalculateGroupPrice()
        {
            int nbrPeople = -1;
            int summa = 0;

            Console.WriteLine("Beräkna pris för grupp  ");
            Console.WriteLine($"-----------------------------{Environment.NewLine}");

            //Get number of people in the group
            nbrPeople = AskIntValue("Ange antal personer i gruppen: ", 0);
            Console.WriteLine("");

            //Get the sum of prices for every person in the group
            if (nbrPeople >= 1)
            {
                for (int i = 0; i < nbrPeople; i++)
                {
                    int age = AskIntValue($"Ange ålder för person {i + 1}: ");
                    summa += GetPriceForAge(age);
                }
                Console.WriteLine("");
                Console.WriteLine($"Antal personer: {nbrPeople}");
                Console.WriteLine($"Summa för gruppen: {summa}");
            }
            else
            {
                Console.WriteLine("Antal är '0'. Avbryter...");
            }

            // Show info until key pressed, then return to main menu
            WaitForKeyPress();
        }

        public static void CalculateIndividualPrice()
        {
            int years = -1;

            Console.WriteLine("Beräkna pris för enskild kund");
            Console.WriteLine($"-----------------------------{Environment.NewLine}");

            //Ask for customers age and calculate price
            years = AskIntValue("Ange kundens ålder: ");  // -1 vid 0


            //Present users price
            if (years < 20)
            {
                Console.WriteLine("Ungdomspris: " + GetPriceForAge(years) + " kr");
            }
            else if (years > 64)
            {
                Console.WriteLine("Pensionärspris: " + GetPriceForAge(years) + " kr");
            }
            else
            {
                Console.WriteLine("Standartpris: " + GetPriceForAge(years) + " kr");
            }


            // Show info until key pressed, then return to main menu
            WaitForKeyPress();
        }

        public static void PrintTextInLoop()
        {
            string input = "";

            // Ask string
            Console.WriteLine("Skriv ut text 10 gånger  ");
            Console.WriteLine($"-----------------------------{Environment.NewLine}");
            
            do
            {
                Console.Write("Ange text att loopa: ");
                input = Console.ReadLine() ?? "";
                if (input == "")
                {
                    Console.WriteLine("Text saknas");
                }

            } while (input == "");


            // Print string 10 times
            for(int i = 0; i<10; i++)
            {
                Console.Write($"{i + 1}. {input} ");
            }

            // Show info until key pressed, then return to main menu
            Console.WriteLine("");
            WaitForKeyPress();
        }

        public static void SplitText()
        {
            string input = "";
            bool goodValue = false;
            string[] split;
            string[] strippedSplit;

            // Ask string
            Console.WriteLine("Skriv ut det tredje ordet  ");
            Console.WriteLine($"-----------------------------{Environment.NewLine}");

            do
            {
                Console.Write("Ange text med minst tre ord: ");
                input = Console.ReadLine() ?? "";

                if (!string.IsNullOrWhiteSpace(input))
                {
                    split = input.Split(' ');
                    strippedSplit = split.Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
                    if (strippedSplit.Length >= 3)
                    {
                        Console.WriteLine($"Tredje ordet: {strippedSplit[2]}");
                        goodValue = true;
                    }
                }

                if (!goodValue)
                {
                    Console.WriteLine("Ange minst tre ord!");
                }
            } while (!goodValue);

            // Show info until key pressed, then return to main menu
            Console.WriteLine("");
            WaitForKeyPress();
        }
        public static int GetPriceForAge(int age)
        {
            int price = -1;

            if (age >= 0)
            {
                if (age < 20)
                {
                    price = 80;
                }
                else if (age > 64)
                {
                    price = 90;
                }
                else
                {
                    price = 120;
                }
            }
            
            return price;
        }

        public static int AskIntValue(string query, int minValue = 0, int maxValue = -1)  // maxValue ?
        {
            int intValue = -1;
            string input = "";
            bool validInput = false;

            do
            {
                Console.Write(query);// "Ange ålder: "
                input = Console.ReadLine() ?? "";

                if (int.TryParse(input, out intValue))  // maxValue
                {
                    if (intValue >= minValue && (maxValue == -1 || maxValue >= intValue))
                    {
                        validInput = true;
                    }
                }

                if (!validInput)
                {
                    Console.WriteLine("Ogiltigt värde!");
                }
            }
            while (!validInput);

            return intValue;
        }

        public static bool WaitForKeyPress()
        {
            bool keyIsPressed = false;

            Console.WriteLine($"{Environment.NewLine}Tryck på valfri tangent för att gå till huvudmenyn");
            ConsoleKeyInfo key = Console.ReadKey();

            if (key.ToString() != "")
            {
                keyIsPressed = true;
            }

            return keyIsPressed;
        }
    }
}
