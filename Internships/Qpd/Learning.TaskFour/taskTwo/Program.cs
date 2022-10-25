using Help;
using ReceiverLib;
using RepositoryLib.FakeRepository;
using RepositoryLib.JSONRepository;
using RepositoryLib.XMLRepository;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using ViewLib;

namespace taskTwo
{
    public class Program
    {
        public static void Main()
        {
            ChatBot bot = new ChatBot(new XMLAphorismsRepository(), new JSONMyNameRepository(), new XMLJokeRepository(), new XMLByeRepository(), new ViewConsole());
            
            string task = "";
            while (task.ToLower() != "пока" && task.ToLower() != "до свидания")
            {
                Console.Write("You->");
                task = Console.ReadLine();
                bot.Ask(task);
            }
            bot.Dispose();
        }
    }
}