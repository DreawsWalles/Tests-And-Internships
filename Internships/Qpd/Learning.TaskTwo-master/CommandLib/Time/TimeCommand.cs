using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLib.Time
{
    public class TimeCommand : ICommand
    {
        private  TimePhrase _phrase;
        public TimeCommand(TimePhrase phraseSet)
        {
            _phrase = phraseSet;
        }

        public string Execute()
        {
            return _phrase.Say();
        }
    }
}
