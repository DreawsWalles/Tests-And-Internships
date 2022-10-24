using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpClasses;

namespace ChatBot
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine(ChatBot.Ask("Привет"));
            string question;
            do
            {
                Console.Write("->");
                question = Console.ReadLine();
                Console.WriteLine(question = ChatBot.Ask(question));
            } while (question != "Пока" && question != "До свидания");
            HelpFunctions.Continue();
        }
    }
}
