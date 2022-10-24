using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpClasses;

namespace ChatBotXML
{
    public class Program
    {
        static public void Main()
        {
            ChatBotXML bot = new ChatBotXML();
            Console.WriteLine(bot.Ask("Привет"));
            string question;
            do
            {
                Console.Write("->");
                question = Console.ReadLine();
                Console.WriteLine(question = bot.Ask(question));
            } while (question != "Пока" && question != "До свидания");
            HelpFunctions.Continue();
        }
    }
}
