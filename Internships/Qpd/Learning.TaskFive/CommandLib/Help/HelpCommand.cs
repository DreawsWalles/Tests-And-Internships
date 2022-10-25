using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLib.Help
{
    public class HelpCommand : ICommand
    {
        private HelpPhrase _phrase;
        public HelpCommand(HelpPhrase phraseSet)
        {
            _phrase = phraseSet;
        }

        public string Execute()
        {
            return _phrase.Say();
        }
    }
}
