using Help;
using ReceiverLib;
using RepositoryLib.FakeRepository;
using RepositoryLib.JSONRepository;
using RepositoryLib.XMLRepository;
using System.Text.Json;

namespace taskTwo
{
    public class Program
    {
        public static void Main()
        {
            ChatBot bot = new ChatBot(new JSONAphorismsRepository(), new JSONMyNameRepository(), new JSONJokeRepository(), new JSONByeRepository());
            
            string task = "";
            while (task.ToLower() != "пока" && task.ToLower() != "до свидания")
            {
                Console.Write("You->");
                task = Console.ReadLine();
                Console.WriteLine($"bot-> {bot.Ask(task)}");
            }
        }
    }
}