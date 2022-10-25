using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLib.MyName
{
    public class MyNameCommand : ICommand
    {
        private MyNamePhrase _phrase;

        public MyNameCommand(MyNamePhrase phrase)
        {
            this._phrase = phrase;
        }

        public string Execute()
        {
            return _phrase.Say();
        }
    }
}
