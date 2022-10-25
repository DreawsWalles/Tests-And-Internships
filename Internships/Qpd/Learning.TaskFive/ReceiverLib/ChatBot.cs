using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLib;
using CommandLib.Aphorisms;
using CommandLib.Hello;
using CommandLib.MyName;
using CommandLib.Time;
using CommandLib.Joke;
using CommandLib.Bye;
using CommandLib.Help;
using CommandLib.DownloadWebSite;
using RepositoryLib;
using ViewLib;
using HistoryLib;
using ModelsLib;

namespace ReceiverLib
{
    public class ChatBot : IDisposable
    {
        private IRepository _aphorismsRepository;
        private static IRepository _myNameRepository;
        private static IRepository _jokeRepository;
        private static IRepository _byeRepository;
        private static IRepository _helpRepository;
        private IRepository _downloadWebSiteRepository;
        private History _history;
        private Dictionary<string, ICommand> _tasks;
        private Thread _thread;
        private Queue<string> _questionsQueue;
        private IView _view;

        public ChatBot(History history, IRepository AphorismsRepository, IRepository MyNameRepository, IRepository JokeRepository, 
                       IRepository ByeRepository, IRepository HelpRepository, IRepository DownloadWebSiteRepository, IView view )
        {
            _myNameRepository = MyNameRepository;
            _jokeRepository = JokeRepository;
            _byeRepository = ByeRepository;
            _aphorismsRepository = AphorismsRepository;
            _helpRepository = HelpRepository;
            _downloadWebSiteRepository = DownloadWebSiteRepository;
            _history = history;
            _tasks = new Dictionary<string, ICommand>()
            {
                {"доброе утро", new HelloCommand(new HelloPhrase()) },
                {"добрый день", new HelloCommand(new HelloPhrase()) },
                {"добрый вечер", new HelloCommand(new HelloPhrase()) },
                {"доброй ночи", new HelloCommand(new HelloPhrase()) },
                {"привет", new HelloCommand(new HelloPhrase()) },
                {"здравствуй", new HelloCommand(new HelloPhrase()) },
                {"здравствуйте", new HelloCommand(new HelloPhrase()) },
                {"как тебя зовут?", new MyNameCommand(new MyNamePhrase(_myNameRepository)) },
                {"сколько времени?", new TimeCommand(new TimePhrase()) },
                {"анекдот", new JokeCommand(new JokePhrase(_jokeRepository)) },
                {"пока", new ByeCommad(new BuyPhrase(_byeRepository)) },
                {"до свидания", new ByeCommad(new BuyPhrase(_byeRepository)) },
                {"-help", new HelpCommand(new HelpPhrase(_helpRepository)) }
            };
            _view = view;
            _thread = new Thread(new ThreadStart(Check));
            _questionsQueue = new Queue<string>();
            _history.DownLoad();
            _thread.Start();
        }
        private void Check()
        {
            while(true)
            {
                if (_questionsQueue.Any())
                {
                    string question = _questionsQueue.Dequeue();
                    Task task = new Task(new Action(() => { Answer(question); }));
                    task.Start();
                    task.Wait();
                }
            }
        }
        private async void Answer(string question)
        {
            string answer;
            try
            {
                HttpClient client = new HttpClient();
                using (HttpResponseMessage response = client.GetAsync(question).Result)
                {
                    using (HttpContent content = response.Content)
                    {
                        string result = content.ReadAsStringAsync().Result;
                        using (StreamWriter file = new StreamWriter("downloadWebSite"))
                        {
                            await file.WriteLineAsync(result);
                        }
                        answer = new DownloadWebSiteCommand(new DownloadWebSitePhrase(_downloadWebSiteRepository)).Execute();
                        _history.Add(new HistoryModel() { Id = 0, dateTime = DateTime.Now, BotMessage = answer, Question = question });
                        _view.ViewAnswer(question, answer);
                        File.Delete("downloadWebSite");
                        return;
                    }
                }
            }
            catch { }
            await Task.Delay(300);
            if (_tasks.ContainsKey(question.ToLower()))
                answer = _tasks[question.ToLower()].Execute();
            else
                answer = new AphorismsCommand(new AphorismsPhrase(_aphorismsRepository)).Execute();
            _history.Add(new HistoryModel() { Id = 0, dateTime = DateTime.Now, BotMessage = answer, Question = question });
            _view.ViewAnswer(question, answer);  

        }
        public void Ask(string question)
        {
            _questionsQueue.Enqueue(question);
        }

        public void Dispose()
        {
            File.Delete("XMLRepository/Aphorisms");
            File.Delete("XMLRepository/Bye");
            File.Delete("XMLRepository/Joke");
            File.Delete("XMLRepository/MyName");
            File.Delete("XMLRepository/Help");
            Directory.Delete("XMLRepository");
            File.Delete("JSONRepository/MyName");
            File.Delete("JSONRepository/Joke");
            File.Delete("JSONRepository/Bye");
            File.Delete("JSONRepository/Aphorisms");
            File.Delete("JSONRepository/Help");
            Directory.Delete("JSONRepository");
        }
    }
}
