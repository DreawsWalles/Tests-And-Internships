using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLib.Joke
{
    public class JokeCommand : ICommand
    {
        private JokePhrase _phrase;
        public JokeCommand(JokePhrase phraseSet)
        {
            _phrase = phraseSet;    
        }

        public string Execute()
        {
            return _phrase.Say();
        }
    }
}
