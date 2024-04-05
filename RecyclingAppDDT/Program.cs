using System.Dynamic;
using System.Runtime.CompilerServices;

namespace RecyclingAppDDT
{
    internal class Program
    {
        //Global Variables
        static float fullTotal = 0;
        static string totalReTypes = "";
        static float totalWeight = 0;
        
        static void UiTrash()
        {
            int chosenIndex;
            float globaltax = 0.15f;
            string reTypeString = "";

            List<string> reType = new List<string>() { "Glass ($2.5p/kg)", "Plastic ($2.5p/kg)", "Cardboard ($2.5p/kg", "Tin ($3p/kg)" }; //List
            List<float> reTypePrice = new List<float>() { 2.5f, 3.90f, 2.5f, 3 }; //Prices

            Console.WriteLine("Please Choose the TYPE of Recycling you want to dump:\n");
            
            chosenIndex = MenuChoice("Type", reType); //Displaying the List
            if (chosenIndex == 0)
            {
                reTypeString = "Glass, ";
            }
            if (chosenIndex == 1)
            {
                reTypeString = "Plastic, ";
            }
            if (chosenIndex == 2)
            {
                reTypeString = "Cardboard, ";
            }
            if (chosenIndex == 3)
            {
                reTypeString = "Tin, ";
            }

            totalReTypes = totalReTypes + reTypeString;

            float weight = CheckFloat(); //Asking for weight
            totalWeight = totalWeight + weight;

            float dumpPrice = weight * reTypePrice[chosenIndex]; //The Weight times the Recycling Type

            Console.WriteLine($"The weight of your recycling is {weight}kg and it's cost is ${reTypePrice[chosenIndex]} per kg");

            if (weight > 20) //if the weight is over 20kg you get discount
            {
                dumpPrice = dumpPrice * 0.2f;
                Console.WriteLine("\tAdded 20% discount\n");
            }

            //Math
            float ogDumpP = dumpPrice;
            float tax =  dumpPrice * globaltax;
            float totalTax = dumpPrice + tax;

            fullTotal += totalTax;

            Console.WriteLine("Press <ENTER> to finalize prices\n");
            Console.ReadLine();
            Console.Clear();

            //Displaying Totals
            Console.WriteLine($"Recycling Type: {reTypeString}\n" +
                $"The weight of your dumped {reTypeString} is {weight}kg\n" +
                "Totals:\n" +
                $"\tTax: ${globaltax}\n" +
                $"\tTotal Tax: ${tax}\n" +
                $"\tDump Price (Before Tax): ${dumpPrice}\n" +
                $"\tDump Price (After Tax): ${totalTax}\n");

        }

        static int MenuChoice(string menuType, List<string> listData)
        {


            string menu = GenerateMenu(menuType, listData);

            return CheckInt(menu, 1, listData.Count) - 1;
        }
        static string GenerateMenu(string menuType, List<string> listData)
        {


            string menu = $"Select the {menuType}:\n";

            for (int loop = 0; loop < listData.Count; loop++)
            {
                menu += $"{loop + 1}. {listData[loop]}\n";
            }

            return menu;
        }
        static int CheckInt(string question, int min, int max)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine(question);

                    int userInt = Convert.ToInt32(Console.ReadLine());

                    if (userInt >= min && userInt <= max)
                    {
                        return userInt;
                    }
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"ERROR: You must enter a number between {min} and {max}");
                    Console.ForegroundColor= ConsoleColor.White;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"ERROR: You must enter a number between {min} and {max}");
                    Console.ForegroundColor = ConsoleColor.White;
                }


            }

        }
        static float CheckFloat(int min = 0, int max = 999999)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine($"How much does your recycling weigh?(kg)\n");

                    float userFloat = (float)Convert.ToDecimal(Console.ReadLine());

                    if (userFloat >= min && userFloat <= max)
                    {
                        return userFloat;
                    }
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"ERROR: You must enter a number");
                    Console.ForegroundColor= ConsoleColor.White;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"ERROR: You must enter a number");
                    Console.ForegroundColor= ConsoleColor.White;
                }
            }
        }
        static string CheckProceed()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Press <ENTER> to add more recycling types or type 'x' to exit the program");
                Console.ForegroundColor = ConsoleColor.White;

                string checkProceed = Console.ReadLine();

                checkProceed = checkProceed.ToUpper();

                if (checkProceed.Equals("") || checkProceed.Equals("X")) //this || means or
                {
                    return checkProceed;
                }
            }
        }
      
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(",------.                            ,--.,--.                     ,---.                 \n" +
                "|  .--. ' ,---.  ,---.,--. ,--.,---.|  |`--',--,--,  ,---.      /  O  \\  ,---.  ,---.  \n" +
                "|  '--'.'| .-. :| .--' \\  '  /| .--'|  |,--.|      \\| .-. |    |  .-.  || .-. || .-. | \n" +
                "|  |\\  \\ \\   --.\\ `--.  \\   ' \\ `--.|  ||  ||  ||  |' '-' '    |  | |  || '-' '| '-' ' \n" +
                "`--' '--' `----' `---'.-'  /   `---'`--'`--'`--''--'.`-  /     `--' `--'|  |-' |  |-'  \n" +
                "                      `---'                         `---'               `--'   `--'    \n"
                ); //Replace later (Ascii art Gen)
            Console.ForegroundColor= ConsoleColor.White;

            Console.WriteLine("Please follow the programs prompts:");

            string proceed = "";
            while (proceed.Equals(""))
            {
                UiTrash();

                proceed = CheckProceed();
            }
            
            Console.WriteLine($"The type/s you chose to dump were: {totalReTypes}\n" +
            $"The total weight of all items to dump is: {totalWeight}kg\n" +
            $"The amount to dump in total is ${fullTotal}\n");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Press <ENTER> to end the program");
            Console.ForegroundColor = ConsoleColor.White;

            Console.ReadLine();
            Console.Clear();
        }
    } 
}