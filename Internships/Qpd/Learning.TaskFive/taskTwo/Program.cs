using Help;
using HistoryLib;
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
            string url = "http://google.com";
           

            ChatBot bot = new ChatBot(new History(new ViewConsole()), new XMLAphorismsRepository(), new JSONMyNameRepository(), new XMLJokeRepository(), new XMLByeRepository(), new FakeHelpRepository(), new FakeDownloadWebSiteRepository(), new ViewConsole());
            
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