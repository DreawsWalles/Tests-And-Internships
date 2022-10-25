using ReceiverLib;

namespace taskTwo
{
    public class Program
    {
        public static void Main()
        {
            ChatBot bot = new ChatBot();
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