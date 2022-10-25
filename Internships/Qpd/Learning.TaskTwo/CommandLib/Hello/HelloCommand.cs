using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLib.Hello
{
    public class HelloCommand : ICommand
    {
        private HelloPhrase _phrase;
        public HelloCommand(HelloPhrase phraseSet)
        {
            _phrase = phraseSet;
        }
        public string Execute()
        {
            return _phrase.Say();
        }
    }
}
