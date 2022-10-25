using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLib.Bye
{
    public class ByeCommad : ICommand
    {
        private BuyPhrase _phrase;
        public ByeCommad(BuyPhrase phraseSet)
        {
            _phrase = phraseSet;
        }

        public string Execute()
        {
            return _phrase.Say();
        }
    }
}
