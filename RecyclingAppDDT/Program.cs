using System.Dynamic;
using System.Runtime.CompilerServices;

namespace RecyclingAppDDT
{
    internal class Program
    {
        //Final Code - Recycling App
        //Global Variables
        static float fullTotal = 0;
        static string totalReTypes = "";
        static float totalWeight = 0;
        //Secondary Method
        static void UiTrash()
        {
            int chosenIndex;
            float globaltax = 0.15f;
            string reTypeString = "";

            List<string> reType = new List<string>() { "Glass ", "Plastic ", "Cardboard ", "Tin " }; //List
            List<float> reTypePrice = new List<float>() { 2.5f, 3.90f, 2.5f, 3 }; //Prices

            Console.WriteLine("Please Choose the TYPE of Recycling you want to dump (1-4):\n");
            
            chosenIndex = MenuChoice("Type", reType, reTypePrice); //Displaying the List
            totalReTypes = totalReTypes + reType[chosenIndex]; //Adding to Global
            Console.Clear();
            
            float weight = CheckFloat(); //Asking for weight
            totalWeight = totalWeight + weight;

            float dumpPrice = weight * reTypePrice[chosenIndex]; //The Weight times the Recycling Type

            Console.WriteLine($"The weight of your recycling is {weight}kg and it's cost is ${reTypePrice[chosenIndex]} per kg");

            if (weight >= 20) //if the weight is over 20kg you get discount
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
            Console.WriteLine($"Recycling Type: {reType[chosenIndex]}\n" +
                $"The weight of your dumped {reTypeString}is {weight}kg\n" +
                "Totals:\n" +
                $"\tTax: ${globaltax}\n" +
                $"\tTotal Tax: ${tax}\n" +
                $"\tDump Price (Before Tax): ${dumpPrice}\n" +
                $"\tDump Price (After Tax): ${totalTax}\n");
        }
        //Supporting Methods
        //Displaying Menu
        static int MenuChoice(string menuType, List<string> typeData, List<float> priceData)
        {


            string menu = GenerateMenu(menuType, typeData, priceData);

            return CheckInt(menu, 1, typeData.Count) - 1;
        }
        //Generating Menu
        static string GenerateMenu(string menuType, List<string> typeData, List<float> priceData)
        {


            string menu = $"Select the {menuType}:\n";

            for (int loop = 0; loop < typeData.Count; loop++)
            {
                menu += $"{loop + 1}. {typeData[loop]} (${priceData[loop]}\\kg)\n";
            }

            return menu;
        }
        //Checking Int
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
                    DisplayErrorMessage($"ERROR: You must enter a number between {min} and {max}");                   
                }
                catch
                {                   
                    DisplayErrorMessage($"ERROR: You must enter a number between {min} and {max}");
                }


            }

        }
        //Checking parameters for Weight
        static float CheckFloat(int min = 0, int max = 999999999)
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
                    DisplayErrorMessage($"ERROR: You must enter a number");
                }
                catch
                {
                    DisplayErrorMessage($"ERROR: You must enter a number");
                }
            }
        }
        //Giving the user the option to add more info
        static string CheckProceed()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Press <ENTER> to add more recycling types or type 'x' to exit the program");
                Console.ForegroundColor = ConsoleColor.White;

                string checkProceed = Console.ReadLine();
                Console.Clear();
                checkProceed = checkProceed.ToUpper();

                if (checkProceed.Equals("") || checkProceed.Equals("X")) //this || means or
                {
                    return checkProceed;
                }
                DisplayErrorMessage("ERROR: Invalid Response");
            }
        }
        //Displaying the Error Message
        private static void DisplayErrorMessage(string error)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(error);
            Console.ForegroundColor = ConsoleColor.White;
        }
        //Main
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(",------.                            ,--.,--.                     ,---.                 \n" +
                "|  .--. ' ,---.  ,---.,--. ,--.,---.|  |`--',--,--,  ,---.      /  O  \\  ,---.  ,---.  \n" +
                "|  '--'.'| .-. :| .--' \\  '  /| .--'|  |,--.|      \\| .-. |    |  .-.  || .-. || .-. | \n" +
                "|  |\\  \\ \\   --.\\ `--.  \\   ' \\ `--.|  ||  ||  ||  |' '-' '    |  | |  || '-' '| '-' ' \n" +
                "`--' '--' `----' `---'.-'  /   `---'`--'`--'`--''--'.`-  /     `--' `--'|  |-' |  |-'  \n" +
                "                      `---'                         `---'               `--'   `--'    \n" +
                "---------------------------------------------------------------------------------------"
                ); //title
            Console.ForegroundColor= ConsoleColor.White;

            Console.WriteLine("Welcome to the Recycling APP\n" +
                "Please follow the programs prompts:\n" +
                "Press <ENTER> To Begin\n");
            Console.ReadLine();
            Console.Clear();

            string proceed = "";
            while (proceed.Equals(""))
            {
                UiTrash(); //Calling the Secondary method

                proceed = CheckProceed();
            }
            //Total Totals
            Console.WriteLine($"The type/s you chose to dump were:\n{totalReTypes}\n" +
            $"The total weight of all items to dump is:\n{totalWeight}kg\n" +
            $"The amount to dump in total is \n${fullTotal}\n");

          
            DisplayErrorMessage("Press <ENTER> to end the program");
            

            Console.ReadLine();
            Console.Clear();
        }
    } 
}