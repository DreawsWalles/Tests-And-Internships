using Help;
using HistoryLib;
using ReceiverLib;
using RepositoryLib.FakeRepository;
using RepositoryLib.JSONRepository;
using RepositoryLib.XMLRepository;
using LoggerLib;
using ViewLib;
using RepositoryLib;

namespace taskTwo
{
    public class Program
    {
        public static void Main()
        {
            IView view = new ViewConsole();
            Logger logger = new Logger();
            try
            {
                ChatBot bot = new ChatBot(new History(view), new UnitOfWork(new XMLAphorismsRepository(), new JSONMyNameRepository(), new XMLJokeRepository(), new XMLByeRepository(), new FakeHelpRepository(), new FakeDownloadWebSiteRepository()), view);

                string task = "";
                while (task.ToLower() != "пока" && task.ToLower() != "до свидания")
                {
                    Console.Write("You->");
                    task = Console.ReadLine();
                    bot.Ask(task);
                }
            }
            catch (Exception e)
            {
                logger.Log(e.Message);
                view.ViewError(e.Message);
            }
        }
    }
}