using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewLib
{
    public interface IView
    {
        void View(string question, string answer);
    }
}
