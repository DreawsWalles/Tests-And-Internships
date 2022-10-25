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
using RepositoryLib;

namespace ReceiverLib
{
    public class ChatBot
    {
        private IRepository _aphorismsRepository;
        private static IRepository _myNameRepository;
        private static IRepository _jokeRepository;
        private static IRepository _byeRepository;

        public ChatBot(IRepository AphorismsRepository, IRepository MyNameRepository, IRepository JokeRepository, IRepository ByeRepository)
        {
            _myNameRepository = MyNameRepository;
            _jokeRepository = JokeRepository;
            _byeRepository = ByeRepository;
            _aphorismsRepository = AphorismsRepository;
        }
        private Dictionary<string, ICommand> _tasks = new Dictionary<string, ICommand>()
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
                {"до свидания", new ByeCommad(new BuyPhrase(_byeRepository)) }
        };

        public string Ask(string task)
        {
            if(_tasks.ContainsKey(task.ToLower()))
                return _tasks[task.ToLower()].Execute();
            return new AphorismsCommand(new AphorismsPhrase(_aphorismsRepository)).Execute();
        }
    }
}
