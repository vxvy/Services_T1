using System;
    //https://social.msdn.microsoft.com/Forums/en-US/9a58321d-7fd5-45ca-bba0-44a0a336aeeb/how-can-i-iterate-through-the-list-of-methods-subscribed-to-any-event?forum=csharplanguage
    //Multiple Delegates
namespace Services_T1
{
    delegate void Fonsi();
    class Program
    {
        public static int optionCount = 0;

        static void Main(string[] args)
        {
            int numOptions = 0;
            Fonsi[] myFonsi = new Fonsi[numOptions];

            do
            {
                Console.WriteLine("How many options do you want?");
                string optionNumberStr = Console.ReadLine();
                if (Int32.TryParse(optionNumberStr, out numOptions))
                {

                    myFonsi = new Fonsi[numOptions];

                    for (int i = 0; i <  numOptions; i++, optionCount++)
                    {
                        myFonsi[i] = option;
                    }
                }

            } while (numOptions<=0);

            string[] options = new string[numOptions];
            for (int i = 1; i <= options.Length; i++)
            {
                options[i-1] = "Option "+i;
            }

            MenuGenerator(options, myFonsi);
            Console.ReadKey();
        }

        public static void MenuGenerator(string [] options, Fonsi []myFonsi)
        {
            string option = "0";
            do
            {
                Console.WriteLine("Choose an option: ");
                foreach (string str in options)
                {
                    Console.WriteLine(str);
                }
                Console.WriteLine("Press 0 to exit.");

                option = Console.ReadLine();

                if (Int32.TryParse(option, out int intOption) && intOption < myFonsi.Length && intOption != 0)
                {
                    myFonsi[intOption]();
                }
                else if(option == "0")
                {
                    Console.WriteLine("Leaving . . . ");
                }
                else
                {
                    Console.WriteLine("There was an error with the option given. Please, choose some other option.");
                }

            } while (option!="0");

        }

        public static void option(){
            char a = (char)('1'+optionCount);
            Console.WriteLine("You've chosen "+a);
        }
    }
}