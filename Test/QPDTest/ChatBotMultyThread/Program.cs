using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HelpClasses;

namespace ChatBotMultyThread
{
    public class Program
    {
        public static void Main()
        {
            ChatBot.Ask("Привет");
            string question;
            do
            {
                Console.Write("-> ");
                question = Console.ReadLine();
                ChatBot.Ask(question);
            } while (question != "Пока" && question != "До свидания");
            HelpFunctions.Continue();
        }
    }
}
