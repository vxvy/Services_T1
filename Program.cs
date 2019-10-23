using System;
    //https://social.msdn.microsoft.com/Forums/en-US/9a58321d-7fd5-45ca-bba0-44a0a336aeeb/how-can-i-iterate-through-the-list-of-methods-subscribed-to-any-event?forum=csharplanguage
    //Multiple Delegates
namespace Services_T1
{
    delegate void Fonsi();
    class Program
    {
        static void Main(string[] args)
        {
            int numOptions = 3;
            int totalSize = numOptions + 2;

            //Fonsi myFonsi = new Fonsi(outOption);
            //myFonsi += option1;
            //myFonsi += option2;
            //myFonsi += option3;
            //myFonsi += defOption;

            Fonsi[] myFonsi = new Fonsi[] { outOption, option1, option2, option3, defOption };

            string[] options = new string[totalSize];
            for (int i = 0; i < options.Length; i++)
            {
                if (i == 0)
                {
                    options[i] = 
                        "___________________________" +
                        "\r\nMENU"+
                        "\r\n___________________________";
                }
                else if (i == options.Length-1)
                {
                    options[i] = "Press 0 to exit";
                }
                else
                {
                    options[i] = "Press "+i+".-";
                }
            }
            MenuGenerator(options, myFonsi);
            Console.ReadKey();
        }

        //public static void MenuGenerator(string [] options, Fonsi myFonsi)
        public static void MenuGenerator(string [] options, Fonsi []myFonsi)
        {
            if(options.Length == myFonsi.Length){

                string option = "0";
                do
                {
                    for (int i = 0; i < options.Length; i++)
                    {
                        Console.WriteLine(options[i]);
                    }

                    option = Console.ReadLine();
                
                    if (!Int32.TryParse(option, out int aux) || ( aux < 0 || aux > 4))
                    {
                        aux = 4;
                    }

                    myFonsi[aux]();

                    //Delegate[] test = myFonsi.GetInvocationList();
                    //test[option];

                } while (option!="0");
            }
            else
            {
                Console.WriteLine("El menú no es coherente con el delegado");
            }
        }

        public static void option1(){
            Console.WriteLine("You've chosen 1");
        }
        public static void option2(){
            Console.WriteLine("You've chosen 2");
        }
        public static void option3(){
            Console.WriteLine("You've chosen 3");
        }
        public static void defOption(){
            Console.WriteLine("Option not avaiable.");
        }
        public static void outOption(){
            Console.WriteLine("Leaving . . .");
        }
    }
}