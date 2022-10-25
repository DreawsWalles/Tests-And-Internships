using Help;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLib.FakeRepository
{
    public class FakeByeRepository : IRepository
    {
        public void Add(AskModel model) { }
        private static Dictionary<int, string> _command = new Dictionary<int, string>
        {
            {1, "Пока" },
            {2, "До свидания" }
        };
        public string Get(int id)
        {
            return _command[id];
        }
    }
}
