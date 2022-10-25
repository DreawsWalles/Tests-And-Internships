using RepositoryLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLib.Aphorisms
{
    public class AphorismsCommand : ICommand
    {
        private AphorismsPhrase _phrase;
        public AphorismsCommand(AphorismsPhrase phraseSet)
        {
            _phrase = phraseSet;
        }

        public string Execute()
        {
            return _phrase.Say();
        }
    }
}
