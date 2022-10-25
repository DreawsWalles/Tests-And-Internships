using RepositoryLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLib.MyName
{
    public class MyNamePhrase
    {
        private IRepository _repository;

        public MyNamePhrase(IRepository repository)
        {
            _repository = repository;
        }

        public string Say()
        {
            return _repository.Get(0);
        }
    }
}
