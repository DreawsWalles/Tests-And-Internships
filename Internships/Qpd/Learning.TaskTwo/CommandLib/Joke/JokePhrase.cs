using RepositoryLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLib.Joke
{
    public class JokePhrase
    {
        private IRepository _repository;
        public JokePhrase(IRepository repository)
        {
            _repository = repository;
        }
        
        public string Say()
        {
            return _repository.Get(new Random().Next(1, 17));
        }
    }
}
