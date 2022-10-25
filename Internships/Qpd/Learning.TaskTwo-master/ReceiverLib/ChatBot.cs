using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLib;
using CommandLib.Aphorisms;
using RepositoryLib.FakeRepository;
using CommandLib.Hello;
using CommandLib.MyName;
using CommandLib.Time;
using CommandLib.Joke;
using CommandLib.Bye;

namespace ReceiverLib
{
    public class ChatBot
    {
        private ICommand[] _commands;

        public ChatBot()
        {
            _commands = new ICommand[] { new AphorismsCommand(new AphorismsPhrase(new FakeAphorismsRepository())), new HelloCommand(new HelloPhrase()), new MyNameCommand(new MyNamePhrase(new FakeMyNameRepository())),
                                         new TimeCommand(new TimePhrase()), new JokeCommand(new JokePhrase(new FakeJokeRepository())), new ByeCommad(new BuyPhrase(new FakeByeRepository()))};
        }
        private static Dictionary<string, int> _tasks = new Dictionary<string, int>()
        {
            {"доброе утро", 1 },
            {"добрый день", 1 },
            {"добрый вечер", 1 },
            {"доброй ночи", 1 },
            {"привет", 1 },
            {"здравствуй", 1 },
            {"здравствуйте", 1 },
            {"как тебя зовут?", 2 },
            {"сколько времени?", 3 },
            {"анекдот", 4 },
            {"пока", 5 },
            {"до свидания", 5 }
        };
        public string Ask(string task)
        {
            int index;
            if (_tasks.ContainsKey(task.ToLower()))
                index = _tasks[task.ToLower()];
            else
                index = 0;
            return _commands[index].Execute();
        }
    }
}
